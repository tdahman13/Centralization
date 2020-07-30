$(document).ready(function () {
    "Use Strict";

    // Before modal shows, show form details in body
    $("#confirmModal").on("show.hidden.bs.modal", function (e) {
        var type = $("#MemorialApplication_Type option:selected").text();
        var uploadBy = $("#MemorialApplication_UploadedBy").val();
        var idf = $("#MemorialApplication_Idf").val();
        var cem = $("#MemorialApplication_CemNo option:selected").text();

        var html = "<dl class='row'><dt class='col-sm-4'>Application Type</dt><dd class='col-sm-8'>" + type
            + "</dd><dt class='col-sm-4'>Uploaded By</dt><dd class='col-sm-8'>" + uploadBy
            + "</dd><dt class='col-sm-4'>Interred IDF</dt><dd class='col-sm-8'>" + idf
            + "</dd><dt class='col-sm-4'>Cemetery</dt><dd class='col-sm-8'>" + cem + "</dd></dl>";
        $(".modal-body").html(html);
    })

    $("#submitBtn").on("click", function (e) {
        if ($("#createForm").valid()) {
            $("#confirmModal").modal("show");
        } 
    })

    $("#FileUpload").on("change", function () {
        $("#createForm").valid();
    })
});