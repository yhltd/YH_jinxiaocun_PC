<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zheng_li_page.aspx.cs" Inherits="Web.zheng_li_page" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
        function del_row(row) {
            var rowIndex = $("#del_row_cs1").context.rowIndex;
            $("#del_row" + row + "").remove();
        }

        $(function () {
            $("#dj_row").click(function () {

                $("#row_i1").val($("#biao_ge tr").length);

            })

        })

        $(document).ready(function () {
            var row = 1;
            $("#dj_yh").click(function () {

                var rowLength = $("#biao_ge tr").length;

                var insertStr = "<tr id='del_row" + row + "' >"
                               + "<td style='font-size: 14px;padding-left: 0.5%;width: 22px;'>" + rowLength + "</td>"
                               + "<td ><input type='text' class='input_tr' style='width: 244px;margin:0.2%;' name='sp_dm" + row + "' ></input></td>"
                               + "<td class='bg_bj_dm'><input type='text' style='width: 290px;margin:0.2%;' class='input_tr' name='name" + row + "' ></input></td>"
                               + "<td class='bg_bj_lb'><input type='text' style='width: 244px;margin:0.2%;' class='input_tr' name='lei_bie" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' style='width: 244px;margin:0.2%;' class='input_tr' name='dan_wei" + row + "' ></input></td>"
                               + "<td style='border-right: 1px dashed #a8a8a8;'><input type='button' class='rk_btu'value='删除'  onclick='del_row(" + row + ")'/></td>"
                               + "</tr>";
                $("#biao_ge tr:eq(" + (rowLength - 1) + ")").after(insertStr);
                row++;
            });


        });

        function pd_tj_ff() {
            var c = confirm('要提交吗?');
            if (c) {
                $("#xx_hidden").val("tj_true");
                $("#tj_pd_id").val("tj_true");
            } else {

                $("#tj_pd_id").val("tj_false");

            }

        }


        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            if (document.getElementById("xx_hidden").value == "tj_false") {
                return false;
            } else {
            }
        })

    </script>
    <style type="text/css">
        .input_tr
        {
            border: none;
            height: 90%;
            width: 90%;
        }

        td
        {
            text-align: center;
            height: 40px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
            font-size: 4px;
        }

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

        .input_tr_sc
        {
        }

        .input_tr_tj
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

        .hidden_load
        {
        }

        .input_tr_sx
        {
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

            <input type="hidden" id="xx_hidden" value="tj_false" />
            
            <div class="top-div">
                <asp:Button ID="Button2" class="input_tr_tj" OnClick="zl_select_load" Text="刷新数据" runat="server" />
                <asp:Button OnClick="zl_tj" ID="dj_row" class="input_tr_tj" Text="提交" runat="server" />
                <asp:Button OnClick="del_qichu" ID="del_qc_btu" class="input_tr_tj" Text="删除" runat="server" />
            </div>
            <input type="hidden" id="tj_pd_id" name="tj_pd" />
            <input type="hidden" id="row_i1" name="row_i" />
            <div class="table_div">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="width: 100%">
                    <tr id="dj_yh">
                        <th class="auto-style1" style="width: 70px">序号</th>
                        <th class="auto-style1" style="width: 228px">商品代码</th>
                        <th class="auto-style1" style="width: 228px">商品名称</th>
                        <th class="auto-style1" style="width: 228px">商品类别</th>
                        <th class="auto-style1" style="width: 228px">商品单位</th>
                        <th class="auto-style1" style="width: 70px">功能</th>
                    </tr>
                    <%
                        List<zl_and_jc_info> zl_and_jc_info = Session["zl_and_jc_select"] as List<zl_and_jc_info>;
                        if (zl_and_jc_info != null)
                        {
                            for (int i = 0; i < zl_and_jc_info.Count; i++)
                            {                          
                    %>
                    <tr id="del_row_cs<%=i %>">
                        <%--style="font-size: 90%; padding-left: 2%;"--%>
                        <td style="font-size: 14px; padding-left: 0.5%; width: 22px;"><%=(i+1) %></td>
                        <td class="bg_bj">
                            <input type="text"class="input_tr" id="sp_name" name="sp_dm_cs<%=i %>" value="<%=zl_and_jc_info[i].sp_dm %>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="Text1" name="name_cs<%=i %>" value="<%=zl_and_jc_info[i].name %>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="Text2" name="lei_bie_cs<%=i %>" value="<%=zl_and_jc_info[i].lei_bie %>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="ck_dj<%=i %>" name="dan_wei_cs<%=i %>" value="<%=zl_and_jc_info[i].dan_wei %>" /></td>
                        <td class="bg_bj">
                            <input type="hidden" class="input_tr" id="Text3" name="id_cs<%=i %>" value="<%=zl_and_jc_info[i].id %>" /><input id="checkbox" name="Checkbox_bd<%=i %>" value=" <%=i %>" type="checkbox" /></td>

                    </tr>

                    <%
                            }
                        }
                    %>
                </table>
            </div>

            <%--<div style="margin-left: 41%; margin-top: 4%;">
                <asp:Button CssClass="input_tr" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" />
                <asp:Button CssClass="input_tr" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" />
                <asp:Button CssClass="input_tr" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="input_tr" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
            </div>--%>
        </div>
    </form>
</body>
</html>
