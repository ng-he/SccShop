<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUI.Web_Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> SCC shop </title>
    <link rel="icon" type="image/x-icon" href="~/Images/Icons/SCC-icon-2.png" />
    <link rel="stylesheet" type="text/css" href="../Css/login-style.css" />
    <script type="text/javascript" src="../Scripts/login-script.js"> </script>
</head>
<body> 
    <form id="form1" runat="server" onsubmit="return (loginValidate());">
        <div class = "login-form-container">
            <div class = "welcome-container">
                <div class="welcome-border"> <p> Welcome </p> </div>
                <div style="margin-top: 22px; font-size: 20px; font-weight: 700;"> Không có tài khoản </div>
                <a href="user/SignUp.aspx" class="sign-up-link"> Tạo tài khoản mới tại đăy </a>
            </div>

            <div class="bound"></div>

            <div class = "input-container">
                <p> Đăng nhập </p> 
                <hr class="line" />
                <div id="txt-username-container" class="textbox-style">
                    <img id="person-ico" src = "../Images/Icons/Person1.png" />
                    <input id = "txt_Username" type="text" runat="server" placeholder = "Tên đăng nhập"
                        oninput="textChange('txt_Username', 'UsernameError', 'Tên đăng nhập không được để trống')" onfocus="borderFocus('txt-username-container', 'txt-password-container')" /> <br />                                    
                </div>

                <div style="width: 330px;">
                    <small id = "UsernameError"> &nbsp </small>
                </div>

                <div id="txt-password-container" class="textbox-style">
                    <img id="lock-ico" src = "../Images/Icons/Lock1.png" />
                    <input id="txt_Password" type="password" runat="server" placeholder = "Mật khẩu"
                        oninput="textChange('txt_Password', 'PasswordError', 'Mật khẩu không được để trống')" onfocus="borderFocus('txt-password-container', 'txt-username-container')"/> <br />               
                </div>

                <div style="width: 330px;">
                    <small id = "PasswordError"> &nbsp </small>
                </div>

                <div style="width: 330px; margin-top : 20px;">
                    <div style="float : left;">
                        <input id="ckbx_RememberMe" type="checkbox" /> 
                        <small style="font-size: 15px; font-weight: 700;"> Nhớ đến tôi </small>
                    </div>         
                </div>
                
                <input id="btn_Login" type="submit" value="LOGIN" runat="server" onserverclick="btn_Login_ServerClick" />
                <asp:Label ID="lbl_LoginMessage" runat="server" Text="&nbsp" CssClass="label-message"></asp:Label>
                <a class="forgot-password" href="#" style="margin-top : 40px; margin-bottom : 20px;"> Quên mật khẩu? </a>
            </div>
        </div>
    </form>
</body>
</html>
