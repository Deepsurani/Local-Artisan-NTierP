<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminManageUserPage.aspx.cs" Inherits="AdminManageUserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style>
        .table thead {
            background-color: #007bff;
            color: white;
        }

        .card {
            border-radius: 10px;
        }

        .table td, .table th {
            vertical-align: middle;
        }

        .table img {
            border-radius: 6px;
        }

        .action-btns button {
            margin-right: 5px;
        }

        @media (max-width: 767px) {
            .table-responsive {
                font-size: 14px;
            }
            .btn {
                font-size: 12px;
                padding: 4px 8px;
            }
        }
    </style>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">



     <div class="container-fluid pt-4 px-4">
        <div class="bg-light text-center rounded p-4 shadow-sm">
            <div class="d-flex align-items-center justify-content-between mb-4">
                <h5 class="mb-0 text-primary"><i class="fa fa-list me-2"></i>Manage User</h5>
               <%-- <a href="#" class="btn btn-primary">
                    <i class="fa fa-plus"></i> Add New
                </a>--%>
                <h6 class="mb-0 text-primary">UserType 1 : For Artisian</br>UserType 2 : For Ciient</h6>
                
            </div>

            <div class="table-responsive">
                <asp:GridView ID="GridViewUser" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover align-middle text-start" OnRowCommand="GridViewUser_RowCommand">
                    <Columns>

                 
                        <%-- Id --%>
                        <asp:TemplateField HeaderText="UserId">
                            <ItemTemplate>
                                    <%#Eval("UserId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- User Type --%>
                        <asp:TemplateField HeaderText="User Type">
                            <ItemTemplate>
                                    <%#Eval("UserType") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- Name --%>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                     <%#Eval("Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- Email --%>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                  <%#Eval("Email") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <%-- Email --%>
                        <asp:TemplateField HeaderText="Mobile">
                            <ItemTemplate>
                                  <%#Eval("Mobile") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <%--Edit--%>   <%--  ?Edit= ...querystring--%>
                       <%-- <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <a href='AdminCreateCategoryPage.aspx?EditCat=<%#Eval("CategoryId")%>' class="btn btn-info"><i class="fa fa-edit"></i>&nbsp;Edit</a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--Delete--%>
                       <%-- <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>                            
                                 <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-danger" OnClientClick="return confirm('are you sure dlt data?')" CommandName="del" CommandArgument='<%#Eval("CategoryId") %>'><i class="fa fa-trash"></i>&nbsp;Delete</asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>--%>



                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>




</asp:Content>




<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

