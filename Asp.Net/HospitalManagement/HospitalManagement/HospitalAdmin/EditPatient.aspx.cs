using HospitalManagement.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagement.HospitalAdmin
{
    public partial class EditPatient : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pid"] == "" || Request.QueryString["pid"] == null)
            {
                Response.Redirect("PatientList.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    bindUser();
                }
            }


        }
        public void bindUser()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "pDisplayS");
            slD.Add("@pid", Request.QueryString["pid"]);

            sdr = hms.GetDataReaderSP("PatientMastersp", slD);
            while (sdr.Read())
            {
                txtName.Text = sdr["P_Name"].ToString();
                txtContact.Text = sdr["P_Contact"].ToString();
                txtEmail.Text = sdr["P_Email"].ToString();
                txtAddress.Text = sdr["P_Address"].ToString();
                ddlStatus.SelectedValue = sdr["P_Status"].ToString();
            }

        }

        protected void btnEditPatient_Click(object sender, EventArgs e)
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
                slI.Add("@mode", "pUpdate");
                slI.Add("@pid", Request.QueryString["pid"]);
                slI.Add("@pname", txtName.Text);
                slI.Add("@pemail", txtEmail.Text);
                slI.Add("@pcontact", txtContact.Text);
                slI.Add("@padd", txtAddress.Text);
                slI.Add("@pstatus", ddlStatus.SelectedValue);

                hms.ExecuteNonQuerySP("PatientMastersp", slI);
                pnlAlertS.Visible = true;
                lblMessageS.Text = "Saved Successfully.";
            }

        }


    }
}