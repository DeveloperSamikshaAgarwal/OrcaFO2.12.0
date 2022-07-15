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

namespace Orca_FO_v2._12._0.PositonView
{
    public partial class APACPositions : UserControl
    {
        public APACPositions()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of APAC positions view  components");
            GetApacPositions();
            
        }
        public void GetApacPositions()
        {
            MainForm.log.Information("Execution of SP for APAC positions view started");
            DataTable dtApacPositon = DAL.FillUpDataSetFromSP("Trade.FetchAPACPositions", null).Tables[0];
            MainForm.log.Information("Execution of SP for APAC positions view completed");
            dataGridApacPositons.DataSource = dtApacPositon;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked successfully");
            GetApacPositions();
            MainForm.log.Information("Refresh button is clicked successfully");
        }

        private void btnTransfertoHF_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Transfer of HF button is clicked for updating  the database and sending to HF");
            DialogResult res = MessageBox.Show("Do you want to transfer file to Hedge Fund?", "Transfer to HF", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (res != DialogResult.Cancel)
            {
                int targetContracts = 0;
                int contractId = 0;
                decimal averagePrice = 0;
                int row = 0;
                MainForm.log.Information("Execution of SP for Updating the values is started");
                for (int i = 0; i < dataGridApacPositons.RowCount; i++)
                {
                    bool isTisActive = Convert.ToBoolean(dataGridApacPositons.Rows[i].Cells["colisThisActive"].Value);
                    if (isTisActive.ToString().ToLower() == "true".ToLower())
                    {
                        targetContracts = Convert.ToInt32(dataGridApacPositons.Rows[i].Cells["coltarget_contracts"].Value);
                        averagePrice = Convert.ToDecimal(dataGridApacPositons.Rows[i].Cells["colref_price"].Value);
                        contractId = Convert.ToInt32(dataGridApacPositons.Rows[i].Cells["colContractId"].Value);
                        List<SqlParameter> sqlParameters = new List<SqlParameter>();
                        sqlParameters.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.NVarChar,
                            ParameterName = "@Filetype",
                            Value = "APAC"
                        });
                        sqlParameters.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.Int,
                            ParameterName = "@ContractId",
                            Value = contractId
                        });
                        sqlParameters.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.Int,
                            ParameterName = "@NewLots",
                            Value = targetContracts
                        });
                        sqlParameters.Add(new SqlParameter()
                        {
                            SqlDbType = SqlDbType.Decimal,
                            ParameterName = "@Price",
                            Value = averagePrice
                        });
                        DAL.ExecuteSp("[Trade].[UpdateEMEAandAPACpositonsforUI]", sqlParameters);
                    }
                    else
                    {
                        row++;
                    }
                    MainForm.log.Information("Exection of SP is completed");
                }
                if (res == DialogResult.Yes)
                {
                    MainForm.log.Information("You have pressed yes");
                    if (row == dataGridApacPositons.RowCount)
                    {
                        MainForm.log.Information("Please select atleast 1 row!!");
                        MessageBox.Show("Please select atleast 1 row!!");

                    }
                    else
                    {
                        if (TransferFiletoHF1.TransferFilesToHedgeFund("APAC") == true)
                        {
                            MainForm.log.Information("File has been successfully moved to the HF!");
                            MessageBox.Show("File has been successfully moved to the HF!");
                        }
                        else
                        {
                            MainForm.log.Information("File has not been sent to the HF");
                            MessageBox.Show("File has not been sent to the HF");
                        }
                    }
                }
                else if (res == DialogResult.No)
                {
                    MainForm.log.Information("You have pressed No");
                    if (row == dataGridApacPositons.RowCount)
                    {
                        MainForm.log.Information("Please select atleast 1 row!!");
                        MessageBox.Show("Please select atleast 1 row!!");
                    }
                    else
                    {
                        MainForm.log.Information("Values are updated successfully in the database!");
                        MessageBox.Show("Values are updated successfully in the database!");
                    }
                }
            }
            else
            {
                MainForm.log.Information("Nothing happened because you have pressed cancel");
            }

        }

        private void dataGridApacPositons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            int targetContracts = 0;
            double averagePrice = 0;
            double targetNotional = 0;
            int sizeMultiplier = 0;
            double notionalMultiplier = 0;
            int rowIndex = 0;

            if (dgv == null)
                return;
            else
            {
                if (dgv.RowCount > 0)
                {
                    rowIndex = dgv.CurrentCell.RowIndex;
                    string headerText = dgv.Columns[e.ColumnIndex].HeaderText;
                    if ((headerText == "Target Contracts") || (headerText == "Average Price"))
                    {

                        targetContracts = Convert.ToInt32(dgv.Rows[rowIndex].Cells["coltarget_contracts"].Value);
                        averagePrice = Convert.ToDouble(dgv.Rows[rowIndex].Cells["colref_price"].Value);
                        sizeMultiplier = Convert.ToInt32(dgv.Rows[rowIndex].Cells["colSizeMultiplier"].Value);
                        notionalMultiplier = Convert.ToDouble(dgv.Rows[rowIndex].Cells["colNotionalMultiplier"].Value);
                        targetNotional = targetContracts * averagePrice * sizeMultiplier * notionalMultiplier;
                        dgv.Rows[rowIndex].Cells["coltarget_notional"].Value = targetNotional;

                    }

                }

            }
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Export to excel  button is clicked for exporting APAC positions view");
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
                for (int i = 1; i < dataGridApacPositons.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridApacPositons.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridApacPositons.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridApacPositons.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridApacPositons.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(filepath + "ApacPositions" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MainForm.log.Information("Export of APAC positions grid data is completed successfully");
                MessageBox.Show("Export of APAC positions grid data is completed successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MainForm.log.Information("APAC positions grid data is not exported" + ex);
                MessageBox.Show("APAC positions grid data is not exported", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void resetAllAPACPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Reset all All APAC Positions to 0");
                if (MessageBox.Show("Do you want to Reset All APAC Positions to 0 ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.No)
                {
                    MainForm.log.Information("You have pressed yes so all the positions are resetting to zero..");
                    MainForm.log.Information("Executionf of SP starts for resetting positions");
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(new SqlParameter()
                    {
                        SqlDbType = SqlDbType.NVarChar,
                        ParameterName = "@Filetype",
                        Value = "APAC"
                    });
                    DAL.ExecuteSp("[Trade].[ResetAllPositionsToZero]", sqlParameters);
                    MainForm.log.Information("SP executes successfully");
                    GetApacPositions();
                }
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Exception occurrs: " + ex);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetApacPositions();
        }

        private void dataGridApacPositons_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string headerText = dataGridApacPositons.Columns[e.ColumnIndex].HeaderText;
            
            if (headerText=="Target Notional"||headerText=="Average Price")
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,###.####################");
            }
        }
    }
}
