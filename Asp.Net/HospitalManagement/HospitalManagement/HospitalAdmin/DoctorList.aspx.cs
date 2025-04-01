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
    public partial class DoctorList : System.Web.UI.Page
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
            slD.Add("@mode", "dDisplay");

            sdr = hms.GetDataReaderSP("DoctorMasterSP", slD);

            rptDoctor.DataSource = sdr;
            rptDoctor.DataBind();
        }

        protected void rptDoctor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("EditDoctor.aspx?did=" + e.CommandArgument);
            }
            else if (e.CommandName == "delete")
            {
                SortedList slI = new SortedList();
                slI.Add("@mode", "dDelete");
                slI.Add("@did", e.CommandArgument);

                hms.ExecuteNonQuerySP("DoctorMasterSP", slI);

                bindUser();
            }
        }
    }
}