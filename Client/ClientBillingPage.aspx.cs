using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NTier.Model;
using NTier.OrderTblServices;

public partial class Client_ClientBillingPage : System.Web.UI.Page
{
    private readonly IOrderTblService db;

    public Client_ClientBillingPage()
    {
        db = new OrderTblServices();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User"] != null && Request.QueryString["Billno"] != null)
            {
                string bill = Request.QueryString["Billno"];
                var response = db.GetOrderDetailsByBill(bill);

                if (response.ContainsKey("Data"))
                {
                    var list = response["Data"] as List<OrderTblModel>;
                    var first = list.First();

                    // Header details
                    billidpass.InnerHtml = first.Billno;
                    orderidpass.InnerHtml = first.OrderId.ToString();
                    billdate.InnerHtml = first.EntryDate.ToString();
                    paymentmode.InnerHtml = first.PaymentType;

                    custname.InnerHtml = first.CusttName.ToString();
                    custmobile.InnerHtml = first.CustMobile.ToString();
                    custadd.InnerHtml = first.CusttAddress.ToString();

                    shipname.InnerHtml = first.CusttName.ToString();
                    shipmobile.InnerHtml = first.CustMobile.ToString();
                    shipadd.InnerHtml = first.CusttAddress.ToString();
                }
            }
        }
    }

}



