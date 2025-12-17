<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminCreateCityPage.aspx.cs" Inherits="Admin_AdminCreateCityPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">

         <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header bg-primary text-white">
                        <h4 class="mb-0">City</h4>

                          <a href="AdminManageCityPage.aspx" class="btn btn-primary">
                          <i class="fa fa-plus"></i> Add New
                          </a>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mb-2" Visible="false"></asp:Label>



                        <!-- City -->
                        <div class="mb-3">
                            <label for="txtcity" class="form-label">City</label>
                            <asp:TextBox ID="TxtCity" runat="server" CssClass="form-control" />
                        </div>

  

                        <%-- Status --%>
                           <div class="mb-3">
                            <label for="Status" class="form-label">Status</label>
                               <asp:DropDownList class="form-control" ID="DropStatus" name="Status" runat="server">
                                   <asp:ListItem Value="1">Active</asp:ListItem>
                                   <asp:ListItem Value="0">Deactive</asp:ListItem>
                               </asp:DropDownList>

                        </div>
                                                               

                            <!-- Submit -->
                            <div class="d-grid">
                                <asp:Button ID="BtnCitySave" runat="server" OnClick="BtnCitySave_Click" Text="Save City" CssClass="btn btn-primary"/>
                            </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

