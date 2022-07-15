
namespace Orca_FO_v2._12._0.MasterView
{
    partial class NotionalMultiplier
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
            this.dataGridNotMul = new System.Windows.Forms.DataGridView();
            this.colContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotionalMultiplierHF1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotionalMultiplierHF2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpboxNotional = new System.Windows.Forms.GroupBox();
            this.btnExporttoexcel = new System.Windows.Forms.Button();
            this.btnUpdateNotionalMultiplier = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotMul)).BeginInit();
            this.grpboxNotional.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridNotMul);
            this.panel1.Controls.Add(this.grpboxNotional);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1411, 742);
            this.panel1.TabIndex = 0;
            // 
            // dataGridNotMul
            // 
            this.dataGridNotMul.AllowUserToAddRows = false;
            this.dataGridNotMul.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridNotMul.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridNotMul.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridNotMul.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridNotMul.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNotMul.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContractName,
            this.colNotionalMultiplierHF1,
            this.colNotionalMultiplierHF2});
            this.dataGridNotMul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridNotMul.Location = new System.Drawing.Point(0, 59);
            this.dataGridNotMul.Name = "dataGridNotMul";
            this.dataGridNotMul.Size = new System.Drawing.Size(1411, 683);
            this.dataGridNotMul.TabIndex = 0;
            // 
            // colContractName
            // 
            this.colContractName.DataPropertyName = "ContractName";
            this.colContractName.HeaderText = "Contract Name";
            this.colContractName.Name = "colContractName";
            this.colContractName.ReadOnly = true;
            this.colContractName.Width = 130;
            // 
            // colNotionalMultiplierHF1
            // 
            this.colNotionalMultiplierHF1.DataPropertyName = "NotionalMultiplierHF1";
            this.colNotionalMultiplierHF1.HeaderText = "Notional Multiplier HF1";
            this.colNotionalMultiplierHF1.Name = "colNotionalMultiplierHF1";
            this.colNotionalMultiplierHF1.Width = 160;
            // 
            // colNotionalMultiplierHF2
            // 
            this.colNotionalMultiplierHF2.DataPropertyName = "NotionalMultiplierHF2";
            this.colNotionalMultiplierHF2.HeaderText = "Notional Multiplier HF2";
            this.colNotionalMultiplierHF2.Name = "colNotionalMultiplierHF2";
            this.colNotionalMultiplierHF2.Width = 160;
            // 
            // grpboxNotional
            // 
            this.grpboxNotional.Controls.Add(this.btnExporttoexcel);
            this.grpboxNotional.Controls.Add(this.btnUpdateNotionalMultiplier);
            this.grpboxNotional.Controls.Add(this.btnRefresh);
            this.grpboxNotional.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpboxNotional.Location = new System.Drawing.Point(0, 0);
            this.grpboxNotional.Name = "grpboxNotional";
            this.grpboxNotional.Size = new System.Drawing.Size(1411, 59);
            this.grpboxNotional.TabIndex = 1;
            this.grpboxNotional.TabStop = false;
            // 
            // btnExporttoexcel
            // 
            this.btnExporttoexcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExporttoexcel.Image = global::Orca_FO_v2._12._0.Properties.Resources.send;
            this.btnExporttoexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExporttoexcel.Location = new System.Drawing.Point(1065, 16);
            this.btnExporttoexcel.Name = "btnExporttoexcel";
            this.btnExporttoexcel.Size = new System.Drawing.Size(108, 40);
            this.btnExporttoexcel.TabIndex = 2;
            this.btnExporttoexcel.Text = "Export to excel";
            this.btnExporttoexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExporttoexcel.UseVisualStyleBackColor = true;
            this.btnExporttoexcel.Click += new System.EventHandler(this.btnExporttoexcel_Click);
            // 
            // btnUpdateNotionalMultiplier
            // 
            this.btnUpdateNotionalMultiplier.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUpdateNotionalMultiplier.Image = global::Orca_FO_v2._12._0.Properties.Resources.Update;
            this.btnUpdateNotionalMultiplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateNotionalMultiplier.Location = new System.Drawing.Point(1173, 16);
            this.btnUpdateNotionalMultiplier.Name = "btnUpdateNotionalMultiplier";
            this.btnUpdateNotionalMultiplier.Size = new System.Drawing.Size(160, 40);
            this.btnUpdateNotionalMultiplier.TabIndex = 1;
            this.btnUpdateNotionalMultiplier.Text = "Update Notional Multiplier";
            this.btnUpdateNotionalMultiplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateNotionalMultiplier.UseVisualStyleBackColor = true;
            this.btnUpdateNotionalMultiplier.Click += new System.EventHandler(this.btnUpdateNotionalMultiplier_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1333, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // NotionalMultiplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "NotionalMultiplier";
            this.Size = new System.Drawing.Size(1411, 742);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotMul)).EndInit();
            this.grpboxNotional.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridNotMul;
        private System.Windows.Forms.GroupBox grpboxNotional;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotionalMultiplierHF1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotionalMultiplierHF2;
        private System.Windows.Forms.Button btnUpdateNotionalMultiplier;
        private System.Windows.Forms.Button btnExporttoexcel;
    }
}
