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
    public partial class AddPatient : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddPatient_Click(object sender, EventArgs e)
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
                Random ra = new Random();
                string pass = ra.Next(0, 100000).ToString();

                SortedList slI = new SortedList();
                slI.Add("@mode", "pinsert");
                slI.Add("@pname", txtName.Text);
                slI.Add("@pemail", txtEmail.Text);
                slI.Add("@pcontact", txtContact.Text);
                
                slI.Add("@ppassword", pass);
                slI.Add("@padd", txtAddress.Text);
                
                slI.Add("@pstatus", "Active");
                slI.Add("@pdate", System.DateTime.Now);

                hms.ExecuteNonQuerySP("PatientMastersp", slI);
                pnlAlertS.Visible = true;
                lblMessageS.Text = "Record inserted Successfully.";
            }
        }
    }
}