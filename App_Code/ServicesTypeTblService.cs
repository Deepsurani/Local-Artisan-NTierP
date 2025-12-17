using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NTier.Model;
using NTier.ResponseMessages;
using Database.conction;
using System.Data;

/// <summary>
/// Summary description for ServicesTypeTblService
/// </summary>
/// 

namespace NTier.ServiceTypeTblServices
{
   

    public interface IServiceTypeTblService
    {
        string InsertServicesTypeTbl(ServiceTypeTblModel model);


        Dictionary<string, object> GetList();


        string DeleteServiceType(int Id);

        Dictionary<string, object> GetById(int Id);

        string UpdateServiceTypeTbl(int Id, ServiceTypeTblModel model);

    }
  

    public class ServicesTypeTblService : IServiceTypeTblService, IDisposable
    {
        private readonly DbConnaction db;
       public ServicesTypeTblService()
        {
            db = new DbConnaction();
        }

        //_______________________________1.Start :- Insert ServiceTypeTbl

        public string InsertServicesTypeTbl(ServiceTypeTblModel model)
        {
            //throw new NotImplementedException();

            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.InsertUpdate("SPServiceTypeTblInsertUpdate",
                new Dictionary<string, object>() {


            { "@ServiceType", model.ServicesType},
            { "@Icon", model.Icon},
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

        //_______________________________1.End :- Insert ServiceTypeTbl

        //_____________________________ 2.start :- select ServiceTypeTbl show gridview/manage

        public Dictionary<string, object> GetList()
        {
            // throw new NotImplementedException();

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
                        Icon = dt.Rows[i]["Icon"].ToString(),
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
        //_____________________________ 2.end :- select ServiceTypeTbl show gridview/manage


        //Start_________________________3.Delete Service Type

        public string DeleteServiceType(int Id)
        {
            // throw new NotImplementedException();

            if (Id == 0)
            {
                return Messages.IdIsZero;
            }

            var ResponseDict = db.Delete("SPServicesTypeDelete", new Dictionary<string, object>() {
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

        //End_________________________3.Delete Service Type



        //Start_______________________4.Edit ServiceType Using GetById

        public Dictionary<string, object> GetById(int Id)
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPServiceTypeSelect", new Dictionary<string, object>()
            {
                {"@servicetypeid",Id}
            });

            if (ResponseData.ContainsKey("Data"))
            {
                ServiceTypeTblModel model = new ServiceTypeTblModel();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.ServicesTypeId = Convert.ToInt32(dt.Rows[i]["ServicesTypeId"]);
                    model.ServicesType = dt.Rows[i]["ServicesType"].ToString();
                    model.Icon = dt.Rows[i]["Icon"].ToString();
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


        //End_______________________4.Edit ServiceType Using GetById


        //Start__________________________5.Update Service Type Using GetById

        public string UpdateServiceTypeTbl(int Id, ServiceTypeTblModel model)
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

            var ResponseDict = db.InsertUpdate("SPServiceTypeTblInsertUpdate", new Dictionary<string, object>() {


            { "@ServiceTYpe", model.ServicesType},
            { "@Icon", model.Icon},
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

        //End__________________________5.Update Service Type Using GetById







        public void Dispose()
        {
            //throw new NotImplementedException();

            db.Dispose();
            GC.SuppressFinalize(this);
        }

     

     

    
    }

}