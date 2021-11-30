using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Classes;
using Utilities;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace ClothingStore
{
    public partial class ManageClothes : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //check role and update label on top right and set visibility of buttons
           // Navbar ctrl = (Navbar)LoadControl("Navbar.ascx");
           // Form.Controls.AddAt(0, ctrl);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["ver"] = verificationCode.ToString(); //setting up

            /*
            string name = (string)(Session["name"]); //receiving
            string color = (string)(Session["color"]); 
            string description = (string)(Session["description"]); 
            string URL = (string)(Session["URL"]); 
            string small = (string)(Session["small"]); 
            string med = (string)(Session["med"]); 
            string large = (string)(Session["large"]); 
            string onClearance = (string)(Session["onClearance"]); 
            string precentageOff = (string)(Session["precentageOff"]); 
            string price = (string)(Session["price"]); 
            string brand = (string)(Session["brand"]);
            
            tbName.Text = name;
            tbColor.Text = color;
            tbDescription.Text = description;
            tbURL.Text = URL;
            tbSmall.Text = small;
            tbMed.Text = med;
            tbLarge.Text = large;
            //on clearance ?
            tbPercentageOff.Text = precentageOff;
            tbPrice.Text = price;
            tbBrand.Text = brand;
            */
        }
        protected void cbClearance_CheckedChanged(object sender, EventArgs e)
        {

            if (cbClearance.Checked == true)
            {
                lblOff.Visible = true;
                tbPercentageOff.Visible = true;
            }
            else
            {
                lblOff.Visible = false;
                tbPercentageOff.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(cbClearance.Checked == false)
            {
                tbPercentageOff.Text = "0";
            }
            //string clothingID = (string)(Session["clothingID"]);

            StoredProcedures storedProc = new StoredProcedures();

           // storedProc.UpdateClothing(clothingID);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalog.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
          //  string clothingID = (string)(Session["clothingID"]);

            StoredProcedures storedProc = new StoredProcedures();

         //   storedProc.DeleteClothing(clothingID);

            Response.Redirect("Catalog.aspx");
        }
    }
}