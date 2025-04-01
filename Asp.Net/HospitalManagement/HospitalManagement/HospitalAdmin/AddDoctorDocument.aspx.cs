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

namespace HospitalManagement
{
    public partial class AddDoctorDocument : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                bindDoctor();

            }

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

        protected void btnAddDocument_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;
            pnlAlertS.Visible = false;
            string fileName = "", filePath = "";
            HttpPostedFile httpPostedFile = fuDoctorDoc.PostedFile;
            if (txtDDName.Text == "" || httpPostedFile.ContentLength <= 0 || httpPostedFile == null)
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "All fields are Required !";
            }
            else
            {
                Random random = new Random();
                fileName = Path.GetFileName(random.Next() + "_" + fuDoctorDoc.PostedFile.FileName);
                //filePath= Server.MapPath("~/DoctorDocument/" + fileName);
                fuDoctorDoc.PostedFile.SaveAs(Server.MapPath("~/DoctorDocument/" + fileName));
                filePath = "../DoctorDocument/" + fileName;

                SortedList slI = new SortedList();
                slI.Add("@mode", "ddInsert");
                slI.Add("@did", ddDoctorid.SelectedValue);
                slI.Add("@ddtitle", txtDDName.Text);
                slI.Add("@ddname", fileName);
                slI.Add("@ddpath", filePath);
                slI.Add("@drstatus", "Active");
                slI.Add("@drdate", System.DateTime.Now);

                hms.ExecuteNonQuerySP("DoctorMasterSP", slI);

                pnlAlertS.Visible = true;
                lblMessageS.Text = "Record Inserted.";
            }
        }
    }
}