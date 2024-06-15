using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Web_Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_LoginMessage.Text = " ";
            txt_Username.Focus();
        }

        protected void btn_Login_ServerClick(object sender, EventArgs e)
        {
            string[] Result = BUS.AccountChecker.UsernameExist(txt_Username.Value);

            if(Result[0] == "")
            {
                lbl_LoginMessage.Text = "Tài khoản không tồn tại";
                return;
            }

            if(Result[0] != txt_Password.Value)
            {
                lbl_LoginMessage.Text = "Mật khẩu không chính xác";
                return;
            }

            if(Result[1] == "user")
            {
                Session["username"] = txt_Username.Value;   
                Response.Redirect("~/Web_Pages/user/UserMain.aspx");
            } 
            else if(Result[1] == "admin")
            {
                Response.Redirect("~/Web_Pages/admin/AdminMain.aspx");
            }
        }
    }
}