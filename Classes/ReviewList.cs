using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ReviewList
    {
        public List<Review> reviews {get; set;}
        
        public ReviewList(Review[] input)
        {
            reviews = new List<Review>();
            foreach (Review r in input)
            {
                reviews.Add(r);
            }
        }

        //get reviews for clothing ID
        public List<Review> getReviewByClothingID(int id)
        {
            List<Review> output = new List<Review>();
            foreach(Review r in reviews)
            {
                if (r.ClothingID == id)
                {
                    output.Add(r);
                }
            }
            return output;
        }
    }
}
