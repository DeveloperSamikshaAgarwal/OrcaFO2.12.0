using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL = Orca_FO_v2._12._0.DataContext.DbContext;

namespace Orca_FO_v2._12._0.MasterView
{
    public partial class RollOverCurrentMonth : Form
    {
        int id = 0;
        public RollOverCurrentMonth(int id)
        {
            InitializeComponent();
            this.id = id;
            setPopUp();
        }
        public void setPopUp()
        {
            try
            {
                MainForm.log.Information("Rollver of contract Month form opens");
                DataTable dtCurrentMonth = DAL.GetDataSetFromQuery("select * from Trade.futureSymbols where ContractId=" + id).Tables[0];
                string contractName = dtCurrentMonth.Rows[0]["ContractName"].ToString();
                lblWarning.Text = string.Format(lblWarning.Text, contractName);
                lblChange.Text = String.Format("Rolling future of {0} current month traded from {1}  to ",
                    /*dtCurrentMonth.Rows[0]["ContractName"].ToString(),*/
                    dtCurrentMonth.Rows[0]["BBGName"].ToString(),
                   dtCurrentMonth.Rows[0]["CurrentMonthTraded"].ToString());
            }
            catch (Exception ex)
            {
                MainForm.log.Information("Error occured while opening of form for rollover contract month: " + ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm.log.Information("Cancel button is clicked");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MainForm.log.Information("Save button is clicked for saving the changed contract month");
            if (String.IsNullOrEmpty(txtCurrentMonth.Text))
            {
                MainForm.log.Information("Current month cannot be null, Please fill the text box");
                MessageBox.Show("Current month cannot be null, Please fill the text box");
            }
            else
            {
                try
                {
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(new SqlParameter()
                    {
                        SqlDbType = SqlDbType.Int,
                        ParameterName = "@ContractId",
                        Value = id
                    });
                    sqlParameters.Add(new SqlParameter()
                    {
                        SqlDbType = SqlDbType.NVarChar,
                        ParameterName = "@CurrentMonthTraded",
                        Value = txtCurrentMonth.Text
                    });
                    DAL.ExecuteSp("[Trade].[UpdateFutureMonth]", sqlParameters);
                    this.Close();
                    MessageBox.Show("Contract month updated successfully in the database", Application.ProductName);
                    MainForm.log.Information("Contract month updated successfully in the database");


                }
                catch (Exception ex)
                {
                    MainForm.log.Information("Sorry!! It seems some error occured while updating the data. please try again: "+ex);
                    MessageBox.Show("Sorry!! It seems some error occured while updating the data. please try again", Application.ProductName); ;
                }
            }
        }

    }
}
