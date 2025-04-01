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
    public partial class AddDoctor : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            bindCategory();
            }

        }
        public void bindCategory()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "cDisplay");

            sdr = hms.GetDataReaderSP("CategoryMastersp", slD);

            ddCategory.DataSource = sdr;
            ddCategory.DataTextField = "C_Title";
            ddCategory.DataValueField = "C_ID";
            ddCategory.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
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
                    Random ra = new Random();
                    fileName = Path.GetFileName(ra.Next() + "_" + fuDoctorImage.PostedFile.FileName);
                    fuDoctorImage.PostedFile.SaveAs(Server.MapPath("~/DoctorImage/" + fileName));
                    filePath = "../DoctorImage/" + fileName;
                    string pass = ra.Next(0, 100000).ToString();

                    SortedList slI = new SortedList();
                    slI.Add("@mode", "drinsert");
                    slI.Add("@cid", ddCategory.SelectedValue);
                    slI.Add("@drname", txtName.Text);
                    slI.Add("@drimgname", fileName);
                    slI.Add("@drimage", filePath);
                    slI.Add("@dremail", txtEmail.Text);
                    slI.Add("@drcontact", txtContact.Text);
                    slI.Add("@drpassword", pass);
                    slI.Add("@drbankname", txtBankname.Text);
                    slI.Add("@drbankacno", txtBankacno.Text);
                    slI.Add("@dractype", txtBankactype.Text);
                    slI.Add("@drifccode", txtBankifccode.Text);
                    slI.Add("@drregno", txtDrregnum.Text);
                    slI.Add("@drfee", "1500");
                    slI.Add("@drstatus", "Active");
                    slI.Add("@drdate", System.DateTime.Now);

                    hms.ExecuteNonQuerySP("DoctorMasterSP", slI);
                    pnlAlertS.Visible = true;
                    lblMessageS.Text = "Record inserted Successfully.";
                }
            }

        }
    }
}
