using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NTier.Model;
using Database.conction;
using NTier.ResponseMessages;
using System.Data;


/// <summary>
/// Summary description for ServicesTblServices
/// </summary>
/// 

namespace NTier.ServicesTblServices
{

    public interface IServicesTblServices
    {
        string InsertServicesTbl(ServicesTblModel model);
        Dictionary<string, object> GetList();

        //for griedview
        Dictionary<string, object> GetListSelect(string UserId);

        string DeleteServices(int Id);

        Dictionary<string, object> GetById(int Id);

        string UpdateServicesTbl(int Id, ServicesTblModel model);

        Dictionary<string, object> GetListServices();
    }

    public class ServicesTblServices : IServicesTblServices,IDisposable
    {
        private readonly DbConnaction db;

        public ServicesTblServices()
        {
            db = new DbConnaction();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();

            db.Dispose();
            GC.SuppressFinalize(this);
        }


        // 1. Start :-  Fill DropDown(SErvicesType) in ServicesTbl
        public Dictionary<string, object> GetList()
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPServiceTypeSelect");

            if (ResponseData.ContainsKey("Data"))
            {
                List<ServiceTypeTblModel> modelList = new List<ServiceTypeTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new ServiceTypeTblModel()
                    {

                        ServicesTypeId = Convert.ToInt32(dt.Rows[i]["ServicesTypeId"]),
                        ServicesType = dt.Rows[i]["ServicesType"].ToString(),


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

        // 1. end :-  Fill DropDown(SErvicesType) in ServicesTbl


        // 2. Start :-  Insert Services
        public string InsertServicesTbl(ServicesTblModel model)
        {
            //throw new NotImplementedException();

            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.InsertUpdate("SPServicesTblInsertUpdate", new Dictionary<string, object>() {


                {"@UserId",model.UserId},            
                {"@ServicesTypeId",model.ServicesTypeId},
                {"@ServiceTitle",model.ServiceTitle},
                {"@ServicesEstimatePrice",model.ServicesEstimatePrice},
                {"@ServicesDescription",model.ServicesDescription},
                {"@Photo1",model.Photo1},
                {"@Photo2",model.Photo2},
                {"@Photo3",model.Photo3},
                {"@Photo4",model.Photo4},
                {"@Photo5",model.Photo5},
                {"@Ve", model.IsVerified},
                {"@Ac", model.IsActive}

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
        // 2. End :-  Insert Services


        // 3. Start :-  fill gridview :- using getlist

        public Dictionary<string, object> GetListSelect(string UserId)
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPServicesSelect", new Dictionary<string, object>()
            {
                {"UserId",UserId}
               });

            if (ResponseData.ContainsKey("Data"))
            {
                List<ServicesTblModel> modelList = new List<ServicesTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new ServicesTblModel()
                    {

                        ServicesId = Convert.ToInt32(dt.Rows[i]["ServicesId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),

                        //here is the Services use for :- sid  name print in the manage page/gridview --> bcz alias pass in the inner join

                        ServicesType= dt.Rows[i]["ServicesType"].ToString(),
                       
                        ServiceTitle = dt.Rows[i]["ServiceTitle"].ToString(),
                        ServicesEstimatePrice = dt.Rows[i]["ServicesEstimatePrice"].ToString(),
                        ServicesDescription = dt.Rows[i]["ServicesDescription"].ToString(),

                        Photo1 = dt.Rows[i]["Photo1"].ToString(),
                        Photo2 = dt.Rows[i]["Photo2"].ToString(),
                        Photo3 = dt.Rows[i]["Photo3"].ToString(),
                        Photo4 = dt.Rows[i]["Photo4"].ToString(),
                        Photo5 = dt.Rows[i]["Photo5"].ToString(),

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


        // 3. End :-  fill gridview :- using getlist

        // 4. Start :- Delete Services

        public string DeleteServices(int Id)
        {
            //throw new NotImplementedException();

            if (Id == 0)
            {
                return Messages.IdIsZero;
            }

            var ResponseDict = db.Delete("SPServicesDelete", new Dictionary<string, object>() {
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




        // 4. End :- Delete Services

        // 5 . Start :- Edit fill Services
        public Dictionary<string, object> GetById(int Id)
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPServicesSelect", new Dictionary<string, object>()
            {
                {"@servicesid",Id}
            });

            if (ResponseData.ContainsKey("Data"))
            {
                ServicesTblModel model = new ServicesTblModel();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    model.ServicesId = Convert.ToInt32(dt.Rows[i]["ServicesId"]);
                    model.ServicesTypeId = Convert.ToInt32(dt.Rows[i]["ServicesTypeId"]);
                 
                    model.ServiceTitle = dt.Rows[i]["ServiceTitle"].ToString();
                    model.ServicesEstimatePrice = dt.Rows[i]["ServicesEstimatePrice"].ToString();
                    model.ServicesDescription = dt.Rows[i]["ServicesDescription"].ToString();
                    model.Photo1 = dt.Rows[i]["Photo1"].ToString();
                    model.Photo2 = dt.Rows[i]["Photo2"].ToString();
                    model.Photo3 = dt.Rows[i]["Photo3"].ToString();
                    model.Photo4 = dt.Rows[i]["Photo4"].ToString();
                    model.Photo5 = dt.Rows[i]["Photo5"].ToString();
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




        // 5 . End :- Edit fill Services

        // 6.Start :- Update Services

        public string UpdateServicesTbl(int Id, ServicesTblModel model)
        {
            // throw new NotImplementedException();

            if (Id == 0)
            {
                return Messages.IdIsZero;
            }
            if (model == null)
            {
                return Messages.ModelIsNull;
            }

            var ResponseDict = db.InsertUpdate("SPServicesTblInsertUpdate", new Dictionary<string, object>() {

                {"@id",Id},
                {"@UserId",model.UserId},
                {"@ServicesTypeId",model.ServicesTypeId},
              
                {"@ServiceTitle",model.ServiceTitle},
                {"@ServicesEstimatePrice",model.ServicesEstimatePrice},
                {"@ServicesDescription",model.ServicesDescription},
                {"@Photo1",model.Photo1},
                {"@Photo2",model.Photo2},
                {"@Photo3",model.Photo3},
                {"@Photo4",model.Photo4},
                {"@Photo5",model.Photo5},

                // NOTE :- Agar value null ho to default "0" le, taaki SQL error na aaye
                {"@Ve", model.IsVerified ?? "0"},
                {"@Ac", model.IsActive ?? "0"}

            });

            byte retval = Convert.ToByte(ResponseDict["@retval"]);

            if (retval == 2)
                return Messages.Updated;
            else if (retval == 1)
                return Messages.AlreadyExistCategory;
            else
                return Messages.SomethingWrong;
        }


        // 6.End :- Update Services


        //  8. Start :- services show in client

        public Dictionary<string, object> GetListServices()
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPServicesSelectShow");
            if (ResponseData.ContainsKey("Data"))
            {
                List<ServicesTblModel> modelList = new List<ServicesTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new ServicesTblModel()
                    {


                        ServicesId = Convert.ToInt32(dt.Rows[i]["ServicesId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),

                        //here is the Category and SubCategory use for :- catid and subcateid name print in the manage page/gridview --> bcz alias pass in the inner join

                        ServicesTypeId = Convert.ToInt32(dt.Rows[i]["ServicesTypeId"]),
                   
                        ServiceTitle = dt.Rows[i]["ServiceTitle"].ToString(),
                        ServicesEstimatePrice = dt.Rows[i]["ServicesEstimatePrice"].ToString(),
                        ServicesDescription = dt.Rows[i]["ServicesDescription"].ToString(),

                        Photo1 = dt.Rows[i]["Photo1"].ToString(),
                        Photo2 = dt.Rows[i]["Photo2"].ToString(),
                        Photo3 = dt.Rows[i]["Photo3"].ToString(),
                        Photo4 = dt.Rows[i]["Photo4"].ToString(),
                        Photo5 = dt.Rows[i]["Photo5"].ToString(),



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

        //  8. End :- services show in client
    }
}