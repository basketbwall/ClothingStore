using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter
using System.IO;                                            //needed for the MemoryStream

namespace Classes
{
    public class StoredProcedures
    {
        DBConnect DB;

        public StoredProcedures()
        {
            DB = new DBConnect();
        }

        //check if user email has an account associated
        public bool UserExists(string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetUser";
            cmd.Parameters.AddWithValue("@theEmail", email);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);

            if (myDataSet.Tables[0].Rows.Count == 0)
            {
                return false;
            } else
            {
                return true;
            }
        }

        //get a random security question given email
        public List<String> GetSecurityQuestion(string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetUser";
            cmd.Parameters.AddWithValue("@theEmail", email);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);

            List<String> output = new List<String>();
            if (myDataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                Random random = new Random();
                int secNumber = random.Next(1, 4);
                string queryRow = "securityQuestion" + secNumber;
                string securityQuestion = myDataSet.Tables[0].Rows[0][queryRow].ToString();

                queryRow = "securityAnswer" + secNumber;
                string securityAnswer = myDataSet.Tables[0].Rows[0][queryRow].ToString();

                output.Add(securityQuestion);
                output.Add(securityAnswer);
                return output;
            }
        }

        public string GetPassword(string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetUser";
            cmd.Parameters.AddWithValue("@theEmail", email);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);

            if (myDataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            } else
            {
                return myDataSet.Tables[0].Rows[0]["userPassword"].ToString();
            }
        }

        public string GetUsername(string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetUser";
            cmd.Parameters.AddWithValue("@theEmail", email);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);

            if (myDataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return myDataSet.Tables[0].Rows[0]["userName"].ToString();
            }
        }

        public string GetUsername(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetUserByID";
            cmd.Parameters.AddWithValue("@theUserID", userid);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);

            if (myDataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return myDataSet.Tables[0].Rows[0]["userName"].ToString();
            }
        }

        //get clothing information
        //write stored procedure for clothing table
        //write clothing class
        public Clothing GetClothingByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetClothingByID";
            cmd.Parameters.AddWithValue("@theClothingID", id);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);

            if (myDataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow record = myDataSet.Tables[0].Rows[0];
                Clothing c = new Clothing();
                c.ClothingID = int.Parse(record["clothingID"].ToString());
                c.ClothingName = record["clothingName"].ToString();
                c.ClothingColor = record["clothingColor"].ToString();
                c.ClothingDescription = record["clothingDescription"].ToString();
                c.ClothingImage = record["clothingImage"].ToString();
                c.SmallStock = int.Parse(record["smallStock"].ToString());
                c.MediumStock = int.Parse(record["MediumStock"].ToString());
                c.LargeStock = int.Parse(record["LargeStock"].ToString());
                c.OnClearance = bool.Parse(record["onClearance"].ToString());
                c.ClearanceDiscountPercent = int.Parse(record["clearanceDiscountPercent"].ToString());
                c.ClothingPrice = decimal.Parse(record["clothingPrice"].ToString());
                c.ClothingBrand = record["clothingBrand"].ToString();

                return c;
            }
        }

        public Review GetUserReview(int userID, int clothingID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetUserReview";
            cmd.Parameters.AddWithValue("@theUserID", userID);
            cmd.Parameters.AddWithValue("@theClothingID", clothingID);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);

            if (myDataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow record = myDataSet.Tables[0].Rows[0];
                Review r = new Review();
                r.QualityRating = int.Parse(record["qualityRating"].ToString());
                r.ComfortRating = int.Parse(record["comfortRating"].ToString());
                r.CostRating = int.Parse(record["costRating"].ToString());
                r.ReviewContent = record["reviewContent"].ToString();
                r.ReviewID = int.Parse(record["reviewID"].ToString());
                r.ClothingID = int.Parse(record["clothingID"].ToString());
                r.UserID = int.Parse(record["userID"].ToString());

                return r;
            }
        }

        //get all users and check for a row with the username and password fields in input
        public Boolean CheckCredentials(string username, string password)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetAllUsers";
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);
            Boolean retVal = false;
            foreach(DataRow record in myDataSet.Tables[0].Rows)
            {
                if (record["userName"].ToString() == username && record["userPassword"].ToString() == password)
                {
                    retVal = true;
                }
            }
            return retVal;
        }

        //return role given username -1 if coudln't find user
        public int GetRoleID(string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetAllUsers";
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);
            int retVal = -1;
            foreach (DataRow record in myDataSet.Tables[0].Rows)
            {
                if (record["userName"].ToString() == username)
                {
                    retVal = int.Parse(record["roleID"].ToString());
                }
            }
            return retVal;
        }

        public int GetUserID(string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetAllUsers";
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);
            int retVal = -1;
            foreach (DataRow record in myDataSet.Tables[0].Rows)
            {
                if (record["userName"].ToString() == username)
                {
                    retVal = int.Parse(record["userID"].ToString());
                }
            }
            return retVal;
        }

        public DataSet GetOrders()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetOrders";
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);

            return myDataSet;
        }
        
        public DataSet RetrieveOrderItems(int orderID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_RetrieveOrderItems";
            cmd.Parameters.AddWithValue("@theOrderID", orderID);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);
            return myDataSet;

        }

        public DataSet GetUserOrders(int userID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetUserOrders";
            cmd.Parameters.AddWithValue("@theUserID", userID);
            DataSet myDataSet = DB.GetDataSetUsingCmdObj(cmd);
            return myDataSet;

        }

        public bool UserBoughtClothing(int userID, int clothingID)
        {
             
            //retreive the info and put in display text
            DataSet orderDataSet = GetUserOrders(userID); 
            //searching through all the users orders and look for clothingID
            //for each row in this dataset, grab the order id and retrieve order items
            foreach (DataRow order in orderDataSet.Tables[0].Rows)
            {
                //get order items using the id
                int orderID = int.Parse(order["orderID"].ToString());
                DataSet orderItems = RetrieveOrderItems(orderID);
                if (orderItems.Tables[0].Rows[0]["orderItems"] != DBNull.Value)
                {
                    Byte[] byteArray = (Byte[])orderItems.Tables[0].Rows[0]["orderItems"];
                    BinaryFormatter deSerializer = new BinaryFormatter();
                    MemoryStream memStream = new MemoryStream(byteArray);
                    List<Classes.Clothing> objOrderItems = (List<Classes.Clothing>)deSerializer.Deserialize(memStream);
                    //loop through the clothing list in objOrderItems for match with parameters
                    foreach (Classes.Clothing clothing in objOrderItems)
                    {
                        if (clothing.ClothingID == clothingID)
                        {
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }

        public bool CheckRefundStatus(int orderID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_CheckRefundStatus";
            cmd.Parameters.AddWithValue("@theOrderID", orderID);

            bool retval = (bool)DB.GetDataSetUsingCmdObj(cmd).Tables[0].Rows[0]["refundRequested"];
            return retval;

        }

        public int RequestRefund(int orderID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_RequestRefund";
            cmd.Parameters.AddWithValue("@theOrderID", orderID);

            int res = DB.DoUpdateUsingCmdObj(cmd);
            return res;
        }

        public DataSet GetRefundRequests()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetRefundRequests";

            return DB.GetDataSetUsingCmdObj(cmd);
        }

        public int ConfirmRefund(int orderID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_ConfirmRefund";
            cmd.Parameters.AddWithValue("@theOrderID", orderID);

            int res = DB.DoUpdateUsingCmdObj(cmd);
            return res;
        }

        public DataSet GetAverages(int clothingID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetAverages";
            cmd.Parameters.AddWithValue("@theClothingID", clothingID);
            return DB.GetDataSetUsingCmdObj(cmd);
        }

        public int AddUser(string userName, string userEmail, string userPassword, decimal totalSpent, int roleID, string question1, string answer1, string question2, string answer2, string question3, string answer3)
        {
            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "TP_AddUser";

            myCommand.Parameters.AddWithValue("@userName", userName);
            myCommand.Parameters.AddWithValue("@userEmail", userEmail);
            myCommand.Parameters.AddWithValue("@userPassword", userPassword);
            myCommand.Parameters.AddWithValue("@totalSpent", totalSpent);
            myCommand.Parameters.AddWithValue("@roleID", roleID);
            myCommand.Parameters.AddWithValue("@securityQuestion1", question1);
            myCommand.Parameters.AddWithValue("@securityAnswer1", answer1);
            myCommand.Parameters.AddWithValue("@securityQuestion2", question2);
            myCommand.Parameters.AddWithValue("@securityAnswer2", answer2);
            myCommand.Parameters.AddWithValue("@securityQuestion3", question3);
            myCommand.Parameters.AddWithValue("@securityAnswer3", answer3);

            DBConnect objDB = new DBConnect();
            return objDB.DoUpdateUsingCmdObj(myCommand);
        }

        public int DeleteClothing(int clothingID)
        {

            DataSet searchDataSet = new DataSet();
            DBConnect objDB = new DBConnect();

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "TP_DeleteClothing";

            myCommand.Parameters.AddWithValue("@clothingID", clothingID);

            return objDB.DoUpdateUsingCmdObj(myCommand);

        }

        public int UpdateClothing(int clothingID, string clothingName, string clothingColor, string clothingDescription, string clothingImage, string smallStock, string medStock, string largeStock, string onClearance, string precentOff, string clothingPrice, string clothingBrand)
        {

            DataSet searchDataSet = new DataSet();
            DBConnect objDB = new DBConnect();

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "TP_UpdateClothing";

            int clearance = 0;

            if (onClearance == "1")
            {
                clearance = 1;
            }


            myCommand.Parameters.AddWithValue("@clothingID", clothingID);
            myCommand.Parameters.AddWithValue("@clothingName", clothingName);
            myCommand.Parameters.AddWithValue("@clothingColor", clothingColor);
            myCommand.Parameters.AddWithValue("@clothingDescription", clothingDescription);
            myCommand.Parameters.AddWithValue("@clothingImage", clothingImage);
            myCommand.Parameters.AddWithValue("@smallStock", Int32.Parse(smallStock));
            myCommand.Parameters.AddWithValue("@mediumStock", Int32.Parse(medStock));
            myCommand.Parameters.AddWithValue("@largeStock", Int32.Parse(largeStock));
            myCommand.Parameters.AddWithValue("@onClearance", clearance);
            myCommand.Parameters.AddWithValue("@clearanceDiscountPercent", Int32.Parse(precentOff));
            myCommand.Parameters.AddWithValue("@clothingPrice", Convert.ToDecimal(clothingPrice));
            myCommand.Parameters.AddWithValue("@clothingBrand", clothingBrand);

            return objDB.DoUpdateUsingCmdObj(myCommand);

        }

        public DataSet GetClothing()
        {
            DataSet searchDataSet = new DataSet();
            DBConnect objDB = new DBConnect();

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "TP_GetClothing";

            return objDB.GetDataSetUsingCmdObj(myCommand);

        }

        public int AddClothing(string clothingName, string clothingColor, string clothingDescription, string clothingImage, string smallStock, string medStock, string largeStock, string onClearance, string precentOff, string clothingPrice, string clothingBrand)
        {

            DataSet searchDataSet = new DataSet();
            DBConnect objDB = new DBConnect();

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "TP_AddClothing";

            Boolean clearance = false;

            if (onClearance == "1")
            {
                clearance = true;
            }

            
            myCommand.Parameters.AddWithValue("@clothingName", clothingName);
            myCommand.Parameters.AddWithValue("@clothingColor", clothingColor);
            myCommand.Parameters.AddWithValue("@clothingDescription", clothingDescription);
            myCommand.Parameters.AddWithValue("@clothingImage", clothingImage);
            myCommand.Parameters.AddWithValue("@smallStock", Int32.Parse(smallStock));
            myCommand.Parameters.AddWithValue("@mediumStock", Int32.Parse(medStock));
            myCommand.Parameters.AddWithValue("@largeStock", Int32.Parse(largeStock));
            myCommand.Parameters.AddWithValue("@onClearance", clearance);
            myCommand.Parameters.AddWithValue("@clearanceDiscountPercent", Int32.Parse(precentOff));
            myCommand.Parameters.AddWithValue("@clothingPrice", Convert.ToDecimal(clothingPrice));
            myCommand.Parameters.AddWithValue("@clothingBrand", clothingBrand);

            return objDB.DoUpdateUsingCmdObj(myCommand);

        }
        
    }
}

