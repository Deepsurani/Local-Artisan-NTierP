<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientBillingPage.aspx.cs" Inherits="Client_ClientBillingPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice Bill</title>

    <!-- Bootstrap 5 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />

     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body {
            background: #f4f6f8;
        }

        .invoice-box {
            background: #fff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 4px 20px rgba(0,0,0,0.15);
        }

        .invoice-header {
            border-bottom: 2px solid #eee;
            padding-bottom: 15px;
            margin-bottom: 20px;
        }

        .invoice-header img {
            max-height: 60px;
        }

        .invoice-title {
            font-size: 32px;
            font-weight: 700;
            color: #000;
        }

        .invoice-section h5 {
            color: #000;
            font-weight: 600;
            margin-bottom: 15px;
        }


        .table th, .table td {
            vertical-align: middle !important;
        }

        .table thead th {
            background: #000;
            color: #fff;
            text-align: center;
        }

        .table tfoot th {
            text-align: right;
        }

        .table tfoot td {
            text-align: right;
        }

        .total-row {
            background: #d1e7dd !important;
            font-weight: 600;
        }

        .icon {
            color: #000;
            margin-right: 5px;
        }

        @media print {
            .no-print { display: none; }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container my-5">
            <div class="invoice-box">

                <!-- Header -->
                <div class="row invoice-header align-items-center">
                    <div class="col-md-6">
                       <img src="https://cdn-icons-png.flaticon.com/512/891/891462.png" alt="Logo" />
                        <span class="invoice-title ms-3">INVOICE</span>
                    </div>
                    <div class="col-md-6 text-end">
                        <div><i class="fas fa-receipt icon"></i><strong>Bill ID:</strong > &nbsp;<label id="billidpass" runat="server"></label></div> 
                        <div><i class="fas fa-shopping-bag icon"></i><strong>Order ID:</strong>&nbsp;<label id="orderidpass" runat="server"></label></div>
                        <div><i class="fas fa-calendar-alt icon"></i><strong>Bill Date:</strong> &nbsp;<label id="billdate" runat="server"></label></div>
                        <div><i class="fas fa-credit-card icon"></i><strong>Payment Mode:</strong>&nbsp;<label id="paymentmode" runat="server"></label></div>
                    </div>
                </div>

                <!-- Company & Customer -->
                <div class="row mt-4">
                    <div class="col-md-6 invoice-section">
                        <h5><i class="fas fa-building icon"></i>Company Details</h5>
                        <p>
                            <strong>ECommerce World Pvt Ltd</strong><br />
                            401 Silicon Tower, SG Highway, Ahmedabad - 380015<br />
                            GST No: 24ABCDE1234A1ZK<br />
                            <i class="fas fa-phone icon"></i> +91 79905 12345<br />
                            <i class="fas fa-envelope icon"></i> support@ecommerceworld.com
                        </p>
                    </div>
                    <div class="col-md-6 invoice-section">
                        <h5><i class="fas fa-user icon"></i>Customer (Billing)</h5>
                        <p>
                            <strong><label id="custname" runat="server"></label></strong><br />
                           <label id="custmobile" runat="server"></label><br />
                            <label id="custadd" runat="server"></label><br />
                           
                        </p>

                        <h5 class="mt-3"><i class="fas fa-truck icon"></i>Shipping Address</h5>
                        <p>
                            <strong><label id="shipname" runat="server"></label></strong><br />
                            <label id="shipmobile" runat="server"></label><br />
                          <label id="shipadd" runat="server"></label><br />
                            
                        </p>
                    </div>
                </div>

                <!-- Product Table -->
                <div class="table-responsive mt-4">
                    <table class="table table-bordered align-middle">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Product</th>
                                <th>Qty</th>
                                <th>Rate</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="text-center">1</td>
                                <td><label id="mergeProduct" runat="server"></label></td>
                                <td class="text-center"><label id="productqty"></label></td>
                                <td><label id="productrate" runat="server"></label></td>
                                <td><label id="prodtotal"></label></td>
                            </tr>
                           
                        </tbody>
                        <tfoot>
                          <%--  <tr>
                                <th colspan="4">Sub Total:</th>
                                <td>₹5,197</td>
                            </tr>
                            <tr>
                                <th colspan="4">Shipping Charges:</th>
                                <td>₹80</td>
                            </tr>
                            <tr>
                                <th colspan="4">GST (18%):</th>
                                <td>₹935</td>
                            </tr>--%>
                            <tr class="total-row">
                                <th colspan="4">Grand Total:</th>
                                <td><strong>₹6,212</strong></td>
                            </tr>
                        </tfoot>
                    </table>
                </div>

                <div class="text-center mt-4">
                    <h6>Thank you for shopping with us! <i class="fas fa-heart text-danger"></i></h6>
                </div>

                <!-- Print Button -->
                <div class="text-center mt-4">
                    <button type="button" class="btn btn-primary no-print" onclick="window.print()">
                        <i class="fas fa-print"></i> PRINT BILL
                    </button>
                </div>

                    <div class="text-center mt-4">
                    <button class="btn btn-primary no-print" type="button" id="download_Btn">
                           <i class="fas fa-print"></i>Download PDF</button>
                </div>

            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>


