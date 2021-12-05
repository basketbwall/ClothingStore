using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;              // import needed for DataSet and other data classes
using System.Data.SqlClient;    // import needed for ADO.NET classes
using Utilities;                // import needed for DBConnect class
using ReviewsAPI.Models;
namespace ReviewsAPI.Controllers
{
    [Route("api/[controller]")] //api/Reviews
    public class ReviewsController : Controller
    {
        [HttpGet] // api/Reviews
        [HttpGet("GetReviews")]   //api/Reviews/GetReviews
        public List<Review> Get()
        {
            DBConnect DB = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetReviews";
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);
            List<Review> reviews = new List<Review>();
            Review review;

            foreach (DataRow record in myDataSet.Tables[0].Rows)
            {
                review = new Review();
                review.ReviewID = int.Parse(record["reviewID"].ToString());
                review.ReviewContent = record["reviewContent"].ToString();
                review.CostRating = int.Parse(record["costRating"].ToString());
                review.QualityRating = int.Parse(record["qualityRating"].ToString());
                review.ComfortRating = int.Parse(record["comfortRating"].ToString());
                review.UserID = int.Parse(record["userID"].ToString());
                review.ClothingID = int.Parse(record["clothingID"].ToString());

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TP_GetUserByID";
                cmd.Parameters.AddWithValue("@theUserID", review.UserID);
                myDataSet = DB.GetDataSetUsingCmdObj(cmd);

                if (myDataSet.Tables[0].Rows.Count == 0)
                {
                    review.UserName = "";
                }
                else
                {
                    review.UserName = myDataSet.Tables[0].Rows[0]["userName"].ToString();
                }

                reviews.Add(review);
            }
            //access stored procedure to get all cars
            //if there are rows returned convert to array of review objects
            return reviews;
        }
        [HttpGet("{id}")] // api/Reviews/idNumber
        public Review Get(int id)
        {
            DBConnect DB = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetReview";
            cmd.Parameters.AddWithValue("@theReviewID", id);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);
            DataRow record;
            Review review = new Review();
            if (myDataSet.Tables[0].Rows.Count != 0)
            {
                record = myDataSet.Tables[0].Rows[0];
                review.ReviewID = int.Parse(record["reviewID"].ToString());
                review.ReviewContent = record["reviewContent"].ToString();
                review.CostRating = int.Parse(record["costRating"].ToString());
                review.QualityRating = int.Parse(record["qualityRating"].ToString());
                review.ComfortRating = int.Parse(record["comfortRating"].ToString());
                review.UserID = int.Parse(record["userID"].ToString());
                review.ClothingID = int.Parse(record["clothingID"].ToString());
            }
            return review;
        }

        [HttpPost("AddReview")] // POST api/Reviews/AddReview
        public Boolean AddReview([FromBody]Review rev)
        {
            if (rev != null)
            {
                DBConnect DB = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TP_AddReview";
                //	(reviewContent, costRating, qualityrating, comfortRating, userID, clothingID)
                cmd.Parameters.AddWithValue("@theReviewContent", rev.ReviewContent);
                cmd.Parameters.AddWithValue("@theCostRating", rev.CostRating);
                cmd.Parameters.AddWithValue("@theQualityrating", rev.QualityRating);
                cmd.Parameters.AddWithValue("@theComfortRating", rev.ComfortRating);
                cmd.Parameters.AddWithValue("@theUserID", rev.UserID);
                cmd.Parameters.AddWithValue("@theClothingID", rev.ClothingID);
                int retVal = DB.DoUpdateUsingCmdObj(cmd);

                if (retVal > 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        //PUT for updating a review
        //make update review stored procedure
        [HttpPut("UpdateReview")] // POST api/Reviews/UpdateReview
        public Boolean UpdateReview([FromBody] Review rev)
        {
            if (rev != null)
            {
                DBConnect DB = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TP_UpdateReview";

                cmd.Parameters.AddWithValue("@theReviewID", rev.ReviewID);
                cmd.Parameters.AddWithValue("@theReviewContent", rev.ReviewContent);
                cmd.Parameters.AddWithValue("@theCostRating", rev.CostRating);
                cmd.Parameters.AddWithValue("@theQualityrating", rev.QualityRating);
                cmd.Parameters.AddWithValue("@theComfortRating", rev.ComfortRating);
                cmd.Parameters.AddWithValue("@theUserID", rev.UserID);
                cmd.Parameters.AddWithValue("@theClothingID", rev.ClothingID);
                int retVal = DB.DoUpdateUsingCmdObj(cmd);

                if (retVal > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //DELETE for deleting a review
        //make delete review stored procedure
        [HttpDelete("DeleteReview")] // DELETE api/Reviews/DeleteReview
        public Boolean DeleteReview([FromBody] Review rev)
        {
            if (rev != null)
            {
                DBConnect DB = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TP_DeleteReview";
                
                cmd.Parameters.AddWithValue("@theReviewID", rev.ReviewID);

                int retVal = DB.DoUpdateUsingCmdObj(cmd);

                if (retVal > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
