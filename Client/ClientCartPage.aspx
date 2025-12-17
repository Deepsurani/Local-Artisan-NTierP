<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientMasterPage.master" AutoEventWireup="true" CodeFile="ClientCartPage.aspx.cs" Inherits="Client_ClientCartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">


     <!-- Page Title/Header Start -->
    <div class="page-title-section section" data-bg-image="assets/images/bg/page-title-1.webp">
        <div class="container">
            <div class="row">
                <div class="col">

                    <div class="page-title">
                        <h1 class="title">Cart</h1>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                            <li class="breadcrumb-item active">Cart</li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- Page Title/Header End -->




    <!-- Shopping Cart Section Start -->
    <div class="section section-padding">
        <div class="container">

            <form class="cart-form" action="#">

                <table class="cart-wishlist-table table">
                  <%--  produt title--%>
                    <thead>
                        <tr>
                            <th class="name" colspan="2">Product</th>
                            <th class="price">Price</th>
                            <th class="quantity">Quantity</th>
                            <th class="subtotal">Total</th>
                            <th class="Delete">&nbsp;&nbsp;Delete</th>
                            <th class="UpdateQty">&nbsp;&nbsp;UpdateQty</th>
                        </tr>
                    </thead>
                     <%--  produt title--%>

                     <%--  produt Body--%>
                    <tbody>

                     <asp:Repeater ID="rptProduct" OnItemCommand="rptProduct_ItemCommand" runat="server">
                        <ItemTemplate>
                             <asp:HiddenField id="hidqty" Value='<%#Eval("Qty") %>' runat="server" />
                          <tr>
                              <td class="thumbnail">
                                  <a href="product-details.html">
                                      <%--<img src="assets/images/product/cart-product-1.webp" alt="cart-product-1">--%>
                                     <asp:Image ID="imgpro1" ImageUrl='<%#Eval("Photo1")%>'  runat="server"/>
                                  </a>
                              </td>
                              <td class="name"> <a href="product-details.html"><%#Eval("ProductTitle")%></a></td>

                              <td class="price">
                                  <span><%#Eval("Price")%></span>
                              </td>

                              <td class="quantity">
                                <div class="product-quantity">
                                    <%--<span class="qty-btn minus"><i class="ti-minus"></i></span>
                                    <input type="text" class="input-qty" value="1">
                                    <span class="qty-btn plus"><i class="ti-plus"></i></span>--%>

                                     <asp:TextBox ID="TxtQty" Height="50px" Width="50px" Text='<%#Eval("Qty") %>' type="number" runat="server"></asp:TextBox>
                                </div>
                              </td>
                              <td class="subtotal"><span><%#Eval("total") %></span></td>     <%-- this total is the quantity+ productprice-- %>
                             <%-- <td class="remove"><a href="#" class="btn">×</a></td>--%>
                              <td>                              
                                  <asp:LinkButton ID="btndelete" class="btn"   CommandName="RowdeleteBtn" OnClientClick="return confirm('are you sure dlt these data row')"  CommandArgument='<%#Eval("ProductId")%>' runat="server">×</asp:LinkButton>

                               </td>

                               <td>                              
                                  <asp:LinkButton ID="btnUpdate" class="btn"   CommandName="RowUpdateBtn"   CommandArgument='<%#Eval("ProductId")%>' runat="server">Update</asp:LinkButton>

                               </td>


                           </tr>   


                        </ItemTemplate>
                    </asp:Repeater>
                                       
                    </tbody>
                     <%--  produt Body--%>

                </table>
                <div class="row justify-content-between mb-n3">
                    <div class="col-auto mb-3">
                        <div class="cart-coupon">
                            <input type="text" placeholder="Enter your coupon code">
                            <button class="btn"><i class="fas fa-gift"></i></button>
                        </div>
                    </div>
                    <div class="col-auto">
                        <a class="btn btn-light btn-hover-dark mr-3 mb-3" href="ClientProductShowPage.aspx">Continue Shopping</a>
                       <%-- <button class="btn btn-dark btn-outline-hover-dark mb-3">Update Cart</button>--%>
                    </div>
                </div>
            </form>

           <%-- start :-Cart Totals--%>
            <div class="cart-totals mt-5">
                <h2 class="title">Cart Totals</h2>
            
                    <table>
                    <tbody>
                        <tr class="cartsubtotal">
                            <th>CartSubTotal</th>
                            <%--<td><span class="amount">Rs242.00</span></td>--%>
                            <td>
                               <span>
                                 <asp:Label ID="LblSubTotal" runat="server">
                                 </asp:Label>
                                </span>
                            </td>
                        </tr>

                         <tr class="Discount">
                            <th>Discount</th>
                            <%--<td><span class="amount">Rs.242.00</span></td>--%>
                             <td>
                                 <span>
                                  <asp:Label ID="LblDiscount" runat="server">
                                  </asp:Label>
                                   </span>
                             </td>
                        </tr>

                        <tr class="discountpercent">
                            <th>Discount (%)</th>
                            <td>
                                <span>
                                    <asp:Label ID="LblDiscountPercent" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>

                        <tr class="total">
                            <th>Total Amount</th>
                            <%--<td><strong><span class="amount">Rs.242.00</span></strong></td>--%>
                            <td>
                               <span>
                                <asp:Label ID="LblCatrTotal" runat="server">
                                </asp:Label>
                               </span>
                            </td>
                        </tr>

                     
                              
                                   

                    </tbody>

                </table>
                <h6><asp:Label ID="LblYouSave" runat="server"></asp:Label></h6> 
                <a href="CheckOutPage.aspx" class="btn btn-dark btn-outline-hover-dark">Proceed to checkout</a>

           
            </div>
                <%-- end :-Cart Totals--%>
        </div>

    </div>
    <!-- Shopping Cart Section End -->


</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

