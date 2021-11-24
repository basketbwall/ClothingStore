using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Category("Misc")]
        public int CurrentQuantity

        {

            get { return int.Parse(lblQuantity.Text); }

            set { lblQuantity.Text = value.ToString(); }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int currentQuantity = int.Parse(lblQuantity.Text);
            if (currentQuantity == 5)
            {
                lblWarning.Text = "You can not go above 5";
                lblWarning.Visible = true;
            } else
            {
                lblWarning.Text = "";
                lblQuantity.Text = Convert.ToString(++currentQuantity);
            }
        }

        protected void btnSubtract_Click(object sender, EventArgs e)
        {
            int currentQuantity = int.Parse(lblQuantity.Text.ToString());
            if (currentQuantity == 1)
            {
                lblWarning.Text = "You can not go below 1";
                lblWarning.Visible = true;
            } else
            {
                lblWarning.Text = "";
                lblQuantity.Text = Convert.ToString(--currentQuantity);
            }
        }
    }
}