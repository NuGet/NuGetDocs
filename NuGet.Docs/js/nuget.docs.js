

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

function copyButton() {
    var btn = $('<button class="btn btn-sm" data-toggle="tooltip" data-clipboard-snippet><span class="glyphicon glyphicon-copy"></span></button>');
    btn.mouseleave(function() {
        $(this)
            .removeAttr('data-original-title')
            .tooltip('hide');
    });
    return btn;
}

function prepareSnippets() {
    $('code').each(function () {
        var snippet = $(this);
        if (snippet.parent().is('pre')) {
            snippet.parent().addClass('snippet');
            snippet.before(copyButton());
        }
        else if (snippet.parent().is('p')) {
            var lines = snippet.text().split(/\r\n|\r|\n/).length;
            if (lines > 1) {
                snippet.parent().addClass('snippet');
                snippet.before(copyButton());
            }
        }
    });

    $('[data-toggle="tooltip"]').tooltip({title: 'Copy to clipboard'});
}

function prepareClipboard() {
    var clipboardSnippets = new Clipboard('[data-clipboard-snippet]', {
        target: function (trigger) {
            return $(trigger).siblings('code:first').get(0);
        }
    });
    clipboardSnippets.on('success', function (e) {
        e.clearSelection();
        showTooltip(e.trigger, 'Copied!');
    });
    clipboardSnippets.on('error', function (e) {
        showTooltip(e.trigger, fallbackMessage(e.action));
        console.log(e);
    });
}

function showTooltip(elem, msg) {
    $(elem)
        .attr('data-original-title', msg)
        .tooltip('show');
}

function fallbackMessage(action) {
    var actionMsg = '';
    if (/iPhone|iPad/i.test(navigator.userAgent)) {
        actionMsg = 'Not supported on iPhone/iPad';
    } else if (/Mac/i.test(navigator.userAgent)) {
        actionMsg = 'Press ⌘-C to copy';
    } else {
        actionMsg = 'Press Ctrl-C to copy';
    }
    return actionMsg;
}

$(document).ready(function () {

    $(".nano").nanoScroller();

    hljs.initHighlightingOnLoad();

    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
    });

    $('body').scrollspy({
        target: '.bs-docs-sidebar',
        offset: 40
    });

    $("#baseSidebar").affix({
        offset: {
            top: 60
        }
    });

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
    else if (url.indexOf("/guides") != -1) {
        $('#a-Guides').click();
    }
    else if (url.indexOf("/hosting-packages") != -1) {
        $('#a-Hosting-Packages').click();
    }
    else if (url.indexOf("/visual-studio-extensibility") != -1) {
        $('#a-Visual-Studio-Extensibility').click();
    }
    else if (url.indexOf("/policies") != -1) {
        $('#a-Policies').click();
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

    prepareSnippets();
    prepareClipboard();
});

