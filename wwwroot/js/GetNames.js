$(document).ready(function () {
    "Use Strict";

    // Autocomplete for finding interred (Two Names)
    $("#searchName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Index?handler=SearchBothNames",
                type: "GET",
                data: { term: request.term, cemetery: $("#cemeterySearch").val() },
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
        delay: 600,
        minLength: 2,
        select: function (event, ui) {
            getData(ui);
        }
    });

    // Autocomplete for finding interred (Fullname)
    $("#searchFull").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Index?handler=SearchFullNames",
                type: "GET",
                data: { term: request.term, cemetery: $("#cemeterySearch").val() },
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
        delay: 600,
        minLength: 2,
        select: function (event, ui) {
            getData(ui);
        }
    });

    // Hide name-search, show location-search
    $("#search-by-location-btn").on("click", function () {
        if ($("#name-search-form").is(":visible")) {
            $("#search-by-name-btn").removeClass("active");
            $("#search-by-location-btn").addClass("active");
            $("#name-search-form").hide();
            $("#location-search-form").show();
        }
    });
    // Hide location-search, show name-search
    $("#search-by-name-btn").on("click", function () {
        if ($("#location-search-form").is(":visible")) {
            $("#search-by-location-btn").removeClass("active");
            $("#search-by-name-btn").addClass("active");
            $("#location-search-form").hide();
            $("#name-search-form").show();
        }
    });
});

function getData(ui) {
    $.ajax({
        url: "/Index?handler=Data",
        type: "GET",
        timeout: 10000,
        contentType: "application/json;charset=utf-8",
        dataType: "html",
        data: { idf: ui.item.idf, cemNo: ui.item.cemNo },
        beforeSend: clearSearch(),
        success: function (data) {
            $("#partialGoesHere").append(data);
            popUp();
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
    $("#loading-image").hide();
}

function popUp() {
    "use strict";
    $('.with-caption').magnificPopup({
        type: 'image',
        closeBtnInside: false,
        mainClass: 'mfp-with-zoom mfp-img-mobile',
        closeOnContentClick: true,
        image: {
            verticalFit: true,
            tError: '<a href="%url%">The image</a> could not be loaded.' // Error message
        },
        gallery: {
            enabled: true
        },
        closeMarkup: '<button type="button" class="mfp-close">&#215;</button>'
    });
}