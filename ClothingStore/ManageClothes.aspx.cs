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
            Navbar ctrl = (Navbar)LoadControl("Navbar.ascx");
            Form.Controls.AddAt(0, ctrl);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int clothingID = Int32.Parse(Session["ClothingID"].ToString()); //receiving

            StoredProcedures storedProc = new StoredProcedures();
            Classes.Clothing currentClothing = storedProc.GetClothingByID(clothingID);


            tbName.Text = currentClothing.ClothingName;
            tbColor.Text = currentClothing.ClothingColor;
            tbDescription.Text = currentClothing.ClothingDescription;
            tbURL.Text = currentClothing.ClothingImage;
            tbSmall.Text = currentClothing.SmallStock.ToString();
            tbMed.Text = currentClothing.MediumStock.ToString();
            tbLarge.Text = currentClothing.LargeStock.ToString();
            //on clearance ?
            if (currentClothing.OnClearance.ToString() == "True")
            {
                cbClearance.Checked = true;
            }
            else
            {
                cbClearance.Checked = false;
            }

            tbPercentageOff.Text = currentClothing.ClearanceDiscountPercent.ToString();
            tbPrice.Text = currentClothing.ClothingPrice.ToString();
            tbBrand.Text = currentClothing.ClothingBrand;

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
            if (cbClearance.Checked == false)
            {
                tbPercentageOff.Text = "0";
            }
            int clothingID = Int32.Parse(Session["ClothingID"].ToString());

            StoredProcedures storedProc = new StoredProcedures();
            Classes.Clothing currentClothing = storedProc.GetClothingByID(clothingID);

            string clearanceStatus = "1";

            if (cbClearance.Checked == false)
            {
                clearanceStatus = "0";
                tbPercentageOff.Text = "0";
            }

            storedProc.UpdateClothing(clothingID, tbName.Text, tbColor.Text, tbDescription.Text, tbURL.Text, tbSmall.Text, tbMed.Text, tbLarge.Text, clearanceStatus, tbPercentageOff.Text, tbPrice.Text, tbBrand.Text);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalog.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int clothingID = Int32.Parse(Session["ClothingID"].ToString());

            StoredProcedures storedProc = new StoredProcedures();
            
            storedProc.DeleteClothing(clothingID);

            Response.Redirect("Catalog.aspx");
        }
    }
}