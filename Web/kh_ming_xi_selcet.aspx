<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kh_ming_xi_selcet.aspx.cs" Inherits="Web.kh_ming_xi_selcet" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            var windowHeight = window.innerHeight;
            $(".table_div").css("height", windowHeight * 0.8)
        })
    </script>
    <style type="text/css">
        .auto-style1
        {
            height: 49px;
            text-align: center;
            background-color: #2F4056;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position: sticky;
            top: 0;
        }

        td
        {
            text-align: center;
            height: 40px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
            font-size: 4px;
        }

        .input_tr
        {
            width: 91px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
            margin-left: 10px;
        }

        .select_xl
        {
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
            justify-content: start;
            align-items: center;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="top-div">
                <select class="select_xl" name="gonghuo">
                    <option>请选择</option>
                    <%           
                        List<string> kh_mx_xl_select = Session["kh_mx_xl_select"] as List<string>;
                        for (int i = 0; i < kh_mx_xl_select.Count; i++)
                        {                          
                    %>
                    <option><%=kh_mx_xl_select[i]%></option>
                    <%
                        }
                    %>
                </select>
                <asp:Button OnClick="kh_mx_select_Click" ID="Button2" class="input_tr" Text="查询" runat="server" />
                <asp:Button OnClick="kh_mx_select_load" ID="Button1" class="input_tr" Text="清空" runat="server" />
            </div>

            <div class="table_div">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="width: 100%">
                    <tr id="dj_yh">
                        <th class="auto-style1" style="width: 150px;">日期</th>
                        <th class="auto-style1" style="width: 138px;">供货商</th>
                        <th class="auto-style1" style="width: 138px;">单号</th>
                        <th class="auto-style1" style="width: 138px;">商品代码</th>
                        <th class="auto-style1" style="width: 138px;">商品名称</th>
                        <th class="auto-style1" style="width: 70px;">入库数量</th>
                        <th class="auto-style1" style="width: 70px;">入库金额</th>
                    </tr>

                    <%
               
                        List<rc_ku_info_select> rk_mx_select = Session["rk_mx_select"] as List<rc_ku_info_select>;


                        if (rk_mx_select == null)
                        {

                        }
                        else
                        {
                            for (int i = 0; i < rk_mx_select.Count; i++)
                            {
                       
                    %>
                    <tr id="Tr1">
                        <td><%=rk_mx_select[i].date %></td>
                        <td><%=rk_mx_select[i].come%></td>
                        <td><%=rk_mx_select[i].order %></td>
                        <td><%=rk_mx_select[i].code %></td>
                        <td><%=rk_mx_select[i].name %></td>
                        <td><%=rk_mx_select[i].num %></td>
                        <td><%=rk_mx_select[i].price %></td>
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
