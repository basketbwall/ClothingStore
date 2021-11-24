﻿using System;
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

        protected void btnClothing_Click(object sender, EventArgs e)
        {
            int id = 2;
            Response.Redirect("ClothingPage.aspx" + "?ClothingID=" + id);
        }

    }
}