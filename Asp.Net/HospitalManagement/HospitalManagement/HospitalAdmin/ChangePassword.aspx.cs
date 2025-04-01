using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using HospitalManagement.App_Code;

namespace HospitalManagement.HospitalAdmin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        HMS hms = new HMS();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;
            pnlAlertS.Visible = false;

            if (txtOldPass.Text == "" || txtNewPassword.Text == "" || txtConfirmpass.Text == "")
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "All Fields are Required !";
            }
            else if (txtNewPassword.Text != txtConfirmpass.Text)
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "New password does not match !";
            }
            else
            {
                SortedList sl = new SortedList();
                sl.Add("@mode", "checkLogin");
                sl.Add("@auname", Session["hmsaduname"].ToString());
                sl.Add("@apassword", txtOldPass.Text);

                int ac = Convert.ToInt32(hms.ExecuteScalarSP("AdminMasterSP", sl));
                if (ac == 1)
                {
                    SortedList slcp = new SortedList();
                    slcp.Add("@mode", "adChangePassword");
                    slcp.Add("@aid", Session["hmsadid"].ToString());
                    slcp.Add("@apassword", txtNewPassword.Text);

                    hms.ExecuteNonQuerySP("AdminMasterSP", slcp);

                    pnlAlertS.Visible = true;
                    lblMessageS.Text = "Password changed Successfully.";
                }
                else
                {
                    pnlAlertD.Visible = true;
                    lblMessageD.Text = "Old password does not match !";
                }
            }
        }
    }
}