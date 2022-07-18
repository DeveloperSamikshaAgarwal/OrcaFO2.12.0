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
        DataTable dtAllHF;


        public ActivateHFs()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of Activate/Deactivate HFs view  components");
            GetAllHFs();
        }
        public void GetAllHFs()
        {
            MainForm.log.Information("Execution of SP for Activate/Deactivate HFs view started");
            dtAllHF = DAL.FillUpDataSetFromSP("[Static].[ActivateDeActivateHFs]",null).Tables[0];
            MainForm.log.Information("Execution of SP for Activate/Deactivate HFs view completed");
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
                var JoinResult = (from p in dtAllHF.AsEnumerable()
                                  join t in dtViewData.AsEnumerable()
                                  on
                                  new
                                  {
                                      entityName = p.Field<string>("Name"),
                                     // RootContract = p.Field<string>("RootContract")
                                  }
                        equals
                        new
                        {
                            entityName = t.Field<string>("Name"),
                           // RootContract = t.Field<string>("RootContract")
                        }

                                  where (Convert.ToBoolean(Convert.ToString(p["TobePublished"]))) != (Convert.ToBoolean(Convert.ToString(t["TobePublished"])))
                                  select new
                                  {
                                     // EntityCode = p.Field<int>("EntityCode"),
                                      EntityName = p.Field<string>("Name"),
                                      RootContract = p.Field<string>("RootContract"),
                                      tobePublished = Convert.ToBoolean(Convert.ToString(t["TobePublished"]))
                                  }).ToList();
                DataTable dtActiveContracts = DataTableUtilities.ToDataTable(JoinResult);
                DialogResult res = MessageBox.Show("Do you want to activate or deactivate the portfolio for the particular entitiy?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes==res)
                {
                    int adaptorCode = 0;
                    string portfolio = "";
                    bool isThisActive = false;
                    MainForm.log.Information("Excecution of SP for activativating/deactivating HFs is started");
                    for (int i = 0; i < dataGridHFs.RowCount; i++)
                    {
                        if (!String.IsNullOrEmpty(dataGridHFs.Rows[i].Cells["colEntityCode"].Value.ToString()))
                        {
                            adaptorCode = Convert.ToInt32(dataGridHFs.Rows[i].Cells["colEntityCode"].Value);
                        }
                        if (!String.IsNullOrEmpty(dataGridHFs.Rows[i].Cells["colPortfolio"].Value.ToString()))
                        {
                            portfolio = dataGridHFs.Rows[i].Cells["colPortfolio"].Value.ToString();
                        }
                        if (!String.IsNullOrEmpty(dataGridHFs.Rows[i].Cells["colisThisActive"].Value.ToString()))
                        {
                            isThisActive = Convert.ToBoolean(dataGridHFs.Rows[i].Cells["colisThisActive"].Value);
                        }
                        List<SqlParameter> sqlParameters = new List<SqlParameter>();
                        sqlParameters.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.Int,
                            ParameterName = "@AdaptorCode",
                            Direction = ParameterDirection.Input,
                            Value = adaptorCode
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
