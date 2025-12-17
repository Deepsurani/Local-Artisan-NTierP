using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ResponseMessages;
using NTier.SubCategoryTblService;

using System.Data.SqlClient;
using System.Data;

public partial class Admin_AdminCrateSubCategoryPage : System.Web.UI.Page
{
    private readonly ISubCategoryTblServices db;

    public Admin_AdminCrateSubCategoryPage()
    {
        db = new SubCategoryTblServices();
    }



    // Start :-  Fill DropDown Category In the SubCategoryTbl
    void FillDropDownCategory_SubCategory()
    {        
        var ResData = db.GetList();

        if (ResData.ContainsKey("Data"))
        { 
            // Note :- Below Line is --> get model like list for the data bind to any source
             var res = ResData["Data"] as List<CategoryTblModel>;


            //DropCategory.DataSource = ResData["Data"];
            //DropCategory.DataBind();

            //da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            DropCategory.DataSource = res;
            DropCategory.DataTextField = "Category";
            DropCategory.DataValueField = "CategoryId";
            DropCategory.DataBind();
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }

    // End :-  Fill DropDown Category In the SubCategoryTbl


    void EditSubCategoryFill()
    {
        // this function ids use for :- Edit Category Data fill
        if (!IsPostBack)
        {
            if (Request.QueryString["EditSubCat"] != null)
            {
                int SubCateId = Convert.ToInt32(Request.QueryString["EditSubCat"]);
                var ResponseData = (db.GetById(SubCateId));

                if (ResponseData.ContainsKey("Data"))
                {
                    var model = ResponseData["Data"] as SubCategoryTblModel;
                    if (model == null)
                    {
                        Response.Write(Messages.ModelIsNull);
                    }

                    TxtSubCategory.Text = model.SubCategory;
                    DropCategory.Text = model.CategoryId;
                    ForEditImg.ImageUrl = model.Icon;
                    DropStatusAdCatCreate.Text = model.Status;

                    // Fill data in text box then Save Category btn convert to Update Category
                    BtnSubCatSave.Text = "Update SubCategory";

                }

            }

        }


    }




    protected void Page_Load(object sender, EventArgs e)
    {
        // 1.Start :-  Fill DropDown Category In the SubCategoryTbl ---> its function call
        FillDropDownCategory_SubCategory();
        // 1.End :-  Fill DropDown Category In the SubCategoryTbl ---> its function call

        // 2.start :-this function ids use for :- Edit SubCategory Data fill
      
            EditSubCategoryFill();
        
        // 2.End :-this function ids use for :- Edit SubCategory Data fill
    }

    protected void BtnSubCatSave_Click(object sender, EventArgs e)
    {

        string imgPath = "";

        //START :- FOR Update 

        if (Request.QueryString["EditSubCat"] != null)
        {
            //Editimglable.Visible = true;
            //ForEditImg.Visible = true;

            int SubCateId = Convert.ToInt32(Request.QueryString["EditSubCat"]);
            var ResponseData = (db.GetById(SubCateId));

            //Editimglable.Visible = true;
            //ForEditImg.Visible = true;



            if (FuAdCatCreate.HasFile)
            {
                FuAdCatCreate.SaveAs(Server.MapPath("~/Admin/img/" + FuAdCatCreate.FileName));
                imgPath = "img/" + FuAdCatCreate.FileName;
            }
            else
            {
                imgPath = ForEditImg.ImageUrl;
            }

            string Message = db.UpdateSubCategoryTbl(SubCateId, new SubCategoryTblModel()
            {
                CategoryId = DropCategory.Text,
                SubCategory = TxtSubCategory.Text,
                Icon = imgPath,
                Status = DropStatusAdCatCreate.Text
            });
            Response.Write(Message);

            lblMessage.Text = Message;
            lblMessage.Visible = true;



            DropCategory.SelectedIndex = 0;
            TxtSubCategory.Text = "";
            DropStatusAdCatCreate.SelectedIndex = 0;

           



        }

        //END :- FOR Update 


        //START :- FOR SubCategory Insert 

        else
        {

            if (FuAdCatCreate.HasFile)
            {
                FuAdCatCreate.SaveAs(Server.MapPath("~/Admin/img/" + FuAdCatCreate.FileName));
                imgPath = "img/" + FuAdCatCreate.FileName;
            }
            else
            {
                imgPath = ForEditImg.ImageUrl;
            }

            SubCategoryTblModel model = new SubCategoryTblModel()
            {
                CategoryId = DropCategory.Text,
                SubCategory = TxtSubCategory.Text,
                Icon = imgPath,
                Status = DropStatusAdCatCreate.Text

            };

            string result = db.InsertSubCategoryTbl(model);

            lblMessage.Text = result;
            lblMessage.Visible = true;


            DropCategory.SelectedIndex = 0;
            TxtSubCategory.Text = "";
            DropStatusAdCatCreate.SelectedIndex = 0;

            BtnSubCatSave.Text = "INSERT SUBCATEGORY";

        }

     
     

        //End :- FOR SubCategory Insert 

    }
}