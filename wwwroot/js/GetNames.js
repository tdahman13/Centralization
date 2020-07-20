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
                success: function (data) {
                    console.log("success");
                    console.log(data);
                },
                error: function (response) {
                    alert("Error Check Console.");
                    console.log(response);
                },
                failure: function (response) {
                    alert("Fail Check Console.");
                    console.log(response);
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