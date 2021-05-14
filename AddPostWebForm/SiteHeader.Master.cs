using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddPostWebForm
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    lblUserName.Text = "Hello " + HttpContext.Current.User.Identity.GetUserName();
                    LoggedUserName.Visible = true;
                    MyAds.Visible = true;
                    //UserLogin.Visible = false;
                    //UserRegister.Visible = false;


                    if (HttpContext.Current.User.IsInRole("Admin"))
                    {
                        AdminAllAds.Visible = true;
                        CategoryAdd.Visible = true;
                        AllAds.Visible = false;
                        PostAd.Visible = false;
                        MyAds.Visible = false;
                    }
                }
            }
        }

    }
}