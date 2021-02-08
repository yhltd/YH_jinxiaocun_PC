<%@ Page Language='C#' AutoEventWireup='true' CodeBehind='chu_ku.aspx.cs' Inherits='Web.chu_ku' %>

<%@ Import Namespace='SDZdb' %>

<!DOCTYPE html>

<html xmlns='http://www.w3.org/1999/xhtml'>
<head id='Head1' runat='server'>
    <script src='/Myadmin/js/jquery-1.8.3.min.js' type='text/javascript'></script>
    <script src='/Myadmin/js/json2.js' type='text/javascript'></script>
    <link href='Myadmin/css/common.css' rel='stylesheet' type='text/css' />
    <script>
        var row = 1;
        var list = [];
        var ruku = {
            gonghuo: '',
            orderid: '',
            itemList: []
        }
        $(function () {
            var windowHeight = window.innerHeight;
            $('#table_div').css('height', windowHeight * 0.8)
            getList();
            getGongHuoList();
            $('#dj_row').click(function () {
                $('#row_i1').val($('#biao_ge tr').length);
            })
            $('#dj_yh').click(function () {
                var newTr = '';
                newTr += "<tr id='del_row" + row + "'>"
                newTr += "<td class='item_td'><input type='checkbox' class='checkBox_list' onclick='choice_ruku(this.value," + row + ")' id='checkbox" + row + "' value='0'></checkbox></td>"
                newTr += "<td class='item_td'>" + row + "</td>"
                newTr += "<td class='item_td' id='sp_name" + row + "></td>"
                newTr += "<td class='item_td'>"
                newTr += "<select class='input_tr' id='sp_dm" + row + "' name='sp_dm" + row + "' onchange='bhhq(" + row + "')'>"
                newTr += "<option value='选择编号'>选择编号</option>"
                for (var i = 0; i < list.length; i++) {
                    newTr += "<option class='option_list' value='" + i + "'>" + list[i].sp_dm + "</option>"
                }
                newTr += '</select></td>'
                newTr += "<td class='item_td' id='sp_cplb" + row + "'></td>"
                newTr += "<td class='item_td' id='sp_cpsj" + row + "'></td>"
                newTr += "<td class='item_td' id='sp_cpsl" + row + "'><input id='num" + row + "' type='number' autocomplete='off' class='table_input' placeholder='总数量：'/></td>"
                newTr += "<td class='item_td' id='sp_cpprice' + row + ''><input id='price" + row + "' type='number' autocomplete='off' class='table_input'/></td>"
                newTr += "<td class='item_td'><input type='button' class='rk_btu' value='删除' onclick='del_row(" + row + ")'/></td>"
                newTr += '</tr>'
                $('#biao_ge').append(newTr);
                row++;
            });

            $('#ru_bt').click(function () {
                if (ruku.itemList.length == 0) {
                    alert('请选择商品')
                } else {
                    $('.ruku_div').css('display', 'block')
                    $('.mask').css('display', 'block')
                }
            })



            $('#getRandom').click(function () {
                var rand = Math.floor(Math.random() * (9999999 - 99999)) + 99999;
                var is = true;
                do {
                    $.ajax({
                        type: 'Post',
                        url: 'chu_ku.aspx',
                        data: {
                            act: 'checkOrder',
                            order_id: 'CK' + rand
                        },
                        async: false,
                        dataType: 'json',
                        success: function (result) {
                            if (result == -1) {
                                ruku.orderid = 'CK' + rand
                                $('.order_id_input').val('CK' + rand)
                                is = false;
                            }
                        }
                    });
                } while (is)
            })
            $('#back_ruku').click(function () {
                $('.ruku_div').css('display', 'none')
                $('.mask').css('display', 'none')
            })

            $('#insert_ruku').click(function () {
                if ($('.order_id_input').val() == '') {
                    alert('请生成订单号');
                    return;
                }
                $.ajax({
                    type: 'Post',
                    url: 'chu_ku.aspx',
                    data: {
                        act: 'insert',
                        infos: JSON.stringify(ruku)
                    },
                    dataType: 'json',
                    success: function (result) {
                        if (result > 0) {
                            alert('出库成功')
                            $('.ruku_div').css('display', 'none')
                            $('.mask').css('display', 'none')
                            $('#shuaxin').click();
                        }
                    }
                });
            })

            $('#shuaxin').click(function () {
                for (var i = 1; i <= row; i++) {
                    del_row(i)
                }
                row = 1;
                getList();
            })
        })

        function check(e, index) {
            if (e == 0) {
                alert('请选择编号')
                return false
            }
            if ($('#num' + index).text() == '' && $('#num' + index).val() == '' || $('#num' + index).val() <= 0) {
                alert('请输入数量')

                return false
            }
            if ($('#price' + index).text() == '' && $('#price' + index).val() == '' || $('#price' + index).val() <= 0) {
                alert('请输入单价')
                return false
            }
            return true
        }

        function choice_ruku(e, index) {
            if (check(e, index)) {
                if ($('#checkbox' + index).is(':checked')) {
                    var item = { id: e, num: $('#num' + index).val(), price: $('#price' + index).val() };
                    ruku.itemList.push(item)
                    console.log(ruku.itemList)
                } else {
                    for (var i = 0; i < ruku.itemList.length; i++) {
                        if (ruku.itemList[i].id == $('#checkbox' + index).val()) {
                            ruku.itemList.splice(i, 1)
                            break;
                        }
                    }
                    console.log(ruku.itemList)
                }

            } else {
                $('#checkbox' + index).prop('checked', false);
            }
        }

        function del_row(row) {
            $('#del_row' + row + '').remove();
        }

        function setList(result) {
            var insertStr = '';
            for (var j = 0; j < result.length; j++) {
                insertStr += "<tr id='del_row" + row + "'>"
                insertStr += "<td class='item_td'><input type='checkbox' class='checkBox_list' onclick='choice_ruku(this.value," + row + ")' id='checkbox" + row + "' value='" + result[j].id + "'></checkbox></td>"
                insertStr += "<td class='item_td'>" + row + "</td>"
                insertStr += "<td class='item_td' id='sp_name" + row + "'>" + result[j].name + "</td>"
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
                insertStr += "<td class='item_td' id='sp_cplb" + row + "'>" + result[j].lei_bie + "</td>"
                insertStr += "<td class='item_td' id='sp_cpsj" + row + "'>" + result[j].dan_wei + "</td>"
                insertStr += "<td class='item_td' id='sp_cpsl" + row + "'><input id='num" + row + "' type='number' autocomplete='off' class='table_input' oninput='bindInput_num(this.value," + result[j].id + ")' placeholder='总数量：" + result[j].maxNum + "'/></td>"
                insertStr += "<td class='item_td' id='sp_cpprice" + row + "'><input id='price" + row + "' type='number' autocomplete='off' oninput='bindInput_price(this.value," + result[j].id + ")' class='table_input' /></td>"
                insertStr += "<td class='item_td'><input type='button' class='rk_btu' value='删除' onclick='del_row(" + row + ")'/></td>"
                insertStr += "</tr>"
                row++;
            }
            $('#biao_ge').append(insertStr);
        }

        function getList() {
            var insertStr = '';
            $.ajax({
                type: 'Post',
                url: 'chu_ku.aspx',
                data: {
                    act: 'newSp'
                },
                dataType: 'json',
                success: function (result) {
                    list = result;
                    setList(result);
                }
            });
        }

        function getGongHuoList() {
            $.ajax({
                type: 'Post',
                url: 'chu_ku.aspx',
                data: {
                    act: 'shouhuoList'
                },
                dataType: 'json',
                success: function (result) {
                    var gonghuo = ''
                    for (var i = 0; i < result.length; i++) {
                        gonghuo += '<option class="option_list" value="' + result[i] + '">' + result[i] + '</option>'
                    }
                    $('.gonghuo_select').append(gonghuo);
                    ruku.gonghuo = result[0]
                }
            });
        }

        function bindInput_num(e, id, index) {
            for (var j = 0; j < list.length; j++) {
                if (id == list[j].id) {
                    if (parseInt(e) > list[j].maxNum) {
                        alert('出库数量不能大于总数量')
                        $('#num' + (j+1)).val('')
                        return false
                    }
                }
            }
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
            for (var i = 1; i < row; i++) {
                var name = $('#sp_name' + i).text();
                var dm = list[$('#sp_dm' + i).val()].sp_dm;
                if (name.indexOf(e) == -1 && dm.indexOf(e) == -1) {
                    $('#del_row' + i).css('display', 'none');
                } else {
                    $('#del_row' + i).removeAttr('style');
                }
            }
        }
        function bhhq(row) {
            var i = $("#sp_dm" + row).val();
            var rows = list[i];
            $("#checkbox" + row).val(rows.id);
            $("#sp_name" + row).text(rows.name);
            $("#sp_cplb" + row).text(rows.lei_bie);
            $("#sp_cpsj" + row).text(rows.dan_wei);
            $("#num" + row).attr("placeholder", "总数量：" + rows.maxNum)
        }

        function getGongguo(e) {
            ruku.gonghuo = e
        }

    </script>
    <style type='text/css'>
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
            width: 100%;
            border: none;
            height: 64%;
            border: 1px solid #F0F0F0;
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

    <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
    <title></title>
</head>
<body>
    <form id='form1' runat='server'>
        <div>
            <input type='hidden' id='tj_pd_id' name='tj_pd' />
            <input type='hidden' id='row_i1' name='row_i' />
            <input type='hidden' id='xx_hidden' value='tj_false' />
            <div class='new_ss_div'>
                <input id='ru_cx' class='select_input' autocomplete='off' oninput='bindInput_select(this.value)' placeholder='按商品名称/商品代码搜索' />
                <input id='ru_bt' class='rk_bt' type='button' value='出库'/> 
                <input id='shuaxin' class='rk_bt' type='button' value='刷新'/> 
            </div> 
            <div id='table_div' style='width:100%;height:420px;overflow:scroll;' >
                <table id='biao_ge' name='bg_row' cellspacing='0' cellpadding='0'>
                    <tr id='dj_yh'>
                        <td class='auto-style1' style='width: 100px'>出库</td>
                        <td class='auto-style1' style='width: 100px'>序号</td>
                        <td class='auto-style1' style='width: 130px;'>商品名称</td>
                        <td class='auto-style1' style='width: 130px;'>商品代码</td>
                        <td class='auto-style1' style='width: 130px;'>商品类别</td>
                        <td class='auto-style1' style='width: 130px;'>商品单位</td>
                        <td class='auto-style1' style='width: 130px;'>数量</td>
                        <td class='auto-style1' style='width: 130px;'>单价</td>
                        <td class='auto-style1' style='width: 100px;'>功能</td>
                      </tr>
                </table>
            </div>
            <div style='width: 300px;height: 70px;display: flex;justify-content: space-around;align-items: center;'>
                <asp:Button CssClass='page_bt' ID='shou_ye' OnClick='shou_ye_Click' Text='首页' runat='server' />
                <asp:Button CssClass='page_bt' ID='shang_ye' OnClick='shang_ye_Click' Text='上一页' runat='server' />
                <asp:Button CssClass='page_bt' ID='xia_ye' OnClick='xia_ye_Click' Text='下一页' runat='server' />
                <asp:Button CssClass='page_bt' ID='mo_ye' OnClick='mo_ye_Click' Text='末页' runat='server' />
            </div>
        </div>
    </form>
    <div class='ruku_div' style='display:none'>
        <div class='ruku_info_div'>
            <input class='order_id_input' placeholder="请输入订单号" value=""/>
            <select class='gonghuo_select' onchange='getGongguo(this.value)'></select>
        </div>
        <div class='ruku_bottom_div'>
            <input class='rk_bt' id='back_ruku' type='button' value='返回'/>
            <input class='rk_bt' id='insert_ruku' type='button' value='确认出库'/>
        </div>
    </div>
    <div class='mask' style='display:none'></div>
</body>
</html>
