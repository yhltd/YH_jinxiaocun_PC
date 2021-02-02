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
    },
    412: function () {
        
    }
}

function clearCss(className) {
    $(function () {
        $("." + className).css("display", "none");
    })
}

function ajaxUtil(params, success, complete) {
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: params.url,
        beforeSend: function(){
            if (params.loading) loadingOpen();
        },
        data: params.data,
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            success(result)
        },
        error: function (err) {
            if (err.statusText == 'timeout') {
                alert("网络超时，请稍后再试。");
            } else {
                alert("错误！");
            }
        },
        complete: function (XMLHttpRequest, status) {
            if (params.loading) loadingClose();

            if (complete != undefined && complete != null) complete();
        }
    })
}

function loadingOpen() {
    $.messager.progress({
        top: 150,
        title: '提示',
        msg: '正在加载',
        text: ''
    });
}

function loadingClose() {
    $.messager.progress('close')
}