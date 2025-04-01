using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using HospitalManagement.App_Code;
using System.IO;

namespace HospitalManagement.HospitalAdmin
{
    public partial class AddCategory : System.Web.UI.Page
    {
        HMS hms = new HMS();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            pnlAlertD.Visible = false;
            pnlAlertS.Visible = false;
            string fileName = "", filePath = "";
            HttpPostedFile httpPostedFile = fuCategoryImage.PostedFile;
            if (txtTitle.Text == "" || httpPostedFile.ContentLength <= 0 || httpPostedFile == null)
            {
                pnlAlertD.Visible = true;
                lblMessageD.Text = "Fill the required Fields !";
            }
            else
            {
                Random random = new Random();
                fileName = Path.GetFileName(random.Next() + "_" + fuCategoryImage.PostedFile.FileName);
                //filePath= Server.MapPath("~/DoctorDocument/" + fileName);
                fuCategoryImage.PostedFile.SaveAs(Server.MapPath("~/CategoryImage/" + fileName));
                filePath = "../CategoryImage/" + fileName;


                SortedList slI = new SortedList();
                slI.Add("@mode", "cinsert");
                slI.Add("@ctitle", txtTitle.Text);
                slI.Add("@cimgname", fileName);
                slI.Add("@cimage", filePath);

                slI.Add("@cstatus", "Active");
                slI.Add("@cdate", System.DateTime.Now);

                hms.ExecuteNonQuerySP("CategoryMastersp", slI);
                pnlAlertS.Visible = true;
                lblMessageS.Text = "Record inserted Successfully.";
            }
        }
    }
}