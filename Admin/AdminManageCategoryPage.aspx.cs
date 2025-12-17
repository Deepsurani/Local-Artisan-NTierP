using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using NTier.Model;
using NTier.CategoryTblServices;
using NTier.ResponseMessages;

public partial class Admin_AdminManageCategoryPage : System.Web.UI.Page
{
    private readonly ICategoryTblService db;
    public Admin_AdminManageCategoryPage()
    {
        db = new CategorTblservice();
    }

    void CategoryFillGrid()
    {
        //this gridview id :- Category show
        var ResData = db.GetList();
        if (ResData.ContainsKey("Data"))
        {
            GridViewCategory.DataSource = ResData["Data"];
            GridViewCategory.DataBind();
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        CategoryFillGrid();

    }

    protected void GridViewCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string result = db.DeleteCategory(id);

            Response.Write("<script>alert('" + result + "');</script>");

            // Refresh grid
            CategoryFillGrid();


        }
    }
}