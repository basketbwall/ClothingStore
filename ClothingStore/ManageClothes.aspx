<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageClothes.aspx.cs" Inherits="ClothingStore.ManageClothes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" runat="server">
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
&nbsp;<asp:TextBox ID="tbName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="53px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Height="50px" Width="250px" Rows="4"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblClearance" runat="server" Text="On Clearance: "></asp:Label>
            <asp:CheckBox ID="cbClearance" runat="server" OnCheckedChanged="cbClearance_CheckedChanged" Text=" " />
            <asp:Label ID="lblOff" runat="server" Text="Percentage Off: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbPercentageOff" runat="server" Visible="False" Width="29px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblSmall" runat="server" Text="Small"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMed" runat="server" Text="Medium"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblLarge" runat="server" Text="Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblStock" runat="server" Text="Stock: "></asp:Label>
&nbsp;
            <asp:TextBox ID="tbSmall" runat="server" Width="40px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbMed" runat="server" Width="40px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbLarge" runat="server" Width="40px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" Height="23px" Text="Back" Width="67px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Height="23px" Text="Save" Width="67px" />
        </div>
    </form>
</body>
</html>
