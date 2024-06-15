using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Web_Pages.admin
{
    public partial class ProductDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BUS.DataDeleter.DeleteSpecifications(Request.QueryString["id"], Request.QueryString["cate"]);
            BUS.DataDeleter.DeleteProduct(Request.QueryString["id"]);
            Response.Redirect("~/Web_Pages/admin/ProductList.aspx");
        }
    }
}