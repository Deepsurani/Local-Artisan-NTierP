using NTier.CategoryTblServices;
using NTier.Model;
using NTier.ResponseMessages;
using NTier.SubCategoryTblService;
using NTier.UserTblServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_ClientMasterPage : System.Web.UI.MasterPage
{
    private readonly IUserTblServices db;
    private readonly ICategoryTblService Cdb;
    private readonly ISubCategoryTblServices SCdb;

    public Client_ClientMasterPage()
    {
        db = new UserTblServices();
        Cdb=new CategorTblservice();
        SCdb=new SubCategoryTblServices();
    }
    void fillcate()
    {
        var cate= Cdb.GetList();
        if (cate.ContainsKey("Data"))
        {
            RptCategory.DataSource = cate["Data"];
            RptCategory.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        fillcate();
        // NOTE :- session get and then print welcome with session id
        if (Session["user"] != null)
        {
            int id = Convert.ToInt32(Session["user"]);
            var ResponseData = (db.GetById(id));

            if (ResponseData.ContainsKey("Data"))
            {
                var model = ResponseData["Data"] as UserTblModel;
                if (model == null)
                {
                    Response.Write(Messages.ModelIsNull);
                }


                user.InnerHtml = model.Name;
            }

        }
    }

    protected void RptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField catid=e.Item.FindControl("CateId") as HiddenField;
        Repeater rptSubCate = e.Item.FindControl("SubCat") as Repeater;
        var SCAT = SCdb.GetById(Convert.ToInt32(catid));
        if (SCAT.ContainsKey("Data"))
        {
            RptCategory.DataSource = SCAT["Data"];
            RptCategory.DataBind();
        }
    }
}
