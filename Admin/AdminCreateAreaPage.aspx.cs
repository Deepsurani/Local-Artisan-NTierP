using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NTier.Model;
using NTier.ResponseMessages;
using NTier.AreaTblService;

public partial class Admin_AdminCreateAreaPage : System.Web.UI.Page
{

    private readonly IAreaTblServices db;

    public Admin_AdminCreateAreaPage()
    {
        db = new AreaTblServices();
    }



    // Start :-  Fill DropDown City In the AreaTbl
    void FillDropDownCity_Area()
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
        }
        else
        {
            Response.Write(ResData["Error"].ToString());
        }
    }

    // End :-  Fill DropDown City In the AreaTbl


    void EditAreaFill()
    {
        // this function ids use for :- Edit Category Data fill
        if (!IsPostBack)
        {
            if (Request.QueryString["EditArea"] != null)
            {
                int AreaeId = Convert.ToInt32(Request.QueryString["EditArea"]);
                var ResponseData = (db.GetById(AreaeId));

                if (ResponseData.ContainsKey("Data"))
                {
                    var model = ResponseData["Data"] as AreaTblModel;
                    if (model == null)
                    {
                        Response.Write(Messages.ModelIsNull);
                    }

                    TxtArea.Text = model.Area;
                    DropCity.Text = model.CityId.ToString();
                    
                    DropStatus.Text = model.Status;

                    // Fill data in text box then Save Category btn convert to Update Category
                    BtnAreaSave.Text = "Update Area";

                }

            }

        }


    }
    protected void Page_Load(object sender, EventArgs e)
    {

        // 1.Start :-  Fill DropDown City In the AreaTbl ---> its function call

        FillDropDownCity_Area();

        // 1.End :-  Fill DropDown City In the AreaTbl ---> its function call



        EditAreaFill();

    }

    protected void BtnAreaSave_Click(object sender, EventArgs e)
    {


        if (Request.QueryString["EditArea"] != null)
        {
            //Editimglable.Visible = true;
            //ForEditImg.Visible = true;

            int AreaId = Convert.ToInt32(Request.QueryString["EditArea"]);
            var ResponseData = (db.GetById(AreaId));

            //Editimglable.Visible = true;
            //ForEditImg.Visible = true;



         

            string Message = db.UpdateAreaTbl(AreaId, new AreaTblModel()
            {
                CityId = Convert.ToInt32(DropCity.Text),
                Area = TxtArea.Text,
                Status = DropStatus.Text
            });
            Response.Write(Message);

            lblMessage.Text = Message;
            lblMessage.Visible = true;


            TxtArea.Text = "";
            DropStatus.SelectedIndex = 0;
            DropCity.SelectedIndex = 0;





        }
        //   

        else
        {
            AreaTblModel model = new AreaTblModel()
            {
                CityId = Convert.ToInt32(DropCity.Text),
                Area = TxtArea.Text,
                Status = DropStatus.Text

            };

            string result = db.InsertAreaTbl(model);

            lblMessage.Text = result;
            lblMessage.Visible = true;


            TxtArea.Text = "";
            DropStatus.SelectedIndex = 0;
            DropCity.SelectedIndex = 0;
        }
          

        }
        //END :- FOR Insert 

}