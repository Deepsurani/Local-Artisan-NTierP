<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientMasterPage.master" AutoEventWireup="true" CodeFile="ClientMyOrderShow.aspx.cs" Inherits="Client_ClientMyOrderShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


       <style>
    body {
      font-family: 'Segoe UI', sans-serif;
      background-color: #f4f4f4;
      margin: 0;
      padding: 20px;
    }

    .order-list {
      max-width: 900px;
      margin: auto;
      background: #fff;
      padding: 20px;
      border-radius: 12px;
      box-shadow: 0 2px 10px rgba(0,0,0,0.1);
    }

    h2 {
      text-align: center;
      margin-bottom: 20px;
      color: #333;
    }

    .order-table {
      width: 100%;
      border-collapse: collapse;
    }

    .order-table th,
    .order-table td {
      padding: 12px 15px;
      text-align: left;
      border-bottom: 1px solid #eee;
    }

    .order-table th {
      background-color: #f8f8f8;
      color: #333;
    }

    .status {
      padding: 5px 12px;
      border-radius: 20px;
      font-size: 0.9em;
      font-weight: 500;
    }

    .delivered {
      background-color: #d4edda;
      color: #155724;
    }

    .pending {
      background-color: #fff3cd;
      color: #856404;
    }

    .cancelled {
      background-color: #f8d7da;
      color: #721c24;
    }

    @media (max-width: 600px) {
      .order-table th, .order-table td {
        font-size: 14px;
        padding: 10px;
      }
    }
  </style>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" Runat="Server">


     <div class="order-list">
    <h2>My Orders</h2>
    <table class="order-table">
      <thead>
        <tr>
          <th>Order ID</th>
          <th>Bill No</th>
          <th>Product</th>
          <th>Total Amount</th>
          <th>Payment Status</th>
          <th>Payment Type</th>
            <th>billing</th>
          <%--<th>Order Date</th>--%>
        </tr>
      </thead>
      <tbody>
            <asp:Repeater ID="RepeaterMyOrder" runat="server">
                <ItemTemplate>
        <tr>
          

          <td><%#Eval("OrderId")%></td>
          <td><%#Eval("Billno")%></td>
            <%-- Name = Product Name --%>
          <td><%#Eval("ProductTitle")%></td> 
          <td><%#Eval("TotalAmount")%></td>
          <td><span class="status delivered"><%#Eval("PaymentStatus")%></span></td>
          <td><%#Eval("PaymentType")%></td>
          <td><a  href='ClientBillingPage.aspx?Billno=<%#Eval("Billno")%>' class="status delivered">&nbsp;Bill</a></td>
         

            
        

        </tr>   
                        </ItemTemplate>
            </asp:Repeater>  
      </tbody>
    </table>
  </div>


</asp:Content>





<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" Runat="Server">
</asp:Content>

