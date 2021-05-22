using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace AddPostWebForm
{
    public partial class MyAds : System.Web.UI.Page
    {
        //database connection which refers connection string in the Web.config file
        string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

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



                //selecting all my ads
                try
                {
                    conn = new SqlConnection(connString);
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Ads WHERE CustomerID=@customerid";


                        cmd.Parameters.AddWithValue("@customerid", User.Identity.GetUserId());

                        //filter the ads of the logged user
                        SqlDataReader reader = cmd.ExecuteReader();

                        //bind the ads of logged user to the repeater control in .aspx file
                        myAdRep.DataSource = reader;
                        myAdRep.DataBind();

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

            foreach (RepeaterItem item in myAdRep.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton btnDelete = item.FindControl("btnDelete") as LinkButton;
                    btnDelete.Click += new EventHandler(DeleteMyAd);

                    LinkButton btnEdit = item.FindControl("btnEdit") as LinkButton;
                    btnEdit.Click += new EventHandler(EditMyAd);

                    LinkButton btnDetail = item.FindControl("btnDetail") as LinkButton;
                    btnDetail.Click += new EventHandler(DetailAd);
                }
            }

        }

        protected void myAdRep_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void DeleteMyAd(object sender, EventArgs e)
        {

            string postID = (sender as LinkButton).CommandArgument;

            //database connection which refers connection string in the Web.config file
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Ads WHERE PostID=@postID";

                    Debug.WriteLine(postID);

                    cmd.Parameters.AddWithValue("@postID", int.Parse(postID));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        //After delete is successfull refresh the page
                        Server.TransferRequest(Request.Url.AbsolutePath, false);
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

        protected void EditMyAd(object sender, EventArgs e)
        {
            string postID = (sender as LinkButton).CommandArgument;

            Response.Redirect("~/EditMyAd.aspx?id="+postID);
        }

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

                    //sql server needed and alias for the subquery therefore added the "a"
                    cmd.CommandText = "SELECT * FROM (SELECT * FROM Ads WHERE CustomerID=@customerid) a WHERE CategoryID=@categoryid";

                    cmd.Parameters.AddWithValue("@customerid", User.Identity.GetUserId());
                    cmd.Parameters.AddWithValue("@categoryid", categoryid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    //selected myads of the relevant category
                    //bind the myads of the selected category
                    myAdRep.DataSource = reader;
                    myAdRep.DataBind();

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
                    myAdRep.DataSource = reader;
                    myAdRep.DataBind();

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