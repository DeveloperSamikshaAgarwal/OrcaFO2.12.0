
namespace Orca_FO_v2._12._0.PositonView
{
    partial class EquitiesHF2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvEquities = new System.Windows.Forms.DataGridView();
            this.grpEquities = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.colContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUSDNotional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTransfertoHF2 = new System.Windows.Forms.Button();
            this.btnExporttoXls = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetAllEQPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquities)).BeginInit();
            this.grpEquities.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvEquities);
            this.panel1.Controls.Add(this.grpEquities);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 641);
            this.panel1.TabIndex = 0;
            // 
            // dgvEquities
            // 
            this.dgvEquities.AllowUserToAddRows = false;
            this.dgvEquities.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquities.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquities.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContractName,
            this.colUSDNotional,
            this.colNotional});
            this.dgvEquities.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvEquities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquities.Location = new System.Drawing.Point(0, 59);
            this.dgvEquities.Name = "dgvEquities";
            this.dgvEquities.Size = new System.Drawing.Size(1067, 582);
            this.dgvEquities.TabIndex = 0;
            // 
            // grpEquities
            // 
            this.grpEquities.Controls.Add(this.btnExporttoXls);
            this.grpEquities.Controls.Add(this.btnTransfertoHF2);
            this.grpEquities.Controls.Add(this.btnRefresh);
            this.grpEquities.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEquities.Location = new System.Drawing.Point(0, 0);
            this.grpEquities.Name = "grpEquities";
            this.grpEquities.Size = new System.Drawing.Size(1067, 59);
            this.grpEquities.TabIndex = 1;
            this.grpEquities.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(983, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(81, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // colContractName
            // 
            this.colContractName.DataPropertyName = "ContractName";
            this.colContractName.HeaderText = "Contract Name";
            this.colContractName.Name = "colContractName";
            this.colContractName.ReadOnly = true;
            this.colContractName.Width = 120;
            // 
            // colUSDNotional
            // 
            this.colUSDNotional.DataPropertyName = "USDNotional";
            this.colUSDNotional.HeaderText = "Notional(USD)";
            this.colUSDNotional.Name = "colUSDNotional";
            this.colUSDNotional.ReadOnly = true;
            // 
            // colNotional
            // 
            this.colNotional.DataPropertyName = "Notional";
            this.colNotional.HeaderText = "Notional";
            this.colNotional.Name = "colNotional";
            this.colNotional.ReadOnly = true;
            // 
            // btnTransfertoHF2
            // 
            this.btnTransfertoHF2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTransfertoHF2.Image = global::Orca_FO_v2._12._0.Properties.Resources.transfer;
            this.btnTransfertoHF2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransfertoHF2.Location = new System.Drawing.Point(820, 16);
            this.btnTransfertoHF2.Name = "btnTransfertoHF2";
            this.btnTransfertoHF2.Size = new System.Drawing.Size(163, 40);
            this.btnTransfertoHF2.TabIndex = 1;
            this.btnTransfertoHF2.Text = "Transfer to Hedge Fund";
            this.btnTransfertoHF2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransfertoHF2.UseVisualStyleBackColor = true;
            this.btnTransfertoHF2.Click += new System.EventHandler(this.btnTransfertoHF2_Click);
            // 
            // btnExporttoXls
            // 
            this.btnExporttoXls.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExporttoXls.Image = global::Orca_FO_v2._12._0.Properties.Resources.send;
            this.btnExporttoXls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExporttoXls.Location = new System.Drawing.Point(704, 16);
            this.btnExporttoXls.Name = "btnExporttoXls";
            this.btnExporttoXls.Size = new System.Drawing.Size(116, 40);
            this.btnExporttoXls.TabIndex = 2;
            this.btnExporttoXls.Text = "Export to excel";
            this.btnExporttoXls.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExporttoXls.UseVisualStyleBackColor = true;
            this.btnExporttoXls.Click += new System.EventHandler(this.btnExporttoXls_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllEQPositionsToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 48);
            // 
            // resetAllEQPositionsToolStripMenuItem
            // 
            this.resetAllEQPositionsToolStripMenuItem.Name = "resetAllEQPositionsToolStripMenuItem";
            this.resetAllEQPositionsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.resetAllEQPositionsToolStripMenuItem.Text = "Reset All EQ Positions";
            this.resetAllEQPositionsToolStripMenuItem.Click += new System.EventHandler(this.resetAllEQPositionsToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // EquitiesHF2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "EquitiesHF2";
            this.Size = new System.Drawing.Size(1067, 641);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquities)).EndInit();
            this.grpEquities.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEquities;
        private System.Windows.Forms.GroupBox grpEquities;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUSDNotional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotional;
        private System.Windows.Forms.Button btnExporttoXls;
        private System.Windows.Forms.Button btnTransfertoHF2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetAllEQPositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}
