<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminManageAreaPage.aspx.cs" Inherits="Admin_AdminManageAreaPage" %>

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
                <h5 class="mb-0 text-primary"><i class="fa fa-list me-2"></i>Manage Area</h5>
                <a href="AdminCreateAreaPage.aspx" class="btn btn-primary">
                    <i class="fa fa-plus"></i> Add New
                </a>
            </div>

            <div class="table-responsive">
                <asp:GridView ID="GridViewArea" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewArea_RowCommand" CssClass="table table-bordered table-hover align-middle text-start">
                    <Columns>

                 
                        <%-- Area Id --%>
                        <asp:TemplateField HeaderText="Area Id">
                            <ItemTemplate>
                                    <%#Eval("AreaId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- City --%>
                        <asp:TemplateField HeaderText="City Id">
                            <ItemTemplate>
                                    <%#Eval("CityId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <%-- Area --%>
                        <asp:TemplateField HeaderText="Area">
                            <ItemTemplate>
                                    <%#Eval("Area") %>
                            </ItemTemplate>
                        </asp:TemplateField>


                     

                        <%-- Status --%>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                  <%#Eval("Status") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--Edit--%>   <%--  ?Edit= ...querystring--%>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <a href='AdminCreateAreaPage.aspx?EditArea=<%#Eval("AreaId")%>' class="btn btn-info"><i class="fa fa-edit"></i>&nbsp;Edit</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--Delete--%>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>                            
                                 <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-danger" OnClientClick="return confirm('are you sure dlt data?')" CommandName="del" CommandArgument='<%#Eval("AreaId") %>'><i class="fa fa-trash"></i>&nbsp;Delete</asp:LinkButton>

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

