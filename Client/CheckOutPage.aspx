<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientMasterPage.master" AutoEventWireup="true" CodeFile="CheckOutPage.aspx.cs" Inherits="Client_CheckOutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">


      <!-- Page Title/Header Start -->
    <div class="page-title-section section" data-bg-image="assets/images/bg/page-title-1.webp">
        <div class="container">
            <div class="row">
                <div class="col">

                    <div class="page-title">
                        <h1 class="title">Checkout</h1>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                            <li class="breadcrumb-item active">Checkout</li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- Page Title/Header End -->

    <!-- Checkout Section Start -->
    <div class="section section-padding">
        <div class="container">
            <div class="checkout-coupon">
                <p class="coupon-toggle">Have a coupon? <a href="#checkout-coupon-form" data-bs-toggle="collapse">Click here to enter your code</a></p>
                <div id="checkout-coupon-form" class="collapse">
                    <div class="coupon-form">
                        <p>If you have a coupon code, please apply it below.</p>
                        <div> action="#" class="learts-mb-n10">
                            <input class="learts-mb-10" type="text" placeholder="Coupon code">
                            <button class="btn btn-dark btn-outline-hover-dark learts-mb-10">apply coupon</button>
                        </div>
                    </div>
                </div>
            </div>

           <%-- start :- Billing Details--%>

            <asp:Panel ID="PanelBillDetails" runat="server">

                  <div class="section-title2">
    <h2 class="title">Billing details/Shipping Address</h2>
</div>
 <asp:Button ID="BtnOldAdd" OnClick="BtnOldAdd_Click" class="btn btn-dark btn-outline-hover-dark" BorderStyle="None" runat="server" Text="Old Address" />


<div class="checkout-form learts-mb-50">

    <div class="row">

        <!-- Full Name -->
        <div class="col-12 learts-mb-20">
            <label for="txtName">Full Name <abbr class="required">*</abbr></label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Full Name"></asp:TextBox>
        </div>

        <!-- Mobile -->
        <div class="col-md-6 col-12 learts-mb-20">
            <label for="txtMobile">Mobile <abbr class="required">*</abbr></label>
            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile Number"></asp:TextBox>
        </div>

        <!-- Alternate Mobile -->
        <div class="col-md-6 col-12 learts-mb-20">
            <label for="txtAlternateMobile">Alternate Mobile</label>
            <asp:TextBox ID="txtAlternateMobile" runat="server" CssClass="form-control" placeholder="Alternate Mobile Number"></asp:TextBox>
        </div>

        <!-- Address -->
        <div class="col-12 learts-mb-20">
            <label for="txtAddress">Address <abbr class="required">*</abbr></label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Street / House No. / Area"></asp:TextBox>
        </div>

        <!-- Locality -->
        <div class="col-md-6 col-12 learts-mb-20">
            <label for="txtLocality">Locality <abbr class="required">*</abbr></label>
            <asp:TextBox ID="txtLocality" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <!-- Landmark -->
        <div class="col-md-6 col-12 learts-mb-20">
            <label for="txtLandmark">Landmark</label>
            <asp:TextBox ID="txtLandmark" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <!-- Pincode -->
        <div class="col-md-6 col-12 learts-mb-20">
            <label for="txtPincode">Pincode <abbr class="required">*</abbr></label>
            <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <!-- City -->
        <div class="col-md-6 col-12 learts-mb-20">
            <label for="ddlCity">City <abbr class="required">*</abbr></label>
            <asp:DropDownList ID="ddlCity" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" runat="server" CssClass="form-select select2-basic">
                <asp:ListItem Value="">Select City</asp:ListItem>
            </asp:DropDownList>

           <%--  <asp:DropDownList  class="form-control" ID="DropCategoryId"  AutoPostBack="true" OnSelectedIndexChanged="DropCategoryId_SelectedIndexChanged" name="CategoryId" runat="server">

             </asp:DropDownList>--%>
        </div>

        <!-- Area -->
        <div class="col-md-6 col-12 learts-mb-20">
            <label for="ddlArea">Area <abbr class="required">*</abbr></label>
            <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-select select2-basic">
                <asp:ListItem Value="">Select Area</asp:ListItem>
            </asp:DropDownList>
        </div>

        <!-- Address Type -->
        <div class="col-md-6 col-12 learts-mb-20">
            <label for="ddlAddressType">Address Type <abbr class="required">*</abbr></label>
            <asp:DropDownList ID="ddlAddressType" runat="server" CssClass="form-select select2-basic">
                <asp:ListItem Value="">Select</asp:ListItem>
                <asp:ListItem Value="Home">Home</asp:ListItem>
                <asp:ListItem Value="Office">Office</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="text-center">
            <p class="payment-note">
                Your personal data will be used to process your order, support your experience throughout this website,
                and for other purposes described in our privacy policy.
            </p>

         <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mb-2" Visible="false"></asp:Label>
         <asp:Label ID="Label1" runat="server" CssClass="text-danger mb-2" Visible="false"></asp:Label>
            

            <asp:Button ID="btnPlaceOrder" OnClick="btnPlaceOrder_Click" runat="server" Text="Place Order" CssClass="btn btn-dark btn-outline-hover-dark" />
        </div>

    </div>

</div>


            </asp:Panel>
    

              <%-- End :- Billing Details--%>


            <%-- start :- panel old add show --%>

             <asp:Panel ID="PanelOldAdd" Visible="false" runat="server">

    <!-- New Bill Add Button -->
    <div class="text-end mb-3">
        <asp:Button ID="NewBillDetail" CssClass="btn btn-success" OnClick="NewBillDetail_Click"
            Text="New Add Bill Detail" runat="server" />
    </div>

    <!-- Shipping Address List -->
    <div class="row">
        <asp:Repeater ID="Rptoldadd" runat="server">
            <ItemTemplate>
                <div class="col-lg-6 col-md-6 col-sm-12 mb-4">
                    <div class="card shadow-sm border rounded p-3">

                        <div class="d-flex justify-content-between align-items-center mb-2">
                            <h5 class="m-0">
                                <i class="bi bi-person-fill"></i>
                                <%# Eval("Name") %>
                            </h5>

                            <a href='ClientOrderSummeryPayment.aspx?spid=<%#Eval("ShipingId") %>' 
                               class="btn btn-primary btn-sm">
                                Use This
                            </a>
                        </div>

                        <div class="mb-2">
                            <strong>Address :</strong><br />
                            <%# Eval("Address") %>
                        </div>

                        <div>
                            <strong>Mobile :</strong> <%# Eval("Mobile") %>
                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Panel>



              <%-- end :- panel old add show --%>

         
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Checkout Section End -->






</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

