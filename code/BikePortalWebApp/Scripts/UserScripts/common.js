var tokenKey = "user_token";

function getErrorList(jqXhr) {
    var modelState = jqXhr.responseJSON.ModelState;
    var errorList = [];

    $.each(modelState,
        function(key, value) {
            errorList.push(value);
        });

    return errorList;
}

function getAuthHeaders() {
    var token = sessionStorage.getItem(tokenKey);
    var headers = {};
    if (token) {
        headers.Authorization = "Bearer " + token;
    }

    return headers;
}
