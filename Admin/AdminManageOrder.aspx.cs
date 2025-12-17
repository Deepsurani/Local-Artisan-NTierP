using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.OrderTblServices;

public partial class Admin_AdminManageOrder : System.Web.UI.Page
{
    private readonly IOrderTblService db;

    public Admin_AdminManageOrder()
    {
        db = new OrderTblServices();
    }

    void AllOrderShowFillGrid()
    {
        var ResData = db.GetListOrderShowAdmin();
        if (ResData.ContainsKey("Data"))
        {
            GridViewOrder.DataSource = ResData["Data"];
            GridViewOrder.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AllOrderShowFillGrid();
    }
}