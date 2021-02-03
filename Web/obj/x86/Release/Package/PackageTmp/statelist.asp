<!--#include file="Include/conn.asp"-->
<!--#include file="Include/Fun_SqlIn.Asp"-->
<!--#include file="Include/CheckLog.asp"-->
<%
Dim RegName,shenfen,syadd,klid,sex,Birth,National,Mian,bschool,gkbm,schoolxj
Dim Tadd,Tcode,TTel,qianli,Ticha,BigPic
Dim fclass,Fname,ftel,mclass,mname,mtel
Dim zhiya,zhiyb,zhiyc,Tiaoj
Dim language,math,foreign,physics,chemistry,biont,polity,history,geography,Liberal,calculator
Dim ViewVlag,mtype

%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <title>报修信息列表</title>
    <script src="images/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="images/gotopku.js" type="text/javascript"></script>
    <script src="images/jquery.uploadify.min.js" type="text/javascript"></script>
    <script language="javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml; window.print();
            window.document.body.innerHTML = bdhtml;
        }
    </script>
    <!--<link rel="stylesheet" type="text/css" href="images/uploadify.css">-->
    <link href="images/style.css" rel="stylesheet" type="text/css">
</head>

<body>
 <!--   <div class="header_logo">
        <div class="header_logo_con">
            <h1 class="h1_logo"><%=SiteTitle%></h1>
        </div>
    </div>-->
<!--    <div class="header_login_info">
        <div class="header_login_info_con">
            <span class="fl welcome_info">你好 <%=session("ZhiRegName")%>！　　你的身份证号码：<%=session("zhishenfen")%></span>
            <span class="fr"><a class="header_nav" href="UserPassUp.asp">修改密码</a>　　　<a class="header_nav" href="UserLogin.asp?Action=logout">退出登录</a></span>
        </div>
    </div>-->

    <div class="main1">
        <div class="mainCon1">
            <div class="leftNav">
                <ul>
                    <li><a id="Nav_begin" class="leftNav_li" href="senior.asp">报修信息导航</a></li>
                    <li><span class="leftNav_block"></span></li>
                    <li><a href="senior.asp#Nav_profile_basic" class="leftNav_li">在线报修</a></li>
                    <li><a href="statelist.asp#Nav_profile_image" class="leftNav_li">报修列表</a></li>
                    <li><a href="UserPassUp.asp" class="leftNav_li">个人信息</a></li>
                    <span id="show_hide_app" style="display: &#39; none&#39;"></span>
                </ul>
            </div>

            <div class="rightContent">
                <!--start -->
                <!--startprint-->
                <table id="Nav_profile_whish" class="app_table">
                    <tbody>
                        <tr bgcolor="#D9DDE9">
                            <td width="20" height="25" align='center' nowrap><strong>ID</strong></td>
                            <td align='center' nowrap><strong>客户</strong></font></td>
                            <td width="5%" align='center' nowrap><strong>城市</strong></td>
                            <td width="5%" align='center' nowrap><strong>电话</strong></td>
                            <td width="5%" align='center' nowrap><strong>会员</strong></td>
                            <td width="5%" align='center' nowrap><strong>地址</strong></td>
                            <td align='center' nowrap><strong>报修时间</strong></td>
                            <td align='center' nowrap><strong>维修经费</strong></td>
                            <td align='center' nowrap><strong>是否完成</strong></td>
                        </tr>
                        <% NewsList() %>
                    </tbody>
                </table>
         
            </div>
            <div class="clear"></div>
        </div>
    </div>

    <div class="foot">
        <div class="footer">
            <div class="copyright">
                <%=SiteTitle%>&nbsp;&nbsp;版权所有&nbsp;&nbsp;&nbsp;&nbsp;<%=year(now())%><br>
            </div>
        </div>
    </div>
</body>
</html>
