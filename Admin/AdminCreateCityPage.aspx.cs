using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using NTier.CityTblServices;
using NTier.Model;
using NTier.ResponseMessages;

public partial class Admin_AdminCreateCityPage : System.Web.UI.Page
{

    private readonly ICityTblServices db;

    public Admin_AdminCreateCityPage()
    {
        db = new CityTblServices();
    }


    void EditCityFill()
    {
        // this function ids use for :- Edit Category Data fill
        if (!IsPostBack)
        {
            if (Request.QueryString["EditCity"] != null)
            {
                int CityId = Convert.ToInt32(Request.QueryString["EditCity"]);
                var ResponseData = (db.GetById(CityId));

                if (ResponseData.ContainsKey("Data"))
                {
                    var model = ResponseData["Data"] as CityTblModel;
                    if (model == null)
                    {
                        Response.Write(Messages.ModelIsNull);
                    }

                    TxtCity.Text = model.City;
                    DropStatus.Text = model.Status;

                    // Fill data in text box then Save Category btn convert to Update Category
                    BtnCitySave.Text = "Update City";

                }

            }

        }


    }

    protected void Page_Load(object sender, EventArgs e)
    {
         // 1.start :-this function ids use for :- Edit City Data fill
        if (!IsPostBack)
        {
            EditCityFill();
        }
        // 1.End :-this function ids use for :- Edit City Data fill
    }

    protected void BtnCitySave_Click(object sender, EventArgs e)
    {

        //START :- FOR Update 


        if (Request.QueryString["EditCity"] != null)
        {
            //Editimglable.Visible = true;
            //ForEditImg.Visible = true;

            int CityId = Convert.ToInt32(Request.QueryString["EditCity"]);
            var ResponseData = (db.GetById(CityId));

        


            string Message = db.UpdateCityTbl(CityId, new CityTblModel()
            {
                City = TxtCity.Text,
                Status = DropStatus.Text
            });
            Response.Write(Message);

            lblMessage.Text = Message;
            lblMessage.Visible = true;

            BtnCitySave.Text = "UPDATE CITY";
            TxtCity.Text = "";
            DropStatus.SelectedIndex = 0;


        }
        //END :- FOR Update 

        //START :- FOR Insert 

        else
        {
            CityTblModel model = new CityTblModel()
            {
                City = TxtCity.Text,
                Status = DropStatus.Text

            };

            string result = db.InsertCityTbl(model);

            lblMessage.Text = result;
            lblMessage.Visible = true;

            BtnCitySave.Text = "INSERT CITY";
            TxtCity.Text = "";
            DropStatus.SelectedIndex = 0;
        }

        //END :- FOR Insert 

       

    }
}