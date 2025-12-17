using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using NTier.Model;
using NTier.ResponseMessages;
using Database.SubCategoryConnection;
using System.Data;



/// <summary>
/// Summary description for SubCategoryTblServices
/// </summary>
/// 


namespace NTier.SubCategoryTblService
{

    public interface ISubCategoryTblServices
    {

        string InsertSubCategoryTbl(SubCategoryTblModel model);


        // this GetList Use for the fill the dropdown on the category in the subcategoryTbl
        Dictionary<string, object> GetList();

        Dictionary<string, object> GetListSelect();

        string DeleteSubCategory(int Id);

        Dictionary<string, object> GetById(int Id);

        string UpdateSubCategoryTbl(int Id, SubCategoryTblModel model);

    }




    public class SubCategoryTblServices : ISubCategoryTblServices, IDisposable
    {
        private readonly SubCategoryDbConnaction db;


        public SubCategoryTblServices()
        {
            db = new SubCategoryDbConnaction();
        }



        //_________________________________________________  1.start :- Insert SubCategoryTbl
        public string InsertSubCategoryTbl(SubCategoryTblModel model)
        {
            if (model == null)
            {
                return Messages.ModelIsNull;
            }
            var ResponseDict = db.SubCategoryTblInsertUpdate("SPSubCategoryTblInsertUpdate", new Dictionary<string, object>() {


            { "@CatId", model.CategoryId},
            { "@SubCat", model.SubCategory},
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

        //_________________________________________________  1.End :- Insert SubCategoryTbl



        //_________________________________________________  2.Start  :- Fill DropDown Category In  SubCategory
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
        //_________________________________________________  2.End  :- Fill DropDown Category In  SubCategory

        //_______________________________________________________________________________ 3.start :- select SubCategoryTbl show gridview/manage

        public Dictionary<string, object> GetListSelect()
        {
            var ResponseData = db.SelectList("SPSubCategorySelect");

            if (ResponseData.ContainsKey("Data"))
            {
                List<SubCategoryTblModel> modelList = new List<SubCategoryTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new SubCategoryTblModel()
                    {
                        SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]),
                        CategoryId = dt.Rows[i]["Category"].ToString(),
                        SubCategory = dt.Rows[i]["SubCategory"].ToString(),                      
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


        //_______________________________________________________________________________ 3.End :- select SubCategoryTbl show gridview/manage



        //Start_____________________________________________________________________________________________4.Delete SubCategory

        public string DeleteSubCategory(int Id)
        {
            // throw new NotImplementedException();


            if (Id == 0)
            {
                return Messages.IdIsZero;
            }

            var ResponseDict = db.SubDelete("SPSubCategoryDelete", new Dictionary<string, object>() {
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

        //End_____________________________________________________________________________________________4.Delete SubCategory

        //Start_____________________________________________________________________________________________5.Edit SubCategory Using GetById


        public Dictionary<string, object> GetById(int Id)
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPSubCategorySelect", new Dictionary<string, object> ()
            {
                {"@subcatid",Id}

            });

            if (ResponseData.ContainsKey("Data"))
            {
                SubCategoryTblModel model = new SubCategoryTblModel();
                DataTable dt = ResponseData["Data"] as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]);
                    model.CategoryId = dt.Rows[i]["CategoryId"].ToString();
                    model.SubCategory = dt.Rows[i]["SubCategory"].ToString();
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




        //End_____________________________________________________________________________________________5.Edit SubCategory Using GetById


        //Start____________________________________________________________________________________________6.Update SubCategory 

        public string UpdateSubCategoryTbl(int Id, SubCategoryTblModel model)
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

            var ResponseDict = db.SubCategoryTblInsertUpdate("SPSubCategoryTblInsertUpdate", new Dictionary<string, object>() {

            { "@subCat", model.SubCategory},
             { "@Catid", model.CategoryId},
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







        //End____________________________________________________________________________________________6.Update SubCategory 



        //

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }

    
    }





















}





