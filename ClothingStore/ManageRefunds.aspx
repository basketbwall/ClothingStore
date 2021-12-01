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
                        <h2 style="margin-left:5%"> Past Orders </h2>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="display: inline-block; float:right; margin-top: 5%; margin-right: 2.5%;" class="col-md-6">
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
                                    <asp:Button ID="btnConfirmRefund" runat="server" Text="Confirm Refund" visible="false" class="btn btn-dark" OnClick="btnConfirmRefund_Click" />
                                    <br />
                    <asp:Label ID="lblRefundResult" runat="server" Text="" style="margin:auto;"></asp:Label>
                </div>
                </div>
                

                <table style="display: inline-block">
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
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
        <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
<link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css" />
<script type="text/javascript">

    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {
        createDataTable();
    });

    createDataTable();

    function createDataTable() {
        $('#<%= GridView1.ClientID %>').DataTable();
    }
</script>
</body>
</html>
