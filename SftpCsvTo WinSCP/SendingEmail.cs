using System;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
namespace TradeStationToHedgeFund
{
    class SendingEmail
    {
        private static string Email_From ="orca@capbonconsulting.com";  
     
       

        public static bool SendMail(SendEmailModel model)
        {
            try
            {
              
                Outlook.Application app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)app.CreateItem(Outlook.OlItemType.olMailItem);
                if (!string.IsNullOrWhiteSpace(model.UserEmail))
                {
                    string[] arrAddTos = model.UserEmail.Split(new char[] { ';', ',' });
                    foreach (string strAddr in arrAddTos)
                    {
                        if (!string.IsNullOrWhiteSpace(strAddr) &&
                            strAddr.IndexOf('@') != -1)
                        {
                            mail.Recipients.Add(strAddr.Trim());
                        }
                        else
                            throw new Exception("Bad to-address: " + model.UserEmail);
                    }
                }
                else
                    throw new Exception("Must specify to-address");

               
                if (!string.IsNullOrEmpty(model.CCEmail))
                {
                   
                    mail.CC = model.CCEmail;
                }
                if (!string.IsNullOrEmpty(model.bccMail))
                {

                    mail.BCC = model.bccMail;
                }
                Outlook.Accounts accounts = app.Session.Accounts;
                Outlook.Account acc = null;
                foreach (Outlook.Account account in accounts)
                {
                    if (account.SmtpAddress.Equals(Email_From, StringComparison.CurrentCultureIgnoreCase))
                    {
                     
                        acc = account;
                        break;
                    }
                }

                mail.SendUsingAccount = acc;
             
                mail.Subject = model.EmailSubject;
                mail.Body = model.EmailBody;
               
                if (model.PositionFilePath != null)
                {
                    
                    mail.Attachments.Add(model.PositionFilePath);
                }

                ((Outlook._MailItem)mail).Send();

                return true;
            }

            catch (Exception ex)
            {
                string msg = "Mail cannot be sent because of the server problem:";
                msg += ex.Message;
                return false;
            }
        }
    }
}
