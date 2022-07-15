
namespace Orca_FO_v2._12._0.Configurations
{
    partial class LimitConfigurations
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
            this.dataGridLimitConfig = new System.Windows.Forms.DataGridView();
            this.grpboxLimitConfig = new System.Windows.Forms.GroupBox();
            this.colContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHFPreferences = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSavePriority = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLimitConfig)).BeginInit();
            this.grpboxLimitConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridLimitConfig);
            this.panel1.Controls.Add(this.grpboxLimitConfig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1114, 660);
            this.panel1.TabIndex = 0;
            // 
            // dataGridLimitConfig
            // 
            this.dataGridLimitConfig.AllowUserToAddRows = false;
            this.dataGridLimitConfig.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridLimitConfig.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridLimitConfig.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridLimitConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridLimitConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLimitConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContractId,
            this.colContractName,
            this.colAssetClass,
            this.colHFPreferences});
            this.dataGridLimitConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLimitConfig.Location = new System.Drawing.Point(0, 59);
            this.dataGridLimitConfig.Name = "dataGridLimitConfig";
            this.dataGridLimitConfig.Size = new System.Drawing.Size(1114, 601);
            this.dataGridLimitConfig.TabIndex = 0;
            // 
            // grpboxLimitConfig
            // 
            this.grpboxLimitConfig.Controls.Add(this.btnSavePriority);
            this.grpboxLimitConfig.Controls.Add(this.btnRefresh);
            this.grpboxLimitConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpboxLimitConfig.Location = new System.Drawing.Point(0, 0);
            this.grpboxLimitConfig.Name = "grpboxLimitConfig";
            this.grpboxLimitConfig.Size = new System.Drawing.Size(1114, 59);
            this.grpboxLimitConfig.TabIndex = 1;
            this.grpboxLimitConfig.TabStop = false;
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
            this.colContractName.Width = 150;
            // 
            // colAssetClass
            // 
            this.colAssetClass.DataPropertyName = "AssetClass";
            this.colAssetClass.HeaderText = "Asset Class";
            this.colAssetClass.Name = "colAssetClass";
            this.colAssetClass.ReadOnly = true;
            // 
            // colHFPreferences
            // 
            this.colHFPreferences.DataPropertyName = "HFPreference";
            this.colHFPreferences.HeaderText = "HF Preferences";
            this.colHFPreferences.Name = "colHFPreferences";
            this.colHFPreferences.Width = 150;
            // 
            // btnSavePriority
            // 
            this.btnSavePriority.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSavePriority.Image = global::Orca_FO_v2._12._0.Properties.Resources.download;
            this.btnSavePriority.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePriority.Location = new System.Drawing.Point(939, 16);
            this.btnSavePriority.Name = "btnSavePriority";
            this.btnSavePriority.Size = new System.Drawing.Size(97, 40);
            this.btnSavePriority.TabIndex = 1;
            this.btnSavePriority.Text = "Save Priority";
            this.btnSavePriority.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSavePriority.UseVisualStyleBackColor = true;
            this.btnSavePriority.Click += new System.EventHandler(this.btnSavePriority_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1036, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // LimitConfigurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LimitConfigurations";
            this.Size = new System.Drawing.Size(1114, 660);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLimitConfig)).EndInit();
            this.grpboxLimitConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridLimitConfig;
        private System.Windows.Forms.GroupBox grpboxLimitConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFPreferences;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSavePriority;
    }
}
