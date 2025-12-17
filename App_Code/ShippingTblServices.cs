using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NTier.Model;
using NTier.ResponseMessages;
using Database.conction;
using System.Data;

/// <summary>
/// Summary description for ShippingTblServices
/// </summary>
/// 

namespace NTier.ShippingTblServices
{

    public interface IShippingTblService
    {
        string InsertShippingTbl(ShippingTblModel model);

        Dictionary<string, object> GetList();

        Dictionary<string, object>GetListArea(string id);

        Dictionary<string, object> GetListShipping(string uid);
    }


    public class ShippingTblServices : IShippingTblService, IDisposable
    {
        private readonly DbConnaction db;

        public ShippingTblServices()
        {
            db = new DbConnaction();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();

            db.Dispose();
            GC.SuppressFinalize(this);
        }

       // start :- for insert
        public string InsertShippingTbl(ShippingTblModel model)
        {
            //throw new NotImplementedException();

            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.InsertUpdate("SPShippingTblInsert",
                new Dictionary<string, object>()
                {
                  {"@UserId",model.UserId},
                  {"@Name",model.Name},
                  {"@Mobile",model.Mobile},
                  {"@AlternateMobile",model.AlternateMobile},
                  {"@Address",model.Address},
                  {"@Locality",model.Locality},
                  {"@LandMark",model.LandMark},
                  {"@Pincode",model.Pincode},
                  {"@CityId",model.CityId},
                  {"@AreaId",model.AreaId},
                  {"@AddressType",model.AddressType},
                  {"@Status","true"},

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

        // end :- for insert


  

        //2. start :- City dropdown fill
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
        //2. End :- City dropdown fill


        //3. start :- Area dropdown fill
        public Dictionary<string, object> GetListArea(string id)
        {
            // throw new NotImplementedException();

            Dictionary<string, object> Inperamerater = new Dictionary<string, object>()
            {
                {"@cityid",id }
            };
            var ResponseData = db.SelectList("SPAreaSelectToCityy", Inperamerater);

            if (ResponseData.ContainsKey("Data"))
            {
                List<AreaTblModel> modelList = new List<AreaTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new AreaTblModel()
                    {

                        AreaId = Convert.ToInt32(dt.Rows[i]["AreaId"].ToString()),
                        Area = dt.Rows[i]["Area"].ToString(),


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
        //3. end :- Area dropdown fill




        // start :- 4. Shiping data show 
        public Dictionary<string, object> GetListShipping(string uid)
        {
            // throw new NotImplementedException();

            var ResponseData = db.SelectList("SPShippingTblSelect", new Dictionary<string, object>()
            {
                {"@userid",uid}
            });
            if (ResponseData.ContainsKey("Data"))
            {
                List<ShippingTblModel> modelList = new List<ShippingTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new ShippingTblModel()
                    {
                        ShipingId = Convert.ToInt32(dt.Rows[i]["ShipingId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Mobile = dt.Rows[i]["Mobile"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
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

        // End :-4. Shiping data show 

    }



}