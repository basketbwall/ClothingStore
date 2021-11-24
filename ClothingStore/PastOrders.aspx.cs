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
                //set the repeater datasource and databind
                DataSet orders = SP.GetOrders();
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
            int rowIndex = e.Item.ItemIndex;

            // Retrieve a value from a control in the Repeater's Items collection

            Label myLabel = (Label)rptOrders.Items[rowIndex].FindControl("lblOrderID");

            String orderNumber = myLabel.Text;

            lblDisplay.Text = "You selected orderNumber " + orderNumber;

            //using order number grab the clothing list and display that in a gridview

            StoredProcedures SP = new StoredProcedures();
            //retreive the info and put in display text
            DataSet orderDataSet = SP.RetrieveOrderItems(1);
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

        protected void btnManageRefunds_Click(object sender, EventArgs e)
        {
            Response.Redirect("manageRefunds.aspx");

        }

        protected void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("PastOrders.aspx");

        }
    }
}