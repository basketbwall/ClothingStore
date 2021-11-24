<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PastOrders.aspx.cs" Inherits="ClothingStore.PastOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/Navigation-with-Button.css" />
    <link rel="stylesheet" href="assets/css/styles.css/" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <title></title>
    <style>
        nav {
            padding-top: 10px;
        }

        #imageDiv {
            text-align: center;
        }

        #clothingImage {
            width: 100%;
            padding: 10%;
        }

        #clothesInfoDiv {
            display: inline-block;
            padding: 2.5%;
        }

        #reviews {
            padding-left: 5%;
        }

        #btnCheckOut {
            position: relative;
            top: 20px;
        }

        #navbar {
            background-color: lightgrey;
        }

        #lblCompany {
            margin-left: 2rem;
        }

        td {
            width: 10%;
        }
        .auto-style1 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav id="navbar" class="text-start">
            <asp:Label ID="lblCompany" runat="server" Text="CompanyName" class="h6"></asp:Label>
            <ul class="col-md-5" style="display: inline-block; list-style-type: none;">
                <li style="display: inline-block;"><a href="Catalog.aspx" class="btn btn-outline-dark">Catalog</a></li>

                <li style="display: inline-block;"><a href="Clearance.aspx" class="btn btn-outline-dark">Clearance</a></li>

                <li style="display: inline-block;">
                    <a runat="server" id="navPurchaseHistory" visible="false" href="PastOrders.aspx" class="btn btn-outline-dark">Purchase History</a></li>

                <li style="display: inline-block;"><a runat="server" id="navManageRefunds" visible="false" href="ManageRefunds.aspx" class="btn btn-outline-dark">Manage Refunds</a></li>

            </ul>
            <ul class="text-end col-md-5" style="display: inline-block; list-style-type: none;">
                <li style="display: inline-block;">
                    <a runat="server" id="navCheckoutPage" visible="false" href="CheckoutPage.aspx">
                        <img src="/Images/black-24dp/2x/outline_shopping_bag_black_24dp.png" /></a>
                </li>

                <asp:Label ID="lblUser" runat="server" Text="" Style="margin-right: 1rem;"></asp:Label>

                <li style="display: inline-block;"><a runat="server" id="navSignIn" visible="false" href="Login.aspx" class="btn btn-outline-success">Sign In</a></li>
                <li style="display: inline-block;"><a runat="server" id="navSignOut" visible="false" href="Login.aspx" class="btn btn-outline-danger">Sign Out</a></li>
            </ul>
        </nav>


                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="text-center" style="width: 70%; margin: auto;">
            <Columns>
                <asp:BoundField DataField="ClothingName" HeaderText="Name" />
                <asp:BoundField DataField="ClothingColor" HeaderText="Color" />
                <asp:BoundField DataField="ClothingSize" HeaderText="Size" />
                <asp:BoundField DataField="ClothingPrice" HeaderText="Price" />
                <asp:BoundField DataField="ClothingQuantity" HeaderText="Quantity Purchased" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
        <table style="width: 70%; margin: auto;">

            <tr>

                <th>Order ID</th>

                <th>Order Total</th>

                <th>Order Date</th>

                <th>Refund Request Status</th>

                <th>View Order</th>

            </tr>



            <asp:Repeater ID="rptOrders" runat="server" OnItemCommand="rptOrders_ItemCommand">

                <ItemTemplate>

                    <tr>

                        <td>

                            <asp:Label ID="lblOrderID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderID") %>'></asp:Label>

                        </td>

                        <td>

                            <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderTotal", "{0:c}") %>'></asp:Label>

                        </td>

                        <td>

                            <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderDate") %>'></asp:Label>

                        </td>
                        <td>

                            <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "refundRequested") %>'></asp:Label>

                        </td>
                        <td>
                            <asp:Button ID="Button3" runat="server" Text="Initiate Refund Request" class="btn btn-dark"/>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>



        </table>



    </form>
</body>
</html>
