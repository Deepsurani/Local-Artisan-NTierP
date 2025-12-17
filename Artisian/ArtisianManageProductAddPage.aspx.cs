using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using NTier.Model;
using NTier.ProductTblServices;
using NTier.ResponseMessages;

public partial class Artisian_ArtisianManageProductAddPage : System.Web.UI.Page
{
    private readonly IProductTblServices db;
    public Artisian_ArtisianManageProductAddPage()
    {
        db = new ProductTblServices();
    }


    void ProductFillGrid()
    {
        if (Session["User"] == null)
        {
            Response.Redirect("/Client/ClientLogInPage.aspx");
            return;
        }


        else
        {
            string userId = Session["User"].ToString(); // userid pass karva mate
                                                        //this gridview id :- product show
            var ResData = db.GetListSelect(userId);
            if (ResData.ContainsKey("Data"))
            {
                GridViewProduct.DataSource = ResData["Data"];
                GridViewProduct.DataBind();
            }
            else
            {
                Response.Write(ResData["Error"].ToString());
            }
        }

      
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        ProductFillGrid();
    }

    protected void GridViewProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string result = db.DeleteProduct(id);

            Response.Write("<script>alert('" + result + "');</script>");

            // Refresh grid
            ProductFillGrid(); ;

        }
    }
}