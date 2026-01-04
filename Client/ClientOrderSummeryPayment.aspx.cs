using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.CartTblServices;
using NTier.ResponseMessages;
using NTier.Model;
using NTier.OrderTblServices;
public partial class Client_ClientOrderSummeryPayment : System.Web.UI.Page
{

    private readonly ICartTblService db;
    private readonly IOrderTblService odb;


    public Client_ClientOrderSummeryPayment()
    {
        db = new CartTblServices();
        odb = new OrderTblServices();
    }
    void FillCartDataShow()
    {
        if (Session["User"] != null)
        {
            string userId = Session["User"].ToString(); // userid pass karva mate

            var ResData = db.GetListCartProduct(userId);
            if (ResData.ContainsKey("Data"))
            {
                var cartList = (List<CartTblModel>)ResData["Data"];




                // ----------------------------

                decimal subtotal = 0;
                int qty = 0;


                foreach (var item in cartList)
                {
                    subtotal += item.total;
                    qty += item.Qty;
                }

                // ------------------------------
                //  DISCOUNT 
                // ------------------------------
                decimal discountPercent = 0;

                if (subtotal > 500)
                {
                    discountPercent = 10;      // 10% discount
                }

                decimal discount = (subtotal * discountPercent) / 100;
                decimal grandTotal = subtotal - discount;



                LblSubTotal.Text = subtotal.ToString("0.00");
                LblDiscount.Text = discount.ToString("0.00");
                LblCartTotal.Text = grandTotal.ToString("0.00");
                totalqty.Value = qty.ToString("");



                LblDiscountPercent.Text = discountPercent + "%";

                LblYouSave.Text = "You will save Rs. " + discount.ToString("0.00") + " on this order!";

                // ----------------------------
            }
            else
            {
                Response.Write(ResData["Error"].ToString());
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCartDataShow();
        }
    }

    protected void BtnOrderTblPlaceOrder_Click(object sender, EventArgs e)
    {


        if (Session["user"] != null)
        {
            string status = "active";
            string ostatus = "Pending";

            if (Request.QueryString["spid"] != null)
            {
                string payment = "";
                string pstatus = "";
                if (RadioButton1.Checked)
                {
                    payment = "Online Payment";
                    pstatus = "Paid";
                }
                else if (RadioButton2.Checked)
                {
                    payment = "COD";
                    pstatus = "Pending";
                }
                string spid = Request.QueryString["spid"].ToString();
                string userId = Session["User"].ToString();


                OrderTblModel model = new OrderTblModel()
                {
                 
                    ShipingId = Convert.ToInt32(spid),
                    UserId = Convert.ToInt32(userId),
                    TotalAmount = LblCartTotal.Text,
                    TotalQty = totalqty.Value,
                    Status = status,
                    OrderStatus = ostatus,
                    PaymentStatus = pstatus,
                    PaymentType = payment

                 
                };


                Dictionary<string,string> result = odb.InsertOrderTbl(model);

              
                if (result["Msg"] == Messages.Inserted)
                {
                    Response.Redirect("/Client/OnlyShowOrdePlacedSuccessfully.aspx?oid=" + result["Id"]);
                }
                else
                {
                    lblMessage.Text = result["Msg"];
                    lblMessage.Visible = true;

                }


            }
        }













    }
}
