using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.UserTblServices;
using NTier.Model;
using NTier.ResponseMessages;

public partial class Client_ClientArtisanRegistrationPage : System.Web.UI.Page
{
    private readonly IUserTblServices db;

    public Client_ClientArtisanRegistrationPage()
    {
        db = new UserTblServices();
    }

    // 1.start :- Fill DropDown City In the Artisan registrationPage/ArtisanTbl
     void FillDropDownCity_Artisian()
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
            DropCity.DataSource = res;
            DropCity.DataTextField = "City";
            DropCity.DataValueField = "CityId";
            DropCity.DataBind();
            DropCity.Items.Insert(0, "----Select Value-----");
            DropCity.Items[0].Value = "";
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }

    // 1.end :- Fill DropDown City In the Artisan registrationPage/ArtisanTbl


    // 2.start :- Fill DropDown Area Acording to the City registrationPage/ArtisanTbl 
    void FillDropDownAreaToCity_Artisan()
    {
        var ResData = db.GetListArea(Convert.ToInt32(DropCity.Text));

        if (ResData.ContainsKey("Data"))
        {
            // Note :- Below Line is --> get model like list for the data bind to any source
            var res = ResData["Data"] as List<AreaTblModel>;


            //DropCategory.DataSource = ResData["Data"];
            //DropCategory.DataBind();

            //da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            DropArea.DataSource = res;
            DropArea.DataTextField = "Area";
            DropArea.DataValueField = "AreaId";
            DropArea.DataBind();
            DropArea.Items.Insert(0, "----Select Value-----");
            DropArea.Items[0].Value = "";
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }
    // 2.end :- Fill DropDown Area Acording to the City registrationPage/ArtisanTbl 

    protected void Page_Load(object sender, EventArgs e)
    {
        // 1.start :- Fill DropDown City In the Artisan registrationPage/ArtisanTbl --> fun call :-FillDropDownCity_Artisian();
        if (!IsPostBack)
        {
            FillDropDownCity_Artisian();
        }
        // 1.end :- Fill DropDown City In the Artisan registrationPage/ArtisanTbl--> fun call :-FillDropDownCity_Artisian();

        
    }

    protected void BtnArtisanRegistration_Click(object sender, EventArgs e)
    {
       
       string imgPathAddressProof = "";
        string imgpathAdharCard = "";
        string imgpathShopPhoto = "";
        string imgpathArtisianPhoto = "";
        string imgpathShopLogo = "";
        string imgpathShopBanarPhoto = "";

        if (fuAddressProof.HasFile)
        {
            fuAddressProof.SaveAs(Server.MapPath("~/Admin/img/" + fuAddressProof.FileName));
            imgPathAddressProof = "/img/" + fuAddressProof.FileName;
        }

        if (fuAdharCard.HasFile)
        {
            fuAdharCard.SaveAs(Server.MapPath("~/Admin/img/" + fuAdharCard.FileName));
            imgpathAdharCard = "img/" + fuAdharCard.FileName;
        }

        if (fuShopPhoto.HasFile)
        {
            fuShopPhoto.SaveAs(Server.MapPath("~/Admin/img/" + fuShopPhoto.FileName));
            imgpathShopPhoto = "img/" + fuShopPhoto.FileName;
        }

        if (fuShopLogo.HasFile)
        {
            fuShopLogo.SaveAs(Server.MapPath("~/Admin/img/" + fuShopLogo.FileName));
            imgpathShopLogo = "img/" + fuShopLogo.FileName;
        }

        if (fuShopBanarLogo.HasFile)
        {
            fuShopBanarLogo.SaveAs(Server.MapPath("~/Admin/img/" + fuShopBanarLogo.FileName));
            imgpathShopBanarPhoto = "img/" + fuShopBanarLogo.FileName;
        }

        if (fuArtisanPhoto.HasFile)
        {
            fuArtisanPhoto.SaveAs(Server.MapPath("~/Admin/img/" + fuArtisanPhoto.FileName));
            imgpathArtisianPhoto = "img/" + fuArtisanPhoto.FileName;
        }

        UserTblModel model = new UserTblModel()
        {


            UserType = 2,     // 1 usertype --> customer ,2 usertype -->
            Name = TxtName.Text,
            Email = TxtEmail.Text,
            Mobile = TxtMobile.Text,
            Password = TxtPassword.Text,
            IsVerified = false,
            IsActive = 1,

            ShopName = TxtShopName.Text,
            ArtisianName = TxtArtisanName.Text,
            ShopContactNo = Convert.ToInt64(TxtShopContact.Text),
            ArtisianContactNo = Convert.ToInt64(TxtArtisanContact.Text),
            Address = TxtAddress.Text,
            CityId = Convert.ToInt32(DropCity.Text),
            AreaId = Convert.ToInt32(DropArea.Text),

            AddressProof = imgPathAddressProof,
            AdharCard = imgpathAdharCard,
            ShopPhoto = imgpathShopPhoto,
            ArtisianPhoto = imgpathArtisianPhoto,
            ShopLogo = imgpathShopLogo,
            ShopBanarPhoto = imgpathShopBanarPhoto,
            IsArtisanVerified = false,


    };

        string result = db.InsertUserTbl(model);

        lblMessage.Text = result;
        lblMessage.Visible = true;


    }

    protected void DropCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 2.start :- Fill DropDown Area Acording to the City registrationPage/ArtisanTbl --> fun call :-FillDropDownAreaToCity_Artisan();
        FillDropDownAreaToCity_Artisan();
        // 2.end :- Fill DropDown Area Acording to the City registrationPage/ArtisanTbl --> fun call :-FillDropDownAreaToCity_Artisan();
    }
}