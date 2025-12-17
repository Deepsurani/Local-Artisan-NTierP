using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using NTier.Model;
using NTier.ResponseMessages;
using Database.conction;
using System.Data;

/// <summary>
/// Summary description for CartTblServices
/// </summary>
/// 
namespace NTier.CartTblServices
{

    public interface ICartTblService
    {
        string InsertCartTbl(CartTblModel model);

        Dictionary<string, object> GetListCartProduct(string uid);

        string DeleteCart(int Id);

        string UpdateCart(int Id,int Qty);
    }

    public class CartTblServices : ICartTblService, IDisposable
    {
        private readonly DbConnaction db;
        public CartTblServices()
        {
            db = new DbConnaction();
        }
        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }

     

        public string InsertCartTbl(CartTblModel model)
        {
            string UniqeId = "";
            UniqeId = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

            //throw new NotImplementedException();

            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.InsertUpdate("SPCartTblInsert",
                new Dictionary<string, object>() {


                    //{ "@Cat", model.Category},
                    //{ "@Icon", model.Icon},
                    //{"@Status", model.Status},

                   
                    {"@UniquId",UniqeId},
                    {"@UserId",model.UserId },
                    {"@ProductId",model.ProductId },
                    {"@Qty",model.Qty },
                    {"@CustomData",model.CustomData},


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


        // start :- cart product show
        public Dictionary<string, object> GetListCartProduct(string uid)
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPCartProductSelectShow",new Dictionary<string, object>()
            {
                {"@userid",uid}
            });
            if (ResponseData.ContainsKey("Data"))
            {
                List<CartTblModel> modelList = new List<CartTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new CartTblModel()
                    {
                        ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]),
                        //here is the Category and SubCategory use for :- catid and subcateid name print in the manage page/gridview --> bcz alias pass in the inner join

                        //CartId = Convert.ToInt32(dt.Rows[i]["CartId"]),
                        //UniqeId = Convert.ToInt32(dt.Rows[i]["UniqeId"]),
                        Qty = Convert.ToInt32(dt.Rows[i]["Qty"].ToString()),
                        //CustomData = dt.Rows[i]["CustomData"].ToString(),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        Price = Convert.ToInt32(dt.Rows[i]["Price"]),
                        Photo1 = dt.Rows[i]["Photo1"].ToString(),
                        total = Convert.ToInt32(dt.Rows[i]["total"]),




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


        // start :- cart product show




        // Start :- Cart Product Delete

        public string DeleteCart(int Id)
        {
            //throw new NotImplementedException();

            if (Id == 0)
            {
                return Messages.IdIsZero;
            }

            var ResponseDict = db.Delete("SPCartProductDelete", new Dictionary<string, object>() {
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



        // End :- Cart Product Delete



        // start :- Cart Product Qty Update

        public string UpdateCart(int Id, int Qty)
        {
            if (Id == 0)
            {
                return Messages.IdIsZero;
            }

            var ResponseDict = db.InsertUpdate("SPUpdateCartQty",
                new Dictionary<string, object>()
                {
            {"@id", Id},
            {"@qty", Qty}
                });

            if (ResponseDict.ContainsKey("@retval"))
            {
                if (Convert.ToInt32(ResponseDict["@retval"]) == 2)
                {
                    return Messages.Updated;
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

        // End :- Cart Product Qty Update
    }

}