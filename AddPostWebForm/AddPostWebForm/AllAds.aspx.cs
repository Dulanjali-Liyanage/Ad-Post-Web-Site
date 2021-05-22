using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddPostWebForm
{
    public partial class AllAds : System.Web.UI.Page
    {
        //database connection which refers connection string in the Web.config file
        string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Logout.Visible = true;
                }


                

                //selecting all categories
                try
                {
                    conn = new SqlConnection(connString);
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Categories";

                        //Select all categories
                        SqlDataReader reader = cmd.ExecuteReader();

                        //bind the ads of logged user to the repeater control in .aspx file
                        CategoryRepeat.DataSource = reader;
                        CategoryRepeat.DataBind();

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






                //selecting all ads
                try
                {
                    conn = new SqlConnection(connString);
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Ads";

                        //Select all categories
                        SqlDataReader reader = cmd.ExecuteReader();

                        //bind the all the ads to the repeater
                        someRep.DataSource = reader;
                        someRep.DataBind();

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




            }
            
        }

        protected void SignOut(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void someRep_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        //view more details of the ad
        protected void DetailAd(object sender, EventArgs e)
        {
            string postID = (sender as LinkButton).CommandArgument;

            Response.Redirect("~/DetailAd.aspx?id="+postID);
        }

        //filter the ads of a specific category
        protected void Category_click(object sender, EventArgs e)
        {
            string categoryid = (sender as LinkButton).CommandArgument;

            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Ads WHERE CategoryID=@categoryid";

                    cmd.Parameters.AddWithValue("@categoryid", categoryid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    //selected ads of the relevant category
                    //bind the ads of the selected category
                    someRep.DataSource = reader;
                    someRep.DataBind();

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

        }

        protected void AllCategory_click(object sender, EventArgs e)
        {
            //refresh the page to run the page load
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        protected void MangeAccount_click(object sender, EventArgs e)
        {
            
        }

        protected void SearchAd_click(object sender, EventArgs e)
        {
            
            //selecting all ads relevant to search string
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Ads WHERE CHARINDEX(@searchstring, Title) > 0";


                    cmd.Parameters.AddWithValue("@searchstring", txtSearchbox.Text);

                    //Select all categories
                    SqlDataReader reader = cmd.ExecuteReader();

                    //bind the all the ads to the repeater
                    someRep.DataSource = reader;
                    someRep.DataBind();

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


        }
    }
}