using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization; //JSON serializers
using System.IO; //Stream and StreamReader
using System.Net; //needed for web request
using Classes; //needed for review class
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace ClothingStore
{
    public partial class Clothing : System.Web.UI.Page
    {
        StoredProcedures SP = new StoredProcedures();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check role and update label on top right and set visibility of buttons
                if (Session["Role"].ToString() == "RewardsCustomer")
                {
                    navPurchaseHistory.Visible = true;
                    navCheckoutPage.Visible = true;
                    shoppingOptions.Visible = true;
                    lblUser.Text = "Hello " + "Rewards Customer";
                    navSignOut.Visible = true;
                    //if they already have a review for this clothing, then only show edit otherwise show the write review
                    WebRequest request = WebRequest.Create("https://localhost:44385/api/Reviews/GetReviews");
                    WebResponse response = request.GetResponse();

                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Review[] reviews = js.Deserialize<Review[]>(data);
                    ReviewList rlist = new ReviewList(reviews); //create reviewlist
                    if (rlist.HasUserReviewed(int.Parse(Session["UserID"].ToString()))) {
                        btnMyReview.Visible = true;
                    } else
                    {
                        btnAddReview.Visible = true;
                    }

                }
                else if (Session["Role"].ToString() == "Administrator")
                {
                    navManageRefunds.Visible = true;
                    lblUser.Text = "Hello " + "Administrator";
                    navSignOut.Visible = true;
                    btnManage.Visible = true;
                }
                else
                {
                    //visitor
                    navCheckoutPage.Visible = true;
                    lblUser.Text = "Hello " + "Visitor";
                    navSignIn.Visible = true;
                    shoppingOptions.Visible = true;
                }

                Session.Add("ReviewOperation", null);
                //use stored procedure to grab clothing info and populate the labels and image fields on page
                Classes.Clothing c = SP.GetClothingByID(int.Parse(Request.QueryString["ClothingID"].ToString()));
                lblName.Text = lblName.Text + c.ClothingName;
                lblColor.Text = lblColor.Text + c.ClothingColor;
                lblDescription.Text = lblDescription.Text + c.ClothingDescription;
                lblPrice.Text = lblPrice.Text + c.ClothingPrice;
                lblBrand.Text = lblBrand.Text + c.ClothingBrand;
                clothingImage.ImageUrl = c.ClothingImage;


            }
        }

        protected void btnEditReview_Click(object sender, EventArgs e)
        {
            allreviews.Visible = false;
            writereview.Visible = true;
            btnDelete.Visible = true;
            Session["ReviewOperation"] = "Update";
            //load review information from storedprocedure into the fields
            Review r = SP.GetUserReview(int.Parse(Session["UserID"].ToString()), int.Parse(Request.QueryString["ClothingID"].ToString()));
            if (r != null)
            {
                txtReviewContent.Text = r.ReviewContent;
                ddlComfort.SelectedValue = r.ComfortRating.ToString();
                ddlCost.SelectedValue = r.CostRating.ToString();
                ddlQuality.SelectedValue = r.QualityRating.ToString();
            }

        }



        protected void btnLoadReview_Click(object sender, EventArgs e)
        {
            writereview.Visible = false;
            allreviews.Visible = true;

            WebRequest request = WebRequest.Create("https://localhost:44385/api/Reviews/GetReviews");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Review[] reviews = js.Deserialize<Review[]>(data);
            ReviewList rlist = new ReviewList(reviews); //create reviewlist
            int clothingID = int.Parse(Request.QueryString["ClothingID"].ToString());
            lvReviews.DataSource = rlist.getReviewByClothingID(clothingID);
            lvReviews.DataBind();
        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {
            allreviews.Visible = false;
            writereview.Visible = true;
            //clear fields
            txtReviewContent.Text = "";
            ddlComfort.SelectedValue = "1";
            ddlCost.SelectedValue = "1";
            ddlQuality.SelectedValue = "1";
            Session["ReviewOperation"] = "Add";
        }

        protected void btnSubmitReview_Click(object sender, EventArgs e)
        {
            if (Session["ReviewOperation"].ToString() == "Add")
            {
                //figure out how to send a Review class through the body to use POST web api method
                //api/Reviews/AddReview
                Review r = new Review();
                r.ClothingID = int.Parse(Request.QueryString["ClothingID"].ToString());
                r.ComfortRating = int.Parse(ddlComfort.SelectedValue);
                r.CostRating = int.Parse(ddlCost.SelectedValue);
                r.QualityRating = int.Parse(ddlQuality.SelectedValue);
                r.ReviewContent = txtReviewContent.Text;
                r.UserID = (int)Session["UserID"];

                //serialize Review into JSON string
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonReview = js.Serialize(r);

                try
                {
                    WebRequest request = WebRequest.Create("https://localhost:44385/api/Reviews/AddReview");
                    request.Method = "POST";
                    request.ContentLength = jsonReview.Length;
                    request.ContentType = "application/json";

                    //write the JSON data to the web request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonReview);
                    writer.Flush();
                    writer.Close();

                    //read data from response

                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    string data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    if (data == "true")
                    {
                        lblSubmitReviewDisplay.Text = "Review was successfully saved to the database";
                        //hide write review button and show edit review
                        btnAddReview.Visible = false;
                        btnMyReview.Visible = true;
                    }
                    else
                    {
                        lblSubmitReviewDisplay.Text = "A problem occurred while adding the review to the database. the data wasn't recorded.";
                    }
                }
                catch (Exception ex)
                {
                    lblSubmitReviewDisplay.Text = "Error: " + ex.Message;
                }
            } else
            {
                Review r = SP.GetUserReview(int.Parse(Session["UserID"].ToString()), int.Parse(Request.QueryString["ClothingID"].ToString()));
                if (r != null)
                {
                    r.ReviewContent = txtReviewContent.Text;
                    r.ComfortRating = int.Parse(ddlComfort.SelectedValue.ToString());
                    r.CostRating = int.Parse(ddlCost.SelectedValue.ToString());
                    r.QualityRating = int.Parse(ddlQuality.SelectedValue.ToString());
                }


                //serialize Review into JSON string
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonReview = js.Serialize(r);

                try
                {
                    WebRequest request = WebRequest.Create("https://localhost:44385/api/Reviews/UpdateReview");
                    request.Method = "PUT";
                    request.ContentLength = jsonReview.Length;
                    request.ContentType = "application/json";

                    //write the JSON data to the web request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonReview);
                    writer.Flush();
                    writer.Close();

                    //read data from response

                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    string data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    if (data == "true")
                    {
                        lblSubmitReviewDisplay.Text = "Review was successfully saved to the database";
                    }
                    else
                    {
                        lblSubmitReviewDisplay.Text = "A problem occurred while adding the review to the database. the data wasn't recorded.";
                    }
                }
                catch (Exception ex)
                {
                    lblSubmitReviewDisplay.Text = "Error: " + ex.Message;
                }
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Review r = SP.GetUserReview(int.Parse(Session["UserID"].ToString()), int.Parse(Request.QueryString["ClothingID"].ToString()));
            //delete the review using review passed through body http DELETE method
            //// DELETE api/Reviews/DeleteReview
            //serialize Review into JSON string
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonReview = js.Serialize(r);

            try
            {
                WebRequest request = WebRequest.Create("https://localhost:44385/api/Reviews/DeleteReview");
                request.Method = "DELETE";
                request.ContentLength = jsonReview.Length;
                request.ContentType = "application/json";

                //write the JSON data to the web request
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonReview);
                writer.Flush();
                writer.Close();

                //read data from response

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                string data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "true")
                {
                    lblSubmitReviewDisplay.Text = "Review was successfully removed from the database";
                    btnDelete.Visible = false;
                    writereview.Visible = false;
                    btnMyReview.Visible = false;
                    btnAddReview.Visible = true;
                }
                else
                {
                    lblSubmitReviewDisplay.Text = "A problem occurred while removing the review to the database. the data wasn't updated.";
                }
            }
            catch (Exception ex)
            {
                lblSubmitReviewDisplay.Text = "Error: " + ex.Message;
            }
        }

        protected void btnManage_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Classes.Clothing clothing = SP.GetClothingByID(int.Parse(Request.QueryString["ClothingID"].ToString()));
            string size = SizePicker.CurrentSize;
            clothing.ClothingSize = size;
            int quantity = QuantityPicker.CurrentQuantity;
            clothing.ClothingQuantity = quantity;

            //check if there is enough quantity in that size before adding to the cart
            if (size == "")
            {
                lblPurchaseWarning.Text = "Items were not added to your cart. Please choose a size";
                return;
            }
            if(size == "Small")
            {
                if(quantity > clothing.SmallStock)
                {
                    lblPurchaseWarning.Text = "Items were not added to your cart. There are only " + clothing.SmallStock + " smalls left";
                    return;
                }
            }
            if (size == "Medium")
            {
                if (quantity > clothing.MediumStock)
                {
                    lblPurchaseWarning.Text = "Items were not added to your cart. There are only " + clothing.MediumStock + " mediums left";
                    return;
                }
            }
            if (size == "Large")
            {
                if (quantity > clothing.LargeStock)
                {
                    lblPurchaseWarning.Text = "Items were not added to your cart. There are only " + clothing.LargeStock + " larges left";
                    return;
                }
            }

            //instantiate arraylist of cart items from session if null
            List<Classes.Clothing> Cart;

            if (Session["Cart"] == null)
            {
                Cart = new List<Classes.Clothing>();
            } else
            {
                Cart = (List<Classes.Clothing>)Session["Cart"]; //instantiate using previous cart info
            }
            bool addedFlag = false;
            //search for existing order item that has the same clothing in the same size, just increment the quantity for that  if possible
            foreach(Classes.Clothing o in Cart)
            {
                if (o.ClothingID == clothing.ClothingID && o.ClothingSize == size)
                {
                    o.ClothingQuantity += quantity;
                    addedFlag = true;
                }
            }

            if (addedFlag == false)
            {
                //create cart item with clothing
                Cart.Add(clothing);
            }


            //save into session
            Session["Cart"] = Cart;
            lblPurchaseWarning.Text = "Items were successfully added to your cart";



        }
    }
}