<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sp_rc_ku_select.aspx.cs" Inherits="Web.sp_rc_ku_select" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            var winHeight = window.innerHeight;
            $(".table_div").css("height", winHeight * 0.8)
        })
    </script>
    <style type="text/css">

        .auto-style1 {
            height: 49px;
            text-align: center;
            background-color: #2F4056;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position: sticky;
            top: 0;
        }

        .input_tr {
            width: 91px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
            margin-left: 10px;
        }

        .td_css {
            text-align: center;
            height: 40px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
            font-size: 4px;
        }

        .select_xl {
            width: 185px;
            height: 73%;
            border: 1px solid #F0F0F0;
            border-radius: 3px;
        }
        .top-div
        {
            width: 100%;
            height: 50px;
            display: flex;
            flex-direction: row;
            justify-content: space-start;
            align-items: center;
        }
        .table_div
        {
            width: 100%;
            overflow: scroll;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <div class="top-div">
                <select class="select_xl" name="kui_lei">
                    <option>请选择</option>
                    <%           
                        List<string> rc_ku_xl_select = Session["rc_ku_xl_select"] as List<string>;
                        if (rc_ku_xl_select != null)
                        {
                            for (int i = 0; i < rc_ku_xl_select.Count; i++)
                            {                          
                    %>
                    <option><%=rc_ku_xl_select[i]%></option>
                    <%
                        }
                       
                    %>
                </select>
                <asp:Button OnClick="rc_ku_select_Click" ID="Button1" CssClass="input_tr" Text="查询" runat="server" />
                <asp:Button OnClick="rc_ku_select_Click" ID="Button2" CssClass="input_tr" Text="清空" runat="server" />
            </div>

            <div class="table_div">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="width: 100%">
                    <tr id="Tr2">
                        <th colspan="1" rowspan="2" class="auto-style1" style="width: 150px;">日期</th>
                        <th colspan="1" rowspan="2" class="auto-style1" style="width: 50px;">单号</th>
                        <th colspan="1" rowspan="2" class="auto-style1" style="width: 128px;">商品代码</th>
                        <th colspan="1" rowspan="2" class="auto-style1" style="width: 128px;">商品名称</th>
                        <th colspan="2" rowspan="1" class="auto-style1" style="width: 140px">入库</th>
                        <th colspan="2" rowspan="1" class="auto-style1" style="width: 140px;">出库</th>
                    </tr>
                    <tr id="dj_yh">
                        <th class="auto-style1" style="width: 70px">数量</th>
                        <th class="auto-style1" style="width: 70px">金额</th>
                        <th class="auto-style1" style="width: 70px">数量</th>
                        <th class="auto-style1" style="width: 70px">金额</th>
                    </tr>

                    <%
                            }
                            List<rc_ku_info> rc_ku_r_select = Session["selectSp"] as List<rc_ku_info>;


                            if (rc_ku_r_select == null)
                            {

                            }
                            else
                            {
                                for (int i = 0; i < rc_ku_r_select.Count; i++)
                                {
                       
                    %>
                    <tr id="Tr1">

                        <td class="td_css"><%=rc_ku_r_select[i].Ri_qi %></td>
                        <td class="td_css"><%=rc_ku_r_select[i].Orderid %></td>
                        <td class="td_css"><%=rc_ku_r_select[i].Sp_dm %></td>
                        <td class="td_css"><%=rc_ku_r_select[i].Name %></td>
                        <td class="td_css"><%=rc_ku_r_select[i].num1 %></td>
                        <td class="td_css"><%=rc_ku_r_select[i].price1 %></td>
                        <td class="td_css"><%=rc_ku_r_select[i].num2 %></td>
                        <td class="td_css"><%=rc_ku_r_select[i].price2 %></td>
                    </tr>
                    <%
                            }
                        }
                    %>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
