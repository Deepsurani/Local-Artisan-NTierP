<%@ Page Title="" Language="C#" MasterPageFile="~/Artisian/ArtisianMasterPage.master" AutoEventWireup="true" CodeFile="ArtisianProductAdd.aspx.cs" Inherits="Artisian_ArtisianProductAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">

        <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header bg-primary text-white">
                        <h4 class="mb-0">Product</h4>
                          <a href="ArtisianManageProductAddPage.aspx" class="btn btn-primary">
                          <i class="fa fa-plus"></i> Add New
                </a>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mb-2" Visible="false"></asp:Label>



                        <!--1. Category Id -->
                        <div class="mb-3">
                            <label for="txtcatid" class="form-label">Category Id</label>
                            <asp:DropDownList  class="form-control" ID="DropCategoryId"  AutoPostBack="true" OnSelectedIndexChanged="DropCategoryId_SelectedIndexChanged" name="CategoryId" runat="server">

                            </asp:DropDownList>
                        </div>

                           <!--2. SubCategory Id -->
                        <div class="mb-3">
                            <label for="txtsubcatid" class="form-label">SubCategory Id</label>
                            <asp:DropDownList  class="form-control" ID="DropSubCategoryId"  name="SubCategoryId" runat="server">

                            </asp:DropDownList>
                        </div>

                          <%--3. ProducTitle  --%>
                           <div class="mb-3">
                            <label for="txtprotitle" class="form-label">Product Title</label>
                            <asp:TextBox ID="TxtProductTitle" runat="server" CssClass="form-control" />
                        </div>

                          <%-- 4.Price --%>
                         <div class="mb-3">
                            <label for="txtprice" class="form-label">Price</label>
                            <asp:TextBox ID="TxtPrice" runat="server" CssClass="form-control" />
                        </div>


                        <%--5. Description --%>
                           <div class="mb-3">
                            <label for="txtdescription" class="form-label">Description</label>
                            <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control" />
                        </div>



                        <%-- 6.Photo 1 img --%>

                        <div class="mb-3">
                            <label for="photo1" class="form-label">Photo 1</label>
                            <asp:FileUpload class="form-control" name="PhotoUpload1" type="file" ID="FuPhoto1" runat="server" />

                        </div>

                        <%-- EditImage  --%>

                        <div class="mb-3">
                            <label for="EditImage1" runat="server" id="Editimglable1" class="form-label">Edit Image1</label>
                            <asp:Image Height="100px" Width="100px" ID="ForEditImg1" runat="server" />

                        </div>

                        <%-- 7.Photo 2 img --%>

                        <div class="mb-3">
                            <label for="photo2" class="form-label">Photo 2</label>
                            <asp:FileUpload class="form-control" name="PhotoUpload2" type="file" ID="FuPhoto2" runat="server" />

                        </div>

                        <div class="mb-3">
                             <label for="EditImage2" runat="server" id="Editimglable2" class="form-label">Edit Image2</label>
                            <asp:Image Height="100px" Width="100px" ID="ForEditImg2" runat="server" />
                        </div>

                           <%-- 8.Photo 3 img --%>

                        <div class="mb-3">
                            <label for="photo3" class="form-label">Photo 3</label>
                            <asp:FileUpload class="form-control" name="PhotoUpload3" type="file" ID="FuPhoto3" runat="server" />

                        </div>

                        <div class="mb-3">
                             <label for="EditImage3" runat="server" id="Editimglable3" class="form-label">Edit Image3</label>
                            <asp:Image Height="100px" Width="100px" ID="ForEditImg3" runat="server" /> 
                        </div>

                            <%-- 9.Photo 4 img --%>

                        <div class="mb-3">
                            <label for="photo4" class="form-label">Photo 4</label>
                            <asp:FileUpload class="form-control" name="PhotoUpload4" type="file" ID="FuPhoto4" runat="server" />

                        </div>

                        <div class="mb-3">
                             <label for="EditImage4" runat="server" id="Editimglable4" class="form-label">Edit Image4</label>
                            <asp:Image Height="100px" Width="100px" ID="ForEditImg4" runat="server" /> 
                        </div>

                            <%-- 10.Photo 5 img --%>

                        <div class="mb-3">
                            <label for="photo5" class="form-label">Photo 5</label>
                            <asp:FileUpload class="form-control" name="PhotoUpload5" type="file" ID="FuPhoto5" runat="server" />
                        </div>

                        <div class="mb-3">
                            <label for="EditImage5" runat="server" id="Editimglable5" class="form-label">Edit Image5</label>
                            <asp:Image Height="100px" Width="100px" ID="ForEditImg5" runat="server" /> 
                        </div>

             
                            <!-- Submit -->
                            <div class="d-grid">
                                <asp:Button ID="BtnProductSave" runat="server" Text="Save Product" OnClick="BtnProductSave_Click" CssClass="btn btn-primary"/>
                            </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

