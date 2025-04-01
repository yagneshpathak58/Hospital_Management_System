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
    /// Summary description for PatientMaster
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PatientMaster : System.Web.Services.WebService
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HMSCn"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}

        //get Method is Use For View,post Method is Used For Insert,put Method is Use For Update.......

        //View All Category

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getCategory()
        {
            string cs = "select * from Category_Master where C_Status='Active'";
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

        //View All Doctor

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDoctor()
        {
            string ds = "select * from Doctor_Master where DR_Status='Active'";
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getTopDoctor()
        {
            string ds = "select TOP 5* from Doctor_Master, Category_Master where Doctor_Master.DR_Status='Active' and Doctor_Master.C_ID=Category_Master.C_ID order by Dr_ID desc";
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

        //View Doctor by CategoryId

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDoctorByCategory(String C_ID)
        {
            string ds = "select * from Doctor_Master where C_ID = " + C_ID;
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

        // View Single Doctor By Doctor Id

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDoctorByDocid(String DR_Id)
        {
            //string ds = "select * from Doctor_Master where DR_Id = " + DR_Id;
            string ds = "select * from Doctor_Master d , Category_Master c where d.DR_Id=" + DR_Id + " and c.C_ID=d.C_ID ";
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

        //View Appointment

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAppointment(string pid)
        {
            string ap = "select * from Appointment_Master, Doctor_Master where Appointment_Master.D_ID=Doctor_Master.Dr_ID and Appointment_Master.P_ID="+pid;
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

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void getAppointmentByDocId(String D_ID)
        //{
        //    string ap = "select * from Appointment_Master where D_ID = " + D_ID;
        //    cmd.CommandText = ap;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.SelectCommand.Connection = con;
        //    da.Fill(dt);
        //    con.Close();
        //    List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
        //    Dictionary<string, object> row = null;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        row = new Dictionary<string, object>();
        //        foreach (DataColumn dc in dt.Columns)
        //        {
        //            row.Add(dc.ColumnName, dr[dc]);
        //        }
        //        rd.Add(row);
        //    }
        //    this.Context.Response.ContentType = "application/json;";
        //    this.Context.Response.Write(serializer.Serialize(new { data = rd }));
        //}

        //View Appointment By PatientId

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAppointmentByPatientId(String P_ID)
        {
            string ap = "select * from Appointment_Master where P_ID = " + P_ID;
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
        public void getAppointmentById(String P_A_Id)
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
        //Add Appointment 

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AppointmentCount(string opid)
        {
            con.Open();
            string cs = "select COUNT(*) from Appointment_Master where Op_Id=" + opid;
            cmd = new SqlCommand(cs, con);
            int dc1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = dc1 }));

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddAppointment(string opid, string pid, string did, DateTime opdate, string optime, string dfee)
        {
            con.Open();
            string cs = "insert into Appointment_Master(Op_Id,P_ID,D_ID,P_A_OPD_Date,P_A_OPD_Time,P_A_Status,P_A_Date) values(@opid,@pid,@did,@paopddate,@paopdtime,@pastatus,@padate)";
            //string csu = "update Patient_Master set C_Title=@ctitle,C_Status=@cstatus,C_Date =@cdate where C_ID=" + cid";
            cmd = new SqlCommand(cs, con);
            cmd.Parameters.AddWithValue("@opid", opid);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@paopddate", opdate);
            cmd.Parameters.AddWithValue("@paopdtime", optime);
            cmd.Parameters.AddWithValue("@pastatus", "Active");
            cmd.Parameters.AddWithValue("@padate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();

            //con.Open();
            //string dc = "select COUNT(*) from Doctor_Payment_Master where D_ID=" + did;
            //cmd = new SqlCommand(dc, con);
            //int dc1 = Convert.ToInt32(cmd.ExecuteScalar());

            ////if (dc1 == 1)
            ////{
            ////    int tOpd = 0;
            ////    float total = 0, paid = 0, remain = 0;

            ////    string dp = "update Doctor_Payment_Master set B_D_TotalOPD=" + tOpd + ",B_D_Total=" + total + ",B_D_Paid_Amount=" + paid + ",B_D_Remain_Amount=" + remain + " where D_ID=" + did;
            ////    cmd = new SqlCommand(dp, con);
            ////    cmd.ExecuteNonQuery();
            ////}
            ////else
            ////{
            //string dp = "insert into Doctor_Payment_Master(D_ID,B_D_TotalOPD,B_D_Total,B_D_Paid_Amount,B_D_Remain_Amount,B_D_Date) values(@did,@topd,@ototal,@opaid,@premain,@odate)";
            ////string csu = "update Patient_Master set C_Title=@ctitle,C_Status=@cstatus,C_Date =@cdate where C_ID=" + cid";
            //cmd = new SqlCommand(dp, con);
            //cmd.Parameters.AddWithValue("@did", did);
            //cmd.Parameters.AddWithValue("@topd", "1");
            //cmd.Parameters.AddWithValue("@ototal", dfee);
            //cmd.Parameters.AddWithValue("@opaid", "0");
            //cmd.Parameters.AddWithValue("@premain", dfee);
            //cmd.Parameters.AddWithValue("@odate", System.DateTime.Now);
            //cmd.ExecuteNonQuery();
            ////}
            //con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }


        //View 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getPatient()
        {
            string ap = "select * from Patient_Master";
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

        //View Patient By Patient ID  for Profile
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getPatientByID(String P_Id)
        {
            string ap = "select * from Patient_Master where P_Id = " + P_Id;
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


        //View Bill

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getPatientBill()
        {
            string ap = "select * from Bill_Patient_Master";
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

        //Add Patient  For Registration
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddPatient(string pname, string pcontact, string pemail, string paddress)
        {
            Random ra = new Random();
            string pass = ra.Next(0, 100000).ToString();

            con.Open();
            string cs = "insert into Patient_Master(P_Name,P_Contact,P_Email,P_Password,P_Address,P_Status,P_Date) values(@pname,@pcontact,@pemail,@ppassword,@paddress,@pstatus,@pdate)";
            //string csu = "update Patient_Master set C_Title=@ctitle,C_Status=@cstatus,C_Date =@cdate where C_ID=" + cid";
            cmd = new SqlCommand(cs, con);
            cmd.Parameters.AddWithValue("@pname", pname);
            cmd.Parameters.AddWithValue("@pcontact", pcontact);
            cmd.Parameters.AddWithValue("@pemail", pemail);
            cmd.Parameters.AddWithValue("@ppassword", pass);
            cmd.Parameters.AddWithValue("@paddress", paddress);
            cmd.Parameters.AddWithValue("@pstatus", "Active");
            cmd.Parameters.AddWithValue("@pdate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //Add Feedback System
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddFeedbackSystem(string uid, string uttype, string fsubject, string fmessage)
        {
            con.Open();
            string cs = "insert into Patient_Feeedback(U_Id,U_Type,F_Subject,F_Message,F_Status,F_Date) values(@uid,@uttype,@fsubject,@fmessage,@fstatus,@fdate)";
            //string csu = "update Patient_Master set C_Title=@ctitle,C_Status=@cstatus,C_Date =@cdate where C_ID=" + cid";
            cmd = new SqlCommand(cs, con);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@uttype", uttype);
            cmd.Parameters.AddWithValue("@fsubject", fsubject);
            cmd.Parameters.AddWithValue("@fmessage", fmessage);
            //cmd.Parameters.AddWithValue("@fstatus", paddress);
            cmd.Parameters.AddWithValue("@fstatus", "Active");
            cmd.Parameters.AddWithValue("@fdate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //Add Feedback Doctor 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddFeedbackDoctor(string did, string pid, string fdmessage)
        {
            con.Open();
            string cs = "insert into Doctor_FeedBack(D_Id,P_Id,Fd_Message,Fd_Status,Fd_Date) values(@did,@pid,@fdmessage,@fdstatus,@fddate)";
            //string csu = "update Patient_Master set C_Title=@ctitle,C_Status=@cstatus,C_Date =@cdate where C_ID=" + cid";
            cmd = new SqlCommand(cs, con);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@pid", pid);
            //cmd.Parameters.AddWithValue("@fsubject", fsubject);
            cmd.Parameters.AddWithValue("@fdmessage", fdmessage);
            //cmd.Parameters.AddWithValue("@fstatus", paddress);
            cmd.Parameters.AddWithValue("@fdstatus", "Active");
            cmd.Parameters.AddWithValue("@fddate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //Update Patient Profile By Patient Id
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdatePatientProfile(string pname, string pcontact,string paddress, string pid)
        {
            con.Open();
            //string cs = "insert into Patient_Master(P_Name,P_Contact,P_Email,P_Password,P_Address,P_Status,P_Date) values(@pname,@pcontact,@pemail,@ppassword,@paddress,@pstatus,@pdate)";
            string csu = "update Patient_Master set P_Name=@pname,P_Contact=@pcontact,P_Address=@paddress where P_Id=" + pid;
            cmd = new SqlCommand(csu, con);
            cmd.Parameters.AddWithValue("@pname", pname);
            cmd.Parameters.AddWithValue("@pcontact", pcontact);
            //cmd.Parameters.AddWithValue("@pemail", pemail);
            //cmd.Parameters.AddWithValue("@ppassword", ppassword);
            cmd.Parameters.AddWithValue("@paddress", paddress);
            //cmd.Parameters.AddWithValue("@pstatus", "Active");
            //cmd.Parameters.AddWithValue("@pdate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Context.Response.ContentType = "application/json;";
            this.Context.Response.Write(serializer.Serialize(new { data = "true" }));
        }

        //Update Password By Patient Or Change Password

        

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdatePatientPassword(string patPasswordOld, string patPassword, string pid)
        {
            con.Open();
            string ccp = "select COUNT(*) from Patient_Master where P_Id=@pid and P_Password=@ppass and P_Status='Active'";
            cmd = new SqlCommand(ccp, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@ppass", patPasswordOld);
            int cc = Convert.ToInt32(cmd.ExecuteScalar());
            if (cc == 1)
            {
                string csu = "update Patient_Master set P_Password =@ppass where P_Id=" + pid;
                cmd = new SqlCommand(csu, con);
                cmd.Parameters.AddWithValue("@ppass", patPassword);
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
        //View Feeedback By User Id
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFeedBackByUID(String U_Id)
        {
            string ap = "select * from Patient_Master where U_Id = " + U_Id;
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
        //View Feedback By User Type
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFeedBackByUtype(String U_Type)
        {
            string ap = "select * from Patient_Master where U_Type = " + U_Type;
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
        //Patient Login
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void PatientLogin(string pEmail, string pPassword)
        {
            con.Open();
            string cs = "select COUNT(*) from Patient_Master where P_Email=@pemail and P_Password=@ppassword and P_Status='Active'";
            cmd = new SqlCommand(cs, con);
            cmd.Parameters.AddWithValue("@pemail", pEmail);
            cmd.Parameters.AddWithValue("@ppassword", pPassword);
            //cmd.Parameters.AddWithValue("@cdate", System.DateTime.Now);
            //cmd.ExecuteNonQuery();
            int dc1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            List<Dictionary<string, object>> rd = new List<Dictionary<string, object>>();
            con.Open();
            if (dc1 == 1)
            {
                string cs1 = "select * from Patient_Master where P_Email=@pemail";
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

        //View Feeedback By User Id
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getNotificationByUId(String N_U_Id)
        {
            string ap = "select * from Notification_Master where N_U_Id = " + N_U_Id;
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
        //View Feedback By User Type
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getNotificationByUtype(String N_U_Type)
        {
            string ap = "select * from Notification_Master where N_U_Type = " + N_U_Type;
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

    }
}
