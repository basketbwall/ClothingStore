using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI
{
    public class Order
    {
        public decimal orderTotal { get; set; }
        public DateTime orderDate { get; set; }
        public int refundRequested { get; set; }
        public int userID { get; set; }
        public byte[] orderItems { get; set; }

        public Order()
        {

        }

        public Order(decimal OrderTotal, DateTime OrderDate, int RefundRequested, int UserID, byte[] OrderItems)
        {
            orderTotal = OrderTotal;
            orderDate = OrderDate;
            refundRequested = RefundRequested;
            userID = UserID;
            orderItems = OrderItems;
        }

          
    }
}
