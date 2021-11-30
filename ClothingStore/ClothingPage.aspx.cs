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
        APICalls APIMethods = new APICalls();
        Navbar ctrl;
        protected void Page_Init(object sender, EventArgs e)
        {
            //check role and update label on top right and set visibility of buttons
            ctrl = (Navbar)LoadControl("Navbar.ascx");
            Form.Controls.AddAt(0, ctrl);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                //check role and update label on top right and set visibility of buttons
                if (Session["Role"].ToString() == "RewardsCustomer")
                {

                    shoppingOptions.Visible = true;
                    //check if user has even bought this using storedprocedure to look at users orders, look inside each orderitems list to find a clothing id match
                    //check if the user has reviewed this already
                    int userID = int.Parse(Session["UserID"].ToString());
                    int clothingID = int.Parse(Request.QueryString["ClothingID"].ToString());
                    
                    if (APIMethods.UserWroteReview(userID, clothingID))
                    {
                        btnMyReview.Visible = true;
                    }
                    else
                    {
                        btnAddReview.Visible = true;
                    }
                }
                else if (Session["Role"].ToString() == "Administrator")
                {
                    btnManage.Visible = true;

                }
                else
                {
                    //visitor

                    shoppingOptions.Visible = true;
                }

                Session.Add("ReviewOperation", null);
                //update labels
                displayClothingInfo();
            }
        }
        protected void displayClothingInfo()
        {
            //use stored procedure to grab clothing info and populate the labels and image fields on page
            Classes.Clothing c = SP.GetClothingByID(int.Parse(Request.QueryString["ClothingID"].ToString()));
            lblName.Text = lblName.Text + c.ClothingName;
            lblColor.Text = lblColor.Text + c.ClothingColor;
            lblDescription.Text = lblDescription.Text + c.ClothingDescription;
            lblPrice.Text = lblPrice.Text + c.ClothingPrice;
            lblBrand.Text = lblBrand.Text + c.ClothingBrand;
            clothingImage.ImageUrl = c.ClothingImage;
            DataSet avgReviews = SP.GetAverages(c.ClothingID);
            lblComfortAv.Text = avgReviews.Tables[0].Rows[0]["comfortRating"].ToString();
            lblQualityAv.Text = avgReviews.Tables[0].Rows[0]["qualityRating"].ToString();
            lblCostAv.Text = avgReviews.Tables[0].Rows[0]["costRating"].ToString();
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
            int clothingID = int.Parse(Request.QueryString["ClothingID"].ToString());
            lvReviews.DataSource = APIMethods.GetClothingReviews(clothingID);
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
            if (txtReviewContent.Text == "")
            {
                reviewContentValidator.Visible = true;
                return;
            } else
            {
                reviewContentValidator.Visible = false;
            }

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

                //add review
                if (APIMethods.AddReview(r) == 1)
                {
                    lblSubmitReviewDisplay.Text = "Review was successfully saved to the database";
                    int clothingID = int.Parse(Request.QueryString["ClothingID"].ToString());
                    lvReviews.DataSource = APIMethods.GetClothingReviews(clothingID);
                    lvReviews.DataBind();
                    //hide write review button and show edit review
                    btnAddReview.Visible = false;
                    btnMyReview.Visible = true;
                    displayClothingInfo();
                    //forcing postback for the stars to update without breaking the ajax
                    forceReload();

                }
                else
                {
                    lblSubmitReviewDisplay.Text = "A problem occurred while adding the review to the database. the data wasn't recorded.";
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

                //update review
                if (APIMethods.UpdateReview(r) == 1)
                {
                    lblSubmitReviewDisplay.Text = "Review was successfully saved to the database";
                    int clothingID = int.Parse(Request.QueryString["ClothingID"].ToString());
                    lvReviews.DataSource = APIMethods.GetClothingReviews(clothingID);
                    lvReviews.DataBind();
                    displayClothingInfo();
                    //forcing postback for the stars to update without breaking the ajax
                    forceReload();
                } else
                {
                    lblSubmitReviewDisplay.Text = "A problem occurred while adding the review to the database. the data wasn't recorded.";
                }

            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Review r = SP.GetUserReview(int.Parse(Session["UserID"].ToString()), int.Parse(Request.QueryString["ClothingID"].ToString()));
            //delete the review using review passed through body http DELETE method
            //// DELETE api/Reviews/DeleteReview
            //serialize Review into JSON string
            if (APIMethods.DeleteReview(r) == 1)
            {
                lblSubmitReviewDisplay.Text = "Review was successfully removed from the database";
                btnDelete.Visible = false;
                writereview.Visible = false;
                btnMyReview.Visible = false;
                btnAddReview.Visible = true;
                int clothingID = int.Parse(Request.QueryString["ClothingID"].ToString());
                lvReviews.DataSource = APIMethods.GetClothingReviews(clothingID);
                lvReviews.DataBind();
                displayClothingInfo();
                forceReload();
            } else
            {
                lblSubmitReviewDisplay.Text = "A problem occurred while removing the review to the database. the data wasn't updated.";
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
            if (size == "Small")
            {
                if (quantity > clothing.SmallStock)
                {
                    lblPurchaseWarning.Text = "Items not added to cart. There is not enough stock to add your specified quantity.";
                    return;
                }
            }
            if (size == "Medium")
            {
                if (quantity > clothing.MediumStock)
                {
                    lblPurchaseWarning.Text = "Items not added to cart. There is not enough stock to add your specified quantity.";
                    return;
                }
            }
            if (size == "Large")
            {
                if (quantity > clothing.LargeStock)
                {
                    lblPurchaseWarning.Text = "Items not added to cart. There is not enough stock to add your specified quantity.";
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
            bool alreadyInCart = false;
            //search for existing order item that has the same clothing in the same size, just increment the quantity for that  if possible
            foreach(Classes.Clothing o in Cart)
            {
                if (o.ClothingID == clothing.ClothingID && o.ClothingSize == size)
                {
                    alreadyInCart = true;
                    //check if quantity will go over the stock
                    if (size == "Small")
                    {
                        if (o.SmallStock >= o.ClothingQuantity + quantity)
                        {
                            o.ClothingQuantity += quantity;
                            addedFlag = true;
                            lblPurchaseWarning.Text = "Items were successfully added to your cart";
                        }
                        else
                        {
                            lblPurchaseWarning.Text = "Items not added to cart. There is not enough stock to add your specified quantity.";
                        }
                    } else if (size == "Medium")
                    {
                        if (o.MediumStock >= o.ClothingQuantity + quantity)
                        {
                            o.ClothingQuantity += quantity;
                            addedFlag = true;
                            lblPurchaseWarning.Text = "Items were successfully added to your cart";
                        }
                        else
                        {
                            lblPurchaseWarning.Text = "Items not added to cart. There is not enough stock to add your specified quantity.";
                        }
                    }
                    else if (size == "Large")
                    {
                        if (o.LargeStock >= o.ClothingQuantity + quantity)
                        {
                            o.ClothingQuantity += quantity;
                            addedFlag = true;
                            lblPurchaseWarning.Text = "Items were successfully added to your cart";
                        }
                        else
                        {
                            lblPurchaseWarning.Text = "Items not added to cart. There is not enough stock to add your specified quantity.";
                        }
                    }

                }
            }

            if (addedFlag == false && alreadyInCart == false)
            {
                //create cart item with clothing
                //do the same check at this stage to check
                Cart.Add(clothing);
                lblPurchaseWarning.Text = "Items were successfully added to your cart";
            }


            //save into session
            Session["Cart"] = Cart;

            ctrl.UpdateCart();
            //forcing postback for the cart numbers to update without breaking the ajax
            forceReload();


        }

        public void forceReload()
        {
            //forcing postback for certain items
            int id = int.Parse(Request.QueryString["ClothingID"].ToString());
            Response.Redirect("ClothingPage.aspx" + "?ClothingID=" + id);
        }
    }
}