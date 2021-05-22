using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddPostWebForm
{
    public partial class PostAdForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (!User.Identity.IsAuthenticated) 
                {
                    Response.Redirect("~/Login.aspx");
                }
            }

        }

        //on button click add the form data to the table
        protected void btnPostAd_Click(object sender, EventArgs e)
        {

            //Check the clicked radio button
            string condition;
            if(rdbUsed.Checked == true)
            {
                condition = "Used";
            }else
            {
                condition = "New";
            }

            //saving the image file to images folder
            FileUpload1.SaveAs(Server.MapPath("/images/") + FileUpload1.FileName);


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
                    cmd.CommandText = "INSERT INTO Ads(CustomerID,CategoryID,Condition,Title,Description,Price,Image) Values (@customerid,@categoryid,@condition,@title,@description,@price,@image)";

                    cmd.Parameters.AddWithValue("@categoryid", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@customerid", User.Identity.GetUserId());
                    cmd.Parameters.AddWithValue("@condition", condition);
                    cmd.Parameters.AddWithValue("@title", txtAdTitle.Text);
                    cmd.Parameters.AddWithValue("@description", txtAdDescription.Text);
                    cmd.Parameters.AddWithValue("@price", float.Parse(txtAdPrice.Text));
                    cmd.Parameters.AddWithValue("@image", Path.GetFileName(FileUpload1.PostedFile.FileName));

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