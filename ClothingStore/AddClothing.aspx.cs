using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Classes;

namespace ClothingStore
{
    public partial class AddClothing : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //check role and update label on top right and set visibility of buttons
            Navbar ctrl = (Navbar)LoadControl("Navbar.ascx");
            Form.Controls.AddAt(0, ctrl);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalog.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbColor.Text != "" && tbDescription.Text != "" && tbURL.Text != "" && tbSmall.Text != "" && tbMed.Text != "" && tbLarge.Text != "" && tbPercentageOff.Text != "" && tbPrice.Text != "" && tbBrand.Text != "")
            {
                if (cbClearance.Checked == false)
                {
                    tbPercentageOff.Text = "0";
                }

                StoredProcedures storedProc = new StoredProcedures();

                string clearanceStatus = "1";

                if (cbClearance.Checked == false)
                {
                    clearanceStatus = "0";
                    tbPercentageOff.Text = "0";
                }

                storedProc.AddClothing(tbName.Text, tbColor.Text, tbDescription.Text, tbURL.Text, tbSmall.Text, tbMed.Text, tbLarge.Text, clearanceStatus, tbPercentageOff.Text, tbPrice.Text, tbBrand.Text);

                Response.Redirect("Catalog.aspx");
            }
            else
            {
                if (cbClearance.Checked == true)
                {
                    percentageValidator.Visible = true;
                }
                nameValidator.Visible = true;
                priceValidator.Visible = true;
                colorValidator.Visible = true;
                brandValidator.Visible = true;
                urlValidator.Visible = true;
                descriptionValidator.Visible = true;
                stockValidator.Visible = true;
            }
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
    }
}