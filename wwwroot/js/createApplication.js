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

    // Check form and show modal before submitting
    $("#submitBtn").on("click", function (e) {
        var numberRelated = $(".dead").length;
        if ($(".dead").length <= 0) {
            $("span[data-valmsg-for='MemorialApplication.LinkedInterments']").text("Must add at least one interred.");
            return;
        }
        if ($("#createForm").valid()) {
            $("#confirmModal").modal("show");
        }
    });

    $("#FileUpload").on("change", function () {
        $("#createForm").valid();
    });

    // On cemetery selectlist change, reset related interred
    $("#MemorialApplication_CemNo, #cemeterySearch, #cemetery").on("change", function () {
        var cem = $(this).val();
        $("#MemorialApplication_CemNo, #cemeterySearch, #cemetery").val(cem);
        $("#relatedDeadDisplay").empty();
    });

    // Before modal shows, show form details in body
    $("#confirmModal").on("show.hidden.bs.modal", function (e) {
        var relatedSection = $("#relatedFormInput");
        relatedSection.empty();
        // Set up related Interments
        var n = 0;
        $(".dead").each(function () {
            var dead = $(this);
            var cem = dead.data('cemno');
            var idf = dead.data('idf');
            var inputCemNo = $("<input>").attr("type", "hidden")
                .attr("name", "MemorialApplication.LinkedInterments[" + n + "].CemNo").val(cem);
            var inputIdf = $("<input>").attr("type", "hidden")
                .attr("name", "MemorialApplication.LinkedInterments[" + n + "].Idf").val(idf);
            relatedSection.append(inputCemNo);
            relatedSection.append(inputIdf);
            n++;
        })

        var type = $("#MemorialApplication_Type option:selected").text();
        var uploadBy = $("#MemorialApplication_UploadedBy").val();
        var cem = $("#MemorialApplication_CemNo option:selected").text();

        var html = "<dl class='row'><dt class='col-sm-4'>Application Type</dt><dd class='col-sm-8'>" + type
            + "</dd><dt class='col-sm-4'>Uploaded By</dt><dd class='col-sm-8'>" + uploadBy
            + "</dd><dt class='col-sm-4'>Cemetery</dt><dd class='col-sm-8'>" + cem + "</dd></dl>";
        $(".modal-body").html(html);
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
            // Check if already selected or different cemetery
            if (!canDisplayDead(idf, cemNo))
                return;
            $("span[data-valmsg-for='MemorialApplication.LinkedInterments']").text('');
            var p = $("<p class='dead'>" + ui.item.label + "</p>")
                .attr('data-cemNo', cemNo).attr('data-idf', idf);
            $("#relatedDeadDisplay").append(p);
        }
    });

    // Autocomplete for finding interred (Fullname)
    $("#searchFull").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Search?handler=SearchFullNames",
                type: "GET",
                data: {
                    term: request.term, cemetery: $("#cemeterySearch").val()
                },
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
            // Check if already selected or different cemetery
            if (!canDisplayDead(idf, cemNo))
                return;
            $("span[data-valmsg-for='MemorialApplication.LinkedInterments']").text('');
            var p = $("<p class='dead'>" + ui.item.label + "</p>")
                .attr('data-cemNo', cemNo).attr('data-idf', idf);
            $("#relatedDeadDisplay").append(p);
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
                var orderedList = $("<ul class='resultList'>").append("Result Count: " + data.length)
                    .appendTo(divToReplace);
                $.each(data, function (i, item) {
                    var $tr = $("<li class='resultListItem' onClick='addToDeadList(this)'>")
                        .attr('data-cemNo', item.cemNo).attr('data-idf', item.idf)
                        .append(item.label).appendTo(orderedList);
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

function addToDeadList(obj) {
    var idf = $(obj).attr("data-cemNo");
    var cemNo = $(obj).attr("data-idf");
    var label = $(obj).text();

    // Check if already selected or different cemetery
    if (!canDisplayDead(idf, cemNo))
        return;

    $("span[data-valmsg-for='MemorialApplication.LinkedInterments']").text('');
    var p = $("<p class='dead'>" + label + "</p>")
        .attr('data-cemNo', cemNo).attr('data-idf', idf);
    $("#relatedDeadDisplay").append(p);
}

// Checks display list of interred to make sure no duplicates
function canDisplayDead(idf, cem) {
    var result = true;
    $(".dead").each(function () {
        var dead = $(this);
        var deadCem = dead.data('cemno');
        var deadIdf = dead.data('idf');
        if (cem == deadCem)
            if (idf == deadIdf) {
                result = false;
                return result;
            }
    });
    return result;
}