using HospitalManagement.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;


namespace HospitalManagement.HospitalAdmin
{

    public partial class AddUser : System.Web.UI.Page
    {
        HMS hms = new HMS();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;
            pnlAlertS.Visible = false;
            if (txtName.Text == "" || txtContact.Text == "" || txtUsername.Text == "")
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "Fille the required Fields !";
            }
            else
            {
                SortedList sl = new SortedList();
                sl.Add("@mode", "checkUsername");
                sl.Add("@auname", txtUsername.Text);

                int ac = Convert.ToInt32(hms.ExecuteScalarSP("AdminMasterSP", sl));
                if (ac == 1)
                {
                    pnlAlertD.Visible = true;
                    lblMessageD.Text = "Username already Exist !";
                }
                else
                {

                    Random ra = new Random();
                    string pass = ra.Next(0, 100000).ToString();

                    SortedList slI = new SortedList();
                    slI.Add("@mode", "adinsert");
                    slI.Add("@aname", txtName.Text);
                    slI.Add("@aemail", txtEmail.Text);
                    slI.Add("@acontact", txtContact.Text);
                    slI.Add("@auname", txtUsername.Text);
                    slI.Add("@apassword", pass);
                    slI.Add("@aadd", txtAddress.Text);
                    slI.Add("@arole", ddlRole.SelectedValue);
                    slI.Add("@astatus", "Active");
                    slI.Add("@adate", System.DateTime.Now);

                    hms.ExecuteNonQuerySP("AdminMasterSP", slI);
                    pnlAlertS.Visible = true;
                    lblMessageS.Text = "Record inserted Successfully.";
                }
            }

        }
    }
}