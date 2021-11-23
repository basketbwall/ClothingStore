﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClothingPage.aspx.cs" Inherits="ClothingStore.Clothing" %>

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
            <ul class="col-md-5" style="display: inline-block">
                <asp:Button ID="btnCatalog" runat="server" Text="Catalog" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnCatalog_Click1" />
                <asp:Button ID="btnClearance" runat="server" Text="Clearance" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnClearance_Click" />
                <asp:Button ID="btnPurchaseHistory" runat="server" Visible="false" Text="Purchase History" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnPurchaseHistory_Click" />
                <asp:Button ID="btnManageRefunds" runat="server" Visible="false" Text="Manage Refunds" class="btn btn-outline-dark" Style="margin-right: 1rem;" OnClick="btnManageRefunds_Click" />
            </ul>
            <ul class="text-end col-md-5" style="display: inline-block">
                <asp:ImageButton ID="btnCheckOut" runat="server" ImageUrl="~/Images/black-24dp/2x/outline_shopping_bag_black_24dp.png" data-toggle="tooltip" data-placement="top"
                    title="Check Out" Style="margin-right: 1rem;" Visible="false" OnClick="btnCheckOut_Click" />
                <asp:Label ID="lblUser" runat="server" Text="" Style="margin-right: 1rem;"></asp:Label>
                <asp:Button ID="btnSignIn" runat="server" Visible="false" Text="Sign In" class="btn btn-outline-success" Style="margin-right: 1rem;" OnClick="Button1_Click" />
                <asp:Button ID="btnSignOut" runat="server" Visible="false" Text="Sign Out" class="btn btn-outline-danger" OnClick="Button2_Click" />

            </ul>
        </nav>
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
            <asp:Label ID="lblBrand" runat="server" Text="Brand: "></asp:Label>
            <div runat="server" id="shoppingOptions" visible="false">
                <asp:Label ID="lblSize" runat="server" Text="Choose Size: "></asp:Label>
                <uc1:SizePicker runat="server" ID="SizePicker" />
                <asp:Label ID="lblQuantity" runat="server" Text="Choose Quantity To Add: "></asp:Label>
                <uc1:QuantityPicker runat="server" ID="QuantityPicker" />
                <asp:Button ID="btnAdd" runat="server" Text="Add To Bag" class="btn btn-dark" />
            </div>
        </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Ratings & Reviews" class="h4 col-sm-3"></asp:Label>
        <br />
        <br />
        <div runat="server" id="reviews" class="row">
            <asp:Button ID="btnLoadReview" runat="server" Text="See Reviews" class="btn btn-dark col-sm-3" Style="margin-right: 1rem;" OnClick="btnLoadReview_Click" />
            <asp:Button ID="btnAddReview" runat="server" Text="Write Review" Visible="false" class="btn btn-dark col-sm-3" Style="margin-right: 1rem;" OnClick="btnAddReview_Click" />
            <asp:Button ID="btnMyReview" runat="server" Text="Edit Review" Visible="false" class="btn btn-dark col-sm-3" OnClick="btnEditReview_Click" />
            <asp:Button ID="btnManage" runat="server" Text="Manage" Visible="false" class="btn btn-dark col-sm-3" OnClick="btnManage_Click" />
        </div>
        <br />
        <div runat="server" id="allreviews">
            <!-- Display reviews here!-->
            <%--            <asp:GridView ID="gvReviews" runat="server" class="text-center" Style="margin: auto; width: 75%"></asp:GridView>--%>
            <asp:ListView ID="lvReviews" runat="server" Style="text-align: left">
                <EmptyDataTemplate>
                    There are no reviews for this clothing item.
                </EmptyDataTemplate>
                <ItemTemplate>
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
                </ItemTemplate>
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
    </form>

    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
