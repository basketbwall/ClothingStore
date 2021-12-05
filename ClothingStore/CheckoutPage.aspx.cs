using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace ClothingStore
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //check role and update label on top right and set visibility of buttons
            Navbar ctrl = (Navbar)LoadControl("Navbar.ascx");
            Form.Controls.AddAt(0, ctrl);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Administrator")
            {
                //prevent the page to load the html and give a warning somehow
                this.Controls.Clear();
                Response.Write("You are not allowed here buddy");
                return;
            }

            if (!IsPostBack)
            {
                gvOrder.DataSource = Session["Cart"];
                gvOrder.DataBind();
            }

        }

        protected void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            //create order using add order stored procedure
            
            //appending the list of clothes bought to the orderitems column of the order
            StoredProcedures SP = new StoredProcedures();
            //call stored procedure that sets the order given an order ID
            List<Classes.Clothing> Cart = (List<Classes.Clothing>)Session["Cart"];
            // Serialize the OrderItem List object

            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            Byte[] byteArray;

            serializer.Serialize(memStream, Cart);

            byteArray = memStream.ToArray();

            // Create the Web Service Proxy Object used to talk to the Web Service in SOAP
            CheckoutService.CheckoutProcessor wsProxy = new CheckoutService.CheckoutProcessor();

            //bool result = wsProxy.Storing(byteArray, )
                

            //if (order.  == true)
            //    lblCartSubmitDisplay.Text = "The order items were successfully stored for this account.";

            //else

            //    lblCartSubmitDisplay.Text = "A problem occured in storing the order items.";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Response.Write("Clothing Name: " + gvr.Cells[0].Text);
            //grab the cart from session. remove the clothing item using name + size to locate which to remove
            List<Classes.Clothing> Cart = (List<Classes.Clothing>)Session["Cart"];
            foreach(Classes.Clothing clothing in Cart)
            {
                
            }

        }

        protected void btnIncrease_Click(object sender, EventArgs e)
        {
            //grab the cart from session. increment quantity of the clothing item using name + size to locate which to remove
            List<Classes.Clothing> Cart = (List<Classes.Clothing>)Session["Cart"];
            foreach (Classes.Clothing clothing in Cart)
            {

            }
        }

        protected void btnDecrease_Click(object sender, EventArgs e)
        {
            //grab the cart from session. decrement quantity of the clothing item using name + size to locate which to remove
            List<Classes.Clothing> Cart = (List<Classes.Clothing>)Session["Cart"];
            foreach (Classes.Clothing clothing in Cart)
            {

            }
        }
    }
}