using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = Orca_FO_v2._12._0.DataContext.DbContext;
using AppSetting = Orca_FO_v2._12._0.Utils.GetterData;
using System.Data;
using Orca_FO_v2._12._0.EmailFunctionality;
using WinSCP;

namespace Orca_FO_v2._12._0.PositonView
{
    class TransferFiletoHF1
    {
        
        static string winSCPserverIP = AppSetting.ServerHostNameHF1;
        static string winSCPUserID = AppSetting.ServerUserNameHF1;
        static string winSCPSshPrivateKeyPath = AppSetting.ServerSshPrivateKeyPathHF1;
        static int winSCPPortNumber = Convert.ToInt32(AppSetting.ServerPortNumber);
        static string winSCPSshHostKeyFingerprint = AppSetting.ServerSshHostKeyFingerprintHF1;
        static string winSCPSourcePath;

        static string winSCPToEMEADestinationPath = AppSetting.ServerDirectoryForEMEAHF1;
        static string winSCPToAPACDestinationPath = AppSetting.ServerDirectoryForApacHF1;
        static string filepath = AppSetting.SaveFilePath;
        static string FileName = AppSetting.FileName;
        //public static string _incomingPath;
        public static string _processPath = AppSetting.ProcessFilePath;
        static string recipients = AppSetting.Recipients;
        static string ccMail = AppSetting.CCmail;
        static string bccMail = AppSetting.BCCEmail;

        public static bool TransferFilesToHedgeFund(string marketTimeZone)
        {
            bool returnType = false;
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@FileType", marketTimeZone));
            DataTable dt = DAL.FillUpDataSetFromSP("Trade.GenerateFuturePositionsForAPACorEMEA",sqlParameters).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string csv = "";
                foreach (var c in dt.Columns)
                {
                    csv += c + ",";

                }
                csv = csv.Remove(csv.LastIndexOf(","));
                csv += "\r";
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        csv += dt.Rows[row][col] + ",";
                    }
                    csv = csv.Remove(csv.LastIndexOf(","));
                    csv += "\r";
                }

                if (!Directory.Exists(filepath + marketTimeZone))
                {
                    Directory.CreateDirectory(filepath + marketTimeZone);
                }

                string filename = FileName + DateTime.UtcNow.ToString("yyyyMMdd-HHmm") + ".csv";

                string completeFileName = filepath + marketTimeZone + "\\" + filename;
                File.WriteAllText(completeFileName, csv);

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
                    MainForm.log.Information("SFTP Connection establishing...");
                    session.Open(remoteSession);
                    MainForm.log.Information("SFTP Session to the HedgeFund has been Opened");
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    transferOptions.PreserveTimestamp = false;
                    transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
                    TransferOperationResult transferOperationResult;

                    if (marketTimeZone == "EMEA")
                    {
                        transferOperationResult = session.PutFiles(completeFileName, winSCPToEMEADestinationPath, false, transferOptions);
                        bool ab = SendingEmail.SendMail(new SendEmailModel()
                        {
                            CCEmail = ccMail/*"sameeksha@alliance-techfunctionals.com"*/,
                            BCCEmail=bccMail,
                            EmailSubject = "[INFO] New target positions for " + completeFileName,
                            EmailBody = "Upload [Success]",
                            PositionFilePath = completeFileName,
                            UserEmail = recipients/*"mbettaieb@capbonconsulting.com,capbonorca@gmail.com,mbelaid@capbonconsulting.com,anuj@alliance-techfunctionals.com"*/
                        });
                    }
                    else
                    {
                        transferOperationResult = session.PutFiles(completeFileName, winSCPToAPACDestinationPath, false, transferOptions);
                        bool ab = SendingEmail.SendMail(new SendEmailModel()
                        {
                            CCEmail = ccMail/*"sameeksha@alliance-techfunctionals.com"*/,
                            EmailSubject = "[INFO] New target positions for " + completeFileName,
                            BCCEmail = bccMail,
                            EmailBody = "Upload [Success]",
                            PositionFilePath = completeFileName,
                            UserEmail = recipients/*"mbettaieb@capbonconsulting.com,capbonorca@gmail.com,mbelaid@capbonconsulting.com,anuj@alliance-techfunctionals.com"*/
                        });
                    }
                    transferOperationResult.Check();

                    if (transferOperationResult.IsSuccess)
                    {
                        MainForm.log.Information("File has been transferred properly to the hedge fund " + filename);
                        returnType = true;

                    }


                    else
                    {
                        MainForm.log.Information("Sorry, file cannot be transferred, some exception has occurred. Please check it"+completeFileName);
                        returnType = false;
                    }
                    session.Close();
                    MainForm.log.Information("SFTP Session has been closed");
                    TransferFiletoAnotherfolder(marketTimeZone);


                }
                catch (Exception ex)
                {
                    MainForm.log.Information("Exception occurred while Transferring file to the Hedge Fund" + ex);
                    bool ab = SendingEmail.SendMail(new SendEmailModel()
                    {
                        CCEmail = ccMail/*"sameeksha@alliance-techfunctionals.com"*/,
                        EmailSubject = "[Alert] New target positions for " + completeFileName,
                        EmailBody = "Upload [Failed]",
                        PositionFilePath = completeFileName,
                        UserEmail =recipients/*"sameeksha@alliance-techfunctionals.com"*/ //"mbettaieb@capbonconsulting.com,capbonorca@gmail.com,mbelaid@capbonconsulting.com,anuj@alliance-techfunctionals.com"
                    });
                }

            }
            return returnType;

        }
        static void TransferFiletoAnotherfolder(string filetype)
        {
            try
            {

                if (!Directory.Exists(filepath + filetype))
                {
                    Directory.CreateDirectory(filepath + filetype);
                }
                if (!Directory.Exists(_processPath + "\\" + filetype + "\\"))
                {
                    Directory.CreateDirectory(_processPath + "\\" + filetype + "\\");
                }
                MainForm.log.Information("Moving a file from" + filepath + filetype + "to" + _processPath + "\\" + filetype);
                
                DirectoryInfo directoryInfo = new DirectoryInfo(filepath + filetype);
                var getAllCSVFiles = directoryInfo.GetFiles("*.csv")
                                     .Select(file => file.Name).ToList();
                string filename = FileName + DateTime.UtcNow.ToString("yyyyMMdd-HHmmss") + ".csv";

                foreach (var file in getAllCSVFiles)
                {
                    File.Move(filepath + filetype + "\\" + file, _processPath + "\\" + filetype + "\\" + filename);
                }
                MainForm.log.Information("File moved Successfully from " + filepath + filetype + "to" + _processPath + "\\" + filetype);
              
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Exceptions occurs while moving a file locally: "+ex);
            }
        }
    }
}
