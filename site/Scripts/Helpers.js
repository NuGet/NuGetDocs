function RegisterPopupWindow(triggerSelector, PopupWindowSelector) {
    var inWindow = false;
    $(triggerSelector).click(function () {
        $(PopupWindowSelector).toggle("fast");
        $(triggerSelector).toggleClass("active");
        return false;
    });

    $(PopupWindowSelector).hover(function () {
        inWindow = true;
    }, function () {
        inWindow = false;
    });

    $(triggerSelector).hover(function () {
        inWindow = true;
    }, function () {
        inWindow = false;
    });

    $("body").mouseup(function () {
        if (!inWindow) {
            $(triggerSelector).removeClass("active")
            $(PopupWindowSelector).hide("fast");
        }
    });
}
