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
    public partial class PatientList : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            bindUser();
        }
        public void bindUser()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "pDisplay");

            sdr = hms.GetDataReaderSP("PatientMastersp", slD);

            rptPatient.DataSource = sdr;
            rptPatient.DataBind();
        }
        protected void rptPatient_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("EditPatient.aspx?pid=" + e.CommandArgument);
            }
            else if (e.CommandName == "delete")
            {
                SortedList slI = new SortedList();
                slI.Add("@mode", "pdelete");
                slI.Add("@pid", e.CommandArgument);

                hms.ExecuteNonQuerySP("PatientMastersp", slI);

                bindUser();
            }

        }
    }
}