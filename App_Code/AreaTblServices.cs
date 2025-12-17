using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NTier.Model;
using NTier.ResponseMessages;
using Database.conction;
using System.Data;

/// <summary>
/// Summary description for AreaTblServices
/// </summary>
/// 

namespace NTier.AreaTblService
{


    public interface IAreaTblServices
    {

        string InsertAreaTbl(AreaTblModel model);

        // this GetList Use for the fill the dropdown on the City in the AreaTbl
        Dictionary<string, object> GetList();

        Dictionary<string, object> GetListSelect();

        string DeleteArae(int Id);

        Dictionary<string, object> GetById(int Id);

        string UpdateAreaTbl(int Id, AreaTblModel model);

    }


    public class AreaTblServices : IAreaTblServices, IDisposable
    {
        private readonly DbConnaction db;

        public AreaTblServices()
        {
            db = new DbConnaction();
        }




        // 1. Start  :- Insert Update

        public string InsertAreaTbl(AreaTblModel model)
        {
            //throw new NotImplementedException();

            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.InsertUpdate("SPAreaTblInsertUpdate",
              new Dictionary<string, object>() {


            { "@CityId", model.CityId},
            { "@Area",model.Area},           
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


        // 1. End  :- Insert Update



        //________________________________ 2.Start  :- Fill DropDown City In  AreaTbl

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
    

        //________________________________________________________ 2.End  :- Fill DropDown City In  AreaTbl




        // 3.Start :- select AreaTbl show gridview/manage

        public Dictionary<string, object> GetListSelect()
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPAreaSelect");
            if (ResponseData.ContainsKey("Data"))
            {
                List<AreaTblModel> modelList = new List<AreaTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new AreaTblModel()
                    {
                        AreaId = Convert.ToInt32(dt.Rows[i]["AreaId"]),
                        CityId = Convert.ToInt32(dt.Rows[i]["CityId"]),
                        Area = dt.Rows[i]["Area"].ToString(),          
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

        // 3.End :- select AreaTbl show gridview/manage



        //  4. Start :-  Delete Area

        public string DeleteArae(int Id)
        {
            //throw new NotImplementedException();

            if (Id == 0)
            {
                return Messages.IdIsZero;
            }

            var ResponseDict = db.Delete("SPAreaDelete", new Dictionary<string, object>() {
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

        //  4. End :-  Delete Area



        //5. Start :- Edit Area Using GetById

        public Dictionary<string, object> GetById(int Id)
        {
            //throw new NotImplementedException();

            

            var ResponseData = db.SelectList("SPAreaSelect", new Dictionary<string, object>()
            {
                {"@areaid",Id}

            });

            if (ResponseData.ContainsKey("Data"))
            {
                AreaTblModel model = new AreaTblModel();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.AreaId = Convert.ToInt32(dt.Rows[i]["AreaId"]);
                    model.CityId = Convert.ToInt32(dt.Rows[i]["CityId"].ToString());
                    model.Area = dt.Rows[i]["Area"].ToString();                
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

    //5. End :- Edit Area Using GetById



    //6. Start :- Update Area

    public string UpdateAreaTbl(int Id, AreaTblModel model)
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

            var ResponseDict = db.InsertUpdate("SPAreaTblInsertUpdate", new Dictionary<string, object>() {

            { "@cityid", model.CityId},
             { "@Area", model.Area},          
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

        public void Dispose()
        {
            //throw new NotImplementedException();

            db.Dispose();
            GC.SuppressFinalize(this);
        }

        //6. End :- Update Area














    }



}