<%@ Page Title="" Language="C#" MasterPageFile="~/Web_Pages/user/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="UserMain.aspx.cs" Inherits="GUI.Web_Pages.user.UserMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .product-item {
            width: 200px;
            height: 300px;
            margin-left: 5px;
            margin-right: 5px;
            margin-bottom: 10px;
            background-color: white;
            border-radius: 25px;
            display: flex;
            flex-direction: column;
        }

        .product-item img {
            border-radius: 25px;
            box-shadow: 3px 4px 5.2px -3px rgba(0, 0, 0, 0.13);
        }

        .product-name {
            font-size: 13px;
            font-weight: bold;
            padding-left: 11px;
            padding-right: 11px;
            text-decoration: none;
            color: black;
        }

        .product-name:hover {
            color:  #FC4F00;
        }

        .price {
            margin-left: auto; 
            margin-right: auto; 
            margin-top: auto; 
            margin-bottom: 10px;
            color: #FC4F00;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 5px; margin-top: 11px; width: 842px;">
        <asp:DataList ID="DataList_Product" runat="server" RepeatColumns="4">
            <ItemTemplate>
                <div class="product-item">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("picture_path", "../../Images/ProductImg/{0}") %>' Width="200px" />
                    <div style="width: 179px; height: 3px; margin-bottom: 10px; margin-top: 10px; margin-left: auto; margin-right: auto; background: linear-gradient(270deg, #B55BB4 0%, #4554BA 100%);"></div>                   
                    <asp:HyperLink ID="Label1" runat="server" Text='<%# Eval("product_name") %>' NavigateUrl='<%# Eval("product_id", "~/Web_Pages/user/ProductDetails.aspx?id={0}") %>' CssClass="product-name"></asp:HyperLink>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("unit_price", "{0:0,#} VNĐ") %>' CssClass="price"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
