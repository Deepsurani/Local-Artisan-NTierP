using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Database.conction
{
    public class DbConnaction : IDisposable
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ToString());
            con.Open();
        }
        public DbConnaction()
        {
            mycon();
        }

        //1.start __________________________________________________________________________________________________________CategoryTbl Data Insert

        public Dictionary<string, object> InsertUpdate(string SQLStoreProcedure, Dictionary<string, object> InputParameter = null)
        {

            try
            {
                cmd = new SqlCommand(SQLStoreProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (InputParameter != null)
                {
                    foreach (var item in InputParameter)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                }

                // add outparameter

                SqlParameter retVal = new SqlParameter("@retval", SqlDbType.TinyInt);
                retVal.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(retVal);


                cmd.ExecuteNonQuery();

                // Read retval after execution
                byte retvalValue = Convert.ToByte(cmd.Parameters["@retval"].Value);

                return new Dictionary<string, object>() {

            {"@retval", retvalValue}
        };
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    return new Dictionary<string, object>() {
                        {"IsExecuted" , true}
                    };
                }
                else
                {
                    return new Dictionary<string, object>() {
                        {"IsExecuted" , false}
                    };

                }


            }
            catch (Exception Ex)
            {
                return new Dictionary<string, object>(){
                    {"Error", Ex.Message}
                };

            }

        }

        //1.End __________________________________________________________________________________________________________________CategoryTbl Data Insert

        //2.start _____________________________________________________________________________________________________________CategoryTbl Data show (Manage/gridview )

        public Dictionary<string, object> SelectList(string SQLQuery, Dictionary<string, object> InputParameter = null)
        {

            try
            {
                cmd = new SqlCommand(SQLQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (InputParameter != null)
                {
                    foreach (var item in InputParameter)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return new Dictionary<string, object>() {
                    {"Data" , dt }
                };

            }
            catch (Exception Ex)
            {
                return new Dictionary<string, object>(){
                    {"Error", Ex.ToString()}
                };
            }
        }
        //2.End ______________________________________________________________________________________________________________________________CategoryTbl Data show (Manage/gridview )


        //3.Start ______________________________________________________________________________________________________________________________CategoryTbl Data Delete


        public Dictionary<string, object> Delete(string SQLQuery, Dictionary<string, object> InputParameter = null)
        {
            try
            {
                cmd = new SqlCommand(SQLQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (InputParameter != null)
                {
                    foreach (var item in InputParameter)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    return new Dictionary<string, object>() {
                       // {"Message" , "Successfully Insert Your Data" }
                          {"IsExecuted" , true}
                    };
                }
                else
                {
                    return new Dictionary<string, object>() {
                       // {"Message" , "Something Wrong in Database." }
                          {"IsExecuted" , false}
                    };

                }

            }
            catch (Exception Ex)
            {
                return new Dictionary<string, object>(){
                    {"Error", Ex.ToString()}
                };
            }
        }



        //3.End ______________________________________________________________________________________________________________________________CategoryTbl Data Delete

        // 4. start ______________________________________________________________________________________________________________________for ArtisanTbl 
        //NOTE:- create new con bcz in the artisantbl  --> we use the new userId parameter 
        public Dictionary<string, object> InsertUpdateArt(string SQLStoreProcedure, Dictionary<string, object> InputParameter = null)
        {

            try
            {
                cmd = new SqlCommand(SQLStoreProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (InputParameter != null)
                {
                    foreach (var item in InputParameter)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                }

                // add outparameter

                SqlParameter retVal = new SqlParameter("@retval", SqlDbType.TinyInt);
                retVal.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(retVal);
                SqlParameter newUserId = new SqlParameter("@newUserId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(newUserId);

                cmd.ExecuteNonQuery();

                // Read retval after execution
                byte retvalValue = Convert.ToByte(cmd.Parameters["@retval"].Value);

                return new Dictionary<string, object>() {

            {"@retval", retvalValue}
        };
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    return new Dictionary<string, object>() {
                        {"IsExecuted" , true}
                    };
                }
                else
                {
                    return new Dictionary<string, object>() {
                        {"IsExecuted" , false}
                    };

                }


            }
            catch (Exception Ex)
            {
                return new Dictionary<string, object>(){
                    {"Error", Ex.Message}
                };

            }

        }

        // 4. End ______________________________________________________________________________________________________________________for ArtisanTbl 


        // 5. Start____________________________________ :- GetDataTable :- for product shows

        public Dictionary<string, object> GetDataTable(string SQLStoreProcedure, Dictionary<string, object> InputParameter = null, Dictionary<string, SqlDbType> OutParameter = null)
        {
            try
            {
                cmd = new SqlCommand(SQLStoreProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (InputParameter != null)
                {
                    foreach (var item in InputParameter)

                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                if (OutParameter != null)
                {
                    foreach (var item in OutParameter)
                    {
                        SqlParameter sp = new SqlParameter(item.Key, item.Value);
                        sp.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(sp);
                    }
                }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                var ResponseData = new Dictionary<string, object>() {
                    {"Data", dt }
                };
                if (OutParameter != null)
                {
                    foreach (var item in OutParameter)
                    {
                        ResponseData.Add(item.Key, Convert.ToByte(cmd.Parameters[item.Key].Value.ToString()));
                    }
                }
                return ResponseData;
            }
            catch (Exception Ex)
            {
                return new Dictionary<string, object>() {
                    {"Error", Ex.ToString() }
                };
            }


        }


        // 5. End______________________________________ :- GetDataTable :- for product shows
        public void Dispose()
        {
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Dispose();
            }
            if (da != null)
            {
                da.Dispose();
            }
            if (dt != null)
            {
                dt.Dispose();
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
