using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ResponseMessages;
using NTier.ProductTblServices;

public partial class Client_ClientProductShowPage : System.Web.UI.Page
{
    private readonly IProductTblServices db;

    public Client_ClientProductShowPage()
    {
        db = new ProductTblServices();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var ResData = db.GetListProduct();
        if (ResData.ContainsKey("Data"))
        {
            rptProduct.DataSource = ResData["Data"];
            rptProduct.DataBind();
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }



    }
}