using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ResponseMessages;
using NTier.CategoryTblServices;

public partial class Admin_AdminCreateCategoryPage : System.Web.UI.Page
{
    private readonly ICategoryTblService db;
    public Admin_AdminCreateCategoryPage()
    {
        db = new CategorTblservice();
    }


    void EditCategoryFill()
    {  
        // this function ids use for :- Edit Category Data fill
        if (!IsPostBack)
        {
            if (Request.QueryString["EditCat"] != null)
            {
                int CateId = Convert.ToInt32(Request.QueryString["EditCat"]);
                var ResponseData = (db.GetById(CateId));

                if (ResponseData.ContainsKey("Data"))
                {
                    var model = ResponseData["Data"] as CategoryTblModel;
                    if (model == null)
                    {
                        Response.Write(Messages.ModelIsNull);
                    }

                    TxtCategory.Text = model.Category;
                    ForEditImg.ImageUrl = model.Icon;
                    DropStatusAdCatCreate.Text = model.Status;

                    // Fill data in text box then Save Category btn convert to Update Category
                    BtnCatSave.Text = "Update Category";

                }

            }

        }


    }
    protected void Page_Load(object sender, EventArgs e)
    {

        //Editimglable.Visible = false;
        //ForEditImg.Visible = false;

        // 1.start :-this function ids use for :- Edit Category Data fill
        if (!IsPostBack)
        {
            EditCategoryFill();
        }
        // 1.End :-this function ids use for :- Edit Category Data fill

    }

    protected void BtnUserSave_Click(object sender, EventArgs e)
    {
        


        string imgPath = "";

        //START :- FOR Update 
       

        if (Request.QueryString["EditCat"] != null)
        {
            //Editimglable.Visible = true;
            //ForEditImg.Visible = true;

            int CateId = Convert.ToInt32(Request.QueryString["EditCat"]);
            var ResponseData = (db.GetById(CateId)); 
            
            Editimglable.Visible = true;
            ForEditImg.Visible = true;
   

           
            if (FuAdCatCreate.HasFile)
            {
                FuAdCatCreate.SaveAs(Server.MapPath("~/Admin/img/" + FuAdCatCreate.FileName));
                imgPath = "/img/" + FuAdCatCreate.FileName;
            }
            else
            {
                imgPath = ForEditImg.ImageUrl;
            }

            string Message = db.UpdateCategoryTbl(CateId, new CategoryTblModel()
            {
                Category = TxtCategory.Text,
                Icon = imgPath,
                Status = DropStatusAdCatCreate.Text
            });
            Response.Write(Message);

            lblMessage.Text = Message;
            lblMessage.Visible = true;


          

            TxtCategory.Text = "";
            DropStatusAdCatCreate.SelectedIndex = 0;


        }
        //END :- FOR Update 

        //START :- FOR Insert 

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

            CategoryTblModel model = new CategoryTblModel()
            {
                Category = TxtCategory.Text,
                Icon = imgPath,
                Status = DropStatusAdCatCreate.Text

            };

            string result = db.InsertCategoryTbl(model);

            lblMessage.Text = result;
            lblMessage.Visible = true;

            BtnCatSave.Text = "INSERT CATEGORY";
            TxtCategory.Text = "";
            DropStatusAdCatCreate.SelectedIndex = 0;

        }
        //END :- FOR Insert 







    }

}




