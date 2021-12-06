using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace CheckoutAPI
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
        public bool Storing(byte[] orderList,)
        {
            DataSet searchDataSet = new DataSet();
            DBConnect objDB = new DBConnect();

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "TP_AddOrder";

            myCommand.Parameters.AddWithValue("@orderTotal", orderTotal);
            myCommand.Parameters.AddWithValue("@orderDate", orderDate);
            myCommand.Parameters.AddWithValue("@refundRequested", refundRequested);
            myCommand.Parameters.AddWithValue("@userID", Int32.Parse(userID));
            myCommand.Parameters.AddWithValue("@orderItems", Int32.Parse(orderItems));

            return objDB.DoUpdateUsingCmdObj(myCommand);

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

    }
}
