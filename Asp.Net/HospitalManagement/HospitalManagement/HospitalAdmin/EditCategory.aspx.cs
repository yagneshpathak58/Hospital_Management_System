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
    public partial class EditCategory : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cid"] == "" || Request.QueryString["cid"] == null)
            {
                Response.Redirect("CategoryList.aspx");
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
            slD.Add("@mode", "cDisplayS");
            slD.Add("@cid", Request.QueryString["cid"]);


            sdr = hms.GetDataReaderSP("CategoryMastersp", slD);
            while (sdr.Read())
            {

                txtTitle.Text = sdr["C_Title"].ToString();


                ddlStatus.SelectedValue = sdr["C_Status"].ToString();
            }
        }

        protected void btnSaveChange_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;
            pnlAlertS.Visible = false;
            string fileName = "", filePath = "";
            HttpPostedFile httpPostedFile = fuCategoryImage.PostedFile;
            if (txtTitle.Text == "")
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "Fill the required Fields !";
            }
            else
            {
                if (httpPostedFile.ContentLength <= 0 || httpPostedFile == null)
                {
                    fileName = hdfCategoryImageName.Value;
                    filePath = hdfCategoryImagePath.Value;
                }
                else
                {
                    Random random = new Random();
                    fileName = Path.GetFileName(random.Next() + "_" + fuCategoryImage.PostedFile.FileName);
                    fuCategoryImage.PostedFile.SaveAs(Server.MapPath("~/CategoryImage/" + fileName));
                    filePath = "../CategoryImage/" + fileName;
                }


                SortedList slI = new SortedList();
                slI.Add("@mode", "cUpdate");
                slI.Add("@cid", Request.QueryString["cid"]);
                slI.Add("@ctitle", txtTitle.Text);
                slI.Add("@cimgname", fileName);
                slI.Add("@cimage", filePath);
                slI.Add("@cstatus", ddlStatus.SelectedValue);

                hms.ExecuteNonQuerySP("CategoryMastersp", slI);
                pnlAlertS.Visible = true;
                lblMessageS.Text = "Record inserted Successfully.";
            }
        }
    }
}