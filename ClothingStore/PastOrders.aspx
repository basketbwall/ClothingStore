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
<body>
    <form id="form1" runat="server">
                        <nav id="navbar" class="text-start">
            <asp:Label ID="lblCompany" runat="server" Text="CompanyName" class="h6"></asp:Label>
            <ul class="col-md-5" style="display: inline-block">
                <asp:Button ID="btnCatalog" runat="server" Text="Catalog" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnCatalog_Click" />
                <asp:Button ID="btnClearance" runat="server" Text="Clearance" class="btn btn-outline-dark" Style="margin-right: 1rem;" />
                <asp:Button ID="btnPurchaseHistory" runat="server" Text="Purchase History" class="btn btn-outline-dark" Style="margin-right: 1rem;"/>
                                <asp:Button ID="btnManageRefunds" runat="server" Text="Manage Refunds" class="btn btn-outline-dark" Style="margin-right: 1rem;" />
            </ul>
            <ul class="text-end col-md-5" style="display: inline-block">
                <asp:ImageButton ID="btnCheckOut" runat="server" ImageUrl="~/Images/black-24dp/2x/outline_shopping_bag_black_24dp.png" data-toggle="tooltip" data-placement="top"
                    title="Check Out" Style="margin-right: 1rem;" />
                <asp:Label ID="lblUser" runat="server" Text="Hello Customer" Style="margin-right: 1rem;"></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="Sign In" class="btn btn-outline-success" Style="margin-right: 1rem;"  />
                <asp:Button ID="Button2" runat="server" Text="Sign Out" class="btn btn-outline-danger" />

            </ul>
        </nav>
        <div>
            <asp:ListView ID="lvOrders" runat="server" OnSelectedIndexChanged="lvOrders_SelectedIndexChanged">
                <ItemTemplate>
                    <div class="list">
                        <table style="border:solid black 0.5px; width: 70%; margin: auto;">
                            <tr><td>User: <%#Eval("userID")%></td></tr>
                            <tr><td>reviewContent: <%#Eval("reviewContent")%></td></tr>
                            <br />
                            <tr>
                                <td>Comfort: <%#Eval("comfortRating")%></td>
                            </tr>
                            <tr>
                                <td>Quality: <%#Eval("qualityRating")%></td>
                            </tr>
                            <tr>
                                <td>Cost: <%#Eval("costRating")%></td>
                            </tr>
                            <br />
                        </table>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
