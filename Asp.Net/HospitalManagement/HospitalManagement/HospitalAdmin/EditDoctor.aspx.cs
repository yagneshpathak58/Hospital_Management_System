using HospitalManagement.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagement.HospitalAdmin
{
    public partial class EditDoctor : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["did"] == "" || Request.QueryString["did"] == null)
            {
                Response.Redirect("DoctorList.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    bindUser();
                }
            }

        }

        public void bindUser()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "dDisplayS");
            slD.Add("@did", Request.QueryString["did"]);

            sdr = hms.GetDataReaderSP("DoctorMasterSP", slD);
            while (sdr.Read())
            {
                txtName.Text = sdr["DR_Name"].ToString();
                txtContact.Text = sdr["DR_Contact"].ToString();
                txtEmail.Text = sdr["DR_Email"].ToString();
                txtBankname.Text = sdr["DR_Bank_Name"].ToString();
                txtBankacno.Text = sdr["DR_B_Ac"].ToString();
                txtBankactype.Text = sdr["DR_Ac_Type"].ToString();
                txtBankifccode.Text = sdr["DR_IFCcode"].ToString();
                ddlStatus.SelectedValue = sdr["DR_Status"].ToString();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;
            pnlAlertS.Visible = false;
            string fileName = "", filePath = "";
            HttpPostedFile httpPostedFile = fuDoctorImage.PostedFile;
            if (txtName.Text == "" || txtContact.Text == "")
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "Fill the required Fields !";
            }
            else
            {
                if (httpPostedFile.ContentLength <= 0 || httpPostedFile == null)
                {
                    fileName = hdfDoctorImageName.Value;
                    filePath = hdfDoctorImagePath.Value;
                }
                else
                {
                    Random random = new Random();
                    fileName = Path.GetFileName(random.Next() + "_" + fuDoctorImage.PostedFile.FileName);
                    fuDoctorImage.PostedFile.SaveAs(Server.MapPath("~/DoctorImage/" + fileName));
                    filePath = "../DoctorImage/" + fileName;
                }

                SortedList slI = new SortedList();
                slI.Add("@mode", "dUpdate");
                slI.Add("@did", Request.QueryString["did"]);
                slI.Add("@drname", txtName.Text);
                slI.Add("@drimgname", fileName);
                slI.Add("@drimage", filePath);
                slI.Add("@dremail", txtEmail.Text);
                slI.Add("@drcontact", txtContact.Text);
                slI.Add("@drbankname", txtBankname.Text);
                slI.Add("@drbankacno", txtBankacno.Text);
                slI.Add("@dractype", txtBankactype.Text);
                slI.Add("@drifccode", txtBankifccode.Text);
                slI.Add("@drstatus", ddlStatus.SelectedValue);

                hms.ExecuteNonQuerySP("DoctorMasterSP", slI);
                pnlAlertS.Visible = true;
                lblMessageS.Text = "Saved Successfully.";
            }
        }
    }
}