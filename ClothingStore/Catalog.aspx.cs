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
        protected void Page_Init(object sender, EventArgs e)
        {
            //check role and update label on top right and set visibility of buttons
            Navbar ctrl = (Navbar)LoadControl("Navbar.ascx");
            Form.Controls.AddAt(0, ctrl);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnClothing_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtClothingID.Text);
            Response.Redirect("ClothingPage.aspx" + "?ClothingID=" + id);
        }

    }
}