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
    public partial class CategoryList : System.Web.UI.Page
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
            slD.Add("@mode", "cDisplay");

            sdr = hms.GetDataReaderSP("CategoryMastersp", slD);

            rptCategory.DataSource = sdr;
            rptCategory.DataBind();
        }

        protected void rptCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "edit")
            {
                Response.Redirect("EditCategory.aspx?cid=" + e.CommandArgument);
            }
            else if (e.CommandName == "delete")
            {
                SortedList slI = new SortedList();
                slI.Add("@mode", "cDelete");
                slI.Add("@cid", e.CommandArgument);

                hms.ExecuteNonQuerySP("CategoryMastersp", slI);
                bindUser();

            }
        }
    }
}