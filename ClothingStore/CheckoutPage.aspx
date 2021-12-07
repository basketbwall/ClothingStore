<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="ClothingStore.CheckoutPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/Navigation-with-Button.css" />
    <link rel="stylesheet" href="assets/css/styles.css/" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
        <link rel="stylesheet" href="NavBarStyle.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
                <asp:Label ID="lblCartSubmitDisplay" runat="server" Text=""></asp:Label>
        </div>
        <div align="center" runat="server">
            <br />
            <asp:Label ID="lblWarning" align="center" runat="server" Text="Label" Style="font-size:28px"></asp:Label>
        </div>
        <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False" style="margin:auto; width:75%; margin-top: 2.5%; margin-bottom: 2.5%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" ShowFooter="True">
                                        <emptydatatemplate>
                                There are no items in your cart.
                            </emptydatatemplate>
            <Columns>
                <asp:BoundField DataField="ClothingID" HeaderText="ID" />
                <asp:BoundField DataField="ClothingName" HeaderText="Name" />
                <asp:BoundField DataField="ClothingColor" HeaderText="Color" />
                <asp:ImageField DataImageUrlField="ClothingImage" HeaderText="Image">
                    <ControlStyle Height="150px" Width="150px" />
                </asp:ImageField>
                <asp:BoundField DataField="OnClearance" HeaderText="Clearance" />
                <asp:BoundField DataField="ClearanceDiscountPercent" HeaderText="Discount Percent" />
                <asp:BoundField DataField="ClothingPrice" HeaderText="Price" />
                <asp:BoundField DataField="ClothingSize" HeaderText="Size" />
                <asp:BoundField DataField="ClothingQuantity" HeaderText="Quantity" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDecrease" runat="server" Text="-" class="btn btn-success" OnClick="btnDecrease_Click"/>
                        <asp:Button ID="btnIncrease" runat="server" Text="+" class="btn btn-danger" OnClick="btnIncrease_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Remove" class="btn btn-dark" OnClick="btnDelete_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <div class="text-center">
                        <asp:Button ID="btnSubmitOrder" runat="server" Text="Submit Order" class="btn btn-warning" OnClick="btnSubmitOrder_Click"/>
                        <br />
                        <asp:Label ID="lblPayment" runat="server" Text="Payment Information" Visible="False" Font-Size="24px"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblName" runat="server" Text="Cardholder Name (as printed on card): " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbName" runat="server" Visible="False" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
                        <br />
                        <span id="nameValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
                        <asp:Label ID="lblCardNumber" runat="server" Text="Card Number: " Visible="False"></asp:Label>
&nbsp;
                        <asp:TextBox ID="tbCardNumber" runat="server" class="col-sm-2 col-form-label" Height="30px" Width="200px" Visible="False" MaxLength="16" ></asp:TextBox>
                        <br />
                        <span id="cardNumberValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
                        <asp:Label ID="lblExpirationDate" runat="server" Text="Expiration Date: " Visible="False"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlMonth" runat="server" Visible="False" class="btn btn-primary dropdown-toggle">
                            <asp:ListItem Value="01">01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList>
&nbsp;
                        <asp:DropDownList ID="ddlYear" runat="server" Visible="False" class="btn btn-primary dropdown-toggle">
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                            <asp:ListItem>2021</asp:ListItem>
                            <asp:ListItem>2022</asp:ListItem>
                            <asp:ListItem>2023</asp:ListItem>
                            <asp:ListItem>2024</asp:ListItem>
                            <asp:ListItem>2025</asp:ListItem>
                            <asp:ListItem>2026</asp:ListItem>
                            <asp:ListItem>2027</asp:ListItem>
                            <asp:ListItem>2028</asp:ListItem>
                            <asp:ListItem>2029</asp:ListItem>
                            <asp:ListItem>2030</asp:ListItem>
                        </asp:DropDownList>
&nbsp;
                        <asp:Label ID="lblCVV" runat="server" Text="CVV: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbCVV" runat="server" class="col-sm-2 col-form-label" Height="30px" Width="70px" Visible="False" MaxLength="4"></asp:TextBox>
                        <br />
                        <span id="cvvValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
                        <br />
                        <asp:Label ID="lblBilling" runat="server" Text="Billing Address" Visible="False" Font-Size="24px"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblCountry" runat="server" Text="Country: " Visible="False"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlCountry" runat="server" Visible="False" class="btn btn-primary dropdown-toggle">
                            <asp:ListItem Value="Select a country">Select a country</asp:ListItem>
                            <asp:ListItem>Afghanistan</asp:ListItem>
                            <asp:ListItem>Albania</asp:ListItem>
                            <asp:ListItem>Argentina</asp:ListItem>
                            <asp:ListItem>Australia</asp:ListItem>
                            <asp:ListItem>Austria</asp:ListItem>
                            <asp:ListItem>Bahamas</asp:ListItem>
                            <asp:ListItem>Belgium</asp:ListItem>
                            <asp:ListItem>Bolivia</asp:ListItem>
                            <asp:ListItem>Brazil</asp:ListItem>
                            <asp:ListItem>Cambodia</asp:ListItem>
                            <asp:ListItem>Canada</asp:ListItem>
                            <asp:ListItem>Chad</asp:ListItem>
                            <asp:ListItem>China</asp:ListItem>
                            <asp:ListItem>Colombia</asp:ListItem>
                            <asp:ListItem>Congo </asp:ListItem>
                            <asp:ListItem>Cuba</asp:ListItem>
                            <asp:ListItem>Denmark</asp:ListItem>
                            <asp:ListItem>Dominica</asp:ListItem>
                            <asp:ListItem>Egypt</asp:ListItem>
                            <asp:ListItem>Estonia</asp:ListItem>
                            <asp:ListItem>Finland</asp:ListItem>
                            <asp:ListItem>France</asp:ListItem>
                            <asp:ListItem>Germany</asp:ListItem>
                            <asp:ListItem>Greece</asp:ListItem>
                            <asp:ListItem>Guinea</asp:ListItem>
                            <asp:ListItem>Guyana</asp:ListItem>
                            <asp:ListItem>Haiti</asp:ListItem>
                            <asp:ListItem>Hungary</asp:ListItem>
                            <asp:ListItem>Iceland</asp:ListItem>
                            <asp:ListItem>India</asp:ListItem>
                            <asp:ListItem>Iran</asp:ListItem>
                            <asp:ListItem>Iraq</asp:ListItem>
                            <asp:ListItem>Ireland</asp:ListItem>
                            <asp:ListItem>Israel</asp:ListItem>
                            <asp:ListItem>Italy</asp:ListItem>
                            <asp:ListItem>Japan</asp:ListItem>
                            <asp:ListItem>Kenya</asp:ListItem>
                            <asp:ListItem>Kyrgyzstan</asp:ListItem>
                            <asp:ListItem>Lebanon</asp:ListItem>
                            <asp:ListItem>Libya</asp:ListItem>
                            <asp:ListItem>Luxembourg</asp:ListItem>
                            <asp:ListItem>Madagascar</asp:ListItem>
                            <asp:ListItem>Mexico</asp:ListItem>
                            <asp:ListItem>Mongolia</asp:ListItem>
                            <asp:ListItem>Morocco</asp:ListItem>
                            <asp:ListItem>Nepal</asp:ListItem>
                            <asp:ListItem>Netherlands</asp:ListItem>
                            <asp:ListItem>North Korea</asp:ListItem>
                            <asp:ListItem>Norway</asp:ListItem>
                            <asp:ListItem>Peru</asp:ListItem>
                            <asp:ListItem>Philippines</asp:ListItem>
                            <asp:ListItem>Poland</asp:ListItem>
                            <asp:ListItem>Russia</asp:ListItem>
                            <asp:ListItem>Samoa</asp:ListItem>
                            <asp:ListItem>Serbia</asp:ListItem>
                            <asp:ListItem>South Korea</asp:ListItem>
                            <asp:ListItem>Spain</asp:ListItem>
                            <asp:ListItem>Sweden</asp:ListItem>
                            <asp:ListItem>Switzerland</asp:ListItem>
                            <asp:ListItem>Turkey</asp:ListItem>
                            <asp:ListItem>Ukraine</asp:ListItem>
                            <asp:ListItem>United Kingdom</asp:ListItem>
                            <asp:ListItem>United States of America</asp:ListItem>
                            <asp:ListItem>Venezuela</asp:ListItem>
                            <asp:ListItem>Vietnam</asp:ListItem>
                            <asp:ListItem>Zimbabwe</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <span id="countryValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
                        <asp:Label ID="lblAddress" runat="server" Text="Address 1: " Visible="False"></asp:Label>
                        <asp:TextBox ID="tbAddress1" runat="server" Visible="False" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
                        <br />
                        <span id="address1Validator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
                        <asp:Label ID="lblAddress2" runat="server" Text="Address 2: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbAddress2" runat="server" Visible="False" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblCity" runat="server" Text="City: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbCity" runat="server" Visible="False" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
&nbsp;<br />
                        <span id="cityValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
&nbsp;<asp:Label ID="lblState" runat="server" Text="State/Province/Region: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbState" runat="server" Visible="False" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
                        <br />
                        <span id="stateValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
                        <asp:Label ID="lblZip" runat="server" Text="ZIP/Postal code: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbZip" runat="server" Visible="False" class="col-sm-2 col-form-label" Height="30px" Width="200px" MaxLength="10"></asp:TextBox>
                        <br />
                        <span id="zipValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
                        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbPhoneNumber" runat="server" Visible="False" class="col-sm-2 col-form-label" Height="30px" Width="200px" MaxLength="10"></asp:TextBox>
                        <br />
                        <span id="phoneNumberValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
                        <asp:Label ID="lblEmail" runat="server" Text="Email: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbEmail" runat="server" Visible="False" class="col-sm-2 col-form-label" Height="30px" Width="200px"></asp:TextBox>
                        <br />
                        <span id="emailValidator" runat="server" style="color: red;" visible="false">* Required Field</span><br />
                        <br />
                        <asp:Button ID="btnSubmitFinal" runat="server" Text="Submit Order" class="btn btn-warning" OnClick="btnSubmitFinal_Click" Visible="False" />
        </div>

    </form>
</body>
</html>