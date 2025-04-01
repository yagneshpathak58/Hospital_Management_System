using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using HospitalManagement.App_Code;

namespace HospitalManagement.HospitalAdmin
{
    public partial class AddAppointment : System.Web.UI.Page
    {
        HMS hms = new HMS();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindPatient();
                bindDoctor();

            }

        }
        public void bindPatient()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "pDisplay");

            sdr = hms.GetDataReaderSP("PatientMastersp", slD);

            ddPatientid.DataSource = sdr;
            ddPatientid.DataTextField = "P_Name";
            ddPatientid.DataValueField = "P_ID";
            ddPatientid.DataBind();
        }
        public void bindDoctor()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "dDisplay");

            sdr = hms.GetDataReaderSP("DoctorMasterSP", slD);

            ddDoctorid.DataSource = sdr;
            ddDoctorid.DataTextField = "DR_Name";
            ddDoctorid.DataValueField = "DR_Id";
            ddDoctorid.DataBind();

        }

        protected void btnAddAppointment_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;
            pnlAlertS.Visible = false;
            if (txtPName.Text == "" || txtContact.Text == "")
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "Fill the required Fields !";
            }
            else
            {


                SortedList slI = new SortedList();
                slI.Add("@mode", "paInsert");
                slI.Add("@opid", ddOPDTime.SelectedValue);
                slI.Add("@papid", ddPatientid.SelectedValue);
                slI.Add("@padid", ddDoctorid.SelectedValue);
                slI.Add("@paname", txtPName.Text);

                slI.Add("@pacontact", txtContact.Text);
                slI.Add("@paadd", txtAddress.Text);
                slI.Add("@padisease", txtDiseases.Text);
                slI.Add("@pamedicines", txtMedicines.Text);
                slI.Add("@paopddate", txtOpddate.Text);
                slI.Add("@paopdtime", ddOPDTime.SelectedItem.Text);
                slI.Add("@pastatus", "Active");

                slI.Add("@padate", System.DateTime.Now);

                hms.ExecuteNonQuerySP("AppointmentMastersp", slI);
                pnlAlertS.Visible = true;
                lblMessageS.Text = "Record inserted Successfully.";
            }
        }

        protected void ddPatientid_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindPatientS();
        }

        protected void ddDoctorid_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDoctorS();
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "getOPDByID");
            slD.Add("@did", ddDoctorid.SelectedValue);
            slD.Add("@bdate", txtOpddate.Text);

            sdr = hms.GetDataReaderSP("AppointmentMastersp", slD);

            ddOPDTime.DataSource = sdr;
            ddOPDTime.DataTextField = "Op_Time_From";
            ddOPDTime.DataValueField = "Op_Id";
            ddOPDTime.DataBind();

        }
        public void bindPatientS()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "pDisplayS");
            slD.Add("@pid", ddPatientid.SelectedValue);

            sdr = hms.GetDataReaderSP("PatientMastersp", slD);
            while (sdr.Read())
            {
                txtPName.Text = sdr["P_Name"].ToString();
                txtContact.Text = sdr["P_Contact"].ToString();
                txtAddress.Text = sdr["P_Address"].ToString();
            }
        }
        public void bindDoctorS()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "dDisplayS");
            slD.Add("@did", ddDoctorid.SelectedValue);

            sdr = hms.GetDataReaderSP("DoctorMasterSP", slD);
            while (sdr.Read())
            {
                DoctorFee.Text = sdr["DR_Fee"].ToString();
            }
        }
    }
}