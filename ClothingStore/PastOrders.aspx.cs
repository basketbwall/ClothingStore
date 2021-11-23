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
namespace ClothingStore
{
    public partial class PastOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                int clothingID = 2;
                lvOrders.DataSource = rlist.getReviewByClothingID(clothingID);
                lvOrders.DataBind();
            }
        }

        protected void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCatalog_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalog.aspx");
        }
    }
}