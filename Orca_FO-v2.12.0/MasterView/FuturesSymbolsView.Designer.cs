
namespace Orca_FO_v2._12._0.MasterView
{
    partial class FuturesSymbolsView
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
            this.dgridFuturesSymbolsView = new System.Windows.Forms.DataGridView();
            this.colContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHFPrefrences = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExchange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBBGName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTickerBBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInternalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContractMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizeMultiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpboxFutSym = new System.Windows.Forms.GroupBox();
            this.btnExporttoExcel = new System.Windows.Forms.Button();
            this.btnRollOver = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridFuturesSymbolsView)).BeginInit();
            this.grpboxFutSym.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgridFuturesSymbolsView);
            this.panel1.Controls.Add(this.grpboxFutSym);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 704);
            this.panel1.TabIndex = 0;
            // 
            // dgridFuturesSymbolsView
            // 
            this.dgridFuturesSymbolsView.AllowUserToAddRows = false;
            this.dgridFuturesSymbolsView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgridFuturesSymbolsView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridFuturesSymbolsView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridFuturesSymbolsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgridFuturesSymbolsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridFuturesSymbolsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContractId,
            this.colContractName,
            this.colHFPrefrences,
            this.colAssetClass,
            this.colExchange,
            this.colBBGName,
            this.colTickerBBG,
            this.colRIC,
            this.colInternalCode,
            this.colContractMonth,
            this.colSizeMultiplier,
            this.colModifiedOn});
            this.dgridFuturesSymbolsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgridFuturesSymbolsView.Location = new System.Drawing.Point(0, 59);
            this.dgridFuturesSymbolsView.Margin = new System.Windows.Forms.Padding(0);
            this.dgridFuturesSymbolsView.Name = "dgridFuturesSymbolsView";
            this.dgridFuturesSymbolsView.ReadOnly = true;
            this.dgridFuturesSymbolsView.Size = new System.Drawing.Size(1097, 645);
            this.dgridFuturesSymbolsView.TabIndex = 0;
            // 
            // colContractId
            // 
            this.colContractId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContractId.DataPropertyName = "ContractId";
            this.colContractId.HeaderText = "Contract Id";
            this.colContractId.Name = "colContractId";
            this.colContractId.ReadOnly = true;
            // 
            // colContractName
            // 
            this.colContractName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContractName.DataPropertyName = "ContractName";
            this.colContractName.HeaderText = "Contract Name";
            this.colContractName.Name = "colContractName";
            this.colContractName.ReadOnly = true;
            // 
            // colHFPrefrences
            // 
            this.colHFPrefrences.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHFPrefrences.DataPropertyName = "HFPreference";
            this.colHFPrefrences.HeaderText = "HF Prefrence";
            this.colHFPrefrences.Name = "colHFPrefrences";
            this.colHFPrefrences.ReadOnly = true;
            // 
            // colAssetClass
            // 
            this.colAssetClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAssetClass.DataPropertyName = "AssetClass";
            this.colAssetClass.HeaderText = "Asset Class";
            this.colAssetClass.Name = "colAssetClass";
            this.colAssetClass.ReadOnly = true;
            // 
            // colExchange
            // 
            this.colExchange.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colExchange.DataPropertyName = "Exchange";
            this.colExchange.HeaderText = "Exchange";
            this.colExchange.Name = "colExchange";
            this.colExchange.ReadOnly = true;
            // 
            // colBBGName
            // 
            this.colBBGName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBBGName.DataPropertyName = "BBGName";
            this.colBBGName.HeaderText = "BBG Name";
            this.colBBGName.Name = "colBBGName";
            this.colBBGName.ReadOnly = true;
            // 
            // colTickerBBG
            // 
            this.colTickerBBG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTickerBBG.DataPropertyName = "TickerBBG";
            this.colTickerBBG.HeaderText = "TickerBBG";
            this.colTickerBBG.Name = "colTickerBBG";
            this.colTickerBBG.ReadOnly = true;
            // 
            // colRIC
            // 
            this.colRIC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRIC.DataPropertyName = "RIC";
            this.colRIC.HeaderText = "RIC";
            this.colRIC.Name = "colRIC";
            this.colRIC.ReadOnly = true;
            // 
            // colInternalCode
            // 
            this.colInternalCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInternalCode.DataPropertyName = "InternalCode";
            this.colInternalCode.HeaderText = "Internal Code";
            this.colInternalCode.Name = "colInternalCode";
            this.colInternalCode.ReadOnly = true;
            // 
            // colContractMonth
            // 
            this.colContractMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContractMonth.DataPropertyName = "CurrentMonthTraded";
            this.colContractMonth.HeaderText = "Current Month Traded";
            this.colContractMonth.Name = "colContractMonth";
            this.colContractMonth.ReadOnly = true;
            // 
            // colSizeMultiplier
            // 
            this.colSizeMultiplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSizeMultiplier.DataPropertyName = "SizeMultiplier";
            this.colSizeMultiplier.HeaderText = "Size Multiplier";
            this.colSizeMultiplier.Name = "colSizeMultiplier";
            this.colSizeMultiplier.ReadOnly = true;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            this.colModifiedOn.HeaderText = "Modified On";
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.ReadOnly = true;
            // 
            // grpboxFutSym
            // 
            this.grpboxFutSym.Controls.Add(this.btnExporttoExcel);
            this.grpboxFutSym.Controls.Add(this.btnRollOver);
            this.grpboxFutSym.Controls.Add(this.btnRefresh);
            this.grpboxFutSym.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpboxFutSym.Location = new System.Drawing.Point(0, 0);
            this.grpboxFutSym.Name = "grpboxFutSym";
            this.grpboxFutSym.Size = new System.Drawing.Size(1097, 59);
            this.grpboxFutSym.TabIndex = 1;
            this.grpboxFutSym.TabStop = false;
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExporttoExcel.Image = global::Orca_FO_v2._12._0.Properties.Resources.send;
            this.btnExporttoExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExporttoExcel.Location = new System.Drawing.Point(823, 16);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(108, 40);
            this.btnExporttoExcel.TabIndex = 2;
            this.btnExporttoExcel.Text = "Export to excel";
            this.btnExporttoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExporttoExcel.UseVisualStyleBackColor = true;
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // btnRollOver
            // 
            this.btnRollOver.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRollOver.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh;
            this.btnRollOver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRollOver.Location = new System.Drawing.Point(931, 16);
            this.btnRollOver.Name = "btnRollOver";
            this.btnRollOver.Size = new System.Drawing.Size(85, 40);
            this.btnRollOver.TabIndex = 1;
            this.btnRollOver.Text = "Roll Over";
            this.btnRollOver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRollOver.UseVisualStyleBackColor = true;
            this.btnRollOver.Click += new System.EventHandler(this.btnRollOver_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1016, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FuturesSymbolsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FuturesSymbolsView";
            this.Size = new System.Drawing.Size(1097, 704);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridFuturesSymbolsView)).EndInit();
            this.grpboxFutSym.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgridFuturesSymbolsView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.GroupBox grpboxFutSym;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFPrefrences;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExchange;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBBGName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTickerBBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInternalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizeMultiplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;
        private System.Windows.Forms.Button btnRollOver;
        private System.Windows.Forms.Button btnExporttoExcel;
    }
}
