
namespace Orca_FO_v2._12._0.PositonView
{
    partial class FX1
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
            this.dataGridFX1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetAllFXPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpboxFX1 = new System.Windows.Forms.GroupBox();
            this.btnExporttoExcel = new System.Windows.Forms.Button();
            this.btnTransfertoHF2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.colContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUSDNotional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmodelname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltargetmaxpos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.grpboxFX1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridFX1);
            this.panel1.Controls.Add(this.grpboxFX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 715);
            this.panel1.TabIndex = 0;
            // 
            // dataGridFX1
            // 
            this.dataGridFX1.AllowUserToAddRows = false;
            this.dataGridFX1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridFX1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridFX1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridFX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContractName,
            this.colUSDNotional,
            this.colNotional,
            this.colmodelname,
            this.coltargetmaxpos});
            this.dataGridFX1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridFX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridFX1.Location = new System.Drawing.Point(0, 59);
            this.dataGridFX1.Name = "dataGridFX1";
            this.dataGridFX1.Size = new System.Drawing.Size(992, 656);
            this.dataGridFX1.TabIndex = 0;
            this.dataGridFX1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridFX1_CellFormatting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllFXPositionsToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 48);
            // 
            // resetAllFXPositionsToolStripMenuItem
            // 
            this.resetAllFXPositionsToolStripMenuItem.Name = "resetAllFXPositionsToolStripMenuItem";
            this.resetAllFXPositionsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.resetAllFXPositionsToolStripMenuItem.Text = "Reset All FX Positions";
            this.resetAllFXPositionsToolStripMenuItem.Click += new System.EventHandler(this.resetAllFXPositionsToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // grpboxFX1
            // 
            this.grpboxFX1.Controls.Add(this.btnExporttoExcel);
            this.grpboxFX1.Controls.Add(this.btnTransfertoHF2);
            this.grpboxFX1.Controls.Add(this.button1);
            this.grpboxFX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpboxFX1.Location = new System.Drawing.Point(0, 0);
            this.grpboxFX1.Name = "grpboxFX1";
            this.grpboxFX1.Size = new System.Drawing.Size(992, 59);
            this.grpboxFX1.TabIndex = 1;
            this.grpboxFX1.TabStop = false;
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExporttoExcel.Image = global::Orca_FO_v2._12._0.Properties.Resources.send;
            this.btnExporttoExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExporttoExcel.Location = new System.Drawing.Point(645, 16);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(113, 40);
            this.btnExporttoExcel.TabIndex = 2;
            this.btnExporttoExcel.Text = "Export to Excel";
            this.btnExporttoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExporttoExcel.UseVisualStyleBackColor = true;
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // btnTransfertoHF2
            // 
            this.btnTransfertoHF2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTransfertoHF2.Image = global::Orca_FO_v2._12._0.Properties.Resources.transfer;
            this.btnTransfertoHF2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransfertoHF2.Location = new System.Drawing.Point(758, 16);
            this.btnTransfertoHF2.Name = "btnTransfertoHF2";
            this.btnTransfertoHF2.Size = new System.Drawing.Size(156, 40);
            this.btnTransfertoHF2.TabIndex = 1;
            this.btnTransfertoHF2.Text = "Transfer to Hedge Fund";
            this.btnTransfertoHF2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransfertoHF2.UseVisualStyleBackColor = true;
            this.btnTransfertoHF2.Click += new System.EventHandler(this.btnTransfertoHF2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(914, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Refresh";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.colmodelname.HeaderText = "Model Name";
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
            // FX1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FX1";
            this.Size = new System.Drawing.Size(992, 715);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.grpboxFX1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridFX1;
        private System.Windows.Forms.GroupBox grpboxFX1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTransfertoHF2;
        private System.Windows.Forms.Button btnExporttoExcel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetAllFXPositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUSDNotional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmodelname;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltargetmaxpos;
    }
}
