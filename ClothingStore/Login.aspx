<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClothingStore.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <title></title>
    <style>
        #login {
            margin: auto;
            margin-top: 10%;
            border: solid black 0.5px;
            padding: 5%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="login" class="text-center col-md-5" style="border-radius: 2.5px">
            <h1>Log In</h1>
            <div>
                <asp:Label ID="lblUsername" runat="server" Text="Enter Your Username:" class="col-sm-2 col-form-label"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" class="form-control col-4"></asp:TextBox>
                <span runat="server" visible="false" id="usernameValidator" style="color: red;">* Required Field</span>
                <br />
                <asp:LinkButton ID="btnUsername" runat="server" OnClick="btnUsername_Click">Forgot Your Username?</asp:LinkButton>
            </div>
            <br />
            <div>
                <asp:Label ID="lblPassword" runat="server" Text="Enter Your Password:" class="col-sm-2 col-form-label"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" class="form-control col-4" type="password"></asp:TextBox>
                <span runat="server" visible="false" id="passwordValidator" style="color: red;">* Required Field</span>
                <br />

            </div>
            <asp:LinkButton ID="btnForgotPassword" runat="server" OnClick="btnForgotPassword_Click">Forgot Your Password?</asp:LinkButton>
            <asp:CheckBox ID="chkSaveUsername" runat="server" Text="Save Login Info" class="form-check" />
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-dark" OnClick="btnRegister_Click" />
            <asp:Button ID="btnLogin" runat="server" Text="Log In" class="btn btn-primary" OnClick="btnLogin_Click" />
            <br />
            <br />
            <asp:Label ID="lblLogin" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnContinue" runat="server" Text="Continue Without Account" class="btn btn-success" OnClick="btnContinue_Click" />
        </div>

        <div runat="server" visible="false" id="divRecovery" class="col-md-5 text-center" style="margin: auto;">
            <asp:Label ID="lblEmail" runat="server" Text="To retreive your username and/or password, enter the email associated with your account:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
            <span runat="server" visible="false" id="emailValidator" style="color: red;">* Required Field</span>
                <br />
            <asp:Button ID="btnSubmitEmail" runat="server" Text="Submit Email" class="btn btn-success" OnClick="btnSubmitEmail_Click" />
        </div>
        <br />
        <div runat="server" visible="false" id="securityQuestion" class="col-md-5 text-center" style="margin: auto;">
            <asp:Label ID="lblSecurityQuestion" runat="server" Text="Security Question"></asp:Label>
            <asp:TextBox ID="txtSecurityAnswer" runat="server" class="form-control"></asp:TextBox>
             <span runat="server" visible="false" id="securityQuestionValidator" style="color: red;">* Required Field</span>
             <br />
            <asp:Button ID="btnAnswerSecurity" runat="server" Text="Submit Answer" class="btn btn-success" OnClick="btnAnswerSecurity_Click" />

        </div>

        <br />

        <div runat="server" visible="false" id="recoveryOptions" class="col-md-5 text-center" style="margin: auto;">

            <asp:Button ID="btnRecoverPassword" runat="server" Text="Recover Password" class="btn btn-success" OnClick="btnRecoverPassword_Click" />
            <asp:Button ID="btnRecoverUsername" runat="server" Text="Recover Username" class="btn btn-success" OnClick="btnRecoverUsername_Click1" />
            <br />
            <asp:Label ID="lblEmailDisplay" runat="server" Text="Label"></asp:Label>
        </div>
        &nbsp;
    </form>
</body>
</html>
