using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;

namespace ClothingStore
{
    public partial class ManageRefunds : System.Web.UI.Page
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

        protected void rptOrders_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;

            // Retrieve a value from a control in the Repeater's Items collection

            Label myLabel = (Label)rptOrders.Items[rowIndex].FindControl("lblOrderID");

            String orderNumber = myLabel.Text;

            lblDisplay.Text = "You selected orderNumber " + orderNumber;
        }

        protected void btnPurchaseHistory_Click1(object sender, EventArgs e)
        {
            Response.Redirect("PastOrders.aspx");

        }

        protected void btnCatalog_Click(object sender, EventArgs e)
        {

        }

        protected void btnClearance_Click(object sender, EventArgs e)
        {

        }

        protected void btnManageRefunds_Click(object sender, EventArgs e)
        {

        }

        protected void btnCheckOut_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}