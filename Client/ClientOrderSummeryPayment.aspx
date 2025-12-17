<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientMasterPage.master" AutoEventWireup="true" CodeFile="ClientOrderSummeryPayment.aspx.cs" Inherits="Client_ClientOrderSummeryPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="Server">


    <!-- Page Title/Header Start -->
    <div class="page-title-section section" data-bg-image="assets/images/bg/page-title-1.webp">
        <div class="container">
            <div class="row">
                <div class="col">

                    <div class="page-title">
                        <h1 class="title">OrderSummery & Payment</h1>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                            <li class="breadcrumb-item active">OrderSummery & Payment</li>
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



            <%-- start :- Order Details--%>
            <div class="section-title2 text-center">
                <h2 class="title">Your order</h2>
            </div>


            <div class="row learts-mb-n30">

                <div class="col-lg-6 order-lg-2 learts-mb-30">
                    <div class="order-review">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="name">Product</th>
                                    <th class="total">Subtotal</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RptCartList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="name">
                                                <%# Eval("ProductName") %>
                                                <strong class="quantity">× <%# Eval("Qty") %></strong>
                                            </td>
                                            <td class="total"><span>₹ <%# Eval("SubTotal") %></span></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr class="subtotal">
                                    <th>Subtotal</th>
                                    <td><span>₹
                                        <asp:Label ID="LblSubTotal" runat="server"></asp:Label></span></td>
                                </tr>

                                <tr class="Discount">
                                    <th>Discount</th>
                                    <td><span>₹
                                        <asp:Label ID="LblDiscount" runat="server"></asp:Label></span></td>
                                </tr>

                                <tr class="discountpercent">
                                    <th>Discount (%)</th>
                                    <td><span>
                                        <asp:Label ID="LblDiscountPercent" runat="server"></asp:Label></span></td>
                                </tr>

                                <tr class="total">
                                    <th>Total</th>
                                    <td><strong><span>₹
                                        <asp:Label ID="LblCartTotal" runat="server"></asp:Label></span></strong></td>
                                </tr>
                               <asp:HiddenField ID="totalqty" runat="server"/>
                            </tfoot>
                        </table>
                    </div>

                    <h6 style="margin-top: 10px;">
                        <asp:Label ID="LblYouSave" runat="server"></asp:Label></h6>

                </div>

                <div class="col-lg-6 order-lg-1 learts-mb-30">
                    <div class="order-payment">
                        <div class="payment-method">
                            <div class="accordion" id="paymentMethod">
                                
                                <div class="card">
                                    <div class="card-header">
                                          <asp:RadioButton ID="RadioButton1" runat="server" GroupName="rdopayment" Text="Online Payment" />
                                        
                                    </div>
                                   <%-- <div id="cashkPayments" class="collapse" data-bs-parent="#paymentMethod">
                                        <div class="card-body">
                                            <p>Pay with cash upon delivery.</p>
                                        </div>
                                    </div>--%>
                                </div>

                                <div class="card">
                                    <div class="card-header">
                                            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="rdopayment" Text="Cash On Delivery" />
                                    </div>

                                   <%-- <div id="payPalPayments" class="collapse" data-bs-parent="#paymentMethod">
                                        <div class="card-body">
                                            <p>Pay via PayPal; you can pay with your credit card if you don’t have a PayPal account.</p>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="text-center">
                           <%-- <p class="payment-note">Your personal data will be used to process your order, support your experience throughout this website, and for other purposes described in our privacy policy.</p>
                            <button class="btn btn-dark btn-outline-hover-dark">place order</button>--%>
                            <asp:Button ID="BtnOrderTblPlaceOrder" class="btn btn-dark btn-outline-hover-dark" OnClick="BtnOrderTblPlaceOrder_Click" Text="Place Order"  runat="server"/>
                            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mb-2" Visible="false"></asp:Label>
                             </div>
                        <%-- End :- Order Details--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Checkout Section End -->









</asp:Content>






<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" runat="Server">
</asp:Content>

