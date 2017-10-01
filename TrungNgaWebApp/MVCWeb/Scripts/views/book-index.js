var selectedSeatList = {
    data: [],
    passengerId: 0,
    contain: function(obj) {
        var seatObj;
        if (obj.hasClass("seat")) {
            seatObj = obj;
        } else {
            seatObj = obj.closest(".seat");
        }
        var json = {
            TransportId: getCurrentTransport(),
            SeatId: seatObj.data("seat-id")
        };
        var hasMatch = false;
        for (var index = 0; index < this.data.length; ++index) {
            var seat = this.data[index];
            if (seat.TransportId == json.TransportId && seat.SeatId == json.SeatId) {
                hasMatch = true;
                break;
            }
        }
        return hasMatch;
    },
    clear: function() {
        this.data = [];
    },
    add: function(obj) {
        var seatObj;
        if (obj.hasClass("seat")) {
            seatObj = obj;
        } else {
            seatObj = obj.closest(".seat");
        }
        if (!this.contain(obj)) {
            var json = {
                TransportId: getCurrentTransport(),
                SeatId: seatObj.data("seat-id")
            };
            this.data.push(json);
        }
    },
    remove: function(obj) {
        var seatObj;
        if (obj.hasClass("seat")) {
            seatObj = obj;
        } else {
            seatObj = obj.closest(".seat");
        }
        var json = {
            TransportId: getCurrentTransport(),
            SeatId: seatObj.data("seat-id")
        };
        for (var index = 0; index < this.data.length; ++index) {
            var seat = this.data[index];
            if (seat.TransportId == json.TransportId && seat.SeatId == json.SeatId) {
                this.data.splice(index, 1);
                return;
            }
        }
    }
};


var editMode;

/*Constants*/
var EDIT_SEAT_INFO = 1;
var MOVE_SEAT = 2;


$(document).ready(function () {
    $(window).bind("load resize", function () {
        adjustElementsByScreenSize();
    });
    bindDatePickerAndControls();
    bindSeatControls();
    $("#test-modal").click(function() {
        $.ajax({
            method: "GET",
            url: $("#edit-bookinfo-url").val(),
            data: { id: $(this).data("customer-id") },
            success: function (html) {
                $("#modal-container").html(html);
                $("#edit-bookinfo-modal").modal();
                adjustElementsByScreenSize();
            }
        });
    });
});

function adjustElementsByScreenSize() {
    var width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
    if (width >= 1420) {
        $(".seat").removeAttr("style");
        $(".coach-left").removeAttr("style").removeClass("pr0").addClass("pull-left");
        $(".coach-right").removeAttr("style").removeClass("pl0").addClass("pull-right");
        $("#edit-bookinfo-modal > .modal-dialog").addClass("modal-md");
    }
    if (width >= 1000 && width < 1420) {
        $(".seat").css("width", "50%");
        $(".coach-left").removeAttr("style").removeClass("pr0").addClass("pull-left");
        $(".coach-right").removeAttr("style").removeClass("pl0").addClass("pull-right");
        $("#edit-bookinfo-modal > .modal-dialog").addClass("modal-md");
    }
    if (width >= 740 && width < 1000) {
        $(".seat").removeAttr("style");
        $(".coach-left").css("width", "100%").addClass("pr0");
        $(".coach-right").css("width", "100%").addClass("pl0");
        $("#edit-bookinfo-modal > .modal-dialog").addClass("modal-md");
    }
    if (width >= 500 && width < 740) {
        $(".seat").css("width", "50%");
        $(".coach-left").css("width", "100%").addClass("pr0");
        $(".coach-right").css("width", "100%").addClass("pl0");
        $("#edit-bookinfo-modal > .modal-dialog").removeClass("modal-md");
    }
    if (width < 500) {
        $(".seat").css("width", "100%");
        $(".coach-left").css("width", "100%").addClass("pr0");
        $(".coach-right").css("width", "100%").addClass("pl0");
        $("#edit-bookinfo-modal > .modal-dialog").removeClass("modal-md");
    }
    if (width > 765) {
        $(".seat-list").removeClass("list-group-horizontal");
    } else {
        $(".seat-list").addClass("list-group-horizontal");
    }
}

function bindSeatControls() {
    $(".seat").on("click", function (e) {
        var target = $(e.target);
        if (target.is("button") || target.is("button > span")) {
            return;
        }
        if ($(this).hasClass("selected")) {
            //Un-select the current seat
            $(this).removeClass("selected");
            selectedSeatList.remove($(this));
        } else {
            //Select the current seat
            var passengerId = $(this).data("passenger-id");
            if (passengerId != "") {
                //This seat contains passenger info
                if (selectedSeatList.passengerId != passengerId) {
                    //This seat contains passenger info which is different from ones in list
                    $(".seat").removeClass("selected");
                    $(".seat[data-passenger-id=" + passengerId + "]").addClass("selected");
                    selectedSeatList.passengerId = passengerId;
                    selectedSeatList.clear();
                    $(".seat[data-passenger-id=" + passengerId + "]").each(function() {
                        selectedSeatList.add($(this));
                    });
                } else {
                    //This seat with passenger info was un-selected then re-select
                    $(this).addClass("selected");
                    selectedSeatList.add($(this));
                }
            } else {
                //This seat is empty
                if (selectedSeatList.passengerId != 0) {
                    //Remove all seats with passenger info in list
                    $(".seat").removeClass("selected");
                    selectedSeatList.passengerId = 0;
                    selectedSeatList.clear();
                }
                $(this).addClass("selected");
                selectedSeatList.add($(this));
            }
        }
    });

    $(".seat .button-panel .btn-book-seat").on("click", function (e) {
        var seat = $(this).closest(".seat");
        if (!seat.hasClass("selected")) {
            seat.click();
        }
        $(this).parent().find("img").show();
        $.ajax({
            url: $("#book-seats-url").val(),
            data: {
                seatListJson: JSON.stringify(selectedSeatList.data)
            },
            success: function () {
                $("#btnReloadBookingContainer").click();
            }
        });
    });

    $(".seat .button-panel .btn-update-bookinfo").on("click", function (e) {
        var seat = $(this).closest(".seat");
        if (!seat.hasClass("selected")) {
            seat.click();
        }
        $.ajax({
            method: "POST",
            url: $("#edit-bookinfo-url").val(),
            data: {
                clickedSeatId: seat.data("seat-id"),
                seatListJson: JSON.stringify(selectedSeatList.data),
                transportId: getCurrentTransport()
            },
            success: function (html) {
                $("#modal-container").html(html);
                $("#edit-bookinfo-modal").modal();
                adjustElementsByScreenSize();
                initBookInfoEdit();
            }
        });
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
        data: { transportId: getCurrentTransport() },
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

function getCurrentTransport() {
    return $("#ddlCurrentTransport").val();
}

function initBookInfoEdit() {
    //Passenger PhoneNo
    var passengers = new Bloodhound({
        datumTokenizer: function (data) {
            return Bloodhound.tokenizers.whitespace(data.PassengerPhoneNo);
        },
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            wildcard: "%QUERY",
            url: $("#passenger-suggestion-datasource").val() + "?query=%QUERY",
            transform: function (passengers) {
                return $.map(passengers, function (passenger) {
                    return passenger;
                });
            }
        }
    });

    $("#txtPassengerPhoneNo").typeahead({
        hint: false,
        highlight: true,
        minLength: 3
    }, {
        displayKey: "SuggestPhoneNoFull",
        name: "passengers",
        source: passengers
    });

    $("#txtPassengerPhoneNo").bind("typeahead:selected", function (obj, data) {
        $(this).typeahead("val", data.PassengerPhoneNo);
        $("#passenger-id").val(data.Id);
        $("#txtPassengerName").val(data.PassengerName);
    });

    //Pickup Location
    var pickUpLocations = new Bloodhound({
        datumTokenizer: function (data) {
            return Bloodhound.tokenizers.whitespace(data.Address);
        },
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            wildcard: "%QUERY",
            url: $("#pickuplocation-suggestion-datasource").val() + "?query=%QUERY",
            transform: function (pickUpLocations) {
                return $.map(pickUpLocations, function (pickUpLocation) {
                    return pickUpLocation;
                });
            }
        }
    });

    $("#txtPickUpLocation").typeahead({
        hint: true,
        highlight: true,
        minLength: 3
    }, {
        displayKey: "Address",
        name: "pickUpLocations",
        source: pickUpLocations
    });

    $("#txtPickUpLocation").bind("typeahead:selected", function (obj, data) {
        $(this).typeahead("val", data.Address);
        $("#pickuplocation-id").val(data.Id);
    });
}

