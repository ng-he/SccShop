<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="GUI.Web_Pages.user.ProductDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> SCC shop </title>
    <link rel="icon" type="image/x-icon" href="../../Images/Icons/SCC-icon-2.png" />
    <link rel="stylesheet" type="text/css" href="../../Css/user-master.css" />
    <style>
        .description {
            display: block;
            font-weight: bold;
            text-align: justify;
            line-height: 30px;
        }

        #specifications table {
            width: 100%;
        }

        #specifications td {
            width: 50%;
            font-weight: bold;
            padding-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top-bar">
            <div style="width:1200px; height: 96px; margin: auto; display: flex; flex-direction: row;">
                <div class="logo">
                    <img src="../../Images/Icons/SCC-icon.png" style="width: 298px; margin: auto;" />
                </div>
                <div class="tool-bar">
                    <div class="search-container">
                        <input id="InputText_Search" runat="server" type="text" placeholder="Nhập tên sản phẩm"/>
                        <asp:ImageButton ID="ImageButton_Search" runat="server" ImageUrl="~/Images/Icons/glass1.png" OnClick="ImageButton_Search_Click" CssClass="search-icon" Width="37px" Height="37px" ImageAlign="Middle" />
                    </div>
                    <div class="register-container">
                        <div style="margin: auto;">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <div style="font-weight: bold; font-size: 24px; text-decoration: none; color: black;">
                                        <asp:HyperLink ID="HyperLink_Register" runat="server" NavigateUrl="~/Web_Pages/user/SignUp.aspx">Đăng Ký</asp:HyperLink> | 
                                        <asp:HyperLink ID="HyperLink_Login" runat="server" NavigateUrl="~/Web_Pages/Login.aspx">Đăng Nhập</asp:HyperLink>
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table>
                                        <tr>
                                            <td rowspan="2" style="width: 68px; height: 68px;">
                                                <img src="../../Images/Icons/Person2.png" style="width: 68px;"/>
                                            </td>
                                            <td style="text-align: left; font-weight: bold; font-size: 16px; vertical-align: middle; padding-top: 3px;">
                                                <asp:Label ID="Label_Username" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; font-weight: bold; font-size: 12px; vertical-align: top;">
                                                <asp:LinkButton ID="LinkButton_Logout" runat="server" OnClick="LinkButton_Logout_Click">Đăng xuất</asp:LinkButton> |
                                                Tài khoản của tôi
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </div>
                    </div>
                    <div class="cart-container">
                        <img src="../../Images/Icons/cart.png" style="margin: auto;" />
                    </div>
                </div>
            </div>
        </div>

        <div class="body" style="margin-top: 18px;">
            <div style="width: 1200px; height: 560px; border-radius: 25px; background: linear-gradient(270deg, #B55BB4 0%, #4554BA 100%); box-shadow: 3px 4px 5.2px -3px rgba(0, 0, 0, 0.13);">
                <div style="width: 1200px; height: 48px; border-radius: 25px; background-color: #EDEDED; box-shadow: 3px 4px 5.2px -3px rgba(0, 0, 0, 0.13); display: flex;">
                    <a href="UserMain.aspx" style="text-decoration: none; font-weight: bold; font-size: 18px; margin-top: auto; margin-bottom: auto; margin-left: 30px;">QUAY LẠI TRANG CHỦ</a>
                </div>
                <div style="width: 1164px; height: 484px; background-color: white; border-radius: 25px; margin-left: auto; margin-right: auto; margin-top: 13px; display: flex;">
                    <table style="width: 1000px; margin: auto;">
                        <tr>
                            <td rowspan="4" style="width: 440px;">
                                <img id="Img_Product" runat="server" src="../../Images/images-empty.png" style="width: 420px;" />
                            </td>                                
                            <td style="height: 245px; vertical-align: top; font-weight: bold; font-size: 40px; " >
                                <asp:Label ID="Label_Product" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 50px;">
                            <td style="height: 30px; display: flex;">
                                <div style="font-weight: bold; color: #FC4F00; margin-right: 10px; margin-top: auto; margin-bottom: auto;">Số lượng: </div>
                                <input type="number" value="0" style="font-weight: bold; border-radius: 25px; background-color: #EDEDED; border: none; box-shadow: 3px 4px 5.2px -3px rgba(0, 0, 0, 0.13); padding-left: 20px; padding-right: 10px; width: 100px;" />
                                <div style="font-weight: bold; color: #A3A3A3; margin-left: 10px; margin-top: auto; margin-bottom: auto;"><asp:Label ID="Label_Stock" runat="server" Text=""></asp:Label> sản phẩm có sẵn</div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; color: #FC4F00;">
                                Đơn giá : <asp:Label ID="Label_Price" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: bottom;">
                                <button style="width: 244px; height: 52px; border: none; border-radius: 25px; box-shadow: 3px 4px 5.2px -3px rgba(0, 0, 0, 0.13); background-color: #6FB554; color: white; font-size: 20px; font-weight: bold;">Mua ngay</button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div style="width: 1200px; margin-top: 18px;">
                <table style="width: 100%;">
                    <tr>
                        <td style="border-radius: 25px; width: 584px; height: 614px; background-color: #EDEDED; vertical-align: top;">
                            <div style="width: 518px; margin-left: auto; margin-right: auto; margin-top: 33px;">
                                <p style="font-weight: bold; font-size: 24px;">MÔ TẢ</p>
                                <div style="width: 80px; height: 3px; background: linear-gradient(270deg, #B55BB4 0%, #4554BA 100%); margin-top: 5px; margin-bottom: 15px;"></div>
                                <asp:Label ID="Label_Desciption" runat="server" Text="" CssClass="description"></asp:Label>
                            </div>
                        </td>
                        <td style="width: 33px;"></td>
                        <td style="border-radius: 25px; width: 584px; height: 614px; background-color: #EDEDED; vertical-align: top;">
                            <div style="width: 518px; margin-left: auto; margin-right: auto; margin-top: 33px;">
                                <p style="font-weight: bold; font-size: 24px;">THÔNG SỐ KỸ THUẬT</p>
                                <div style="width: 260px; height: 3px; background: linear-gradient(270deg, #B55BB4 0%, #4554BA 100%); margin-top: 5px; margin-bottom: 15px;"></div>
                                <div id="specifications"><asp:Literal ID="Literal_Specifications" runat="server"></asp:Literal></div>                             
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
