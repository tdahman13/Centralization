$(document).ready(function () {
    "Use Strict";

    // Hide name-search, show location-search
    $("#search-by-location-btn").on("click", function () {
        if ($("#name-search-form").is(":visible")) {
            $("#search-by-name-btn").removeClass("active");
            $("#search-by-location-btn").addClass("active");
            $("#name-search-form").hide();
            $("#location-search-form").show();
            $("#location-search-results").show();
        }
    });
    // Hide location-search, show name-search
    $("#search-by-name-btn").on("click", function () {
        if ($("#location-search-form").is(":visible")) {
            $("#search-by-location-btn").removeClass("active");
            $("#search-by-name-btn").addClass("active");
            $("#location-search-form").hide();
            $("#name-search-form").show();
            $("#location-search-results").hide();
        }
    });

    // Autocomplete for finding interred (Two Names)
    $("#searchName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Search?handler=SearchBothNames",
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
            var idf = ui.item.idf;
            var cemNo = ui.item.cemNo;
            getData(idf, cemNo);
        }
    });

    // Autocomplete for finding interred (Fullname)
    $("#searchFull").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Search?handler=SearchFullNames",
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
            var idf = ui.item.idf;
            var cemNo = ui.item.cemNo;
            getData(idf, cemNo);
        }
    });

    // Get names by location
    $("#location-search-btn").on("click", function () {
        var cem = $("#cemetery").val();
        var grave = $("#grave").val();
        var lot = $("#lot").val();
        var block = $("#block").val();
        var section = $("#section").val();
        $.ajax({
            url: "/Search?handler=SearchLocation",
            type: "GET",
            data: { cemetery: cem, grave: grave, lot: lot, block: block, section: section },
            beforeSend: function () {
                $("#location-search-results").empty();
                $("#loading-image").show();
            },
            success: function (data) {
                var divToReplace = $("#location-search-results");
                var orderedList = $("<ul class='resultList'>").append("Result Count: " + data.length).appendTo(divToReplace);
                $.each(data, function (i, item) {
                    var params = item.idf + ", " + item.cemNo;
                    var $tr = $("<li class='resultListItem' onClick='getData(" + params + ")'>").append(item.label).appendTo(orderedList);
                });
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
    });

    // Reset Location Form
    $("#reset-btn").on("click", function () {
        $("#cemetery").val("05");
        $("#grave").val("");
        $("#lot").val("");
        $("#block").val("");
        $("#section").val("");
    });
});

function getData(idf, cemNo) {
    $.ajax({
        url: "/Search?handler=Data",
        type: "GET",
        timeout: 10000,
        contentType: "application/json;charset=utf-8",
        dataType: "html",
        data: { idf: idf, cemNo: cemNo },
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