using HospitalManagement.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagement.HospitalAdmin
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["hmsadid"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                lblAdName.Text = Session["hmsadname"].ToString();
                if (Session["hmsadrole"].ToString() == "super")
                {
                    pnlSuper.Visible = true;
                    pnlSub.Visible = false;
                }
                else
                {
                    pnlSuper.Visible = false;
                    pnlSub.Visible = true;
                }
            }
            bindCounter();
        }
        public void bindCounter()
        {
            SortedList sldc = new SortedList();
            sldc.Add("@mode", "paDoctorCount");
            lblDC.Text = (hms.ExecuteScalarSP("DoctorMasterSP", sldc)).ToString();

            SortedList slpc = new SortedList();
            slpc.Add("@mode", "paPatientCount");
            lblPC.Text = (hms.ExecuteScalarSP("PatientMastersp", slpc)).ToString();

            SortedList slac = new SortedList();
            slac.Add("@mode", "AppointmentCount");
            lblAC.Text = (hms.ExecuteScalarSP("AppointmentMastersp", slac)).ToString();

            SortedList slfc = new SortedList();
            slfc.Add("@mode", "FeedbackCount");
            lblFC.Text = (hms.ExecuteScalarSP("AppointmentMastersp", slfc)).ToString();
        }
    }
}