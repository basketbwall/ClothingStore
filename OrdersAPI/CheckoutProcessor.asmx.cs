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
        public decimal TotalCaluator(decimal discountPrecent, decimal price, int quantity) //Calculates 
        {
            decimal finalPrice = 0.00m;
            decimal precent = (100m - discountPrecent) / 100m;
            finalPrice += (price * precent) * quantity;

            return finalPrice;
        }

        [WebMethod]
        public int StockReturn(int clothingID, int stockPurchased, string stockSize) //
        {
            int currentStock = 0;
            int smallStock = 0;
            int mediumStock = 0;
            int largeStock = 0;

            DataSet searchDataSet = new DataSet();
            DBConnect objDB = new DBConnect();
            SqlCommand myCommand = new SqlCommand();
            

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "TP_GetClothingByID";

            myCommand.Parameters.AddWithValue("@theClothingID", clothingID);

            searchDataSet = objDB.GetDataSetUsingCmdObj(myCommand);

            
                DataRow record = searchDataSet.Tables[0].Rows[0];
            
            DBConnect objDB2 = new DBConnect();
            SqlCommand myCommand2 = new SqlCommand();


            if (stockSize == "Small")
            {
                currentStock = int.Parse(record["smallStock"].ToString());
                mediumStock = int.Parse(record["MediumStock"].ToString());
                largeStock = int.Parse(record["LargeStock"].ToString());

                currentStock = currentStock - stockPurchased;

                myCommand2.CommandType = CommandType.StoredProcedure;
                myCommand2.CommandText = "TP_UpdateStock";

                myCommand2.Parameters.AddWithValue("@clothingID", clothingID);
                myCommand2.Parameters.AddWithValue("@smallStock", currentStock);
                myCommand2.Parameters.AddWithValue("@mediumStock", mediumStock);
                myCommand2.Parameters.AddWithValue("@largeStock", largeStock);

                return objDB2.DoUpdateUsingCmdObj(myCommand2);

            }
            else if (stockSize == "Medium")
            {
                smallStock = int.Parse(record["smallStock"].ToString());
                currentStock = int.Parse(record["MediumStock"].ToString());
                largeStock = int.Parse(record["LargeStock"].ToString());

                currentStock = currentStock - stockPurchased;

                myCommand2.CommandType = CommandType.StoredProcedure;
                myCommand2.CommandText = "TP_UpdateStock";

                myCommand2.Parameters.AddWithValue("@clothingID", clothingID);
                myCommand2.Parameters.AddWithValue("@smallStock", smallStock);
                myCommand2.Parameters.AddWithValue("@mediumStock", currentStock);
                myCommand2.Parameters.AddWithValue("@largeStock", largeStock);

                return objDB2.DoUpdateUsingCmdObj(myCommand2);

            }
            else
            {
                smallStock = int.Parse(record["smallStock"].ToString());
                mediumStock = int.Parse(record["MediumStock"].ToString());
                currentStock = int.Parse(record["LargeStock"].ToString());

                currentStock = currentStock - stockPurchased;

                myCommand2.CommandType = CommandType.StoredProcedure;
                myCommand2.CommandText = "TP_UpdateStock";

                myCommand2.Parameters.AddWithValue("@clothingID", clothingID);
                myCommand2.Parameters.AddWithValue("@smallStock", smallStock);
                myCommand2.Parameters.AddWithValue("@mediumStock", mediumStock);
                myCommand2.Parameters.AddWithValue("@largeStock", currentStock);

                return objDB2.DoUpdateUsingCmdObj(myCommand2);
            }
            
        }

        [WebMethod]
        public int MaxStock(int clothingID, string stockSize) //
        {
            int currentStock = 0;

            DataSet searchDataSet = new DataSet();
            DBConnect objDB = new DBConnect();
            SqlCommand myCommand = new SqlCommand();


            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "TP_GetClothingByID";

            myCommand.Parameters.AddWithValue("@theClothingID", clothingID);

            searchDataSet = objDB.GetDataSetUsingCmdObj(myCommand);


            DataRow record = searchDataSet.Tables[0].Rows[0];

            DBConnect objDB2 = new DBConnect();
            SqlCommand myCommand2 = new SqlCommand();


            if (stockSize == "Small")
            {
                currentStock = int.Parse(record["smallStock"].ToString());
                return currentStock;

            }
            else if (stockSize == "Medium")
            {
                currentStock = int.Parse(record["MediumStock"].ToString());
                return currentStock;
            }
            else
            {
                currentStock = int.Parse(record["LargeStock"].ToString());
                return currentStock;
            }

        }
    }
}
