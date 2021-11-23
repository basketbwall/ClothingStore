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

namespace ClothingStore
{
    public partial class PastOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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