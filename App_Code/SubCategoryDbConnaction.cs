using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;



/// <summary>
/// Summary description for SubCategoryDbConnaction
/// </summary>
/// 

namespace Database.SubCategoryConnection
{
    public class SubCategoryDbConnaction : IDisposable
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt;


        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ToString());
            con.Open();
        }

        public SubCategoryDbConnaction()
        {
            mycon();
        }


        // 1.start __________________________ SubCategoryTbl Data Insert


        public Dictionary<string, object> SubCategoryTblInsertUpdate(string SQLStoreProcedure, Dictionary<string, object> InputParameter = null)
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

        // 1.end __________________________ SubCategoryTbl Data Insert


        //2.start__________________________Fill DropDown Category In  SubCategory   AND   SubCategoryTbl Data show (Manage/gridview )

        public Dictionary<string ,object>SelectList(string SQLQuery,Dictionary<string,object>InputParameter=null)
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



        //2.End_____________________________Fill DropDown Category In  SubCategory   AND   SubCategoryTbl Data show (Manage/gridview )



        //3.Start ______________________________________________________________________________________________________________________________SubCategoryTbl Data Delete


        public Dictionary<string, object> SubDelete(string SQLQuery, Dictionary<string, object> InputParameter = null)
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



        //3.End ______________________________________________________________________________________________________________________________SubCategoryTbl Data Delete





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