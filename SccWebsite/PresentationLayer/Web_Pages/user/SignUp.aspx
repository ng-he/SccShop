<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="GUI.Web_Pages.user.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title> SCC shop </title>
    <link rel="icon" type="image/x-icon" href="../../Images/Icons/SCC-icon-2.png" />
    <link rel="stylesheet" type="text/css" href="../../Css/signup-style.css" />
    <script src="../../Scripts/jquery-3.7.1.js"></script>
    <script src="../../Scripts/signup-script.js"></script>
</head>
<body>    
    <div runat="server" class="login-redirect-container">
        <div class="login-redirect-form">
            <table>
                <tr>
                    <td colspan="2"> <p> Đăng ký thành công, chuyển sang trang đăng nhập ? </p> </td>
                </tr>
                <tr>
                    <td style="width: 50%;"> <input id="to-login" type="button" value="OK" onclick="window.location = '../Login.aspx';"/> </td>
                    <td style="width: 50%;"> <input id="cancel-to-login" type="button" value="Cancel" onclick="loginRedirectConfirmDisappear();"/> </td>
                </tr>
            </table>
        </div>
    </div>
    <form id="form_SignUp" runat="server">
        <asp:HiddenField ID="hidden_SignUpSuccessMessage" runat="server" Value="false" />
        <div class="sign-up-form-container">      
            <table class="table">
                <caption style="text-align: left;"> 
                    <p> ĐĂNG KÝ </p>
                    <div class="line"></div>
                </caption>
                <tbody>
                    <tr>
                        <td style="width: 40%;">
                            <p> Họ và tên </p>
                            <div class="field-container">    
                                <input id="txt_Fullname" type="text" runat="server" oninput="fullNameField_isValid()" />
                            </div>
                            <small id="small_FullnameAlert"> &nbsp </small>
                        </td>
                        <td rowspan="4" style="width: 10%;">  
                            <div class="border"></div>
                        </td>
                        <td style="width: 40%;">
                            <p> Tên tài khoản </p>
                            <div class="field-container">    
                                <input id="txt_Username" type="text" runat="server" oninput="usernameField_isValid()" />          
                            </div>
                            <small id="small_UsernameAlert" runat="server"> &nbsp </small>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p> Số điện thoại </p>
                            <div class="field-container">
                                <input id="txt_PhoneNumber" type="text" runat="server" oninput="phoneNumberField_isValid()" />                          
                            </div>
                            <small id="small_PhoneNumberAlert" runat="server"> &nbsp </small>
                        </td>
                        <td>
                            <p> Email </p>
                            <div class="field-container">
                                <input id="txt_Email" type="text" runat="server" oninput="emailField_isValid()" />
                            </div>
                            <small id="small_EmailAlert" runat="server"> &nbsp </small>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p> Ngày sinh </p>
                            <div class="birthday-field">                            
                                <input id="txt_Days" type="text" placeholder="Ngày" list="days-list" runat="server" size="4" 
                                    oninput="birthDayField_isValid()" />
                                <datalist id="days-list"></datalist>

                                &nbsp;

                                <input id="txt_Months" type="text" placeholder="Tháng" list="months-list" runat="server" size="4" 
                                    onchange="monthChange()" oninput="birthDayField_isValid()" />
                                <datalist id="months-list"></datalist>

                                &nbsp;

                                <input id="txt_Years" type="text" placeholder="Năm" list="years-list" runat="server" size="4" 
                                    onchange="yearChange()" oninput="birthDayField_isValid()" />
                                <datalist id="years-list"></datalist>
                            </div>
                            <small id="small_BirthDayAlert" runat="server"> &nbsp </small>
                            <small id="cache"></small>
                        </td>
                        <td>
                            <p> Mật khẩu </p>
                            <div class="field-container">                            
                                <input id="txt_Password" type="password" runat="server" oninput="passwordField_isValid()" />
                            </div>
                            <small id="small_PasswordAlert"> &nbsp </small>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p> Giới tính </p> 
                            <div class="gender-field">                               
                                <input id="ckbx_GenderMale"   name="Gender" type="radio"  runat="server" value="Nam" /> <label for="ckbx_GenderMale"> Nam </label> 
                                <input id="ckbx_GenderFemale" name="Gender" type="radio"  runat="server" value="Nữ"/> <label for="ckbx_GenderFemale"> Nữ </label> <br />
                                <input id="ckbx_GenderNone"   name="Gender" type="radio"  runat="server" value="" style="margin-top: 10px;"/> <label for="ckbx_GenderNone" > Không muốn nhắc đến </label>
                            </div>
                        </td>
                        <td>
                            <input id="toggle-button" type="checkbox" onclick="showPassword()" /> 
                            <span> Hiển thị mật khẩu </span>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;">
                            <input id="btn_Submit" type="submit" value="Đăng ký" runat="server" onserverclick="btn_Submit_ServerClick" />
                        </td>
                        <td> </td>
                        <td style="text-align: center;">
                            <input id="btn_Reset" type="reset" value="Nhập lại" />
                        </td>
                    </tr>
                </tbody>
            </table>                
        </div>
    </form>
</body>
</html>


