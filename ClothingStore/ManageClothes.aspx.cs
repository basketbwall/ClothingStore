using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClothingStore
{
    public partial class ManageClothes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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