function orderListingReady() {
    if (sessionStorage.getItem(tokenKey) === null) {
        alert("you most log in");
        window.location = "/Login";
        return;
    }

    var headers = getAuthHeaders();

    $.ajax({
        type: "GET",
        url: "/api/User/GetOrders",
        headers: headers
    }).done(function (data) {
        console.log("data:");
        console.log(data);

        for (var i = 0; i < data.length; i++) {
            var order = data[i];
            var link = "/OrderList/" + order.Id + "/Details/";
            var listItem = "<li>" + "<a href='" + link + "'>" + "Order: " + order.Id + "</a>" + "</li>";
            $("#orderList").append(listItem);
        }
    }).fail(function() {
        alert("you must log in first");
    });
}

$(document).ready(orderListingReady);
