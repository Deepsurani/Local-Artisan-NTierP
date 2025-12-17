using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ResponseMessages;
using NTier.ShippingTblServices;

public partial class Client_CheckOutPage : System.Web.UI.Page
{
    private readonly IShippingTblService db;

    public Client_CheckOutPage()
    {
        db = new ShippingTblServices();
    }

    // 1. start :- Fill city dropdown

    void FillDropDownCity_ShippingTbl()
    {
        var ResData = db.GetList();

        if (ResData.ContainsKey("Data"))
        {
            // Note :- Below Line is --> get model like list for the data bind to any source
            var res = ResData["Data"] as List<CityTblModel>;


            //DropCategory.DataSource = ResData["Data"];
            //DropCategory.DataBind();

            //da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            ddlCity.DataSource = res;
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, "----Select Value-----");
            ddlCity.Items[0].Value = "";
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }

    // 1. end :- Fill city dropdown

    // 2. start :- Fill Area using city  dropdown

    void FillDropDownAreaToCity_ShippingTbl()
    {
        var ResData = db.GetListArea(ddlCity.Text);

        if (ResData.ContainsKey("Data"))
        {
            // Note :- Below Line is --> get model like list for the data bind to any source
            var res = ResData["Data"] as List<AreaTblModel>;


            //DropCategory.DataSource = ResData["Data"];
            //DropCategory.DataBind();

            //da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            ddlArea.DataSource = res;
            ddlArea.DataTextField = "Area";
            ddlArea.DataValueField = "AreaId";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, "----Select Value-----");
            ddlArea.Items[0].Value = "";
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }
    // 2. end :- Fill Area using city  dropdown

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDownCity_ShippingTbl();
            //FillDropDownAreaToCity_ShippingTbl();
        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDownAreaToCity_ShippingTbl();
    }




    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {

            string userId = Session["User"].ToString(); // userid pass karva mate

            ShippingTblModel model = new ShippingTblModel()
            {
                UserId = Convert.ToInt32(userId),
                Name = txtName.Text,
                Mobile = txtMobile.Text,
                AlternateMobile = txtAlternateMobile.Text,
                Address = txtAddress.Text,
                Locality = txtLocality.Text,
                LandMark = txtLandmark.Text,
                Pincode = txtPincode.Text,
                CityId = ddlCity.Text,
                AreaId = Convert.ToInt32(ddlArea.Text),
                AddressType = ddlAddressType.Text,

            };

            string result = db.InsertShippingTbl(model);

            lblMessage.Text = result;
            lblMessage.Visible = true;

            Response.Redirect("/Client/ClientOrderSummeryPayment.aspx");

        }

        else
        {
            Response.Redirect("/Client/ClientLogInPage.aspx");
        }




    }

    protected void BtnOldAdd_Click(object sender, EventArgs e)
    {
        PanelOldAdd.Visible = true;
        PanelBillDetails.Visible = false;

        if (Session["user"] != null)
        {
            string userId = Session["User"].ToString();

            var ResData = db.GetListShipping(userId);
            if (ResData.ContainsKey("Data"))
            {
                var cartList = (List<ShippingTblModel>)ResData["Data"];

                Rptoldadd.DataSource = ResData["Data"];
                Rptoldadd.DataBind();


                // ----------------------------

              

                // ----------------------------
            }


        }


    }

    protected void NewBillDetail_Click(object sender, EventArgs e)
    {
        PanelBillDetails.Visible = true;
        PanelOldAdd.Visible = false;
    }
}