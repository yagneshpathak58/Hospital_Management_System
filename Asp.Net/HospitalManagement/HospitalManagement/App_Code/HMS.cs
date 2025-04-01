using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace HospitalManagement.App_Code
{
    public class HMS
    {
        public int ExecuteNonQuerySP(string sp, SortedList sl)
        {
            String constr = System.Configuration.ConfigurationManager.ConnectionStrings["HMSCn"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand(sp, con);
            int result = 0;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;

                for (int x = 0; x <= sl.Count - 1; x++)
                {
                    cmd.Parameters.AddWithValue((String)sl.GetKey(x), sl.GetByIndex(x));
                }

                con.Open();


                result = cmd.ExecuteNonQuery();


                con.Close();
            }
            catch (Exception ex)
            {
                result = -1;
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception ex2)
                {
                    // ErrHandler.WriteError(ex2.ToString());
                }
                // ErrHandler.WriteError(ex.ToString());
            }
            return result;
        }


        public Object ExecuteScalarSP(String sp, SortedList sl)
        {
            String constr = System.Configuration.ConfigurationManager.ConnectionStrings["HMSCn"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sp, con);
            Object result = null;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < sl.Count; i++)
                    cmd.Parameters.AddWithValue((String)sl.GetKey(i), sl.GetByIndex(i));


                con.Open();
                result = cmd.ExecuteScalar();
                //myConnection.Close();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                // ErrHandler.WriteError(ex.ToString());
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return result;
        }


        public SqlDataReader GetDataReaderSP(string sSQL, SortedList paramList)
        {
            String constr = System.Configuration.ConfigurationManager.ConnectionStrings["HMSCn"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand(sSQL, con);
            SqlDataReader dr;
            int x;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (x = 0; x <= paramList.Count - 1; x++)
                {
                    cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
                }
                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

            catch (Exception ex)
            {
                //	websurveytool.ErrHandler.WriteError(ex.ToString);
                return null;
            }

            // Return the datareader result
            return dr;
        }
    }
}