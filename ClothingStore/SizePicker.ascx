<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SizePicker.ascx.cs" Inherits="ClothingStore.WebUserControl1" %>
<asp:Label ID="lblSize" runat="server"></asp:Label>
<asp:RadioButtonList ID="rdbSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
    <asp:ListItem>Small</asp:ListItem>
    <asp:ListItem>Medium</asp:ListItem>
    <asp:ListItem>Large</asp:ListItem>
</asp:RadioButtonList>

