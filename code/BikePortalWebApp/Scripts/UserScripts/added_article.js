function articleAddedReady() {
    var notifier = $.connection.articleAddedMini;

    notifier.client.broadcastArticleAdded = function() {
        $.notify("A new article has been added", "success");
    }

    $.connection.hub.start();
}

$(document).ready(articleAddedReady);
