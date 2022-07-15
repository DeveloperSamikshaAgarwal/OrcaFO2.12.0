using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLoggerProvider
{
    public class Logger : LogBase
    {
        public enum LogLevel
        {
            Information = 1,
            Error = 2
        }
        public string CurrentDirectory
        {
            get; set;
        }
        public string FileName
        {
            get; set;
        }
        public string FilePath
        {
            get; set;
        }
        public Logger()
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory() + "\\Logs\\";
            if (!Directory.Exists(this.CurrentDirectory))
            {
                Directory.CreateDirectory(this.CurrentDirectory);
            }
            this.FileName = "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            this.FilePath = this.CurrentDirectory + this.FileName;
        }

        public override void Information(string message)
        {


            using (StreamWriter writer = new StreamWriter(this.FilePath, true))
            {
                writer.WriteLine(string.Format("{0}: {1}: {2}", LogLevel.Information, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), message));
                writer.Close();
            }
        }
        public override void Error(string message)
        {
            using (StreamWriter writer = new StreamWriter(this.FilePath, true))
            {
                writer.WriteLine(string.Format("{0}: {1}: {2}", LogLevel.Error, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), message));
                writer.Close();
            }
        }
    }
}
