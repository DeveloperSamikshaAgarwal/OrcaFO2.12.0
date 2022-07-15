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

namespace Orca_FO_v2._12._0.MasterView
{
    public partial class FuturesSymbolsView : UserControl
    {
        public FuturesSymbolsView()
        {
            InitializeComponent();
            MainForm.log.Information("Initialization of futures Symbols view  components");
            GetFuturesSymbolsView();
            
        }
        public void GetFuturesSymbolsView()
        {
            MainForm.log.Information("Execution of SP for future Symbols view started");
            DataTable dtFutSymbols = DAL.FillUpDataSetFromSP("Trade.GetFutureSymbolsData", null).Tables[0];
            MainForm.log.Information("Execution of SP for future Symbols view completed");
            dgridFuturesSymbolsView.DataSource = dtFutSymbols;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Refresh button is clicked");
            GetFuturesSymbolsView();
        }

        private void btnRollOver_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Rollover button is clicked ");
            int rowindex = dgridFuturesSymbolsView.CurrentCell.RowIndex;
           int contractId= Convert.ToInt32(dgridFuturesSymbolsView.Rows[rowindex].Cells[0].Value);
            RollOverCurrentMonth month = new RollOverCurrentMonth(contractId);
            MainForm.log.Information("Rollover form is opened");
            month.Show();
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.log.Information("Export to excel  button is clicked for exporting futures symbols view");
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
                for (int i = 1; i < dgridFuturesSymbolsView.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgridFuturesSymbolsView.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgridFuturesSymbolsView.Rows.Count; i++)
                {
                    for (int j = 0; j < dgridFuturesSymbolsView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgridFuturesSymbolsView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(filepath + "FutureSymbols" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MainForm.log.Information("Export of Futures grid data is completed successfully");
                MessageBox.Show("Export of Futures grid data is completed successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Futures grid data is not exported"+ex);
                MessageBox.Show("Futures grid data is not exported", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
    }
}
