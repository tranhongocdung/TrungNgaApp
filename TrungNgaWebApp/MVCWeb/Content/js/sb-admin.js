$(function() {
    $(window).bind("load resize", function() {
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
    });
    $(".clear-text").click(function () {
        $(this).parent().parent().children("input").first().val("");
    });
    UILoad.initMVCValidationForBootstrap();
});

var UILoad = {
    initDatePicker: function (selector, funcOnDateChanged) {
        $(selector).each(function () {
            var that = $(this);
            that.datepicker({
                format: "DD dd/mm/yyyy",
                language: "vi",
                autoclose: true,
                orientation: "bottom auto",
                todayHighlight: true
            }).on("changeDate", funcOnDateChanged);
            $(this).parent().find(".remove-date").click(function() {
                that.val("");
            });
        });
    },
    initMVCValidationForBootstrap: function() {
        var defaultOptions = {
            validClass: "has-success",
            errorClass: "has-error",
            highlight: function (element, errorClass, validClass) {
                $(element).closest(".form-group")
                    .removeClass(validClass)
                    .addClass(errorClass);
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).closest(".form-group")
                .removeClass(errorClass)
                .addClass(validClass);
            }
        };

        $.validator.setDefaults(defaultOptions);

        $.validator.unobtrusive.options = {
            errorClass: defaultOptions.errorClass,
            validClass: defaultOptions.validClass
        };
    }
}