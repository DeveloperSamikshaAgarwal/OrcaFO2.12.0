using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using WinSCP;

namespace TradeStationToHedgeFund
{
    public class SecondHedgeFund
    {
        static string finalData = "";
        static string finalPositionData = "";
        public static void GenerateBTCPositionsTextFileAndSFTPTransfer(DataTable dt)
        {
            string startTime = DateTime.UtcNow.ToString("R");
            string startTimeInepoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();/*Convert.ToInt32(Convert.ToDateTime(startTime).Subtract(dateTime).TotalSeconds).ToString();*/
            UInt64 startEpoch = Convert.ToUInt64(startTimeInepoch) / 1000;
            finalData = dt.Rows[0]["modelname"] + "\n" + dt.Rows[0]["targetmaxpos"] + "\n\n# Execution timeframe\nexecution.startTime:=" + startTime + "\n";
            finalPositionData = "\n#Target exposures\n";
            foreach (DataRow dr in dt.Rows)
            {
                string positionBTC = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                string targetPositionBTC = "targetPositions.BTC:=" + positionBTC;
                finalPositionData += targetPositionBTC + "\n";
                break;
            }
            string endTime = DateTime.UtcNow.AddHours(1.0).ToString("R");
            string endTimeInepoch = DateTimeOffset.UtcNow.AddHours(1.0).ToUnixTimeMilliseconds().ToString();/*Convert.ToInt32(Convert.ToDateTime(endTime).Subtract(dateTime).TotalSeconds).ToString();*/
            UInt64 endEpoch = Convert.ToUInt64(endTimeInepoch) / 1000;
            finalData += "execution.endTime:=" + endTime + "\nexecution.startTimeInEpoch:=" + startEpoch + "\nexecution.endTimeInEpoch:=" + endEpoch + "\n\n";
            decimal sumofUSDNotional = Math.Round(dt.AsEnumerable().Sum(row => row.Field<decimal>("USDNotional")));
            finalData += finalPositionData + "\nexpectedPositions.USD:=" + sumofUSDNotional.ToString() + "\n\n#Metadata about the signal - to double check that the signal " +
                "is 'fresh'\nsignal.generationTime:=" + startTime + "\nsignal.generationTimeInEpoch:=" + startEpoch +
                "\nsignal.dataDate:=" + startTime + "\nsignal.dataDateInEpoch:=" + startEpoch;
            finalData += "\nsignal.price.dataDate:=" + startTime + "\nsignal.price.dataDateInEpoch:=" + startEpoch;
            string foldername = dt.Rows[0]["modelname"].ToString().Split(":=")[1];

            ExportAndSFTP(finalData, startEpoch.ToString(), Program.btcfilename, Program._incomingPath + foldername + "\\");
        }
        public static void GenerateEQPositionsTextFileAndSFTPTransfer(DataTable dt)
        {
            string startTime= DateTime.UtcNow.ToString("yyyy.MM.dd HH:mm:ss");
            string startTimeInepoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            UInt64 startEpoch=Convert.ToUInt64(startTimeInepoch) / 1000;
            finalData = dt.Rows[0]["modelname"] + "\n" + "\n\n# Execution timeframe\nexecution.startTime:=" + startTime +
                "\nexecution.startTimeInEpoch:=" + startEpoch.ToString() + "\n";
            finalPositionData = "\n# Signal values\n";
            foreach (DataRow dr in dt.Rows)
            {
                switch ((dr.Field<string>("ContractName").ToString()))
                {
                    case "ES":
                        string esFlag = Convert.ToInt32(dr.Field<int>("EQTradeHappen")).ToString();
                        string signalES = "signal.SPX:=" + esFlag;
                        finalPositionData += signalES + "\n";
                        break;
                    case "NQ":
                        string nqFlag = Convert.ToInt32(dr.Field<int>("EQTradeHappen")).ToString();
                        string signalNQ = "signal.NDX:=" + nqFlag;
                        finalPositionData += signalNQ + "\n";
                        break;
                    case "RTY":
                        string rtyFlag = Convert.ToInt32(dr.Field<int>("EQTradeHappen")).ToString();
                        string signalRTY = "signal.RTY:=" + rtyFlag;
                        finalPositionData += signalRTY + "\n";
                        break;
                    case "YM":
                        string ymFlag = Convert.ToInt32(dr.Field<int>("EQTradeHappen")).ToString();
                        string signalYM = "signal.YMX:=" + ymFlag;
                        finalPositionData += signalYM + "\n";
                        break;
                    default:

                        break;
                }
            }
            string endTime = DateTime.UtcNow.AddHours(1.0).ToString("yyyy.MM.dd HH:mm:ss");
            string endTimeInepoch = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeMilliseconds().ToString();
            UInt64 endEpoch = Convert.ToUInt64(endTimeInepoch) / 1000;
            finalData += "execution.endTime:=" + endTime  + "\nexecution.endTimeInEpoch:=" + endEpoch.ToString() + "\n\n";
            finalData+=finalPositionData+ "\n\n#Metadata about the signal - to double check that the signal is 'fresh'\nsignal.generationTime:=" + startTime + "\nsignal.generationTimeInEpoch:=" + startEpoch + "\nsignal.dataDate:=" + startTime + "\nsignal.dataDateInEpoch:=" + startEpoch;
            finalData += "\nsignal.price.dataDate:=" + startTime + "\nsignal.price.dataDateInEpoch:=" + startEpoch;
            string foldername = dt.Rows[0]["modelname"].ToString().Split(":=")[1];

            ExportAndSFTP(finalData, startEpoch.ToString(), Program.eqfilename, Program._incomingPath + foldername + "\\");
        }


        public static void GenerateFXPositionsTextFileAndSFTPTransfer(DataTable dt)
        {
            string startTime = DateTime.UtcNow.ToString("R");
            string startTimeInepoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(); //Convert.ToInt32(Convert.ToDateTime(startTime).Subtract(dateTime).TotalSeconds).ToString();*/
            UInt64 startEpoch = Convert.ToUInt64(startTimeInepoch) / 1000;
            Log.Logger.Information("");
            finalData = dt.Rows[0]["modelname"] + "\n" + dt.Rows[0]["targetmaxpos"] + "\n\n# Execution timeframe\nexecution.startTime:=" + startTime + "\n";
            finalPositionData = "\n#Target exposures\n";
            foreach (DataRow dr in dt.Rows)
            {
                switch ((dr.Field<string>("ContractName").ToString()))
                {
                    case "AD":
                        string positionAD = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionAD = "targetPositions.AUD:=" + positionAD;
                        finalPositionData += targetPositionAD + "\n";
                        break;
                    case "BP":
                        string positionBP = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionBP = "targetPositions.GBP:=" + positionBP;
                        finalPositionData += targetPositionBP + "\n";
                        break;
                    case "CD":
                        string positionCD = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionCD = "targetPositions.CAD:=" + positionCD;
                        finalPositionData += targetPositionCD + "\n";
                        break;
                    case "SF":
                        string positionSF = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionSF = "targetPositions.CHF:=" + positionSF;
                        finalPositionData += targetPositionSF + "\n";
                        break;
                    case "EC":
                        string positionEC = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionEC = "targetPositions.EUR:=" + positionEC;
                        finalPositionData += targetPositionEC + "\n";
                        break;
                    case "JY":
                        string positionJY = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionJY = "targetPositions.JPY:=" + positionJY;
                        finalPositionData += targetPositionJY + "\n";
                        break;
                    case "NE1":
                        string positionNE1 = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionNE1 = "targetPositions.NZD:=" + positionNE1;
                        finalPositionData += targetPositionNE1 + "\n";
                        break;
                    default:

                        break;
                }
            }
            string endTime = DateTime.UtcNow.AddHours(1.0).ToString("R");
            string endTimeInepoch = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeMilliseconds().ToString();
            UInt64 endEpoch = Convert.ToUInt64(endTimeInepoch) / 1000;
            finalData += "execution.endTime:=" + endTime + "\nexecution.startTimeInEpoch:=" + startEpoch.ToString() + "\nexecution.endTimeInEpoch:=" + endEpoch.ToString() + "\n\n";
            decimal sumofUSDNotional = Math.Round(dt.AsEnumerable().Sum(row => row.Field<decimal>("USDNotional")));
            finalData += finalPositionData + "\nexpectedPositions.USD:=" + sumofUSDNotional.ToString() + "\n\n#Metadata about the signal - to double check that the signal is 'fresh'\nsignal.generationTime:=" + startTime + "\nsignal.generationTimeInEpoch:=" + startEpoch + "\nsignal.dataDate:=" + startTime + "\nsignal.dataDateInEpoch:=" + startEpoch;
            finalData += "\nsignal.price.dataDate:=" + startTime + "\nsignal.price.dataDateInEpoch:=" + startEpoch;
            string foldername = dt.Rows[0]["modelname"].ToString().Split(":=")[1];
            ExportAndSFTP(finalData, startEpoch.ToString(), Program.fxfilename, Program._incomingPath + foldername + "\\");
        }
        public static void ExportAndSFTP(string text, string timeInEpoch, string filename, string path)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileName = path + filename + timeInEpoch + ".txt";
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(text);
                writer.Close();
            }
            try
            {

                SessionOptions remoteSession = new SessionOptions()//U5XA6YsxeUXW
                {
                    Protocol = Protocol.Sftp,
                    HostName = Program.winSCPserverIP1,
                    UserName = Program.winSCPUserID1,
                    Password = Program.password1,
                    PortNumber = Program.winSCPPortNumber1,
                    SshHostKeyFingerprint = Program.winSCPSshHostKeyFingerprint1,
                    SshPrivateKeyPath = Program.winSCPSshPrivateKeyPath1

                };

                Log.Logger.Information("SFTP Connection establishing...");

                using (Session session = new Session())
                {
                    session.Open(remoteSession);
                    Log.Logger.Information("SFTP Session to the HedgeFund-2 has been Opened");
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    transferOptions.PreserveTimestamp = false;
                    transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
                    TransferOperationResult transferOperationResult;
                    if (filename.Split(".targetPositions")[0] == "TMS75oB"/*paper_trading_FX*/)
                    {
                        transferOperationResult = session.PutFiles(fileName, Program.winSCPFXTodestinationPath1, false, transferOptions);
                        transferOperationResult.Check();
                        if (transferOperationResult.IsSuccess)
                        {
                            bool ab = SendingEmail.SendMail(new SendEmailModel()
                            {
                                CCEmail = Program.CCEmail,
                                bccMail=Program.bccMail,
                                EmailSubject = "[INFO] New target positions for " + filename.Split(".targetPositions")[0],
                                EmailBody = /*"ftp01.gtsx.com:*/"Upload [OK]",
                                PositionFilePath = fileName,
                                UserEmail = Program.UserEmailSuccess
                            });
                        }
                    }
                    else if (filename.Split(".signals")[0]== "TMS108B")
                    {
                        transferOperationResult = session.PutFiles(fileName, Program.winSCPEQTodestinationPath1, false, transferOptions);
                        transferOperationResult.Check();
                        if (transferOperationResult.IsSuccess)
                        {
                            bool ab = SendingEmail.SendMail(new SendEmailModel()
                            {
                                CCEmail = Program.CCEmail,
                                bccMail = Program.bccMail,
                                EmailSubject = "[INFO] New target positions for " + filename.Split(".signals")[0],
                                EmailBody = /*"ftp01.gtsx.com:*/"Upload [OK]",
                                PositionFilePath = fileName,
                                UserEmail = Program.UserEmailSuccess
                            });
                        }
                       
                    }
                    else
                    {
                        transferOperationResult = session.PutFiles(fileName, Program.winSCPToBTCDestinationPath1, false, transferOptions);
                        transferOperationResult.Check();
                        if (transferOperationResult.IsSuccess)
                        {
                            bool ab = SendingEmail.SendMail(new SendEmailModel()
                            {
                                CCEmail = Program.CCEmail /*"sameeksha@alliance-techfunctionals.com"*/,
                                bccMail = Program.bccMail,
                                EmailSubject = "[INFO] New target positions for " + filename.Split(".targetPositions")[0],
                                EmailBody = /*"ftp01.gtsx.com:*/ "Upload [OK]",
                                PositionFilePath = fileName,
                                UserEmail = Program.UserEmailSuccess /*"mbettaieb@capbonconsulting.com,capbonorca@gmail.com"*/
                            });
                        }
                       
                    }
                    transferOperationResult.Check();

                    if (transferOperationResult.IsSuccess)
                        Log.Logger.Information("File has been transferred properly to the hedge fund-2 " + filename);
                    else
                        Log.Logger.Error("Sorry, file cannot be transferred to Hedge Fund-2, some exception has occurred. Please check it" + fileName);
                    session.Close();
                    Log.Logger.Information("SFTP Session has been closed");

                }
                string filetypeforHF2 = "";
                if (filename.Contains(".targetPositions"))
                {
                    filetypeforHF2 = filename.Split(".targetPositions")[0];
                    
                }
                else if (filename.Contains(".signals"))
                {
                    filetypeforHF2 = filename.Split(".signals")[0];
                   
                }
                TransferFiletoAnotherfolderHF2(filetypeforHF2, path);

            }
            catch (Exception ex)
            {
                Log.Logger.Error("Exception occurred while Transferring file to the Hedge Fund" + ex);
                string portfolioname="";
                if (filename.Contains(".signals"))
                {
                     portfolioname = filename.Split(".signals")[0];
                }
                else
                {
                    portfolioname = filename.Split(".targetPositions")[0];
                }
                    bool ab = SendingEmail.SendMail(new SendEmailModel()
                    {
                        CCEmail = Program.CCEmail/*"sameeksha@alliance-techfunctionals.com"*/,
                        bccMail=Program.bccMail,
                        EmailSubject = "[ALERT] New target positions for " + portfolioname,
                        EmailBody = /*"ftp01.gtsx.com:*/"Upload [Failed]",
                        PositionFilePath = fileName,
                        UserEmail = Program.UserEmail/* "mbettaieb@capbonconsulting.com,capbonorca@gmail.com"*/
                    });
               
               
            }
        }

        static void TransferFiletoAnotherfolderHF2(string filetype, string path)
        {
            try
            {
                string filename = "";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!Directory.Exists(Program._processPath + "\\" + filetype + "\\"))
                {
                    Directory.CreateDirectory(Program._processPath + "\\" + filetype + "\\");
                }

                Log.Logger.Information("Moving a file from  " + path + " to " + Program._processPath + "\\" + filetype);
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                var getAllCSVFiles = directoryInfo.GetFiles("*.txt")
                                     .Select(file => file.Name).ToList();
                string dteStart = DateTime.Now.ToString("R");
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);

                string startTimeInepoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();    //Convert.ToInt32(Convert.ToDateTime(dteStart).Subtract(dateTime).TotalSeconds).ToString();
                if (filetype == "TMS75oB")
                {
                    filename = Program.fxfilename + startTimeInepoch + ".txt";
                }
                if (filetype == "paper_trading_Crypto")
                {
                    filename = Program.btcfilename + startTimeInepoch + ".txt";
                }
                if (filetype== "TMS108B")
                {
                    filename = Program.eqfilename + startTimeInepoch + ".txt";
                }
                foreach (var file in getAllCSVFiles)
                {
                    File.Move(path + "\\" + file, Program._processPath + "\\" + filetype + "\\" + filename);

                }
                Log.Logger.Information("File moved Successfully from  " + path + "  to  " + Program._processPath + "\\" + filetype);
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Exceptions occurs while moving a file locally" + ex.ToString());
            }
        }
        public static void UpdatePositionsintoDatabaseforHF2(string contractId, int newLots, decimal price)
        {
            DataTable dtIsFutureActiveornot = ISfutureisActive(contractId);
            var isContractActive = Convert.ToBoolean(dtIsFutureActiveornot.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 101).Select(x => x.Field<bool>("TobePublished")).FirstOrDefault());
            Log.Logger.Information("Contract is active or not for HF2 "+contractId+" "+isContractActive);
            if (isContractActive == true)
            {
                List<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@ContractId",
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt32(contractId)
                });
                sqlParameter.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@Lots",
                    Direction = ParameterDirection.Input,
                    Value = newLots
                });
                sqlParameter.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.Decimal,
                    ParameterName = "@Prices",
                    Direction = ParameterDirection.Input,
                    Value = price
                });
                Log.Logger.Information("Database Connection has been Opened for Updating the Positions inthe Database ");
                DBContext.ExecuteSp(Program.connectionString, "[Trade].[UpdatePositionsforHF2]", sqlParameter);
                Log.Logger.Information("Database Connection has been Closed after Updating the positions");
                //return true;
                DataTable dtAssetClass = DBContext.GetDataSetFromQuery(Program.connectionString, "select AssetClass from Trade.FutureSymbols where ContractId=" + contractId).Tables[0];
                if (Convert.ToInt32(contractId) != 126 && dtAssetClass.Rows[0]["AssetClass"].ToString() == "FX")
                {
                    Program.isThisFXTrade = true;

                }
                if (Convert.ToInt32(contractId) != 126 && dtAssetClass.Rows[0]["AssetClass"].ToString() != "FX")
                {
                    Program.isEQTrade = true;
                }
                if (Convert.ToInt32(contractId) == 126)
                {
                    Program.isBitcoinTrade = true;
                }
            }
            else
            {
                Log.Logger.Information("The Contract in which trade is happened is is not sent to the Hedge Fund 2");
            }

        }
        public static DataTable ISfutureisActive(string ContractId)
        {

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@ContractId",
                Direction = ParameterDirection.Input,
                Value = ContractId
            });

            DataTable dtIsActive = DBContext.FillUpDataSetFromSp(Program.connectionString, "Trade.FuturesStatusatgivenContractId", 5000, sqlParameters).Tables[0];
            return dtIsActive;
        }
    }
}
