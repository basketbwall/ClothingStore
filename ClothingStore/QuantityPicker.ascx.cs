using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClothingStore
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int currentQuantity = Convert.ToInt32(lblQuantity.Text);
            if (currentQuantity == 5)
            {
                lblWarning.Text = "You can not go above 5";
                lblWarning.Visible = true;
            } else
            {
                lblQuantity.Text = Convert.ToString(++currentQuantity);
            }
        }

        protected void btnSubtract_Click(object sender, EventArgs e)
        {
            int currentQuantity = Convert.ToInt32(lblQuantity.Text);
            if (currentQuantity == 1)
            {
                lblWarning.Text = "You can not go below 1";
                lblWarning.Visible = true;
            } else
            {
                lblQuantity.Text = Convert.ToString(--currentQuantity);
            }
        }
    }
}