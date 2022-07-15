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
using AppSetting = Orca_FO_v2._12._0.Utils.GetterData;
using System.IO;

namespace Orca_FO_v2._12._0.PositonView
{
    public partial class HF1Aggregated : UserControl
    {
        public HF1Aggregated()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of HF1 Aggregated positions view  components");
            GetHF1AggregatedView();
        }
        public void GetHF1AggregatedView()
        {
            MainForm.log.Information("Execution of SP for HF1 Aggregated positions view started");
            DataTable dtHf1Aggregated = DAL.FillUpDataSetFromSP("[Trade].[AggregatedFuturePositions]",null).Tables[0];
            MainForm.log.Information("Execution of SP for HF1 Aggregated positions view completed");
            dataGridHF1Aggregated.DataSource = dtHf1Aggregated;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked successfully");
            GetHF1AggregatedView();
            MainForm.log.Information("Refresh button is clicked successfully");
        }

        private void btnExporttoexcel_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Export to excel  button is clicked for exporting HF1 Aggregated positions view");
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
                for (int i = 1; i < dataGridHF1Aggregated.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridHF1Aggregated.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridHF1Aggregated.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridHF1Aggregated.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridHF1Aggregated.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(filepath + "HF1Aggregated" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MainForm.log.Information("Export of HF1 Agrregated positions grid data is completed successfully");
                MessageBox.Show("Export of HF1 Agrregated positions grid data is completed successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MainForm.log.Information("HF1 Agrregated positions grid data is not exported" + ex);
                MessageBox.Show("HF1 Agrregated positions grid data is not exported", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dataGridHF1Aggregated_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string headerText = dataGridHF1Aggregated.Columns[e.ColumnIndex].HeaderText;

            if (headerText == "Total MV")
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,###.####################");
            }
        }
    }
}
