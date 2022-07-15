using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL = Orca_FO_v2._12._0.DataContext.DbContext;

namespace Orca_FO_v2._12._0.PositonView
{
    public partial class ActivateContracts : UserControl
    {
        public ActivateContracts()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of Activate/Deactivate contracts view  components");
            GetActivateContracts();
        }
        public void GetActivateContracts()
        {
            MainForm.log.Information("Execution of SP for Activate/Deactivate contracts view started");
            DataSet ds = DAL.FillUpDataSetFromSP( "Trade.GetContractsStatus",  null);
            MainForm.log.Information("Execution of SP for Activate/Deactivate contracts view completed");
            dataGridActivateContracts.DataSource = ds.Tables[0];
            dataGridActivateContracts.Sort(dataGridActivateContracts.Columns[1],ListSortDirection.Ascending);
           // this.dataGridActivateContracts.Columns["colEntityCode"].AllowGrouping = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked successfully");
            GetActivateContracts();
            MainForm.log.Information("Refresh button is clicked successfully");
        }

        private void btnActivated_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Activate/Deactivate contracts button is clicked");

                int rowIndex = dataGridActivateContracts.CurrentRow.Index;
                string portf = dataGridActivateContracts.Rows[rowIndex].Cells["colPortfolioName"].Value.ToString();
                string contract = dataGridActivateContracts.Rows[rowIndex].Cells["colRootContract"].Value.ToString();
                List<SqlParameter> sqlParameters1 = new List<SqlParameter>();
                sqlParameters1.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@ContractName",
                    Direction = ParameterDirection.Input,
                    Value = contract
                });
                sqlParameters1.Add(new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@Portfolio",
                    Direction = ParameterDirection.Input,
                    Value = portf

                });
                DataSet dspostions = DAL.FillUpDataSetFromSP("[Trade].[GetPositionsData]", sqlParameters1);
                DialogResult res = MessageBox.Show("Do you want to Activate/Deactivate the Contracts  in the database ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    MainForm.log.Information("You have pressed yes");
                    int entitycode = 0;
                    bool tobePublished = false;
                    string rootContract = "";
                    MainForm.log.Information("Excecution of SP for activativating/deactivating HFs is started");
                    for (int i = 0; i < dataGridActivateContracts.RowCount; i++)
                    {
                        if (!String.IsNullOrEmpty(dataGridActivateContracts.Rows[i].Cells["colEntityCode"].Value.ToString()))
                        {
                            entitycode = Convert.ToInt32(dataGridActivateContracts.Rows[i].Cells["colEntityCode"].Value);
                        }
                        if (!String.IsNullOrEmpty(dataGridActivateContracts.Rows[i].Cells["colRootContract"].Value.ToString()))
                        {
                            rootContract = dataGridActivateContracts.Rows[i].Cells["colRootContract"].Value.ToString();
                        }
                        if (!String.IsNullOrEmpty(dataGridActivateContracts.Rows[i].Cells["colToBePublished"].Value.ToString()))
                        {
                            tobePublished = Convert.ToBoolean(dataGridActivateContracts.Rows[i].Cells["colToBePublished"].Value);
                        }
                        List<SqlParameter> sqlParameters = new List<SqlParameter>();
                        sqlParameters.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.NVarChar,
                            Direction = ParameterDirection.Input,
                            ParameterName = "@RootContract",
                            Value = rootContract
                        });
                        sqlParameters.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            ParameterName = "@EntityCode",
                            Value = entitycode
                        });
                        sqlParameters.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.Bit,
                            Direction = ParameterDirection.Input,
                            ParameterName = "@TobePublished",
                            Value = tobePublished
                        });
                        DAL.ExecuteSp("Trade.UpdateContractStatus", sqlParameters);

                    }
                    MainForm.log.Information("Sp executes successfully");
                    MainForm.log.Information("contracts activation/deactivation is done successfully");
                    MessageBox.Show("Contracts activation/deactivation is done successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MainForm.log.Information("Contracts are activated/deactivated is not done because ypu have pressed No");
                    MessageBox.Show("Contracts are activated/deactivated is not done because you have pressed No", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Contracts are activated/deactivated is not done because some error occurred: "+ ex);
                MessageBox.Show("Contracts are activated/deactivated is not done because some error occurred", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            
        }
    }
}
