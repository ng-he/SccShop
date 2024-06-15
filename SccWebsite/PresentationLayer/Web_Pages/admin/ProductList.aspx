<%@ Page Title="" Language="C#" MasterPageFile="~/Web_Pages/admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="GUI.Web_Pages.admin.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Css/product-list.css" />
    <script src="../../Scripts/jquery-3.7.1.js"></script>
    <script>
        window.onload = function () {
            $('tr').click(function (e) {
                if ($('#optional-control').length != 0) {
                    $('#optional-control').remove();
                }

                if (e.target.tagName == 'TD') {
                    let productId = $(this).children(':first').contents();
                    let cate = $(this).children().eq(8).contents();
                    $(this).after(
                        "<tr id='optional-control'> \
                            <td colspan='8'> \
                                <button id='opt-update-btn' type='button' onclick='window.location = \"ProductUpdate.aspx?id=" + productId.text() + "\";'> Sửa thông tin </button> \
                                <button id='opt-delete-btn' type='button' onclick='if(confirm(\"Xóa sản phẩm này?\") == true) {window.location = \"ProductDelete.aspx?id=" + productId.text() + "&cate=" + cate.text() + "\";}'> Xóa </button>  \
                            </td> \
                        </tr>"
                    );
                }      
            });

            document.addEventListener('click', function (e) {
                if (e.target.tagName != 'TD') {
                    if ($('#optional-control').length != 0) {
                        $('#optional-control').remove();
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <div class="toolbar-container">
        <input type="button" value="THÊM SẢN PHẨM" class="insert-btn" onclick="window.location = 'ProductInsert.aspx'" />
        <div style="margin: auto; font-weight: bold;"> BẤM VÀO 1 HÀNG ĐỂ HIỆN CHỨC NĂNG UPDATE VÀ DELETE </div>
    </div>
    <div class="list-container">
        <asp:GridView ID="grv_ProductList" runat="server" AutoGenerateColumns="False" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="product_id" HeaderText="M&#227; sản phẩm">
                    <HeaderStyle Width="150px"></HeaderStyle>
                </asp:BoundField>
                <asp:ImageField AlternateText="Kh&#244;ng c&#243; ảnh" DataImageUrlField="picture_path" DataImageUrlFormatString="../../Images/ProductImg/{0}" HeaderText="Ảnh" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle Width="150px"></HeaderStyle>
                </asp:ImageField>
                <asp:BoundField DataField="product_name" HeaderText="T&#234;n sản phẩm">
                    <HeaderStyle Width="200px"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="category_name" HeaderText="Loại sản phẩm">
                    <HeaderStyle Width="150px"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="manufacturer_name" HeaderText="HSX">
                    <HeaderStyle Width="150px"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="unit_price" HeaderText="Đơn gi&#225;">
                    <HeaderStyle Width="150px"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="stock" HeaderText="Số lượng">
                    <HeaderStyle Width="150px"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="product_description" HeaderText="M&#244; tả" ItemStyle-CssClass="description-style"></asp:BoundField>
                <asp:BoundField DataField="category_id" ItemStyle-CssClass="visible-false"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
