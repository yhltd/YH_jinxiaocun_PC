function toUpdPwd() {
    var updatePwdForm = $('#updatePwd').serialize();
    var param = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)))
    if (checkUpdPwd(param)) {
        $.ajax({
            type: 'Post',
            url: "web_service/updateUser.asmx/updatePwd",
            data: {
                oldPwd: param.oldPwd,
                newPwd: param.newPwd
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg)
                if (result.code == 200) {
                    $('#update_pwd').window('close');
                }
            },
            error: function (err) {
                alert("错误！")
                console.log(err)
            }
        })
    }
}

function toResetPwd() {
    $("#updatePwd").form('reset');
}

function checkUpdPwd(param) {
    if (param.oldPwd == "") {
        alert("请输入旧密码")
        return false;
    } else if (param.newPwd == "") {
        alert("请输入新密码")
        return false;
    } else if (param.newPwd_again == "") {
        alert("请确认新密码")
        return false;
    } else if (param.newPwd != param.newPwd_again) {
        alert("两次新密码输入不一致")
        return false;
    }
    return true;
}



function toUpdDo() {
    var updateDoForm = $('#updateDo').serialize();
    var param = JSON.parse(formToJson(decodeURIComponent(updateDoForm, true)))
    if (checkUpdDo(param)) {
        $.ajax({
            type: 'Post',
            url: "web_service/updateUser.asmx/updateDo",
            data: {
                oldDo: param.oldDo,
                newDo: param.newDo
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg)
                if (result.code == 200) {
                    $('#update_do').window('close');
                }
            },
            error: function (err) {
                alert("错误！")
                console.log(err)
            }
        })
    }
}

function toResetDo() {
    $("#updateDo").form('reset');
}

function checkUpdDo(param) {
    if (param.oldDo == "") {
        alert("请输入旧密码")
        return false;
    } else if (param.newDo == "") {
        alert("请输入新密码")
        return false;
    } else if (param.newDo_again == "") {
        alert("请确认新密码")
        return false;
    } else if (param.newDo != param.newDo_again) {
        alert("两次新密码输入不一致")
        return false;
    }
    return true;
}


function toNewUser() {
    var newUserForm = $('#newUser').serialize();
    var param = JSON.parse(formToJson(decodeURIComponent(newUserForm, true)))
    if (checkNewUser(param)) {
        $.ajax({
            type: 'Post',
            url: "web_service/updateUser.asmx/newUser",
            data: {
                myDo: param.myDo,
                user_json: JSON.stringify({
                    name: param.name,
                    pwd: param.pwd,
                    do: param.do
                })
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg)
                if (result.code == 200) {
                    $('#new_user').window('close');
                }
            },
            error: function (err) {
                alert("错误！")
                console.log(err)
            }
        })
    }
}

function toResetNewUser() {
    $("#newUser").form('reset');
}

function checkNewUser(param) {
    if (param.myDo == "") {
        alert("请输入您的操作密码")
        return false;
    } else if (param.user == "") {
        alert("请输入用户名")
        return false;
    } else if (param.pwd == "") {
        alert("请输入密码")
        return false;
    } else if (param.pwd == "") {
        alert("请输入操作密码")
        return false;
    }
    return true;
}