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
            btnSubmitOrder.Visible = false;
            lblAddress.Visible = true;
            lblAddress2.Visible = true;
            lblBilling.Visible = true;
            lblCardNumber.Visible = true;
            lblCity.Visible = true;
            lblCountry.Visible = true;
            lblCVV.Visible = true;
            lblEmail.Visible = true;
            lblExpirationDate.Visible = true;
            lblName.Visible = true;
            lblPayment.Visible = true;
            lblPhoneNumber.Visible = true;
            lblState.Visible = true;
            lblZip.Visible = true;
            tbName.Visible = true;
            tbAddress1.Visible = true;
            tbAddress2.Visible = true;
            tbCardNumber.Visible = true;
            tbCity.Visible = true;
            tbCVV.Visible = true;
            tbEmail.Visible = true;
            tbPhoneNumber.Visible = true;
            tbState.Visible = true;
            tbZip.Visible = true;
            ddlCountry.Visible = true;
            ddlMonth.Visible = true;
            ddlYear.Visible = true;
            btnSubmitFinal.Visible = true;

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Response.Write("Clothing Name: " + gvr.Cells[0]);
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

        protected void btnSubmitFinal_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbAddress1.Text != "" && tbAddress2.Text != "" && tbCardNumber.Text != "" && tbCity.Text != "" && tbCVV.Text != "" && tbEmail.Text != "" && tbPhoneNumber.Text != "" && tbState.Text != "" && tbZip.Text != "" && ddlCountry.SelectedValue != "Select a country")
            {
                string name = tbName.Text;
                string address1 = tbAddress1.Text;
                string address2 = tbAddress2.Text;
                string cardNumber = tbCardNumber.Text;
                string city = tbCity.Text;
                string cvv = tbCVV.Text;
                string email = tbEmail.Text;
                string phoneNumber = tbPhoneNumber.Text;
                string state = tbState.Text;
                string zip = tbZip.Text;
                string country = ddlCountry.SelectedValue;
                string month = ddlMonth.SelectedValue;
                string year = ddlYear.SelectedValue;

                StoredProcedures StoredProc = new StoredProcedures();
                List<Classes.Clothing> Cart = (List<Classes.Clothing>)Session["Cart"];
                decimal price = 0.00m;

                foreach (Classes.Clothing clothing in Cart)
                {
                  price +=  clothing.ClothingPrice;
                }
                price = price - (price * 0.06m);

                DateTime localDate = DateTime.Now; //gets current datetime
                int refundRequest = 0;
                string userID = Session["UserID"].ToString();

                //create order using add order stored procedure

               // StoredProc.AddOrder(price, localDate, refundRequest, userID);


                //appending the list of clothes bought to the orderitems column of the order
                StoredProcedures SP = new StoredProcedures();
                //call stored procedure that sets the order given an order ID


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
            else //11
            {
                nameValidator.Visible = true;
                emailValidator.Visible = true;
                cvvValidator.Visible = true;
                countryValidator.Visible = true;
                address1Validator.Visible = true;
                addresss2Validator.Visible = true;
                zipValidator.Visible = true;
                phoneNumberValidator.Visible = true;
                stateValidator.Visible = true;
                cityValidator.Visible = true;
                cardNumberValidator.Visible = true;

            }
        }
    }
}