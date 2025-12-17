using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using NTier.Model;
using NTier.ProductTblServices;
using NTier.ResponseMessages;

public partial class Artisian_ArtisianOrderShow : System.Web.UI.Page
{
    private readonly IProductTblServices db;
  

    public Artisian_ArtisianOrderShow()
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
            var ResData = db.GetListOrder(userId);
            if (ResData.ContainsKey("Data"))
            {
                GridOrder.DataSource = ResData["Data"];
                GridOrder.DataBind();
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
}