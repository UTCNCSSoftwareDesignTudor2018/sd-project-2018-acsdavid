$(document).ready(function() {
    $.getJSON("/api/Bike/",
        function(data, status) {
            console.log("data:");
            console.log(data);


            for (var i = 0; i < data.length; i++) {
                var bike = data[i];
                var link = "/BikeListing/" + bike["Id"] + "/Details/";
                var listItem = "<li>" + "<a href='" + link + "'>" + bike["Name"] + "</a>" + "</li>";
                $("ul[name='listOfBikes']").append(listItem);
            }
        });
});