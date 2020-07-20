$(document).ready(function () {
    "Use Strict";

    $("#searchName, #searchFull").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Index?handler=Search",
                type: "GET",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                },
                error: function (response) {
                    alert(response);
                },
                failure: function (response) {
                    alert("fail: " + response);
                }
            })
        },
        delay: 500,
        minLength: 2,
        select: function (event, ui) {
            $.ajax({
                url: "/Index?handler=Data",
                type: "GET",
                data: { idf: ui.item.idf, cemNo: ui.item.cemNo },
                beforeSend: clearSearch(),
                success: function (data) {
                    console.log("success");
                    console.log(data);
                    $("#partialGoesHere").append(data);
                },
                error: function (response) {
                    var msg = response.error;
                    showFail(msg);
                },
                failure: function (response) {
                    var msg = response.error;
                    showFail(msg);
                },
                complete: function () {
                    $("#loading-image").hide();
                }
            })
        }
    });
});

// Clears edit forms
function clearInput(obj) {
    var sib = $(obj).prev();
    $(sib).val("");
    $(sib).focus();
}

// Clicking search removes old search values
function clearSearch() {
    "use strict";
    $("#partialGoesHere").empty();
    $("#loading-image").show();
}

// On ajax failure
function showFail(msg) {
    "use strict";
    $("#partialGoesHere").html("<div class='alert alert-danger'>" + msg + "</div>");
}