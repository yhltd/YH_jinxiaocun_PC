<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.login" enableEventValidation="false"%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="inc/logincss.css" rel="stylesheet" type="text/css" />
    <link href="../../Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <title>云合未来一体化系统</title>
    <link rel="shortcut icon" href="../Images/yhltd.ico">
    <script src="./js/Jquery.js"></script>
    <script language="JavaScript">
        window.onload = function () {
            var oUser = document.getElementById('username');
            var oPswd = document.getElementById('password');
            var oRemember = document.getElementById('remember');
            var oForm = document.getElementById('MyForm');
            //页面初始化时，如果帐号密码cookie存在则填充
            if (getCookie('user') && getCookie('pwd')) {
                oUser.value = getCookie('user');
                oPswd.value = getCookie('pwd');
                oRemember.checked = true;
            }

            if (getCookie('login')!='') {
                var arr = getCookie('login').split("`")
                delCookie('login')
                document.getElementById('DropDownList3').selectedIndex = 1
                var addOption = document.createElement("option");
                addOption.text = arr[3];
                addOption.value = arr[3];
                document.getElementById('DropDownList1').add(addOption);
                document.getElementById('DropDownList1').selectedIndex = 1;
                $("#_DropDownList1").val(arr[3])

                var addOption = document.createElement("option");
                addOption.text = arr[2];
                addOption.value = arr[2];
                document.getElementById('DropDownList2').add(addOption);
                document.getElementById('DropDownList2').selectedIndex = 0
                oUser.value = arr[0]
                oPswd.value = arr[1]
                $("#_DropDownList2").val(arr[2])

            }

            //复选框勾选状态发生改变时，如果未勾选则清除cookie
            oRemember.onchange = function () {
                if (!this.checked) {
                    delCookie('user');
                    delCookie('pwd');
                }
            };
            //表单提交事件触发时，如果复选框是勾选状态则保存cookie
            oForm.onsubmit = function () {
                if (remember.checked) {
                    setCookie('user', oUser.value, 30); //保存帐号到cookie，有效期7天
                    setCookie('pwd', oPswd.value, 30); //保存密码到cookie，有效期7天
                }
            };

        }


        $(document).ready(function(){

            loadPushNewsData();

            var xiala1 = document.getElementById('DropDownList3');
            var xiala2 = document.getElementById('DropDownList1');
            var xiala3 = document.getElementById('DropDownList2');
            var oUser = document.getElementById('username');
            var oPswd = document.getElementById('password');
            var user = getUrlParams("user")
            console.log(user)
            if (user != false) {
                alert("beidiaoyong")
                //var companyName = xiala3.value;
                //console.log("记录的公司名称:", companyName);

                //// 存储到sessionStorage（前端临时存储）
                //sessionStorage.setItem('currentCompanyName', companyName);

                $.ajax({
                    type: "post", //要用post方式     
                    url: "/Myadmin/HouTai/YongHuGuanli.aspx/DecryptAes",
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    dataType: "json",
                    data: JSON.stringify({
                        source: user,
                    }),
                    success: function (data) {
                        console.log(data)
                        setCookie('login', data.d, 30)
                        console.log($("#DropDownList2").text())
                        var url = window.top.location.href.split("?")[0]
                        window.location.href = url
                        //var arr = data.d.split("`")
                        //document.getElementById('DropDownList3').selectedIndex = 1
                        //var addOption = document.createElement("option");
                        //addOption.text = arr[3];
                        //addOption.value = 0;
                        //document.getElementById('DropDownList1').add(addOption);
                        //document.getElementById('DropDownList1').selectedIndex = 1;

                        //var addOption = document.createElement("option");
                        //addOption.text = arr[2];
                        //addOption.value = 0;
                        //document.getElementById('DropDownList2').add(addOption);
                        //document.getElementById('DropDownList2').selectedIndex = 0
                        //oUser.value = arr[0]
                        //oPswd.value = arr[1]

                    },
                    error: function (err) {
                        console.log(err)
                    }
                });
            }

        })


        //设置cookie
        function setCookie(name, value, day) {
            var date = new Date();
            date.setDate(date.getDate() + day);
            document.cookie = name + '=' + value + ';expires=' + date;
        };
        //获取cookie
        function getCookie(name) {
            var reg = RegExp(name + '=([^;]+)');
            var arr = document.cookie.match(reg);
            if (arr) {
                return arr[1];
            } else {
                return '';
            }
        };
        //删除cookie
        function delCookie(name) {
            setCookie(name, null, -1);
        };

        function CheckLogin() {
            // 验证用户名
            if (document.MyForm.username.value == "") {
                alert("请输入用户名再提交！");
                document.MyForm.username.focus();
                return false
            }
    
            // 验证密码
            if (document.MyForm.password.value == "") {
                alert("请输入密码再提交！");
                document.MyForm.password.focus()
                return false
            }
    
            // 获取公司名并保存到 localStorage
            var companySelect = document.getElementById('DropDownList2');
            if (companySelect) {
                var companyName = companySelect.options[companySelect.selectedIndex].text;
                if (companyName && companyName.trim() !== '') {
                    localStorage.setItem('savedCompany', companyName);
                    console.log('保存company到localStorage:', companyName);
                } else {
                    console.log('公司名称为空，不保存到localStorage');
                }
            } else {
                console.log('未找到公司名下拉框');
            }

            //系统名称
            var xtSelect = document.getElementById('DropDownList1');
            if (xtSelect) {
                var xtName = xtSelect.options[xtSelect.selectedIndex].text;
                if (xtName && xtName.trim() !== '') {
                    localStorage.setItem('savedSys', xtName);
                    console.log('保存company到localStorage:', xtName);
                } else {
                    console.log('公司名称为空，不保存到localStorage');
                }
            } else {
                console.log('未找到公司名下拉框');
            }
    
            return true; // 验证通过，允许表单提交
        }

        function getUrlParams(key) {
            var url = window.location.search.substr(1);
            if (url == '') {
                return false;
            }
            var paramsArr = url.split('&');
            for (var i = 0; i < paramsArr.length; i++) {
                var combina = paramsArr[i].split("=");
                if (combina[0] == key) {
                    return combina[1];
                }
            }
            return false;
        };

        document.addEventListener('DOMContentLoaded', function() {
          const container = document.getElementById('particles');
          const particleCount = 30;
            
            for (let i = 0; i < particleCount; i++) {
                createParticle(container);
            }
            
            function createParticle(parent) {
                const particle = document.createElement('div');
                particle.classList.add('particle');
                
                // 随机大小 (2px - 8px)
                const size = Math.random() * 6 + 2;
                particle.style.width = `${size}px`;
                particle.style.height = `${size}px`;
                
                // 随机位置
                particle.style.left = `${Math.random() * 100}%`;
                particle.style.top = `${Math.random() * 100}%`;
                
                // 随机动画延迟和持续时间
                particle.style.animationDelay = `${Math.random() * 15}s`;
                particle.style.animationDuration = `${Math.random() * 10 + 10}s`;
                
                // 随机透明度
                particle.style.opacity = Math.random() * 0.5 + 0.3;
                
                parent.appendChild(particle);
            }
        });


        function switchTab(tabName) {
            // 切换标签样式
            document.querySelectorAll('.tab').forEach(tab => {
                tab.classList.remove('active');
        });
        event.target.classList.add('active');
            
        // 切换内容显示
        document.getElementById('account-login').classList.toggle('hidden', tabName !== 'account');
        document.getElementById('qrcode-login').classList.toggle('hidden', tabName !== 'qrcode');
        document.getElementById('phone-login').classList.toggle('hidden', tabName !== 'phone');
        }




        function loadPushNewsData() {
            var savedCompany = localStorage.getItem('savedCompany') || '';
            var savedsys = localStorage.getItem('savedSys') || '';
            // 使用jQuery AJAX调用WebMethod
            $.ajax({
                type: "POST",
                url: "login.aspx/GetPushNewsLogo", // 注意：这里应该是当前页面或其他包含WebMethod的页面
                data: JSON.stringify({ 
                    companyName: savedCompany, 
                    systemName: savedsys 
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    
                    console.log("完整响应:", response);
                    console.log("返回数据:", response.d);
                    if (response.d[0].beizhu2.trim() !== "") {
                        var logoImg = document.querySelector('img.floating-img');
                        if (logoImg) {
                            logoImg.src = "data:image/jpg;base64," + response.d[0].beizhu2;
                        }
                    }

                    if (response.d[0].beizhu3.trim() !== "") {
    
                        // 替换标题文本
                        var titleElement = document.querySelector('.lefts span');
                        if (titleElement) {
                            titleElement.textContent = response.d[0].beizhu3;
                            console.log("标题已替换为:", response.d[0].beizhu3);
                        }
                    }
                       
                },
                error: function (xhr, status, error) {
                    console.error("加载推送新闻数据失败:", error);
                }
            });
        }


    </script>
    <style type="text/css">
        .auto-style1 {
            width: 227px;
        }

        .select {
            /*position: absolute;*/
            width: 100%;
            height: 100%;
            padding: 0 24px 0 8px;
            color: #fff;
            font: 12px/21px arial,sans-serif;
            background: url(select.png) no-repeat; /*span背景图片，其实就是dropdownlist图片*/
            overflow: hidden;
            top: 0px;
            left: 0px;
        }
        option {
            text-align:center;
                color: black;
        }
       .particle-container {
    background: url('images/beijinglog.png') no-repeat center center;
    background-size: cover;
}

        </style>
</head>

<body class="particle-container" id="particles">
    <div class="mains">
        <div class="inners">
            <img class="floating-img" src="images/companyLogo.png" height="80" style="float:left;left:2px;position:absolute;" />
            <p align="right">
                <span style="font-size: 12pt ;color:white" class="font_gray"><%=version%></span>
            </p>
            

            <div class="login">

                <form name="MyForm" id="MyForm" runat="server" method="post" action="login.aspx">
                    <div style="display:none">
                        <input type="hidden" id="_DropDownList1" name ="_DropDownList1" value="" />
                        <input type="hidden" id="_DropDownList2" name ="_DropDownList2" value="" />

                    </div>
                    <%--<form action="admin_login.asp" method="post" name="MyForm" id="Form1" runat="server" >--%>
                    <div class="dbweizhi">
                        <table id="Table1">
                        </table>
                    </div>
                    <input type="hidden" value="chklogin" name="reaction">

                    <div class="center">
                        <div class="lefts" style="text-align: center;width:100%">
                            <div style="text-align: center;width:100%" >
                                <b><span style="font-size: 42pt; color:white;">云和未来一体化系统</span></b>
                            </div>
                    

            </div>
                   <div class="inner">

                     <div class="tab-switcher">
                        <div class="tab active" onclick="switchTab('account')">密码登录</div>
                        <div class="tab" onclick="switchTab('phone')">手机号登录</div>
                         <div class="tab" onclick="switchTab('qrcode')">扫码登录</div>
                     </div>
                           

                         <div id="account-login">
             <table cellpadding="0" cellspacing="0" id="innnertalbe">

                                <tr style="margin-top:10px">
                                    <td height="50">
                                        <p align="right" style="width: 81px">
                                            <b><span style="font-size: 13pt">系&nbsp; 统：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="DropDownList3" runat="server" Style="color:#383838; " class="select_w150" AutoPostBack="true" OnSelectedIndexChanged="xitong_select"></asp:DropDownList>

                                    </td>
                                </tr>

                                <tr>
                                    <td height="50">
                                        <p align="right" style="width: 81px">
                                            <b><span style="font-size: 13pt">数据库：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="DropDownList1" runat="server" Style="color:#383838; " class="select_w150" AutoPostBack="true" OnSelectedIndexChanged="bian"></asp:DropDownList>

                                    </td>
                                </tr>

                                 <tr>
                                    <td height="50" >
                                        <p align="right" style="width: 81px">
                                            <b><span style="font-size: 13pt">公司名：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="DropDownList2" runat="server" Style="color: #383838; " class="select_w150" ></asp:DropDownList>
                                        </td>
                                </tr>

                                <tr>
                                    <td height="50" >
                                        <p align="right" style="width: 81px">
                                            <b><span style="font-size: 13pt">用户名：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <input name="username" autocomplete="off" type="text" class="select_w150" id="username" size="16" maxlength="100" value="<%=user%>" /></td>
                                </tr>

                                <tr>
                                    <td height="50">
                                        <p align="right" style="width: 81px">
                                            <b><span style="font-size: 13pt">密&nbsp; 码：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <input name="password" type="password" class="select_w150" id="password" size="16" maxlength="100" value="<%=pass%>" /></td>
                                </tr>

                                <tr>
                                    <td align="center" style="margin-left:150px">
                                        <input name="remember" type="checkbox"  id="remember" style="margin-top: 8px;height: auto;"  />
                                    </td>
                                    <td style="margin-left:10px">
                                        <p align="left">
                                            <b><span style="font-size: 13pt">30天内记住密码</span></b>
                                        </p>
                                    </td>
                                    <%--<td class="auto-style1">
                                        <input name="remember" type="checkbox" class="select_w150" id="remember" size="16" maxlength="100" /></td>
                                    <td height="60">
                                        <p align="right">
                                            <b><span style="font-size: 13pt">30天内记住密码</span></b>
                                        </p>
                                    </td>--%>
                                </tr>

                                <tr>
                                    <td height="49"></td>
                                    <td class=" btn">
                                        <asp:Button type="button" ID="image" runat="server" Text=" 登 录 " class="LoginSub" OnClick="HtmlBtn_Click" OnClientClick="CheckLogin()" />

                                        <asp:Button ID="btcreate" runat="server" Text=" 找回密码 " class="LoginSub" OnClick="Btchangepas_Click" Visible="true" />
                                        <br>
                                        <br>

                                        <span style="color: #4cff00;"></span>

                                    </td>

                                </tr>

                              <%--  <tr>
                                    <br>
                                    <td height="49"></td>
                                    <td class="auto-style1">
                                        <asp:Button ID="Btchangepas" runat="server" Text=" 改密 " class="LoginSub" OnClick="Btchangepas_Click" Visible="True" />
                                        <asp:Button ID="frmmain" runat="server" Text=" 主页面 " class="LoginSub" OnClick="Btmain_Click" Visible="False" />
                                        
                                        <br>
                                        <span style="color: #FF0000;"></span>
                                    </td>


                                </tr>--%>
                              <%--  <tr>
                                    <td align="center" colspan="5">
                                        <asp:Button ID="Button1" runat="server" Text=" 游客登录 " class="NOLoginSub" OnClick="HtmlNOlogin_Click" Visible="True" Width="285px" />
                                        <br />
                                        <asp:Label ID="Label1" runat="server">
                                       <%=alterinfo1%>
                                        </asp:Label>
                                    </td>
                                </tr>--%>
                            </table>
            </div>
                        <div id="qrcode-login" class="hidden">
                <div class="qrcode-container">
                    <div class="qrcode-placeholder"></div>
                    <p class="qrcode-tip">请使用手机APP扫描二维码登录</p>
                    <button type="button" class="btn2" onclick="refreshQRCode()">刷新二维码</button>
                </div>
            </div>

                         <div id="phone-login" class="hidden">
                <div class="form-group">
                        <label for="username">手机号</label>
                        <input type="text" id="Text1" placeholder="请输入手机号">
                    </div>
                    <div class="form-group">
                        <label for="password">验证码</label>
                        <input style="  width: 81%;border-right: 0;border-radius: 8px 0 0 8px;" type="password" id="password1" placeholder="请输入验证码">
                        <button class="btn-yzm"  disabled="disabled">获取验证码</button>
                    </div>
                    <button style="width:100%" type="button" class="btn2" onclick="login()">登录</button>
            </div>
                     
                        <div class="clearfix"></div>

                    </div>

                </form>
            </div>

        </div>
        <div class="ui-login-footer">
            <p style="vertical-align:bottom;line-height:20px">
                <span class="font_gray" style="color:white">云合未来计算机技术有限公司  © Copyright 2018-2030   联系电话：16619776280</span>
                <%--辽ICP备19018259号 云合未来计算机技术有限公司 技术支持 www.yhocn.cn--%>
            </p>
            <p style="vertical-align:bottom;line-height:20px">
                <span class="font_gray" style="color:white">云合未来计算机技术有限公司 技术支持 www.yhocn.cn</span>
            </p>
        </div>
    </div>

</body>
</html>
