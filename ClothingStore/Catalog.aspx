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
<body>
    <form id="form1" runat="server">
                <nav id="navbar" class="text-start">
            <asp:Label ID="lblCompany" runat="server" Text="CompanyName" class="h6"></asp:Label>
            <ul class="col-md-5" style="display: inline-block">
                <asp:Button ID="btnCatalog" runat="server" Text="Catalog" class="btn btn-outline-dark" Style="margin-right: 1rem;" />
                <asp:Button ID="btnClearance" runat="server" Text="Clearance" class="btn btn-outline-dark" Style="margin-right: 1rem;" />
                <asp:Button ID="btnPurchaseHistory" runat="server" Visible="false" Text="Purchase History" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnPurchaseHistory_Click" />
                <asp:Button ID="btnManageRefunds" runat="server" Visible="false" Text="Manage Refunds" class="btn btn-outline-dark" Style="margin-right: 1rem;" />
            </ul>
            <ul class="text-end col-md-5" style="display: inline-block">
                <asp:ImageButton ID="btnCheckOut" runat="server" ImageUrl="~/Images/black-24dp/2x/outline_shopping_bag_black_24dp.png" data-toggle="tooltip" data-placement="top"
                    title="Check Out" Style="margin-right: 1rem;" Visible="false" />
                <asp:Label ID="lblUser" runat="server" Text="" Style="margin-right: 1rem;"></asp:Label>
                <asp:Button ID="btnSignIn" runat="server" Visible="false" Text="Sign In" class="btn btn-outline-success" Style="margin-right: 1rem;" OnClick="Button1_Click" />
                <asp:Button ID="btnSignOut" runat="server" Visible="false" Text="Sign Out" class="btn btn-outline-danger" OnClick="Button2_Click" />

            </ul>
        </nav>
        <div>
            Dummy page
            <asp:Button ID="btnClothing" runat="server" Text="Clothing" OnClick="btnClothing_Click" />
        </div>
    </form>
</body>
</html>
