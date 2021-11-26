using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization; //JSON serializers
using System.IO; //Stream and StreamReader
using System.Net; //needed for web request
using Classes; //needed for any classes
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClothingStore
{
    public partial class PastOrders : System.Web.UI.Page
    {
        StoredProcedures SP;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if(Session["Role"].ToString() != "RewardsCustomer")
            {
                //prevent the page to load the html and give a warning somehow
                this.Controls.Clear();
                Response.Write("You are not allowed here buddy");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //check role and update label on top right and set visibility of buttons
                if (Session["Role"].ToString() == "RewardsCustomer")
                {
                    navPurchaseHistory.Visible = true;
                    navCheckoutPage.Visible = true;
                    lblUser.Text = "Hello " + "Rewards Customer";
                    navSignOut.Visible = true;
                }
                else if (Session["Role"].ToString() == "Administrator")
                {
                    navManageRefunds.Visible = true;
                    lblUser.Text = "Hello " + "Administrator";
                    navSignOut.Visible = true;
                }
                else
                {
                    //visitor
                    navCheckoutPage.Visible = true;
                    lblUser.Text = "Hello " + "Visitor";
                    navSignIn.Visible = true;
                }
                //call stored procedure to get order items field from an order based on id
                //check for null returned in field
                //de-serialize the binary data to reconstruct order items list


                StoredProcedures SP = new StoredProcedures();
                //call stored procedure to get a dataset of orders that belong to the current user
                //set the repeater datasource and
                int userID = int.Parse(Session["UserID"].ToString());
                DataSet orders = SP.GetUserOrders(userID);
                rptOrders.DataSource = orders;
                rptOrders.DataBind();

            }
        }

        protected void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCatalog_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalog.aspx");
        }

        protected void rptOrders_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            lblRefund.Text = "";
            divCurrentOrder.Visible = true;
            int rowIndex = e.Item.ItemIndex;

            // Retrieve a value from a control in the Repeater's Items collection

            Label myLabel = (Label)rptOrders.Items[rowIndex].FindControl("lblOrderID");

            String orderNumber = myLabel.Text;

            btnRefundRequest.Text = "Request Refund For Order: " + orderNumber;

            //using order number grab the clothing list and display that in a gridview

            StoredProcedures SP = new StoredProcedures();
            //retreive the info and put in display text
            DataSet orderDataSet = SP.RetrieveOrderItems(int.Parse(orderNumber));
            if (orderDataSet.Tables[0].Rows.Count != 0)
            {
                Byte[] byteArray = (Byte[])orderDataSet.Tables[0].Rows[0]["orderItems"];
                BinaryFormatter deSerializer = new BinaryFormatter();

                MemoryStream memStream = new MemoryStream(byteArray);



                List<Classes.Clothing> objOrderItems = (List<Classes.Clothing>)deSerializer.Deserialize(memStream);
                GridView1.DataSource = objOrderItems;
                GridView1.DataBind();
            }
        }

        protected void btnRefundRequest_Click(object sender, EventArgs e)
        {
            SP = new StoredProcedures();
            String[] btnText = btnRefundRequest.Text.Split(' ');
            int orderID = int.Parse(btnText[4]);

            //check the refund status if already set to true using stored procedure to check
            if (SP.CheckRefundStatus(orderID))
            {
                lblRefund.Text = "Refund already requested for order ID: " + orderID;
            }
            else
            {
                //else initiate refund using stored procedure to set to true
                int res = SP.RequestRefund(orderID);
                if (res == 1)
                {
                    lblRefund.Text = "Refund requested for order ID: " + orderID;
                    int userID = int.Parse(Session["UserID"].ToString());
                    DataSet orders = SP.GetUserOrders(userID);
                    rptOrders.DataSource = orders;
                    rptOrders.DataBind();
                }
            }

        }
    }
}