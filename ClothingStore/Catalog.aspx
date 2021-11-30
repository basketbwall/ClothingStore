<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="ClothingStore.Catalog" %>

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
    </style>
</head>
<body runat="server" align="center">
    <form id="form1" runat="server">
<%--        <nav id="navbar" class="text-start">
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
                    <a runat="server" id="navCheckoutPage" type="button" class="btn position-relative"  href="CheckoutPage.aspx">
                          <img src="/Images/black-24dp/2x/outline_shopping_bag_black_24dp.png" />
                          <span runat="server" id="CartSpan" class="position-absolute start-50 badge rounded-pill bg-danger">
                              <asp:Label ID="lblCartTotalQuantity" runat="server" Text="3"></asp:Label>
                          </span>
                    </a>
                </li>

                <asp:Label ID="lblUser" runat="server" Text="" Style="margin-right: 1rem;"></asp:Label>

                <li style="display: inline-block;"><a runat="server" id="navSignIn" visible="false" href="Login.aspx" class="btn btn-outline-success">Sign In</a></li>
                <li style="display: inline-block;"><a runat="server" id="navSignOut" visible="false" href="Login.aspx" class="btn btn-outline-danger">Sign Out</a></li>
            </ul>
        </nav>--%>
                    <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
        <div class="text-center form-inline" style="margin-top: 10%;">
            <br />
            <br />
            <asp:Repeater ID="rptCLothing" runat="server" OnItemCommand="rptCLothing_ItemCommand">
                    <ItemTemplate>
                        <div class="card text-start col-md-3"  style="margin:1%; display:inline-block; width:300px" >

                            <asp:Image ID="Image1" runat="server" Width="300" Height="300" ImageUrl='<%# Eval("clothingImage") %>'/>

                            <div class="card-body">
                                <h5 class="card-title"></h5>
                                <p class="card-text">
                                    
                                    <asp:Label ID="lblclothingID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "clothingID") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "clothingName") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "clothingDescription", "{0:c}") %>'></asp:Label>
                                    <br />
                                    $<asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "clothingPrice") %>'></asp:Label>
                                    <br />
                                </p>
                                <asp:Button ID="Button3" runat="server" Text="View Order" class="btn btn-dark" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
    </form>


</body>
</html>
