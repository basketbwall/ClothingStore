using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI
{
    [Serializable]
    public class Clothing
    {
        public int ClothingID { get; set; }
        public string ClothingName { get; set; }
        public string ClothingColor { get; set; }
        public string ClothingDescription { get; set; }
        public string ClothingImage { get; set; }
        public int SmallStock { get; set; }
        public int MediumStock { get; set; }
        public int LargeStock { get; set; }
        public bool OnClearance { get; set; }
        public int ClearanceDiscountPercent { get; set; }
        public decimal ClothingPrice { get; set; }
        public string ClothingBrand { get; set; }
        public String ClothingSize { get; set; }
        public int ClothingQuantity { get; set; }

        public Clothing() { }

        //public GetAverageRating() { }

        //public GetAveragePriceRating() { }

        //public GetAverageComfortRating() { }

        //public GetAverageQualityRating() { }
    }
}
