using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orca_FO_v2._12._0.EmailFunctionality
{
    public class SendEmailModel
    {
        public string templateName { get; set; }
        public string EmailBody { get; set; }
        public string CCEmail { get; set; }
        public string EmailSubject { get; set; }
        public string UserEmail { get; set; }
        public string BCCEmail { get; set; }
        public string PositionFilePath { get; set; }
    }
}
