using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace HospitalManagement.API
{
    /// <summary>
    /// Summary description for DoctorMaster
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DoctorMaster : System.Web.Services.WebService
    {
        //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HMSCn"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        //Update categry

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateCategory(string cTitle, string cid)
        {
            con.Open();
            //string cs = "insert into Category_Master(C_Title,C_Status,C_Date) values(@ctitle,@cstatus,@cdate)";
            string csu = "update Category_Master set C_Title=@ctitle,C_Status=@cstatus,C_Date =@cdate where C_ID=" + cid;
            cmd = new SqlCommand(csu, con);
            cmd.Parameters.AddWithValue("@ctitle", cTitle);
            cmd.Parameters.AddWithValue("@cstatus", "Active");
            cmd.Parameters.AddWithValue("@cdate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //View Category

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getCategory()
        {
            string cs = "select * from Category_Master";
            cmd.CommandText = cs;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();

            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //View Doctor

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDoctor()
        {
            string ds = "select * from Doctor_Master";
            cmd.CommandText = ds;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //View Doctor by DoctorId for DoctorProfile

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDoctorById(String DR_Id)
        {
            string ds = "select * from Doctor_Master where DR_Id = " + DR_Id;
            cmd.CommandText = ds;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }



        //View OPD

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDoctorOPD()
        {
            string opd = "select * from Manage_OPD_Master";
            cmd.CommandText = opd;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //View Appointment

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAppointment()
        {
            string ap = "select * from Appointment_Master";
            cmd.CommandText = ap;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //View Appointment By DoctorId

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAppointmentByDocId(String D_ID)
        {
            string ap = "select * from Appointment_Master where D_ID = " + D_ID;
            cmd.CommandText = ap;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //View Appointment By Appointment Id

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAppointmentByAppId(String P_A_Id)
        {
            string ap = "select * from Appointment_Master where P_A_Id = " + P_A_Id;
            cmd.CommandText = ap;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //View Payment

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getPayment()
        {
            string pay = "select * from  Doctor_Payment_Master";
            cmd.CommandText = pay;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //View FeedBack

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFeedback()
        {
            string fb = "select * from  Doctor_FeedBack";
            cmd.CommandText = fb;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //View Feedback By Doctor Id

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFeedbackById(String D_ID)
        {
            string fb = "select * from  Doctor_FeedBack where D_ID = " + D_ID;
            cmd.CommandText = fb;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //Add Feedback

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddFeedback(string did, string pid, string fdmsg)
        {
            con.Open();
            string cs = "insert into Doctor_FeedBack(D_Id,P_Id,Fd_Message,Fd_Status,Fd_Date) values(@did,@pid,@fdmsg,@fdstatus,@fddate)";
            //string csu = "update Manage_OPD_Master set D_Id=@did,O_P_Date=@OpdDate,Op_Time_From=@OpdTimeFrom,Op_Time_To=@OpdTimeTo where Op_Id=" + opid;
            cmd = new SqlCommand(cs, con);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@fdmsg", fdmsg);
            cmd.Parameters.AddWithValue("@fdstatus", "Active");
            cmd.Parameters.AddWithValue("@fddate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //Update Doctor Profile

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateDoctorProfile(string DocName, string DocEmail, string DocContact, string drid)
        {
            con.Open();
            //string cs = "insert into Category_Master(C_Title,C_Status,C_Date) values(@ctitle,@cstatus,@cdate)";
            string csu = "update Doctor_Master set DR_Name=@DocName,DR_Email=@DocEmail,DR_Contact =@DocContact where DR_Id=" + drid;
            cmd = new SqlCommand(csu, con);
            cmd.Parameters.AddWithValue("@DocName", DocName);
            cmd.Parameters.AddWithValue("@DocEmail", DocEmail);
            cmd.Parameters.AddWithValue("@DocContact", DocContact);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //Update Doctor Password

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateDoctorPassword(string DocPasswordOld, string DocPassword, string drid)
        {
            con.Open();
            string ccp = "select COUNT(*) from Doctor_Master where DR_Id=@drid and DR_Password=@drpass and DR_Status='Active'";
            cmd = new SqlCommand(ccp, con);
            cmd.Parameters.AddWithValue("@drid", drid);
            cmd.Parameters.AddWithValue("@drpass", DocPasswordOld);
            int cc = Convert.ToInt32(cmd.ExecuteScalar());
            if (cc == 1)
            {
                string csu = "update Doctor_Master set DR_Password =@DocPassword where DR_Id=" + drid;
                cmd = new SqlCommand(csu, con);
                cmd.Parameters.AddWithValue("@DocPassword", DocPassword);
                cmd.ExecuteNonQuery();
                con.Close();
                this.Context.Response.ContentType = "application/json;";
                this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
            }
            else
            {
                this.Context.Response.ContentType = "application/json;";
                this.Context.Response.Write(serializer.Serialize(new { data = "false" }));

            }
        }

        //Add OPD

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddOPD(string did, string OpdDate, string OpdTimeFrom, string OpdTimeTo)
        {
            con.Open();
            string cs = "insert into Manage_OPD_Master(D_Id,O_P_Date,Op_Time_From,Op_Time_To,Op_Status,Op_Date) values(@did,@OpdDate,@OpdTimeFrom,@OpdTimeTo,@opstatus,@opdate)";
            //string csu = "update Manage_OPD_Master set D_Id=@did,O_P_Date=@OpdDate,Op_Time_From=@OpdTimeFrom,Op_Time_To=@OpdTimeTo where Op_Id=" + opid;
            cmd = new SqlCommand(cs, con);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@OpdDate", OpdDate);
            cmd.Parameters.AddWithValue("@OpdTimeFrom", OpdTimeFrom);
            cmd.Parameters.AddWithValue("@OpdTimeTo", OpdTimeTo);
            cmd.Parameters.AddWithValue("@opstatus", "Active");
            cmd.Parameters.AddWithValue("@opdate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //View OPD By Id 

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getOPdById(String D_Id, DateTime OPDDate)
        {
            string opd = OPDDate.ToString("MM/dd/yyyy");
            string ds = "select * from Manage_OPD_Master where D_Id = " + D_Id + "and O_P_Date='" + opd + "'";
            cmd.CommandText = ds;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }
        //Update OPD

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateOPD(string did, string OpdTimeFrom, string OpdTimeTo, string opid)
        {
            con.Open();
            //string cs = "insert into Category_Master(C_Title,C_Status,C_Date) values(@ctitle,@cstatus,@cdate)";
            string csu = "update Manage_OPD_Master set D_Id=@did,O_P_Date=@OpdDate,Op_Time_From=@OpdTimeFrom,Op_Time_To=@OpdTimeTo where Op_Id=" + opid;
            cmd = new SqlCommand(csu, con);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@OpdDate", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@OpdTimeFrom", OpdTimeFrom);
            cmd.Parameters.AddWithValue("@OpdTimeTo", OpdTimeTo);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //Delete OPD
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteOPD(string opid, string opstatus)
        {
            con.Open();
            //string cs = "insert into Category_Master(C_Title,C_Status,C_Date) values(@ctitle,@cstatus,@cdate)";
            string csu = "update Manage_OPD_Master set Op_Status=@opstatus where Op_Id=" + opid;
            cmd = new SqlCommand(csu, con);
            cmd.Parameters.AddWithValue("@opstatus", "Deleted");
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //View Notification

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getNotification()
        {
            string cs = "select * from Notification_Master";
            cmd.CommandText = cs;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();

            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }

        //Add Notification

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddNotification(string NUserId, string NUserType, string NType, string NTitle, string NMessage)
        {
            con.Open();
            string cs = "insert into Notification_Master(N_U_Id,N_U_Type,N_Type,N_Title,N_Message,N_Status,N_Date) values(@NUserId,@NUserType,@NType,@NTitle,@NMessage,@Nstatus,@Ndate)";
            //string csu = "update Manage_OPD_Master set D_Id=@did,O_P_Date=@OpdDate,Op_Time_From=@OpdTimeFrom,Op_Time_To=@OpdTimeTo where Op_Id=" + opid;
            cmd = new SqlCommand(cs, con);
            cmd.Parameters.AddWithValue("@NUserId", NUserId);
            cmd.Parameters.AddWithValue("@NUserType", NUserType);
            cmd.Parameters.AddWithValue("@NType", NType);
            cmd.Parameters.AddWithValue("@NTitle", NTitle);
            cmd.Parameters.AddWithValue("NMessage", NMessage);
            cmd.Parameters.AddWithValue("@Nstatus", "Active");
            cmd.Parameters.AddWithValue("@Ndate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //View Transactions

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getTransactions()
        {
            string pay = "select * from  Transactions_Master";
            cmd.CommandText = pay;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt);
            con.Close();
            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rd.Add(row);
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void doctorLogin(string dEmail, string dPassword)
        {
            con.Open();
            string cs = "select COUNT(*) from Doctor_Master where DR_Email=@demail and DR_Password=@dpassword and Dr_Status='Active'";
            cmd = new SqlCommand(cs, con);
            cmd.Parameters.AddWithValue("@demail", dEmail);
            cmd.Parameters.AddWithValue("@dpassword", dPassword);
            //cmd.Parameters.AddWithValue("@cdate", System.DateTime.Now);
            //cmd.ExecuteNonQuery();
            int dc1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            con.Open();
            if (dc1 == 1)
            {
                string cs1 = "select * from Doctor_Master where DR_Email=@demail";
                cmd.CommandText = cs1;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.Connection = con;
                da.Fill(dt);
                con.Close();
                //rd = new List<Dictionary<string, object>>();
                Dictionary<string, object> row = null;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        row.Add(dc.ColumnName, dr[dc]);
                    }
                    rd.Add(row);
                }
            }
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = rd, status = dc1 }));
        }
    }
}
