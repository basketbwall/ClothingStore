<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageClothes.aspx.cs" Inherits="ClothingStore.ManageClothes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />

    <title></title>

    <style>
        #ClothesManagement {
            margin: auto;
            margin-top: 10%;
            border: solid black 0.5px;
            padding: 5%;
        }
    </style>
</head>
<body>
        <div id="ClothesManagement" class="text-center col-md-5" style="border-radius: 2.5px">
            <h1>Clothes Management</h1>
            <div>
    <form id="form1" runat="server">
        <div align="center" runat="server">
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
&nbsp;<asp:TextBox ID="tbName" runat="server" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
            &nbsp;&nbsp;<br />
            <br />
&nbsp;<asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
&nbsp;
            <asp:TextBox ID="tbPrice" runat="server"  class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblColor" runat="server" Text="Color: "></asp:Label>
&nbsp;<asp:TextBox ID="tbColor" runat="server"  class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
&nbsp;<br />
            <br />
            <asp:Label ID="lblBrand" runat="server" Text="Brand: "></asp:Label>
&nbsp;<asp:TextBox ID="tbBrand" runat="server"  class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblURL" runat="server" Text="Image URL: "></asp:Label>
&nbsp;<asp:TextBox ID="tbURL" runat="server"  class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
            <br />
            <asp:TextBox ID="tbDescription" runat="server" Height="70px" Width="350px" class="form-control" ></asp:TextBox>
            <br />
            <asp:Label ID="lblClearance" runat="server" Text="On Clearance: "></asp:Label>
            <asp:CheckBox ID="cbClearance" runat="server" OnCheckedChanged="cbClearance_CheckedChanged" Text=" " AutoPostBack="True" />
            <asp:Label ID="lblOff" runat="server" Text="Percentage Off: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbPercentageOff" runat="server" Visible="False" class="col-sm-2 col-form-label" Height="30px" Width="100px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblSmall" runat="server" Text="Small"></asp:Label>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMed" runat="server" Text="Medium"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblLarge" runat="server" Text="Large"></asp:Label>
            <br />
            <asp:Label ID="lblStock" runat="server" Text="Stock: "></asp:Label>
&nbsp;
            <asp:TextBox ID="tbSmall" runat="server" class="col-sm-2 col-form-label" Height="30px" Width="100px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbMed" runat="server" class="col-sm-2 col-form-label" Height="30px" Width="100px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbLarge" runat="server" class="col-sm-2 col-form-label" Height="30px" Width="100px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" class="btn btn-dark" Height="40px" Width="75px"/>
&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" Text="Delete" class="btn btn-dark" Height="40px" Width="75px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-dark" Height="40px" Width="75px"/>
        </div>
    </form>
</body>
</html>
