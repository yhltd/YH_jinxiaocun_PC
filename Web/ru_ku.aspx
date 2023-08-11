<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ru_ku.aspx.cs" Inherits="Web.ru_ku" %>

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
            $("#dj_row").click(function () {
                $("#row_i1").val($("#biao_ge tr").length);
            })
            $("#dj_yh").click(function () {
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

            ////打印
            //$("#btn_print").click(function () {
            //    if (ruku.itemList.length == 0) {
            //        alert("请选择商品")
            //    } else {
            //        $.ajax({
            //            type: "Post",
            //            url: "frm_ReportForm.aspx",
            //            data: {
            //                act: "print",
            //                infos: JSON.stringify(ruku)
            //            },
            //            dataType: "json",
            //            success: function (result) {
                            
            //            }
            //        });
            //    }
            //})

            $("#insert_ruku").click(function () {
                if ($('.order_id_input').val() == "") {
                    alert("请输入订单号");
                    return;
                }
                ruku.orderid = $('.order_id_input').val()
                $.ajax({
                    type: "Post",
                    url: "ru_ku.aspx",
                    data: {
                        act: "insert",
                        infos: JSON.stringify(ruku)
                    },
                    dataType: "json",
                    success: function (result) {
                        if (result > 0) {
                            alert("入库成功")
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
                url: "ru_ku.aspx",
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
                url: "ru_ku.aspx",
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
                    } else{
                        alert("基础配置中无此商品代码")
                        document.getElementById("qr_code_text").value = ""
                    }
                }
            }
        };

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
            height: 49px;
            text-align: center;
            background-color: #2F4056;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position:sticky;
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
        }
        .item_td {
            text-align: center;
            height: 40px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
        }
        .rk_bt {
            margin-left: 10px;
            width: 91px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
        }
        .table_input {
            border: none;
            height: 90%;
            width: 90%;
        }

        .input_tr {
            border: none;
            text-align: center;
            width: 90%;
            height: 90%;
        }

        .select_input {
            width: 300px;
            border: none;
            height: 64%;
            border: 1px solid #C2C2C2;
            border-radius: 3px;
        }
        .ruku_div {
            width: 50%;
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
            height: 60%;
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
                <input id="ru_bt" class="rk_bt" type="button" value="入库"/>
                <input id="shuaxin" class="rk_bt" type="button" value="刷新"/>               
                <asp:Button ID="btn_print" class="rk_bt" runat="server" Text="打印" OnClick="toExcel" UseSubmitBehavior="false"/>
                <input id='qr_code_text' class='select_input' autocomplete='off' placeholder='扫描商品二维码' style="margin-left:10px;width:150px" onkeypress="Enter(event)"/>
                <div id="last_code" style="margin-left:10px;"></div>
            </div> 
            <div class="d-main" id="table_div" style="width:100%;overflow:scroll;">

                <table id="biao_ge" name="bg_row" cellspacing="0" cellpadding="0">
                    <tr id="dj_yh">
                        <td class="auto-style1" style="width: 100px">入库</td>
                        <td class="auto-style1" style="width: 100px">序号</td>
                        <td class="auto-style1" style="width: 130px;">商品名称</td>
                        <td class="auto-style1" style="width: 130px;">商品代码</td>
                        <td class="auto-style1" style="width: 130px;">商品类别</td>
                        <td class="auto-style1" style="width: 130px;">商品单位</td>
                        <td class="auto-style1" style="width: 130px;">数量</td>
                        <td class="auto-style1" style="width: 130px;">单价</td>
                        <td class="auto-style1" style="width: 100px;">功能</td>
                      </tr>
                </table>
            </div>
            <%--<div class="d-footer" style="width: 300px;height: 70px;display: flex;justify-content: space-around;align-items: center;">
                <asp:Button CssClass="page_bt" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" />
                <asp:Button CssClass="page_bt" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" />
                <asp:Button CssClass="page_bt" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="page_bt" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
            </div>--%>
        </div>
    </form>
    <div class="ruku_div" style="display:none">
        <div class="ruku_info_div">
            <input class="order_id_input" placeholder="订单号" value=""/>
            <select class="gonghuo_select" onchange="getGongguo(this.value)"></select>
        </div>
        <div class="ruku_bottom_div">
            <input class="rk_bt" id="back_ruku" type="button" value="返回"/>
            <input class="rk_bt" id="insert_ruku" type="button" value="确认入库"/>
        </div>
    </div>
    <div class="mask" style="display:none"></div>
</body>
</html>