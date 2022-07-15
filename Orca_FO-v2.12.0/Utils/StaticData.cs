using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = Orca_FO_v2._12._0.DataContext.DbContext;
namespace Orca_FO_v2._12._0.Utils
{
    public class StaticData
    {
        public static List<KeyValuePairs> _appSettings = new List<KeyValuePairs>();
        public static void LoadData()
        {
            try
            {
                DataSet dsAppSetting = DAL.FillUpDataSetFromSP("[config].[GetAppSettings]", null);
              var appSettings = DataTableUtilities.Convert<KeyValuePairs>(dsAppSetting.Tables["AppSettings"]);
              _appSettings = appSettings;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
