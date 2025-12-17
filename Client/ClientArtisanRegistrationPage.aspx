<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientMasterPage.master" AutoEventWireup="true" CodeFile="ClientArtisanRegistrationPage.aspx.cs" Inherits="Client_ClientArtisanRegistrationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">

      <!-- Page Title/Header Start -->
    <div class="page-title-section section" data-bg-image="assets/images/bg/page-title-1.webp">
        <div class="container">
            <div class="row">
                <div class="col">

                    <div class="page-title">
                        <h1 class="title">Register As Artisan</h1>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                            <li class="breadcrumb-item active">Register As Artisan</li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- Page Title/Header End -->


      <!-- Login & Register Section Start -->
    <div class="section section-padding">
        <div class="container">
            <div class="row g-0">

                <div class="col-lg-6">
                    <div class="user-login-register bg-light">
                        <div class="login-register-title">
                            <h2 class="title">Register As Artisan</h2>
                            <p class="desc">Great to have you back!</p>
                        </div>

                        <div class="login-register-form">
                            <div>
                                <div class="row learts-mb-n50">

                                    

                                    <%-- User Name --%>

                                    <div class="col-12 learts-mb-50">
                                       <%-- <input type="password" placeholder="Password">--%>
                                        <asp:TextBox ID="TxtName" placeholder="Name" runat="server"></asp:TextBox>

                                    </div>

                                     <%-- Email --%>

                                    <div class="col-12 learts-mb-50">
                                       <%-- <input type="password" placeholder="Password">--%>
                                        <asp:TextBox ID="TxtEmail" placeholder="Email" runat="server"></asp:TextBox>

                                    </div>

                                       <%-- Mobile Number --%>

                                    <div class="col-12 learts-mb-50">
                                       <%-- <input type="password" placeholder="Password">--%>
                                        <asp:TextBox ID="TxtMobile" placeholder="Mobile" runat="server"></asp:TextBox>

                                    </div>

                                       <%--  Password --%>

                                    <div class="col-12 learts-mb-50">
                                       <%-- <input type="password" placeholder="Password">--%>
                                        <asp:TextBox ID="TxtPassword" placeholder="Password" type="password" runat="server"></asp:TextBox>

                                    </div>
                                    <%--  --%>
                                      <div class="col-12 learts-mb-50">

                                          <asp:TextBox ID="TxtShopName" CssClass="form-control mb-3" placeholder="Shop Name" runat="server"></asp:TextBox>
                                      </div>

                                      <div class="col-12 learts-mb-50">
                                           <asp:TextBox ID="TxtArtisanName" CssClass="form-control mb-3" placeholder="Artisan Name" runat="server"></asp:TextBox>
                                      </div>

                                      <div class="col-12 learts-mb-50">
                                           <asp:TextBox ID="TxtShopContact" CssClass="form-control mb-3" placeholder="Shop Contact No." runat="server"></asp:TextBox>
                                      </div>

                                      <div class="col-12 learts-mb-50">
                                          <asp:TextBox ID="TxtArtisanContact" CssClass="form-control mb-3" placeholder="Artisan Contact No." runat="server"></asp:TextBox>
                                      </div>

                                      <div class="col-12 learts-mb-50">
                                           <asp:TextBox ID="TxtAddress" CssClass="form-control mb-3" placeholder="Address" runat="server"></asp:TextBox>
                                      </div>

                                      <div class="col-12 learts-mb-50">
                                           <label>City</label>
                                           <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="DropCity_SelectedIndexChanged" class="form-control" ID="DropCity" name="City" runat="server"> </asp:DropDownList>
                                            <%-- NOTE:-  OnSelectedIndexChanged — event triggered when a user changes the selected item in a dropdown or list control (like DropDownList) in ASP.NET. --%>
                                            <%--NOTE:- AutoPostBack — when set to true, it automatically sends the page to the server (postback) as soon as the control’s value changes. --%>
                                      </div>

                                      <div class="col-12 learts-mb-50">
                                            <label>Area</label>
                                           <asp:DropDownList class="form-control" ID="DropArea" name="Area" runat="server"> </asp:DropDownList>
                                      </div>

                                      <div class="col-12 learts-mb-50">
                                            <label>Address Proof</label>
                                           <asp:FileUpload ID="fuAddressProof" CssClass="form-control mb-3" runat="server" />
                                      </div>

                                    
                                      <div class="col-12 learts-mb-50">
                                            <label>AdharCard Proof</label>
                                           <asp:FileUpload ID="fuAdharCard" CssClass="form-control mb-3"  runat="server" />
                                      </div>

                                     <div class="col-12 learts-mb-50">
                                           <label>ShopPhoto</label>
                                           <asp:FileUpload ID="fuShopPhoto" CssClass="form-control mb-3" runat="server" />
                                      </div>

                                     <div class="col-12 learts-mb-50">
                                           <label>ArtisanPhoto</label>
                                           <asp:FileUpload ID="fuArtisanPhoto" CssClass="form-control mb-3" runat="server" />
                                      </div>

                                     <div class="col-12 learts-mb-50">
                                           <label>ShopLogo</label>
                                           <asp:FileUpload ID="fuShopLogo" CssClass="form-control mb-3" runat="server" />
                                      </div>

                                     <div class="col-12 learts-mb-50">
                                           <label>Shop Baner Logo</label>
                                           <asp:FileUpload ID="fuShopBanarLogo" CssClass="form-control mb-3" runat="server" />
                                      </div>

                                    <%-- btn Registration --%>
                                    <div class="col-12 text-center learts-mb-50">

                                        <%--<button class="btn btn-dark btn-outline-hover-dark">Registration</button>--%>
                                       <asp:Button ID="BtnArtisanRegistration" OnClick="BtnArtisanRegistration_Click" runat="server" Text="Artisan Registration" class="btn btn-dark btn-outline-hover-dark"/>

                                    </div>
                                    <div class="col-12 learts-mb-50">

                                         <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mb-2" Visible="false"></asp:Label>
                                       <%-- <div class="row learts-mb-n20">
                                            <div class="col-12 learts-mb-20">
                                                <div class="form-check">
                                                    <input type="checkbox" class="form-check-input" id="rememberMe">
                                                    <label class="form-check-label" for="rememberMe">Remember me</label>
                                                </div>
                                            </div>
                                            <div class="col-12 learts-mb-20">
                                                <a href="lost-password.html" class="fw-400">Lost your password?</a>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>




                <div class="col-lg-6">
                    <div class="user-login-register">
                      
                    <img src="assets/images/imgartreg1.jpg" alt="">
                    </div>
                </div>
            </div>

        </div>

    </div>
    <!-- Login & Register Section End -->



</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

