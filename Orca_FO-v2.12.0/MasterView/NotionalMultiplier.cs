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

namespace Orca_FO_v2._12._0.MasterView
{
    public partial class NotionalMultiplier : UserControl
    {
        public NotionalMultiplier()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of notional multiplier view  components");
            GetNotionalMultiplier();
        }
        public void GetNotionalMultiplier()
        {
            MainForm.log.Information("Execution of SP for notional multiplier view started");
            DataSet ds = DAL.GetDataSetFromQuery("select ContractName,FORMAT(NotionalMultiplierHF1,'#.####################') as NotionalMultiplierHF1,FORMAT(NotionalMultiplierHF2,'#.####################') as NotionalMultiplierHF2 from Trade.FuturesNotionalMultiplier");
            MainForm.log.Information("Execution of SP for notional multiplier view completed");
            dataGridNotMul.DataSource = ds.Tables[0];
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked");
            GetNotionalMultiplier();
            MainForm.log.Information("View is refreshed successfully");
        }

        private void btnUpdateNotionalMultiplier_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Update notional multiplier button is clicked");
                decimal notionalMultiplierHF1 = 0;
                decimal notionalMultiplierHF2 = 0;
                MainForm.log.Information("Execution of SP for updating notional multiplier started");
                for (int i = 0; i < dataGridNotMul.RowCount; i++)
                {
                    string contractName = dataGridNotMul.Rows[i].Cells["colContractName"].Value.ToString();
                    if (!String.IsNullOrEmpty(dataGridNotMul.Rows[i].Cells["colNotionalMultiplierHF1"].Value.ToString()))
                    {
                        notionalMultiplierHF1 = Convert.ToDecimal(dataGridNotMul.Rows[i].Cells["colNotionalMultiplierHF1"].Value);
                    }
                    else
                    {
                        notionalMultiplierHF1 = 0;
                    }
                    if (!String.IsNullOrEmpty(dataGridNotMul.Rows[i].Cells["colNotionalMultiplierHF2"].Value.ToString()))
                    {
                        notionalMultiplierHF2 = Convert.ToDecimal(dataGridNotMul.Rows[i].Cells["colNotionalMultiplierHF2"].Value);
                    }
                    else
                    {
                        notionalMultiplierHF2 = 0;
                    }
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(new SqlParameter()
                    {
                        SqlDbType = SqlDbType.Decimal,
                        ParameterName = "@NotionalMultiplier1",
                        Direction = ParameterDirection.Input,
                        Value = notionalMultiplierHF1
                    });
                    sqlParameters.Add(new SqlParameter()
                    {
                        SqlDbType = SqlDbType.Decimal,
                        ParameterName = "@NotionalMultiplier2",
                        Direction = ParameterDirection.Input,
                        Value = notionalMultiplierHF2
                    });
                    sqlParameters.Add(new SqlParameter()
                    {
                        SqlDbType = SqlDbType.NVarChar,
                        ParameterName = "@ContractName",
                        Direction = ParameterDirection.Input,
                        Value = contractName
                    });
                    DAL.ExecuteSp("[Trade].[UpdateNotionalMultiplier]", sqlParameters);
                    string quetry = "select ContractId from Trade.FutureSymbols where ContractName='" + contractName + "'";
                    DataTable dtContractName = DAL.GetDataSetFromQuery(quetry).Tables[0];
                    var contractId = dtContractName.AsEnumerable().Select(x => x.Field<int>("ContractId")).FirstOrDefault();
                    if (notionalMultiplierHF2 == 0)
                    {
                        List<SqlParameter> sqlParameters1 = new List<SqlParameter>();
                        sqlParameters1.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.NVarChar,
                            ParameterName = "@ContractId",
                            Direction = ParameterDirection.Input,
                            Value = Convert.ToInt32(contractId)
                        });
                        sqlParameters1.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.Int,
                            ParameterName = "@Lots",
                            Direction = ParameterDirection.Input,
                            Value = 0
                        });
                        sqlParameters1.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.Decimal,
                            ParameterName = "@Prices",
                            Direction = ParameterDirection.Input,
                            Value = 0.0
                        });
                        DAL.ExecuteSp("Trade.[UpdatePositionsforHF2]", sqlParameters1);
                    }
                   
                }
                MainForm.log.Information("SP executes and also notional multipliers are updated succesfully");
                MessageBox.Show("Notional multipliers are updated succesfully");

            }
            catch (Exception ex)
            {
                MainForm.log.Information("Notional multipliers are not updated succesfully");
                MessageBox.Show("Notional multipliers are not updated succesfully");
            }
        }

        private void btnExporttoexcel_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Export to excel  button is clicked for exporting Notional multiplier view");
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
                for (int i = 1; i < dataGridNotMul.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridNotMul.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridNotMul.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridNotMul.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridNotMul.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(filepath + "NotionalMultiplier" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MainForm.log.Information("Export of Notional multiplier grid data is completed successfully");
            MessageBox.Show("Export of Notional multiplier grid data is completed successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Notional multiplier grid data is not exported" + ex);
                MessageBox.Show("Notional multiplier grid data is not exported", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
