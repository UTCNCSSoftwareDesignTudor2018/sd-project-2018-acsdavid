$(document).ready(addBikeReady);

function addBikeReady() {
    $("#addBikeButton").click(addBikeButtonClicked);
}

function addBikeButtonClicked() {
    var addBikeData = {
        Name: $("#addNameOfArticle").val(),
        Description: $("#addDescription").val(),
        Price: $("#addPrice").val(),
        Model: $("#addModel").val()
    };

    if (sessionStorage.getItem(tokenKey) === null) {
        alert("you most log in");
        window.location = "/Login";
    }

    var headers = getAuthHeaders();

    $.ajax({
        type: "POST",
        url: "/api/Bike",
        data: addBikeData,
        headers : headers
    }).done(function (data) {
        alert("bike successfully added");
    }).fail(function (jqXhr) {
        console.log(jqXhr);
        var errorList = getErrorList(jqXhr);
        alert("an error occurred while adding bike: " + errorList);
    });
}
