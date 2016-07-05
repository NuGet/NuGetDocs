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

function prepareList() {
    $('#expList').find('li:has(ul)')
    .click(function (event) {

        if (this == event.target) {
            $(this).toggleClass('expanded');
            $(this).children('ul').toggle('medium');
        }

        return false;
    })
    .addClass('collapsed')
    .children('ul').hide();

    //Create the button funtionality
    $('#expandList')
    .unbind('click')
    .click( function() {
        $('.collapsed').addClass('expanded');
        $('.collapsed').children().show('medium');
    })
    $('#collapseList')
    .unbind('click')
    .click( function() {
        $('.collapsed').removeClass('expanded');
        $('.collapsed').children().hide('medium');
    })
};

$(document).ready(function () {
    $.fx.off = true;
    prepareList();
    var url = window.location.href;
    if (url.indexOf("/tools") != -1)
    {
        $('#a-Tools').click();
    }
    else if (url.indexOf("/schema") != -1) {
        $('#a-Schema').click();
    }
    else if (url.indexOf("/api") != -1) {
        $('#a-API').click();
    }
    else if (url.indexOf("/topics") != -1) {
        $('#a-Topics').click();
    }
    else if (url.indexOf("/host-packages") != -1) {
        $('#a-Host-Packages').click();
    }
    else if (url.indexOf("/visual-studio-extensibility") != -1) {
        $('#a-Visual-Studio-Extensibility').click();
    }
    else if (url.indexOf("/faq-and-policy-documents") != -1) {
        $('#a-FAQ-and-Policy-Documents').click();
    }
    else if (url.indexOf("/create-packages") != -1) {
        $('#a-Create-Packages').click();
    }
    else if (url.indexOf("/consume-packages") != -1) {
        $('#a-Consume-Packages').click();
    }
    else {
        $('#expList').children('li').first().click();
    }
});
