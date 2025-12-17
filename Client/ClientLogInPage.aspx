<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientMasterPage.master" AutoEventWireup="true" CodeFile="ClientLogInPage.aspx.cs" Inherits="Client_ClientLogInPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">

      <!-- Page Title/Header Start -->
    <div class="page-title-section section" data-bg-image="assets/images/bg/page-title-1.webp">
        <div class="container">
            <div class="row">
                <div class="col">

                    <div class="page-title">
                        <h1 class="title">LogIn Form</h1>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="ClientHomeIPage.aspx">Home</a></li>
                            <li class="breadcrumb-item active">LogIn Form</li>
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
                            <h2 class="title">Login</h2>
                            <p class="desc">Great to have you back!</p>
                        </div>

                        <div class="login-register-form">
                            <div>
                                <div class="row learts-mb-n50">

                                    <%-- Email --%>
                                    <div class="col-12 learts-mb-50">
                                        <%--<input type="email" placeholder="Email Address">--%>
                                        <asp:TextBox ID="TxtEmail" type="email" placeholder="Email Address" runat="server"></asp:TextBox>
                                    </div>

                                    <%-- PassWord --%>
                                    <div class="col-12 learts-mb-50">
                                        <%--<input type="password" placeholder="Password">--%>
                                        <asp:TextBox ID="TxtPassword" type="password" placeholder="Password"  runat="server"></asp:TextBox>
                                    </div>

                                    <%-- Btn LogIn --%>
                                    <div class="col-12 text-center learts-mb-50">
                                       <%-- <button class="btn btn-dark btn-outline-hover-dark">login</button>--%>
                                        <asp:Button ID="BtnLogIn" OnClick="BtnLogIn_Click" runat="server" Text="LogIn" class="btn btn-dark btn-outline-hover-dark"/>

                                    </div>
                                    <div class="col-12 learts-mb-50">
                                      <%--  <div class="row learts-mb-n20">
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
                      
                    <img src="assets/images/imglog3.jpg" alt="">
                    </div>
                </div>


            </div>

        </div>

    </div>
    <!-- Login & Register Section End -->



</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

