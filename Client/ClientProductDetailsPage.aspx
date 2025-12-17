<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientMasterPage.master" AutoEventWireup="true" CodeFile="ClientProductDetailsPage.aspx.cs" Inherits="Client_ClientProductDetailsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <style>
        .ImgClass {
            height: 570px;
            width: 570px;
            object-fit: cover;
        }

         .trtd {
                      display:flex;
                      column-gap:4px;
                     
                      
                 }
         .word::after {
    content: " ";
    margin-right: 10px; /* jitna gap chahiye utna badhao */
}
        
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="Server">


    <!-- Page Title/Header Start -->
    <div class="page-title-section section" data-bg-image="assets/images/bg/page-title-1.webp">
        <div class="container">
            <div class="row">
                <div class="col">

                    <div class="page-title">
                        <h1 class="title">Shop</h1>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                            <li class="breadcrumb-item active">Shop</li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- Page Title/Header End -->


    <%--  ------------------------------------------------------------- Page Details --%>
    <div class="container">
        <div class="row learts-mb-n40">

         <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mb-2" Visible="false"></asp:Label>

            <!-- Product Images Start -->
            <div class="col-lg-6 col-12 learts-mb-40">
                <div class="product-images">
                    <button class="product-gallery-popup hintT-left" data-hint="Click to enlarge" data-images="[
                            {&quot;src&quot;: &quot;assets/images/product/single/1/product-zoom-1.webp&quot;, &quot;w&quot;: 700, &quot;h&quot;: 1100},
                            {&quot;src&quot;: &quot;assets/images/product/single/1/product-zoom-2.webp&quot;, &quot;w&quot;: 700, &quot;h&quot;: 1100},
                            {&quot;src&quot;: &quot;assets/images/product/single/1/product-zoom-3.webp&quot;, &quot;w&quot;: 700, &quot;h&quot;: 1100},
                            {&quot;src&quot;: &quot;assets/images/product/single/1/product-zoom-4.webp&quot;, &quot;w&quot;: 700, &quot;h&quot;: 1100}
                        ]">
                        <i class="fas fa-expand"></i>
                    </button>
                    <a href="https://www.youtube.com/watch?v=1jSsy7DtYgc" class="product-video-popup video-popup hintT-left" data-hint="Click to see video"><i class="fas fa-play"></i></a>
                    <div class="product-gallery-slider slick-initialized slick-slider slick-dotted">
                        <button class="slick-prev slick-arrow" style=""><i class="ti-angle-left"></i></button>
                        <div class="slick-list draggable">
                            <div class="slick-track" style="opacity: 1; width: 5400px; transform: translate3d(-600px, 0px, 0px);">
                                <div class="slick-slide slick-cloned" data-slick-index="-1" aria-hidden="true" style="width: 600px;" tabindex="-1">
                                    <div>
                                        <div class="product-zoom" data-image="assets/images/product/single/1/product-zoom-4.webp" style="width: 100%; display: inline-block;">
                                            <img src="assets/images/product/single/1/product-4.webp" alt="">
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide slick-current slick-active" data-slick-index="0" aria-hidden="false" style="width: 600px;" role="tabpanel" id="slick-slide10">
                                    <div>
                                        <div class="product-zoom" data-image="assets/images/product/single/1/product-zoom-1.webp" style="width: 100%; display: inline-block;">
                                            <%--<img src="assets/images/product/single/1/product-1.webp" alt="">--%>
                                            <%-- <img src="../Admin/img/download%20(17).jpg" />--%>
                                            <asp:Image CssClass="ImgClass" ID="ProductImg" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide" data-slick-index="1" aria-hidden="true" style="width: 600px;" tabindex="-1" role="tabpanel" id="slick-slide11">
                                    <div>
                                        <div class="product-zoom" data-image="assets/images/product/single/1/product-zoom-2.webp" style="width: 100%; display: inline-block;">
                                            <%-- <img src="assets/images/product/single/1/product-2.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide" data-slick-index="2" aria-hidden="true" style="width: 600px;" tabindex="-1" role="tabpanel" id="slick-slide12">
                                    <div>
                                        <div class="product-zoom" data-image="assets/images/product/single/1/product-zoom-3.webp" style="width: 100%; display: inline-block;">
                                            <%--<img src="assets/images/product/single/1/product-3.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(17).jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide" data-slick-index="3" aria-hidden="true" style="width: 600px;" tabindex="-1" role="tabpanel" id="slick-slide13">
                                    <div>
                                        <div class="product-zoom" data-image="assets/images/product/single/1/product-zoom-4.webp" style="width: 100%; display: inline-block;">
                                            <%--<img src="assets/images/product/single/1/product-4.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide slick-cloned" data-slick-index="4" aria-hidden="true" style="width: 600px;" tabindex="-1">
                                    <div>
                                        <div class="product-zoom" data-image="assets/images/product/single/1/product-zoom-1.webp" style="width: 100%; display: inline-block;">
                                            <%--<img src="assets/images/product/single/1/product-1.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide slick-cloned" data-slick-index="5" aria-hidden="true" style="width: 600px;" tabindex="-1">
                                    <div>
                                        <div class="product-zoom" data-image="assets/images/product/single/1/product-zoom-2.webp" style="width: 100%; display: inline-block;">
                                            <%--<img src="assets/images/product/single/1/product-2.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide slick-cloned" data-slick-index="6" aria-hidden="true" style="width: 600px;" tabindex="-1">
                                    <div>
                                        <div class="product-zoom" data-image="assets/images/product/single/1/product-zoom-3.webp" style="width: 100%; display: inline-block;">
                                            <%--  <img src="assets/images/product/single/1/product-3.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide slick-cloned" data-slick-index="7" aria-hidden="true" style="width: 600px;" tabindex="-1">
                                    <div>
                                        <div class="product-zoom" data-image="assets/images/product/single/1/product-zoom-4.webp" style="width: 100%; display: inline-block;">
                                            <%-- <img src="assets/images/product/single/1/product-4.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <button class="slick-next slick-arrow" style=""><i class="ti-angle-right"></i></button>
                        <ul class="slick-dots" style="" role="tablist">
                            <li class="slick-active" role="presentation">
                                <button type="button" role="tab" id="slick-slide-control10" aria-controls="slick-slide10" aria-label="1 of 4" tabindex="0" aria-selected="true">1</button></li>
                            <li role="presentation">
                                <button type="button" role="tab" id="slick-slide-control11" aria-controls="slick-slide11" aria-label="2 of 4" tabindex="-1">2</button></li>
                            <li role="presentation">
                                <button type="button" role="tab" id="slick-slide-control12" aria-controls="slick-slide12" aria-label="3 of 4" tabindex="-1">3</button></li>
                            <li role="presentation">
                                <button type="button" role="tab" id="slick-slide-control13" aria-controls="slick-slide13" aria-label="4 of 4" tabindex="-1">4</button></li>
                        </ul>
                    </div>
                    <div class="product-thumb-slider slick-initialized slick-slider">
                        <div class="slick-list draggable">
                            <div class="slick-track" style="opacity: 1; width: 600px; transform: translate3d(0px, 0px, 0px);">
                                <div class="slick-slide slick-current slick-active" data-slick-index="0" aria-hidden="false" style="width: 150px;">
                                    <div>
                                        <div class="item" style="width: 100%; display: inline-block;">
                                            <%-- <img src="assets/images/product/single/1/product-thumb-1.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide slick-active" data-slick-index="1" aria-hidden="false" style="width: 150px;">
                                    <div>
                                        <div class="item" style="width: 100%; display: inline-block;">
                                            <%--<img src="assets/images/product/single/1/product-thumb-2.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide slick-active" data-slick-index="2" aria-hidden="false" style="width: 150px;">
                                    <div>
                                        <div class="item" style="width: 100%; display: inline-block;">
                                            <%-- <img src="assets/images/product/single/1/product-thumb-3.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="slick-slide slick-active" data-slick-index="3" aria-hidden="false" style="width: 150px;">
                                    <div>
                                        <div class="item" style="width: 100%; display: inline-block;">
                                            <%-- <img src="assets/images/product/single/1/product-thumb-4.webp" alt="">--%>
                                            <img src="../Admin/img/download%20(18).jpg" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Product Images End -->

            <!-- Product Summery Start -->
            <div class="col-lg-6 col-12 learts-mb-40">
                <div class="product-summery">
                    <div class="product-nav">
                        <a href="#"><i class="fas fa-long-arrow-alt-left"></i></a>
                        <a href="#"><i class="fas fa-long-arrow-alt-right"></i></a>
                    </div>
                    <div class="product-ratings">
                        <span class="star-rating">
                            <span class="rating-active" style="width: 100%;">ratings</span>
                        </span>
                        <a href="#reviews" class="review-link">(<span class="count">3</span> customer reviews)</a>
                    </div>
                    <h3 id="ProductName" class="product-title" runat="server">Cleaning Dustpan &amp; Brush</h3>
                    <div id="ProductPrice" class="product-price" runat="server">£38.00 – £50.00</div>
                    <div id="ProductDescription" class="product-description" runat="server">
                        <p>Easy clip-on handle – Hold the brush and dustpan together for storage; the dustpan edge is serrated to allow easy scraping off the hair without entanglement. High-quality bristles – no burr damage, no scratches, thick and durable, comfortable to remove dust and smaller particles.</p>
                    </div>

                    <%-- custom--%>
                    <div class="product-variations">

                        <table>

                            <tbody>

                                <tr>
                                    <td class="label"><span>ArtWork Type</span></td>
                                    <td class="value">
                                        <div class="product">
                                            <asp:TextBox ID="TxtArtType" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>


                                <tr>
                                    <td class="label"><span>Size</span></td>
                                    <td class="value">
                                        <div class="product" >
                                            <asp:RadioButtonList ID="RblSize" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem class="trtd word" Value="Large" >Large</asp:ListItem>
                                                <asp:ListItem class="trtd word" Value="Medium">Medium</asp:ListItem>
                                                <asp:ListItem class="trtd word" Value="Small">Small</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </td>
                                </tr>


                                <tr>
                                    <td class="label"><span>Shape</span></td>
                                    <td class="value">
                                        <div class="product">
                                            <asp:RadioButtonList ID="RblShape" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem class="trtd word">Round</asp:ListItem>
                                                <asp:ListItem class="trtd word">Square</asp:ListItem>
                                                <asp:ListItem class="trtd word">Rectangle</asp:ListItem>
                                                <asp:ListItem class="trtd word">Other</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </td>
                                </tr>


                                <%--   <tr>
                                        <td class="label"><span>Color</span></td>
                                        <td class="value">
                                            <div class="product-colors">
                                                <a href="#" data-bg-color="#000000" style="background-color: rgb(0, 0, 0);"></a>
                                                <a href="#" data-bg-color="#ffffff" style="background-color: rgb(255, 255, 255);"></a>
                                            </div>
                                        </td>
                                    </tr>--%>


                                <tr>
                                    <td class="label"><span>Design Style</span></td>
                                    <td class="value">
                                        <div class="product">
                                            <asp:RadioButtonList ID="RblDesign" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem class="trtd word">Traditional</asp:ListItem>
                                                <asp:ListItem class="trtd word">Modern</asp:ListItem>
                                                <asp:ListItem class="trtd word">Minimalist</asp:ListItem>

                                            </asp:RadioButtonList>
                                        </div>
                                    </td>
                                </tr>


                                <tr>
                                    <td class="label"><span>Mirror Work</span></td>
                                    <td class="value">
                                        <div class="product">
                                            <asp:RadioButtonList ID="RblMirror" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem class="trtd word">Yes</asp:ListItem>
                                                <asp:ListItem class="trtd word">No</asp:ListItem>
                                                <asp:ListItem class="trtd word">Light</asp:ListItem>
                                                <asp:ListItem class="trtd word">Heavy</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </td>
                                </tr>



                                <tr>
                                    <td class="label"><span>colour</span></td>
                                    <td class="value">
                                        <div class="product">
                                            <asp:TextBox ID="TxtColour" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>


                                <tr>
                                    <td class="label"><span>Name on art</span></td>
                                    <td class="value">
                                        <div class="product">
                                            <asp:TextBox ID="TxtArtName" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>

                               <tr>
                                    <td class="label"><span>Quentity</span></td>
                                    <td class="value">
                                        <div class="product">
                                            <asp:TextBox ID="TxtQty" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                    <%-- custom--%>

                    <div class="product-buttons">
                        <a href="#" class="btn btn-icon btn-outline-body btn-hover-dark hintT-top" data-hint="Add to Wishlist"><i class="far fa-heart"></i></a>

                        <asp:LinkButton ID="BtnAddToCart" runat="server" CssClass="btn btn-dark btn-outline-hover-dark" OnClick="BtnAddToCart_Click"><i class="fas fa-shopping-cart"></i> Add to Cart</asp:LinkButton>
                     
                          <a href="#" class="btn btn-icon btn-outline-body btn-hover-dark hintT-top" data-hint="Compare"><i class="fas fa-random"></i></a>
                    </div>


                </div>
            </div>
            <!-- Product Summery End -->

        </div>
    </div>



    <%--  ------------------------------------------------------------- Page Details --%>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" runat="Server">
</asp:Content>

