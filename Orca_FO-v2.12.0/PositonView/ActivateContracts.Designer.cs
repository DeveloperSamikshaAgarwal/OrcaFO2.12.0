
namespace Orca_FO_v2._12._0.PositonView
{
    partial class ActivateContracts
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
            this.dataGridActivateContracts = new System.Windows.Forms.DataGridView();
            this.colEntityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRootContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToBePublished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colModifiedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpboxActivateContracts = new System.Windows.Forms.GroupBox();
            this.btnActivated = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActivateContracts)).BeginInit();
            this.grpboxActivateContracts.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridActivateContracts);
            this.panel1.Controls.Add(this.grpboxActivateContracts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 641);
            this.panel1.TabIndex = 0;
            // 
            // dataGridActivateContracts
            // 
            this.dataGridActivateContracts.AllowUserToAddRows = false;
            this.dataGridActivateContracts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridActivateContracts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridActivateContracts.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridActivateContracts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridActivateContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridActivateContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEntityCode,
            this.colEntityName,
            this.colRootContract,
            this.colToBePublished,
            this.colModifiedOn});
            this.dataGridActivateContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridActivateContracts.Location = new System.Drawing.Point(0, 59);
            this.dataGridActivateContracts.Name = "dataGridActivateContracts";
            this.dataGridActivateContracts.Size = new System.Drawing.Size(1327, 582);
            this.dataGridActivateContracts.TabIndex = 0;
           // this.dataGridActivateContracts.SelectionChanged += new System.EventHandler(this.dataGridActivateContracts_SelectionChanged);
            // 
            // colEntityCode
            // 
            this.colEntityCode.DataPropertyName = "EntityCode";
            this.colEntityCode.HeaderText = "Entity Code";
            this.colEntityCode.Name = "colEntityCode";
            this.colEntityCode.ReadOnly = true;
            // 
            // colEntityName
            // 
            this.colEntityName.DataPropertyName = "Name";
            this.colEntityName.HeaderText = "Entity Name";
            this.colEntityName.Name = "colEntityName";
            this.colEntityName.ReadOnly = true;
            // 
            // colRootContract
            // 
            this.colRootContract.DataPropertyName = "RootContract";
            this.colRootContract.HeaderText = "Root Contract";
            this.colRootContract.Name = "colRootContract";
            this.colRootContract.ReadOnly = true;
            this.colRootContract.Width = 120;
            // 
            // colToBePublished
            // 
            this.colToBePublished.DataPropertyName = "ToBePublished";
            this.colToBePublished.HeaderText = "To Be Published";
            this.colToBePublished.Name = "colToBePublished";
            this.colToBePublished.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colToBePublished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colToBePublished.Width = 150;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            this.colModifiedOn.HeaderText = "Modified On";
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.ReadOnly = true;
            // 
            // grpboxActivateContracts
            // 
            this.grpboxActivateContracts.Controls.Add(this.btnActivated);
            this.grpboxActivateContracts.Controls.Add(this.btnRefresh);
            this.grpboxActivateContracts.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpboxActivateContracts.Location = new System.Drawing.Point(0, 0);
            this.grpboxActivateContracts.Name = "grpboxActivateContracts";
            this.grpboxActivateContracts.Size = new System.Drawing.Size(1327, 59);
            this.grpboxActivateContracts.TabIndex = 1;
            this.grpboxActivateContracts.TabStop = false;
            // 
            // btnActivated
            // 
            this.btnActivated.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnActivated.Image = global::Orca_FO_v2._12._0.Properties.Resources.Update;
            this.btnActivated.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivated.Location = new System.Drawing.Point(1064, 16);
            this.btnActivated.Name = "btnActivated";
            this.btnActivated.Size = new System.Drawing.Size(185, 40);
            this.btnActivated.TabIndex = 1;
            this.btnActivated.Text = "Activate/Deactivate Contracts";
            this.btnActivated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActivated.UseVisualStyleBackColor = true;
            this.btnActivated.Click += new System.EventHandler(this.btnActivated_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = global::Orca_FO_v2._12._0.Properties.Resources.refresh_arrow__1_;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1249, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ActivateContracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ActivateContracts";
            this.Size = new System.Drawing.Size(1327, 641);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActivateContracts)).EndInit();
            this.grpboxActivateContracts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridActivateContracts;
        private System.Windows.Forms.GroupBox grpboxActivateContracts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnActivated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRootContract;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colToBePublished;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;
    }
}
