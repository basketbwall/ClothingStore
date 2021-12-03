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
        public bool Storing(byte[] orderList, int orderID)
        {
            DBConnect DB = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_StoreOrderItems";
            cmd.Parameters.AddWithValue("@theOrderID", orderID);
            cmd.Parameters.AddWithValue("@theOrderItems", orderList);
            int retVal = DB.DoUpdateUsingCmdObj(cmd);

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
