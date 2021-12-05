using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.IO; //Stream and StreamReader
using System.Net; //needed for web request
using Classes;
using Utilities;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace ClothingStore
{
    public partial class Catalog : System.Web.UI.Page
    {
        ArrayList mainClothes = new ArrayList();

        protected void Page_Init(object sender, EventArgs e)
        {
            //check role and update label on top right and set visibility of buttons
            Navbar ctrl = (Navbar)LoadControl("Navbar.ascx");
            Form.Controls.AddAt(0, ctrl);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Role"].ToString() == "RewardsCustomer")
                {
                }
                else if (Session["Role"].ToString() == "Administrator")
                {
                    addClothes.Visible = true;

                }
                else
                {
                    //visitor

                }

                DataSet Clothes = new DataSet();
                StoredProcedures StoredProc = new StoredProcedures();
                ArrayList mainClothes = new ArrayList();

                ArrayList clearance = new ArrayList();
                Classes.Clothing objClothing;


                Clothes = StoredProc.GetClothing();

                foreach (DataRow record in Clothes.Tables[0].Rows)
                {
                    //dude don't keep the || true exp purposes only
                    if (record["onClearance"].ToString() == "False")
                    {
                        objClothing = new Classes.Clothing();
                        objClothing.ClothingImage = (string)record["clothingImage"];
                        objClothing.ClothingID = (int)record["clothingID"];
                        objClothing.ClothingName = (string)record["clothingName"];
                        objClothing.ClothingDescription = (string)record["clothingDescription"];
                        objClothing.ClothingPrice = (decimal)record["clothingPrice"];
                        mainClothes.Add(objClothing);

                    }
                    else
                    {
                        clearance.Add(record);
                    }
                }

                rptCLothing.DataSource = mainClothes;
                rptCLothing.DataBind();
            }
        }
        

        protected void rptCLothing_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            Classes.Clothing thisClothing = new Classes.Clothing();

            int rowIndex = e.Item.ItemIndex;

            // Retrieve a value from a control in the Repeater's Items collection

            Label myLabel = (Label)rptCLothing.Items[rowIndex].FindControl("lblclothingID");
            int clothingID = Int32.Parse(myLabel.Text);
            

            StoredProcedures StoredProc = new StoredProcedures();

            thisClothing = StoredProc.GetClothingByID(clothingID);

            int id = thisClothing.ClothingID;
            Response.Redirect("ClothingPage.aspx" + "?ClothingID=" + id);
        }

        protected void addClothes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddClothing.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = tbSearch.Text;

            DataSet Clothes = new DataSet();
            StoredProcedures StoredProc = new StoredProcedures();
            ArrayList clearance = new ArrayList();
            Classes.Clothing objClothing;


            Clothes = StoredProc.GetClothing();

            foreach (DataRow record in Clothes.Tables[0].Rows)
            {
                if (record["clothingName"].ToString().ToLower().Contains(searchValue.ToLower()))
                {
                        //dude don't keep the || true exp purposes only
                        if (record["onClearance"].ToString() == "False")
                        {
                            objClothing = new Classes.Clothing();
                            objClothing.ClothingImage = (string)record["clothingImage"];
                            objClothing.ClothingID = (int)record["clothingID"];
                            objClothing.ClothingName = (string)record["clothingName"];
                            objClothing.ClothingDescription = (string)record["clothingDescription"];
                            objClothing.ClothingPrice = (decimal)record["clothingPrice"];
                            mainClothes.Add(objClothing);

                        }
                        else
                        {
                            clearance.Add(record);
                        }
                }
            }
            rptCLothing.DataSource = mainClothes;
            rptCLothing.DataBind();
        }
    }
}