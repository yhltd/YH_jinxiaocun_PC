function myUrl(url) {
    var urls = url.split('/');
    return '../controller/' + urls[0] + '.asmx/' + urls[1];
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
        "yyyy": date.getFullYear(),
        "M": date.getMonth() + 1,
        "d": date.getDate(),
        "H": date.getHours(),
        "m": date.getMinutes(),
        "s": date.getSeconds(),
        "MM": ("" + (date.getMonth() + 101)).substr(1),
        "dd": ("" + (date.getDate() + 100)).substr(1),
        "HH": ("" + (date.getHours() + 100)).substr(1),
        "mm": ("" + (date.getMinutes() + 100)).substr(1),
        "ss": ("" + (date.getSeconds() + 100)).substr(1)
    };
    return format.replace(/(yyyy|MM?|dd?|HH?|ss?|mm?)/g, function () {
        return dict[arguments[0]];
    });
}

function exportExcel(data, columns, exportName) {
    var table = '<table border="1px" cellspacing="0" cellpadding="0">';

    table += '<thead>';
    for (var column in columns) {
        table += '<th>' + columns[column] + '</th>';
    }
    table += '</thead>';

    table += '<tbody>';
    for (var i = 0; i < data.length; i++) {
        table += '<tr>'
        for (var column in columns) {
            var cell = data[i][column];
            if (cell == undefined || cell == null || cell == NaN) cell = "";
            table += '<td>' + cell + '</td>';
        }
        table += '</tr>'
    }
    table += '</tbody>';

    table += '</table>';

    var html = "<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>";
    html += '<meta http-equiv="content-type" content="application/vnd.ms-excel; charset=UTF-8">';
    html += '<meta http-equiv="content-type" content="application/vnd.ms-excel';
    html += '; charset=UTF-8">';
    html += "<head>";
    html += "</head>";
    html += "<body>";
    html += table;
    html += "</body>";
    html += "</html>";
    var uri = 'data:application/vnd.ms-excel;charset=utf-8,' + encodeURIComponent(html);
    var link = document.createElement("a");
    link.href = uri;
    link.style = "visibility:hidden";
    link.download = exportName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

axios.interceptors.response.use(function (response) {
    var data = response.data.d;
    if (data != '') data = JSON.parse(data)

    if (data.code == 200) {
        return data;
    } else if (data.code == 401) {
        alert('身份验证过期，请重新登录。');
        window.parent.location.href = '/';
    } else {
        return data;
    }
}, function (err) {
    return Promise.reject({
        msg: '错误'
    });
})

