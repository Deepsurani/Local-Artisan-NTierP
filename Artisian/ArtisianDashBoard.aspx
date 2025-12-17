<%@ Page Title="" Language="C#" MasterPageFile="~/Artisian/ArtisianMasterPage.master" AutoEventWireup="true" CodeFile="ArtisianDashBoard.aspx.cs" Inherits="Artisian_ArtisianDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">


    
    <div class="container-fluid pt-4 px-4">
        <div class="row g-4">

            <!-- Total Products -->
            <div class="col-sm-6 col-xl-3">
                <div class="bg-light rounded d-flex align-items-center justify-content-between p-4 shadow-sm">
                    <i class="fa fa-box fa-3x text-primary"></i>
                    <div class="ms-3 text-end">
                        <p class="mb-2">Total Products</p>
                        <h6 class="mb-0">120</h6>
                    </div>
                </div>
            </div>

            <!-- Total Services -->
            <div class="col-sm-6 col-xl-3">
                <div class="bg-light rounded d-flex align-items-center justify-content-between p-4 shadow-sm">
                    <i class="fa fa-tools fa-3x text-success"></i>
                    <div class="ms-3 text-end">
                        <p class="mb-2">Total Services</p>
                        <h6 class="mb-0">85</h6>
                    </div>
                </div>
            </div>

            <!-- Total Orders -->
            <div class="col-sm-6 col-xl-3">
                <div class="bg-light rounded d-flex align-items-center justify-content-between p-4 shadow-sm">
                    <i class="fa fa-shopping-cart fa-3x text-warning"></i>
                    <div class="ms-3 text-end">
                        <p class="mb-2">Total Orders</p>
                        <h6 class="mb-0">540</h6>
                    </div>
                </div>
            </div>

            <!-- Payments -->
            <div class="col-sm-6 col-xl-3">
                <div class="bg-light rounded d-flex align-items-center justify-content-between p-4 shadow-sm">
                    <i class="fa fa-credit-card fa-3x text-danger"></i>
                    <div class="ms-3 text-end">
                        <p class="mb-2">Payments Received</p>
                        <h6 class="mb-0">₹1,25,000</h6>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <!-- Quick Navigation Buttons -->
    <div class="container-fluid pt-4 px-4">
        <div class="bg-light rounded p-4 shadow-sm">
            <h5 class="mb-4 text-center text-uppercase fw-bold text-primary">Quick Actions</h5>
            <div class="row g-3 justify-content-center">

                <div class="col-md-2 col-sm-6">
                    <a href="ManageProduct.aspx" class="btn btn-outline-primary w-100 py-3">
                        <i class="fa fa-box me-2"></i>Manage Product
                    </a>
                </div>

                <div class="col-md-2 col-sm-6">
                    <a href="ManageService.aspx" class="btn btn-outline-success w-100 py-3">
                        <i class="fa fa-tools me-2"></i>Manage Service
                    </a>
                </div>

                <div class="col-md-2 col-sm-6">
                    <a href="ManageOrder.aspx" class="btn btn-outline-warning w-100 py-3">
                        <i class="fa fa-shopping-cart me-2"></i>Manage Order
                    </a>
                </div>

                <div class="col-md-2 col-sm-6">
                    <a href="ManagePayment.aspx" class="btn btn-outline-danger w-100 py-3">
                        <i class="fa fa-credit-card me-2"></i>Manage Payment
                    </a>
                </div>

                <div class="col-md-2 col-sm-6">
                    <a href="Order.aspx" class="btn btn-outline-info w-100 py-3">
                        <i class="fa fa-file-invoice me-2"></i>New Order
                    </a>
                </div>

            </div>
        </div>
    </div>

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

