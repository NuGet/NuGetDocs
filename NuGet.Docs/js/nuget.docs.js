$(function () {
    $("#toc-hide").click(function (e) {
        e.preventDefault();
        $("#toc").hide();
        $("#doc").css("margin-right", "0px");
        return false;
    });
});
