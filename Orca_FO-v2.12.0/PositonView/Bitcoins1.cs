using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL = Orca_FO_v2._12._0.DataContext.DbContext;
using AppSetting = Orca_FO_v2._12._0.Utils.GetterData;

namespace Orca_FO_v2._12._0.PositonView
{
    public partial class Bitcoins1 : UserControl
    {
        public Bitcoins1()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of Bitcoins1 positions view  components");
            GetBitcoins1();
        }
        public void GetBitcoins1()
        {
            MainForm.log.Information("Execution of SP for Bitcoins1 positions view started");
            DataTable dtBtc = DAL.FillUpDataSetFromSP("[Trade].[GenerateBTCPositionsForEntity2]",null).Tables[0];
            MainForm.log.Information("Execution of SP for Bitcoins1 positions view completed");
            dataGridView1.DataSource = dtBtc;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked successfully");
            GetBitcoins1();
            MainForm.log.Information("Refresh button is clicked successfully");
        }

        private void btnTraansfertoHF2_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Transfer of HF2 button is clicked sending to HF");
            DialogResult res = MessageBox.Show("Do you want to transfer file to Hedge Fund?", "Transfer to HF", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if (res != DialogResult.No)
            {
                MainForm.log.Information("Execution of SP for fetching the values is started");
                DataTable dtBTC = DAL.FillUpDataSetFromSP( "[Trade].[GenerateBTCPositionsForEntity2]", null).Tables[0];
                MainForm.log.Information("Exection of SP is completed");
                TransfertoHF2.GenerateBTCPositionsTextFileAndSFTPTransfer(dtBTC);
            }
        }

        private void btnExporttoexcel_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Export to excel  button is clicked for exporting Bitcoins1 positions view");
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
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(filepath + "Bitcoins1" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MainForm.log.Information("Export of Bitcoins1 positions grid data is completed successfully");
                MessageBox.Show("Export of Bitcoins1 positions grid data is completed successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Bitcoins1 positions grid data is not exported" + ex);
                MessageBox.Show("Bitcoins1 positions grid data is not exported", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void resetAllBTCPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Reset all All Bitcoins1 Positions to 0");
                if (MessageBox.Show("Do you want to Reset All BTC Positions 0 ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.No)
                {
                    MainForm.log.Information("You have pressed yes so all the positions are resetting to zero..");
                    MainForm.log.Information("Executionf of SP starts for resetting positions");
                    DAL.ExecuteSp("[Trade].[ResetAllBTCPositionsforHF2ToZero]", null);
                    MainForm.log.Information("SP executes successfully");
                }
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Exception occurrs: " + ex);
            }
            
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBitcoins1();
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;

            if (headerText.Contains("Notional"))
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,###.####################");
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //string headerText = dataGridView1.Columns["colUSDNotional"].HeaderText;

            //if (headerText==("Notional(USD)"))
            //{
            //    int apacData = Convert.ToInt32(dataGridView1.Rows[0].Cells["colUSDNotional"].Value);
            //    if (apacData>0)
            //    {
            //        e.CellStyle.ForeColor = Color.Green;
            //    }
            //    if (apacData<0)
            //    {
            //        e.CellStyle.ForeColor = Color.Crimson;
            //    }
            //}
        }
    }
}
