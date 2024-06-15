<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_ProductCategory.ascx.cs" Inherits="GUI.Web_Pages.user.Uc_ProductCategory" %>
<asp:DataList ID="DataList_ProCategory" runat="server">
    <ItemTemplate>
        <div class="category">
            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("category_name") %>' NavigateUrl='<%# Eval("category_id", "~/Web_Pages/user/ProductByCategory.aspx?cate={0}") %>'></asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:DataList>