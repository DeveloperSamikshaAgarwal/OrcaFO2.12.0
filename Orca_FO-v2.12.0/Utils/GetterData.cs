using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orca_FO_v2._12._0.Utils
{
    public class GetterData
    {
        public static string closeButtonFullPath
        {
            get {
                     return StaticData._appSettings.Find(x => x.AppKey.Equals("closeButtonFullPath")).AppValue; 
                } 
        }
        public static string ExcelSaveFileDirectory
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ExcelSaveFileDirectory")).AppValue;
            }
        }
        public static string SaveFilePath
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("SaveFilePath")).AppValue;
            }
        }
        public static string ProcessFilePath
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ProcessFilePath")).AppValue;
            }
        }
        public static string FileName
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("FileName")).AppValue;
            }
        }
        public static string Recipients
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("Recipients")).AppValue;
            }
        }
        public static string RecipientsHF2
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("RecipientsHF2")).AppValue;
            }
        }
        public static string CCmail
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("CCmail")).AppValue;
            }
        }
        public static string ServerHostNameHF1
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerHostNameHF1")).AppValue;
            }
        }
        public static string ServerUserNameHF1
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerUserNameHF1")).AppValue;
            }
        }
        public static string ServerSshPrivateKeyPathHF1
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerSshPrivateKeyPathHF1")).AppValue;
            }
        }
        public static string ServerPortNumber
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerPortNumber")).AppValue;
            }
        }
        public static string ServerSshHostKeyFingerprintHF1
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerSshHostKeyFingerprintHF1")).AppValue;
            }
        }
        public static string ServerDirectoryForEMEAHF1
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerDirectoryForEMEAHF1")).AppValue;
            }
        }
        public static string ServerDirectoryForApacHF1
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerDirectoryForApacHF1")).AppValue;
            }
        }
        public static string fxfilename
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("fxfilename")).AppValue;
            }
        }
        public static string btcfilename
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("btcfilename")).AppValue;
            }
        }
        public static string ServerHostNameHF2
        {
            get
            {
                return StaticData._appSettings.Find(x => x.AppKey.Equals("ServerHostNameHF2")).AppValue;
            }
        }
        public static string ServerUserNameHF2
        {
            get
            {

                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerUserNameHF2")).AppValue;
            }
        }
        public static string ServerSshPrivateKeyHF2
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerSshPrivateKeyHF2")).AppValue;
            }
        }
        public static string ServerSshHostKeyFingerprintHF2
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerSshHostKeyFingerprintHF2")).AppValue;
            }
        }
        public static string ServerPasswordHF2
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerPasswordHF2")).AppValue;
            }
        }
        public static string ServerDirectoryForFXHF2
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerDirectoryForFXHF2")).AppValue;
            }
        }
        public static string ServerDirectoryForBTCHF2
        {
            get
            {
                return StaticData._appSettings.Find(x=>x.AppKey.Equals("ServerDirectoryForBTCHF2")).AppValue;

            }
        }
        public static string ServerDirectoryForEQHF2
        {
            get
            {
                return StaticData._appSettings.Find(x => x.AppKey.Equals("ServerDirectoryForEQHF2")).AppValue;
            }
        }
        public static string eqfilename
        {
            get
            {
                return StaticData._appSettings.Find(x => x.AppKey.Equals("eqfilename")).AppValue;
            }
        }
        public static string BCCEmail
        {
            get
            {
                return StaticData._appSettings.Find(x => x.AppKey.Equals("BCCEmail")).AppValue;
            }
        }
    }
}
