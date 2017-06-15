$(document).ready(function() {
    bindDatePickerAndButtons();
});

function bindDatePickerAndButtons() {
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
}



