using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.CityTblServices;
using NTier.ResponseMessages;

public partial class Admin_AdminManageCityPage : System.Web.UI.Page
{
    private readonly ICityTblServices db;
    public Admin_AdminManageCityPage()
    {
        db = new CityTblServices();
    }

    void CityFillGrid()
    {
        //this gridview id :- Category show
        var ResData = db.GetList();
        if (ResData.ContainsKey("Data"))
        {
            GridViewCity.DataSource = ResData["Data"];
            GridViewCity.DataBind();
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        CityFillGrid();
    }

    protected void GridViewCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string result = db.DeleteCity(id);

            Response.Write("<script>alert('" + result + "');</script>");

            // Refresh grid
            CityFillGrid();


        }
    }
}