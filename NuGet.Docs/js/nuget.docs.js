$(function () {
    $("#toc-hide").click(function (e) {
        e.preventDefault();
        $("#toc").hide();
        $("#doc").css("margin-right", "0px");
        return false;
    });

    // -- responsive menu --
    $('.nav-toggle').on('click', function (e) {
        $target = $($(this).data('toggle'));
        if ($target) {
            $target.slideToggle();
        }

        $('.nav-toggle').each(function (i, item) {
            $ele = $($(item).data('toggle'));
            if ($ele && !$ele.is($target)) {
                $ele.slideUp();
            }
        });
        e.preventDefault();
    });

    $(window).on('resize', function () {
        var w = $(window).width();

        $('.nav-toggle').each(function (i, item) {
            $target = $($(item).data('toggle'));
            if ($target && w > 600) {
                $target.show();
            } else if ($target && w <= 600 && $target.is(':visible')) {
                $target.slideUp();
            }
        });
    });
    // -- / responsive menu --
});
