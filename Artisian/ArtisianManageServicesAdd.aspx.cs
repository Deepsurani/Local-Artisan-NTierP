using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ServicesTblServices;
using NTier.ResponseMessages;

public partial class Artisian_ArtisianManageServicesAdd : System.Web.UI.Page
{
    private readonly IServicesTblServices db;
    public Artisian_ArtisianManageServicesAdd()
    {
        db = new ServicesTblServices();
    }


    void ServicesFillGrid()
    {
        if (Session["User"] == null)
        {
            Response.Redirect("/Client/ClientLogInPage.aspx");
            return;
        }




        string userId = Session["User"].ToString(); // userid pass karva mate
        //this gridview id :- services show
        var ResData = db.GetListSelect(userId);
        if (ResData.ContainsKey("Data"))
        {
            GridViewServices.DataSource = ResData["Data"];
            GridViewServices.DataBind();
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ServicesFillGrid();
    }

    protected void GridViewServices_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string result = db.DeleteServices(id);

            Response.Write("<script>alert('" + result + "');</script>");

            // Refresh grid
            ServicesFillGrid(); ;

        }
    }
}