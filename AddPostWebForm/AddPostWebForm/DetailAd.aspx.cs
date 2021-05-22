using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddPostWebForm
{
    public partial class DetailAd : System.Web.UI.Page
    {
        public string imageName;
        protected void Page_Load(object sender, EventArgs e)
        {
            string customerId = "";
            if(!IsPostBack)
            {
                string postID = Request.QueryString["id"].ToString();

                //database connection which refers connection string in the Web.config file
                string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection conn = null;


                //Getting the ad details
                try
                {
                    conn = new SqlConnection(connString);
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Ads WHERE PostID=@postID";

                        Debug.WriteLine(postID);

                        cmd.Parameters.AddWithValue("@postID", int.Parse(postID));

                        //filtered ad from it's id
                        SqlDataReader reader = cmd.ExecuteReader();

                        //give details of the ad
                        while (reader.Read())
                        {
                            txtTitle.Text = (string)reader["Title"];
                            txtCondition.Text = (string)reader["Condition"];
                            txtDescription.Text = (string)reader["Description"];

                            object price = reader.GetValue(reader.GetOrdinal("Price"));
                            txtPrice.Text = "Rs. " + price.ToString();

                            customerId = (string)reader["CustomerID"];
                            imageName = (string)reader["Image"];
                            //need to check how to display the image
                        }

                    }


                }
                catch (Exception ex)
                {
                    //log error 
                    //display friendly error to user
                    Label1.Text = ex.ToString();
                }
                finally
                {
                    if (conn != null)
                    {
                        //cleanup connection i.e close 
                    }
                }



                //getting the contact details of the ad owner
                try
                {
                    conn = new SqlConnection(connString);
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "SELECT * FROM AspNetUsers WHERE Id=@customerid";

                        cmd.Parameters.AddWithValue("@customerid", customerId);

                        //filter the customer details
                        SqlDataReader reader = cmd.ExecuteReader();

                        //give details of the customer
                        while (reader.Read())
                        {
                            txtName.Text = (string)reader["UserName"];
                            txtEmail.Text = (string)reader["Email"];
                            txtPhoneNumber.Text = (string)reader["PhoneNumber"];
                        }

                    }

                }
                catch (Exception ex)
                {
                    //log error 
                    //display friendly error to user
                    Label1.Text = ex.ToString();
                }
                finally
                {
                    if (conn != null)
                    {
                        //cleanup connection i.e close 
                    }
                }


            }

        }
    }
}