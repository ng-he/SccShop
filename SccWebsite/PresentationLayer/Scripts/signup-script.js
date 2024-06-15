const daysInMonths = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

window.onload = function () {
    $('#form_SignUp').on('submit', function () {
        let validArray = [
            fullNameField_isValid(),
            phoneNumberField_isValid(),
            birthDayField_isValid(),
            usernameField_isValid(),
            emailField_isValid(),
            passwordField_isValid()
        ];

        return !validArray.includes(false);
    });

    let loginRedirectConfirm_Visible = document.getElementById('hidden_SignUpSuccessMessage').value;

    if (loginRedirectConfirm_Visible == 'true') {
        loginRedirectConfirmAppear();
    } else {
        loginRedirectConfirmDisappear();
    }

    $('input').on('focus', function () {
        $(this).parent('.field-container').css('border', '2px solid #0075ff');
    });

    $('input').on('blur', function () {
        $(this).parent('.field-container').css('border', 'none');
    });

    $('#txt_Days').on('focus', function () {
        $(this).css('outline', '2px solid #0075ff');
    });

    $('#txt_Months').on('focus', function () {
        $(this).css('outline', '2px solid #0075ff');
    });

    $('#txt_Years').on('focus', function () {
        $(this).css('outline', '2px solid #0075ff');
    });

    $('#txt_Days').on('blur', function () {
        $(this).css('outline', 'none');
    });

    $('#txt_Months').on('blur', function () {
        $(this).css('outline', 'none');
    });

    $('#txt_Years').on('blur', function () {
        $(this).css('outline', 'none');
    });

    const yearsList = document.getElementById("years-list");
    const monthsList = document.getElementById("months-list");
    const todayYear = new Date().getFullYear();

    for (let i = 1930; i <= todayYear; i++) {
        yearsList.innerHTML += '<option value="' + i.toString() + '"></option>';
    }

    for (let i = 1; i <= 12; i++) {
        monthsList.innerHTML += '<option value="' + i.toString() + '"></option>';
    }
}

function isLeapYear(year) {
    year = Number.parseInt(year);
    return ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0));
}

function yearChange() {
    const selectedYear = document.getElementById("txt_Years").value;
    const selectedMonths = document.getElementById("txt_Months").value;

    if (isLeapYear(selectedYear)) {
        daysInMonths[1] = 29;
    } else {
        daysInMonths[1] = 28;
    }

    if (selectedMonths == 2) {
        const daysList = document.getElementById("days-list");

        daysList.options.length = 0;

        for (let i = 1; i <= daysInMonths[1]; i++) {
            daysList.innerHTML += '<option value="' + i.toString() + '"></option>';
        }
    }
}

function monthChange() {
    const selectedMonths = Number.parseInt(document.getElementById("txt_Months").value);
    const daysList = document.getElementById("days-list");

    daysList.options.length = 0;

    for (let i = 1; i <= daysInMonths[selectedMonths - 1]; i++) {
        daysList.innerHTML += '<option value="' + i.toString() + '"></option>';
    }
}

function fullNameField_isValid() {
    const fullname = document.getElementById("txt_Fullname").value;
    const alertField = document.getElementById("small_FullnameAlert");

    if (fullname == '') {
        alertField.innerHTML = "Họ và tên không được để trống";
        return false;
    }

    if (fullname.search(/[-$&+,:;=?@#|'<>.^*()%!0-9]/) != -1) {
        alertField.innerHTML = "Họ và tên không được chứa chữ số hay các ký tự đặc biệt";
        return false;
    }

    if (fullname.length < 3) {
        alertField.innerHTML = "Họ và tên phải có ít nhất 3 ký tự";
        return false;
    }

    if (fullname.split(" ").length < 2) {
        alertField.innerHTML = "Họ và tên phải có ít nhất 2 từ";
        return false;
    }

    alertField.innerHTML = "&nbsp";
    return true;
}

function phoneNumberField_isValid() {
    const phoneNumber = document.getElementById("txt_PhoneNumber").value;
    const alertField = document.getElementById("small_PhoneNumberAlert");

    if (phoneNumber == '') {
        alertField.innerHTML = "Số điện thoại không được để trống";
        return false;
    }

    if (phoneNumber.search(/[^0-9]/) != -1) {
        alertField.innerHTML = "Số điện thoại chỉ được chứa số";
        return false;
    }

    alertField.innerHTML = "&nbsp";
    return true;
}

function DateFormatIsValid(strDay, strMonth, strYear) {
    let day = 0, month = 0, year = 0;

    try {
        day = Number.parseInt(strDay);
        month = Number.parseInt(strMonth);
        year = Number.parseInt(strYear);
    } catch (err) {
        return false;
    }

    if ((strDay != day.toString()) || (strMonth != month.toString()) || (strYear != year.toString())) {
        return false;
    }

    return (day > 0 && day <= daysInMonths[month - 1]) && (month > 0 && month <= 12) && (year > 0);
}

function birthDayField_isValid() {
    const day = document.getElementById("txt_Days").value;
    const month = document.getElementById("txt_Months").value;
    const year = document.getElementById("txt_Years").value;
    const alertField = document.getElementById("small_BirthDayAlert");
    let isValid = true;

    if (day == '' || month == '' || year == '') {
        alertField.innerHTML = "Ngày, tháng hoặc năm không được để trống";
        return false;
    }

    if (!DateFormatIsValid(day, month, year)) {
        alertField.innerHTML = "Ngày, tháng hoặc năm không đúng định dạng";
        return false;
    }

    alertField.innerHTML = "&nbsp";
    return true;
}

function usernameField_isValid() {
    const username = document.getElementById("txt_Username").value;
    const alertField = document.getElementById("small_UsernameAlert");

    if (username == '') {
        alertField.innerHTML = "Tên đăng nhập không được để trống";
        return false;
    }

    if (username.length < 6) {
        alertField.innerHTML = "Tên đăng nhập phải ít nhất 6 ký tự";
        return false;
    }

    if (username.search(/\s/) != -1) {
        alertField.innerHTML = "Tên đăng nhập không được chứa dấu cách";
        return false;
    }

    if (username.search(/[^0-9A-Za-z]/) != -1) {
        alertField.innerHTML = "Tên đăng nhập chỉ được chứa chữ cái và chữ số";
        return false;
    }

    alertField.innerHTML = "&nbsp";
    return true;
}

function emailField_isValid() {
    const email = document.getElementById("txt_Email").value;
    const alertField = document.getElementById("small_EmailAlert");

    if (email.length == '') {
        alertField.innerHTML = "Email không được bỏ trống";
        return false;
    }

    if (email.search(/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/) == -1) {
        alertField.innerHTML = "Email không đúng định dạng";
        return false;
    }

    alertField.innerHTML = "&nbsp";
    return true;
}

function passwordField_isValid() {
    const password = document.getElementById("txt_Password").value;
    const alertField = document.getElementById("small_PasswordAlert");
    const cache = document.getElementById("cache");

    if (password == '') {
        alertField.innerHTML = "Mật khẩu không được để trống";
        return false;
    }

    if (password.length < 8) {
        alertField.innerHTML = "Mật khẩu phải có ít nhất 8 ký tự";
        return false;
    }

    if (password.search(/[a-z]/) == -1 ||
        password.search(/[A-Z]/) == -1 ||
        password.search(/[0-9]/) == -1 ||
        password.search(/[^a-zA-Z0-9]/) == -1) {

        alertField.innerHTML = "Mật khẩu phải bao gồm số, chữ thường, chữ in hoa và ký tự đặc biệt.";
        return false;
    }

    alertField.innerHTML = "&nbsp";
    return true;
}

function showPassword() {
    const passwordField = document.getElementById("txt_Password");

    if (passwordField.type === 'password') {
        passwordField.type = 'text';
    } else {
        passwordField.type = 'password';
    }
}

function loginRedirectConfirmAppear() {
    document.getElementsByClassName("login-redirect-container")[0].style.display = "flex";
}

function loginRedirectConfirmDisappear() {
    document.getElementsByClassName("login-redirect-container")[0].style.display = "none";
}