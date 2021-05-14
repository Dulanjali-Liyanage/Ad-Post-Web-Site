using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddPostWebForm
{
    public partial class EditMyAd : System.Web.UI.Page
    {
        public string imageName;
        //database connection which refers connection string in the Web.config file
        string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string postID = Request.QueryString["id"].ToString();

                
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

                        //filtered ad of the logged user
                        SqlDataReader reader = cmd.ExecuteReader();

                        //acces and set the default values of the relevant ad
                        while (reader.Read()) 
                        {
                            if((string)reader["Condition"] == "Used")
                            {
                                rdbUsed.Checked = true;
                            }
                            else
                            {
                                rdbNew.Checked = true;
                            }
                            //DropDownList1.SelectedValue = (string)reader["CategoryID"];//err

                            object dropvalueselect = reader.GetValue(reader.GetOrdinal("CategoryID"));
                            DropDownList1.SelectedValue = dropvalueselect.ToString();
                                


                            txtAdTitle.Text = (string)reader["Title"];
                            txtAdDescription.Text = (string)reader["Description"];

                            object price = reader.GetValue(reader.GetOrdinal("Price"));
                            txtAdPrice.Text = price.ToString();
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
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string postID = Request.QueryString["id"].ToString();
            string postImageName ="";


            //get the previous image name of the ad to be editedd
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

                    //filtered ad of the logged user
                    SqlDataReader reader = cmd.ExecuteReader();

                    //acces and set the default values of the relevant ad
                    while (reader.Read())
                    {

                        postImageName = (string)reader["Image"];
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


            //***********************************************Updating function************************
            //Check the clicked radio button
            string condition;
            if (rdbUsed.Checked == true)
            {
                condition = "Used";
            }
            else
            {
                condition = "New";
            }

            if (FileUpload1.HasFile)
            {
                //saving the image file to images folder
                FileUpload1.SaveAs(Server.MapPath("/images/") + FileUpload1.FileName);
            }
            


            //Update           
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Ads SET CategoryID = @categoryid, Condition = @condition,Title = @title,Description = @description,Price = @price,Image = @image WHERE PostID = @postid";

                    cmd.Parameters.AddWithValue("@categoryid", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@postid", int.Parse(postID));
                    cmd.Parameters.AddWithValue("@condition", condition);
                    cmd.Parameters.AddWithValue("@title", txtAdTitle.Text);
                    cmd.Parameters.AddWithValue("@description", txtAdDescription.Text);
                    cmd.Parameters.AddWithValue("@price", float.Parse(txtAdPrice.Text));

                    if (FileUpload1.HasFile)
                    {
                        cmd.Parameters.AddWithValue("@image", Path.GetFileName(FileUpload1.PostedFile.FileName));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image", postImageName);
                    }

                    

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        //Success notification
                    }
                    else
                    {
                        //Error notification
                    }
                }
            }
            catch (Exception ex)
            {
                //log error 
                //display friendly error to user
                //Label2.Text = ex.ToString();
            }
            finally
            {
                if (conn != null)
                {
                    //cleanup connection i.e close 
                }
            }

            rdbNew.Checked = false;
            rdbUsed.Checked = false;
            txtAdTitle.Text = "";
            txtAdDescription.Text = "";
            txtAdPrice.Text = "";
        }
    }
}