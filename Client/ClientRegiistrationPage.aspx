<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientMasterPage.master" AutoEventWireup="true" CodeFile="ClientRegiistrationPage.aspx.cs" Inherits="Client_ClientRegiistrationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">

     <!-- Page Title/Header Start -->
    <div class="page-title-section section" data-bg-image="assets/images/bg/page-title-1.webp">
        <div class="container">
            <div class="row">
                <div class="col">

                    <div class="page-title">
                        <h1 class="title">Register As Customer</h1>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                            <li class="breadcrumb-item active">Register As Customer</li>
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
                            <h2 class="title">Register As Customer</h2>
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

                                    <%-- btn Registration --%>
                                    <div class="col-12 text-center learts-mb-50">

                                        <%--<button class="btn btn-dark btn-outline-hover-dark">Registration</button>--%>
                                       <asp:Button ID="BtnRegistration" OnClick="BtnRegistration_Click" runat="server" Text="Registration" class="btn btn-dark btn-outline-hover-dark"/>

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
                      
                    <img src="assets/images/img1reg.jpg" alt="">
                    </div>
                </div>
            </div>

        </div>

    </div>
    <!-- Login & Register Section End -->




</asp:Content>







<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

