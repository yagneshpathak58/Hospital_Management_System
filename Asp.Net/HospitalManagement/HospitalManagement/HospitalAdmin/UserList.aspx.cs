using HospitalManagement.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;

namespace HospitalManagement.HospitalAdmin
{
    public partial class UserList : System.Web.UI.Page
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
            slD.Add("@mode", "adDisplay");

            sdr = hms.GetDataReaderSP("AdminMasterSP", slD);

            rptUser.DataSource = sdr;
            rptUser.DataBind();
        }

        protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName=="edit")
            {
                Response.Redirect("EditUser.aspx?uid=" + e.CommandArgument);
            }
            else if(e.CommandName== "delete")
            {
                SortedList slI = new SortedList();
                slI.Add("@mode", "adDelete");
                slI.Add("@aid", e.CommandArgument);

                hms.ExecuteNonQuerySP("AdminMasterSP", slI);

                bindUser();
            }
        }
    }
}