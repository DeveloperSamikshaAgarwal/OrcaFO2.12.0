using System;
using System.Collections.Generic;
using System.Text;

namespace TradeStationToHedgeFund
{
    class SendEmailModel
    {
        public string templateName { get; set; }
        public string EmailBody { get; set; }
        public string CCEmail { get; set; }
        public string EmailSubject { get; set; }
        public string UserEmail { get; set; }
        public string bccMail { get; set; }
        public string PositionFilePath { get; set; }
    }
}
