using HospitalManagement.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;

namespace HospitalManagement.HospitalAdmin
{
    public partial class EditUser : System.Web.UI.Page
    {
        HMS hms = new HMS();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["uid"]=="" || Request.QueryString["uid"]==null)
            {
                Response.Redirect("UserList.aspx");
            }
            else
            {
                if(!IsPostBack)
                {
                    bindUser();
                }
            }
            
            
        }
        public void bindUser()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "adDisplayS");
            slD.Add("@aid", Request.QueryString["uid"]);

            sdr = hms.GetDataReaderSP("AdminMasterSP", slD);
            while(sdr.Read())
            {
                txtName.Text = sdr["A_Name"].ToString();
                txtContact.Text = sdr["A_Contact"].ToString();
                txtEmail.Text = sdr["A_Email"].ToString();
                txtUsername.Text = sdr["A_UserName"].ToString();
                txtAddress.Text = sdr["A_Address"].ToString();
                ddlRole.SelectedValue = sdr["A_Role"].ToString();
                ddlStatus.SelectedValue = sdr["A_Status"].ToString();
            }
           
        }

        protected void btnEditAdmin_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;
            pnlAlertS.Visible = false;
            if (txtName.Text == "" || txtContact.Text == "")
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "Fill the required Fields !";
            }
            else
            {

                SortedList slI = new SortedList();
                slI.Add("@mode", "adUpdate");
                slI.Add("@aid", Request.QueryString["uid"]);
                slI.Add("@aname", txtName.Text);
                slI.Add("@aemail", txtEmail.Text);
                slI.Add("@acontact", txtContact.Text);
                slI.Add("@aadd", txtAddress.Text);
                slI.Add("@arole", ddlRole.SelectedValue);
                slI.Add("@astatus", ddlStatus.SelectedValue);

                hms.ExecuteNonQuerySP("AdminMasterSP", slI);
                pnlAlertS.Visible = true;
                lblMessageS.Text = "Saved Successfully.";
            }
        }
    }
}