<%@ Page Title="" Language="C#" MasterPageFile="~/Artisian/ArtisianMasterPage.master" AutoEventWireup="true" CodeFile="ArtisianManageProductAddPage.aspx.cs" Inherits="Artisian_ArtisianManageProductAddPage" %>

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
                <h5 class="mb-0 text-primary"><i class="fa fa-list me-2"></i>Manage Product</h5>
                <a href="ArtisianProductAdd.aspx" class="btn btn-primary">
                    <i class="fa fa-plus"></i> Add New
                </a>
            </div>

            <div class="table-responsive">
                <asp:GridView ID="GridViewProduct" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewProduct_RowCommand" CssClass="table table-bordered table-hover align-middle text-start">
                    <Columns>

                 
                        <%-- Product Id --%>
                        <asp:TemplateField HeaderText="Product Id">
                            <ItemTemplate>
                                    <%#Eval("ProductId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- UserId --%>
                        <asp:TemplateField HeaderText="User Id">
                            <ItemTemplate>
                                    <%#Eval("UserId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <%-- Category Id --%>
                        <asp:TemplateField HeaderText="Category Id">
                            <ItemTemplate>
                                    <%#Eval("Category") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <%-- SubCategory Id --%>
                        <asp:TemplateField HeaderText="SubCategory Id">
                            <ItemTemplate>
                                    <%#Eval("Subcategory") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <%-- Product Title --%>
                        <asp:TemplateField HeaderText="Product Title">
                            <ItemTemplate>
                                    <%#Eval("ProductTitle") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <%-- Price --%>
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                    <%#Eval("Price") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                             <%-- Photo1 --%>
                        <asp:TemplateField HeaderText="Photo1">
                            <ItemTemplate>
                                    <%#Eval("Photo1") %>
                            </ItemTemplate>
                        </asp:TemplateField>




                        <%--Edit--%>   <%--  ?Edit= ...querystring--%>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <a href="ArtisianProductAdd.aspx?EditProduct=<%#Eval("ProductId") %>" class="btn btn-info"><i class="fa fa-edit"></i>&nbsp;Edit</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--Delete--%>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>                            
                                 <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-danger" OnClientClick="return confirm('are you sure dlt data?')" CommandName="del" CommandArgument='<%#Eval("ProductId") %>'><i class="fa fa-trash"></i>&nbsp;Delete</asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>



                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>








</asp:Content>





<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

