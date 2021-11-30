using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

using Classes;
using Utilities;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace ClothingStore
{
    public partial class Registration : System.Web.UI.Page
    {

        int verificationCode;

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = tbName.Text;
            string userEmail = tbEmail.Text;
            string userPassword = tbPassword.Text;
            decimal totalSpent = 0.00m;
            string role = ddlRole.SelectedValue;       //roleID
            string question1 = ddlQuestion1.SelectedValue;
            string answer1 = tbQuestion1.Text;
            string question2 = ddlQuestion2.SelectedValue;
            string answer2 = tbQuestion2.Text;
            string question3 = ddlQuestion3.SelectedValue;
            string answer3 = tbQuestion3.Text;

            StoredProcedures store = new StoredProcedures();
            int roleID = 2;
            string ver = (string)(Session["ver"]);

            if (role == "Rewards Member")
            {
               roleID = 1;
            }
                

            if (tbVerificationCode.Text == ver)
            {
                // stored procedure to add the user into the database
                store.AddUser(userName, userEmail, userPassword, totalSpent, roleID, question1, answer1, question2, answer2, question3, answer3);
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnBack1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");    
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbEmail.Text != "" && tbPassword.Text != "" && tbQuestion1.Text != "" && tbQuestion2.Text != "" && tbQuestion3.Text != "")
            {

                btnSubmit1.Visible = false;
                btnBack1.Visible = false;
                tbVerificationCode.Visible = true;
                lblEndMsg.Visible = true;
                btnBack2.Visible = true;
                btnSubmit.Visible = true;
                lblWarning.Visible = true;
                btnResend.Visible = true;

                var rand = new Random();
                verificationCode = rand.Next(1000, 9999);    //Creates a random number to be used as the verifaction code

                Session["ver"] = verificationCode.ToString();

                string strTo = tbEmail.Text;
                string strFrom = "3342Clothing@gmail.com";
                string subjectEmail = "QuickClothes Verification Code";
                string bodyEmail = tbName.Text + " thanks for signing up. The verification code is " + verificationCode + ".";

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(strFrom, "clothing123!");
                smtp.Timeout = 20000;

                try
                {
                    //email.SendMail(strTO, strFROM, strSubject, strMessage);
                    MailMessage message = new MailMessage(strFrom, strTo);
                    message.Subject = subjectEmail;
                    message.Body = bodyEmail;
                    smtp.Send(message);
                    lblWarning.Text = "Email was sent";
                }
                catch (Exception ex)
                {
                    lblWarning.Text = "Error: " + ex.Message;

                }
            }
            else
            {
                Response.Write("Please make sure that all information was filled out below");
            }
        }

        protected void btnResend_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbEmail.Text != "" && tbPassword.Text != "" && tbQuestion1.Text != "" && tbQuestion2.Text != "" && tbQuestion3.Text != "")
            {

            var rand = new Random();
            verificationCode = rand.Next(1000, 9999);    //Creates a random number to be used as the verifaction code

            Session["ver"] = verificationCode.ToString();

            string strTo = tbEmail.Text;
            string strFrom = "3342Clothing@gmail.com";
            string subjectEmail = "QuickClothes Verification Code";
            string bodyEmail = tbName.Text + " thanks for signing up. The verification code is " + verificationCode + ".";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(strFrom, "clothing123!");
            smtp.Timeout = 20000;

            try
            {
                //email.SendMail(strTO, strFROM, strSubject, strMessage);
                MailMessage message = new MailMessage(strFrom, strTo);
                message.Subject = subjectEmail;
                message.Body = bodyEmail;
                smtp.Send(message);
                lblWarning.Text = "Email was sent";
            }
            catch (Exception ex)
            {
                lblWarning.Text = "Error: " + ex.Message;

            }
        }
            else
            {
                Response.Write("Please make sure that all information was filled out below");
            }
}
    }
}