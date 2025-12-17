<%@ Page Title="" Language="C#" MasterPageFile="~/Artisian/ArtisianMasterPage.master" AutoEventWireup="true" CodeFile="ArtisianOrderShow.aspx.cs" Inherits="Artisian_ArtisianOrderShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                <asp:GridView  ID="GridOrder" AutoGenerateColumns="false" runat="server"  CssClass="table table-bordered table-hover align-middle text-start">
                    <Columns>

                 
                    
                         <%-- Order Id --%>
                         <asp:TemplateField HeaderText="OrderId">
                             <ItemTemplate>
                                 <%#Eval("OrderId") %>
                             </ItemTemplate>
                         </asp:TemplateField>

                             <%-- Bill no--%>
                         <asp:TemplateField HeaderText="Billno">
                             <ItemTemplate>
                                 <%#Eval("Billno") %>
                             </ItemTemplate>
                         </asp:TemplateField>

                           <%-- Product--%>
                         <asp:TemplateField HeaderText="ProductTitle">
                             <ItemTemplate>
                                 <%#Eval("ProductTitle") %>
                             </ItemTemplate>
                         </asp:TemplateField>

                           <%-- Total Amount--%>
                         <asp:TemplateField HeaderText="Price">
                             <ItemTemplate>
                                 <%#Eval("Price") %>
                             </ItemTemplate>
                         </asp:TemplateField>

                           <%-- Payment Status--%>
                         <asp:TemplateField HeaderText="Qty">
                             <ItemTemplate>
                                 <%#Eval("Qty") %>
                             </ItemTemplate>
                         </asp:TemplateField>

                           <%-- Payment Type--%>
                         <asp:TemplateField HeaderText="Total">
                             <ItemTemplate>
                                 <%#Eval("Total") %>
                             </ItemTemplate>
                         </asp:TemplateField>

                           <%-- Order Date--%>
                        <%-- <asp:TemplateField HeaderText="EntryDate">
                             <ItemTemplate>
                                 <%#Eval("EntryDate") %>
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

