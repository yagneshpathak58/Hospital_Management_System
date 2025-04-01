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
    
    public partial class EditDoctorDocument : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ddid"] == "" || Request.QueryString["ddid"] == null)
            {
                Response.Redirect("DoctorDocumentList.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    bindDoctor();
                    bindUser();
                }
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
        public void bindUser()
        {
            SortedList slD = new SortedList();
            SqlDataReader sdr;
            slD.Add("@mode", "ddDisplayS");
            slD.Add("@ddid", Request.QueryString["ddid"]);

            sdr = hms.GetDataReaderSP("DoctorMasterSP", slD);
            while (sdr.Read())
            {
                ddDoctorid.SelectedValue = sdr["D_Id"].ToString();
                txtDDName.Text = sdr["Dd_Title"].ToString();
                ddlStatus.SelectedValue = sdr["Dd_Status"].ToString();
                hdfDocumentName.Value = sdr["Dd_DocumentName"].ToString();
                hdfDocumentPath.Value = sdr["Dd_DocumentPath"].ToString();
            }

        }

        protected void btnSavechanges_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;
            pnlAlertS.Visible = false;
            string fileName = "", filePath = "";
            HttpPostedFile httpPostedFile = fuDoctorDoc.PostedFile;

            if (txtDDName.Text == "")
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "All fields are Required !";
            }
            else
            {
                if (httpPostedFile.ContentLength <= 0 || httpPostedFile == null)
                {
                    fileName = hdfDocumentName.Value;
                    filePath = hdfDocumentPath.Value;
                }
                else
                {
                    Random random = new Random();
                    fileName = Path.GetFileName(random.Next() + "_" + fuDoctorDoc.PostedFile.FileName);
                    fuDoctorDoc.PostedFile.SaveAs(Server.MapPath("~/DoctorDocument/" + fileName));
                    filePath = "../DoctorDocument/" + fileName;
                }

                SortedList slI = new SortedList();
                slI.Add("@mode", "ddUpdate");
                slI.Add("@ddid", Request.QueryString["ddid"]);
                slI.Add("@did", ddDoctorid.SelectedValue);
                slI.Add("@ddtitle", txtDDName.Text);
                slI.Add("@ddname", fileName);
                slI.Add("@ddpath", filePath);
                slI.Add("@drstatus", ddlStatus.SelectedValue);

                hms.ExecuteNonQuerySP("DoctorMasterSP", slI);

                pnlAlertS.Visible = true;
                lblMessageS.Text = "Saved Successfully.";
            }
        }
    }
}