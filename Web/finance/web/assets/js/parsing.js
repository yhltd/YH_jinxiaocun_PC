function getJson(xml) {
    var result = JSON.parse(jQuery(xml).text())
    checkResult[result.code]();
    return result;
}

var checkResult = {
    200: function (result){
        
    },
    402: function (result) {
        alert("无效的token")
    },
    500: function (result) {
        alert("错误！")
    },
    401: function (result) {
        var pathName = window.location.pathname
        if (pathName == "index.aspx") {
            window.location.href = "invalid.aspx"
        } else {
            window.parent.location.href = "invalid.aspx"
        }
    }
}

function clearCss(className) {
    $(function () {
        $("." + className).css("display", "none");
    })
}