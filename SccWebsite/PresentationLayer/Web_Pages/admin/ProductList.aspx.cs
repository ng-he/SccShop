using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Web_Pages.admin
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grv_ProductList.DataSource = BUS.DataSelecter.GetAllProduct();
            grv_ProductList.DataBind();
        }
    }
}