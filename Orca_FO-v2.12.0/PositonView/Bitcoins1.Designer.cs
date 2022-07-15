
namespace Orca_FO_v2._12._0.PositonView
{
    partial class Bitcoins1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetAllBTCPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpboxBtc = new System.Windows.Forms.GroupBox();
            this.btnExporttoexcel = new System.Windows.Forms.Button();
            this.btnTraansfertoHF2 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.colContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUSDNotional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmodelname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltargetmaxpos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.grpboxBtc.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.grpboxBtc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 624);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContractName,
            this.colUSDNotional,
            this.colNotional,
            this.colmodelname,
            this.coltargetmaxpos});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1006, 565);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllBTCPositionsToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 48);
            // 
            // resetAllBTCPositionsToolStripMenuItem
            // 
            this.resetAllBTCPositionsToolStripMenuItem.Name = "resetAllBTCPositionsToolStripMenuItem";
            this.resetAllBTCPositionsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.resetAllBTCPositionsToolStripMenuItem.Text = "Reset All BTC Positions";
            this.resetAllBTCPositionsToolStripMenuItem.Click += new System.EventHandler(this.resetAllBTCPositionsToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // grpboxBtc
            // 
            this.grpboxBtc.Controls.Add(this.btnExporttoexcel);
            this.grpboxBtc.Controls.Add(this.btnTraansfertoHF2);
            this.grpboxBtc.Controls.Add(this.btnRefresh);
            this.grpboxBtc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpboxBtc.Location = new System.Drawing.Point(0, 0);
            this.grpboxBtc.Name = "grpboxBtc";
            this.grpboxBtc.Size = new System.Drawing.Size(1006, 59);
            this.grpboxBtc.TabIndex = 1;
            this.grpboxBtc.TabStop = false;
            // 
            // btnExporttoexcel
            // 
            this.btnExporttoexcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExporttoexcel.Image = global::Orca_FO_v2._12._0.Properties.Resources.send;
            this.btnExporttoexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExporttoexcel.Location = new System.Drawing.Point(668, 16);
            this.btnExporttoexcel.Name = "btnExporttoexcel";
            this.btnExporttoexcel.Size = new System.Drawing.Size(107, 40);
            this.btnExporttoexcel.TabIndex = 2;
            this.btnExporttoexcel.Text = "Export to excel";
            this.btnExporttoexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExporttoexcel.UseVisualStyleBackColor = true;
            this.btnExporttoexcel.Click += new System.EventHandler(this.btnExporttoexcel_Click);
            // 
            // btnTraansfertoHF2
            // 
            this.btnTraansfertoHF2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTraansfertoHF2.Image = global::Orca_FO_v2._12._0.Properties.Resources.transfer;
            this.btnTraansfertoHF2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraansfertoHF2.Location = new System.Drawing.Point(775, 16);
            this.btnTraansfertoHF2.Name = "btnTraansfertoHF2";
            this.btnTraansfertoHF2.Size = new System.Drawing.Size(153, 40);
            this.btnTraansfertoHF2.TabIndex = 1;
            this.btnTraansfertoHF2.Text = "Transfer to Hedge Fund";
            this.btnTraansfertoHF2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTraansfertoHF2.UseVisualStyleBackColor = true;
            this.btnTraansfertoHF2.Click += new System.EventHandler(this.btnTraansfertoHF2_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(928, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // colContractName
            // 
            this.colContractName.DataPropertyName = "ContractName";
            this.colContractName.HeaderText = "Root Contract";
            this.colContractName.Name = "colContractName";
            this.colContractName.ReadOnly = true;
            this.colContractName.Width = 150;
            // 
            // colUSDNotional
            // 
            this.colUSDNotional.DataPropertyName = "USDNotional";
            this.colUSDNotional.HeaderText = "Notional(USD)";
            this.colUSDNotional.Name = "colUSDNotional";
            this.colUSDNotional.ReadOnly = true;
            this.colUSDNotional.Width = 150;
            // 
            // colNotional
            // 
            this.colNotional.DataPropertyName = "Notional";
            this.colNotional.HeaderText = "Notional";
            this.colNotional.Name = "colNotional";
            this.colNotional.ReadOnly = true;
            this.colNotional.Width = 150;
            // 
            // colmodelname
            // 
            this.colmodelname.DataPropertyName = "modelname";
            this.colmodelname.HeaderText = "modelname";
            this.colmodelname.Name = "colmodelname";
            this.colmodelname.Visible = false;
            // 
            // coltargetmaxpos
            // 
            this.coltargetmaxpos.DataPropertyName = "targetmaxpos";
            this.coltargetmaxpos.HeaderText = "targetmaxpos";
            this.coltargetmaxpos.Name = "coltargetmaxpos";
            this.coltargetmaxpos.Visible = false;
            // 
            // Bitcoins1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Bitcoins1";
            this.Size = new System.Drawing.Size(1006, 624);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.grpboxBtc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpboxBtc;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExporttoexcel;
        private System.Windows.Forms.Button btnTraansfertoHF2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetAllBTCPositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUSDNotional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmodelname;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltargetmaxpos;
    }
}
