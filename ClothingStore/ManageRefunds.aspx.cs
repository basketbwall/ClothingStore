using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ClothingStore
{
    public partial class ManageRefunds : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //check role and update label on top right and set visibility of buttons
            Navbar ctrl = (Navbar)LoadControl("Navbar.ascx");
            Form.Controls.AddAt(0, ctrl);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                //prevent the page to load the html and give a warning somehow
                this.Controls.Clear();
                Response.Write("You are not allowed here buddy");
                return;
            }
            else if (Session["Role"].ToString() != "Administrator")
            {
                //prevent the page to load the html and give a warning somehow
                this.Controls.Clear();
                Response.Write("You are not allowed here buddy");
                return;
            }
            if (!IsPostBack)
            {

                StoredProcedures SP = new StoredProcedures();
                //call stored procedure to get a dataset of orders that have refundrequest column set to true
                //set the repeater datasource and databind
                DataSet orders = SP.GetRefundRequests();
                rptOrders.DataSource = orders;
                rptOrders.DataBind();

            }
        }

        protected void rptOrders_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;

            // Retrieve a value from a control in the Repeater's Items collection

            Label myLabel = (Label)rptOrders.Items[rowIndex].FindControl("lblOrderID");

            String orderNumber = myLabel.Text;

            //lblDisplay.Text = "You selected orderNumber " + orderNumber;

            //display gridview using api call to grab order
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

                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            //call stored procedure to delete a order
            SP = new StoredProcedures();
            int retVal = SP.ConfirmRefund(int.Parse(orderNumber));

            if (retVal == 1)
            {
                //let admin know the refund was issued
                lblRefundResult.Text = "Refund was successfully issued.";
            }
            else
            {
                //let admin know there was an error and refund was not issued
                lblRefundResult.Text = "Refund was NOT successfully issued.";
            }
        }

        protected void btnConfirmRefund_Click(object sender, EventArgs e)
        {

        }
    }
}