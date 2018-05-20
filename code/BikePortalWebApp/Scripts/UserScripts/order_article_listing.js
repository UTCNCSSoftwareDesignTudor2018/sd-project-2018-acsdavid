function formatOrderedArticle(orderedArticle) {
    var article = orderedArticle.Article;
    var link = "/BikeListing/" + article["Id"] + "/Details/";
    var articleName = "<td>" + "<a href='" + link + "'>" + article["Name"] + "</a>" + "</td>";
    var articleQuantity = "<td>" + orderedArticle.Quantity + "</td>";
    var tableRow = "<tr>" + articleName + articleQuantity + "</tr>";
    return tableRow;
}

function orderArticleReady() {
    var orderIdString = $("#orderId").text();
    console.log("orderIdString: " + orderIdString);
    var orderId = parseInt(orderIdString);
    console.log("orderId: " + orderId);

    var data = {
        id: orderId
    };
    var headers = getAuthHeaders();

    $.ajax({
        type: "GET",
        url: "/api/UserOrder/GetOrder/",
        data: data,
        headers : headers
    }).done(function (data) {
        console.log(data);

        var date = data.Date;

        $("#orderDetailsDate").text(date);

        $.each(data.OrderedArticles,
            function(index, orderedArticle) {
                var formattedOrderedArticle = formatOrderedArticle(orderedArticle);
                $("#orderArticleTable").append(formattedOrderedArticle);
            });

    }).fail(function (jqXhr) {
        console.log(jqXhr);
        alert("you must log in to access the orders");
    });
}

$(document).ready(orderArticleReady);
