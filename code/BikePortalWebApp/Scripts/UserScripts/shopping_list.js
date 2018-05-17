$(document).ready(shoppingListReady);

function buyAllFromCartClicked() {
    var headers = getAuthHeaders();
    $.ajax({
        type: "POST",
        url: "/api/User/PostBuyAllFromCart",
        headers: headers
    }).done(function() {
        alert("you have bought all items from the shopping cart");
    }).fail(function(jhqxr) {
        alert("an error occoured");
        console.log(jhqxr);
    });
}

function shoppingListReady() {
    if (sessionStorage.getItem(tokenKey) === null) {
        alert("you most log in to access your shopping list");
        window.location = "/Login";
    }

    $("#buyAllFromCart").click(buyAllFromCartClicked);

    var headers = getAuthHeaders();

    $.ajax({
        type: "GET",
        url: "/api/User/GetCartItems",
        headers: headers
    }).done(function (data) {
        console.log("data:");
        console.log(data);

        for (var i = 0; i < data.length; i++) {
            var article = data[i].Article;
            var link = "/BikeListing/" + article["Id"] + "/Details/";
            var listItem = "<li>" + "<a href='" + link + "'>" + article["Name"] + "</a>" + "</li>";
            $("#listOfShoppingItems").append(listItem);
        }
    }).fail(function() {
        alert("you must log in first");
    });
}
