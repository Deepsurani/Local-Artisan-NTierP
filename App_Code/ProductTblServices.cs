using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using NTier.Model;
using Database.conction;
using NTier.ResponseMessages;
using System.Data;

/// <summary>
/// Summary description for ProductTblServices
/// </summary>
/// 

namespace NTier.ProductTblServices
{

    public interface IProductTblServices
    {
        string InsertProductTbl(ProductTblModel model);

        Dictionary<string, object> GetById(int Id);

        Dictionary<string, object> GetList();

        Dictionary<string, object> GetListSubCategory(int id);

        Dictionary<string, object> GetListSelect(string UserId);

        string DeleteProduct(int Id);

        string UpdateProductTbl(int Id, ProductTblModel model);


     
        Dictionary<string, object> GetListProduct();



        Dictionary<string, object> GetListOrder(string UserId); 
    }

    public class ProductTblServices : IProductTblServices, IDisposable
    {
        private readonly DbConnaction db;

        public ProductTblServices()
        {
            db = new DbConnaction();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();

            db.Dispose();
            GC.SuppressFinalize(this);
        }

        //-----------------------

        // 1. Start :-  Insert Product
        public string InsertProductTbl(ProductTblModel model)
        {
            //throw new NotImplementedException();

            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.InsertUpdate("SPProductTblInsertUpdate", new Dictionary<string, object>() {


                {"@UserId",model.UserId},
                {"@CategoryId",model.CategoryId},
                {"@SubCategoryId",model.SubCategoryId},
                {"@ProductTitle",model.ProductTitle},
                {"@Price",model.Price},
                {"@Description",model.Description},
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
        // 1. End :-  Insert Product


        //2. start :- Category dropdown fill
        public Dictionary<string, object> GetList()
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPCategorySelect");

            if (ResponseData.ContainsKey("Data"))
            {
                List<CategoryTblModel> modelList = new List<CategoryTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new CategoryTblModel()
                    {

                        CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]),
                        Category = dt.Rows[i]["Category"].ToString(),


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
        //2. End :- Category dropdown fill


        //3. start :- SubCategory dropdown fill
        public Dictionary<string, object> GetListSubCategory(int id)
        {
            // throw new NotImplementedException();

            Dictionary<string, object> Inperamerater = new Dictionary<string, object>()
            {
                {"@categoryid",id }
            };
            var ResponseData = db.SelectList("SPSubCategorySelectToCategory", Inperamerater);

            if (ResponseData.ContainsKey("Data"))
            {
                List<SubCategoryTblModel> modelList = new List<SubCategoryTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new SubCategoryTblModel()
                    {

                        SubCategoryId =Convert.ToInt32(dt.Rows[i]["SubCategoryId"].ToString()),
                        SubCategory = dt.Rows[i]["SubCategory"].ToString(),


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
        //3. end :- SubCategory dropdown fill



        // 4. Start :- Select Product ----Edit product
        public Dictionary<string, object> GetById(int Id)
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPProductSelect", new Dictionary<string, object>()
            {
                {"@productid",Id}
            });

            if (ResponseData.ContainsKey("Data"))
            {
                ProductTblModel model = new ProductTblModel();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                  

                     model.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                     model.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                     model.SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]);
                     model.ProductTitle = dt.Rows[i]["ProductTitle"].ToString();
                     model.Price = dt.Rows[i]["Price"].ToString();
                     model.Description = dt.Rows[i]["Description"].ToString();
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

        // 4. End :- Select Product ----Edit product



        // 5.start :- fill grideview Product

        public Dictionary<string, object> GetListSelect(string UserId)
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPProductSelect",new Dictionary<string, object>()
            {
                {"UserId",UserId}
               });

            if (ResponseData.ContainsKey("Data"))
            {
                List<ProductTblModel> modelList = new List<ProductTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new ProductTblModel()
                    {
             
                        ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),

                        //here is the Category and SubCategory use for :- catid and subcateid name print in the manage page/gridview --> bcz alias pass in the inner join

                        Category = dt.Rows[i]["Category"].ToString(),
                        Subcategory = dt.Rows[i]["SubCategory"].ToString(),
                        ProductTitle = dt.Rows[i]["ProductTitle"].ToString(),
                        Price = dt.Rows[i]["Price"].ToString(),
                        Description = dt.Rows[i]["Description"].ToString(),

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

        // 5.end  :- fill gridview product


        // 6. start :- Product Delete
        public string DeleteProduct(int Id)
        {
            // throw new NotImplementedException();

            if (Id == 0)
            {
                return Messages.IdIsZero;
            }

            var ResponseDict = db.Delete("SPProductDelete", new Dictionary<string, object>() {
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

        // 6. end :- Product Delete


        // 7. start :- Product Update 

        public string UpdateProductTbl(int Id, ProductTblModel model)
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

            var ResponseDict = db.InsertUpdate("SPProductTblInsertUpdate", new Dictionary<string, object>() {

                {"@id",Id},
                {"@UserId",model.UserId},
                {"@CategoryId",model.CategoryId},
                {"@SubCategoryId",model.SubCategoryId},
                {"@ProductTitle",model.ProductTitle},
                {"@Price",model.Price},
                {"@Description",model.Description},
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

        // 7. end :- Product Update 



        // 8. Start :- product show in client
        public Dictionary<string, object> GetListProduct()
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPProductSelectShow");
            if (ResponseData.ContainsKey("Data"))
            {
                List<ProductTblModel> modelList = new List<ProductTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new ProductTblModel()
                    {

                     
                        ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),

                        //here is the Category and SubCategory use for :- catid and subcateid name print in the manage page/gridview --> bcz alias pass in the inner join

                        CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]),
                        SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]),
                        ProductTitle = dt.Rows[i]["ProductTitle"].ToString(),
                        Price = dt.Rows[i]["Price"].ToString(),
                        Description = dt.Rows[i]["Description"].ToString(),

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


        // 8. End :- product show in client





        // for the order show in artisian side .....according to user id
        public Dictionary<string, object> GetListOrder(string UserId)
        {
            // throw new NotImplementedException();



            var ResponseData = db.SelectList("SPOrderShow", new Dictionary<string, object>()
           {
             {"@UserId", Convert.ToInt32(UserId)}
          });
            if (ResponseData.ContainsKey("Data"))
            {
                List<ProductTblModel> modelList = new List<ProductTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new ProductTblModel()
                    {
                        OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"]),
                        Billno = dt.Rows[i]["Billno"].ToString(),
                        ProductTitle = dt.Rows[i]["ProductTitle"].ToString(),
                        Price = dt.Rows[i]["Price"].ToString(),
                        Qty = dt.Rows[i]["Qty"].ToString(),
                        Total = dt.Rows[i]["TotalAmount"].ToString()
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


        //-----------------------
    }

}