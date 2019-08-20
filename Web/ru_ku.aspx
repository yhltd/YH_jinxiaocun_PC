<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ru_ku.aspx.cs" Inherits="Web.ru_ku" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function ru_ku_click() {
         
            var value = document.getElementById('sp_name').value;
                alert(value);
            
        }

        $(function () {
            $('form').ajaxForm({
                success: function (responseText) {
                    alert(responseText);
                }
            });
        });
    </script>
    <style type="text/css">
        #biao_ti {
         
           margin-left: 45%;
           padding-bottom: 4%;
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
          #biao_ge tr input :nth-of-type(even) {

            background: #ccffcc;
        }
        .dh_css {
            position:absolute;
            top: 90px;
            
        }
        .ghf_css {

             position:absolute;
              top: 90px;
              left:325px;
        }
         .shf_css {

             position:absolute;
               top: 90px;
              left:670px;
        }
        .rq_css {

             position:absolute;
              top: 90px;
              left:1000px;
        }
        .rk_btu {
             position:absolute;
              top: 90px;
              left:91%;
        }
    </style>
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1"  runat="server">
    <div>
<%--        <div ></div>--%>
        
        <h2 id="biao_ti" >入库单</h2>
       
        <div class="dh_css"><label>单号：</label><input type="text"/></div>
        <div class="ghf_css"><label>供货方：</label><input type="text"/></div>
        <div class="shf_css"><label>收货方：</label><input type="text"/></div>
        <div class="rq_css"><label>日期：</label><input type="text"/></div>
        <table border="1" id="biao_ge" ><%--cellspacing="5" cellpadding="5"--%>
            
            <tr>
                <td class="bg_bj_mc">商品名称</td>
                <td class="bg_bj">商品代码</td>
                <td class="bg_bj">商品类别</td>
                <td class="bg_bj">商品售价</td>
                <td class="bg_bj">商品数量</td>
                <td class="bg_bj">金额</td>
                <td class="bg_bj_bz">备注</td>    
                 <td class="bg_bj">功能</td>        
            </tr>
           <%-- <% for (int i = 0; i < 20; i++)
               {%>--%>
                   <tr>
                
                        <td class="bg_bj_mc"><input type="text" id="sp_name" name="sp_name"></td>
                        <td class="bg_bj"><input type="text" id="sp_dm" name="sp_dm"></td>
                        <td class="bg_bj"><input type="text" id="sp_cplb" name="sp_cplb"></td>
                         <td class="bg_bj"><input type="text" id="sp_cpsj" name="sp_cpsj"></td>
                        <td class="bg_bj"><input type="text" id="sp_cpsl" name="sp_cpsl"></td>                   
                        <td class="bg_bj"><input type="text" id="sp_je" name="sp_je"></td>
                        <td class="bg_bj_bz"><input type="text" id="sp_bz" name="sp_bz"></td>     
                        <td class="bg_bj"><a href="#">编辑</a></td>     
                  </tr>
         <%--   <%    } %>--%>
            
        </table>
        <asp:Button OnClick="bt_add_Click" class="rk_btu" Text="入库" runat="server"/>
    </div>
    </form>
</body>
</html>
