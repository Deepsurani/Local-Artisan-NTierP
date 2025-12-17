using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ResponseMessages;
using NTier.UserTblServices;

public partial class Client_ClientLogInPage : System.Web.UI.Page
{
    private readonly IUserTblServices db;

    public Client_ClientLogInPage()
    {
        db = new UserTblServices();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void BtnLogIn_Click(object sender, EventArgs e)
    {

        UserTblModel model = new UserTblModel()
        {
            Email = TxtEmail.Text,
            Password = TxtPassword.Text
        };
        int[] id = db.login(model);

        if (id.Length > 1)
        {

            //NOTE :- Create the session(set session) :- Session["User"] = id;
            Session["User"] = id[0];
            Session["UserType"] = id[1];
            if (id[1] == 2)
            {
                Response.Redirect("/Artisian/ArtisianDashBoard.aspx");
            }
            else if (id[1] == 0)
            {
                Response.Redirect("/Admin/AdminHomePage.aspx");
            }

            else
            {
                Response.Redirect("ClientHomeIPage.aspx");
            }

        }


        else
        {
            Response.Write("<script>alert('Email or password is wrong')</script>");
        }
    }
}