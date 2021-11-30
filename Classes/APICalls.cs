using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net; //needed for web request
using Classes; //needed for review class
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Web.Script.Serialization; //JSON serializers

namespace Classes
{
    public class APICalls
    {
        public APICalls() { }

        public bool UserWroteReview(int UserID, int ClothingID)
        {
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

            return rlist.HasUserReviewed(UserID, ClothingID);
        }

        public List<Classes.Review> GetClothingReviews(int ClothingID)
        {
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
            return rlist.getReviewByClothingID(ClothingID);
        }

        public int AddReview(Review r)
        {
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
                    return 1;
                } else
                {
                    return -1;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int UpdateReview(Review r)
        {
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
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DeleteReview(Review r)
        {
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
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
