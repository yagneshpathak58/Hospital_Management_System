using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagement.HospitalAdmin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["hmsadid"] = null;
            Session["hmsadname"] = null;
            Session["hmsaduname"] = null;

            Response.Redirect("Index.aspx");
        }
    }
}