using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.ProductTblServices;
using NTier.ResponseMessages;
using NTier.Model;
using Newtonsoft.Json;
using NTier.CartTblServices;

public partial class Client_ClientProductDetailsPage : System.Web.UI.Page
{
    private readonly IProductTblServices db;
    private readonly ICartTblService cdb;
  
    public Client_ClientProductDetailsPage()
    {
        db = new ProductTblServices();
        cdb = new CartTblServices();
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["ProductDetails"] != null)
            {
                int ProductId = Convert.ToInt32(Request.QueryString["ProductDetails"]);
                var ResponseData = (db.GetById(ProductId));

                if (ResponseData.ContainsKey("Data"))
                {
                    var model = ResponseData["Data"] as ProductTblModel;
                    if (model == null)
                    {
                        Response.Write(Messages.ModelIsNull);
                    }
                    
                        ProductName.InnerHtml = model.ProductTitle;
                        ProductPrice.InnerHtml = model.Price;
                        ProductDescription.InnerHtml = model.Description;
                        ProductImg.ImageUrl = model.Photo1;




                }

            }
        }


    }

    protected void BtnAddToCart_Click(object sender, EventArgs e)
    {

        if (Session["User"] != null)
        {
            if (Request.QueryString["ProductDetails"] != null)
            {
                int ProductDetailsId = Convert.ToInt32(Request.QueryString["ProductDetails"]);
                var ResponseData = (db.GetById(ProductDetailsId));

                string userId = Session["User"].ToString(); // userid pass karva mate


                string artType = TxtArtType.Text;
                string size = RblSize.Text;
                string shape = RblShape.Text;
                string design = RblDesign.Text;
                string mirror = RblMirror.Text;
                string colour = TxtColour.Text;
                string artName = TxtArtName.Text;

                var custom = new 
                {
                    ArtType = artType,
                    Size = size,
                    Shape = shape,
                    DesignStyle = design,
                    MirrorWork = mirror,
                    Colour = colour,
                    NameOnArt = artName
                };

                string jsonData = JsonConvert.SerializeObject(custom);

                CartTblModel model = new CartTblModel()
                {
                    //Category = TxtCategory.Text,
                    //Icon = imgPath,
                    //Status = DropStatusAdCatCreate.Text
                
                     UserId = Convert.ToInt32(userId),
                     ProductId = ProductDetailsId,
                     Qty = Convert.ToInt32(TxtQty.Text),
                     CustomData = jsonData





                };

                string result = cdb.InsertCartTbl(model);

                lblMessage.Text = result;
                lblMessage.Visible = true;


                Response.Redirect("/Client/ClientCartPage.aspx");

            }
        }

        else
        {
            Response.Redirect("/Client/ClientLogInPage.aspx");
            return;
        }




    
      



    }
}