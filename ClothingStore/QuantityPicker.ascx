<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuantityPicker.ascx.cs" Inherits="ClothingStore.WebUserControl2" %>
<asp:Label ID="lblQuantity" runat="server" Text="1"></asp:Label>
<asp:Button ID="btnSubtract" runat="server" OnClick="btnSubtract_Click" Text="-" class="btn btn-secondary" />
<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="+" class="btn btn-primary" />
<br />
<asp:Label ID="lblWarning" runat="server" Text="Warning Message" Visible="False"></asp:Label>

