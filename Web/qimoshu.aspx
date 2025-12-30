<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qimoshu.aspx.cs" Inherits="Web.qimoshu" %>

<%@ Import Namespace="SDZdb" %>
<%@ Import Namespace="System.Collections.Generic" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
        function bhhq(row) {
            $.ajax({
                type: "post",
                url: "qi_chu.aspx?act=PostUser&id=" + $("#sp_dm" + row).val(),
                dataType: "json",
                data: {},
                success: function (data) {
                    $("#sp_cplb" + row).val(data.lei_bie)
                    $("#sp_name" + row).val(data.name)
                },
                error: function (err) {

                }
            });
        }

        function heji() {
            // 计算期初金额合计
            var qichuTotal = 0;
            // 计算期末金额合计
            var qimoTotal = 0;

            $('.qichu_jine').each(function () {
                var val = parseFloat($(this).val()) || 0;
                qichuTotal += val;
            });

            $('.qimo_jine').each(function () {
                var val = parseFloat($(this).val()) || 0;
                qimoTotal += val;
            });

            $('#heji').html("期初合计：" + qichuTotal.toFixed(2) + " | 期末合计：" + qimoTotal.toFixed(2));
        }

        $(function () {
            heji();
        });

        function test(obj) {
            var v = $(obj).select.length();
            alert(v);
        }

        function del_row(row) {
            var rowIndex = $("#del_row_cs1").context.rowIndex;
            $("#del_row" + row + "").remove();
        }

        $(document).ready(function () {
            var row = 1;
            $("#dj_yh").click(function () {
                var rowLength = $("#biao_ge tr").length;
                var insertStr = "<tr id='del_row" + row + "' >"
                               + "<td style='font-size: 14px;padding-left: 0.5%;width: 18px;'>" + (rowLength) + "</td>"
                               + "<td class='bg_bj_sj'></td>"
                               + "<td ><input type='text' class='input_tr' style='width:147px;margin:1px'  id='sp_name" + row + "' name='cpname" + row + "' ></input></td>"
                               + "<td class='bg_bj_dm'>"
                               + "<select class='input_tr' id='sp_dm" + row + "' name='cpid" + row + "' onchange='bhhq(" + row + ")'>"
                            + "<option>选择编号</option>"
                            +<%
        System.Collections.Generic.List<Web.ServerEntity.JinChuZiLiaoItem> jichu = Session["jichu"] as System.Collections.Generic.List<Web.ServerEntity.JinChuZiLiaoItem>;
                                if (jichu!=null){
                                    for (int ji = 0; ji < jichu.Count; ji++) 
                                    {
                                        %>
                                            + "<option value ='<%=jichu[ji].sp_dm %>'><%=jichu[ji].sp_dm %></option>"
                                            <%
                                    }
                                }
                                 %>

                        + "</select></td>"
                               + "<td class='bg_bj_lb'><input type='text' style='width:147px;margin:1px' id='sp_cplb" + row + "' class='input_tr' name='cplb" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' style='width:147px;margin:1px'  id='ck_dj" + (rowLength - 1) + "' class='input_tr' name='cpsj" + row + "' ></input></td>"
                               + "<td class='bg_bj_sl'><input type='text' style='width:147px;margin:1px'  id='ck_sl" + (rowLength - 1) + "' class='input_tr' name='cpsl" + row + "' ></input></td>"
                               + "<td onclick='js_xx2(" + (rowLength - 1) + ")' id='dj_js" + (rowLength - 1) + "' style='width:147px;margin:1px'></td>"
                               + "<td  style='border-right: 1px dashed #a8a8a8;'><input type='button' class='qc_sc'value='删除'  onclick='del_row(" + row + ")'/></td>"
                               + "</tr>";
                $("#biao_ge tr:eq(" + (rowLength - 1) + ")").after(insertStr);
                row++;
                $('#row_i1').val(row);
            });

            function click(obj) {
                alert($(obj).context.innerHTML);
            }
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
            if (document.getElementById("xx_hidden").value == "tj_false") {
                return false;
            }
        });

     
    </script>
    <style type="text/css">
        .hidden_load {
            display: none;
        }

        td {
            text-align: center;
            height: 40px;
            background-color: white;
            font-size: 10px;
        }

        .qc_sc {
            margin-left: 1px;
        }
        .new_cuku {
            width: 28px;
        }
        .table_div {
            width:100%;
            overflow:scroll;
        }
        .fun_div {
            width: 100%;
            height: 50px;
            display: flex;
            flex-direction: row;
            justify-content: start;
            align-items: center;
        }

        .page_bt {
            border: none;
            background-color: #009688;
            color: white;
            width: 50px;
            height: 25px;
            border-radius: 2px;
        }
        
        .auto-style1 {
            height: 49px;
            text-align: center;
            background-color:#143268;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position:sticky;
        }

        .item_td {
            text-align: center;
            height: 40px;
            color:black;
            font-size:14px;
            background-color: #98c9d9;
        }

        tr:hover {
            transform: translateY(-4px);
            box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1);
            z-index: 10;
        }
        
        /* 奇数行样式 */
        tr:nth-child(odd) .item_td {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .item_td {
            background-color: #e0f7fa; 
        }

        .qichu_input {
            margin-top:10px;
            margin-left: 10px;
            width: 80px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
            display: inline-block;
            transition: all 0.4s cubic-bezier(0.165, 0.84, 0.44, 1);
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
        }
        
        .table_input {
            border: none;
            color:black;
            height: 90%;
            width: 90%;
        }
        
         /* 奇数行样式 */
        tr:nth-child(odd) .table_input {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .table_input {
            background-color: #e0f7fa;
        }

        /* 奇数行样式 */
        tr:nth-child(odd) .bg_bj {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .bg_bj {
            background-color: #e0f7fa;
        }

        .input_tr {
            border: none;
            text-align: center;
            color:black;
            width: 90%;
            height: 90%;
        }
        
         /* 奇数行样式 */
        tr:nth-child(odd) .input_tr {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .input_tr {
            background-color: #e0f7fa;
        }

        .select_input {
            width: 200px;
            border: none;
            height: 64%;
            border: 1px solid white;
            border-radius: 3px;
        }

        .d-main.table_div {
            overflow:auto;
            margin-left:1%;
            margin-top:30px;
            box-sizing: border-box;
            padding-left:5px;
            padding-right:5px;
            width:97.5%;
            height:80%;
            border:3px solid #D3D3D3;
            box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
        }
        
        .d-header {
            margin-left:1%;
            margin-top:10px;
            padding:5px;
            width:97%;
            height: 50px;
            min-height:50px;
            background: linear-gradient(135deg, #3030c7 0%, #2424a1 50%, #a8a8d2 100%);
            border-radius:5px;
            box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
        }
        
    </style>
    <title>期初期末数量查询</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="hidden" id="xx_hidden" value="tj_false" />
            <input type="hidden" id="row_i1" name="row_i" />
            <input type="hidden" id="tj_pd_id" name="tj_pd" />
            <div class="d-header">
                <asp:TextBox ID='qc_cx' class='select_input' Autocomplete='off' runat="server" placeholder="按商品名称搜索"/>
                <label class="lable_select" style="font-size: 16px;">期初日期：</label>
                <input type="date" class="time_select" style="width: 150px;height: 32px;" name="time_qs" id="time_qs" />
                <label class="lable_select" style="font-size: 16px;">期末日期：</label>
                <input type="date" class="time_select" style="width: 150px;height: 32px;" name="time_jz" id="time_jz" />
                <select id="warehouseSelect" name="warehouse_select" style="width: 120px;height: 32px;" class="warehouse-select">
                <!-- 动态加载仓库选项 -->
                <option value="">请选择仓库</option>
                    <%
                        // 从Session获取仓库列表
                        var warehouseList = Session["warehouseList"] as List<string>;
    
                        if (warehouseList != null && warehouseList.Count > 0)
                        {
                            foreach (string warehouse in warehouseList)
                            {
                                if (!string.IsNullOrWhiteSpace(warehouse))
                                {
                                    string trimmedWarehouse = warehouse.Trim();
                                    %>
                                    <option value="<%=trimmedWarehouse%>"><%=trimmedWarehouse%></option>
                                    <%
                                }
                            }
                        }
                        else
                        {
                            // 可选：如果没有数据，显示一个默认选项
                            %>
                            <option value="">暂无仓库数据</option>
                            <%
                        }
                    %>
                    </select>
                <asp:Button ID="qc_query" OnClick="bt_chaxun" class="qichu_input" Text="查询" runat="server" UseSubmitBehavior="false" />
                <asp:Button ID="Button2" class="qichu_input" OnClick="bt_select_Click" Text="刷新数据" runat="server" UseSubmitBehavior="false" />
            </div>
            <div class="d-main table_div">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="margin-top: 1%; width: 100%; table-layout: fixed;">
                <tr id="dj_yh">
                    <td class="auto-style1" style="width: 4%;">序号</td>
                    <th class="auto-style1" style="width: 8%;">图片</th>
                    <td class="auto-style1" style="width: 12%;">商品名称</td>
                    <td class="auto-style1" style="width: 10%;">商品代码</td>
                    <td class="auto-style1" style="width: 10%;">商品类别</td>
                    <td class="auto-style1 qichu-column" style="width: 8%;">期初数量</td>
                    <td class="auto-style1 qichu-column" style="width: 8%;">期初金额</td>
                    <td class="auto-style1 qimo-column" style="width: 8%;">期末数量</td>
                    <td class="auto-style1 qimo-column" style="width: 8%;">期末金额</td>
                </tr>
                    <%
                        // 注意：这里需要修改为新的 QiChuQiMoShuItem 类型
                        System.Collections.Generic.List<Web.ServerEntity.QiChuQiMoShuItem> qi_chu_select = 
                            Session["qi_chu_select"] as System.Collections.Generic.List<Web.ServerEntity.QiChuQiMoShuItem>;
                        
                        if (qi_chu_select != null && qi_chu_select.Count > 0)
                        {
                            for (int i = 0; i < qi_chu_select.Count; i++)
                            {
                                var item = qi_chu_select[i];
                                string imageSrc = "";
                                if (!string.IsNullOrEmpty(item.mark1))
                                {
                                    if (item.mark1.StartsWith("data:image"))
                                    {
                                        imageSrc = item.mark1;
                                    }
                                    else
                                    {
                                        imageSrc = "data:image/jpg;base64," + item.mark1;
                                    }
                                }
                    %>
                    <tr id="del_row_cs<%=i%>">
                        <td style="font-size: 14px; padding-left: 0.5%;" class="input_tr">
                            <%=(i+1) %>
                        </td>
                        <td class="bg_bj">
                            <% if (!string.IsNullOrEmpty(imageSrc)) { %>
                                <img style="width: 60px; height: 60px; object-fit: cover;" src="<%=imageSrc%>" alt="商品图片"/>
                            <% } else { %>
                                <span>无图片</span>
                            <% } %>
                        </td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" name="cpname_cs<%=i%>" value="<%=item.name%>" readonly />
                        </td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" name="cpid_cs<%=i%>" value="<%=item.sp_dm%>" readonly />
                        </td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" name="cplb_cs<%=i%>" value="<%=item.lei_bie%>" readonly />
                        </td>
                        <!-- 期初数据 -->
                        <td class="bg_bj qichu-column">
                            <input type="text" class="input_tr qichu_shuliang" 
                                   value="<%=item.qichu_shuliang.ToString("F2")%>" readonly />
                        </td>
                        <td class="bg_bj qichu-column">
                            <input type="text" class="input_tr qichu_jine" 
                                   value="<%=item.qichu_jine.ToString("F2")%>" readonly />
                        </td>
                        <!-- 期末数据 -->
                        <td class="bg_bj qimo-column">
                            <input type="text" class="input_tr qimo_shuliang" 
                                   value="<%=item.qimo_shuliang.ToString("F2")%>" readonly />
                        </td>
                        <td class="bg_bj qimo-column">
                            <input type="text" class="input_tr qimo_jine" 
                                   value="<%=item.qimo_jine.ToString("F2")%>" readonly />
                        </td>
                    </tr>
                    <%
                            }
                        }
                        else
                        {
                    %>
                    <tr>
                        <td colspan="10" style="text-align: center; height: 50px; color: #666;">
                            暂无数据，请先选择日期并点击查询
                        </td>
                    </tr>
                    <%
                        }
                    %>
                </table>
            </div>

            <div class="d-footer" style="width: 300px; height: 70px; display: flex; justify-content: space-around; align-items: center; height:0; overflow:hidden">
                <asp:Button CssClass="page_bt" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" />
                <asp:Button CssClass="page_bt" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" />
                <asp:Label runat="server" ID="lblCurrentPage" style="font-weight:bold"></asp:Label>
                <asp:Button CssClass="page_bt" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="page_bt" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
                <span id="heji"></span>
            </div>
        </div>
    </form>
</body>
</html>