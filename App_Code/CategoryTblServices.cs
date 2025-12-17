using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NTier.Model;
using NTier.ResponseMessages;
using Database.conction;
using System.Data;
/// <summary>
/// Summary description for CategoryTblServices
/// </summary>
/// 

namespace NTier.CategoryTblServices
{
    public interface ICategoryTblService
    {
        string InsertCategoryTbl(CategoryTblModel model);

        Dictionary<string, object> GetList();

        string DeleteCategory(int Id);

        Dictionary<string, object> GetById(int Id);

        string UpdateCategoryTbl(int Id, CategoryTblModel model);


    }

    public class CategorTblservice : ICategoryTblService, IDisposable
    {
        private readonly DbConnaction db;
        public CategorTblservice()
        {
            db = new DbConnaction();
        }
        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }


        //______________________________________________________________________________________________ 1.start :- Insert CategoryTbl
        public string InsertCategoryTbl(CategoryTblModel model)
        {

            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.InsertUpdate("SPCategoryTblInsertUpdate",
                new Dictionary<string, object>() {


            { "@Cat", model.Category},
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
        // ________________________________________________________________________________________________1.End :- Insert CategoryTbl


        //_______________________________________________________________________________ 2.start :- select CategoryTbl show gridview/manage


        public Dictionary<string, object> GetList()
        {
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

        //_______________________________________________________________________________ 2.end :- select CategoryTbl show gridview/manage


        //Start_____________________________________________________________________________________________3.Delete Category

        public string DeleteCategory(int Id)
        {
            //throw new NotImplementedException();

            if (Id == 0)
            {
                return Messages.IdIsZero;
            }

            var ResponseDict = db.Delete("SPCategoryDelete", new Dictionary<string, object>() {
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


        //End______________________________________________________________________________________________3.Delete Category



        //Start_____________________________________________________________________________________________4.Edit Category Using GetById

        public Dictionary<string , object> GetById(int Id)
        {
            var ResponseData = db.SelectList("SPCategorySelect", new Dictionary<string, object>()
            {
                {"@catid",Id}
            });

            if (ResponseData.ContainsKey("Data"))
            {
                CategoryTblModel model = new CategoryTblModel();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                    model.Category = dt.Rows[i]["Category"].ToString();
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

        //End_____________________________________________________________________________________________4.Edit Category Using GetById

        //Start_____________________________________________________________________________________________5.Update Category Using GetById


        public string UpdateCategoryTbl(int Id, CategoryTblModel model)
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

            var ResponseDict = db.InsertUpdate("SPCategoryTblInsertUpdate", new Dictionary<string, object>() {

            { "@Cat", model.Category},
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



        //End_____________________________________________________________________________________________5.Update Category Using GetById








    }

}