using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using WinSCP;
using System.Data;
using System.Threading.Tasks;
using System.Globalization;

using System.Threading;
using System.Text;

namespace TradeStationToHedgeFund
{
    public class Program
    {
        public static IConfigurationRoot _iconfiguration;
        public static String _incomingPath;
        public static String _processPath;
        static DataTable dtEMEA = new DataTable();
        static DataTable dtAPAC = new DataTable();
        static TimeSpan emeaStartTime = new TimeSpan();
        static TimeSpan emeaEndTime = new TimeSpan();

        static TimeSpan autoPilotFinishTime = new TimeSpan();
        static string dayOfWeek = "";
        //static int autoPilotFinishTime = 0;
        static string[] arrAllCurrencyFutures = { "" };
        static string autoPilotFinishDayOfWeek = "";
        static TimeSpan currentSysTime = new TimeSpan();
        static int position = 0;
        static string marketTimeZone = "";
        static bool doIhaveToTransfer = false;
        static DataSet dtnetOpenPositions = new DataSet();
        public static string connectionString;
        static string winSCPserverIP;
        static string winSCPUserID;
        static string winSCPSshPrivateKeyPath;
        static int winSCPPortNumber;
        static string winSCPSshHostKeyFingerprint;
        static string maximumOpenPositon;
        static string dirLocationOfTradeStationFiles = Directory.GetCurrentDirectory();
        static string winSCPToEMEADestinationPath;
        static string winSCPToAPACDestinationPath;
        public static string btcfilename = "";
        public static string fxfilename = "";
        public static string eqfilename = "";
        public static string winSCPserverIP1 = "";
        public static string winSCPUserID1 = "";
        public static string password1 = "";
        public static int winSCPPortNumber1;
        public static string winSCPSshHostKeyFingerprint1 = "";
        public static string winSCPFXTodestinationPath1 = "";
        public static string winSCPEQTodestinationPath1 = "";
        public static string winSCPToBTCDestinationPath1 = "";
        public static string winSCPSshPrivateKeyPath1 = "";
        public static string filepath;
        static DirectoryInfo directoryInfo = new DirectoryInfo(dirLocationOfTradeStationFiles);
        static string FileName = "";
        static DataTable dtFutureSym = new DataTable();
        static DataTable dtCurrFutures = new DataTable();
        static DataTable dtBitcoins = new DataTable();
        public static bool isThisFXTrade = false;
        public static bool isBitcoinTrade = false;
        public static bool isEQTrade = false;
        public static string UserEmail;
        public static string CCEmail;
        public static string bccMail = "";
        public static string UserEmailSuccess;
        static int count;
        static int proccessRelaxTime;
        static int tradeStationRefreshTime;
        static void Main(string[] args)
        {
            try
            {
                GetAppSettingsData();
                Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(_iconfiguration).CreateLogger();
                Log.Logger.Information("Received AppConfig for the first time and successfully parsed the values ..");
                while (true)
                {
                    currentSysTime = DateTime.Now.TimeOfDay;
                    dayOfWeek = DateTime.Now.DayOfWeek.ToString();
                    if (dayOfWeek == autoPilotFinishDayOfWeek && currentSysTime >= autoPilotFinishTime)
                    {
                        break;
                    }
                    doIhaveToTransfer = false;
                    isThisFXTrade = false;
                    isBitcoinTrade = false;
                    isEQTrade = false;
                    DataTable futureFilesLastActivities = GetFilesLastUpdatedActivities();
                    marketTimeZone = ((currentSysTime >= emeaStartTime) && (currentSysTime <= emeaEndTime)) ? "EMEA" : "APAC";
                    Log.Logger.Information("Current Time Zone is == " + marketTimeZone);
                    ReadlastUpdatedFiles(futureFilesLastActivities, marketTimeZone);
                    Log.Logger.Information("Finished Processing The Files");

                    if (doIhaveToTransfer == true)
                    {
                        Log.Logger.Information("Tranferring to the HedgeFund-1 Now");
                        Log.Logger.Information("there has been an Update for HF1 and we SFTP the files in this iteration");
                        TransferFilesToFirstHedgeFund(marketTimeZone);
                        Log.Logger.Information("Tranfererred the Files to HF1");
                    }
                    else
                    {
                        Log.Logger.Information("there has NOT BEEN any Update for HF1 and we DO NOT SFTP the files in this iteration");
                    }

                    if (isThisFXTrade == true)
                    {
                        Log.Logger.Information("Tranferring to HedgeFund -2 Now");
                        Log.Logger.Information("there has been an Update in FX for HF2 and we SFTP the files in this iteration");
                        DataTable dtFXPositions = DBContext.FillUpDataSetFromSp(connectionString, "[Trade].[GenerateFXPositionsForEntity2]", 5000, null).Tables[0];
                        SecondHedgeFund.GenerateFXPositionsTextFileAndSFTPTransfer(dtFXPositions);
                    }
                    else
                    {
                        Log.Logger.Information("there has NOT BEEN any Update in FX for HF2 and we DO NOT SFTP the files in this iteration");
                    }

                    if (isBitcoinTrade == true)
                    {

                        Log.Logger.Information("Tranferring to HedgeFund - 2 Now");
                        Log.Logger.Information("there has been an Update in Bitcoins for HF2 and we SFTP the files in this iteration");
                        DataTable dtBTCPositions = DBContext.FillUpDataSetFromSp(connectionString, "[Trade].[GenerateBTCPositionsForEntity2]", 5000, null).Tables[0];
                        SecondHedgeFund.GenerateBTCPositionsTextFileAndSFTPTransfer(dtBTCPositions);
                    }
                    else
                    {
                        Log.Logger.Information("there has NOT BEEN any Update in Bitcoin for HF2 and we DO NOT SFTP the files in this iteration");
                    }
                    if (isEQTrade == true)
                    {
                        Log.Logger.Information("Transferring to HedgeFund-2 Now");
                        Log.Logger.Information("there has been an Update in Equity for HF2 and we SFTP the files in this iteration");
                        DataTable dtEQSignal = DBContext.FillUpDataSetFromSp(connectionString, "[Trade].[GenerateEQPositionsForEntity2]").Tables[0]; ;
                        SecondHedgeFund.GenerateEQPositionsTextFileAndSFTPTransfer(dtEQSignal);    
                    }
                    else
                    {
                        Log.Logger.Information("there has NOT BEEN any Update in Equity for HF2 and we DO NOT SFTP the files in this iteration");
                    }
                    Log.Logger.Information("One Iteration Completed - so sleep time!");
                    Thread.Sleep(proccessRelaxTime);
                    Log.Logger.Information("wake up now!");

                }
            }

            catch (Exception e)
            {
                Log.Logger.Error("some exception occurs -- " + e);
            }
            Log.Logger.Information("Auto-Pilot Time Finishes Up! ");
        }
        public static void GetAppSettingsData()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                _iconfiguration = builder.Build();

                connectionString = _iconfiguration.GetSection("ConnectionString")["SqlConnectionString"];

                string query = "select lower( concat(contractName, currentmonthtraded)) as FileNamesToRead,ContractId,AssetClass" +
                    "  from Trade.FutureSymbols order by HFPreference";
                dtFutureSym = DBContext.GetDataSetFromQuery(connectionString, query).Tables[0];

                dirLocationOfTradeStationFiles = _iconfiguration.GetSection("TradeStation")["IncomingFuturesFileDirectory"];
                directoryInfo = new DirectoryInfo(dirLocationOfTradeStationFiles);
                filepath = _iconfiguration.GetSection("AppSettings")["_SaveFilePath"];
                autoPilotFinishDayOfWeek = Convert.ToString(_iconfiguration.GetSection("Time")["AutoPilotFinishDayOfWeek"]);
                proccessRelaxTime = Convert.ToInt32(_iconfiguration.GetSection("Time")["ProccessRelaxTime"]);
                tradeStationRefreshTime= Convert.ToInt32(_iconfiguration.GetSection("Time")["TradeStationRefreshTime"]);
                maximumOpenPositon = _iconfiguration.GetSection("TradeStation")["MaximumOpenPosition"];

                winSCPserverIP = _iconfiguration.GetSection("WinSCPSftp")["HostName"];
                winSCPUserID = _iconfiguration.GetSection("WinSCPSftp")["UserName"];
                winSCPSshPrivateKeyPath = _iconfiguration.GetSection("WinSCPSftp")["SshPrivateKeyPath"];
                winSCPPortNumber = Convert.ToInt32(_iconfiguration.GetSection("WinSCPSftp")["PortNumber"]);
                winSCPSshHostKeyFingerprint = _iconfiguration.GetSection("WinSCPSftp")["SshHostKeyFingerprint"];
                // winSCPSourcePath  filepath; // _iconfiguration.GetSection("WinSCPSftp")["SourcePath"];
                winSCPToEMEADestinationPath = _iconfiguration.GetSection("WinSCPSftp")["DirectoryForEMEA"];
                winSCPToAPACDestinationPath = _iconfiguration.GetSection("WinSCPSftp")["DirectoryForAPAC"];

                _incomingPath = _iconfiguration.GetSection("AppSettings")["_SaveFilePath"];

                _processPath = _iconfiguration.GetSection("AppSettings")["_processPath"];

                emeaStartTime = DateTime.Parse(_iconfiguration.GetSection("Time")["EMEASTARTTIME"]).TimeOfDay;
                emeaEndTime = DateTime.Parse(_iconfiguration.GetSection("Time")["EMEAENDTIME"]).TimeOfDay;
                autoPilotFinishTime = DateTime.Parse(_iconfiguration.GetSection("Time")["AutoPilotFinishTime"]).TimeOfDay; //.Hours;
                FileName = _iconfiguration.GetSection("AppSettings")["filename"];

                //Read HedgeFund 2 details over here 
                btcfilename = _iconfiguration.GetSection("AppSettings")["btcfilename"];
                fxfilename = _iconfiguration.GetSection("AppSettings")["fxfilename"];
                eqfilename = _iconfiguration.GetSection("AppSettings")["eqfilename"];
                winSCPserverIP1 = _iconfiguration.GetSection("WinSCPSftpForHF2")["HostName"];
                winSCPUserID1 = _iconfiguration.GetSection("WinSCPSftpForHF2")["UserName"];
                password1 = _iconfiguration.GetSection("WinSCPSftpForHF2")["Password"];
                winSCPPortNumber1 = Convert.ToInt32(_iconfiguration.GetSection("WinSCPSftpForHF2")["PortNumber"]);
                winSCPSshHostKeyFingerprint1 = _iconfiguration.GetSection("WinSCPSftpForHF2")["SshHostKeyFingerprint"];
                winSCPFXTodestinationPath1 = _iconfiguration.GetSection("WinSCPSftpForHF2")["DirectoryForFX"];
                winSCPToBTCDestinationPath1 = _iconfiguration.GetSection("WinSCPSftpForHF2")["DirectoryForBitCoins"];
                winSCPEQTodestinationPath1 = _iconfiguration.GetSection("WinSCPSftpForHF2")["DirectoryForEQ"];
                winSCPSshPrivateKeyPath1 = _iconfiguration.GetSection("WinSCPSftpForHF2")["SshPrivateKeyPath"];
                UserEmail = _iconfiguration.GetSection("EmailRecipients")["UserEmail"];
                CCEmail = _iconfiguration.GetSection("EmailRecipients")["CCEmail"];
                UserEmailSuccess = _iconfiguration.GetSection("EmailRecipients")["UserEmailSuccess"];
                bccMail= _iconfiguration.GetSection("EmailRecipients")["bccMail"]; 

            }
            catch (Exception ex)
            {
                Log.Logger.Error("some exception has occurred while reading the appsettings.json, please check " + ex);
            }

        }

        static void ReadlastUpdatedFiles(DataTable dt, string marketTimeZone)
        {
            int count = 0;
            DataTable dtUpdatedFile = new DataTable();
            dtUpdatedFile.Columns.Add("FileName", typeof(FileInfo));
            Log.Logger.Information("Total count of current traded contracts in ORCA "+dtFutureSym.Rows.Count);
            for (int i = 0; i < dtFutureSym.Rows.Count; i++)
            {
                string fileN = dtFutureSym.Rows[i]["FileNamesToRead"].ToString() + ".txt";
                FileInfo filename = directoryInfo.GetFiles(fileN).FirstOrDefault();
                Log.Logger.Information("Value of FileNameToRead: "+fileN+ " and filename: "+filename);
                if (filename != null)
                {
                    Log.Logger.Information("checking the status of file ==> " + filename.Name);

                    var lastUpdateTimeOfMyFile = File.GetLastWriteTime(filename.FullName);
                    DataView dv = dtFutureSym.DefaultView;
                    dv.RowFilter = "FileNamesToRead='" + filename.Name.Split(".")[0] + "'";
                    DataTable dtContractID = dv.ToTable();
                    string filenamewithoutextension = filename.Name.Split('.')[0];
                    DataRow drows = dt.Select("ContractId = '" + dtContractID.Rows[0]["ContractId"].ToString() + "'")[0];
                    
                    Log.Logger.Information("count of the which was read by the ORCA "+ count++);
                    if ((DateTime.Parse(lastUpdateTimeOfMyFile.ToString())) > (DateTime.Parse(drows["LastReadAt"].ToString())))
                    {
                        Log.Logger.Information(filename.Name + " >> This file has been Changed now.. Update the  DatabaseTable FileReadActivityMonitor first for the next round with the latest accesstime..");
                        updateFileInfo(dtContractID.Rows[0]["ContractId"].ToString(), lastUpdateTimeOfMyFile);
                        DataRow dr=dtUpdatedFile.NewRow();
                       dr["FileName"] = filename;
                        dtUpdatedFile.Rows.Add(dr);   
                    }
                    else
                    {
                        Log.Logger.Information(filename.Name + " >> This file has NOT been Changed now.." + " last write time is == " + lastUpdateTimeOfMyFile);
                    }
                }

            }
            string aa = "";
            if (/*count == dtFutureSym.Rows.Coun &&*/ dtUpdatedFile.Rows.Count>0)
            {
                Thread.Sleep(tradeStationRefreshTime);
                for (int j = 0; j < dtUpdatedFile.Rows.Count; j++)
                {
                    FileInfo filetobeprocessed = (FileInfo)dtUpdatedFile.Rows[j]["FileName"];
                    Log.Logger.Information("Updated FileReadActivityMonitor for file " + filetobeprocessed.Name + " with the latest values ...");
                    Log.Logger.Information(filetobeprocessed.Name + " Reading The Last Line of this File to ensure is it just refresh or actual updation");
                    string FileNametoProcess = filetobeprocessed.Name.ToString().Split(".txt")[0];
                    int length = FileNametoProcess.Split(".txt")[0].Length - 3;
                    DataTable dtContrctIdforprocess = DBContext.GetDataSetFromQuery(connectionString, "select ContractId from Trade.FutureSymbols where ContractName='" + FileNametoProcess.Substring(0, length) + "'").Tables[0];
                    ReadAndProcessTradeStationFuturesPositions(filetobeprocessed, dtContrctIdforprocess.Rows[0]["ContractId"].ToString(), marketTimeZone);
                }
            }
            //else
            //{
            //    Log.Logger.Information("Files are refreshed there is no true change in the file");
            //}
        }
 

        static void ReadAndProcessTradeStationFuturesPositions(FileInfo filename, String ContractId, string marketTimeZone)
        {
            try
            {
                int exsistingPosition_APAC = 0;
                int exsistingPosition_EMEA = 0;

                DataTable dtexsistingPositionsfromDB = RetrieveExistingPositions(ContractId);
                int exsistingPosition_HF2 = 0;

                if (Convert.ToString(dtexsistingPositionsfromDB.Rows[0]["ExistingPositions_APAC"]) != null && Convert.ToString(dtexsistingPositionsfromDB.Rows[0]["ExistingPositions_APAC"]) != "")
                {
                    exsistingPosition_APAC = Convert.ToInt32(dtexsistingPositionsfromDB.Rows[0]["ExistingPositions_APAC"].ToString());

                }
                if (Convert.ToString(dtexsistingPositionsfromDB.Rows[0]["ExistingPositions_EMEA"]) != null && Convert.ToString(dtexsistingPositionsfromDB.Rows[0]["ExistingPositions_EMEA"]) != "")
                {
                    exsistingPosition_EMEA = Convert.ToInt32(dtexsistingPositionsfromDB.Rows[0]["ExistingPositions_EMEA"].ToString());
                }
                if (Convert.ToString(dtexsistingPositionsfromDB.Rows[0]["Lots"]) != null && Convert.ToString(dtexsistingPositionsfromDB.Rows[0]["Lots"]) != "")
                {
                    exsistingPosition_HF2 = Convert.ToInt32(dtexsistingPositionsfromDB.Rows[0]["Lots"]);
                }

                int tolExsistingPositions = exsistingPosition_APAC + exsistingPosition_EMEA;
                Log.Logger.Information("APAC existing position for this contract " + filename.Name + " == " + exsistingPosition_APAC);
                Log.Logger.Information("EMEa existing position for this contract " + filename.Name + " == " + exsistingPosition_EMEA);
                Log.Logger.Information("EMEa existing position for this contract " + filename.Name + " == " + exsistingPosition_HF2);
                Log.Logger.Information("TOTAL existing position for this contract " + filename.Name + " == " + tolExsistingPositions);

                Log.Logger.Information("Start To Read Futures  File " + filename);


                string fileName = filename.Name.Split(".")[0];
                int realPositon = 0;
                int delta = 0;
                int delta1 = 0;
                var fs = new FileStream(filename.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader rd = new StreamReader(fs))
                {
                    string ex="";
                    string averagePrice = "";
                    decimal avgPrice1 = 0;
                    decimal avgPrice = 0;
                    string bs = "";
                    if (fs.Length>0)
                    {
                        string[] tradeLines = rd.ReadToEnd().ToUpper().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        int lastrow = tradeLines.Length - 1;
                         ex = tradeLines[lastrow].Split("EX=")[1].Split(" ST=")[0];
                        Log.Logger.Information("ex value == " + ex);

                         averagePrice = tradeLines[lastrow].Split("AVG=")[1].Split(" ")[0];
                         avgPrice = Convert.ToDecimal(averagePrice);
                         avgPrice1 = Convert.ToDecimal(averagePrice);
                         bs = tradeLines[lastrow].Split("BS=")[1].Split(" ")[0];
                        int qty = int.Parse(tradeLines[lastrow].Split("QTY=")[1].Split(" ")[0].Split("/")[0]);
                        realPositon = bs.Contains("BUY") ? qty * 1 : qty * -1;

                    }
                    else
                    {
                        realPositon = 0;
                        avgPrice = 0;
                        avgPrice1 = 0;

                    }
                   

                    if (ex.Contains("EXIT"))
                    {
                        realPositon = 0;
                    }
                    if (realPositon == exsistingPosition_HF2 && realPositon == tolExsistingPositions)
                    {

                        Log.Logger.Information("There is no change in file for filename " + filename + " in case where EX is " + ex);
                        Log.Logger.Information("this looks to me as a false alarm as existing position matches up with realposition from file for HF1 and HF2 both");

                    }
                    else
                    {
                        Log.Logger.Information("this looks to me as a TRUE alarm as existing position does not matches up with realposition from file");
                        if (realPositon != tolExsistingPositions)
                        {
                            delta = realPositon - tolExsistingPositions;
                        }
                        else if (realPositon == tolExsistingPositions)
                        {
                            Log.Logger.Information("There is no change in file for filename " + filename + " in case where EX is " + ex);
                            Log.Logger.Information("this looks to me as a false alarm for HF1 as existing position matches up with realposition from file"/* but it is not true for HF2"*/);
                        }
                        if (realPositon != exsistingPosition_HF2)
                        {
                            delta1 = realPositon - exsistingPosition_HF2;
                        }
                        else if (realPositon == exsistingPosition_HF2)
                        {
                            Log.Logger.Information("There is no change in file for filename " + filename + " in case where EX is " + ex);
                            Log.Logger.Information("this looks to me as a false alarm for HF2 as existing position matches up with realposition from file"/* but it is not true for HF1"*/);
                        }
                        Log.Logger.Information("Delta computed for HF1 == " + delta);
                        Log.Logger.Information("Delta computed HF2 == " + delta1);

                        if (marketTimeZone == "APAC" && realPositon != tolExsistingPositions)
                        {
                            delta += exsistingPosition_APAC;
                        }

                        if (marketTimeZone == "EMEA" && realPositon != tolExsistingPositions)
                        {
                            delta += exsistingPosition_EMEA;
                        }
                        if (realPositon != exsistingPosition_HF2)
                        {
                            delta1 += exsistingPosition_HF2;
                        }

                        if (delta == 0)
                        {
                            avgPrice = 0;
                        }
                        if (delta1 == 0)
                        {
                            avgPrice1 = 0;
                        }

                        if (ex.Contains("EXIT"))
                        {
                            Log.Logger.Information("If there is the changes in the  positions and also it is an exit");
                            DataTable isAdaptorActive = CommonClass.ActiveadaptorList();
                            var isHF1Active = Convert.ToBoolean(isAdaptorActive.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 100 && x.Field<string>("Portfolio") == marketTimeZone).Select(x => x.Field<bool>("isThisActive")).FirstOrDefault());
                            if (isHF1Active == true && realPositon != tolExsistingPositions)
                            {
                                UpdateFuturePositionFileDataIntoDataBase(ContractId, delta, ex, avgPrice, marketTimeZone);
                                Log.Logger.Information("marketTimeZone = " + marketTimeZone + " final update delta for HF1= + " + delta + "  average price = " + avgPrice);
                            }
                            else
                            {
                                Log.Logger.Information("HF1 is deactivated for Porfolio" + marketTimeZone + "and" + isHF1Active + "or there is no change in the position " + fileName);
                            }
                            bool isBitcoin = dtFutureSym.AsEnumerable().Where(x => x.Field<string>("AssetClass") == "Bitcoin").Any(row => row.Field<string>("FileNamesToRead") == filename.Name.Split(".")[0]);
                            bool isEQ = dtFutureSym.AsEnumerable().Where(x => x.Field<string>("AssetClass") == "Equity Indices").Any(row => row.Field<string>("FileNamesToRead") == filename.Name.Split(".")[0]);
                            bool isHF2ActiveEQ = Convert.ToBoolean(isAdaptorActive.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 101 && x.Field<string>("Portfolio") == "EQ").Select(x => x.Field<bool>("isThisActive")).FirstOrDefault());
                            bool isHF2ActiveFX = Convert.ToBoolean(isAdaptorActive.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 101 && x.Field<string>("Portfolio") == "FX").Select(x => x.Field<bool>("isThisActive")).FirstOrDefault());
                            bool isHF2ActiveBTC = Convert.ToBoolean(isAdaptorActive.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 101 && x.Field<string>("Portfolio") == "Bitcoin").Select(x => x.Field<bool>("isThisActive")).FirstOrDefault());
                            if ((isHF2ActiveFX == true || isHF2ActiveBTC == true || isHF2ActiveEQ == true) && (realPositon != exsistingPosition_HF2))
                            {
                                if (isBitcoin == false && isHF2ActiveFX == true && isEQ == false)
                                {
                                    //List<SqlParameter> sqls = new List<SqlParameter>();
                                    //sqls.Add(new SqlParameter()
                                    //{
                                    //    SqlDbType = SqlDbType.Int,
                                    //    ParameterName = "@ContractId",
                                    //    Direction = ParameterDirection.Input,
                                    //    Value = Convert.ToInt32(ContractId)

                                    //});
                                    //sqls.Add(new SqlParameter()
                                    //{
                                    //    SqlDbType = SqlDbType.Int,
                                    //    ParameterName = "@Lots",
                                    //    Direction = ParameterDirection.Input,
                                    //    Value = delta1

                                    //});
                                    //sqls.Add(new SqlParameter()
                                    //{
                                    //    SqlDbType = SqlDbType.Int,
                                    //    ParameterName = "@Prices",
                                    //    Direction = ParameterDirection.Input,
                                    //    Value = avgPrice1

                                    //});

                                   // DataSet isExccess = DBContext.FillUpDataSetFromSp(connectionString,"Trade.CalcLimitsAndIsExccessed",5000,sqls);
                                    Log.Logger.Information("If there is the changes in the currency positions and also it is an exit");
                                    SecondHedgeFund.UpdatePositionsintoDatabaseforHF2(ContractId, delta1, avgPrice1);
                                    Log.Logger.Information("ContractId = " + ContractId + " final update delta HF2= + " + delta1 + "  average price = " + avgPrice1 + "FX is activated" + isHF2ActiveFX);
                                }
                                else if (isBitcoin == true && isHF2ActiveBTC == true && isEQ == false)
                                {
                                    Log.Logger.Information("If there is the changes in the Bitcoin positions and also it is an exit");
                                    SecondHedgeFund.UpdatePositionsintoDatabaseforHF2(ContractId, delta1, avgPrice1);
                                    Log.Logger.Information("ContractId = " + ContractId + " final update delta HF2= + " + delta1 + "  average price = " + avgPrice1 + "Bitcoin is activated" + isHF2ActiveBTC);
                                }
                                else if (isBitcoin == false && isHF2ActiveEQ == true && isEQ == true)
                                {
                                    Log.Logger.Information("If there is the changes in the Equity positions and also it is an entry");
                                    SecondHedgeFund.UpdatePositionsintoDatabaseforHF2(ContractId, delta1, avgPrice1);
                                    Log.Logger.Information("ContractId = " + ContractId + " final update delta HF2= + " + delta1 + "  average price = " + avgPrice1 + "Equity is activated" + isHF2ActiveEQ);
                                }
                                else
                                {
                                    Log.Logger.Information("HF2 is Activated/deactivated for Bitcoin" + isHF2ActiveBTC + " and for FX" + isHF2ActiveFX + "or there is no change in the position " + fileName);
                                }
                            }


                        }
                        else  // These are ENTRIES positions
                        {
                            Log.Logger.Information("If there is the changes in the  positions and also it is an entry");
                            DataTable isAdaptorActive = CommonClass.ActiveadaptorList();
                            bool isHF1Active = Convert.ToBoolean(isAdaptorActive.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 100 && x.Field<string>("Portfolio") == marketTimeZone).Select(x => x.Field<bool>("isThisActive")).FirstOrDefault());
                            if (isHF1Active == true && realPositon != tolExsistingPositions)
                            {
                                UpdateFuturePositionFileDataIntoDataBase(ContractId, delta, ex, avgPrice, marketTimeZone);
                                Log.Logger.Information("marketTimeZone = " + marketTimeZone + " final update delta for HF1 = + " + delta + "  average price = " + avgPrice);
                            }
                            else
                            {
                                Log.Logger.Information("HF1 is deactivated for Porfolio" + marketTimeZone + "and" + isHF1Active + "or there is no change in the position " + fileName);
                            }
                            bool isBitcoin = dtFutureSym.AsEnumerable().Where(x => x.Field<string>("AssetClass") == "Bitcoin").Any(row => row.Field<string>("FileNamesToRead") == filename.Name.Split(".")[0]);
                            bool isEQ = dtFutureSym.AsEnumerable().Where(x => x.Field<string>("AssetClass") == "Equity Indices").Any(row => row.Field<string>("FileNamesToRead") == filename.Name.Split(".")[0]);
                            bool isHF2ActiveEQ = Convert.ToBoolean(isAdaptorActive.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 101 && x.Field<string>("Portfolio") == "EQ").Select(x => x.Field<bool>("isThisActive")).FirstOrDefault());
                            bool isHF2ActiveFX = Convert.ToBoolean(isAdaptorActive.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 101 && x.Field<string>("Portfolio") == "FX").Select(x => x.Field<bool>("isThisActive")).FirstOrDefault());
                            bool isHF2ActiveBTC = Convert.ToBoolean(isAdaptorActive.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 101 && x.Field<string>("Portfolio") == "Bitcoin").Select(x => x.Field<bool>("isThisActive")).FirstOrDefault());
                            if ((isHF2ActiveFX == true || isHF2ActiveBTC == true ||isHF2ActiveEQ==true) && (realPositon != exsistingPosition_HF2))
                            {
                                if (isBitcoin == false && isHF2ActiveFX == true && isEQ==false)
                                {
                                    //List<SqlParameter> sqls = new List<SqlParameter>();
                                    //sqls.Add(new SqlParameter()
                                    //{
                                    //    SqlDbType = SqlDbType.Int,
                                    //    ParameterName = "@ContractId",
                                    //    Direction = ParameterDirection.Input,
                                    //    Value = Convert.ToInt32(ContractId)

                                    //});
                                    //sqls.Add(new SqlParameter()
                                    //{
                                    //    SqlDbType = SqlDbType.Int,
                                    //    ParameterName = "@Lots",
                                    //    Direction = ParameterDirection.Input,
                                    //    Value = delta1

                                    //});
                                    //sqls.Add(new SqlParameter()
                                    //{
                                    //    SqlDbType = SqlDbType.Int,
                                    //    ParameterName = "@Prices",
                                    //    Direction = ParameterDirection.Input,
                                    //    Value = avgPrice1

                                    //});

                                    //DataSet dtisExccess = DBContext.FillUpDataSetFromSp(connectionString, "Trade.CalcLimitsAndIsExccessed", 5000, sqls);
                                    bool isExcess=(bool)DBContext.ExecuteScalerFunction(connectionString,"Select [Trade].[IsLimitExcessed]()",null);
                                    if (isExcess)
                                    {
                                        DeactivateFutureInDB(ContractId);
                                    }
                                    else
                                    {
                                        Log.Logger.Information("If there is the changes in the currency positions and also it is an entry");
                                        SecondHedgeFund.UpdatePositionsintoDatabaseforHF2(ContractId, delta1, avgPrice1);
                                        Log.Logger.Information("ContractId = " + ContractId + " final update delta HF2= + " + delta1 + "  average price = " + avgPrice1 + "FX is activated" + isHF2ActiveFX);
                                    }
                                   
                                }
                                else if (isBitcoin == true && isHF2ActiveBTC == true && isEQ==false)
                                {
                                    Log.Logger.Information("If there is the changes in the Bitcoin positions and also it is an entry");
                                    SecondHedgeFund.UpdatePositionsintoDatabaseforHF2(ContractId, delta1, avgPrice1);
                                    Log.Logger.Information("ContractId = " + ContractId + " final update delta HF2= + " + delta1 + "  average price = " + avgPrice1 + "Bitcoin is activated" + isHF2ActiveBTC);
                                }
                                else if (isBitcoin == false && isHF2ActiveEQ == true && isEQ == true)
                                {
                                    Log.Logger.Information("If there is the changes in the Equity positions and also it is an entry");
                                    SecondHedgeFund.UpdatePositionsintoDatabaseforHF2(ContractId, delta1, avgPrice1);
                                    Log.Logger.Information("ContractId = " + ContractId + " final update delta HF2= + " + delta1 + "  average price = " + avgPrice1 + "Equity is activated" + isHF2ActiveEQ);
                                }
                                else
                                {
                                    Log.Logger.Information("HF2 is Activated/deactivated for Bitcoin" + isHF2ActiveBTC + " and for FX" + isHF2ActiveFX + "or there is no change in the position " + fileName);
                                }

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Log.Logger.Error(" exception occurs while reading a Updated File " + ex + "------->" + filename);
            }
        }
        public static void DeactivateFutureInDB(string ContractId)
        {
            //int ContractIdDB = Convert.ToInt32(ContractId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<SqlParameter> sqls = new List<SqlParameter>();
                sqls.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@ContractId",
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt32(ContractId)
                });
                DBContext.ExecuteSp(connectionString, "[Trade].[DeactivateFutureSymbolsForHF2FX]", sqls);
                //connection.Open();
                //SqlCommand sql_cmnd = new SqlCommand("[Trade].[DeactivateFutureSymbols]", connection);
                //sql_cmnd.CommandType = CommandType.StoredProcedure;
                //sql_cmnd.Parameters.AddWithValue("@ContractId", ContractId);
                //sql_cmnd.ExecuteNonQuery();
                //connection.Close();
            }
        }
        public static DataTable RetrieveExistingPositions(string ContractId)
        {
            int contractId = Convert.ToInt32(ContractId);
            string query = "select afp.Lots as ExistingPositions_APAC,efp.Lots as ExistingPositions_EMEA,fxpos.Lots " +
                "from Trade.FutureSymbols fs" +
               " left outer join Trade.ContractsPositionForEntity2 fxpos on fxpos.ContractId = fs.ContractId " +
                "left outer join Trade.ApacFuturePositions afp on afp.ContractId = fs.ContractId " +
                "left outer join Trade.EMEAFuturePositions efp on efp.ContractId = afp.ContractId" +
                " where fs.ContractId = " + contractId;
            DataTable dtExsistingPositions = DBContext.GetDataSetFromQuery(connectionString, query).Tables[0];
            return dtExsistingPositions;
        }
        //public static DataSet GetNetOpenPositionsfromDB()
        //{
        //    DataSet ds = new DataSet();
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "select count(1) as TotalCount from Trade.ApacFuturePositions afp left outer join Trade.EMEAFuturePositions efp on afp.ContractId=efp.ContractId where  (afp.Lots +  efp.Lots != 0) select count(1) as FXCount from Trade.ApacFuturePositions afp left outer join Trade.EMEAFuturePositions efp on afp.ContractId=efp.ContractId left outer join Trade.FutureSymbols fs on efp.ContractId=fs.ContractId where (afp.Lots+efp.Lots)!=0 and fs.AssetClass='FX'";
        //        SqlDataAdapter Adapterdata = new SqlDataAdapter(query, connection);
        //        Adapterdata.Fill(ds);
        //    }
        //    return ds;
        //}

        private static void updateFileInfo(string ContractId, DateTime lastModified)
        {
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            sqlParameter.Add(new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@ContractId",
                Direction = ParameterDirection.Input,
                Value = Convert.ToInt32(ContractId)
            });
            sqlParameter.Add(new SqlParameter()
            {
                SqlDbType = SqlDbType.DateTime,
                ParameterName = "@LastModifiedTime",
                Direction = ParameterDirection.Input,
                Value = lastModified
            });
            DBContext.ExecuteSp(connectionString, "[Trade].[UpdateLastAccessTime]", sqlParameter);
        }

        private static void UpdateFuturePositionFileDataIntoDataBase(string ContractId, int NewLots, string ex, decimal price, string marketTimeZone)
        {
            DataTable dtisContractActive = SecondHedgeFund.ISfutureisActive(ContractId);
            bool isActiveContract = Convert.ToBoolean(dtisContractActive.AsEnumerable().Where(x => x.Field<int>("EntityCode") == 100).Select(x => x.Field<bool>("TobePublished")).FirstOrDefault());
            Log.Logger.Information("Contract is active or not for HF1  " + ContractId + " " + isActiveContract);
            if (isActiveContract == true)
            {
                List<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@ContractId",
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt32(ContractId)
                });
                sqlParameter.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@NewLots",
                    Direction = ParameterDirection.Input,
                    Value = NewLots
                });
                sqlParameter.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@Filetype",
                    Direction = ParameterDirection.Input,
                    Value = marketTimeZone
                });
                sqlParameter.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@ex",
                    Direction = ParameterDirection.Input,
                    Value = ex
                });
                sqlParameter.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@Price",
                    Direction = ParameterDirection.Input,
                    Value = price
                });
                Log.Logger.Information("Database Connection has been Opened for Updating the Positions inthe Database ");
                DBContext.ExecuteSp(connectionString, "[Trade].[UpdateFuturePositionForApacandEmea]", sqlParameter);
                Log.Logger.Information("Database Connection has been Closed after Updating the positions");

                doIhaveToTransfer = true;
            }
            else
            {
                Log.Logger.Information("The Contract in which trade is happened is not sent to the Hedge Fund 1");
            }

        }



        static void TransferFilesToFirstHedgeFund(string marketTimeZone)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@FileType", marketTimeZone));
            DataTable dt = DBContext.FillUpDataSetFromSp(connectionString, "Trade.GeneratePostionsUsingPreferencesAnuj", 5000, sqlParameters).Tables[0];
            int countOfOpenPositions = dt.AsEnumerable().Count(row => row.Field<int>("target_contracts") != 0);
            // if (countOfOpenPositions <= Convert.ToInt32("12"))
            {
                Log.Logger.Information("Total Number of Open Positions == " + countOfOpenPositions + "  so I can start to SFTP the file ");

                if (dt.Rows.Count > 0)
                {
                    string filename = FileName + DateTime.UtcNow.ToString("yyyyMMdd-HHmm") + ".csv";
                    string completeFileName = filepath + marketTimeZone + "\\" + filename;
                    try
                    {
                        string[] headerNames = dt.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName).
                                                  ToArray();
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(string.Join(",", headerNames));

                        int currentRowPosition = 0;
                        foreach (DataRow positionRow in dt.Rows)
                        {
                            currentRowPosition++;
                            string[] fields = positionRow.ItemArray.Select(field => ConvertToCsvValue(field)).ToArray();
                            Log.Logger.Information("Row Number = " + currentRowPosition + "--" + fields.ToString());
                            sb.AppendLine(string.Join(",", fields));
                        }

                        if (!Directory.Exists(filepath + marketTimeZone))
                        {
                            Directory.CreateDirectory(filepath + marketTimeZone);
                        }


                        Log.Logger.Information("Create the complete CSV file");
                        File.WriteAllText(completeFileName, sb.ToString());
                        Log.Logger.Information("CSV file is created in " + filepath + " on time-zone " + marketTimeZone);
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error("some exception in producing the CSV format file" + ex);
                    }

                    Log.Logger.Information("Now I will try to open the session on the remote HF server");
                    try
                    {

                        SessionOptions remoteSession = new SessionOptions()
                        {
                            Protocol = Protocol.Sftp,
                            HostName = winSCPserverIP,
                            UserName = winSCPUserID,
                            SshPrivateKeyPath = winSCPSshPrivateKeyPath,
                            PortNumber = winSCPPortNumber,
                            SshHostKeyFingerprint = winSCPSshHostKeyFingerprint
                        };
                        Session session = new Session();
                        Log.Logger.Information("SFTP Connection establishing...");
                        session.Open(remoteSession);
                        Log.Logger.Information("SFTP Session to the HedgeFund has been Opened");
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;
                        transferOptions.PreserveTimestamp = false;
                        transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
                        TransferOperationResult transferOperationResult;

                        if (marketTimeZone == "EMEA")
                        {
                            transferOperationResult = session.PutFiles(completeFileName, winSCPToEMEADestinationPath, false, transferOptions);
                            transferOperationResult.Check();
                            if (transferOperationResult.IsSuccess)
                            {
                                bool ab = SendingEmail.SendMail(new SendEmailModel()
                                {
                                    CCEmail = Program.CCEmail/*"sameeksha@alliance-techfunctionals.com"*/,
                                    bccMail = Program.bccMail,
                                    EmailSubject = "[Info] New target positions for " + completeFileName,
                                    EmailBody = /*"ftp01.gtsx.com:*/"Upload [Success]",
                                    PositionFilePath = completeFileName,
                                    UserEmail = Program.UserEmail/* "mbettaieb@capbonconsulting.com,capbonorca@gmail.com"*/
                                });
                            }
                           
                        }
                        else
                        {
                            transferOperationResult = session.PutFiles(completeFileName, winSCPToAPACDestinationPath, false, transferOptions);
                            transferOperationResult.Check();
                            if (transferOperationResult.IsSuccess)
                            {
                                bool ab = SendingEmail.SendMail(new SendEmailModel()
                                {
                                    CCEmail = Program.CCEmail/*"sameeksha@alliance-techfunctionals.com"*/,
                                    bccMail = Program.bccMail,
                                    EmailSubject = "[Info] New target positions for " + completeFileName,
                                    EmailBody = /*"ftp01.gtsx.com:*/"Upload [Success]",
                                    PositionFilePath = completeFileName,
                                    UserEmail = Program.UserEmail/* "mbettaieb@capbonconsulting.com,capbonorca@gmail.com"*/
                                });
                            }
                          
                        }
                        transferOperationResult.Check();

                        if (transferOperationResult.IsSuccess)
                            Log.Logger.Information("File has been transferred properly to the hedge fund " + filename);
                        else
                            Log.Logger.Error("Sorry, file cannot be transferred, som eexception has occurred. Please check it" + completeFileName);
                        session.Close();
                        Log.Logger.Information("SFTP Session has been closed");
                        TransferFiletoAnotherfolder(marketTimeZone);
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error("Exception occurred while Transferring file to the Hedge Fund" + ex);
                        bool ab = SendingEmail.SendMail(new SendEmailModel()
                        {
                            CCEmail = Program.CCEmail/*"sameeksha@alliance-techfunctionals.com"*/,
                            bccMail = Program.bccMail,
                            EmailSubject = "[Alert] New target positions for " + completeFileName,
                            EmailBody = /*"ftp01.gtsx.com:*/"Upload [Failed]",
                            PositionFilePath = completeFileName,
                            UserEmail = Program.UserEmail/* "mbettaieb@capbonconsulting.com,capbonorca@gmail.com"*/
                        });
                    }
                }

            }
            //else
            //{
            //    Log.Logger.Information("Total Number of Open Positions == " + countOfOpenPositions + "  so I can not  SFTP the file to HF and suppress.. ");
            //}


        }


        static string ConvertToCsvValue(object value)
        {
            if (value is DateTime)
            {
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                return value.ToString();
            }
        }


        static void TransferFiletoAnotherfolder(string filetype)
        {
            try
            {

                if (!Directory.Exists(_incomingPath + filetype))
                {
                    Directory.CreateDirectory(_incomingPath + filetype);
                }
                if (!Directory.Exists(_processPath + "\\" + filetype + "\\"))
                {
                    Directory.CreateDirectory(_processPath + "\\" + filetype + "\\");
                }

                Log.Logger.Information("Moving a file from  " + _incomingPath + filetype + " to " + _processPath + "\\" + filetype);
                DirectoryInfo directoryInfo = new DirectoryInfo(_incomingPath + filetype);
                var getAllCSVFiles = directoryInfo.GetFiles("*.csv")
                                     .Select(file => file.Name).ToList();
                string filename = FileName + DateTime.UtcNow.ToString("yyyyMMdd-HHmmss") + ".csv";

                foreach (var file in getAllCSVFiles)
                {
                    File.Move(_incomingPath + filetype + "\\" + file, _processPath + "\\" + filetype + "\\" + filename);
                }
                Log.Logger.Information("File moved Successfully from  " + _incomingPath + filetype + "  to  " + _processPath + "\\" + filetype);
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Exceptions occurs while moving a file locally" + ex.ToString());
            }
        }

        static DataTable GetFilesLastUpdatedActivities()
        {

            string query = "Select [ContractId], [LastReadAt] from [Trade].[FileReadActivityMonitor]";
            DataTable dtFileReadActivityMonitor = DBContext.GetDataSetFromQuery(connectionString, query).Tables[0];
            return dtFileReadActivityMonitor;
        }
    }
}


