<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminManageOrder.aspx.cs" Inherits="Admin_AdminManageOrder" %>

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
                <h5 class="mb-0 text-primary"><i class="fa fa-list me-2"></i>Manage Order</h5>
               <%-- <a href="#" class="btn btn-primary">
                    <i class="fa fa-plus"></i> Add New
                </a>--%>
               
                
            </div>

            <div class="table-responsive">
                <asp:GridView ID="GridViewOrder" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover align-middle text-start">
                    <Columns>

                 
                        <%-- Id --%>
                        <asp:TemplateField HeaderText="OrderId">
                            <ItemTemplate>
                                    <%#Eval("OrderId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- Billno --%>
                        <asp:TemplateField HeaderText="Billno">
                            <ItemTemplate>
                                    <%#Eval("Billno") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- Name --%>
                        <asp:TemplateField HeaderText="ProductTitle">
                            <ItemTemplate>
                                     <%#Eval("ProductTitle") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- TotalAmount --%>
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                  <%#Eval("Price") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <%-- PaymentStatus --%>
                        <asp:TemplateField HeaderText="Payment Type">
                            <ItemTemplate>
                                  <%#Eval("PaymentStatus") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <%-- PaymentType --%>
                        <asp:TemplateField HeaderText="Payment Type">
                            <ItemTemplate>
                                  <%#Eval("PaymentType") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                            <%-- Entry date --%>
                        <asp:TemplateField HeaderText="EntryDate">
                            <ItemTemplate>
                                  <%#Eval("EntryDate") %>
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

