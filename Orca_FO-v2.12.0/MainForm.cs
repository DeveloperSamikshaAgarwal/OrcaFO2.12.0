using CustomLoggerProvider;
using Orca_FO_v2._12._0.Configurations;
using Orca_FO_v2._12._0.MasterView;
using Orca_FO_v2._12._0.PositonView;
using Orca_FO_v2._12._0.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSetting = Orca_FO_v2._12._0.Utils.GetterData;

namespace Orca_FO_v2._12._0
{
    public partial class MainForm : RibbonForm
    {
        //static string closeButtonFullPath = "";
        public static Logger log = new Logger();
        public MainForm()
        {
            InitializeComponent();
            StaticData.LoadData();
        }

        private void rbbFutures_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("Future button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("Futures    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {

                    if (tagbpage.Text.Contains("Futures"))
                    {
                        log.Information("Is tab page of futures opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }

                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    FuturesSymbolsView symbolsView = new FuturesSymbolsView();
                    symbolsView.Dock = DockStyle.Fill;
                    tp.Controls.Add(symbolsView);
                    

                    log.Information("Futures Symbols view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the futures symbols view");
                log.Error("Error occurred while opening the futures symbols view: " + ex);
            }

        }


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                //closeButtonFullPath = AppSetting.closeButtonFullPath;
                var tabPage = this.tabControl1.TabPages[e.Index];
                var tabRect = this.tabControl1.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);
                var closeImage = new Bitmap(Properties.Resources.Close);
                e.Graphics.DrawImage(closeImage,
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                    tabRect, tabPage.ForeColor, TextFormatFlags.Left);
                //if (e.Index == tabControl1.SelectedIndex)
                //{
                //    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text,
                //        new Font(tabControl1.Font, FontStyle.Bold),
                //        Brushes.Black,
                //        new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
                //}
                //else
                //{
                //    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text,
                //        tabControl1.Font,
                //        Brushes.Black,
                //        new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
                //}
            }
            catch (Exception ex)
            {
                log.Error("Exception occurs  close is not drawn =" + ex);
            }
        }
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                for (var i = 0; i < this.tabControl1.TabPages.Count; i++)
                {
                    var tabRect = this.tabControl1.GetTabRect(i);
                    tabRect.Inflate(-2, -2);
                    var closeImage = new Bitmap(Properties.Resources.Close);
                    var imageRect = new Rectangle(
                        (tabRect.Right - closeImage.Width),
                        tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                        closeImage.Width,
                        closeImage.Height);
                    if (imageRect.Contains(e.Location))
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                log.Error("Exeception occurred while closing the tab: " + ex);
            }

        }

        private void ActivateHfs_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("Activate/Deactivate HFs button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("Activate/Deactivate HFs    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {

                    if (tagbpage.Text.Contains("Activate/Deactivate HFs"))
                    {
                        log.Information("Is tab page of Activate/Deactivate HFs opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    ActivateHFs activateHFs = new ActivateHFs();
                    activateHFs.Dock = DockStyle.Fill;
                    tp.Controls.Add(activateHFs);
                    log.Information("Activate/Deactivate HFs view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the Activate/Deactivate HFs view");
                log.Error("Error occurred while opening the Activate/Deactivate HFs view: " + ex);
            }
        }



        private void rbbNotionalMultiplier_Click_1(object sender, EventArgs e)
        {
            try
            {
                log.Information("Notional Multiplier button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("Notional Multiplier    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("Notional Multiplier"))
                    {
                        log.Information("Is tab page of Notional Multiplier opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    NotionalMultiplier notmul = new NotionalMultiplier();
                    notmul.Dock = DockStyle.Fill;
                    tp.Controls.Add(notmul);
                    log.Information("Notional Multiplier view is opened now");
                }
                this.tabControl1.SelectedTab = tp;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the Notional Multiplier view");
                log.Error("Error occurred while opening the Notional Multiplier view: " + ex);
            }
        }


        private void rbbApacPositions1_Click(object sender, EventArgs e)
        {
            try
            {

                log.Information("APAC positons button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("APAC Positions    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("APAC Positions"))
                    {
                        log.Information("Is tab page of Apac positions opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    APACPositions aPACPositions = new APACPositions();
                    aPACPositions.Dock = DockStyle.Fill;
                    tp.Controls.Add(aPACPositions);
                    log.Information("Apac positions view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the APAC Positions view");
                log.Error("Error occurred while opening the APAC Positions view: " + ex);
            }
        }

        private void rbbEMEAPosition1_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("EMEA positions HFs button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("EMEA Positions    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("EMEA Positions"))
                    {
                        log.Information("Is tab page of EMEA positions opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    EMEAPositions eMEAPositions = new EMEAPositions();
                    eMEAPositions.Dock = DockStyle.Fill;
                    tp.Controls.Add(eMEAPositions);
                    log.Information("EMEA positions view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the EMEA Positions view");
                log.Error("Error occurred while opening the EMEA positions view: " + ex);
            }
        }

        private void rbbHF1Aggregated1_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("HF1 Aggregated button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("HF1 Aggregated    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("HF1 Aggregated"))
                    {
                        log.Information("Is tab page of HF1 Aggregated opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    HF1Aggregated hF1Aggregated = new HF1Aggregated();
                    hF1Aggregated.Dock = DockStyle.Fill;
                    tp.Controls.Add(hF1Aggregated);
                    log.Information("HF1 Aggregated view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the HF1 Aggregated view");
                log.Error("Error occurred while opening the HF1 Aggregated view: " + ex);
            }
        }

        private void rbbFX11_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("FX1 button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("FX1    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("FX1"))
                    {
                        log.Information("Is tab page of FX1 opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    FX1 fX1 = new FX1();
                    fX1.Dock = DockStyle.Fill;
                    tp.Controls.Add(fX1);
                    log.Information("FX1 view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the FX1 Positions view");
                log.Error("Error occurred while opening the FX1 positions view: " + ex);
            }
        }

        private void rbbBitcoins11_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("Bitcoins1 button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("Bitcoins1    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("Bitcoins1"))
                    {
                        log.Information("Is tab page of Bitcoins1 opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    Bitcoins1 btc1 = new Bitcoins1();
                    btc1.Dock = DockStyle.Fill;
                    tp.Controls.Add(btc1);
                    log.Information("Bitcoins1 view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the Bitcoins1 Positions view");
                log.Error("Error occurred while opening the Bitcoins1 positions view: " + ex);
            }
        }

        private void rbbHF2Aggregated1_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("HF2 Aggregated button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("HF2 Aggregated    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("HF2 Aggregated"))
                    {
                        log.Information("Is tab page of HF2 Aggregated opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    HF2Aggregated hF2Aggregated = new HF2Aggregated();
                    hF2Aggregated.Dock = DockStyle.Fill;
                    tp.Controls.Add(hF2Aggregated);
                    log.Information("HF2 Aggregated view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the HF2 Aggregated Positions view");
                log.Error("Error occurred while opening the HF2 Aggragated view: " + ex);
            }
        }

        private void rbbLimitConfigurations_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("Limit configurations button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("Limit Configurations    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("Limit Configurations"))
                    {
                        log.Information("Is tab page of Limit configurations opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    LimitConfigurations limitConfig = new LimitConfigurations();
                    limitConfig.Dock = DockStyle.Fill;
                    tp.Controls.Add(limitConfig);
                    log.Information("Limit configurations view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the limit configurations view");
                log.Error("Error occurred while opening the limit configurations view: " + ex);
            }
        }

        private void rbbActivateDeactivateContracts_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("Activate/Deactivate contracts button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("Activate/Deactivate Contracts    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("Activate/Deactivate Contracts"))
                    {
                        log.Information("Is tab page of Activate/Deactivate contracts opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    ActivateContracts activeContracts = new ActivateContracts();
                    activeContracts.Dock = DockStyle.Fill;
                    tp.Controls.Add(activeContracts);
                    log.Information("Activate/Deactivate contracts view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the Activate/Deactivate Contracts view");
                log.Error("Error occurred while opening the Activate/Deactivate Contracts view: " + ex);
            }
        }

        private void rbbAppConfig_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("Application configuration button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("Application Configuration    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("Application Configuration"))
                    {
                        log.Information("Is tab page of Application configuration opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    ApplicationConfiguration appConfig = new ApplicationConfiguration();
                    appConfig.Dock = DockStyle.Fill;
                    tp.Controls.Add(appConfig);
                    log.Information("Application configuration view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the Application Configuration view");
                log.Error("Error occurred while opening the Application Configuration view: " + ex);
            }
        }

        private void rbbEQHF2_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("EQ1 button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("EQ1    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("EQ1"))
                    {
                        log.Information("Is tab page of EQ1 opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    EquitiesHF2 eqHF2 = new EquitiesHF2();
                    eqHF2.Dock = DockStyle.Fill;
                    tp.Controls.Add(eqHF2);
                    log.Information("EQ1 view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the EQ1 view");
                log.Error("Error occurred while opening the EQ1 view: " + ex);
            }
        }

        private void rbbHF2Aggregated_Click(object sender, EventArgs e)
        {
            try
            {
                log.Information("HF2 Aggregated button is clicked");
                tabControl1.Visible = true;
                TabPage tp = new TabPage("HF2 Aggregated    ");
                bool isopen = false;
                foreach (TabPage tagbpage in tabControl1.TabPages)
                {
                    if (tagbpage.Text.Contains("HF2 Aggregated"))
                    {
                        log.Information("Is tab page of HF2 Aggregated opened");
                        tp = tagbpage;
                        isopen = true;
                        log.Information("Yes! it is already opened");
                    }
                }
                if (!isopen)
                {
                    tabControl1.TabPages.Add(tp);
                    HF2Aggregated hF2Aggregated = new HF2Aggregated();
                    hF2Aggregated.Dock = DockStyle.Fill;
                    tp.Controls.Add(hF2Aggregated);
                    log.Information("HF2 Aggregated view is opened now");
                }
                this.tabControl1.SelectedTab = tp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while opening the HF2 Aggregated Positions view");
                log.Error("Error occurred while opening the HF2 Aggragated view: " + ex);
            }
        }
    }
}
