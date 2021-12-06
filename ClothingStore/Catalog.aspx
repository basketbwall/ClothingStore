<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="ClothingStore.Catalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/Navigation-with-Button.css" />
    <link rel="stylesheet" href="assets/css/styles.css/" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <title></title>
    <link rel="stylesheet" href="NavBarStyle.css"/>

</head>
<body runat="server" align="center">
    <form id="form1" runat="server" defaultbutton="btnSearch">


                    <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
        <div class="text-center form-inline" style="margin-top: 3%;">

            <asp:ImageButton ID="addClothes" Width="1100" Height="200" ImageUrl="Images/addClothing.jpeg" runat="server" OnClick="addClothes_Click" Visible="false"/>
            <br />
            <br />
            <div class="col-5" style="margin: auto;">
                <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnSearch" runat="server" class="btn btn-warning" OnClick="btnSearch_Click" Text="Search" />
            </div>
&nbsp;
            
            <br />
            <br />
            <asp:Repeater ID="rptCLothing" runat="server" OnItemCommand="rptCLothing_ItemCommand">
                    <ItemTemplate>
                        <div class="card text-start  h-100 col-md-3"  style="margin:1%; display:inline-block; width:300px" >

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
                                <asp:Button ID="Button3" runat="server" Text="View Clothing" class="btn btn-dark" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
    </form>


</body>
</html>
