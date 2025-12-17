using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using NTier.Model;
using NTier.ResponseMessages;
using Database.conction;
using System.Data;




/// <summary>
/// Summary description for OrderTblServices
/// </summary>
/// 

namespace NTier.OrderTblServices
{
    public interface IOrderTblService
    {
        string InsertOrderTbl(OrderTblModel model);

        Dictionary<string, object> GetListOrderShowAdmin();

        Dictionary<string, object> GetListMyOrderShow(string uid);

        Dictionary<string, object> GetOrderDetailsByBill(string billNo);


    }
    public class OrderTblServices : IOrderTblService,IDisposable
    {
        private readonly DbConnaction db;

        public OrderTblServices()
        {
            db = new DbConnaction();
        }


        public void Dispose()
        {
            //throw new NotImplementedException();

            db.Dispose();
            GC.SuppressFinalize(this);
        }

      


        //______________________________________________________________________________________________ 1.start :- Insert OrderTbl
        public string InsertOrderTbl(OrderTblModel model)
        {
            string BillNoUid = System.DateTime.Now.ToString("yyyymmddhhmmss").ToString();
            
           

            //throw new NotImplementedException();

            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.InsertUpdate("SPOrderTblInsertUpdate",
                new Dictionary<string, object>() {



              {"@Billno",BillNoUid},
              {"@ShipingId",model.ShipingId},
              {"@UserId",model.UserId},
              {"@TotalAmount",model.TotalAmount},
              {"@TotalQty",model.TotalQty},
              {"@Status", model.Status},
              {"@OrderStatus",model.OrderStatus},
              {"@PaymentStatus", model.PaymentStatus},
              {"@PaymentType", model.PaymentType},


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



        //______________________________________________________________________________________________ 1.start :-GetListOrderShowAdmin side

        public Dictionary<string, object> GetListOrderShowAdmin()
        {
            //throw new NotImplementedException();


            var ResponseData = db.SelectList("SPOrderSelect");
            if (ResponseData.ContainsKey("Data"))
            {
                List<OrderTblModel> modelList = new List<OrderTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new OrderTblModel()
                    {

                        OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"]),
                        Billno = dt.Rows[i]["Billno"].ToString(),
                        ProductTitle = dt.Rows[i]["ProductTitle"].ToString(),
                        Price = dt.Rows[i]["TotalAmount"].ToString(),
                        PaymentStatus = dt.Rows[i]["PaymentStatus"].ToString(),
                        PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                      

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



        //______________________________________________________________________________________________ 1.sendtart :-GetListOrderShowAdmin side


        //______________________________________________________________________________________________ 2.start :-GetListMyOrderShow side

        public Dictionary<string, object> GetListMyOrderShow(string uid)
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPOrderShow", new Dictionary<string, object>()
            {
                  {"@userid",uid}
            });
            if (ResponseData.ContainsKey("Data"))
            {
                List<OrderTblModel> modelList = new List<OrderTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new OrderTblModel()
                    {
                        OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"]),
                        Billno = dt.Rows[i]["BillNo"].ToString(),
                        TotalQty = dt.Rows[i]["TotalQty"].ToString(),
                        TotalAmount = dt.Rows[i]["TotalAmount"].ToString(),
                        PaymentStatus = dt.Rows[i]["PaymentStatus"].ToString(),
                        PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                  
                        ProductTitle = dt.Rows[i]["Products"].ToString()
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



        //______________________________________________________________________________________________ 2.end :-GetListMyOrderShow side



        // for billing


        public Dictionary<string, object> GetOrderDetailsByBill(string billNo)
        {
            // throw new NotImplementedException();

            var ResponseData = db.SelectList("SPOrderShowInvoice", new Dictionary<string, object>()
    {
        {"@billno", billNo}
    });

            if (ResponseData.ContainsKey("Data"))
            {
                List<OrderTblModel> list = new List<OrderTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(new OrderTblModel()
                    {
                        OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"]),
                        Billno = dt.Rows[i]["Billno"].ToString(),
                        TotalQty = dt.Rows[i]["TotalQty"].ToString(),
                        TotalAmount = dt.Rows[i]["TotalAmount"].ToString(),
                        PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                        PaymentStatus = dt.Rows[i]["PaymentStatus"].ToString(),
                        //EntryDate = dt.Rows[i]["EntryDate"].ToString(),
                        ProductTitle = dt.Rows[i]["ProductNames"].ToString(),
                       // Price = dt.Rows[i]["Price"].ToString()

                        
                        CusttName = dt.Rows[i]["ShippingName"].ToString(),
                        CustMobile = dt.Rows[i]["ShippingMobile"].ToString(),
                        CusttAddress = dt.Rows[i]["ShippingFullAddress"].ToString(),
                    });
                }
                return new Dictionary<string, object>() { { "Data", list } };
            }

            return new Dictionary<string, object>() { { "Error", ResponseData["Error"] } };
        }

        // for billing








    }




}