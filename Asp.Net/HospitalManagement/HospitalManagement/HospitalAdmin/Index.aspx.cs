using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using HospitalManagement.App_Code;
using System.Data.SqlClient;

namespace HospitalManagement.HospitalAdmin
{
    public partial class Index : System.Web.UI.Page
    {
        HMS hms = new HMS();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["hmsadid"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "Username or Password missing !";
            }
            else
            {
                SortedList sl = new SortedList();
                sl.Add("@mode", "checkLogin");
                sl.Add("@auname", txtUsername.Text);
                sl.Add("@apassword", txtPassword.Text);

                int ac = Convert.ToInt32(hms.ExecuteScalarSP("AdminMasterSP", sl));
                if (ac == 1)
                {
                    SortedList slA = new SortedList();
                    SqlDataReader sdrA;

                    slA.Add("@mode", "adGetDetail");
                    slA.Add("@auname", txtUsername.Text);
                    slA.Add("@apassword", txtPassword.Text);

                    sdrA = hms.GetDataReaderSP("AdminMasterSP", slA);
                    while (sdrA.Read())
                    {
                        Session["hmsadid"] = sdrA["A_ID"].ToString();
                        Session["hmsadname"] = sdrA["A_Name"].ToString();
                        Session["hmsaduname"] = sdrA["A_UserName"].ToString();
                        Session["hmsadrole"] = sdrA["A_Role"].ToString();

                        Response.Redirect("Dashboard.aspx");
                    }
                }
                else
                {
                    pnlAlertD.Visible = true;
                    lblMessageD.Text = "Username or Password Incorrect !";
                }
            }
        }
    }
}