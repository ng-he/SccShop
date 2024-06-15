using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Web_Pages.user
{
    public partial class UserMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Label_Username.Text = Session["username"].ToString();  
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void ImageButton_Search_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Web_Pages/user/Search.aspx?search=" + InputText_Search.Value);
        }

        protected void LinkButton_Logout_Click(object sender, EventArgs e)
        {
            Session.Remove("username");
            Page_Load(sender, e);
        }
    }
}