using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Order
    {
        int orderID { get; set; }
        decimal orderTotal { get; set; }
        DateTime orderDate { get; set; }
        int refundRequested { get; set; }
        int userID { get; set; }
        byte[] orderItems { get; set; }
        
        public Order()
        {

        }
           
    }
}
