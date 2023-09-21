var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}
var quanxian_id;

$(function () {
    getCha();
})

function getList() {
    var a = 1;
    ajaxUtil({
        url: "web_service/user_management.asmx/getList",
        loading: true,
        data: {
            financePageJson: JSON.stringify(page)
        }
    }, function (result) {
        if (result.code == 200) {
            setTable(result.data)
        }
    });
}



function getCha() {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.zhgl_select == "是") {
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
}



//设置表格信息
function setTable(data) {
    $('#data-table').datagrid({
        fitColumns: false,
        toolbar: [{
            text: '新增',
            iconCls: 'icon-add',
            handler: function () {

                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.zhgl_add == "是") {
                            $('#new').window({
                                title: "新增",
                                width: 600,
                                height: 400,
                                top: 20,
                                collapsible: false,
                                minimizable: false,
                                maximizable: false,
                                closable: true,
                                draggable: true,
                                resizable: false,
                                shadow: false,
                                modal: true,
                                onClose: function () {
                                    toResetNew();
                                }
                            });
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });

                
            }
        }, '-', {
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.zhgl_update == "是") {

                            var sels = getSelected();
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                update(sels[0])
                            }

                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
            }
        }, '-', {
            text: '删除',
            iconCls: 'icon-remove',
            handler: function (e) {

                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.zhgl_delete == "是") {
                            var sels = getSelected();
                            if (sels.length == 0) {
                                alert('请至少选择一行数据');
                            } else {
                                del(sels)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });

                
            }
        }, '-', {
            text: '权限',
            iconCls: 'icon-edit',
            handler: function (e) {

                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.zhgl_update == "是") {
                            var sels = getSelected();
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                quan_load(sels[0])
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });


                
            }
        }, '-', {
            text: '二维码',
            iconCls: 'icon-edit',
            handler: function (e) {

                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.zhgl_select == "是") {
                            var sels = getSelected();
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                console.log(sels[0])
                                qr_make(sels[0].name,sels[0].pwd,sels[0].company)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });



            }
        }],
        data: data.pageList,
        //height: 470,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'rownum', align: 'center', title: '序号', width: 100 },
            { field: 'name', align: 'center', title: '账号', width: 300 },
		    { field: 'pwd', align: 'center', title: '密码', width: 300 },
            { field: 'do', align: 'center', title: '操作密码', width: 300 },
        ]]
    })

    $("#data-page").pagination({
        total: data.total,
        pageSize: data.pageSize,
        onSelectPage: function (pageNumber, pageSize) {
            page.currentPage = pageNumber;
            page.pageSize = pageSize;
            getList()
        },
        onRefresh: function (pageNumber, pageSize) {
            page.currentPage = pageNumber;
            page.pageSize = pageSize;
        }
    })
}


function del(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }

    ajaxUtil({
        url: "web_service/user_management.asmx/delete",
        loading: true,
        data: {
            idsJson: JSON.stringify(ids)
        }
    }, function (result) {
        if (result.code == 200) {
            alert(result.msg);
            getList();
        }
    });
}

function getSelected() {
    return $('#data-table').datagrid("getSelections");
}

function update(rowItem) {
    $('#update').window({
        title: "修改",
        width: 600,
        height: 600,
        top: 100,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        draggable: true,
        resizable: false,
        shadow: false,
        modal: true
    });
    $("#updateForm").form('load', rowItem );
}

    //确认修改
function toUpd() {
    var updatePwdForm = $('#updateForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)))
    if (checkForm(params)) {
        var item = getSelected()[0]
        item.name = params.name;
        item.pwd = params.pwd;
        item.do = params.do;

        ajaxUtil({
            url: "web_service/user_management.asmx/update",
            loading: true,
            data: {
                newUserJson: JSON.stringify(item)
            }
        }, function (result) {
            if (result.code == 200) {
                alert(result.msg)
                $('#update').window('close');
                getList();
            }
        });
    }
}

function checkForm(params) {
    if (params.name == "") {
        alert("请输入账号")
        return false;
    } else if (params.pwd == "") {
        alert("请输入密码")
        return false;
    } else if (params.do == "") {
        alert("请输入操作密码")
        return false;
    }
    return true;
}


function toResetNew() {
    $("#newForm").form('reset');
}

function toNew() {
    var updatePwdForm = $('#newForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)));
    if (checkForm(params)) {
        ajaxUtil({
            url: "web_service/user_management.asmx/add",
            loading: true,
            data: {
                userJson: JSON.stringify(params)
            }
        }, function (result) {
            if (result.code == 200) {
                console.log(result)
                alert(result.msg);
                $('#new').window('close');
                getList();
            }
        });
    }
}

function quan_load(rowItem) {

    ajaxUtil({
        url: "web_service/user_management.asmx/getquanxian",
        loading: true,
        data: {
            quanxianJson: JSON.stringify(rowItem)
        }
    }, function (result) {
        if (result.code == 200) {
            quanxian_id = result.data.id
            $('#qxupdate').window({
                title: "修改",
                width: 1200,
                height: 500,
                top: 70,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                closable: true,
                draggable: true,
                resizable: false,
                shadow: false,
                modal: true
            });
            $("#qxForm").form('load', result.data);
        }
    });
}


function qxUpd() {
    var updateQXForm = $('#qxForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updateQXForm, true)))
    var item = getSelected()[0]
    var bianhao = item.bianhao
    ajaxUtil({
        url: "web_service/user_management.asmx/updateQX",
        loading: true,
        data: {
            bianhao: bianhao,
            quanxian: JSON.stringify(params)
        }
    }, function (result) {
        if (result.code == 200) {
            alert(result.msg)
            $('#qxupdate').window('close');
            getList();
        }
    });
}

//清空修改框
function toReset() {
    $("#updateForm").form('reset');
}

//查询
function sel() {
    var username = $("#username").val();
    ajaxUtil({
        url: "web_service/user_management.asmx/queryList",
        loading: true,
        data: {
            financePageJson: JSON.stringify(page),
            username: username,
        }
    }, function (result) {
        if (result.code == 200) {
            setTable(result.data)
        }
    });
}

function qr_make(name, password, gongsi) {
    console.log(name)
    console.log(password)
    console.log(gongsi)
    var url = window.top.location.href
    console.log(url)
    var str = name + "`" + password + "`" + gongsi + "`" + "云合未来财务系统"
    $.ajax({
        type: "post", //要用post方式     
        url: "/Myadmin/HouTai/YongHuGuanli.aspx/EncryptAes",
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        data: JSON.stringify({
            source: str,
        }),
        success: function (data) {
            console.log(data)
            console.log(window.top.location.href)
            var this_url = window.top.location.href.replace("/finance/web/view/index.aspx", "/Myadmin/login.aspx")
            console.log(this_url)
            this_url = this_url + "?user=" + data.d
            console.log(this_url)
            var qrcode_container = document.getElementById('qrcode');
            // 生成二维码
            var qrcode = new QRCode(qrcode_container, {
                text: this_url, // 二维码中的内容
                width: 200, // 二维码的宽度
                height: 200, // 二维码的高度
                colorDark: "#000000", // 二维码的颜色
                colorLight: "#ffffff", // 二维码的背景色
            });
            var base64_qrcode = qrcode_container.firstChild.toDataURL("image/png");
            console.log(base64_qrcode)
            downloadFileByBase64(name + ".png", base64_qrcode.split(",")[1])
        },
        error: function (err) {
            console.log(err)
        }
    });
}


function dataURLtoBlob(dataurl, name) {//name:文件名
    var mime = name.substring(name.lastIndexOf('.') + 1)//后缀名
    var bstr = atob(dataurl), n = bstr.length, u8arr = new Uint8Array(n);
    while (n--) {
        u8arr[n] = bstr.charCodeAt(n);
    }
    return new Blob([u8arr], {type: mime});
}

function downloadFile(url, name) {
    var a = document.createElement("a")//创建a标签触发点击下载
    a.setAttribute("href", url)//附上
    a.setAttribute("download", name);
    a.setAttribute("target", "_blank");
    var clickEvent = document.createEvent("MouseEvents");
    clickEvent.initEvent("click", true, true);
    a.dispatchEvent(clickEvent);
}

//主函数
function downloadFileByBase64(name, base64) {
    var myBlob = dataURLtoBlob(base64, name);
    var myUrl = URL.createObjectURL(myBlob);
    downloadFile(myUrl, name)
}

//获取后缀
function getType(file) {
    var filename = file;
    var index1 = filename.lastIndexOf(".");
    var index2 = filename.length;
    var type = filename.substring(index1 + 1, index2);
    return type;
}

//根据文件后缀 获取base64前缀不同
function getBase64Type(type) {
    switch (type) {
        case 'data:text/plain;base64':
            return 'txt';
        case 'data:application/msword;base64':
            return 'doc';
        case 'data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64':
            return 'docx';
        case 'data:application/vnd.ms-excel;base64':
            return 'xls';
        case 'data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64':
            return 'xlsx';
        case 'data:application/pdf;base64':
            return 'pdf';
        case 'data:application/vnd.openxmlformats-officedocument.presentationml.presentation;base64':
            return 'pptx';
        case 'data:application/vnd.ms-powerpoint;base64':
            return 'ppt';
        case 'data:image/png;base64':
            return 'png';
        case 'data:image/jpeg;base64':
            return 'jpg';
        case 'data:image/gif;base64':
            return 'gif';
        case 'data:image/svg+xml;base64':
            return 'svg';
        case 'data:image/x-icon;base64':
            return 'ico';
        case 'data:image/bmp;base64':
            return 'bmp';
    }
}

function base64ToBlob(code) {
    code = code.replace(/[\n\r]/g, '');
    var raw = window.atob(code);
    var rawLength = raw.length;
    var uInt8Array = new Uint8Array(rawLength);
    for (var i = 0; i < rawLength; ++i) {
        uInt8Array[i] = raw.charCodeAt(i)
    }
    return new Blob([uInt8Array], {type: 'application/pdf'})
}

