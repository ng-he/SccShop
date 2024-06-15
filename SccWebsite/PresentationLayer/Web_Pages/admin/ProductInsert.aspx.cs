using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Web_Pages.admin
{
    public partial class ProductInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var categories = BUS.DataSelecter.GetAllCategory();
                var manufacturers = BUS.DataSelecter.GetAllManufacturer();

                lst_ProTypes.DataSource = categories;
                lst_ProTypes.DataTextField = "category_name";
                lst_ProTypes.DataValueField = "category_id";
                lst_ProTypes.DataBind();

                lst_ProManufacturers.DataSource = manufacturers;
                lst_ProManufacturers.DataTextField = "manufacturer_name";
                lst_ProManufacturers.DataValueField = "manufacturer_id";
                lst_ProManufacturers.DataBind();

                txt_ProId.Value = "";
                txt_ProName.Value = "";
                txt_Price.Value = "";
                txt_Quantity.Value = "";
                txt_Description.Value = "";
                lst_ProTypes.SelectedValue = "";
                lst_ProManufacturers.SelectedValue = "";

                DisplayProductSpecifications(lst_ProTypes.Items[0].Value);
            }
        }

        private void DisplayProductSpecifications(string category_id)
        {
            List<string> specNameLst = BUS.SpecificationName.Of(category_id);
            ltrl_SpecificationsContainer.Text = "";

            for (int i = 0; i < specNameLst.Count; i++)
            {
                ltrl_SpecificationsContainer.Text += string.Format("" +
                    "<tr>" +
                        "<td style='width: 20%; border-right: 2px dashed silver;'><p>{0}</p></td>" +
                        "<td><input id='{1}' type='text' class='spec-input-layout'></td>" +
                    "</tr>"
                    , specNameLst[i], "spec_" + (i).ToString());
            }
        }

        protected void lst_ProTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayProductSpecifications(lst_ProTypes.SelectedValue);
        }

        protected void btn_InsertSubmit_ServerClick(object sender, EventArgs e)
        {
            DTO.Product product = new DTO.Product(
                txt_ProId.Value,
                txt_ProName.Value,
                lst_ProTypes.SelectedValue,
                lst_ProManufacturers.SelectedValue,
                float.Parse(txt_Price.Value),
                int.Parse(txt_Quantity.Value),
                txt_Description.Value,
                file_PictureChange.PostedFile.FileName
                );
             
            BUS.DataAdder.AddNew(product);
            BUS.DataAdder.AddSpecifications(txt_ProId.Value, lst_ProTypes.SelectedValue, HiddenField_Specifications.Value.Split(','));

            if (!string.IsNullOrEmpty(file_PictureChange.PostedFile.FileName))
            {
                file_PictureChange.PostedFile.SaveAs(Server.MapPath("..\\..\\Images\\ProductImg\\") + file_PictureChange.PostedFile.FileName);
            }

            Response.Redirect("~/Web_Pages/admin/ProductList.aspx");
        }
    }
}