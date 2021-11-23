using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsAPI.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string ReviewContent { get; set; }
        public int CostRating { get; set; }
        public int QualityRating { get; set; }
        public int ComfortRating { get; set; }
        public int UserID { get; set; }
        public int ClothingID { get; set; }

        public Review() { }


    }
}
