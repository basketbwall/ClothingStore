<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClothingPage.aspx.cs" Inherits="ClothingStore.Clothing" %>

<%@ Register Src="~/SizePicker.ascx" TagPrefix="uc1" TagName="SizePicker" %>
<%@ Register Src="~/QuantityPicker.ascx" TagPrefix="uc1" TagName="QuantityPicker" %>



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
    <form id="form1" runat="server" class="text-center">
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="imageDiv" style="display: inline-block" class="col-md-6">
            <asp:Image ID="clothingImage" runat="server" ImageUrl="~/Images/Preppy V Neck.png" />
        </div>
        <div id="clothesInfoDiv" class="col-4 text-start">
            <asp:Label ID="lblName" runat="server" Text="Name: " class="h1"></asp:Label>
            <br />
            <asp:Label ID="lblColor" runat="server" Text="Color: "></asp:Label>
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
            <br />
            <asp:Label ID="lblBrand" runat="server" Text="Brand: "></asp:Label><br />
            <asp:Button ID="btnManage" runat="server" Text="Edit Clothing Item" Visible="false" class="btn btn-dark col-sm-5" OnClick="btnManage_Click" />
            <div runat="server" id="shoppingOptions" visible="false">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblSize" runat="server" Text="Choose Size: "></asp:Label>
                        <uc1:SizePicker ID="SizePicker" runat="server" />
                        <asp:Label ID="lblQuantity" runat="server" Text="Choose Quantity To Add: "></asp:Label>
                        <uc1:QuantityPicker ID="QuantityPicker" runat="server" />
                        <br />
                        <asp:Button ID="btnAdd" runat="server" class="btn btn-dark" OnClick="btnAdd_Click" Text="Add To Bag" />
                        <br />
                        <asp:Label ID="lblPurchaseWarning" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </div>
        </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Ratings & Reviews" class="h4 col-sm-3"></asp:Label>
        <br />
        <br />

        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

            <ContentTemplate>

                <div runat="server" id="reviews" class="row">
                    <asp:Button ID="btnLoadReview" runat="server" Text="See Reviews" class="btn btn-dark col-sm-3" Style="margin-right: 1rem;" OnClick="btnLoadReview_Click" />
                    <asp:Button ID="btnAddReview" runat="server" Text="Write Review" Visible="false" class="btn btn-dark col-sm-3" Style="margin-right: 1rem;" OnClick="btnAddReview_Click" />
                    <asp:Button ID="btnMyReview" runat="server" Text="Edit Review" Visible="false" class="btn btn-dark col-sm-3" OnClick="btnEditReview_Click" />
                </div>
                <br />
                <div runat="server" id="allreviews">
                        <asp:ListView ID="lvReviews" runat="server" Style="text-align: left">
                            <emptydatatemplate>
                                There are no reviews for this clothing item.
                            </emptydatatemplate>
                            <itemtemplate>
                                <div class="list">
                                    <table style="border: solid black 0.5px; width: 70%; margin: auto;">
                                        <tr>
                                            <td>User Name: <%#Eval("userName")%></td>
                                        </tr>
                                        <tr>
                                            <td>User Review: <%#Eval("reviewContent")%></td>
                                        </tr>
                                        <br />
                                        <tr>
                                            <td>Comfort Rating: <%#Eval("comfortRating")%></td>
                                        </tr>
                                        <tr>
                                            <td>Quality Rating: <%#Eval("qualityRating")%></td>
                                        </tr>
                                        <tr>
                                            <td>Cost Rating: <%#Eval("costRating")%></td>
                                        </tr>
                                    </table>
                                </div>
                            </itemtemplate>
                        </asp:ListView>
                </div>

                <div runat="server" id="writereview" class="col-6" style="margin: auto;" visible="false">

                    <asp:Label ID="lblReviewContent" runat="server" Text="Write Your Review: " class="form-label"></asp:Label>
                    <asp:TextBox ID="txtReviewContent" runat="server" class="form-control"></asp:TextBox>

                    <asp:Label ID="lblCostRating" runat="server" Text="Rate The Cost: "></asp:Label>

                    <asp:DropDownList ID="ddlCost" runat="server" class="form-control">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem Value="5"></asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="lblQualityRating" runat="server" Text="Rate The Quality: "></asp:Label>

                    <asp:DropDownList ID="ddlQuality" runat="server" class="form-control">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem Value="5"></asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="lblComfortRating" runat="server" Text="Rate The Comfort: "></asp:Label>

                    <asp:DropDownList ID="ddlComfort" runat="server" class="form-control">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem Value="5"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnSubmitReview" runat="server" Text="Submit Review" class="btn btn-dark" OnClick="btnSubmitReview_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete Review" Visible="false" class="btn btn-danger" OnClick="btnDelete_Click" />
                    <br />
                    <asp:Label ID="lblSubmitReviewDisplay" runat="server" Text=""></asp:Label>
                </div>


            </ContentTemplate>

        </asp:UpdatePanel>


    </form>

    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
