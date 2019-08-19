<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ru_ku.aspx.cs" Inherits="Web.ru_ku" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        #biao_ti {
         
           margin-left: 45%;
           padding-bottom: 2%;
        }

        /*.bg_bj {
            padding: 5px 20px 5px 20px;
        }
        .bg_bj_bz {
            padding: 5px 150px 5px 20px;
        }
         .bg_bj_mc {
            padding: 5px 80px 5px 20px;
        }

        #biao_ge {
            border: 1px solid #808080;                    
            margin: 0px auto;
        }*/
        #biao_ge tr:nth-of-type(odd) {

            background: #ffff99;
        }
        #biao_ge tr:nth-of-type(even) {

            background: #ccffcc;
        }
         #biao_ge tr input:nth-of-type(even) {

            background: #ccffcc;
        }

    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<%--        <div ></div>--%>
        
        <h2 id="biao_ti" >入库单</h2>
        <button onclick="ru_ku_click">入库</button>
        <table border="1" id="biao_ge" ><%--cellspacing="5" cellpadding="5"--%>
            <tr>
                <td class="bg_bj_mc">商品名称</td>
                <td class="bg_bj">商品代码</td>
                <td class="bg_bj">商品类别</td>
                <td class="bg_bj">数量</td>
                <td class="bg_bj">商品售价</td>
                <td class="bg_bj">金额</td>
                <td class="bg_bj_bz">备注</td>    
                 <td class="bg_bj">功能</td>        
            </tr>

            <tr>
                <td class="bg_bj_mc"><input type="text" id="sp_name" name="sp_name"></td>
                <td class="bg_bj"><input type="text" id="Text1" name="txt"></td>
                <td class="bg_bj"><input type="text" id="Text2" name="txt"></td>
                <td class="bg_bj"><input type="text" id="Text3" name="txt"></td>
                <td class="bg_bj"><input type="text" id="Text4" name="txt"></td>
                <td class="bg_bj"><input type="text" id="Text5" name="txt"></td>
                <td class="bg_bj_bz"><input type="text" id="Text6" name="txt"></td>     
                <td class="bg_bj"><a href="#">编辑</a></td>     
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
