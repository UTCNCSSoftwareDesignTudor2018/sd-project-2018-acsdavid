$(document).ready(registerReady);

function registerReady() {
    $("#registerButton").click(registerButtonClicked);
}

function registerButtonClicked() {
    var registerData = {
        Email: $("#registerEmail").val(),
        Password: $("#registerPass").val(),
        ConfirmPassword: $("#registerConfirmPass").val(),
        FirstName: $("#registerFirstName").val(),
        LastName: $("#registerLastName").val()
};

    $.ajax({
        type: "POST",
        url: "/api/Account/Register",
        data: registerData
    }).done(function (data) {
        console.log("session stored for " + data.userName);
        window.location.replace("/Login/");
    }).fail(function (jqXhr) {
        var errorList = getErrorList(jqXhr);           
        alert("error(s) occurred while registering: " + errorList);
    });
}

