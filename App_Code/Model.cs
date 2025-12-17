using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserTblModel
/// </summary>
/// 


namespace NTier.Model
{

    //1.Start------------CategoryTbl Model

    public class CategoryTblModel
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Icon { get; set; }
        public string Status { get; set; }
        public int EntryDate { get; set; }
    }

    //1.End---------------CategoryTbl Model

    //

    //2.Start-------------SubCategoryTbl Model

    public class SubCategoryTblModel
    {
        public int SubCategoryId { get; set;}
        public string CategoryId { get; set; }
        public string SubCategory { get; set; }
        public string Icon { get; set; }
        public string Status { get; set; }
        public int EntryDate { get; set; }
    }

    //2.End---------------SubCategoryTbl Model

     //

    //3.Start------------CityTbl Model
    public class CityTblModel
    {
        public int CityId { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public int EntryDate { get; set; }
    }
    //3.End---------------CityTbl Model

    //

    //4.Start------------AreaTbl Model
    public class AreaTblModel
    {
        public int AreaId { get; set; }
        public int CityId { get; set; }
        public string Area { get; set; }
        public string Status { get; set; }
        public int EntryDate { get; set; }
    }
    //4.End---------------AreaTbl Model


    //5.Start------------ServiceTypeTbl Model

    public class ServiceTypeTblModel
    {
        public int ServicesTypeId { get; set; }
        public string ServicesType { get; set; }
        public string Icon { get; set; }
        public string Status { get; set; }
        public int EntryDate { get; set; }
    }

    //5.End---------------ServiceTypeTbl Model


    //6.Start------------UserTbl Model

    public class UserTblModel
    {
        public int UserId { get; set; }
        public int UserType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }    

        public int IsActive { get; set; }
        public int EntryDate { get; set; }


        // Artisan-specific fields
        public int ArtisianId { get; set; }
        public string ShopName { get; set; }
        public string ArtisianName { get; set; }
        public long ShopContactNo { get; set; }
        public long ArtisianContactNo { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public string AddressProof { get; set; }
        public string AdharCard { get; set; }
        public string ShopPhoto { get; set; }
        public string ArtisianPhoto { get; set; }
        public string ShopLogo { get; set; }
        public string ShopBanarPhoto { get; set; }
        public bool IsArtisanVerified { get; set; }
        public int IsVerifiedDate { get; set; }

    }


    //6.End---------------UserTypeTbl Model


    // 7. Start -------------ProductTbl Model

    public class ProductTblModel
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string ProductTitle { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public string Photo5 { get; set; }
        public string IsVerified { get; set; }
        public string IsActive { get; set; }
        public int EntryDate { get; set; }


        // Category and SubCategory use for :- catid and subcateid name print in the manage page/gridview
        public string Category { get; set; }
        public string Subcategory { get; set; }



        // for order show
        public int OrderId { get; set; }
        public string Billno { get; set; }
        public string Name { get; set; }
        public string Qty { get; set; }
        public string Total { get; set; }

    }

    // 7. End -------------ProductTbl Model


    // 7. Start -------------ProductTbl Model

    public class ServicesTblModel
    {
        public int ServicesId { get; set; }
        public int UserId { get; set; }
        public int ServicesTypeId { get; set; } 
        public string ServiceTitle { get; set; }
        public string ServicesEstimatePrice { get; set; }
        public string ServicesDescription { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public string Photo5 { get; set; }
        public string IsVerified { get; set; }
        public string IsActive { get; set; }
        public int EntryDate { get; set; }


        // services  use for :- sid  name print in the manage page/gridview
        public string ServicesType { get; set; }
      
    }

    // 7. End -------------ProductTbl Model


    // 8. start _________cartModel

    public class CartTblModel
    {
        public int CartId { get; set; }
        public int UniqeId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public string CustomData { get; set; }
        public int EntryDate { get; set; }



        public string ProductTitle { get; set; }

        public string Photo1 { get; set; }

        public int Price { get; set; }
        public int total { get; set; }

     

     }
    // 8. end _________cartModel


    // 9 .start _________ShippingTbl Model

    public class ShippingTblModel
    {
        public int ShipingId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string AlternateMobile { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string LandMark { get; set; }
        public string Pincode { get; set; }
        public string CityId { get; set; }
        public int AreaId { get; set; }
        public string AddressType { get; set; }
        public string Status { get; set; }
        public DateTime? EntryDate { get; set; }
    }
    // 9 .end _________ShippingTbl Model


    // 10 .start _________OrderTbl Model


    // Note :- Insert  OrderTblModel and  OrderDetailsTbl
    public class OrderTblModel
    {

        // for ordertbl
        public int OrderId { get; set; }

        public string Billno { get; set; }

        public int ShipingId { get; set; }

        public int UserId { get; set; }

        public string TotalAmount { get; set; }

        public string TotalQty { get; set; }

        public string Status { get; set; }

        public string OrderStatus { get; set; }

        public string PaymentStatus { get; set; }

        public string PaymentType { get; set; }

        public int EntryDate { get; set; }



        // for orderdetailtbl

       public int  OrderDetailId { get; set; }

        public int ProductId { get; set; }

        public string Price { get; set; }

        public int Qty { get; set; }

        public string ProductTitle { get; set; }


        // for billing add show--> as per required

        public string CusttName { get; set; }
        public string CustMobile { get; set; }

        public string CusttAddress { get; set; }


    }
    // 10 .start _________OrderTbl Model

}