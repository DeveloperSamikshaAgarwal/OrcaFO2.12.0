
namespace Orca_FO_v2._12._0.PositonView
{
    partial class EMEAPositions
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
            this.dataGridEMEA = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetAllEMEAPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpboxEMEA = new System.Windows.Forms.GroupBox();
            this.btnExporttoExcel = new System.Windows.Forms.Button();
            this.btnTransferToHF = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.colid_specific = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colextra_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvalue_ts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstrategy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colinternal_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colric = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltargetnotional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltarget_contracts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colref_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coladvisor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizeMultiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotionalMultiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coliThisActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEMEA)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.grpboxEMEA.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridEMEA
            // 
            this.dataGridEMEA.AllowUserToAddRows = false;
            this.dataGridEMEA.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridEMEA.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridEMEA.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridEMEA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridEMEA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEMEA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colid_specific,
            this.colextra_key,
            this.colvalue_ts,
            this.colstrategy,
            this.colinternal_code,
            this.colric,
            this.colticker,
            this.coltargetnotional,
            this.colcurrency,
            this.coltarget_contracts,
            this.colref_price,
            this.coladvisor_name,
            this.colContractId,
            this.colSizeMultiplier,
            this.colNotionalMultiplier,
            this.coliThisActive});
            this.dataGridEMEA.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridEMEA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEMEA.Location = new System.Drawing.Point(0, 59);
            this.dataGridEMEA.Name = "dataGridEMEA";
            this.dataGridEMEA.Size = new System.Drawing.Size(1253, 591);
            this.dataGridEMEA.TabIndex = 0;
            this.dataGridEMEA.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridEMEA_CellFormatting);
            this.dataGridEMEA.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEMEA_CellValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllEMEAPositionsToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 48);
            // 
            // resetAllEMEAPositionsToolStripMenuItem
            // 
            this.resetAllEMEAPositionsToolStripMenuItem.Name = "resetAllEMEAPositionsToolStripMenuItem";
            this.resetAllEMEAPositionsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.resetAllEMEAPositionsToolStripMenuItem.Text = "Reset All EMEA Positions";
            this.resetAllEMEAPositionsToolStripMenuItem.Click += new System.EventHandler(this.resetAllEMEAPositionsToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1253, 591);
            this.panel1.TabIndex = 1;
            // 
            // grpboxEMEA
            // 
            this.grpboxEMEA.Controls.Add(this.btnExporttoExcel);
            this.grpboxEMEA.Controls.Add(this.btnTransferToHF);
            this.grpboxEMEA.Controls.Add(this.button1);
            this.grpboxEMEA.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpboxEMEA.Location = new System.Drawing.Point(0, 0);
            this.grpboxEMEA.Name = "grpboxEMEA";
            this.grpboxEMEA.Size = new System.Drawing.Size(1253, 59);
            this.grpboxEMEA.TabIndex = 2;
            this.grpboxEMEA.TabStop = false;
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExporttoExcel.Image = global::Orca_FO_v2._12._0.Properties.Resources.send;
            this.btnExporttoExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExporttoExcel.Location = new System.Drawing.Point(913, 16);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(111, 40);
            this.btnExporttoExcel.TabIndex = 2;
            this.btnExporttoExcel.Text = "Export to excel";
            this.btnExporttoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExporttoExcel.UseVisualStyleBackColor = true;
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // btnTransferToHF
            // 
            this.btnTransferToHF.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTransferToHF.Image = global::Orca_FO_v2._12._0.Properties.Resources.transfer;
            this.btnTransferToHF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransferToHF.Location = new System.Drawing.Point(1024, 16);
            this.btnTransferToHF.Name = "btnTransferToHF";
            this.btnTransferToHF.Size = new System.Drawing.Size(151, 40);
            this.btnTransferToHF.TabIndex = 1;
            this.btnTransferToHF.Text = "Transfer to Hedge Fund";
            this.btnTransferToHF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransferToHF.UseVisualStyleBackColor = true;
            this.btnTransferToHF.Click += new System.EventHandler(this.btnTransferToHF_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1175, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Refresh";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // colid_specific
            // 
            this.colid_specific.DataPropertyName = "id_specific";
            this.colid_specific.HeaderText = "Id specific";
            this.colid_specific.Name = "colid_specific";
            this.colid_specific.ReadOnly = true;
            // 
            // colextra_key
            // 
            this.colextra_key.DataPropertyName = "extra_key";
            this.colextra_key.HeaderText = "Extra Key";
            this.colextra_key.Name = "colextra_key";
            this.colextra_key.ReadOnly = true;
            // 
            // colvalue_ts
            // 
            this.colvalue_ts.DataPropertyName = "value_ts";
            this.colvalue_ts.HeaderText = "Time Stamp";
            this.colvalue_ts.Name = "colvalue_ts";
            this.colvalue_ts.ReadOnly = true;
            this.colvalue_ts.Width = 180;
            // 
            // colstrategy
            // 
            this.colstrategy.DataPropertyName = "strategy";
            this.colstrategy.HeaderText = "Strategy";
            this.colstrategy.Name = "colstrategy";
            this.colstrategy.ReadOnly = true;
            // 
            // colinternal_code
            // 
            this.colinternal_code.DataPropertyName = "internal_code";
            this.colinternal_code.HeaderText = "Internal Code";
            this.colinternal_code.Name = "colinternal_code";
            this.colinternal_code.ReadOnly = true;
            this.colinternal_code.Width = 150;
            // 
            // colric
            // 
            this.colric.DataPropertyName = "ric";
            this.colric.HeaderText = "RIC";
            this.colric.Name = "colric";
            this.colric.ReadOnly = true;
            // 
            // colticker
            // 
            this.colticker.DataPropertyName = "ticker";
            this.colticker.HeaderText = "Ticker BBG";
            this.colticker.Name = "colticker";
            this.colticker.ReadOnly = true;
            // 
            // coltargetnotional
            // 
            this.coltargetnotional.DataPropertyName = "target_notional";
            this.coltargetnotional.HeaderText = "Target Notional";
            this.coltargetnotional.Name = "coltargetnotional";
            this.coltargetnotional.ReadOnly = true;
            this.coltargetnotional.Width = 160;
            // 
            // colcurrency
            // 
            this.colcurrency.DataPropertyName = "currency";
            this.colcurrency.HeaderText = "Currency";
            this.colcurrency.Name = "colcurrency";
            this.colcurrency.ReadOnly = true;
            // 
            // coltarget_contracts
            // 
            this.coltarget_contracts.DataPropertyName = "target_contracts";
            this.coltarget_contracts.HeaderText = "Target Contracts";
            this.coltarget_contracts.Name = "coltarget_contracts";
            this.coltarget_contracts.Width = 160;
            // 
            // colref_price
            // 
            this.colref_price.DataPropertyName = "ref_price";
            this.colref_price.HeaderText = "Average Price";
            this.colref_price.Name = "colref_price";
            this.colref_price.Width = 160;
            // 
            // coladvisor_name
            // 
            this.coladvisor_name.DataPropertyName = "advisor_name";
            this.coladvisor_name.HeaderText = "Advisor Name";
            this.coladvisor_name.Name = "coladvisor_name";
            this.coladvisor_name.ReadOnly = true;
            this.coladvisor_name.Width = 150;
            // 
            // colContractId
            // 
            this.colContractId.DataPropertyName = "ContractId";
            this.colContractId.HeaderText = "Contract Id";
            this.colContractId.Name = "colContractId";
            this.colContractId.Visible = false;
            // 
            // colSizeMultiplier
            // 
            this.colSizeMultiplier.DataPropertyName = "SizeMultiplier";
            this.colSizeMultiplier.HeaderText = "Size Multiplier";
            this.colSizeMultiplier.Name = "colSizeMultiplier";
            this.colSizeMultiplier.Visible = false;
            // 
            // colNotionalMultiplier
            // 
            this.colNotionalMultiplier.DataPropertyName = "NotionalMultiplier";
            this.colNotionalMultiplier.HeaderText = "Notional Multiplier";
            this.colNotionalMultiplier.Name = "colNotionalMultiplier";
            this.colNotionalMultiplier.Visible = false;
            // 
            // coliThisActive
            // 
            this.coliThisActive.DataPropertyName = "isThisActive";
            this.coliThisActive.HeaderText = "isThis Active";
            this.coliThisActive.Name = "coliThisActive";
            this.coliThisActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.coliThisActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.coliThisActive.Width = 150;
            // 
            // EMEAPositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridEMEA);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpboxEMEA);
            this.Name = "EMEAPositions";
            this.Size = new System.Drawing.Size(1253, 650);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEMEA)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.grpboxEMEA.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridEMEA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpboxEMEA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTransferToHF;
        private System.Windows.Forms.Button btnExporttoExcel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetAllEMEAPositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid_specific;
        private System.Windows.Forms.DataGridViewTextBoxColumn colextra_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvalue_ts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstrategy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colinternal_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn colric;
        private System.Windows.Forms.DataGridViewTextBoxColumn colticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltargetnotional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltarget_contracts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colref_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn coladvisor_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizeMultiplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotionalMultiplier;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coliThisActive;
    }
}
