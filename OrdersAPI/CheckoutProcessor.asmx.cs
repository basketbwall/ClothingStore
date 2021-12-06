using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace OrdersAPI
{
    /// <summary>
    /// Summary description for CheckoutProcessor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CheckoutProcessor : System.Web.Services.WebService
    {
        [WebMethod]
        public bool Storing(Order currentOrder)
        {
            DataSet searchDataSet = new DataSet();
            DBConnect objDB = new DBConnect();

            SqlCommand myCommand = new SqlCommand();

            decimal orderTotal = currentOrder.orderTotal;
            DateTime orderDate = currentOrder.orderDate;
            int refundRequested = currentOrder.refundRequested;
            int userID = currentOrder.userID;
            byte[] orderItems = currentOrder.orderItems;

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "TP_AddOrder";

            myCommand.Parameters.AddWithValue("@orderTotal", orderTotal);
            myCommand.Parameters.AddWithValue("@orderDate", orderDate);
            myCommand.Parameters.AddWithValue("@refundRequested", refundRequested);
            myCommand.Parameters.AddWithValue("@userID", userID);
            myCommand.Parameters.AddWithValue("@orderItems", orderItems);

            int retVal = objDB.DoUpdateUsingCmdObj(myCommand);

            //Check to see whether the update was successful

            if (retVal == -1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        [WebMethod]
        public decimal TotalCaluator(decimal discountPrecent, decimal price, int quantity)
        {
            decimal finalPrice = 0.00m;
            decimal precent = (100m - discountPrecent) / 100m;
            finalPrice += (price * precent) * quantity;

            return finalPrice;
        }

    }
}
