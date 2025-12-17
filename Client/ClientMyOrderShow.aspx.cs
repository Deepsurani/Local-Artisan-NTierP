using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NTier.OrderTblServices;

public partial class Client_ClientMyOrderShow : System.Web.UI.Page
{
    private readonly IOrderTblService db;

    public Client_ClientMyOrderShow()
    {
        db = new OrderTblServices();
    }


    void AllOrderShowFillGrid()
    {
        if (Session["User"] != null)
        {
            string userId = Session["User"].ToString(); // userid pass karva mate

            var ResData = db.GetListMyOrderShow(userId);   // 🔥 PASS userId here
            if (ResData.ContainsKey("Data"))
            {
                RepeaterMyOrder.DataSource = ResData["Data"];
                RepeaterMyOrder.DataBind();
            }
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        AllOrderShowFillGrid();
    }
}