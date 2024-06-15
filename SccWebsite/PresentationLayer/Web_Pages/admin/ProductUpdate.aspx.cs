using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.Configuration;

namespace GUI.Web_Pages.admin
{
    public partial class ProductUpdate : System.Web.UI.Page
    {
        private void InputLoad()
        {
            var product = BUS.DataSelecter.GetProduct(Request.QueryString["id"]);
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

            txt_ProId.Value = product.Field<string>("product_id");
            txt_ProName.Value = product.Field<string>("product_name");
            txt_Price.Value = product.Field<double>("unit_price").ToString();
            txt_Quantity.Value = product.Field<int>("stock").ToString();
            txt_Description.Value = product.Field<string>("product_description");
            lst_ProTypes.SelectedValue = product.Field<string>("category_id");
            lst_ProManufacturers.SelectedValue = product.Field<string>("manufacturer_id");

            if (product.Field<string>("picture_path") != "")
            {
                Session["OldPicture"] = product.Field<string>("picture_path");
                img_ProPicture.Src = "../../Images/ProductImg/" + product.Field<string>("picture_path");
            }

            DisplayProductSpecifications(product.Field<string>("category_id"));
            Session["OldProductType"] = lst_ProTypes.SelectedValue;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InputLoad();
            }
        }

        protected void btn_UpdateSubmit_ServerClick(object sender, EventArgs e)
        {
            DTO.Product product = new DTO.Product(
                txt_ProId.Value,
                txt_ProName.Value,
                lst_ProTypes.SelectedValue,
                lst_ProManufacturers.SelectedValue,
                float.Parse(txt_Price.Value),
                int.Parse(txt_Quantity.Value),
                txt_Description.Value,
                file_PictureChange.PostedFile != null ? file_PictureChange.PostedFile.FileName : Session["OldPicture"].ToString()
                );

            BUS.DataUpdater.Update(product);

            if(lst_ProTypes.SelectedValue == Session["OldProductType"].ToString())
            {
                BUS.DataUpdater.UpdateSpecifications(txt_ProId.Value, Session["OldProductType"].ToString(), HiddenField_Specifications.Value.Split(','));
            } 
            else
            {
                BUS.DataDeleter.DeleteSpecifications(txt_ProId.Value, Session["OldProductType"].ToString());
                BUS.DataAdder.AddSpecifications(txt_ProId.Value, lst_ProTypes.SelectedValue, HiddenField_Specifications.Value.Split(','));
            }

            if(!string.IsNullOrEmpty(file_PictureChange.PostedFile.FileName))
            {
                file_PictureChange.PostedFile.SaveAs(Server.MapPath("..\\..\\Images\\ProductImg\\") + file_PictureChange.PostedFile.FileName);
            }

            InputLoad();
        }

        protected void lst_ProTypes_SelectedIndexChanged(object sender, EventArgs e)
        {            
            HiddenField_IsProTypeChange.Value = lst_ProTypes.SelectedValue == Session["OldProductType"].ToString() ? "False" : "True";
            DisplayProductSpecifications(lst_ProTypes.SelectedValue);
        }

        private void DisplayProductSpecifications(string category_id)
        {
            List<string> specNameLst = BUS.SpecificationName.Of(category_id);
            DataRow productSpecs = BUS.DataSelecter.GetProductSpectifications(txt_ProId.Value, category_id);
            ltrl_SpecificationsContainer.Text = "";

            if(productSpecs != null)
            {
                for (int i = 0; i < specNameLst.Count; i++)
                {
                    ltrl_SpecificationsContainer.Text += string.Format("" +
                        "<tr>" +
                            "<td style='width: 20%; border-right: 2px dashed silver;'><p>{0}</p></td>" +
                            "<td><input id='{1}' type='text' class='spec-input-layout' value='{2}'></td>" +
                        "</tr>"
                        , specNameLst[i], "spec_" + (i).ToString(), productSpecs.ItemArray[i + 1].ToString());
                }
            }
            else
            {
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
        }

    }
}