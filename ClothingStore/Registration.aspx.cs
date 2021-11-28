using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClothingStore
{
    public partial class Registration : System.Web.UI.Page
    {

        int verificationCode = 0;

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string password = tbPassword.Text;
            string email = tbEmail.Text;
            string questionOne = tbQuestion1.Text;
            string questionTwo = tbQuestion2.Text;
            string questionThree = tbQuestion3.Text;

            if (tbVerificationCode.Text == verificationCode.ToString())
            {
                // stored procedure to add the user into the database
                //Response.Write();              WILL BE USED TO GO TO THE LOG IN PAGE AFTER ADD THE DATA INTO A TABLE
            }

        }

        protected void btnBack1_Click(object sender, EventArgs e)
        {
            //Response.Write();     WILL BE USED TO GO TO THE LOG IN PAGE 
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            lblName.Visible = true;
            tbName.Visible = true;
            lblEmail.Visible = true;
            tbEmail.Visible = true;
            lblPassword.Visible = true;
            tbPassword.Visible = true;
            lblRole.Visible = true;
            ddlRole.Visible = true;

            lblQuestion1.Visible = true;
            lblQuestion2.Visible = true;
            lblQuestion3.Visible = true;
            ddlQuestion1.Visible = true;
            ddlQuestion2.Visible = true;
            ddlQuestion3.Visible = true;
            tbQuestion1.Visible = true;
            tbQuestion2.Visible = true;
            tbQuestion3.Visible = true;

            btnSubmit1.Visible = true;
            btnBack1.Visible = true;
            tbVerificationCode.Visible = false;
            lblEndMsg.Visible = false;
            btnBack2.Visible = false;
            btnSubmit.Visible = false;

        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            lblName.Visible = false;
            tbName.Visible = false;
            lblEmail.Visible = false;
            tbEmail.Visible = false;
            lblPassword.Visible = false;
            tbPassword.Visible = false;
            lblRole.Visible = false;
            ddlRole.Visible = false;

            lblQuestion1.Visible = false;
            lblQuestion2.Visible = false;
            lblQuestion3.Visible = false;
            ddlQuestion1.Visible = false;
            ddlQuestion2.Visible = false;
            ddlQuestion3.Visible = false;
            tbQuestion1.Visible = false;
            tbQuestion2.Visible = false;
            tbQuestion3.Visible = false;

            btnSubmit1.Visible = false;
            btnBack1.Visible = false;
            tbVerificationCode.Visible = true;
            lblEndMsg.Visible = true;
            btnBack2.Visible = true;
            btnSubmit.Visible = true;

            var rand = new Random();
            int verificationCode = rand.Next(1000, 9999);    //Creates a random number to be used as the verifaction code

            string strTo = tbEmail.Text;
            string strFrom = "3342Clothing@gmail.com";
            string subjectEmail = "QuickClothes Verification Code";
            string bodyEmail = "The verification code is " + verificationCode + ".";

            // send email with code
        }

    }
}