function buildComment(index, comment) {
    var item = "<li>" + comment.CommentText + " " + comment.Date + "</li>";
    $("#commentList").append(item);
}

function bikeListingReady() {
    var bikeIdString = $("#bikeId").text();
    console.log("bikeIdString: " + bikeIdString);
    var bikeId = parseInt(bikeIdString);
    console.log("bikeId: " + bikeId);

    // load bike data
    $.getJSON("/api/Bike/" + bikeId + "/Get",
        function (bike, status) {
            console.log("data:");
            console.log(bike);

            $("#name").text(bike["Name"]);
            $("#description").text(bike["Description"]);
            $("#price").text(bike["Price"]);
            $("#model").text(bike["Model"]);
        });

    // load comments for bike
    $.getJSON("/api/Bike/" + bikeId + "/GetComments",
        function (comments, status) {
            console.log("comments:");
            console.log(comments);

            $.each(comments, buildComment);
        });

    $("#addToCart").click(function() {
        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = "Bearer " + token;
        }

        $.ajax({
            type: "POST",
            url: "/api/Bike/" + bikeId + "/PostPutInShoppingCart",
            headers: headers
        }).done(function () {
            alert("bike added to cart");
        }).fail(function() {
            alert("you must log in first");
        });
    });

    $("#postCommentButton").click(function() {
        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = "Bearer " + token;
        }

        var data = {
            commentText: $("#commentTextBox").val()
        };

        $.ajax({
            type: "POST",
            url: "/api/Bike/" + bikeId + "/PostComment",
            headers: headers,
            data: data
        }).done(function () {
            alert("comment posted successfully");
        }).fail(function(response) {
            alert("you must log in first");
        });
    });
}

$(document).ready(bikeListingReady);