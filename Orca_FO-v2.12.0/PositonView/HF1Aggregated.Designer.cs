
namespace Orca_FO_v2._12._0.PositonView
{
    partial class HF1Aggregated
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridHF1Aggregated = new System.Windows.Forms.DataGridView();
            this.grpboxHF2Aggregated = new System.Windows.Forms.GroupBox();
            this.btnExporttoexcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.colContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colinternal_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colric = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfContractsEMEA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfContractsAPAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colid_specific = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalNumberOfContracts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalMarketValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colextra_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvalue_ts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstrategy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHF1Aggregated)).BeginInit();
            this.grpboxHF2Aggregated.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridHF1Aggregated);
            this.panel1.Controls.Add(this.grpboxHF2Aggregated);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1169, 668);
            this.panel1.TabIndex = 0;
            // 
            // dataGridHF1Aggregated
            // 
            this.dataGridHF1Aggregated.AllowUserToAddRows = false;
            this.dataGridHF1Aggregated.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridHF1Aggregated.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHF1Aggregated.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHF1Aggregated.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridHF1Aggregated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHF1Aggregated.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContractId,
            this.colContractName,
            this.colinternal_code,
            this.colric,
            this.colAssetClass,
            this.colticker,
            this.colNumberOfContractsEMEA,
            this.colNumberOfContractsAPAC,
            this.colid_specific,
            this.colTotalNumberOfContracts,
            this.colTotalMarketValue,
            this.colcurrency,
            this.colextra_key,
            this.colvalue_ts,
            this.colstrategy});
            this.dataGridHF1Aggregated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHF1Aggregated.Location = new System.Drawing.Point(0, 59);
            this.dataGridHF1Aggregated.Name = "dataGridHF1Aggregated";
            this.dataGridHF1Aggregated.Size = new System.Drawing.Size(1169, 609);
            this.dataGridHF1Aggregated.TabIndex = 0;
            this.dataGridHF1Aggregated.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridHF1Aggregated_CellFormatting);
            // 
            // grpboxHF2Aggregated
            // 
            this.grpboxHF2Aggregated.Controls.Add(this.btnExporttoexcel);
            this.grpboxHF2Aggregated.Controls.Add(this.btnRefresh);
            this.grpboxHF2Aggregated.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpboxHF2Aggregated.Location = new System.Drawing.Point(0, 0);
            this.grpboxHF2Aggregated.Name = "grpboxHF2Aggregated";
            this.grpboxHF2Aggregated.Size = new System.Drawing.Size(1169, 59);
            this.grpboxHF2Aggregated.TabIndex = 1;
            this.grpboxHF2Aggregated.TabStop = false;
            // 
            // btnExporttoexcel
            // 
            this.btnExporttoexcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExporttoexcel.Image = global::Orca_FO_v2._12._0.Properties.Resources.send;
            this.btnExporttoexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExporttoexcel.Location = new System.Drawing.Point(981, 16);
            this.btnExporttoexcel.Name = "btnExporttoexcel";
            this.btnExporttoexcel.Size = new System.Drawing.Size(110, 40);
            this.btnExporttoexcel.TabIndex = 1;
            this.btnExporttoexcel.Text = "Export to Excel";
            this.btnExporttoexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExporttoexcel.UseVisualStyleBackColor = true;
            this.btnExporttoexcel.Click += new System.EventHandler(this.btnExporttoexcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1091, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // colContractId
            // 
            this.colContractId.DataPropertyName = "ContractId";
            this.colContractId.HeaderText = "Contract Id";
            this.colContractId.Name = "colContractId";
            this.colContractId.ReadOnly = true;
            // 
            // colContractName
            // 
            this.colContractName.DataPropertyName = "ContractName";
            this.colContractName.HeaderText = "Contract Name";
            this.colContractName.Name = "colContractName";
            this.colContractName.ReadOnly = true;
            this.colContractName.Width = 160;
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
            // colAssetClass
            // 
            this.colAssetClass.DataPropertyName = "AssetClass";
            this.colAssetClass.HeaderText = "Asset Class";
            this.colAssetClass.Name = "colAssetClass";
            this.colAssetClass.ReadOnly = true;
            // 
            // colticker
            // 
            this.colticker.DataPropertyName = "ticker";
            this.colticker.HeaderText = "Ticker BBG";
            this.colticker.Name = "colticker";
            this.colticker.ReadOnly = true;
            // 
            // colNumberOfContractsEMEA
            // 
            this.colNumberOfContractsEMEA.DataPropertyName = "NumberOfContractsEMEA";
            this.colNumberOfContractsEMEA.HeaderText = "Number of EMEA contracts";
            this.colNumberOfContractsEMEA.Name = "colNumberOfContractsEMEA";
            this.colNumberOfContractsEMEA.ReadOnly = true;
            this.colNumberOfContractsEMEA.Width = 200;
            // 
            // colNumberOfContractsAPAC
            // 
            this.colNumberOfContractsAPAC.DataPropertyName = "NumberOfContractsAPAC";
            this.colNumberOfContractsAPAC.HeaderText = "Number of APAC contracts";
            this.colNumberOfContractsAPAC.Name = "colNumberOfContractsAPAC";
            this.colNumberOfContractsAPAC.ReadOnly = true;
            this.colNumberOfContractsAPAC.Width = 200;
            // 
            // colid_specific
            // 
            this.colid_specific.DataPropertyName = "id_specific";
            this.colid_specific.HeaderText = "Id Specific";
            this.colid_specific.Name = "colid_specific";
            this.colid_specific.Visible = false;
            // 
            // colTotalNumberOfContracts
            // 
            this.colTotalNumberOfContracts.DataPropertyName = "TotalNumberOfContracts";
            this.colTotalNumberOfContracts.HeaderText = "Total number of Contracts";
            this.colTotalNumberOfContracts.Name = "colTotalNumberOfContracts";
            this.colTotalNumberOfContracts.ReadOnly = true;
            this.colTotalNumberOfContracts.Width = 200;
            // 
            // colTotalMarketValue
            // 
            this.colTotalMarketValue.DataPropertyName = "TotalMarketValue";
            this.colTotalMarketValue.HeaderText = "Total MV";
            this.colTotalMarketValue.Name = "colTotalMarketValue";
            this.colTotalMarketValue.ReadOnly = true;
            this.colTotalMarketValue.Width = 160;
            // 
            // colcurrency
            // 
            this.colcurrency.DataPropertyName = "currency";
            this.colcurrency.HeaderText = "Currency";
            this.colcurrency.Name = "colcurrency";
            this.colcurrency.ReadOnly = true;
            // 
            // colextra_key
            // 
            this.colextra_key.DataPropertyName = "extra_key";
            this.colextra_key.HeaderText = "Extra Key";
            this.colextra_key.Name = "colextra_key";
            this.colextra_key.Visible = false;
            // 
            // colvalue_ts
            // 
            this.colvalue_ts.DataPropertyName = "value_ts";
            this.colvalue_ts.HeaderText = "Time Stamp";
            this.colvalue_ts.Name = "colvalue_ts";
            this.colvalue_ts.Visible = false;
            // 
            // colstrategy
            // 
            this.colstrategy.DataPropertyName = "strategy";
            this.colstrategy.HeaderText = "Strategy";
            this.colstrategy.Name = "colstrategy";
            this.colstrategy.Visible = false;
            // 
            // HF1Aggregated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "HF1Aggregated";
            this.Size = new System.Drawing.Size(1169, 668);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHF1Aggregated)).EndInit();
            this.grpboxHF2Aggregated.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridHF1Aggregated;
        private System.Windows.Forms.GroupBox grpboxHF2Aggregated;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExporttoexcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colinternal_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn colric;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfContractsEMEA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfContractsAPAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid_specific;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalNumberOfContracts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalMarketValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colextra_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvalue_ts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstrategy;
    }
}
