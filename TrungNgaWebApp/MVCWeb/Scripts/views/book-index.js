$(document).ready(function () {
    $(window).bind("load resize", function () {
        adjustElementsByScreenSize();
    });
    bindDatePickerAndControls();
    bindSeatControls();
});

function adjustElementsByScreenSize() {
    var width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
    if (width >= 1420) {
        $(".seat").removeAttr("style");
        $(".coach-left").removeAttr("style").removeClass("pr0").addClass("pull-left");
        $(".coach-right").removeAttr("style").removeClass("pl0").addClass("pull-right");
    }
    if (width >= 1000 && width < 1420) {
        $(".seat").css("width", "50%");
        $(".coach-left").removeAttr("style").removeClass("pr0").addClass("pull-left");
        $(".coach-right").removeAttr("style").removeClass("pl0").addClass("pull-right");
    }
    if (width >= 740 && width < 1000) {
        $(".seat").removeAttr("style");
        $(".coach-left").css("width", "100%").addClass("pr0");
        $(".coach-right").css("width", "100%").addClass("pl0");
    }
    if (width >= 500 && width < 740) {
        $(".seat").css("width", "50%");
        $(".coach-left").css("width", "100%").addClass("pr0");
        $(".coach-right").css("width", "100%").addClass("pl0");
    }
    if (width < 500) {
        $(".seat").css("width", "100%");
        $(".coach-left").css("width", "100%").addClass("pr0");
        $(".coach-right").css("width", "100%").addClass("pl0");
    }
}

function bindSeatControls() {
    $(".seat").on("click", function (e) {
        var target = $(e.target);
        if (target.is("button") || target.is("button > span")) {
            return;
        }
        if ($(this).hasClass("selected")) {
            $(this).removeClass("selected");
        } else {
            $(this).addClass("selected");
        }
    });
    $(".seat .button-panel button").on("click", function (e) {
        alert("button is clicked!");
    });
}

function bindDatePickerAndControls() {
    UILoad.initDatePicker("#txtRunDateTemp");
    $("#txtRunDateTemp").datepicker("setDate", $("#hdnLatestDateHavingTransport").val());
    $("#btnNextDate").on("click", function () {
        var date = $("#txtRunDateTemp").datepicker("getDate");
        date.setTime(date.getTime() + (1000 * 60 * 60 * 24));
        $("#txtRunDateTemp").datepicker("setDate", date);
    });

    $("#btnPrevDate").on("click", function () {
        var date = $("#txtRunDateTemp").datepicker("getDate");
        date.setTime(date.getTime() - (1000 * 60 * 60 * 24));
        $("#txtRunDateTemp").datepicker("setDate", date);
    });

    $("#btnReloadBookingContainer").on("click", function() {
        reloadBookingContainer();
    });
}

function reloadBookingContainer() {
    $.ajax({
        method: "POST",
        url: $("#reload-bookingcontainer-url").val(),
        data: { transportId: $("#ddlCurrentTransport").val() },
        beforeSend: function () {
            showMainProgressBar();
        },
        success: function (html) {
            $("#booking-container").html(html);
            adjustElementsByScreenSize();
            bindSeatControls();
            hideMainProgressBar();
        }
    });
}

function showMainProgressBar() {
    $("#divLoadingProgress").show();
    $("#divLoadingProgress img").css("left", ($("#divLoadingProgress").width() - $("#divLoadingProgress img").width()) / 2);
}

function hideMainProgressBar() {
    $("#divLoadingProgress").fadeOut();
}

function editBookInfoBegin() {
    
}

function editBookInfoEnd() {

}