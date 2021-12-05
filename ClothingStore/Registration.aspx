<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="ClothingStore.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    

  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css" rel="stylesheet" >
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" ></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.min.js" integrity="sha384-Atwg2Pkwv9vp0ygtn1JAojH0nYbwNJLPhwyoVbhoPwBhjQPR5VtM2+xf0Uwh9KtT" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="NavBarStyle.css"/>

    <title></title>
</head>
<body>
            <div align="center" runat="server" id="logo">
            <asp:Image ID="imgLogo"  Width="1000" Height="150" ImageUrl="Images/clothingLogo.jpg" runat="server" />
        </div>
            <div id="registration" class="text-center col-md-5" style="border-radius: 2.5px">
            <h1>Registration</h1>
            <div>
    <form id="form1" runat="server">
        <div align="center" runat="server">
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblName" runat="server" Text="Name: " class="col-sm-2 col-form-label"></asp:Label>
            &nbsp;<asp:TextBox ID="tbName" runat="server" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
            <br />
            <span id="usernameValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
&nbsp;<asp:Label ID="lblPassword" runat="server" Text="Password: " class="col-sm-2 col-form-label"></asp:Label>
&nbsp;<asp:TextBox ID="tbPassword" runat="server" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
            <br />
            <span id="passwordValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblEmail" runat="server" Text="Email: " class="col-sm-2 col-form-label"></asp:Label>
&nbsp;<asp:TextBox ID="tbEmail" runat="server" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
            <br />
            <span id="emailValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
&nbsp;&nbsp;
            <asp:Label ID="lblRole" runat="server" Text="Role: " class="col-sm-2 col-form-label"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlRole" runat="server" class="btn btn-primary dropdown-toggle">
                <asp:ListItem>Rewards Member</asp:ListItem>
                <asp:ListItem>Store Manager</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Label ID="lblQuestion1" runat="server" Text="Sercurity Question 1: " class="col-sm-2 col-form-label"></asp:Label>
            	
                <br />
</div>
            <br />
&nbsp;<asp:DropDownList ID="ddlQuestion1" runat="server" class="btn btn-primary dropdown-toggle">
                <asp:ListItem>What is the name of your favorite pet?</asp:ListItem>
                <asp:ListItem>In what city were you born?</asp:ListItem>
                <asp:ListItem>What was your favorite food as a child?</asp:ListItem>
            </asp:DropDownList>
&nbsp;<br />
&nbsp;<asp:TextBox ID="tbQuestion1" align="center" runat="server" class="form-control col-4"></asp:TextBox>
            <span id="question1Validator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
            <asp:Label ID="lblQuestion2" runat="server" Text="Sercurity Question 2: " class="col-sm-2 col-form-label"></asp:Label>
            <br />
            <br />
&nbsp;<asp:DropDownList ID="ddlQuestion2" runat="server" class="btn btn-primary dropdown-toggle">
                <asp:ListItem>What is the name of your 3rd grade teacher?</asp:ListItem>
                <asp:ListItem>What highschool did you attend?</asp:ListItem>
                <asp:ListItem>What is your mother&#39;s maiden name?</asp:ListItem>
            </asp:DropDownList>
&nbsp;<br />
&nbsp;<asp:TextBox ID="tbQuestion2" runat="server"  class="form-control col-4"></asp:TextBox>
            <span id="question2Validator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
            <asp:Label ID="lblQuestion3" runat="server" Text="Sercurity Question 3: " class="col-sm-2 col-form-label"></asp:Label>
            <br />
            <br />
&nbsp;<asp:DropDownList ID="ddlQuestion3" runat="server" class="btn btn-primary dropdown-toggle">
                <asp:ListItem>What was the model of your first car?</asp:ListItem>
                <asp:ListItem>Where did you meet your spouse?</asp:ListItem>
                <asp:ListItem>What was the first concert you attended?</asp:ListItem>
            </asp:DropDownList>
&nbsp;<br />
&nbsp;<asp:TextBox ID="tbQuestion3" runat="server" class="form-control col-4"></asp:TextBox>
            <span id="question3Validator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
            <br />
            <asp:Button ID="btnBack1" runat="server" class="btn btn-dark" Height="40px" Width="75px" OnClick="btnBack1_Click" Text="Back" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit1" runat="server" class="btn btn-dark" Height="40px" OnClick="btnSubmit1_Click" Text="Submit" Width="75px" />
            <br />
            <br />
            <asp:Label ID="lblWarning" runat="server" Visible="False" class="col-sm-2 col-form-label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblEndMsg" runat="server" Text="Please check your email for a verification code. Enter below:" Visible="False" class="col-sm-2 col-form-label"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="tbVerificationCode" runat="server" Visible="False" Wrap="False" class="col-sm-2 col-form-label" Height="30px" Width="150px"></asp:TextBox>
            &nbsp;&nbsp; <asp:Button ID="btnResend" runat="server" Text="Resend code" class="btn btn-dark" Height="40px" Width="115px" Visible="False" OnClick="btnResend_Click"/>
            <br />
            <br />
            <asp:Button ID="btnBack2" runat="server" class="btn btn-dark" Height="40px" Text="Back" Width="75px" OnClick="btnBack2_Click" Visible="False" />
        &nbsp; &nbsp;
            <asp:Button ID="btnSubmit" runat="server" class="btn btn-dark" Height="40px" Text="Submit" Width="75px" OnClick="btnSubmit_Click" Visible="False"  />
            <br />
        </div>
    </form>
</body>
</html>