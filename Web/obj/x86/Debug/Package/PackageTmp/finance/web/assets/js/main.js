var height = window.innerHeight;
var width = window.innerWidth;

$(function () {
    $("#main").css({ "height": height + "px", "width": width + "px" })
    $("#main-item").css({ "height": height + "px", "width": width - 20 + "px" })
})

function formToJson(data) {
    data = data.replace(/&/g, "\",\"").replace(/=/g, "\":\"").replace(/\+/g, " ").replace(/[\r\n]/g, "<br>");
    data = "{\"" + data + "\"}";
    return data;
}

function formatDate(date, format) {
	if (!date) return;
	if (!format)
		format = "yyyy-MM-dd";
	switch (typeof date) {
	case "string":
		date = new Date(date.replace(/-/, "/"));
		break;
	case "number":
		date = new Date(date);
		break;
	}
	if (!date instanceof Date) return;
	var dict = {
		"yyyy" : date.getFullYear(),
		"M" : date.getMonth() + 1,
		"d" : date.getDate(),
		"H" : date.getHours(),
		"m" : date.getMinutes(),
		"s" : date.getSeconds(),
		"MM" : ("" + (date.getMonth() + 101)).substr(1),
		"dd" : ("" + (date.getDate() + 100)).substr(1),
		"HH" : ("" + (date.getHours() + 100)).substr(1),
		"mm" : ("" + (date.getMinutes() + 100)).substr(1),
		"ss" : ("" + (date.getSeconds() + 100)).substr(1)
	};
	return format.replace(/(yyyy|MM?|dd?|HH?|ss?|mm?)/g, function() {
		return dict[arguments[0]];
	});
}

//var alertNum = 0

//function alert(msg) {
//    var getAlert = function (_id) {
//        var $_alert = document.createElement("div");
//        var $_alert_child = document.createElement("div");
//        $_alert.id = _id
//        $_alert.className = 'alert'
//        $_alert.innerText = msg
//        $_alert_child.className = 'alert-close'
//        $_alert.appendChild($_alert_child)
//        return $_alert;
//    }

//    var _id = "alert" + alertNum
//    document.body.appendChild(getAlert(_id));
//    var $alert = $("#" + _id)

//    var getTop = function (num) {
//        if (num == 0) {
//            return 16;
//        } else {
//            return num * 70 + 16;
//        }
//    }

//    $alert.css({
//        zIndex: 10001+alertNum,
//        top: getTop(alertNum) + "px"
//    })

//    alertNum++;

//    $alert.animate({
//        right: '20px'
//    }, 200, "linear", function () {
//        //setTimeout(function () {
//        //    alert.animate({
//        //        opacity: 0
//        //    }, 300, "linear", function () {
//        //        alert.remove();
//        //    })
//        //},1000)
//    });
//}