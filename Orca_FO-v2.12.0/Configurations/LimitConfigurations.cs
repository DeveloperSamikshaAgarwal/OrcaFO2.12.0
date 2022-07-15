using Orca_FO_v2._12._0.DataContext.ViewModel;
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
    public partial class LimitConfigurations : UserControl
    {
        public LimitConfigurations()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of Limit Configurations view  components");
            GetLimitsData();
        }
        public void GetLimitsData()
        {
            MainForm.log.Information("Execution of query for Limit Configurations view started");
            dataGridLimitConfig.DataSource= DAL.GetDataSetFromQuery("select ContractId,HFPreference,ContractName, AssetClass from trade.futuresymbols").Tables[0];
            MainForm.log.Information("Execution of query for Limit Configurations view completed");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked successfully");
            GetLimitsData();
            MainForm.log.Information("Refresh button is clicked successfully");
        }

        private void btnSavePriority_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Save priority button is clicked");
                MainForm.log.Information("Excecution of SP for saving priority is started");
                var limitConfig = dataGridLimitConfig.DataSource as DataTable;
                var hfPrefrences = limitConfig.AsEnumerable().Select(x => new LimitConfigurationViewModel()
                {
                    HFPreference = x.Field<Int32>("HFPreference")
                });

                var grpHfPrefrences = hfPrefrences.GroupBy(x => x.HFPreference);
                foreach (var prefrences in grpHfPrefrences)
                {
                    if (prefrences.Count() > 1)
                    {
                        MainForm.log.Information("Some contracts having same priority ");
                        MessageBox.Show("Some contracts having same priority ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                DAL.ExecuteSPWithTableName(limitConfig, "Trade.SavePriority");
                MainForm.log.Information("Sp executes successfully");
                MainForm.log.Information("Priorities saved successfully");
                MessageBox.Show("Priorities saved successfully ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Priorities does not save successfully: "+ex);
                MessageBox.Show("Priorities does not saved successfully ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

        }
    }
}
