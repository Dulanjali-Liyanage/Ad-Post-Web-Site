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
    public partial class CategoryAdd : System.Web.UI.Page
    {
        //database connection which refers connection string in the Web.config file
        string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn = null;
        protected void Page_Load(object sender, EventArgs e)
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
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Categories(CategoryName) Values (@categoryname)";

                    cmd.Parameters.AddWithValue("@categoryname", txtCategory.Text);

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

            txtCategory.Text = "";
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }
    }
}