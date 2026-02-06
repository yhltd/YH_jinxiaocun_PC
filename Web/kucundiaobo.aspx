<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kucundiaobo.aspx.cs" Inherits="Web.kucundiaobo" %>

<%@ Import Namespace="SDZdb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="/Myadmin/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="/Myadmin/js/json2.js" type="text/javascript"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>

        var row = 1;
        var del_hang = {};
        var list = [];
        var ruku = {
            gonghuo: "",
            orderid: "",
            itemList: []
        }
        $(function () {
            getList();
            getGongHuoList();
            getWarehouseList();

            $("#dj_row").click(function () {
                $("#row_i1").val($("#biao_ge tr").length);
            })
            $("#insert").click(function () {
                var myList = JSON.parse(list)
                var newTr = "";
                newTr += "<tr id='del_row" + row + "'>"
                newTr += "<td class='item_td'><input type='checkbox' class='checkBox_list' onclick='choice_ruku(this.value," + row + ")' id='checkbox" + row + "' name='checkbox" + row + "' value='0'></checkbox></td>"
                newTr += "<td class='item_td'>" + row + "</td>"
                newTr += "<td class='item_td' id='sp_name" + row + "'></td>"
                newTr += "<td class='item_td'>"
                newTr += "<select class='input_tr' id='sp_dm" + row + "' name='sp_dm" + row + "' onchange='bhhq(" + row + ")'>"
                newTr += "<option value='选择编号'>选择编号</option>"
                for (var i = 0; i < myList.length; i++) {
                    newTr += "<option class='option_list' value='" + i + "'>" + myList[i].sp_dm + "</option>"
                }
                newTr += "</select></td>"
                newTr += "<td class='item_td' id='sp_cplb" + row + "'></td>"
                newTr += "<td class='item_td' id='sp_cpsj" + row + "'></td>"
                newTr += "<td class='item_td' id='sp_cpsl" + row + "'><input id='num" + row + "' name='num" + row + "' type='number' autocomplete='off' class='table_input' placeholder='总数量：'/></td>"
                newTr += "<td class='item_td' id='sp_cpprice" + row + "'><input id='price" + row + "' name='price" + row + "' type='number' autocomplete='off' class='table_input'/></td>"
                newTr += "<td class='item_td'><input type='button' class='rk_btu' value='删除' onclick='del_row(" + row + ")'/><input type='text' id='check" + row + "' hidden='hidden' name='check" + row + "' /></td>"
                newTr += "</tr>"
                $("#biao_ge").append(newTr);
                row++;
            });

            $("#db_bt").click(function () {
                if (ruku.itemList.length == 0) {
                    alert("请选择商品")
                } else {
                    $(".ruku_div").css("display", "block")
                    $(".mask").css("display", "block")
                }
            })

            $("#back_ruku").click(function () {
                $(".ruku_div").css("display", "none")
                $(".mask").css("display", "none")
            })

            $(".main-div").on('click', function (e) {
                var this_div = $("#userFun_div")
                $("#userFun_div").hide();
            })


            $("#insert_db").click(function () {
                if ($('.order_id_input').val() == "") {
                    alert("请输入订单号");
                    return;
                }

                var Cwarehouse = document.getElementById('warehouseSelect').value;
                var Rwarehouse = $("#ruku_warehouse").val();
                ruku.orderid = $('.order_id_input').val();
                ruku.Rwarehouse = Rwarehouse;
                ruku.Cwarehouse = Cwarehouse;


                $.ajax({
                    type: "Post",
                    url: "kucundiaobo.aspx",
                    data: {
                        act: "insert",
                        infos: JSON.stringify(ruku)
                    },
                    dataType: "json",
                    success: function (result) {
                        if (result > 0) {
                            alert("调拨成功")
                            ruku.itemList = [];
                            $(".ruku_div").css("display", "none")
                            $(".mask").css("display", "none")
                            $('#shuaxin').click();
                        }
                    }
                });
            })

            $("#shuaxin").click(function () {
                for (var i = 1; i <= row; i++) {
                    del_row(i)
                }
                row = 1;
                getList();
            })
        })

        function check(e, index) {
            if (e == 0) {
                alert("请选择编号")
                return false
            }
            if ($("#num" + index).text() == "" && $("#num" + index).val() == "" || $("#num" + index).val() == 0) {
                alert("请输入数量")

                return false
            }
            if ($("#price" + index).text() == "" && $("#price" + index).val() == "" || $("#price" + index).val() == 0) {
                alert("请输入单价")
                return false
            }
            return true
        }

        function choice_ruku(e, index) {
            if (check(e, index)) {
                if ($("#checkbox" + index).is(":checked")) {
                    var item = { id: e, num: $("#num" + index).val(), price: $("#price" + index).val() };
                    ruku.itemList.push(item)
                    console.log(ruku.itemList)
                    $("#check" + index).val("true");
                } else {
                    for (var i = 0; i < ruku.itemList.length; i++) {
                        if (ruku.itemList[i].id == $("#checkbox" + index).val()) {
                            ruku.itemList.splice(i, 1)
                            break;
                        }
                    }
                    $("#check" + index).val("");
                    console.log(ruku.itemList)
                }

            } else {
                $("#checkbox" + index).prop("checked", false);
            }
        }

        function del_row(row) {
            del_hang[row] = ""
            $("#del_row" + row + "").remove();
        }

        function setList(result) {
            var insertStr = "";
            for (var j = 0; j < result.length; j++) {
                insertStr += "<tr id='del_row" + row + "'>"
                insertStr += "<td class='item_td'><input type='checkbox' class='checkBox_list' onclick='choice_ruku(this.value," + row + ")' id='checkbox" + row + "' name='checkbox" + row + "' value='" + result[j].id + "'></checkbox></td>"
                insertStr += "<td class='item_td'>" + row + "</td>"
                insertStr += "<td class='item_td' id='sp_name" + row + "' name='sp_name" + row + "'>" + result[j].name + "</td>"
                insertStr += "<td class='item_td'>"
                insertStr += "<select class='input_tr' id='sp_dm" + row + "' onchange='bhhq(" + row + ")' name='sp_dm" + row + "'>"
                insertStr += "<option>选择编号</option>"
                for (var i = 0; i < result.length; i++) {
                    if (result[i].sp_dm == result[j].sp_dm) {
                        insertStr += "<option class='option_list' selected value='" + i + "'>" + result[i].sp_dm + "</option>"
                        continue;
                    }
                    insertStr += "<option class='option_list' value='" + i + "'>" + result[i].sp_dm + "</option>"
                }
                insertStr += "</select></td>"
                insertStr += "<td class='item_td' id='sp_cplb" + row + "'  name='sp_cplb" + row + "'>" + result[j].lei_bie + "</td>"
                insertStr += "<td class='item_td' id='sp_cpsj" + row + "' name='sp_cpsj" + row + "'>" + result[j].dan_wei + "</td>"
                insertStr += "<td class='item_td' id='sp_cpsl" + row + "' name='sp_cpsl" + row + "' ><input id='num" + row + "' name='num" + row + "' type='number' autocomplete='off' class='table_input' oninput='bindInput_num(this.value," + result[j].id + ")' placeholder='总数量：" + result[j].maxNum + "'/></td>"
                insertStr += "<td class='item_td' id='sp_cpprice" + row + "' name='sp_cpprice" + row + "'><input id='price" + row + "' name='price" + row + "' type='number' autocomplete='off' oninput='bindInput_price(this.value," + result[j].id + ")' class='table_input' /></td>"
                insertStr += "<td class='item_td'><input type='button' class='rk_btu' value='删除' onclick='del_row(" + row + ")'/><input type='text' hidden='hidden' id='check" + row + "' name='check" + row + "' /></td>"
                insertStr += "</tr>"
                row++;
            }
            $("#hangshu").val(row)
            $("#biao_ge").append(insertStr);
        }

        function getList() {
            // 获取选中的仓库值
            var warehouse = document.getElementById('warehouseSelect').value;

            var insertStr = "";
            $.ajax({
                type: "post",
                url: "kucundiaobo.aspx",
                data: {
                    act: 'newSp',
                    warehouse: warehouse
                },
                success: function (result) {
                    list = result;
                    setList(JSON.parse(result));
                },
                error: function (err) {
                    console.log(err);
                    alert("获取商品列表失败");
                }
            });
        }

        function getGongHuoList() {
            $.ajax({
                type: "Post",
                url: "kucundiaobo.aspx",
                data: {
                    act: "gongguoList"
                },
                dataType: "json",
                success: function (result) {
                    var gonghuo = ""
                    for (var i = 0; i < result.length; i++) {
                        gonghuo += "<option class='option_list' value='" + result[i] + "'>" + result[i] + "</option>"
                    }
                    $(".gonghuo_select").append(gonghuo);
                    ruku.gonghuo = result[0]
                }
            });
        }

        function bindInput_num(e, id) {
            for (var i = 0; i < ruku.itemList; i++) {
                if (id == ruku.itemList[i].id) {
                    ruku.itemList[i].num = e
                    break;
                }
            }
        }
        function bindInput_price(e, id) {
            for (var i = 0; i < ruku.itemList; i++) {
                if (id == ruku.itemList[i].id) {
                    ruku.itemList[i].price = e
                    break;
                }
            }
        }
        function bindInput_select(e) {
            var ll = JSON.parse(list);
            for (var i = 1; i < row; i++) {
                var name = $("#sp_name" + i).text();
                var dm = ll[$("#sp_dm" + i).val()].sp_dm;
                if (name.indexOf(e) == -1 && dm.indexOf(e) == -1) {
                    $("#del_row" + i).css("display", "none");
                } else {
                    $("#del_row" + i).removeAttr("style");
                }
            }
        }
        function bhhq(row) {
            var i = $("#sp_dm" + row).val();
            var rows = JSON.parse(list)[i];
            $("#checkbox" + row).val(rows.id);
            $("#sp_name" + row).text(rows.name);
            $("#sp_cplb" + row).text(rows.lei_bie);
            $("#sp_cpsj" + row).text(rows.dan_wei);
            $("#num" + row).attr("placeholder", "总数量：" + rows.maxNum)
        }

        function getGongguo(e) {
            ruku.gonghuo = e
        }


        function getWarehouseList() {
            $.ajax({
                type: "Post",
                url: "kucundiaobo.aspx",
                data: {
                    act: "warehouseList"
                },
                dataType: "json",
                success: function (warehouses) {
                    // 填充出库仓库下拉框
                    var warehouseSelect = $('#warehouseSelect');
                    warehouseSelect.empty(); // 清空现有选项

                    if (warehouses && warehouses.length > 0) {
                        // 添加第一个选项作为默认选中
                        warehouseSelect.append('<option value="' + warehouses[0] + '" selected>' + warehouses[0] + '</option>');

                        // 添加其他选项
                        for (var i = 1; i < warehouses.length; i++) {
                            warehouseSelect.append('<option value="' + warehouses[i] + '">' + warehouses[i] + '</option>');
                        }
                    } else {
                        // 如果没有仓库，添加一个空选项
                        warehouseSelect.append('<option value="" selected>请先添加仓库</option>');
                    }

                    // 填充入库仓库下拉框
                    var rukuWarehouseSelect = $('#ruku_warehouse');
                    rukuWarehouseSelect.empty(); // 清空现有选项

                    if (warehouses && warehouses.length > 0) {
                        // 入库仓库默认选中第一个仓库
                        rukuWarehouseSelect.append('<option value="' + warehouses[0] + '" selected>' + warehouses[0] + '</option>');

                        // 添加其他选项
                        for (var i = 1; i < warehouses.length; i++) {
                            rukuWarehouseSelect.append('<option value="' + warehouses[i] + '">' + warehouses[i] + '</option>');
                        }
                    } else {
                        // 如果没有仓库，添加一个空选项
                        rukuWarehouseSelect.append('<option value="" selected>请先添加仓库</option>');
                    }
                },
                error: function (err) {
                    console.log("获取仓库列表失败:", err);
                    // 失败时设置默认值
                    $('#warehouseSelect').html('<option value="" selected>获取仓库失败</option>');
                    $('#ruku_warehouse').html('<option value="" selected>获取仓库失败</option>');
                }
            });
        }


       

    </script>
    <style type="text/css">
        .page_bt {
            border: none;
            background-color: #009688;
            color: white;
            width: 50px;
            height: 25px;
            border-radius: 2px;
        }
        .auto-style1 {
            display:flexbox;
            height: 49px;
            text-align: center;
            /*background-color: #2F4056;*/
            background-color:#143268;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position:sticky;
            /*border:1px solid white;*/
            top : 0;
        }


        #dj_row {
            position: relative;
            left: 13.7%;
        }
        .rk_btu {
            border: 1px solid #ccc;
            padding: 4px 0px;
            border-radius: 3px;
            width: 80%;
            height: 80%;
            background-color: #009688;
            color: white;
            cursor: pointer;
            transition: all 0.4s cubic-bezier(0.165, 0.84, 0.44, 1);
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
        }
        .item_td {
            text-align: center;
            height: 40px;
            color:black;
            font-size:14px;
            background-color: #98c9d9;
            /*border: 2.5px solid white;*/
        }
        
        /* 奇数行样式 */
        tr:nth-child(odd) .item_td {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .item_td {
            background-color: #e0f7fa; 
        }

        
        .rk_bt {
            margin-left: 10px;
            width: 90px;
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
            background-color: #e0f7fa;  /* 更浅的蓝色 */
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
            background-color: #e0f7fa;  /* 更浅的蓝色 */
        }

        .select_input {
            width: 300px;
            border: none;
            height: 64%;
            border: 1px solid white;
            border-radius: 3px;
        }

        .ruku_div {
            width: 30%;
            height: 40%;
            position: fixed;
            top: 10%;
            left: 25%;
            background-color: white;
            z-index: 20;
            box-shadow: 10px 10px 15px;
            border-radius:2px
            
        }
        .ruku_info_div {
            width: 91%;
            height: 25%;
            display: flex;
            align-items: center;
            margin: auto;
        }
        .order_id_input {
            border: 1px solid #F0F0F0;
            width: 240px;
            height: 30px;
            border-radius: 2px;
        }
        .gonghuo_select {
            margin-left: 15px;
            width: 200px;
            height: 30px;
            border: none;
            border: 1px solid #F0F0F0;
        }
        .ruku_bottom_div {
            width: 43%;
            margin: auto;
            display: flex;
            justify-content: space-around;
        }
        .mask {
            position : fixed;
            width : 100%;
            height: 100%;
            z-index:19;
            top: 0;
            
        }
        .d-main {
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
        /* 仓库下拉选择样式 */
        .warehouse-select {
            height: 34px;
            padding: 0 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 14px;
            color: #333;
            background-color: white;
            cursor: pointer;
            margin-left: 10px;
        }

        .warehouse-select:focus {
            outline: none;
            border-color: #409EFF;
            box-shadow: 0 0 5px rgba(64, 158, 255, 0.3);
        }

        /* 适配原有按钮的样式 */
        .new_ss_div {
            display: flex;
            align-items: center;
            gap: 10px;
            padding: 10px;
            background: linear-gradient(135deg, #3030c7 0%, #2424a1 50%, #a8a8d2 100%);
            border-radius: 4px;
            margin-bottom: 10px;
        }

        .select_input {
            flex: 1;
            height: 34px;
            padding: 0 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 14px;
        }

        .rk_bt {
            height: 34px;
            padding: 0 15px;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
        }

    </style>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <input type="hidden" id="hangshu" name="hangshu" />
            <input type="hidden" id="tj_pd_id" name="tj_pd" />
            <input type="hidden" id="row_i1" name="row_i" />
            <input type="hidden" id="xx_hidden" value="tj_false" />
            <div class="d-header new_ss_div">
                <input id="ru_cx" class="select_input" autocomplete="off" oninput="bindInput_select(this.value)" placeholder="按商品名称/商品代码搜索" />
                <select id="warehouseSelect" class="warehouse-select" onchange="warehouseChanged()">
                    <!-- 动态加载仓库选项 -->
                </select>
                <input id="db_bt" class="rk_bt" type="button" value="调拨"/>
                <input id="shuaxin" class="rk_bt" type="button" value="刷新"/>          
            </div> 
            <div class="d-main" id="table_div">

                <table id="biao_ge" name="bg_row" cellspacing="0" cellpadding="0">
                    <tr id="dj_yh">
                        <td class="auto-style1" style="width: 10%">调拨</td>
                        <td class="auto-style1" style="width: 10%">序号</td>
                        <td class="auto-style1" style="width: 15%;">商品名称</td>
                        <td class="auto-style1" style="width: 15%;">商品代码</td>
                        <td class="auto-style1" style="width: 10%;">商品类别</td>
                        <td class="auto-style1" style="width: 10%;">商品单位</td>
                        <td class="auto-style1" style="width: 10%;">数量</td>
                        <td class="auto-style1" style="width: 10%;">单价</td>
                        <td class="auto-style1" style="width: 10%;">功能</td>
                      </tr>
                </table>
            </div>
        </div>
    </form>
    <div class="ruku_div" style="display:none">
        <div class="ruku_info_div">
            <label style="font-size: 14px; color: #333; margin-bottom: 5px;margin-right: 5px; display: block;">订单号</label>
            <input class="order_id_input" placeholder="订单号" value=""/>
        </div>
        <div class="ruku_info_div">
            <label style="font-size: 14px; color: #333; margin-bottom: 5px;margin-right: 5px; display: block;">公司</label>
            <select class="gonghuo_select" onchange="getGongguo(this.value)"></select>
        </div>
        <div class="ruku_info_div">
            <label style="font-size: 14px; color: #333; margin-bottom: 5px; display: block;">仓库</label>
            <select id="ruku_warehouse" style="margin-left: 20px;width: 200px;height: 30px;border: none;border: 1px solid #F0F0F0;">
                <!-- 动态加载仓库选项 -->
            </select>
        </div>
        <div class="ruku_bottom_div">
            <input class="rk_bt" id="back_ruku" type="button" value="返回"/>
            <input class="rk_bt" id="insert_db" type="button" value="确认调拨"/>
        </div>
    </div>
    <div class="mask" style="display:none"></div>
</body>
</html>