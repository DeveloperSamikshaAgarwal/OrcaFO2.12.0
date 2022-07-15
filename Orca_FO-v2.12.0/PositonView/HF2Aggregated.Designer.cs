
namespace Orca_FO_v2._12._0.PositonView
{
    partial class HF2Aggregated
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
            this.dataGridHF2Aggregated = new System.Windows.Forms.DataGridView();
            this.grpboxforFX1grid = new System.Windows.Forms.GroupBox();
            this.btnExporttoexcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.colContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUSDNotional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHF2Aggregated)).BeginInit();
            this.grpboxforFX1grid.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridHF2Aggregated);
            this.panel1.Controls.Add(this.grpboxforFX1grid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1226, 648);
            this.panel1.TabIndex = 0;
            // 
            // dataGridHF2Aggregated
            // 
            this.dataGridHF2Aggregated.AllowUserToAddRows = false;
            this.dataGridHF2Aggregated.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridHF2Aggregated.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHF2Aggregated.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHF2Aggregated.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridHF2Aggregated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHF2Aggregated.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContractName,
            this.colLots,
            this.colPrices,
            this.colUSDNotional,
            this.colNotional,
            this.colModifiedOn});
            this.dataGridHF2Aggregated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHF2Aggregated.Location = new System.Drawing.Point(0, 59);
            this.dataGridHF2Aggregated.Name = "dataGridHF2Aggregated";
            this.dataGridHF2Aggregated.Size = new System.Drawing.Size(1226, 589);
            this.dataGridHF2Aggregated.TabIndex = 0;
            this.dataGridHF2Aggregated.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridHF2Aggregated_CellFormatting);
            // 
            // grpboxforFX1grid
            // 
            this.grpboxforFX1grid.Controls.Add(this.btnExporttoexcel);
            this.grpboxforFX1grid.Controls.Add(this.btnRefresh);
            this.grpboxforFX1grid.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpboxforFX1grid.Location = new System.Drawing.Point(0, 0);
            this.grpboxforFX1grid.Name = "grpboxforFX1grid";
            this.grpboxforFX1grid.Size = new System.Drawing.Size(1226, 59);
            this.grpboxforFX1grid.TabIndex = 1;
            this.grpboxforFX1grid.TabStop = false;
            // 
            // btnExporttoexcel
            // 
            this.btnExporttoexcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExporttoexcel.Image = global::Orca_FO_v2._12._0.Properties.Resources.send;
            this.btnExporttoexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExporttoexcel.Location = new System.Drawing.Point(1031, 16);
            this.btnExporttoexcel.Name = "btnExporttoexcel";
            this.btnExporttoexcel.Size = new System.Drawing.Size(113, 40);
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
            this.btnRefresh.Location = new System.Drawing.Point(1144, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(79, 40);
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
            // colLots
            // 
            this.colLots.DataPropertyName = "Lots";
            this.colLots.HeaderText = "Number of Contracts";
            this.colLots.Name = "colLots";
            this.colLots.ReadOnly = true;
            this.colLots.Width = 180;
            // 
            // colPrices
            // 
            this.colPrices.DataPropertyName = "Prices";
            this.colPrices.HeaderText = "Prices";
            this.colPrices.Name = "colPrices";
            this.colPrices.ReadOnly = true;
            this.colPrices.Width = 180;
            // 
            // colUSDNotional
            // 
            this.colUSDNotional.DataPropertyName = "USDNotional";
            this.colUSDNotional.HeaderText = "Notional(USD)";
            this.colUSDNotional.Name = "colUSDNotional";
            this.colUSDNotional.ReadOnly = true;
            this.colUSDNotional.Width = 200;
            // 
            // colNotional
            // 
            this.colNotional.DataPropertyName = "Notional";
            this.colNotional.HeaderText = "Notional";
            this.colNotional.Name = "colNotional";
            this.colNotional.ReadOnly = true;
            this.colNotional.Width = 200;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            this.colModifiedOn.HeaderText = "Modified On";
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.ReadOnly = true;
            this.colModifiedOn.Width = 200;
            // 
            // HF2Aggregated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "HF2Aggregated";
            this.Size = new System.Drawing.Size(1226, 648);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHF2Aggregated)).EndInit();
            this.grpboxforFX1grid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridHF2Aggregated;
        private System.Windows.Forms.GroupBox grpboxforFX1grid;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExporttoexcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrices;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUSDNotional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;
    }
}
