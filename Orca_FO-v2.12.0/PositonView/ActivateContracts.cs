using Orca_FO_v2._12._0.Utils;
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
            DataSet ds = DAL.FillUpDataSetFromSP("Trade.GetContractsStatus", null);
            dtDBData = ds.Tables[0].Copy();
            MainForm.log.Information("Execution of SP for Activate/Deactivate contracts view completed");
            dataGridActivateContracts.DataSource = ds.Tables[0];
            dataGridActivateContracts.Sort(dataGridActivateContracts.Columns[1], ListSortDirection.Ascending);
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
                                  on
                                  new
                                  {
                                      entityName = p.Field<string>("Name"),
                                      RootContract = p.Field<string>("RootContract")
                                  }
                        equals
                        new
                        {
                            entityName = t.Field<string>("Name"),
                            RootContract = t.Field<string>("RootContract")
                        }

                                  where (Convert.ToBoolean(Convert.ToString(p["TobePublished"]))) != (Convert.ToBoolean(Convert.ToString(t["TobePublished"])))
                                  select new
                                  {
                                      EntityCode = p.Field<int>("EntityCode"),
                                      EntityName = p.Field<string>("Name"),
                                      RootContract = p.Field<string>("RootContract"),
                                      tobePublished = Convert.ToBoolean(Convert.ToString(t["TobePublished"]))
                                  }).ToList();
                DataTable dtActiveContracts = DataTableUtilities.ToDataTable(JoinResult);
                MainForm.log.Information("You have pressed yes");
                int entitycode = 0;
                bool tobePublished = false;
                string rootContract = "";

                bool isContainpos = false;
                MainForm.log.Information("Excecution of SP for activativating/deactivating HFs is started");
                for (int i = 0; i < dtActiveContracts.Rows.Count; i++)
                {

                    List<SqlParameter> sqlParameters1 = new List<SqlParameter>();
                    sqlParameters1.Add(new SqlParameter()
                    {
                        SqlDbType = SqlDbType.NVarChar,
                        ParameterName = "@ContractName",
                        Direction = ParameterDirection.Input,
                        Value = dtActiveContracts.Rows[i]["RootContract"]
                    });
                    sqlParameters1.Add(new SqlParameter()
                    {
                        SqlDbType = SqlDbType.NVarChar,
                        ParameterName = "@EntityName",
                        Direction = ParameterDirection.Input,
                        Value = dtActiveContracts.Rows[i]["EntityName"]
                    });

                    DataSet dspostions = DAL.FillUpDataSetFromSP("[Trade].[GetPositionsData]", sqlParameters1);
                    if (dtActiveContracts.Rows[i]["EntityName"].ToString() == "HF1")
                    {
                        if (Convert.ToInt32(dspostions.Tables[0].Rows[0]["apacLots"]) != 0 || Convert.ToInt32(dspostions.Tables[0].Rows[0]["emeaLots"]) != 0)
                        {
                            isContainpos = true;
                        }
                    }

                    else if (dtActiveContracts.Rows[i]["EntityName"].ToString() == "HF2")
                    {
                        if (Convert.ToInt32(dspostions.Tables[0].Rows[0]["Lots"]) != 0)
                        {
                            isContainpos = true;
                        }
                    }



                }
               
                if (isContainpos == true)
                {
                    DialogResult res1 = MessageBox.Show("We have open postions do you want continue", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (res1 == DialogResult.Yes)
                    {
                        for (int i = 0; i < dtActiveContracts.Rows.Count; i++)
                        {
                            if (!String.IsNullOrEmpty(dtActiveContracts.Rows[i]["EntityCode"].ToString()))
                            {
                                entitycode = Convert.ToInt32(dtActiveContracts.Rows[i]["EntityCode"]);
                            }
                            if (!String.IsNullOrEmpty(dtActiveContracts.Rows[i]["RootContract"].ToString()))
                            {
                                rootContract = dtActiveContracts.Rows[i]["RootContract"].ToString();
                            }
                            if (!String.IsNullOrEmpty(dtActiveContracts.Rows[i]["tobePublished"].ToString()))
                            {
                                tobePublished = Convert.ToBoolean(dtActiveContracts.Rows[i]["tobePublished"]);
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

                }
                else if(isContainpos==false)
                {
                    DialogResult res = MessageBox.Show("Do you want to Activate/Deactivate the Contracts  in the database ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (res == DialogResult.Yes)
                    {
                        for (int i = 0; i < dtActiveContracts.Rows.Count; i++)
                        {
                            if (!String.IsNullOrEmpty(dtActiveContracts.Rows[i]["EntityCode"].ToString()))
                            {
                                entitycode = Convert.ToInt32(dtActiveContracts.Rows[i]["EntityCode"]);
                            }
                            if (!String.IsNullOrEmpty(dtActiveContracts.Rows[i]["RootContract"].ToString()))
                            {
                                rootContract = dtActiveContracts.Rows[i]["RootContract"].ToString();
                            }
                            if (!String.IsNullOrEmpty(dtActiveContracts.Rows[i]["tobePublished"].ToString()))
                            {
                                tobePublished = Convert.ToBoolean(dtActiveContracts.Rows[i]["tobePublished"]);
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
                }
            
                


                else
                {
                    MainForm.log.Information("Contracts are activated/deactivated is not done because you have pressed No");
                    MessageBox.Show("Contracts are activated/deactivated is not done because you have pressed No", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Contracts are activated/deactivated is not done because some error occurred: " + ex);
                MessageBox.Show("Contracts are activated/deactivated is not done because some error occurred", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
        public static DataTable GridtoDatatable(DataGridView view)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn item in view.Columns)
            {
                dt.Columns.Add(item.DataPropertyName);
            }
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
            return dt;
        }
        
        
    }
}
