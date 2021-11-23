<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRefunds.aspx.cs" Inherits="ClothingStore.ManageRefunds" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav id="navbar" class="text-start">
            <asp:Label ID="lblCompany" runat="server" Text="CompanyName" class="h6"></asp:Label>
            <ul class="col-md-5" style="display: inline-block">
                <asp:Button ID="btnCatalog" runat="server" Text="Catalog" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnCatalog_Click" />
                <asp:Button ID="btnClearance" runat="server" Text="Clearance" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnClearance_Click" />
                <asp:Button ID="btnPurchaseHistory" runat="server" Text="Purchase History" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnPurchaseHistory_Click1" />
                <asp:Button ID="btnManageRefunds" runat="server" Text="Manage Refunds" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnManageRefunds_Click" />
            </ul>
            <ul class="text-end col-md-5" style="display: inline-block">
                <asp:ImageButton ID="btnCheckOut" runat="server" ImageUrl="~/Images/black-24dp/2x/outline_shopping_bag_black_24dp.png" data-toggle="tooltip" data-placement="top"
                    title="Check Out" Style="margin-right: 1rem;" OnClick="btnCheckOut_Click" />
                <asp:Label ID="lblUser" runat="server" Text="Hello Customer" Style="margin-right: 1rem;"></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="Sign In" class="btn btn-outline-success" Style="margin-right: 1rem;" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Sign Out" class="btn btn-outline-danger" OnClick="Button2_Click" />

            </ul>
        </nav>
        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
        <table style="width: 70%; margin: auto;">

            <tr>

                <th>Order ID</th>

                <th>Order Total</th>

                <th>Order Date</th>

                <th>Confirm Refund</th>

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
                            <asp:Button ID="Button3" runat="server" Text="Confirm Refund Request" class="btn btn-dark"/>
                        </td>

                    </tr>

                </ItemTemplate>

            </asp:Repeater>



        </table>
    </form>
</body>
</html>
