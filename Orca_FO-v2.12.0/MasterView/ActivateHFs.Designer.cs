
namespace Orca_FO_v2._12._0.MasterView
{
    partial class ActivateHFs
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
            this.dataGridHFs = new System.Windows.Forms.DataGridView();
            this.colEntityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPortfolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colisThisActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colModifiedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpActivateHFs = new System.Windows.Forms.GroupBox();
            this.btnEportToexcel = new System.Windows.Forms.Button();
            this.colActivateHFs = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHFs)).BeginInit();
            this.grpActivateHFs.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridHFs
            // 
            this.dataGridHFs.AllowUserToAddRows = false;
            this.dataGridHFs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridHFs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHFs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHFs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridHFs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHFs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEntityCode,
            this.colName,
            this.colPortfolio,
            this.colisThisActive,
            this.colModifiedOn});
            this.dataGridHFs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHFs.Location = new System.Drawing.Point(0, 59);
            this.dataGridHFs.Name = "dataGridHFs";
            this.dataGridHFs.Size = new System.Drawing.Size(966, 622);
            this.dataGridHFs.TabIndex = 0;
            // 
            // colEntityCode
            // 
            this.colEntityCode.DataPropertyName = "EntityCode";
            this.colEntityCode.HeaderText = "Entity Code";
            this.colEntityCode.Name = "colEntityCode";
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Entity Name";
            this.colName.Name = "colName";
            // 
            // colPortfolio
            // 
            this.colPortfolio.DataPropertyName = "Portfolio";
            this.colPortfolio.HeaderText = "Portfolio";
            this.colPortfolio.Name = "colPortfolio";
            // 
            // colisThisActive
            // 
            this.colisThisActive.DataPropertyName = "isThisActive";
            this.colisThisActive.HeaderText = "is This Active";
            this.colisThisActive.Name = "colisThisActive";
            this.colisThisActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colisThisActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colisThisActive.Width = 120;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            this.colModifiedOn.HeaderText = "Modified On";
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 622);
            this.panel1.TabIndex = 1;
            // 
            // grpActivateHFs
            // 
            this.grpActivateHFs.Controls.Add(this.btnEportToexcel);
            this.grpActivateHFs.Controls.Add(this.colActivateHFs);
            this.grpActivateHFs.Controls.Add(this.btnRefresh);
            this.grpActivateHFs.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActivateHFs.Location = new System.Drawing.Point(0, 0);
            this.grpActivateHFs.Name = "grpActivateHFs";
            this.grpActivateHFs.Size = new System.Drawing.Size(966, 59);
            this.grpActivateHFs.TabIndex = 2;
            this.grpActivateHFs.TabStop = false;
            // 
            // btnEportToexcel
            // 
            this.btnEportToexcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEportToexcel.Image = global::Orca_FO_v2._12._0.Properties.Resources.send;
            this.btnEportToexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEportToexcel.Location = new System.Drawing.Point(600, 16);
            this.btnEportToexcel.Name = "btnEportToexcel";
            this.btnEportToexcel.Size = new System.Drawing.Size(107, 40);
            this.btnEportToexcel.TabIndex = 2;
            this.btnEportToexcel.Text = "Export to excel";
            this.btnEportToexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEportToexcel.UseVisualStyleBackColor = true;
            this.btnEportToexcel.Click += new System.EventHandler(this.btnEportToexcel_Click);
            // 
            // colActivateHFs
            // 
            this.colActivateHFs.Dock = System.Windows.Forms.DockStyle.Right;
            this.colActivateHFs.Image = global::Orca_FO_v2._12._0.Properties.Resources.Update;
            this.colActivateHFs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.colActivateHFs.Location = new System.Drawing.Point(707, 16);
            this.colActivateHFs.Name = "colActivateHFs";
            this.colActivateHFs.Size = new System.Drawing.Size(181, 40);
            this.colActivateHFs.TabIndex = 1;
            this.colActivateHFs.Text = "Activate/Deactivate HF by PF";
            this.colActivateHFs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.colActivateHFs.UseVisualStyleBackColor = true;
            this.colActivateHFs.Click += new System.EventHandler(this.colActivateHFs_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(888, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ActivateHFs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridHFs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpActivateHFs);
            this.Name = "ActivateHFs";
            this.Size = new System.Drawing.Size(966, 681);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHFs)).EndInit();
            this.grpActivateHFs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridHFs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpActivateHFs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPortfolio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colisThisActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;
        private System.Windows.Forms.Button colActivateHFs;
        private System.Windows.Forms.Button btnEportToexcel;
    }
}
