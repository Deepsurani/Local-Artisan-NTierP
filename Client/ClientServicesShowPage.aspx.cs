using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ResponseMessages;
using NTier.ServicesTblServices;

public partial class Client_ClientServicesShowPage : System.Web.UI.Page
{

    private readonly IServicesTblServices db;

    public Client_ClientServicesShowPage()
    {
        db = new ServicesTblServices();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var ResData = db.GetListServices();
        if (ResData.ContainsKey("Data"))
        {
            rptService.DataSource = ResData["Data"];
            rptService.DataBind();
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }
}