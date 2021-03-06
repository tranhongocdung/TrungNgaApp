﻿function showMessage(message, messagetype) {
    var cssclass;
    switch (messagetype) {
        case "success":
            cssclass = "alert-success";
            break;
        case "error":
            cssclass = "alert-danger";
            break;
        case "warning":
            cssclass = "alert-warning";
            break;
        default:
            cssclass = "alert-info";
    }
    $("#alert-container").append("<div id=\"alert-div\" class=\"alert fade in text-center " + cssclass + "\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a><span>" + message + "</span></div>");

    setTimeout(function () {
        $("#alert-div").fadeTo(2000, 500).slideUp(500, function () {
            $("#alert-div").remove();
        });
    }, 2000);
}

var digitArr = ["không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"];
function readTensDigit(number, fullRead) {
    var str = "";
    var tensDigit = Math.floor(number / 10);
    var unit = number % 10;
    if (tensDigit > 1) {
        str = " " + digitArr[tensDigit] + " mươi";
        if (unit == 1) {
            str += " mốt";
        }
    } else if (tensDigit == 1) {
        str = " mười";
        if (unit == 1) {
            str += " một";
        }
    } else if (fullRead && unit > 0) {
        str = " lẻ";
    }
    if (unit == 5 && tensDigit >= 1) {
        str += " lăm";
    } else if (unit > 1 || (unit == 1 && tensDigit == 0)) {
        str += " " + digitArr[unit];
    }
    return str;
}
function readNumberBlock(number, fullRead) {
    var str;
    var hundredsDigit = Math.floor(number / 100);
    number = number % 100;
    if (fullRead || hundredsDigit > 0) {
        str = " " + digitArr[hundredsDigit] + " trăm";
        str += readTensDigit(number, true);
    } else {
        str = readTensDigit(number, false);
    }
    return str;
}
function readMilsDigits(number, fullRead) {
    var str = "";
    var milsDigit = Math.floor(number / 1000000);
    number = number % 1000000;
    if (milsDigit > 0) {
        str = readNumberBlock(milsDigit, fullRead) + " triệu";
        fullRead = true;
    }
    var thousandsDigit = Math.floor(number / 1000);
    number = number % 1000;
    if (thousandsDigit > 0) {
        str += readNumberBlock(thousandsDigit, fullRead) + " nghìn";
        fullRead = true;
    }
    if (number > 0) {
        str += readNumberBlock(number, fullRead);
    }
    return str;
}
function readNumber(number) {
    if (number == 0) return digitArr[0];
    var str = "", suffix = "", bilsDigit;
    do {
        bilsDigit = number % 1000000000;
        number = Math.floor(number / 1000000000);
        if (number > 0) {
            str = readMilsDigits(bilsDigit, true) + suffix + str;
        } else {
            str = readMilsDigits(bilsDigit, false) + suffix + str;
        }
        suffix = " tỷ";
    } while (number > 0);
    str = str.substr(1);
    return str.charAt(0).toUpperCase() + str.slice(1);
}