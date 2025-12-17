using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.ProductTblServices;
using NTier.Model;
using NTier.ResponseMessages;

public partial class Artisian_ArtisianProductAdd : System.Web.UI.Page
{
    private readonly IProductTblServices db;

    public Artisian_ArtisianProductAdd()
    {
        db = new ProductTblServices();
    }

    // 1.start :- Fill DropDown Category In the ProductAddPage/ProductTbl
    void FillDropDownCategory_ProductTbl()
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
            DropCategoryId.DataSource = res;
            DropCategoryId.DataTextField = "Category";
            DropCategoryId.DataValueField = "CategoryId";
            DropCategoryId.DataBind();
            DropCategoryId.Items.Insert(0, "----Select Value-----");
            DropCategoryId.Items[0].Value = "";
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }
    // 1.end :- Fill DropDown Category In the ProductAddPage/ProductTbl


    // 2.start :- Fill DropDown SubCategory Acording to the Category ArtisianProductAdd/ProductTbl
    void FillDropDownSubCategoryToCategory_Product()
    {
        var ResData = db.GetListSubCategory(Convert.ToInt32(DropCategoryId.Text));

        if (ResData.ContainsKey("Data"))
        {
            // Note :- Below Line is --> get model like list for the data bind to any source
            var res = ResData["Data"] as List<SubCategoryTblModel>;


            //DropCategory.DataSource = ResData["Data"];
            //DropCategory.DataBind();

            //da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            DropSubCategoryId.DataSource = res;
            DropSubCategoryId.DataTextField = "SubCategory";
            DropSubCategoryId.DataValueField = "SubCategoryId";
            DropSubCategoryId.DataBind();
            DropSubCategoryId.Items.Insert(0, "----Select Value-----");
            DropSubCategoryId.Items[0].Value = "";
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }
    // 2.end :- Fill DropDown SubCategory Acording to the Category ArtisianProductAdd/ProductTbl

    void EditProductFill()
    {
        // this function ids use for :- Edit product Data fill

        if (Request.QueryString["EditProduct"] != null)
        {
            int ProdId = Convert.ToInt32(Request.QueryString["EditProduct"]);
            var ResponseData = (db.GetById(ProdId));

            if (ResponseData.ContainsKey("Data"))
            {
                var model = ResponseData["Data"] as ProductTblModel;
                if (model == null)
                {
                    Response.Write(Messages.ModelIsNull);
                }
                DropCategoryId.Text = model.CategoryId.ToString();
                int subcatid = model.SubCategoryId;
                TxtProductTitle.Text = model.ProductTitle;
                TxtPrice.Text = model.Price;
                TxtDescription.Text = model.Description;
                ForEditImg1.ImageUrl = model.Photo1;
                ForEditImg2.ImageUrl = model.Photo2;
                ForEditImg3.ImageUrl = model.Photo3;
                ForEditImg4.ImageUrl = model.Photo4;
                ForEditImg5.ImageUrl = model.Photo5;


                // sub cate drop auto fill
                DropSubCategoryId.Text = subcatid.ToString();
                FillDropDownSubCategoryToCategory_Product();
                // Fill data in text box then Save Product btn convert to Update Product
                BtnProductSave.Text = "Update Product";

            }

        }


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // 1. start :- Fill DropDown Category In the ProductAddPage/ProductTbl

        if (!IsPostBack)
        {
            FillDropDownCategory_ProductTbl();

            // 1.end :- Fill DropDown Category In the ProductAddPage/ProductTbl

            EditProductFill();
        }
    }



    protected void DropCategoryId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDownSubCategoryToCategory_Product();
    }

    protected void BtnProductSave_Click(object sender, EventArgs e)
    {
        string imgPathPhoto1 = "";
        string imgPathPhoto2 = "";
        string imgPathPhoto3 = "";
        string imgPathPhoto4 = "";
        string imgPathPhoto5 = "";

        if (Request.QueryString["EditProduct"] != null)
        {


            int ProdId = Convert.ToInt32(Request.QueryString["EditProduct"]);
            var ResponseData = (db.GetById(ProdId));





            if (FuPhoto1.HasFile)
            {
                FuPhoto1.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto1.FileName));
                imgPathPhoto1 = "/Admin/img/" + FuPhoto1.FileName;
            }

            if (FuPhoto2.HasFile)
            {
                FuPhoto2.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto2.FileName));
                imgPathPhoto2 = "/Admin/img/" + FuPhoto2.FileName;
            }

            if (FuPhoto3.HasFile)
            {
                FuPhoto3.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto3.FileName));
                imgPathPhoto3 = "/Admin/img/" + FuPhoto3.FileName;
            }

            if (FuPhoto4.HasFile)
            {
                FuPhoto4.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto4.FileName));
                imgPathPhoto4 = "/Admin/img/" + FuPhoto4.FileName;
            }

            if (FuPhoto5.HasFile)
            {
                FuPhoto5.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto5.FileName));
                imgPathPhoto5 = "/Admin/img/" + FuPhoto5.FileName;
            }



            string Message = db.UpdateProductTbl(ProdId, new ProductTblModel()
            {
              
                CategoryId = Convert.ToInt32(DropCategoryId.Text),
                SubCategoryId = Convert.ToInt32(DropSubCategoryId.Text),
                ProductTitle = TxtProductTitle.Text,
                Price = TxtPrice.Text,
                Description = TxtDescription.Text,
                Photo1 = imgPathPhoto1,
                Photo2 = imgPathPhoto2,
                Photo3 = imgPathPhoto3,
                Photo4 = imgPathPhoto4,
                Photo5 = imgPathPhoto5,
               
            });
            Response.Write(Message);

            lblMessage.Text = Message;
            lblMessage.Visible = true;

        }

        else
        {
            if (Session["User"] != null)
            {
                int uid = Convert.ToInt32(Session["User"].ToString());
           


                if (FuPhoto1.HasFile)
                {
                    FuPhoto1.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto1.FileName));
                    imgPathPhoto1 = "/Admin/img/" + FuPhoto1.FileName;
                }
                else
                {
                    imgPathPhoto1 = ForEditImg1.ImageUrl;
                }

                if (FuPhoto2.HasFile)
                {
                    FuPhoto2.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto2.FileName));
                    imgPathPhoto2 = "/Admin/img/" + FuPhoto2.FileName;
                }
                else
                {
                    imgPathPhoto2 = ForEditImg2.ImageUrl;
                }

                if (FuPhoto3.HasFile)
                {
                    FuPhoto3.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto3.FileName));
                    imgPathPhoto3 = "/Admin/img/" + FuPhoto3.FileName;
                }
                else
                {
                    imgPathPhoto3 = ForEditImg3.ImageUrl;
                }

                if (FuPhoto4.HasFile)
                {
                    FuPhoto4.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto4.FileName));
                    imgPathPhoto4 = "/Adminimg/" + FuPhoto4.FileName;
                }
                else
                {
                    imgPathPhoto4 = ForEditImg4.ImageUrl;
                }

                if (FuPhoto5.HasFile)
                {
                    FuPhoto5.SaveAs(Server.MapPath("~/Admin/img/" + FuPhoto5.FileName));
                    imgPathPhoto5 = "/Admin/img/" + FuPhoto5.FileName;
                }
                else
                {
                    imgPathPhoto5 = ForEditImg5.ImageUrl;
                }



                ProductTblModel model = new ProductTblModel()
                {

                    UserId = uid,
                    CategoryId = Convert.ToInt32(DropCategoryId.Text),
                    SubCategoryId = Convert.ToInt32(DropSubCategoryId.Text),
                    ProductTitle = TxtProductTitle.Text,
                    Price = TxtPrice.Text,
                    Description = TxtDescription.Text,
                    Photo1 = imgPathPhoto1,
                    Photo2 = imgPathPhoto2,
                    Photo3 = imgPathPhoto3,
                    Photo4 = imgPathPhoto4,
                    Photo5 = imgPathPhoto5,
                    IsVerified = "0",
                    IsActive = "0",


                };

                string result = db.InsertProductTbl(model);

                lblMessage.Text = result;
                lblMessage.Visible = true;
            }
            else
            {
                Response.Redirect("/Client/ClientLogInPage.aspx");
            }
        }




     
    }
}