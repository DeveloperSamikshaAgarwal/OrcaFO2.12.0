using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL = Orca_FO_v2._12._0.DataContext.DbContext;

namespace Orca_FO_v2._12._0.Configurations
{
    public partial class ApplicationConfiguration : UserControl
    {
        public ApplicationConfiguration()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of Application Configurations view  components");
            GetAppConfig();
        }
        public void GetAppConfig()
        {
            MainForm.log.Information("Execution of query for Application Configurations view started");
            DataTable dtAppConfig = DAL.GetDataSetFromQuery("select * from config.AppSettings").Tables[0];
            MainForm.log.Information("Execution of query for Application Configurations view completed");
            dataGridAppConfig.DataSource = dtAppConfig;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked successfully");
            GetAppConfig();
            MainForm.log.Information("Refresh button is clicked successfully");
        }
    }
}
