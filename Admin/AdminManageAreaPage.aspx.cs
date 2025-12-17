using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.AreaTblService;
using NTier.ResponseMessages;

public partial class Admin_AdminManageAreaPage : System.Web.UI.Page
{
    private readonly IAreaTblServices db;
    public Admin_AdminManageAreaPage()
    {
        db = new AreaTblServices();
    }

    void AreaFillGrid()
    {
        //this gridview id :- Category show
        var ResData = db.GetListSelect();
        if (ResData.ContainsKey("Data"))
        {
            GridViewArea.DataSource = ResData["Data"];
            GridViewArea.DataBind();
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AreaFillGrid();

    }

    protected void GridViewArea_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string result = db.DeleteArae(id);

            Response.Write("<script>alert('" + result + "');</script>");

            // Refresh grid
            AreaFillGrid(); ;


        }
    }
}