using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace Banking_Customer_Regstartion_App
{

    public partial class Registartion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        int status = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial catalog=Banking; integrated security=true";
            if (!IsPostBack)
            {
                ddlAccounts.DataSource = Accounts();
                ddlAccounts.DataTextField = "Account";
                ddlAccounts.DataValueField = "Id";
                ddlAccounts.DataBind();
                lblAccNum.Text = AccountNumber().ToString();
                ViewState["action"] = 1;
            }

        }
        int AccountNumber()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmdAccnum = new SqlCommand("Select max(accno)+1 from Customers", con);
            return Convert.ToInt32(cmdAccnum.ExecuteScalar());

        }

        DataTable Accounts()
        {
            SqlDataAdapter daActs = new SqlDataAdapter("Select Id,Account from Accounts", con);
            DataTable dtActs = new DataTable();
            daActs.Fill(dtActs);
            DataRow r = dtActs.NewRow();
            r[0] = -1;
            r[1] = "Choose Preferred Account";
            dtActs.Rows.InsertAt(r, 0);
            return dtActs;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlAccounts.SelectedValue) == -1)
            {
                lblMsg.Text = "Please Choose Your Account Type";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            if (!cbStatus.Checked)
            {
                status = 0;
            }
            SqlCommand cmdSave = new SqlCommand();
            cmdSave.Connection = con;
            if (con.State == ConnectionState.Closed)
                con.Open();
            if (Convert.ToInt32(ViewState["action"]) == 1)
            {
                cmdSave.CommandText = "insert into customers values(@accno, @name, @address, @account, @status)";
            }
            else if (Convert.ToInt32(ViewState["action"]) == 2)
            {
                cmdSave.CommandText = "update customers set name=@name, address=@address, account=@account, status=@status where accno=@accno";
            }

            cmdSave.Parameters.AddWithValue("@accno", Convert.ToInt32(lblAccNum.Text));
            cmdSave.Parameters.AddWithValue("@name", txtName.Text.Trim());
            cmdSave.Parameters.AddWithValue("@address", txtAdd.Text.Trim());
            cmdSave.Parameters.AddWithValue("@account", Convert.ToInt32(ddlAccounts.SelectedValue));
            cmdSave.Parameters.AddWithValue("@status", status);

            try
            {
                int recordsAffected = cmdSave.ExecuteNonQuery();

                if (recordsAffected > 0)
                {
                    if (Convert.ToInt32(ViewState["action"]) == 1)
                    {
                        lblMsg.Text = "Account has been opened for: " + txtName.Text.Trim();

                    }
                    btnSave.Enabled = false;
                    lblMsg.ForeColor = Color.Red;
                }
                else
                {
                    lblMsg.Text = "Failed to Add the deatils";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Database Error: " + ex.Message;
                lblMsg.ForeColor = Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ViewState["action"] = 1;
            status = 1;
            btnSave.Enabled = true;
            txtName.Text = " ";
            txtAdd.Text = "";
            ddlAccounts.SelectedIndex = 0;
            lblMsg.Text = "";
            lblAccNum.Text = AccountNumber().ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}