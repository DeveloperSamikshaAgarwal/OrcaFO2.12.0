
namespace Orca_FO_v2._12._0.Configurations
{
    partial class ApplicationConfiguration
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
            this.dataGridAppConfig = new System.Windows.Forms.DataGridView();
            this.grpAppConfig = new System.Windows.Forms.GroupBox();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAppConfig)).BeginInit();
            this.grpAppConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridAppConfig);
            this.panel1.Controls.Add(this.grpAppConfig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 736);
            this.panel1.TabIndex = 0;
            // 
            // dataGridAppConfig
            // 
            this.dataGridAppConfig.AllowUserToAddRows = false;
            this.dataGridAppConfig.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridAppConfig.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridAppConfig.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAppConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridAppConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAppConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colid,
            this.colCategory,
            this.colAppkey,
            this.colAppValue,
            this.colModifiedOn});
            this.dataGridAppConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAppConfig.Location = new System.Drawing.Point(0, 59);
            this.dataGridAppConfig.Name = "dataGridAppConfig";
            this.dataGridAppConfig.Size = new System.Drawing.Size(1116, 677);
            this.dataGridAppConfig.TabIndex = 0;
            // 
            // grpAppConfig
            // 
            this.grpAppConfig.Controls.Add(this.btnRefresh);
            this.grpAppConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAppConfig.Location = new System.Drawing.Point(0, 0);
            this.grpAppConfig.Name = "grpAppConfig";
            this.grpAppConfig.Size = new System.Drawing.Size(1116, 59);
            this.grpAppConfig.TabIndex = 1;
            this.grpAppConfig.TabStop = false;
            // 
            // colid
            // 
            this.colid.DataPropertyName = "id";
            this.colid.HeaderText = "Id";
            this.colid.Name = "colid";
            this.colid.Width = 80;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "Category";
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.Width = 120;
            // 
            // colAppkey
            // 
            this.colAppkey.DataPropertyName = "Appkey";
            this.colAppkey.HeaderText = "App Key";
            this.colAppkey.Name = "colAppkey";
            this.colAppkey.Width = 180;
            // 
            // colAppValue
            // 
            this.colAppValue.DataPropertyName = "AppValue";
            this.colAppValue.HeaderText = "App Value";
            this.colAppValue.Name = "colAppValue";
            this.colAppValue.Width = 500;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            this.colModifiedOn.HeaderText = "Modified On";
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.Width = 150;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1035, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ApplicationConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ApplicationConfiguration";
            this.Size = new System.Drawing.Size(1116, 736);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAppConfig)).EndInit();
            this.grpAppConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridAppConfig;
        private System.Windows.Forms.GroupBox grpAppConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;
        private System.Windows.Forms.Button btnRefresh;
    }
}
