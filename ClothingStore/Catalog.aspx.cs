using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClothingStore
{
    public partial class Catalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check role and update label on top right and set visibility of buttons
                if (Session["Role"].ToString() == "RewardsCustomer")
                {
                    btnPurchaseHistory.Visible = true;
                    btnCheckOut.Visible = true;
                    lblUser.Text = "Hello " + "Rewards Customer";
                    btnSignOut.Visible = true;
                }
                else if (Session["Role"].ToString() == "Administrator")
                {
                    btnManageRefunds.Visible = true;
                    lblUser.Text = "Hello " + "Administrator";
                    btnSignOut.Visible = true;
                }
                else
                {
                    //visitor
                    btnCheckOut.Visible = true;
                    lblUser.Text = "Hello " + "Visitor";
                    btnSignIn.Visible = true;
                }
            }
        }

        protected void btnClothing_Click(object sender, EventArgs e)
        {
            int id = 2;
            Response.Redirect("ClothingPage.aspx" + "?ClothingID=" + id);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("PastOrders.aspx");
        }
    }
}