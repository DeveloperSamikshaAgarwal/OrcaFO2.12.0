using Orca_FO_v2._12._0.EmailFunctionality;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;
using AppSetting = Orca_FO_v2._12._0.Utils.GetterData;

namespace Orca_FO_v2._12._0.PositonView
{
    public class TransfertoHF2
    {
        static string finalData = "";
        static string finalPositionData = "";
        // public static IConfigurationRoot _iconfiguration;
        //static string connectionString = "";

        static string path = AppSetting.SaveFilePath;
        static string btcfilename = AppSetting.btcfilename;
        static string fxfilename = AppSetting.fxfilename;
        static string winSCPserverIP = AppSetting.ServerHostNameHF2;
        static string winSCPUserID = AppSetting.ServerUserNameHF2;
        static string winSCPSshPrivateKeyPath = AppSetting.ServerSshPrivateKeyHF2;
        static int winSCPPortNumber = Convert.ToInt32(AppSetting.ServerPortNumber);
        static string winSCPSshHostKeyFingerprint = AppSetting.ServerSshHostKeyFingerprintHF2;
        static string winSCPFXTodestinationPath = AppSetting.ServerDirectoryForFXHF2;
        static string winSCPToBTCDestinationPath = AppSetting.ServerDirectoryForBTCHF2;
        static string winSCPToEQDestinationPath = AppSetting.ServerDirectoryForEQHF2;
        static string _processPath = AppSetting.ProcessFilePath;
        static string password = AppSetting.ServerPasswordHF2;
        static string userEmail = AppSetting.Recipients;
        static string cCEmail = AppSetting.CCmail;
        static string userEmailSuccess = AppSetting.RecipientsHF2;
        static string eqfilename = AppSetting.eqfilename;
        static string bccMail = AppSetting.BCCEmail;
        //static void GetAppSettingData()
        //{
        ////    var builder = new ConfigurationBuilder()
        ////                 .SetBasePath(Directory.GetCurrentDirectory())
        ////                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        ////    _iconfiguration = builder.Build();
        ////    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(_iconfiguration).CreateLogger();
        //    path = _iconfiguration.GetSection("AppSettings")["_SaveFilePath"];
        //    _processPath = _iconfiguration.GetSection("AppSettings")["_processPath"];
        //    btcfilename = _iconfiguration.GetSection("AppSettings")["btcfilename"];
        //    fxfilename = _iconfiguration.GetSection("AppSettings")["fxfilename"];

        //}
        public static void GenerateBTCPositionsTextFileAndSFTPTransfer(DataTable dt)
        {
            //GetAppSettingData();

            string startTime = DateTime.UtcNow.ToString("R");
            // DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);

            string startTimeInepoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();/*Convert.ToInt32(Convert.ToDateTime(startTime).Subtract(dateTime).TotalSeconds).ToString();*/
            UInt64 startEpochSec = Convert.ToUInt64(startTimeInepoch) / 1000;
            finalData = dt.Rows[0]["modelname"] + "\n" + dt.Rows[0]["targetmaxpos"] +
                "\n\n# Execution timeframe\nexecution.startTime:=" + startTime + "\n";
            finalPositionData = "\n#Target exposures\n";
            foreach (DataRow dr in dt.Rows)
            {
                string positionBTC = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                string targetPositionBTC = "targetPositions.BTC:=" + positionBTC;
                finalPositionData = finalPositionData + targetPositionBTC + "\n";
                break;
            }
            string endTime = DateTime.UtcNow.AddHours(1.0).ToString("R");
            string endTimeInepoch = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeMilliseconds().ToString(); /*Convert.ToInt32(Convert.ToDateTime(endTime).Subtract(dateTime).TotalSeconds).ToString();*/
            UInt64 endEpochSec = Convert.ToUInt64(endTimeInepoch) / 1000;
            finalData = finalData + "execution.endTime:=" + endTime + "\nexecution.startTimeInEpoch:=" + startEpochSec + "\nexecution.endTimeInEpoch:=" + endEpochSec + "\n\n";
            decimal sumofUSDNotional = Math.Round(dt.AsEnumerable().Sum(row => row.Field<decimal>("USDNotional")));
            finalData = finalData + finalPositionData + "\nexpectedPositions.USD:=" + sumofUSDNotional.ToString() + "\n\n#Metadata about the signal - to double check that the signal is 'fresh'\nsignal.generationTime:=" + startTime + "\nsignal.generationTimeInEpoch:="
                + startEpochSec + "\nsignal.dataDate:=" + startTime + "\nsignal.dataDateInEpoch:=" + startEpochSec;
            finalData = finalData + "\nsignal.price.dataDate:=" + startTime + "\nsignal.price.dataDateInEpoch:=" + startEpochSec;
            string foldername = dt.Rows[0]["modelname"].ToString().Split(new string[] { ":=" }, StringSplitOptions.None)[1];//':=')[1];

            ProduceFile(finalData, startEpochSec.ToString(), btcfilename, path + foldername + "\\");


        }
        public static void GenerateEQPositionsTextFileAndSFTPTransfer(DataTable dt)
        {
            string startTime = DateTime.UtcNow.ToString("yyyy.MM.dd HH:mm:ss");
            string startTimeInepoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            UInt64 startEpochSec = Convert.ToUInt64(startTimeInepoch) / 1000;
            finalData = dt.Rows[0]["modelname"] + "\n" + "\n\n# Execution timeframe\nexecution.startTime:=" + startTime + "\nexecution.startTimeInEpoch:=" + startEpochSec.ToString() + "\n";
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
            UInt64 endEpochSec = Convert.ToUInt64(endTimeInepoch) / 1000;
            finalData += "execution.endTime:=" + endTime + "\nexecution.endTimeInEpoch:=" + endEpochSec + "\n\n";
            finalData += finalPositionData + "\n\n#Metadata about the signal - to double check that the signal is 'fresh'\nsignal.generationTi" +
                "me:=" + startTime + "\nsignal.generationTimeInEpoch:=" + startEpochSec + "\nsignal.dataDate:=" + startTime + "\nsignal.dataDateInEpoch:=" + startEpochSec;
            finalData += "\nsignal.price.dataDate:=" + startTime + "\nsignal.price.dataDateInEpoch:=" + startEpochSec;
            string foldername = dt.Rows[0]["modelname"].ToString().Split(new string[] { ":=" }, StringSplitOptions.None)[1];

            ProduceFile(finalData, startEpochSec.ToString(), eqfilename, path + foldername + "\\");
        }

        public static void GenerateFXPositionsTextFileAndSFTPTransfer(DataTable dt)
        {
            string startTime = DateTime.UtcNow.ToString("R");
            string startTimeInepoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();/*Convert.ToInt32(Convert.ToDateTime(startTime).Subtract(dateTime).TotalSeconds).ToString();*/
            UInt64 startEpochSec = Convert.ToUInt64(startTimeInepoch) / 1000;
            finalData = dt.Rows[0]["modelname"] + "\n" + dt.Rows[0]["targetmaxpos"] + "\n\n# Execution timeframe\nexecution.startTime:=" + startTime + "\n";
            finalPositionData = "\n#Target exposures\n";
            foreach (DataRow dr in dt.Rows)
            {
                switch ((dr.Field<string>("ContractName").ToString()))
                {
                    case "AD":
                        string positionAD = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionAD = "targetPositions.AUD:=" + positionAD;
                        finalPositionData = finalPositionData + targetPositionAD + "\n";
                        break;
                    case "BP":
                        string positionBP = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionBP = "targetPositions.GBP:=" + positionBP;
                        finalPositionData = finalPositionData + targetPositionBP + "\n";
                        break;
                    case "CD":
                        string positionCD = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionCD = "targetPositions.CAD:=" + positionCD;
                        finalPositionData = finalPositionData + targetPositionCD + "\n";
                        break;
                    case "SF":
                        string positionSF = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionSF = "targetPositions.CHF:=" + positionSF;
                        finalPositionData = finalPositionData + targetPositionSF + "\n";
                        break;
                    case "EC":
                        string positionEC = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionEC = "targetPositions.EUR:=" + positionEC;
                        finalPositionData = finalPositionData + targetPositionEC + "\n";
                        break;
                    case "JY":
                        string positionJY = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionJY = "targetPositions.JPY:=" + positionJY;
                        finalPositionData = finalPositionData + targetPositionJY + "\n";
                        break;
                    case "NE1":
                        string positionNE1 = Math.Round(Convert.ToDecimal(dr.Field<decimal>("Notional"))).ToString();
                        string targetPositionNE1 = "targetPositions.NZD:=" + positionNE1;
                        finalPositionData = finalPositionData + targetPositionNE1 + "\n";
                        break;
                    default:

                        break;
                }

            }
            string endTime = DateTime.UtcNow.AddHours(1.0).ToString("R");
            string endTimeInepoch = DateTimeOffset.UtcNow.AddHours(1.0).ToUnixTimeMilliseconds().ToString(); /*Convert.ToInt32(Convert.ToDateTime(endTime).Subtract(dateTime).TotalSeconds).ToString();*/
            UInt64 endEpochSec = Convert.ToUInt64(endTimeInepoch) / 1000;
            finalData = finalData + "execution.endTime:=" + endTime + "\nexecution.startTimeInEpoch:=" + startEpochSec + "\nexecution.endTimeInEpoch:=" + endEpochSec + "\n\n";
            decimal sumofUSDNotional = Math.Round(dt.AsEnumerable().Sum(row => row.Field<decimal>("USDNotional")));
            finalData = finalData + finalPositionData + "\nexpectedPositions.USD:=" + sumofUSDNotional.ToString() + "\n\n#Metadata about the signal - to double check that the signal is 'fresh'\nsignal.generationTime:=" + startTime + "\nsignal.generationTimeInEpoch:=" + startEpochSec + "\nsignal.dataDate:=" + startTime + "\nsignal.dataDateInEpoch:=" + startEpochSec;
            finalData = finalData + "\nsignal.price.dataDate:=" + startTime + "\nsignal.price.dataDateInEpoch:=" + startEpochSec;
            string foldername = dt.Rows[0]["modelname"].ToString().Split(new string[] { ":=" }, StringSplitOptions.None)[1];

            ProduceFile(finalData, startEpochSec.ToString(), fxfilename, path + foldername + "\\");


        }
        public static void ProduceFile(string text, string timeInEpoch, string filename, string path)
        {
            //GetAppSettingData();
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

                SessionOptions remoteSession = new SessionOptions()
                {
                    Protocol = Protocol.Sftp,
                    HostName = winSCPserverIP,
                    UserName = winSCPUserID,
                    SshPrivateKeyPath = winSCPSshPrivateKeyPath,
                    Password = password,
                    PortNumber = winSCPPortNumber,
                    SshHostKeyFingerprint = winSCPSshHostKeyFingerprint
                };
                Session session = new Session();
                MainForm.log.Information("SFTP Connection establishing...");
                session.Open(remoteSession);
                MainForm.log.Information("SFTP Session to the HedgeFund has been Opened");
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;
                transferOptions.PreserveTimestamp = false;
                transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
                TransferOperationResult transferOperationResult;
                if (filename.Split(new string[] { ".targetPositions" }, StringSplitOptions.None)[0] == "TMS75oB"/*paper_trading_FX*/)
                {
                    transferOperationResult = session.PutFiles(fileName, winSCPFXTodestinationPath, false, transferOptions);
                    transferOperationResult.Check();
                    if (transferOperationResult.IsSuccess)
                    {
                        bool ab = SendingEmail.SendMail(new SendEmailModel()
                        {
                            CCEmail = cCEmail/*"mbettaieb@capbonconsulting.com]"*/,
                            BCCEmail=bccMail,
                            EmailSubject = "[INFO] New target positions for " + filename.Split(new string[] { ".targetPositions" }, StringSplitOptions.None)[0],
                            EmailBody = /*"ftp01.gtsx.com:*/"Upload [OK]",
                            PositionFilePath = fileName,
                            UserEmail = userEmailSuccess/*"s75-ops@striketechnologies.com"*/
                        });
                    }
                   
                }
                else if (filename.Split(new string[] { ".signals" }, StringSplitOptions.None)[0] == "TMS108B")
                {
                    transferOperationResult = session.PutFiles(fileName, winSCPToEQDestinationPath, false, transferOptions);
                    transferOperationResult.Check();
                    if (transferOperationResult.IsSuccess)
                    {
                        bool ab = SendingEmail.SendMail(new SendEmailModel()
                        {
                            CCEmail = cCEmail,
                            BCCEmail=bccMail,
                            EmailSubject = "[INFO] New target positions for " + filename.Split(new string[] { ".signals" }, StringSplitOptions.None)[0],
                            EmailBody = /*"ftp01.gtsx.com:*/"Upload [OK]",
                            PositionFilePath = fileName,
                            UserEmail = userEmailSuccess
                        });
                    }
                    
                }
                else
                {
                    transferOperationResult = session.PutFiles(fileName, winSCPToBTCDestinationPath, false, transferOptions);
                    transferOperationResult.Check();
                    if (transferOperationResult.IsSuccess)
                    {
                        bool ab = SendingEmail.SendMail(new SendEmailModel()
                        {
                            CCEmail = cCEmail/*"mbettaieb@capbonconsulting.com"*/,
                            BCCEmail=bccMail,
                            EmailSubject = "[INFO] New target positions for " + filename.Split(new string[] { ".targetPositions" }, StringSplitOptions.None)[0],
                            EmailBody = /*"ftp01.gtsx.com:*/"Upload [OK]",
                            PositionFilePath = fileName,
                            UserEmail = userEmailSuccess/*"s75-ops@striketechnologies.com"*/
                        });
                    }
                    
                }
                transferOperationResult.Check();

                if (transferOperationResult.IsSuccess)
                {
                    MainForm.log.Information("File has been transferred properly to the hedge fund " + filename);
                    MessageBox.Show("File has been transferred properly to the hedge fund " + filename, Application.ProductName);
                }
                else
                {
                    MainForm.log.Error("Sorry, file cannot be transferred, some exception has occurred. Please check it" + fileName);
                    MessageBox.Show("Sorry, file cannot be transferred, some exception has occurred. Please check it" + filename, Application.ProductName);
                }

                session.Close();
                MainForm.log.Information("SFTP Session has been closed");
                string filetypeforHF2 = "";
                if (filename.Contains(".targetPositions"))
                {
                    filetypeforHF2 = filename.Split(new string[] { ".targetPositions" }, StringSplitOptions.None)[0];

                }
                else if (filename.Contains(".signals"))
                {
                    filetypeforHF2 = filename.Split(new string[] { ".signals" }, StringSplitOptions.None)[0];

                }
                TransferFiletoAnotherfolderHF2(filetypeforHF2, path);
            }
            catch (Exception ex)
            {
                string portfolioname = "";
                if (filename.Contains(".signals"))
                {
                    portfolioname = filename.Split(new string[] { ".signals" }, StringSplitOptions.None)[0];
                }
                else
                {
                    portfolioname = filename.Split(new string[] { ".targetPositions" }, StringSplitOptions.None)[0];
                }
                MainForm.log.Error("Exception occurred while Transferring file to the Hedge Fund" + ex);
                bool ab = SendingEmail.SendMail(new SendEmailModel()
                {
                    CCEmail = cCEmail/*"sameeksha@alliance-techfunctionals.com"*/,
                    BCCEmail=bccMail,
                    EmailSubject = "[Alert] New target positions for " + portfolioname,
                    EmailBody = /*"ftp01.gtsx.com:*/"Upload [Failed]",
                    PositionFilePath = fileName,
                    UserEmail = userEmail/*"sameeksha@alliance-techfunctionals.com"*//*"mbettaieb@capbonconsulting.com,capbonorca@gmail.com,mbelaid@capbonconsulting.com,anuj@alliance-techfunctionals.com"*/
                });
                MessageBox.Show("Sorry, file cannot be transferred, some exception has occurred. Please check it.", Application.ProductName);
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
                if (!Directory.Exists(_processPath + "\\" + filetype + "\\"))
                {
                    Directory.CreateDirectory(_processPath + "\\" + filetype + "\\");
                }

                MainForm.log.Information("Moving a file from  " + path + " to " + _processPath + "\\" + filetype);
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                var getAllCSVFiles = directoryInfo.GetFiles("*.txt")
                                     .Select(file => file.Name).ToList();
                string startTime = DateTime.Now.ToString("R");
               // DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);

                string startTimeInepoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();    //Convert.ToInt32(Convert.ToDateTime(startTime).Subtract(dateTime).TotalSeconds).ToString();
                if (filetype == "TMS75oB"/*paper_trading_FX"*/)
                {
                    filename = fxfilename + startTimeInepoch + ".txt";
                }

                if (filetype == "TMS108B")
                {
                    filename = eqfilename + startTimeInepoch + ".txt";
                }
                if (filetype == "paper_trading_Crypto")
                {
                    filename = btcfilename + startTimeInepoch + ".txt";
                }

                foreach (var file in getAllCSVFiles)
                {
                    File.Move(path + "\\" + file, _processPath + "\\" + filetype + "\\" + filename);
                }
                MainForm.log.Information("File moved Successfully from  " + path + "  to  " + _processPath + "\\" + filetype);
            }
            catch (Exception ex)
            {
                MainForm.log.Error("Exceptions occurs while moving a file locally" + ex.ToString());
            }
        }
    }
}
