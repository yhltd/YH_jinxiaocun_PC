<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xiaoshoutuihuo.aspx.cs" Inherits="Web.xiaoshoutuihuo" %>

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
        var userName = "系统用户";
        var printInfo = {}; // 存储打印信息

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

            $("#ru_bt").click(function () {
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

            // 打印按钮点击事件 - 先弹出信息输入弹窗
            $("#print_btn").off('click').on('click', function () {
                console.log("打印按钮被点击");
                showPrintInfoDialog();
            });

            // 取消打印信息输入
            $("#print_info_cancel").off('click').on('click', function () {
                $(".print_info_dialog").css("display", "none");
                $(".mask").css("display", "none");
            });

            // 确认打印信息，显示预览
            $("#print_info_confirm").off('click').on('click', function () {
                var orderId = $("#print_order_id").val();
                var creator = $("#print_creator").val();
                var auditor = $("#print_auditor").val();
                var receiver = $("#print_receiver").val();
                var warehouse = $("#print_warehouse").val();

                if (!orderId) {
                    alert("请输入退货单号");
                    return;
                }

                if (!creator) {
                    alert("请输入制单人");
                    return;
                }

                if (!warehouse) {
                    alert("请选择退货仓库");
                    return;
                }

                // 存储打印信息
                printInfo = {
                    orderId: orderId,
                    creator: creator,
                    auditor: auditor,
                    receiver: receiver,
                    warehouse: warehouse
                };

                // 隐藏信息输入弹窗
                $(".print_info_dialog").css("display", "none");

                // 生成并显示打印预览
                generatePrintContent();
            });

            // 取消打印
            $("#print_cancel").off('click').on('click', function () {
                $(".print_dialog").css("display", "none");
                $(".mask").css("display", "none");
            });

            // 确认打印
            $("#print_confirm").off('click').on('click', function () {
                window.print();
            });


            $("#insert_ruku").click(function () {
                if ($('.order_id_input').val() == "") {
                    alert("请输入订单号");
                    return;
                }
                var Rwarehouse = $("#ruku_warehouse").val();
                ruku.Rwarehouse = Rwarehouse;
                ruku.orderid = $('.order_id_input').val()
                $.ajax({
                    type: "Post",
                    url: "xiaoshoutuihuo.aspx",
                    data: {
                        act: "insert",
                        infos: JSON.stringify(ruku)
                    },
                    dataType: "json",
                    success: function (result) {
                        if (result > 0) {
                            alert("退货入库成功")
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
            var insertStr = "";
            $.ajax({
                type: "post",
                url: "xiaoshoutuihuo.aspx",
                data: {
                    act: 'newSp'
                },
                success: function (result) {
                    list = result;
                    setList(JSON.parse(result));
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }

        function getGongHuoList() {
            $.ajax({
                type: "Post",
                url: "xiaoshoutuihuo.aspx",
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

        function Enter(e) {
            if (e.keyCode == 13) {
                var test = document.getElementById("qr_code_text").value;
                console.log(test)
                $("#last_code").text("本次扫描结果：" + test)
                var myList = JSON.parse(list)
                console.log(myList)
                console.log(row)
                if (test == "") {
                    return;
                }

                var panduan = false
                for (var i = 1; i < row; i++) {
                    var daima_id = "sp_dm" + i
                    if (!del_hang.hasOwnProperty(i)) {
                        var this_daima_text = document.getElementById('' + daima_id).value;
                        this_daima_text = myList[this_daima_text].sp_dm
                        console.log(this_daima_text)
                        if (this_daima_text == test) {
                            panduan = true
                            var num_id = "num" + i
                            var this_num = document.getElementById('' + num_id).value;
                            if (this_num == "") {
                                this_num = 0
                            }
                            this_num = this_num * 1 + 1
                            document.getElementById('' + num_id).value = this_num
                            document.getElementById("qr_code_text").value = ""
                            break;
                        }
                    }
                }
                if (panduan == false) {
                    var newTr = ""
                    var xiabiao = "空"
                    for (var j = 0; j < myList.length; j++) {
                        if (myList[j].sp_dm == test) {
                            xiabiao = j;
                            break;
                        }
                    }
                    if (xiabiao != '空') {

                        newTr += "<tr id='del_row" + row + "'>"
                        newTr += "<td class='item_td'><input type='checkbox' class='checkBox_list' onclick='choice_ruku(this.value," + row + ")' id='checkbox" + row + "' name='checkbox" + row + "' value='0'></checkbox></td>"
                        newTr += "<td class='item_td'>" + row + "</td>"
                        newTr += "<td class='item_td' id='sp_name" + row + "'>" + myList[xiabiao].name + "</td>"
                        newTr += "<td class='item_td'>"
                        newTr += "<select class='input_tr' id='sp_dm" + row + "' name='sp_dm" + row + "' onchange='bhhq(" + row + ")'>"
                        newTr += "<option value='" + xiabiao + "'>" + myList[xiabiao].sp_dm + "</option>"
                        for (var i = 0; i < myList.length; i++) {
                            newTr += "<option class='option_list' value='" + i + "'>" + myList[i].sp_dm + "</option>"
                        }
                        newTr += "</select></td>"
                        newTr += "<td class='item_td' id='sp_cplb" + row + "'>" + myList[xiabiao].lei_bie + "</td>"
                        newTr += "<td class='item_td' id='sp_cpsj" + row + "'>" + myList[xiabiao].dan_wei + "</td>"
                        newTr += "<td class='item_td' id='sp_cpsl" + row + "'><input id='num" + row + "' name='num" + row + "' type='number' autocomplete='off' class='table_input' placeholder='总数量：' value='" + 1 + "'/></td>"
                        newTr += "<td class='item_td' id='sp_cpprice" + row + "'><input id='price" + row + "' name='price" + row + "' type='number' autocomplete='off' class='table_input'/></td>"
                        newTr += "<td class='item_td'><input type='button' class='rk_btu' value='删除' onclick='del_row(" + row + ")'/><input type='text' id='check" + row + "' hidden='hidden' name='check" + row + "' /></td>"
                        newTr += "</tr>"
                        $("#biao_ge").append(newTr);
                        row++;
                        document.getElementById("qr_code_text").value = ""
                    } else {
                        alert("基础配置中无此商品代码")
                        document.getElementById("qr_code_text").value = ""
                    }
                }
            }
        };

        function getWarehouseList() {
            $.ajax({
                type: "Post",
                url: "xiaoshoutuihuo.aspx",
                data: {
                    act: "warehouseList"
                },
                dataType: "json",
                success: function (warehouses) {
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
                    $('#ruku_warehouse').html('<option value="" selected>获取仓库失败</option>');
                }
            });
        }

        // 显示打印信息输入弹窗
        function showPrintInfoDialog() {
            // 检查是否有选中的商品
            var hasSelectedItems = false;
            for (var i = 1; i < row; i++) {
                var checkbox = $("#checkbox" + i);
                if (checkbox.length > 0 && checkbox.is(":checked")) {
                    hasSelectedItems = true;
                    break;
                }
            }

            if (!hasSelectedItems) {
                alert("请先选择要打印的商品（勾选复选框）");
                return;
            }

            // 加载仓库到选择框
            loadWarehouseOptionsForPrint();

            // 显示弹窗
            $(".print_info_dialog").css("display", "block");
            $(".mask").css("display", "block");
        }

        // 加载仓库选项到打印信息弹窗
        function loadWarehouseOptionsForPrint() {
            var warehouseSelect = $("#print_warehouse");
            warehouseSelect.empty();
            warehouseSelect.append('<option value="">请选择退货仓库</option>');

            // 使用已有的仓库数据
            $.ajax({
                type: "Post",
                url: "xiaoshoutuihuo.aspx",
                data: {
                    act: "warehouseList"
                },
                dataType: "json",
                success: function (warehouses) {
                    if (warehouses && warehouses.length > 0) {
                        // 如果有当前选中的仓库，设置为默认值
                        var currentWarehouse = ruku.Rwarehouse || "";

                        warehouses.forEach(function (warehouse) {
                            var option = $('<option></option>').val(warehouse).text(warehouse);
                            if (warehouse === currentWarehouse) {
                                option.attr('selected', 'selected');
                            }
                            warehouseSelect.append(option);
                        });
                    }
                },
                error: function (err) {
                    console.log("加载仓库列表失败:", err);
                }
            });
        }

        // 生成打印内容 - 使用弹窗输入的信息
        function generatePrintContent() {
            var selectedItems = [];
            var totalQuantity = 0;
            var totalAmount = 0;

            console.log("开始生成打印内容");

            // 使用弹窗输入的信息
            var printInfo = window.printInfo || {};
            var orderId = printInfo.orderId || "无单号";
            var warehouse = printInfo.warehouse || "未指定仓库";
            var creator = printInfo.creator || "未知";
            var auditor = printInfo.auditor || "________________";
            var receiver = printInfo.receiver || "________________";

            console.log("打印信息:", printInfo);

            // 遍历表格，获取选中的商品
            var checkedCount = 0;
            for (var i = 1; i < row; i++) {
                var checkbox = $("#checkbox" + i);

                if (checkbox.length > 0 && checkbox.is(":checked")) {
                    checkedCount++;
                    var quantity = parseFloat($("#num" + i).val()) || 0;
                    var price = parseFloat($("#price" + i).val()) || 0;
                    var amount = (quantity * price).toFixed(2);

                    var item = {
                        name: $("#sp_name" + i).text() || "",
                        code: $("#sp_dm" + i + " option:selected").text() || "",
                        category: $("#sp_cplb" + i).text() || "",
                        unit: $("#sp_cpsj" + i).text() || "",
                        quantity: quantity,
                        price: price,
                        amount: parseFloat(amount)
                    };

                    selectedItems.push(item);
                    totalQuantity += quantity;
                    totalAmount += parseFloat(amount);
                }
            }

            console.log("选中的商品数量:", checkedCount);

            if (selectedItems.length === 0) {
                alert("请先选择要打印的商品（勾选复选框）");
                return;
            }

            // 获取当前时间
            var now = new Date();
            var printDate = now.getFullYear() + "年" +
                           (now.getMonth() + 1) + "月" +
                           now.getDate() + "日 " +
                           now.getHours() + ":" +
                           (now.getMinutes() < 10 ? "0" : "") + now.getMinutes();

            // 生成打印内容HTML
            var printHtmlArray = [
                '<div class="print-only">',
                '    <div class="print-header">',
                '        <h2>销售退货单</h2>',
                '        <p style="margin: 5px 0;">单号: ' + orderId + '</p>',
                '        <p style="margin: 5px 0;">打印时间: ' + printDate + '</p>',
                '        <p style="margin: 5px 0;">退货仓库: ' + warehouse + '</p>',
                '    </div>',
                '    ',
                '    <table class="print-table" style="width:100%; border-collapse: collapse; border: 1px solid black;">',
                '        <thead>',
                '            <tr>',
                '                <th style="border: 1px solid black; padding: 5px;">序号</th>',
                '                <th style="border: 1px solid black; padding: 5px;">商品名称</th>',
                '                <th style="border: 1px solid black; padding: 5px;">商品代码</th>',
                '                <th style="border: 1px solid black; padding: 5px;">商品类别</th>',
                '                <th style="border: 1px solid black; padding: 5px;">单位</th>',
                '                <th style="border: 1px solid black; padding: 5px;">数量</th>',
                '                <th style="border: 1px solid black; padding: 5px;">单价(元)</th>',
                '                <th style="border: 1px solid black; padding: 5px;">金额(元)</th>',
                '            </tr>',
                '        </thead>',
                '        <tbody>'
            ];

            // 添加商品行
            for (var j = 0; j < selectedItems.length; j++) {
                var item = selectedItems[j];
                printHtmlArray.push(
                    '<tr>',
                    '    <td style="border: 1px solid black; padding: 5px;">' + (j + 1) + '</td>',
                    '    <td style="border: 1px solid black; padding: 5px;">' + (item.name || '') + '</td>',
                    '    <td style="border: 1px solid black; padding: 5px;">' + (item.code || '') + '</td>',
                    '    <td style="border: 1px solid black; padding: 5px;">' + (item.category || '') + '</td>',
                    '    <td style="border: 1px solid black; padding: 5px;">' + (item.unit || '') + '</td>',
                    '    <td style="border: 1px solid black; padding: 5px;">' + (item.quantity || 0) + '</td>',
                    '    <td style="border: 1px solid black; padding: 5px;">' + (item.price || 0).toFixed(2) + '</td>',
                    '    <td style="border: 1px solid black; padding: 5px;">' + (item.amount || 0).toFixed(2) + '</td>',
                    '</tr>'
                );
            }

            // 添加总计行和页脚
            printHtmlArray.push(
                '        </tbody>',
                '        <tfoot>',
                '            <tr>',
                '                <td colspan="5" style="border: 1px solid black; padding: 5px; text-align: right; font-weight: bold;">总计:</td>',
                '                <td style="border: 1px solid black; padding: 5px; font-weight: bold;">' + totalQuantity.toFixed(2) + '</td>',
                '                <td colspan="2" style="border: 1px solid black; padding: 5px; font-weight: bold;">' + totalAmount.toFixed(2) + '</td>',
                '            </tr>',
                '        </tfoot>',
                '    </table>',
                '    ',
                '    <div class="print-footer">',
                '        <p>制单人: ' + creator + '</p>',
                '        <p>审核人: ' + auditor + '</p>',
                '        <p>收货人: ' + receiver + '</p>',
                '    </div>',
                '</div>'
            );

            var printHtml = printHtmlArray.join('');

            // 更新打印内容
            $("#print_content").html(printHtml);

            // 显示打印预览对话框
            $(".print_dialog").css("display", "block");
            $(".mask").css("display", "block");
        }

        // 修改打印样式，确保打印时只显示打印内容
        var originalPrint = window.print;
        window.print = function () {
            // 隐藏非打印内容
            $(".no-print").hide();
            $(".print-only").show();

            // 执行打印
            originalPrint();

            // 恢复显示
            setTimeout(function () {
                $(".no-print").show();
                $(".print_dialog").css("display", "none");
                $(".mask").css("display", "none");
            }, 100);
        };

        // 导出为Excel
        $("#export_excel").click(function () {
            exportToExcel();
        });

        function exportToExcel() {
            var selectedItems = [];

            // 收集选中的商品（与打印功能类似）
            for (var i = 1; i < row; i++) {
                var checkbox = $("#checkbox" + i);
                if (checkbox.length > 0 && checkbox.is(":checked")) {
                    var item = {
                        序号: i,
                        商品名称: $("#sp_name" + i).text(),
                        商品代码: $("#sp_dm" + i + " option:selected").text(),
                        商品类别: $("#sp_cplb" + i).text(),
                        单位: $("#sp_cpsj" + i).text(),
                        数量: $("#num" + i).val() || "0",
                        单价: $("#price" + i).val() || "0",
                        金额: (parseFloat($("#num" + i).val() || 0) * parseFloat($("#price" + i).val() || 0)).toFixed(2)
                    };
                    selectedItems.push(item);
                }
            }

            if (selectedItems.length === 0) {
                alert("请先选择要导出的商品");
                return;
            }

            // 创建CSV内容
            var csvContent = "data:text/csv;charset=utf-8,\uFEFF";

            // 添加标题行
            var headers = Object.keys(selectedItems[0]);
            csvContent += headers.join(",") + "\r\n";

            // 添加数据行
            selectedItems.forEach(function (item) {
                var row = headers.map(function (header) {
                    return item[header];
                }).join(",");
                csvContent += row + "\r\n";
            });

            // 创建下载链接
            var encodedUri = encodeURI(csvContent);
            var link = document.createElement("a");
            link.setAttribute("href", encodedUri);
            link.setAttribute("download", "退货单_" + new Date().toISOString().slice(0, 10) + ".csv");
            document.body.appendChild(link);

            link.click();
            document.body.removeChild(link);
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
                width: 25%;
    height: 45%;
    position: fixed;
    top: 10%;
    left: 30%;
    background-color: white;
    z-index: 20;
    box-shadow: 10px 10px 15px;
    border-radius: 2px;
            
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
            width: 200px;
            height: 30px;
            border-radius: 2px;
            margin-left: 37px;
        }
        .gonghuo_select {
            margin-left: 40px;
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
        
        /* 打印信息输入弹窗样式 */
        .print_info_dialog {
            display: none;
            width: 80%;
            max-width: 500px;
            height: auto;
            max-height: 80%;
            position: fixed;
            top: 10%;
            left: 10%;
            background-color: white;
            z-index: 1001;
            box-shadow: 0 0 20px rgba(0,0,0,0.3);
            border-radius: 5px;
            padding: 20px;
            overflow-y: auto;
        }

        .print_input, .print_select {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ddd;
            border-radius: 3px;
            box-sizing: border-box;
        }

        .print_input:focus, .print_select:focus {
            border-color: #009688;
            outline: none;
            box-shadow: 0 0 5px rgba(0,150,136,0.3);
        }

        /* 打印样式 */
        .no-print {
            display: none !important;
        }
    
        .print-only {
            display: block !important;
        }
    
        body {
            margin: 0;
            padding: 0;
            font-size: 12pt;
        }
    
        .print-table {
            width: 100%;
            border-collapse: collapse;
            margin: 0;
            padding: 0;
            page-break-inside: avoid;
        }
    
        .print-table th,
        .print-table td {
            border: 1px solid #000;
            padding: 5px;
            text-align: center;
            font-size: 10pt;
        }
    
        .print-header {
            text-align: center;
            margin-bottom: 20px;
        }
    
        .print-footer {
            margin-top: 20px;
            text-align: right;
            font-size: 10pt;
        }

        /* 隐藏打印预览弹窗中的操作按钮和整个主页面（仅打印时） */
@media print {
    /* 隐藏打印弹窗中的标题和按钮 */
    .print_dialog h2,
    .print_dialog > div:last-child,
    #print_cancel,
    #print_confirm {
        display: none !important;
    }
    
    /* 隐藏整个主页面内容（表单及其所有内容） */
    #form1,
    .d-header,
    .d-main,
    #biao_ge,
    .mask,
    .ruku_div,
    .print_info_dialog {
        display: none !important;
        visibility: hidden !important;
        height: 0 !important;
        width: 0 !important;
        overflow: hidden !important;
    }
    
    /* 打印弹窗全屏显示打印内容 */
    .print_dialog {
        display: block !important;
        position: fixed !important;
        top: 0 !important;
        left: 0 !important;
        width: 100% !important;
        height: 100% !important;
        background: white !important;
        z-index: 999999 !important;
        box-shadow: none !important;
        border-radius: 0 !important;
        padding: 0 !important;
        margin: 0 !important;
        border: none !important;
        overflow: visible !important;
    }
    
    /* 打印内容区域 */
    #print_content {
        width: 100% !important;
        height: auto !important;
        min-height: 100vh !important;
        padding: 20px !important;
        box-sizing: border-box !important;
        overflow: visible !important;
        margin: 0 !important;
    }
    
            /* 确保打印内容正常显示 */
            .print-only {
                display: block !important;
                visibility: visible !important;
                width: 100% !important;
                max-width: 100% !important;
                margin: 0 auto !important;
                padding: 20px !important;
                box-sizing: border-box !important;
            }
    
            .print-only * {
                visibility: visible !important;
            }
    
            /* 隐藏body上的所有其他元素 */
            body * {
                visibility: hidden !important;
            }
    
            .print_dialog,
            .print_dialog *,
            .print-only,
            .print-only * {
                visibility: visible !important;
            }
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
                <input id="ru_bt" class="rk_bt" type="button" value="退货入库"/>
                <input id="shuaxin" class="rk_bt" type="button" value="刷新"/>  
                <input id="insert" class="rk_bt" type="button" value="添加"/>
                <input id="print_btn" class="rk_bt" type="button" value="打印退货单"/>            
            </div> 
            <div class="d-main" id="table_div">

                <table id="biao_ge" name="bg_row" cellspacing="0" cellpadding="0">
                    <tr id="dj_yh">
                        <td class="auto-style1" style="width: 10%">销售退货</td>
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
        <div style="margin-bottom: 10px;">
            <label style="font-size: 14px; color: #333; margin-bottom: 5px; display: block;margin-left: 40px;">退货单号</label>
            <input class="order_id_input" placeholder="退货单号" value=""/>
        </div>
        <div style="margin-bottom: 10px;">
            <label style="font-size: 14px; color: #333; margin-bottom: 5px; display: block;margin-left: 40px;">退货仓库</label>
            <select class="gonghuo_select" onchange="getGongguo(this.value)"></select>
        </div>
        <div style="margin-bottom: 10px;">
            <label style="font-size: 14px; color: #333; margin-bottom: 5px; display: block;margin-left: 40px;">退货仓库</label>
            <select id="ruku_warehouse" style="margin-left: 40px;width: 200px;height: 30px;border: none;border: 1px solid #F0F0F0;">
            </select>
        </div>
        <div class="ruku_bottom_div">
            <input class="rk_bt" id="back_ruku" type="button" value="返回"/>
            <input class="rk_bt" id="insert_ruku" type="button" value="确认退货入库"/>
        </div>
    </div>

    <!-- 打印信息输入弹窗（已移除供应商字段） -->
    <div class="print_info_dialog" style="display:none; width: 50%; height: 60%; position: fixed; top: 10%; left: 25%; background-color: white; z-index: 22; box-shadow: 10px 10px 15px; border-radius: 2px; padding: 20px; overflow-y: auto;">
        <h2 style="text-align: center; margin-bottom: 20px;">填写打印信息</h2>
        <div id="print_info_content" style="background-color: white; padding: 20px;">
            <div style="margin-bottom: 15px;">
                <label style="display: block; margin-bottom: 5px; font-weight: bold;">单号:</label>
                <input type="text" id="print_order_id" class="print_input" placeholder="请输入退货单号" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 3px;" />
            </div>
    
            <div style="margin-bottom: 15px;">
                <label style="display: block; margin-bottom: 5px; font-weight: bold;">制单人:</label>
                <input type="text" id="print_creator" class="print_input" placeholder="请输入制单人姓名" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 3px;" value="系统用户" />
            </div>
    
            <div style="margin-bottom: 15px;">
                <label style="display: block; margin-bottom: 5px; font-weight: bold;">审核人:</label>
                <input type="text" id="print_auditor" class="print_input" placeholder="请输入审核人姓名" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 3px;" />
            </div>
    
            <div style="margin-bottom: 15px;">
                <label style="display: block; margin-bottom: 5px; font-weight: bold;">收货人:</label>
                <input type="text" id="print_receiver" class="print_input" placeholder="请输入收货人姓名" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 3px;" />
            </div>
    
            <div style="margin-bottom: 20px;">
                <label style="display: block; margin-bottom: 5px; font-weight: bold;">退货仓库:</label>
                <select id="print_warehouse" class="print_select" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 3px;">
                    <option value="">请选择退货仓库</option>
                    <!-- 仓库选项将通过JS动态加载 -->
                </select>
            </div>
    
            <div style="text-align: center; margin-top: 20px;">
                <input type="button" class="rk_bt" id="print_info_cancel" value="取消" style="margin-right: 20px;" />
                <input type="button" class="rk_bt" id="print_info_confirm" value="确认并预览" />
            </div>
        </div>
    </div>

    <!-- 打印对话框 -->
    <div class="print_dialog" style="display:none; width: 100%; height: 80%; position: fixed;background-color: white; z-index: 21; box-shadow: 10px 10px 15px; border-radius: 2px; padding: 20px; overflow-y: auto;">
        <h2 style="text-align: center; margin-bottom: 20px;">打印预览</h2>
        <div id="print_content" style="background-color: white; padding: 20px;">
            <!-- 打印内容将在这里动态生成 -->
        </div>
        <div style="margin-top: 20px; text-align: center;">
            <input type="button" class="rk_bt" id="print_cancel" value="取消" />
            <input type="button" class="rk_bt" id="print_confirm" value="打印" />
        </div>
    </div>
    <div class="mask" style="display:none"></div>
</body>
</html>