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
    public partial class AppointmentList : System.Web.UI.Page
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
            slD.Add("@mode", "paDisplay");

            sdr = hms.GetDataReaderSP("AppointmentMastersp", slD);

            rptAppointment.DataSource = sdr;
            rptAppointment.DataBind();
        }
        

        protected void rptAppointment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("EditAppointment.aspx?paid=" + e.CommandArgument);
            }
            else if (e.CommandName == "delete")
            {
                SortedList slI = new SortedList();
                slI.Add("@mode", "paDelete");
                slI.Add("@paid", e.CommandArgument);

                hms.ExecuteNonQuerySP("AppointmentMastersp", slI);

                bindUser();
            }

        }
    }
}