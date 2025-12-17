using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using NTier.UserTblServices;
using NTier.Model;
using NTier.ResponseMessages;

public partial class Client_ClientRegiistrationPage : System.Web.UI.Page
{
    private readonly IUserTblServices db;

    public Client_ClientRegiistrationPage()
    {
        db = new UserTblServices();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnRegistration_Click(object sender, EventArgs e)
    {
        UserTblModel model = new UserTblModel()
        {
            UserType = 1,
            Name = TxtName.Text.Trim(),
            Email = TxtEmail.Text.Trim(),
            Mobile = TxtMobile.Text.Trim(),
            Password = TxtPassword.Text.Trim(),
            IsVerified = false,
            IsActive = 1
        };

        string result = db.InsertUserTbl(model);

        lblMessage.Text = result;
        lblMessage.Visible = true;
    }
}