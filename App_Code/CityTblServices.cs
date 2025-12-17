using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NTier.Model;
using Database.conction;
using NTier.ResponseMessages;
using System.Data;

/// <summary>
/// Summary description for CityTblServices
/// </summary>
/// 

namespace NTier.CityTblServices
{

    public interface ICityTblServices
    {
        string InsertCityTbl(CityTblModel model);

        Dictionary<string, object> GetList();

        string DeleteCity(int Id);

        Dictionary<string, object> GetById(int Id);

        string UpdateCityTbl(int Id, CityTblModel model);
    }


    public class CityTblServices : ICityTblServices, IDisposable
    {

        private readonly DbConnaction db;

        public CityTblServices()
        {
            db = new DbConnaction();
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }

        // 1.start ________________________________Insert City

        public string InsertCityTbl(CityTblModel model)
        {
            //throw new NotImplementedException();

            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.InsertUpdate("SPCityTblInsertUpdate",
                new Dictionary<string, object>() {


            { "@City", model.City},        
            {"@Status", model.Status},
                });


            // Get retval
            byte retval = Convert.ToByte(ResponseDict["@retval"]);

            if (retval == 0)
                return Messages.Inserted;
            else if (retval == 1)
                return Messages.AlreadyExistCategory;
            else
                return Messages.SomethingWrong;


        }

        // 1.start _________________________________Insert City
        
          

        // 2.start _______________ select CityTbl show gridview/manage

        public Dictionary<string, object> GetList()
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPCitySelect");
            if (ResponseData.ContainsKey("Data"))
            {
                List<CityTblModel> modelList = new List<CityTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new CityTblModel()
                    {

                        CityId = Convert.ToInt32(dt.Rows[i]["CityId"]),
                        City = dt.Rows[i]["City"].ToString(),                    
                        Status = dt.Rows[i]["Status"].ToString(),

                    });
                }
                return new Dictionary<string, object>() {
                    {"Data",modelList}
                };
            }
            else
            {
                return new Dictionary<string, object>()
                {
                        {"Error", ResponseData["Error"]}
                };
            }




        }

        // 2.end _______________ select CityTbl show gridview/manage



        //3.Start_________________Delete City

        public string DeleteCity(int Id)
        {
            //throw new NotImplementedException();

            if (Id == 0)
            {
                return Messages.IdIsZero;
            }

            var ResponseDict = db.Delete("SPCityDelete", new Dictionary<string, object>() {
                {"@id",Id},
            });

            if (ResponseDict.ContainsKey("IsExecuted"))
            {
                if (Convert.ToBoolean(ResponseDict["IsExecuted"]) == true)
                {
                    return Messages.Delete;
                }
                else
                {
                    return Messages.SomethingWrong;
                }
            }
            else
            {
                return ResponseDict["Error"].ToString();
            }
        }

        //3.end_________________Delete City



        //4.Start_________________Edit City Using GetById

        public Dictionary<string, object> GetById(int Id)
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPCitySelect", new Dictionary<string, object>()
            {
                {"@cityid",Id}
            });

            if (ResponseData.ContainsKey("Data"))
            {
                CityTblModel model = new CityTblModel();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.CityId = Convert.ToInt32(dt.Rows[i]["CityId"]);
                    model.City = dt.Rows[i]["City"].ToString();           
                    model.Status = dt.Rows[i]["Status"].ToString();

                }
                return new Dictionary<string, object>
                {
                    {"Data",model }
                };


            }

            else
            {
                return new Dictionary<string, object>()
                {
                        {"Error", ResponseData["Error"]}
                };
            }

        }

        //4.end_________________Edit City Using GetById



        //5.Start_________________Update City 

        public string UpdateCityTbl(int Id, CityTblModel model)
        {
            //throw new NotImplementedException();

            if (Id == 0)
            {
                return Messages.IdIsZero;
            }
            if (model == null)
            {
                return Messages.ModelIsNull;
            }

            var ResponseDict = db.InsertUpdate("SPCityTblInsertUpdate", new Dictionary<string, object>() {

            { "@City", model.City},
            {"@Status", model.Status},
            {"@id",Id},
            });

            byte retval = Convert.ToByte(ResponseDict["@retval"]);

            if (retval == 2)
                return Messages.Updated;
            else if (retval == 1)
                return Messages.AlreadyExistCategory;
            else
                return Messages.SomethingWrong;
        }

       

        //5.end_________________Update City 










    }




}