using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClothingStore
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateCart();
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
            }
        }

        public void UpdateCart()
        {
            //check session object for cart
            if (Session["Cart"] == null || Session["Cart"].ToString() == "0")
            {
                CartSpan.Visible = false;
            }
            else
            {
                List<Classes.Clothing> Cart = (List<Classes.Clothing>)Session["Cart"]; //instantiate using previous cart info
                int quantity = 0;
                foreach (Classes.Clothing c in Cart)
                {
                    quantity += c.ClothingQuantity;
                }
                CartSpan.Visible = true;
                lblCartTotalQuantity.Text = quantity.ToString();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Catalog.aspx");
        }
    }
}