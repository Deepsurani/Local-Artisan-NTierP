using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using NTier.Model;
using NTier.SubCategoryTblService;
using NTier.ResponseMessages;

public partial class Admin_AdminManageSubCategoryPage : System.Web.UI.Page
{

    private readonly ISubCategoryTblServices db;

    public Admin_AdminManageSubCategoryPage()
    {
        db = new SubCategoryTblServices();
    }


    void SubCategoryFillGrid()
    {
        //this gridview id :- SubCategory show
        var ResData = db.GetListSelect();
        if (ResData.ContainsKey("Data"))
        {
            
            GridViewSubCategory.DataSource = ResData["Data"];
            GridViewSubCategory.DataBind();
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SubCategoryFillGrid();
    }

    protected void GridViewSubCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string result = db.DeleteSubCategory(id);

            Response.Write("<script>alert('" + result + "');</script>");

            // Refresh grid
            SubCategoryFillGrid();


        }
    }
}