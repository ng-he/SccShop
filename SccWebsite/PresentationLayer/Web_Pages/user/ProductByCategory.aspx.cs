using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Web_Pages.user
{
    public partial class ProductByCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList_Product.DataSource = BUS.DataSelecter.GetProductsByCategory(Request.QueryString["cate"]);
            DataList_Product.DataBind();
        }
    }
}