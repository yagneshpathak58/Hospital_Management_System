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
    public partial class EditAppointment : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["paid"] == "" || Request.QueryString["paid"] == null)
            {
                Response.Redirect("AppointmentList.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    bindPatient();
                    bindDoctor();
                    bindUser();
                }
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
        public void bindUser()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "paDisplayS");
            slD.Add("@paid", Request.QueryString["paid"]);


            sdr = hms.GetDataReaderSP("AppointmentMastersp", slD);
            while (sdr.Read())
            {
                ddPatientid.SelectedValue = sdr["P_ID"].ToString();
                ddDoctorid.SelectedValue = sdr["D_ID"].ToString();
                txtPName.Text = sdr["P_A_Name"].ToString();
                txtContact.Text = sdr["P_A_Contact"].ToString();
                txtAddress.Text = sdr["P_A_Address"].ToString();
                txtDiseases.Text = sdr["P_A_Diseases"].ToString();
                txtMedicines.Text = sdr["P_A_Medicines"].ToString();
                txtOpddate.Text = sdr["P_A_OPD_Date"].ToString();
                ddOPDTime.SelectedValue = sdr["P_A_OPD_Time"].ToString();
                PaymentMode.SelectedValue = sdr["B_P_PaymentMode"].ToString();


                ddlStatus.SelectedValue = sdr["P_A_Status"].ToString();

                bindPatientS();
                bindDoctorS();
            }


        }

        protected void btnUpdateAppointment_Click(object sender, EventArgs e)
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
                slI.Add("@mode", "paUpdate");
                slI.Add("@paid", Request.QueryString["paid"]);
                slI.Add("@papid", ddPatientid.SelectedValue);
                slI.Add("@padid", ddDoctorid.SelectedValue);
                slI.Add("@paname", txtPName.Text);
                slI.Add("@pacontact", txtContact.Text);
                slI.Add("@paadd", txtAddress.Text);
                slI.Add("@pamedicines", txtMedicines.Text);

                slI.Add("@pastatus", ddlStatus.SelectedValue);

                hms.ExecuteNonQuerySP("AppointmentMastersp", slI);

                //string dc = "select COUNT(*) from Doctor_Payment_Master where D_ID=" + did;
                SortedList sldc = new SortedList();
                sldc.Add("@mode", "paDoctorCount");
                sldc.Add("@did", ddDoctorid.SelectedValue);
                int dc1 = Convert.ToInt32(hms.ExecuteScalarSP("AppointmentMastersp", sldc));

                if (dc1 == 1)
                {
                    int tOpd = 0;
                    float total = 0, paid = 0, remain = 0;

                    //string dp = "update Doctor_Payment_Master set B_D_TotalOPD=" + tOpd + ",B_D_Total=" + total + ",B_D_Paid_Amount=" + paid + ",B_D_Remain_Amount=" + remain + " where D_ID=" + did;

                }
                else
                {
                    //string dp = "insert into Doctor_Payment_Master(D_ID,B_D_TotalOPD,B_D_Total,B_D_Paid_Amount,B_D_Remain_Amount,B_D_Date) values(@did,@topd,@ototal,@opaid,@premain,@odate)";
                    SortedList sldp = new SortedList();
                    sldp.Add("@mode", "paInsertDocPay");
                    sldp.Add("@did", ddDoctorid.SelectedValue);
                    sldp.Add("@topd", "1");
                    sldp.Add("@ptotal", DoctorFee.Text);
                    sldp.Add("@paid", "0");
                    sldp.Add("@remain", DoctorFee.Text);
                    sldp.Add("@bdate", System.DateTime.Now);

                    hms.ExecuteNonQuerySP("AppointmentMastersp", sldp);
                }
                Random r = new Random();
                string billno = r.Next(000001, 999999).ToString();

                SortedList slbi = new SortedList();
                slbi.Add("@mode", "paInsertBill");
                slbi.Add("@billno", billno);
                slbi.Add("@aid", Session["hmsadid"]);
                slbi.Add("@paid", Request.QueryString["paid"]);
                slbi.Add("@pid", ddPatientid.SelectedValue);
                slbi.Add("@amount", DoctorFee.Text);
                slbi.Add("@pmode", PaymentMode.SelectedValue);
                slbi.Add("@tranid", txtTranId.Text);
                slbi.Add("@bstatus", "Active");
                slbi.Add("@bdate", System.DateTime.Now);

                hms.ExecuteNonQuerySP("AppointmentMastersp", slbi);

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