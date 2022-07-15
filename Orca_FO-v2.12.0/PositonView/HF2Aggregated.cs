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
    public partial class HF2Aggregated : UserControl
    {
        public HF2Aggregated()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of HF2 Aggregated positions view  components");
            GetHF2Aggregated();
        }
        public void GetHF2Aggregated()
        {
            MainForm.log.Information("Execution of SP for HF2 Aggregated positions view started");
            DataTable dtHF2Aggregated = DAL.FillUpDataSetFromSP("[Trade].[HF2AggregatedView]",null).Tables[0];
            MainForm.log.Information("Execution of SP for HF2 Aggregated positions view completed");
            dataGridHF2Aggregated.DataSource = dtHF2Aggregated;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked successfully");
            GetHF2Aggregated();
            MainForm.log.Information("Refresh button is clicked successfully");
        }

        private void btnExporttoexcel_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Export to excel  button is clicked for exporting HF2 Aggregated positions view");
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
                for (int i = 1; i < dataGridHF2Aggregated.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridHF2Aggregated.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridHF2Aggregated.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridHF2Aggregated.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridHF2Aggregated.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(filepath + "HF2Aggregated" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MainForm.log.Information("Export of HF2 Agrregated positions grid data is completed successfully");
                MessageBox.Show("Export of HF2 Agrregated positions grid data is completed successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MainForm.log.Information("HF2 Agrregated positions grid data is not exported" + ex);
                MessageBox.Show("HF2 Agrregated positions grid data is not exported", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dataGridHF2Aggregated_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string headerText = dataGridHF2Aggregated.Columns[e.ColumnIndex].HeaderText;

            if (headerText.Contains("Notional")||headerText=="Prices")
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,###.####################");
            }
        }
    }
}
