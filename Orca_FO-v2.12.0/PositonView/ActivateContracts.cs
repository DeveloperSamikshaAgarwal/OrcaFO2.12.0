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

        DataTable dtDBData;
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
            dtDBData = ds.Tables[0];
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
                DataTable dtViewData = GridtoDatatable(dataGridActivateContracts);
                var JoinResult = (from p in dtDBData.AsEnumerable()
                                  join t in dtViewData.AsEnumerable()
                                  on p.Field<string>("Name") equals t.Field<string>("Name")
                                 
                                  select new
                                  {
                                      ProductName = p.Field<string>("Product Name"),
                                      BrandName = p.Field<string>("Brand Name"),
                                      ProductCategory = t.Field<string>("Product Category"),
                                      TaxCharge = t.Field<int>("Charge")
                                  }).ToList();
                //int rowIndex = dataGridActivateContracts.CurrentRow.Index;
                //string portf = dataGridActivateContracts.Rows[rowIndex].Cells["colPortfolioName"].Value.ToString();
                //string contract = dataGridActivateContracts.Rows[rowIndex].Cells["colRootContract"].Value.ToString();
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

                        //List<SqlParameter> sqlParameters1 = new List<SqlParameter>();
                        //sqlParameters1.Add(new SqlParameter()
                        //{
                        //    SqlDbType = SqlDbType.NVarChar,
                        //    ParameterName = "@ContractName",
                        //    Direction = ParameterDirection.Input,
                        //    Value = contract
                        //});
                        //sqlParameters1.Add(new SqlParameter()
                        //{
                        //    SqlDbType = SqlDbType.NVarChar,
                        //    ParameterName = "@Portfolio",
                        //    Direction = ParameterDirection.Input,
                        //    Value = portf

                        //});
                        //DataSet dspostions = DAL.FillUpDataSetFromSP("[Trade].[GetPositionsData]", sqlParameters1);

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
        public DataTable GridtoDatatable(DataGridView view)
        {
           // AppFunctions._logger.Information("Start converting grid data  into datatable");
            DataTable dt = new DataTable();
            //dt.Columns.Add("ContractName");
            //dt.Columns.Add("HistoricalPNL");
            //dt.Columns.Add("MarketDate");
            foreach (DataGridViewColumn item in view.Columns)
            {
                dt.Columns.Add(item.DataPropertyName);
            }
           // AppFunctions._logger.Information("Start creating data table");
            for (int i = 0; i < view.RowCount; i++)
            {
                DataRow row = dt.NewRow();
                foreach (DataGridViewColumn column in view.Columns)
                {
                    foreach (DataColumn item in dt.Columns)
                    {
                        if (column.DataPropertyName == item.ColumnName)
                        {
                            string colName = column.Name.ToString();
                            row[item] = view.Rows[i].Cells[colName].Value;
                            break;
                        }
                    }
                    
                    
                }
                dt.Rows.Add(row);
            }
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    DataColumn dc = dt.Columns[i];
            //    if (!dc.ColumnName.Contains("TradePortfolio") && !dc.ColumnName.Contains("MarketDate") && !dc.ColumnName.Contains("HistoricalPNL")&& !dc.ColumnName.Contains("ContractName"))
            //    {k
            //        dt.Columns.Remove(dc);
            //    }
            //} 
            //AppFunctions._logger.Information("Data table created successfully!!");
            //AppFunctions._logger.Information("returing data table");
            return dt;
        }
        static List<string> aa;
        private void dataGridActivateContracts_SelectionChanged(object sender, EventArgs e)
        {
            //int rowIndex = dataGridActivateContracts.CurrentRow.Index;
            //string portf = dataGridActivateContracts.Rows[rowIndex].Cells["colPortfolioName"].Value.ToString();
            //string contract = dataGridActivateContracts.Rows[rowIndex].Cells["colRootContract"].Value.ToString();
            //aa.Add(contract);
        }
    }
}
