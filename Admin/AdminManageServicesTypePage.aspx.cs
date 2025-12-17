using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ServiceTypeTblServices;
using NTier.ResponseMessages;

public partial class Admin_AdminManageServicesTypePage : System.Web.UI.Page
{
    private readonly IServiceTypeTblService db;
    public Admin_AdminManageServicesTypePage()
    {
        db = new ServicesTypeTblService();
    }

    void ServiceTYpeFillGrid()
    {
        //this gridview id :- Category show
        var ResData = db.GetList();
        if (ResData.ContainsKey("Data"))
        {
            GridViewServiceType.DataSource = ResData["Data"];
            GridViewServiceType.DataBind();
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ServiceTYpeFillGrid();
    }

    protected void GridViewServiceType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string result = db.DeleteServiceType(id);

            Response.Write("<script>alert('" + result + "');</script>");

            // Refresh grid
            ServiceTYpeFillGrid();


        }

    }
}