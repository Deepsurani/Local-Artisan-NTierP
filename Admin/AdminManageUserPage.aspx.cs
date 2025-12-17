using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.UserTblServices;

public partial class AdminManageUserPage : System.Web.UI.Page
{
    private readonly IUserTblServices db;

    public AdminManageUserPage()
    {
        db = new UserTblServices();
    }

    void AllUserShowFillGrid()
    {
        var ResData = db.GetListUserDataAd();
        if (ResData.ContainsKey("Data"))
        {
            GridViewUser.DataSource = ResData["Data"];
            GridViewUser.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AllUserShowFillGrid();
    }

    protected void GridViewUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}