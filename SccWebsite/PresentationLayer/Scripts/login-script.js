function loginValidate() {
    let username = document.getElementById('txt_Username');
    let password = document.getElementById('txt_Password');

    let isValid = true;

    if (username.value == '') {
        document.getElementById('UsernameError').innerHTML = "Tên đăng nhập không được để trống";
        isValid = false;
    }

    if (password.value == '') {
        document.getElementById('PasswordError').innerHTML = "Mật khẩu không được để trống";
        isValid = false;
    }

    return isValid;
}

function textChange(txtId, txtError, message) {
    const textfield = document.getElementById(txtId);
    if (textfield.value == '') {
        document.getElementById(txtError).textContent = message;
    } else {
        document.getElementById(txtError).innerHTML = "&nbsp";
    }
}

function borderFocus(txtId, otherId) {
    document.getElementById(txtId).style.border = "2px solid #0075ff";
    document.getElementById(otherId).style.border = "none";
}