<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminCreateServicesTypePage.aspx.cs" Inherits="Admin_AdminServicesTypePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">


    
       <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header bg-primary text-white">
                        <h4 class="mb-0">Service Type</h4>
                          <a href="AdminManageServicesTypePage.aspx" class="btn btn-primary">
                          <i class="fa fa-plus"></i> Add New
                </a>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mb-2" Visible="false"></asp:Label>



                        <!-- ServiceType -->
                        <div class="mb-3">
                            <label for="txtservicetype" class="form-label">ServiceType</label>
                            <asp:TextBox ID="TxtServiceType" runat="server" CssClass="form-control" />
                        </div>

                        <%-- Icon --%>

                        <div class="mb-3">
                            <label for="Icon" class="form-label">Icon</label>
                            <asp:FileUpload class="form-control" name="IconUpload" type="file" ID="FuAdServiceTypeCreate" runat="server" />

                        </div>

                        <%-- EditImage  --%>
                          <div class="mb-3">
                            <label for="EditImage" runat="server" id="Editimglable" class="form-label">Edit Image</label>
                            <asp:Image Height="100px" Width="100px" ID="ForEditImg" runat="server" />                            
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
                                <asp:Button ID="BtnServiceTypeSave" runat="server" Text="Save Service Type" OnClick="BtnServiceTypeSave_Click" CssClass="btn btn-primary"/>
                            </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

