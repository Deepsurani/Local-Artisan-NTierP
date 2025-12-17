using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ResponseMessages;
using NTier.ServiceTypeTblServices;

public partial class Admin_AdminServicesTypePage : System.Web.UI.Page
{

    private readonly IServiceTypeTblService db;
    public Admin_AdminServicesTypePage()
    {
        db = new ServicesTypeTblService();
    }


    void EditServiceTypeFill()
    {
        // this function ids use for :- Edit Category Data fill
        if (!IsPostBack)
        {
            if (Request.QueryString["EditServiceType"] != null)
            {
                int ServiceTypeId = Convert.ToInt32(Request.QueryString["EditServiceType"]);
                var ResponseData = (db.GetById(ServiceTypeId));

                if (ResponseData.ContainsKey("Data"))
                {
                    ServiceTypeTblModel model = ResponseData["Data"] as ServiceTypeTblModel;
                    if (model == null)
                    {
                        Response.Write(Messages.ModelIsNull);
                    }

                    TxtServiceType.Text = model.ServicesType;
                    ForEditImg.ImageUrl = model.Icon;
                    DropStatus.Text = model.Status;

                    // Fill data in text box then Save Category btn convert to Update Category
                    BtnServiceTypeSave.Text = "Update ServiceType Save";

                }

            }

        }


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        EditServiceTypeFill();
    }

    protected void BtnServiceTypeSave_Click(object sender, EventArgs e)
    {
        string imgPath = "";

        if (Request.QueryString["EditServiceType"] != null)
        {
            //Editimglable.Visible = true;
            //ForEditImg.Visible = true;

            int ServiceTypeId = Convert.ToInt32(Request.QueryString["EditServiceType"]);
            var ResponseData = (db.GetById(ServiceTypeId));

            Editimglable.Visible = true;
            ForEditImg.Visible = true;



            if (FuAdServiceTypeCreate.HasFile)
            {
                FuAdServiceTypeCreate.SaveAs(Server.MapPath("~/Admin/img/" + FuAdServiceTypeCreate.FileName));
                imgPath = "img/" + FuAdServiceTypeCreate.FileName;
            }
            else
            {
                imgPath = ForEditImg.ImageUrl;
            }

            string Message = db.UpdateServiceTypeTbl(ServiceTypeId, new ServiceTypeTblModel()
            {
                ServicesType = TxtServiceType.Text,
                Icon = imgPath,
                Status = DropStatus.Text
            });
            Response.Write(Message);

            lblMessage.Text = Message;
            lblMessage.Visible = true;




       
            TxtServiceType.Text = "";
            DropStatus.SelectedIndex = 0;


        }


        else
        {
            if (FuAdServiceTypeCreate.HasFile)
            {
                FuAdServiceTypeCreate.SaveAs(Server.MapPath("~/Admin/img/" + FuAdServiceTypeCreate.FileName));
                imgPath = "img/" + FuAdServiceTypeCreate.FileName;
            }
            else
            {
                imgPath = ForEditImg.ImageUrl;
            }

            ServiceTypeTblModel model = new ServiceTypeTblModel()

            {
                ServicesType = TxtServiceType.Text,
                Icon = imgPath,
                Status = DropStatus.Text

            };

            string result = db.InsertServicesTypeTbl(model);

            lblMessage.Text = result;
            lblMessage.Visible = true;

            BtnServiceTypeSave.Text = "INSERT SERVICETYPE";
            TxtServiceType.Text = "";
            DropStatus.SelectedIndex = 0;
        }

      
    }
}