using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

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
                c.ClearanceDiscountPercent = decimal.Parse(record["clearanceDiscountPercent"].ToString());
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
    }
}
