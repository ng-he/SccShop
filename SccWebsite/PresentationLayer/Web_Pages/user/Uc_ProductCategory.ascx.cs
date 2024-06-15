using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Web_Pages.user
{
    public partial class Uc_ProductCategory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList_ProCategory.DataSource = BUS.DataSelecter.GetAllCategory();
            DataList_ProCategory.DataBind();
        }
    }
}