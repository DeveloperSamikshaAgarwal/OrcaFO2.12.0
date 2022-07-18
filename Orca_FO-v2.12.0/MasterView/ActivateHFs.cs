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
using AppSetting = Orca_FO_v2._12._0.Utils.GetterData;
using System.IO;
using Orca_FO_v2._12._0.PositonView;
using Orca_FO_v2._12._0.Utils;

namespace Orca_FO_v2._12._0.MasterView
{
    public partial class ActivateHFs : UserControl
    {
        DataTable dtAllHF1;


        public ActivateHFs()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of Activate/Deactivate HFs view  components");
            GetAllHFs();
        }
        public void GetAllHFs()
        {
            MainForm.log.Information("Execution of SP for Activate/Deactivate HFs view started");
            DataTable dtAllHF = DAL.FillUpDataSetFromSP("[Static].[ActivateDeActivateHFs]",null).Tables[0];
            MainForm.log.Information("Execution of SP for Activate/Deactivate HFs view completed");
            dtAllHF1 = dtAllHF.Copy();
            dataGridHFs.DataSource = dtAllHF;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked");
            GetAllHFs();
            MainForm.log.Information("Refreshed Successfully");
        }

        private void colActivateHFs_Click(object sender, EventArgs e)
        {
            try
            {
                
                MainForm.log.Information("Activate/Deactivate HFs button is clicked");
                DataTable dtViewData = ActivateContracts.GridtoDatatable(dataGridHFs);
                var JoinResult = (from p in dtAllHF1.AsEnumerable()
                                  join t in dtViewData.AsEnumerable()
                                  on
                                  new
                                  {
                                      entityName = p.Field<string>("Name"),
                                      Portfolio = p.Field<string>("Portfolio")
                                  }
                        equals
                        new
                        {
                            entityName = t.Field<string>("Name"),
                            Portfolio = t.Field<string>("Portfolio")
                        }

                                  where (Convert.ToBoolean(Convert.ToString(p["isThisActive"]))) != (Convert.ToBoolean(Convert.ToString(t["isThisActive"])))
                                  select new
                                  {
                                      EntityCode = p.Field<int>("EntityCode"),
                                      EntityName = p.Field<string>("Name"),
                                      Portfolio = p.Field<string>("Portfolio"),
                                      isThisActive = Convert.ToBoolean(Convert.ToString(t["isThisActive"]))
                                  }).ToList();
                DataTable dtActiveHFs  = DataTableUtilities.ToDataTable(JoinResult);
                //DialogResult res = MessageBox.Show("Do you want to activate or deactivate the portfolio for the particular entitiy?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (DialogResult.Yes==res)
                {
                    int entityCode = 0;
                    string portfolio = "";
                    bool isThisActive = false;
                    bool isContainpos = false;
                    for (int i = 0; i < dtActiveHFs.Rows.Count; i++)
                    {

                        List<SqlParameter> sqlParameters1 = new List<SqlParameter>();
                        sqlParameters1.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.NVarChar,
                            ParameterName = "@Portfolio",
                            Direction = ParameterDirection.Input,
                            Value = dtActiveHFs.Rows[i]["Portfolio"]
                        });
                        sqlParameters1.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.NVarChar,
                            ParameterName = "@EntityName",
                            Direction = ParameterDirection.Input,
                            Value = dtActiveHFs.Rows[i]["EntityName"]
                        });

                        DataSet dspostions = DAL.FillUpDataSetFromSP("Trade.GetOpenPositionForHFs", sqlParameters1);
                        if (dtActiveHFs.Rows[i]["EntityName"].ToString() == "HF1")
                        {
                            if (Convert.ToInt32(dspostions.Tables[0].Rows[0]["RowCountNo"]) != 0)
                            {
                                isContainpos = true;
                            }
                        }

                        else if (dtActiveHFs.Rows[i]["EntityName"].ToString() == "HF2")
                        {
                            if (Convert.ToInt32(dspostions.Tables[0].Rows[0]["RowCountNo"]) != 0)
                            {
                                isContainpos = true;
                            }
                        }



                    }

                    MainForm.log.Information("Excecution of SP for activativating/deactivating HFs is started");
                    if (isContainpos == true)
                    {
                        DialogResult res1 = MessageBox.Show("We have open postions do you want continue", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (res1 == DialogResult.Yes)
                        {
                            for (int i = 0; i < dtActiveHFs.Rows.Count; i++)
                            {
                                if (!String.IsNullOrEmpty(dtActiveHFs.Rows[i]["EntityCode"].ToString()))
                                {
                                    entityCode = Convert.ToInt32(dtActiveHFs.Rows[i]["EntityCode"]);
                                }
                                if (!String.IsNullOrEmpty(dtActiveHFs.Rows[i]["Portfolio"].ToString()))
                                {
                                    portfolio = dtActiveHFs.Rows[i]["Portfolio"].ToString();
                                }
                                if (!String.IsNullOrEmpty(dtActiveHFs.Rows[i]["isThisActive"].ToString()))
                                {
                                    isThisActive = Convert.ToBoolean(dtActiveHFs.Rows[i]["isThisActive"]);
                                }
                                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                                sqlParameters.Add(new SqlParameter()
                                {
                                    SqlDbType = SqlDbType.Int,
                                    ParameterName = "@AdaptorCode",
                                    Direction = ParameterDirection.Input,
                                    Value = entityCode
                                });
                                sqlParameters.Add(new SqlParameter()
                                {
                                    SqlDbType = SqlDbType.NVarChar,
                                    ParameterName = "@Portfolio",
                                    Direction = ParameterDirection.Input,
                                    Value = portfolio
                                });
                                sqlParameters.Add(new SqlParameter()
                                {
                                    SqlDbType = SqlDbType.Bit,
                                    ParameterName = "@isThisActivebyPF",
                                    Direction = ParameterDirection.Input,
                                    Value = isThisActive
                                });
                                DAL.ExecuteSp("[Static].[UpdateActivateExternalAdaptor]", sqlParameters);

                            }
                            MainForm.log.Information("SpExecutes successfully");
                            MainForm.log.Information("Hedge fund activation/deactivation is done successfully");
                            MessageBox.Show("Hedge fund activation/deactivation is done successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    else if (isContainpos == false)
                    {
                        DialogResult res = MessageBox.Show("Do you want to activate or deactivate the portfolio for the particular entitiy?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (res == DialogResult.Yes)
                        {
                            for (int i = 0; i < dtActiveHFs.Rows.Count; i++)
                            {
                                if (!String.IsNullOrEmpty(dtActiveHFs.Rows[i]["EntityCode"].ToString()))
                                {
                                    entityCode = Convert.ToInt32(dtActiveHFs.Rows[i]["EntityCode"]);
                                }
                                if (!String.IsNullOrEmpty(dtActiveHFs.Rows[i]["Portfolio"].ToString()))
                                {
                                    portfolio = dtActiveHFs.Rows[i]["Portfolio"].ToString();
                                }

                                if (!String.IsNullOrEmpty(dtActiveHFs.Rows[i]["isThisActive"].ToString()))
                                {
                                    isThisActive = Convert.ToBoolean(dtActiveHFs.Rows[i]["isThisActive"]);
                                }
                                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                                sqlParameters.Add(new SqlParameter()
                                {
                                    SqlDbType = SqlDbType.Int,
                                    ParameterName = "@AdaptorCode",
                                    Direction = ParameterDirection.Input,
                                    Value = entityCode
                                });
                                sqlParameters.Add(new SqlParameter()
                                {
                                    SqlDbType = SqlDbType.NVarChar,
                                    ParameterName = "@Portfolio",
                                    Direction = ParameterDirection.Input,
                                    Value = portfolio
                                });
                                sqlParameters.Add(new SqlParameter()
                                {
                                    SqlDbType = SqlDbType.Bit,
                                    ParameterName = "@isThisActivebyPF",
                                    Direction = ParameterDirection.Input,
                                    Value = isThisActive
                                });
                                DAL.ExecuteSp("[Static].[UpdateActivateExternalAdaptor]", sqlParameters);

                            }
                            MainForm.log.Information("SpExecutes successfully");
                            MainForm.log.Information("Hedge fund activation/deactivation is done successfully");
                            MessageBox.Show("Hedge fund activation/deactivation is done successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }    
                GetAllHFs();


            }
           
             catch (Exception ex)
            {
                MainForm.log.Information("Hedge fund activation/deactivation is not done"+ex);
                MessageBox.Show("Hedge fund activation/deactivation is not done: "+ex, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEportToexcel_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Export to excel  button is clicked for exporting Activate/Deactivate HFs view");
                string filepath = AppSetting.ExcelSaveFileDirectory;
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Exported from gridview";
                for (int i = 1; i < dataGridHFs.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridHFs.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridHFs.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridHFs.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridHFs.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(filepath + "ActivateHFs" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MainForm.log.Information("Export of Activate/Deactivate HFs grid data is completed successfully");
                MessageBox.Show("Export of Activate/Deactivate HFs grid data is completed successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Activate/Deactivate HFs grid data is not exported" + ex);
                MessageBox.Show("Activate/Deactivate HFs grid data is not exported", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
