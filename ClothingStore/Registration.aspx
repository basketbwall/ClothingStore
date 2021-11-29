<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="ClothingStore.Registration" %>

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
            <br />
            <br />
&nbsp;<asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
&nbsp;<asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
&nbsp;<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;
            <asp:Label ID="lblRole" runat="server" Text="Role: "></asp:Label>
&nbsp;<asp:DropDownList ID="ddlRole" runat="server">
                <asp:ListItem>Visitor</asp:ListItem>
                <asp:ListItem>Rewards Member</asp:ListItem>
                <asp:ListItem>Store Manager</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblQuestion1" runat="server" Text="Sercurity Question 1: "></asp:Label>
            <br />
            <br />
&nbsp;<asp:DropDownList ID="ddlQuestion1" runat="server">
                <asp:ListItem>What is the name of your favorite pet?</asp:ListItem>
                <asp:ListItem>In what city were you born?</asp:ListItem>
                <asp:ListItem>What was your favorite food as a child?</asp:ListItem>
            </asp:DropDownList>
&nbsp;
            <asp:TextBox ID="tbQuestion1" runat="server" Width="150px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblQuestion2" runat="server" Text="Sercurity Question 2: "></asp:Label>
            <br />
            <br />
&nbsp;<asp:DropDownList ID="ddlQuestion2" runat="server">
                <asp:ListItem>What is the name of your 3rd grade teacher?</asp:ListItem>
                <asp:ListItem>What highschool did you attend?</asp:ListItem>
                <asp:ListItem>What is your mother&#39;s maiden name?</asp:ListItem>
            </asp:DropDownList>
&nbsp;
            <asp:TextBox ID="tbQuestion2" runat="server" Width="150px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblQuestion3" runat="server" Text="Sercurity Question 3: "></asp:Label>
            <br />
            <br />
&nbsp;<asp:DropDownList ID="ddlQuestion3" runat="server">
                <asp:ListItem>What was the model of your first car?</asp:ListItem>
                <asp:ListItem>Where did you meet your spouse?</asp:ListItem>
                <asp:ListItem>What was the first concert you attended?</asp:ListItem>
            </asp:DropDownList>
&nbsp;
            <asp:TextBox ID="tbQuestion3" runat="server" Width="150px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnBack1" runat="server" Height="23px" OnClick="btnBack1_Click" Text="Back" Width="67px" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit1" runat="server" Height="23px" OnClick="btnSubmit1_Click" Text="Submit" Width="67px" />
            <br />
            <br />
            <asp:Label ID="lblWarning" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblEndMsg" runat="server" Text="Please check your email for a verification code. Enter below:" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="tbVerificationCode" runat="server" Visible="False" Wrap="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnBack2" runat="server" Height="23px" Text="Back" Width="67px" OnClick="btnBack2_Click" Visible="False" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Height="23px" Text="Submit" Width="67px" OnClick="btnSubmit_Click" Visible="False" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>