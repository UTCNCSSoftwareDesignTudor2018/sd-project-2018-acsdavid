$(document).ready(loginReady);

function loginReady() {
    $("#loginButton").click(loginButtonClicked);
}

function loginButtonClicked() {
    var loginData = {
        grant_type: "password",
        username: $("#username").val(),
        password: $("#pass").val()
    };

    $.ajax({
        type: "POST",
        url: "/Token",
        data: loginData
    }).done(function (data) {
        //self.user(data.userName);
        // Cache the access token in session storage.
        sessionStorage.setItem(tokenKey, data.access_token);
        console.log("session stored for " + data.userName);
        window.location.replace("/Home/Index");
        }).fail(function (response) {
            console.log(response);
            alert("an error occurred while logging in: " + response.responseJSON.error_description);
    });
}

