using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace ClothingStore
{
    public partial class Login : System.Web.UI.Page
    {
        StoredProcedures SP;
        protected void Page_Load(object sender, EventArgs e)
        {
            SP = new StoredProcedures();
            //check if cookie is available to fill username
            if (!IsPostBack)
            {
                Session.Add("UserID", null);
                Session.Add("SecurityAnswer", null);
                Session.Add("Role", null);
                if (Request.Cookies["LoginCookie"] != null)
                {
                    txtUsername.Text = Request.Cookies["LoginCookie"].Values["Username"].ToString();
                    chkSaveUsername.Checked = true;
                }

            }
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            securityQuestion.Visible = false;
            recoveryOptions.Visible = false;
            divRecovery.Visible = true;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //check if checkbox is checked to save in cookie
            if(chkSaveUsername.Checked)
            {
                HttpCookie myCookie = new HttpCookie("LoginCookie");
                myCookie.Values["Username"] = txtUsername.Text;
                myCookie.Expires = new DateTime(2025, 1, 1);

                Response.Cookies.Add(myCookie);
            } else
            {
                if (Request.Cookies["LoginCookie"] != null)
                {
                    Response.Cookies["LoginCookie"].Expires = DateTime.Now;
                }
            }

            //check if username and password checks out, call method from storedprocedure class
            if (SP.CheckCredentials(txtUsername.Text, txtPassword.Text))
            {
                // set Session["UserID"];
                Session["UserID"] = SP.GetUserID(txtUsername.Text);
                //set Role in session and continue to the next page
                int roleID = SP.GetRoleID(txtUsername.Text);
                if (roleID != -1)
                {
                    if (roleID == 1)
                    {
                        Session["Role"] = "RewardsCustomer";
                    } else
                    {
                        Session["Role"] = "Administrator";
                    }
                    Response.Redirect("Catalog.aspx");
                }
                //call SP functin to get the role given username and password
            }
            else
            {
                lblLogin.Text = "Incorrect username and password combination";
            }
        }

        protected void btnUsername_Click(object sender, EventArgs e)
        {
            securityQuestion.Visible = false;
            recoveryOptions.Visible = false;
            divRecovery.Visible = true;
        }

        protected void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            //if email exists find security question and set visible
                //select statement for finding user with email
                //select statement for finding all security questions, randomly choose 1 to display
            if(SP.UserExists(email))
            {
                List<String> QA = SP.GetSecurityQuestion(txtEmail.Text);
                Session["SecurityAnswer"] = QA[1];
                lblSecurityQuestion.Text = QA[0];
                divRecovery.Visible = false;
                securityQuestion.Visible = true;
            }
        }

        protected void btnAnswerSecurity_Click(object sender, EventArgs e)
        {
            //if answer is correct display buttons to recover password and username

            if (txtSecurityAnswer.Text == Session["SecurityAnswer"].ToString())
            {
                securityQuestion.Visible = false;
                recoveryOptions.Visible = true;
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Session["UserID"] = 0;
            Session["Role"] = "Visitor";
            Response.Redirect("Catalog.aspx");

        }

        protected void btnRecoverUsername_Click1(object sender, EventArgs e)
        {
            //construct email using email class
            //inside email message send username
            //query for username from storedprocedure
            //construct email using email class
            //inside email message send password
            //query for password from storedprocedure
            //Email email = new Email();
            String strTO = txtEmail.Text;
            String strFROM = "3342Clothing@gmail.com";
            String strSubject = "Username Recovery";
            String strMessage = "Username: " + SP.GetUsername(txtEmail.Text);

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(strFROM, "clothing123!");
            smtp.Timeout = 20000;

            try
            {
                //email.SendMail(strTO, strFROM, strSubject, strMessage);
                MailMessage message = new MailMessage(strFROM, strTO);
                message.Subject = strSubject;
                message.Body = strMessage;
                smtp.Send(message);
                lblEmailDisplay.Text = "Email was sent";
            }
            catch (Exception ex)
            {
                lblEmailDisplay.Text = "Error: " + ex.Message;

            }
        }

        protected void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            //construct email using email class
            //inside email message send password
            //query for password from storedprocedure
            //Email email = new Email();
            String strTO = txtEmail.Text;
            String strFROM = "3342Clothing@gmail.com";
            String strSubject = "Password Recovery";
            String strMessage = "Password: " + SP.GetPassword(txtEmail.Text);

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(strFROM, "clothing123!");
            smtp.Timeout = 20000;

            try
            {
                //email.SendMail(strTO, strFROM, strSubject, strMessage);
                MailMessage message = new MailMessage(strFROM, strTO);
                message.Subject = strSubject;
                message.Body = strMessage;
                smtp.Send(message);
                lblEmailDisplay.Text = "Email was sent";
            }
            catch (Exception ex)
            {
                lblEmailDisplay.Text = "Error: " + ex.Message;

            }
        }
    }
}