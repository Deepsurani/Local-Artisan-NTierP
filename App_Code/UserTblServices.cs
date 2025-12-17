using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



using NTier.Model;
using Database.conction;
using NTier.ResponseMessages;
using System.Data;

/// <summary>
/// Summary description for UserTblServices
/// </summary>
/// 

namespace NTier.UserTblServices
{
    public interface IUserTblServices
    {
        string InsertUserTbl(UserTblModel model);
        int[] login(UserTblModel model);
        Dictionary<string, object> GetById(int Id);

        Dictionary<string, object> GetList();

        Dictionary<string, object> GetListArea(int id);

        Dictionary<string, object> GetListUserDataAd();
    }
    public class UserTblServices : IUserTblServices, IDisposable
    {

        private readonly DbConnaction db;

        public UserTblServices()
        {
            db = new DbConnaction();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();

            db.Dispose();
            GC.SuppressFinalize(this);


        }

        //--------------------------------------------------------------------------------------------------------------------------------------------

        // 1.start :-insert data
        public string InsertUserTbl(UserTblModel model)
        {
            //throw new NotImplementedException();
            if (model == null)
                return Messages.ModelIsNull;

            var parameters = new Dictionary<string, object>
            {
              {"@ut", model.UserType},
              {"@nm", model.Name},
              {"@em", model.Email},
              {"@mn", model.Mobile},
              {"@ps", model.Password},
              {"@UVe", model.IsVerified},
              {"@Ac", model.IsActive}
           };

            // Only add Artisan details if it's an Artisan (UserType = 2)
            if (model.UserType == 2)
            {
                parameters.Add("@ShopName", model.ShopName);
                parameters.Add("@ArtisianName", model.ArtisianName);
                parameters.Add("@ShopContactNo", model.ShopContactNo);
                parameters.Add("@ArtisianContactNo", model.ArtisianContactNo);
                parameters.Add("@Address", model.Address);
                parameters.Add("@CityId", model.CityId);
                parameters.Add("@AreaId", model.AreaId);
                parameters.Add("@AddressProof", model.AddressProof);
                parameters.Add("@AdharCard", model.AdharCard);
                parameters.Add("@ShopPhoto", model.ShopPhoto);
                parameters.Add("@ArtisianPhoto", model.ArtisianPhoto);
                parameters.Add("@ShopLogo", model.ShopLogo);
                parameters.Add("@ShopBanarPhoto", model.ShopBanarPhoto);
                parameters.Add("@IsArtisanVerified", model.IsArtisanVerified);
              


            }

            var ResponseDict = db.InsertUpdateArt("SPUserTblInsertUpdate", parameters);
            var retval = Convert.ToByte(ResponseDict["@retval"]);

            if (retval == 0)
                return Messages.Inserted;
            //else if (retval == 1)
            //    return Messages.AlreadyExistCategory;
            else
                return Messages.SomethingWrong;
        }
        // 1.end :-insert data

       //--------------------------------------------------------------------------------------------------------------------------------------------

        // 2.start :-select data

        public Dictionary<string, object> GetById(int Id)
        {
            //throw new NotImplementedException();
            UserTblModel model = null;
            var ResponseData = db.SelectList("SPUserSelect", new Dictionary<string, object>() {

                { "@userid",Id}
                });
            if (ResponseData.ContainsKey("Data"))
            {
               
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                     model = new UserTblModel()
                    {

                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        UserType = Convert.ToInt32(dt.Rows[i]["UserType"]),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Mobile = dt.Rows[i]["Mobile"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),

                    };
                }
                return new Dictionary<string, object>() {
                    { "Data",model}
                };
            }
            else
            {
                return new Dictionary<string, object>()
                {
                        {"Error", ResponseData["Error"]}
                };
            }
        }
        // 2.end :-select data


        // 3.start :-LogIn data  NOTE:- check the email and password
        public int[] login(UserTblModel model)
        {   // Note :- in the code :- int[] login(UserTblModel model)...pass the array

            var ResponseDict = db.SelectList("SPLogin",new Dictionary<string, object>()
                {
                    {"@Em",model.Email },
                    {"@Ps",model.Password },

                });

            DataTable dt = ResponseDict["Data"] as DataTable;

            if (dt.Rows.Count>0)
            {
                int userId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                int userType = Convert.ToInt32(dt.Rows[0]["UserType"]);

                return new int[] { userId, userType };  //Note :- return both the value
            }
            else
            {
                return new int[] {0};
            }
        }


        // 3.End :-LogIn data


        //4. start :- city dropdown fill

        public Dictionary<string, object> GetList()
        {
            //throw new NotImplementedException();

            var ResponseData = db.SelectList("SPCitySelect");

            if (ResponseData.ContainsKey("Data"))
            {
                List<CityTblModel> modelList = new List<CityTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new CityTblModel()
                    {

                        CityId = Convert.ToInt32(dt.Rows[i]["CityId"]),
                        City = dt.Rows[i]["City"].ToString(),


                    });
                }
                return new Dictionary<string, object>() {
                    {"Data",modelList}
                };
            }
            else
            {
                return new Dictionary<string, object>()
                {
                        {"Error", ResponseData["Error"]}
                };
            }

        }


        //4. end :- city dropdown fill


        // 5. start :- fill area dropdown according to City

        public Dictionary<string, object> GetListArea(int id)
        {
            //throw new NotImplementedException();

            Dictionary<string, object> Inperamerater = new Dictionary<string, object>()
            {
                {"@cityid",id }
            };
            var ResponseData = db.SelectList("SPAreaSelectToCity", Inperamerater);

            if (ResponseData.ContainsKey("Data"))
            {
                List<AreaTblModel> modelList = new List<AreaTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new AreaTblModel()
                    {

                        CityId = Convert.ToInt32(dt.Rows[i]["CityId"]),
                        Area = dt.Rows[i]["Area"].ToString(),


                    });
                }
                return new Dictionary<string, object>() {
                    {"Data",modelList}
                };
            }
            else
            {
                return new Dictionary<string, object>()
                {
                        {"Error", ResponseData["Error"]}
                };
            }
        }

        // 5. end :- fill area dropdown according to City

        // 6. start :- fillgrid for user show of admin side

        public Dictionary<string, object> GetListUserDataAd()
        {
            // throw new NotImplementedException();

            var ResponseData = db.SelectList("SPUserSelect");
            if (ResponseData.ContainsKey("Data"))
            {
                List<UserTblModel> modelList = new List<UserTblModel>();
                DataTable dt = ResponseData["Data"] as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(new UserTblModel()
                    {

                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        UserType = Convert.ToInt32(dt.Rows[i]["UserType"]),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Mobile = dt.Rows[i]["Mobile"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),

                    });
                }
                return new Dictionary<string, object>() {
                    {"Data",modelList}
                };
            }
            else
            {
                return new Dictionary<string, object>()
                {
                        {"Error", ResponseData["Error"]}
                };
            }
        }

        // 6. end :- fillgrid for user show of admin side











    }


}