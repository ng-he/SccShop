using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Web_Pages.user
{
    public partial class ProductDetails : System.Web.UI.Page
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

            DataRow product = BUS.DataSelecter.GetProduct(Request.QueryString["id"].ToString());
            DataRow proSpecs = BUS.DataSelecter.GetProductSpectifications(product["product_id"].ToString(), product["category_id"].ToString());
            List<string> specsName = BUS.SpecificationName.Of(product["category_id"].ToString());

            Label_Product.Text = product["product_name"].ToString();
            Label_Stock.Text = product["stock"].ToString();
            Label_Price.Text = string.Format("{0:0,#} VNĐ", product["unit_price"].ToString());
            Label_Desciption.Text = product["product_description"].ToString();
            Img_Product.Src = "../../Images/ProductImg/" + product["picture_path"].ToString();

            Literal_Specifications.Text = "<table>";
            for(int i = 0; i < specsName.Count; i++)
            {
                Literal_Specifications.Text += string.Format("" +
                    "<tr>" +
                        "<td>{0}</td>" +
                        "<td>{1}</td>" +
                    "</tr>", specsName[i], proSpecs[i + 1].ToString());
            }
            Literal_Specifications.Text += "</table>";
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