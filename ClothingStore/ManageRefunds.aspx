<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRefunds.aspx.cs" Inherits="ClothingStore.ManageRefunds" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/Navigation-with-Button.css" />
    <link rel="stylesheet" href="assets/css/styles.css/" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
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

        td {
            width: 10%;
        }

        .auto-style1 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

<!-- Modal -->
<div class="modal fade" id="modalConfirm" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Order ID: </h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        Are you sure?
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
        <button type="button" class="btn btn-primary" data-dismiss="modal">Confirm Refund</button>
      </div>
    </div>
  </div>
</div>
                <div style="float: right; margin-top: 5%; width: 50%">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="text-center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CssClass="GridView">
                    <Columns>
                        <asp:BoundField DataField="ClothingName" HeaderText="Name" />
                        <asp:ImageField DataImageUrlField="ClothingImage" HeaderText="Image">
                            <ControlStyle Height="150px" Width="150px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="ClothingColor" HeaderText="Color" />
                        <asp:BoundField DataField="ClothingSize" HeaderText="Size" />
                        <asp:BoundField DataField="ClothingPrice" HeaderText="Price" />
                        <asp:BoundField DataField="ClothingQuantity" HeaderText="Quantity Purchased" />
                        <asp:TemplateField HeaderText="Confirm Refund">
                            <ItemTemplate>
                                <asp:Button ID="btnConfirmRefund" runat="server" Text="Confirm Refund" class="btn btn-dark" />
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
                                <div style="text-align: center;">
                    <asp:Label ID="lblRefundResult" runat="server" Text="" style="margin:auto;"></asp:Label>
                </div>
                </div>
                

                <table style="">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="rptOrders_ItemCommand">
                    <ItemTemplate>
                        <div class="card text-start col-md-3" style="margin-left:5%">
                            <div class="card-body">
                                <h5 class="card-title"></h5>
                                <p class="card-text">
                                    Order ID: <asp:Label ID="lblOrderID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderID") %>'></asp:Label>
                                    <br />
                                    Order Total: <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderTotal", "{0:c}") %>'></asp:Label>
                                    <br />
                                    Order Date: <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderDate") %>'></asp:Label>
                                    <br />
                                    Refund Requested: <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "refundRequested") %>'></asp:Label>
                                </p>
                                <asp:Button ID="Button3" runat="server" Text="View Order" class="btn btn-dark" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                    <asp:Repeater ID="rptOrders" runat="server" OnItemCommand="rptOrders_ItemCommand">
                    <ItemTemplate>
                        <div class="card text-start col-md-3" style="margin-left:5%">
                            <div class="card-body">
                                <h5 class="card-title"></h5>
                                <p class="card-text">
                                    Order ID: <asp:Label ID="lblOrderID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderID") %>'></asp:Label>
                                    <br />
                                    Order Total: <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderTotal", "{0:c}") %>'></asp:Label>
                                    <br />
                                    Order Date: <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderDate") %>'></asp:Label>
                                    <br />
                                    Refund Requested: <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "refundRequested") %>'></asp:Label>
                                </p>
                                <asp:Button ID="Button3" runat="server" Text="View Order" class="btn btn-dark" />
                            </div>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>
                </table>
                <br />
                <div class="text-center">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>
