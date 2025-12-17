using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.CartTblServices;
using NTier.ResponseMessages;
using NTier.Model;


public partial class Client_ClientCartPage : System.Web.UI.Page
{
    private readonly ICartTblService db;
   

    public Client_ClientCartPage()
    {
        db = new CartTblServices();
      
    }


    void  FillCartDataShow()
    {
        if (Session["User"] != null)
        {
            string userId = Session["User"].ToString(); // userid pass karva mate

            var ResData = db.GetListCartProduct(userId);
            if (ResData.ContainsKey("Data"))
            {
                var cartList = (List<CartTblModel>)ResData["Data"];

                rptProduct.DataSource = ResData["Data"];
                rptProduct.DataBind();


                // ----------------------------

                decimal subtotal = 0;

                foreach (var item in cartList)
                {
                    subtotal += item.total;
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
                LblCatrTotal.Text = grandTotal.ToString("0.00");

              
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

    protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "RowdeleteBtn")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string result = db.DeleteCart(id);

            Response.Write("<script>alert('" + result + "');</script>");

            // Refresh grid
            FillCartDataShow();


        }

        if (e.CommandName == "RowUpdateBtn")
        {
            TextBox qty = e.Item.FindControl("TxtQty") as TextBox;

            int newQty = Convert.ToInt32(qty.Text);
            int id = Convert.ToInt32(e.CommandArgument);

            string result = db.UpdateCart(id, newQty);

            FillCartDataShow();

            Response.Write("<script>alert('" + result + "');</script>");

         
        }





    }
}