<%@ Page Title="" Language="C#" MasterPageFile="~/Web_Pages/admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ProductUpdate.aspx.cs" Inherits="GUI.Web_Pages.admin.ProductUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Css/product-update.css" />
    <script src="../../Scripts/jquery-3.7.1.js"></script>
    <script>
        var specValues;

        window.onload = function () {
            
            specValues = $(".specifications-container :input").map(function () {
                return $(this).val();
            });  

            $(".specifications-container :input").change(function () {
                specValues[$(this).attr('id').slice(-1)] = $(this).val();
            });

            $("#form1").submit(function () {
                if (document.getElementById("ContentPlaceHolder1_HiddenField_IsProTypeChange").value == "True") {
                    if (!confirm("Việc đổi loại sản phẩm sẽ thay đổi thông số kỹ thuật của sản phẩm, Bạn vẫn muốn tiếp tục?")) {
                        return false;
                    }
                }

                let hiddenFieldSpec = document.getElementById("ContentPlaceHolder1_HiddenField_Specifications");
                hiddenFieldSpec.value = "";

                for (let i = 0; i < specValues.length; i++) {
                    hiddenFieldSpec.value += specValues[i] + (i == specValues.length - 1 ? "" : ",");
                }

                return true;
            });
        }

        function imageChange(event) {
            let imgDisplayer = document.getElementById("ContentPlaceHolder1_img_ProPicture");
            imgDisplayer.src = URL.createObjectURL(event.target.files[0]);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="control-background"> 
        <table class="control-container">
            <tr> 
                <td>  
                    <p style="font-size: 24px; font-weight: bold; color: #FC4F00;"> SỬA THÔNG TIN SẢN PHẨM </p>
                    <div style="width: 325px; height: 3px; background-color: silver; margin-top: 5px;"></div>
                </td>
            </tr>

            <tr>
                <td>
                    <table class="information-container">
                        <asp:HiddenField ID="HiddenField_IsProTypeChange" runat="server" value="False"/>
                        <tr>
                            <td rowspan="2" style="vertical-align: top; text-align: center;">
                                <p> Ảnh sản phẩm </p>
                                <img id="img_ProPicture" runat="server" src="~/Images/images-empty.png" alt="<Không có ảnh>" style="width: 100px; margin-top: 10px; border-radius: 15px;"/>
                                <label for="ContentPlaceHolder1_file_PictureChange" class="file-button">Đổi ảnh</label>
                                <input id="file_PictureChange" type="file" runat="server" accept="image/*" style="display: none;" onchange="imageChange(event)" />  
                            </td>
                            <td> 
                                <p> Mã sản phẩm </p>
                                <input class="input-layout" id="txt_ProId" runat="server" type="text" disabled="disabled"/>
                            </td>
                        </tr>
                        <tr> 
                            <td> 
                                <p> Tên sản phẩm </p>
                                <input class="input-layout" id="txt_ProName" runat="server" type="text"/>
                            </td>
                        </tr>
                        <tr> 
                            <td> 
                                <p> Loại sản phẩm </p>
                                <asp:DropDownList ID="lst_ProTypes" runat="server" CssClass="input-layout" OnSelectedIndexChanged="lst_ProTypes_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td> 
                                <p> Đơn giá </p>
                                <input class="input-layout" id="txt_Price" runat="server" type="number"/>
                            </td>
                        </tr>
                        <tr> 
                            <td> 
                                <p> Hãng sản xuất </p>
                                <asp:DropDownList ID="lst_ProManufacturers" runat="server" CssClass="input-layout" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td> 
                                <p> Số lượng </p>
                                <input class="input-layout" id="txt_Quantity" runat="server" type="number"/>
                            </td>
                        </tr>
                        <tr> 
                            <td colspan="2"> 
                                <p> Mô tả </p>
                                <textarea class="input-layout" id="txt_Description" runat="server" style="width: 100%; resize: vertical;"></textarea>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td> 
                    <p style="font-size: 24px; font-weight: bold; color: #FC4F00; margin-top: 20px; margin-bottom: 20px;"> THÔNG SỐ KỸ THUẬT CỦA SẢN PHẨM </p>
                </td>
            </tr>

            <tr>
                <td>
                    <table class="specifications-container">
                        <asp:Literal ID="ltrl_SpecificationsContainer" runat="server"></asp:Literal>
                    </table>
                    <asp:HiddenField ID="HiddenField_Specifications" runat="server" />
                </td>
            </tr>

            <tr>
                <td>
                    <div style="margin-top: 20px;">
                        <input class="button" id="btn_UpdateSubmit" runat="server" type="submit" onserverclick="btn_UpdateSubmit_ServerClick" value="LƯU THAY ĐỔI" />
                        &nbsp;
                        <button class="button" id="btn_ProductListRedirect" type="button" onclick="window.location = 'ProductList.aspx';">QUAY LẠI</button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
