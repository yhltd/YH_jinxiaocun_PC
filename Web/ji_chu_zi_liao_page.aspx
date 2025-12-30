<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ji_chu_zi_liao_page.aspx.cs" Inherits="Web.ji_chu_zi_liao_page" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="Myadmin/js/qrcode.min.js"></script>
    <script src="Myadmin/js/JsBarcode.all.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
        
        var upd_id = "";

        function del_row(row) {
            var rowIndex = $("#del_row_cs1").context.rowIndex;
            $("#del_row" + row + "").remove();
        }

        function fileUp(id) {
            upd_id = id
            $('#file').trigger('click');
        }

        

        $(function () {
            $("#dj_row").click(function () {
                $("#row_i1").val($("#biao_ge tr").length);
            })

            $('#file').change(function () {
                var file = document.getElementById("file").files;
                var oFReader = new FileReader();
                var this_file = file[0];
                var fileName = file[0].name;
                var obj = [];
                if(this_file.size>1024 * 1024){
                    alert("文件超过1兆，请重新上传！")
                }else{
                    oFReader.readAsDataURL(this_file);
                    oFReader.onloadend = function (oFRevent) {
                        this_file = oFRevent.target.result;
                        this_file = this_file.split(",")[1]
                        console.log(this_file)
                        console.log(upd_id)


                        var fileInput = document.getElementById('file');
                        fileInput.value = ""
                        fileInput.outerHTML = fileInput.outerHTML;

                        $.ajax({
                            type: "post", //要用post方式                 
                            url: "/ji_chu_zi_liao_page.aspx/picture_upd",//方法所在页面和方法名
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            dataType: "json",
                            data: JSON.stringify({
                                id:upd_id,
                                base64:this_file
                            }),
                            success: function (data) {
                                alert(data.d);//返回的数据用data.d获取内容
                                window.location.reload();
                            },
                            error: function (err) {
                                alert(err);
                            }
                        });

                        //$ajax({
                        //    type: 'post',
                        //    url: '/ji_chu_zi_liao_page.aspx/picture_upd',
                        //    data: JSON.stringify({
                        //        id:upd_id,
                        //        base64:this_file
                        //    }),
                        //    dataType: 'json',
                        //    contentType: 'application/json;charset=utf-8',
                        //    async: false,
                        //    success: function (data) {
                        //        alert(data.d);//返回的数据用data.d获取内容
                        //        window.location.reload();
                        //    },
                        //})
                    };
                }
            });
        })

        //$(document).on("click", "#qr_print", function () {
        //    var oldstr = window.document.body.innerHTML;
        //    var newstr = '<table>'
            
        //    var elText = $("#biao_ge").children().eq(0).children().eq(0).prevObject;
        //    console.log(elText)
        //    for(var i=1; i<elText.length; i++){
        //        this_text1 = elText.eq(i).children().eq(1)[0].innerHTML
        //        this_text2 = elText.eq(i).children().eq(9)[0].innerHTML
        //        this_text2 = this_text2.replace("100","380")
        //        this_text = '<tr><td>' + this_text1 + '</td><td>' + this_text2 + '</td></tr>'
        //        newstr = newstr + this_text
        //        console.log(this_text)
        //    }
        //    newstr = newstr + "</table>"
        //    document.body.innerHTML = newstr;
        //    window.print();
        //    document.body.innerHTML = oldstr;
        //    window.location.reload();
        //})


        $(document).on("click", "#qr_print", function () {
            var oldstr = window.document.body.innerHTML;
            var elText = $("#biao_ge").children().eq(0).children().eq(0).prevObject;
            console.log(elText)
            var this_list = []
            for(var i=1; i<elText.length; i++){
                this_text1 = elText.eq(i).children().eq(1).children().eq(1).prevObject[0].defaultValue
                this_text2 = elText.eq(i).children().eq(2).children().eq(1).prevObject[0].defaultValue
                this_base64 = elText.eq(i).children().eq(9).children().eq(0).children().eq(1)[0].currentSrc
                console.log(this_text1)
                console.log(this_text2)
                console.log(this_base64)
                this_list.push({
                    this_text1: this_text1,
                    this_text2: this_text2, 
                    this_base64: this_base64,
                })
            }
            console.log(this_list)

            var newstr = '<canvas class="canvas" id="outCanvas" width="300" height="' + ((10 * 1) + this_list.length * 280) + '"></canvas>' + '<image id="Image" style="width:170px,height:170px" show="false"></image>'
            document.body.innerHTML = newstr;

            var image = document.querySelector('#Image')
            var canvas = document.querySelector('#outCanvas')
            var ctx = canvas.getContext('2d');

            ctx.font = "18px Arial";

            for(var i=0; i<this_list.length; i++){
                image.src = this_list[i].this_base64
                ctx.drawImage(image, 60,10 + i*280,170,170);
                ctx.fillText("商品代码：" + this_list[i].this_text1, 30, 200+i*280);
                ctx.fillText("商品名称：" + this_list[i].this_text2, 30, 230+i*280);
            }
            image.remove();
            window.print();
            document.body.innerHTML = oldstr;
            window.location.reload();
        })



        $(document).on("click", "#barcode_print", function () {
            var oldstr = window.document.body.innerHTML;
            var elText = $("#biao_ge").children().eq(0).children().eq(0).prevObject;
            console.log(elText)
            var this_list = []
            for(var i=1; i<elText.length; i++){
                this_text1 = elText.eq(i).children().eq(1).children().eq(1).prevObject[0].defaultValue
                this_text2 = elText.eq(i).children().eq(2).children().eq(1).prevObject[0].defaultValue
                var canvas = document.createElement("canvas");
                JsBarcode(canvas, this_text1, {format: "CODE128"});
                this_base64 = canvas.toDataURL("image/png");
                console.log(this_text1)
                console.log(this_text2)
                console.log(this_base64)
                this_list.push({
                    this_text1: this_text1,
                    this_text2: this_text2, 
                    this_base64: this_base64,
                })
            }
            console.log(this_list)

            var newstr = '<canvas class="canvas" id="outCanvas" width="300" height="' + ((10 * 1) + this_list.length * 280) + '"></canvas>' + '<image id="Image" style="width:170px,height:170px" show="false"></image>'
            document.body.innerHTML = newstr;

            var image = document.querySelector('#Image')
            var canvas = document.querySelector('#outCanvas')
            var ctx = canvas.getContext('2d');

            ctx.font = "18px Arial";

            for(var i=0; i<this_list.length; i++){
                image.src = this_list[i].this_base64
                ctx.drawImage(image, 60,10 + i*280,170,170);
                ctx.fillText("商品代码：" + this_list[i].this_text1, 30, 200+i*280);
                ctx.fillText("商品名称：" + this_list[i].this_text2, 30, 230+i*280);
            }
            image.remove();
            window.print();
            document.body.innerHTML = oldstr;
            window.location.reload();
        })

        $(document).ready(function () {
            
            var row = 1;
            var elText = $("#biao_ge").children().eq(0).children().eq(0).prevObject;
            for(var i=1; i<elText.length; i++){
                this_text = elText.eq(i).children().eq(1).children().eq(1).prevObject[0].defaultValue
                var this_id = 'qrcode' + (i-1)
                var qrcode = new QRCode(document.getElementById('' + this_id), {
                    width : 100,
                    height : 100
                });
                qrcode.makeCode(this_text);
                var barcode_id = "barcode" + (i-1)
                JsBarcode("#barcode" + (i-1), this_text, {
                    format: "CODE128",
                    displayValue: true,
                    height:50,
                    fontSize: 12,
                    width:1,
                    lineColor: "#000000"
                });
                var canvas = document.createElement("canvas");
                JsBarcode(canvas, this_text, {format: "CODE128"});
                this_base64 = canvas.toDataURL("image/png");
                console.log(this_base64)
                var canvas_barcode = document.getElementById("barcode" + (i-1))
                var this_html = '<img src="' + this_base64 + '" style="display: block;">'
                canvas_barcode.innerHTML = this_html
            }
            $("#insert").click(function () {
                
                var rowLength = $("#biao_ge tr").length;

                //var insertStr = "<tr id='del_row" + row + "' >"
                //               + "<td style='font-size: 14px;padding-left: 0.5%;width: 70px;'>" + rowLength + "</td>"
                //               + "<td ><input type='text' class='input_tr' style='width: 120px;margin:0.2%;' name='sp_dm" + row + "' ></input></td>"
                //               + "<td class='bg_bj_dm'><input type='text' style='width: 150px;margin:0.2%;' class='input_tr' name='name" + row + "' ></input></td>"
                //               + "<td class='bg_bj_lb'><input type='text' style='width: 150px;margin:0.2%;' class='input_tr' name='lei_bie" + row + "' ></input></td>"
                //               + "<td class='bg_bj_sj'><input type='text' style='width: 150px;margin:0.2%;' class='input_tr' name='dan_wei" + row + "' ></input></td>"
                //               + "<td class='bg_bj_sj'><input type='text' style='width: 150px;margin:0.2%;' class='input_tr' name='shou_huo" + row + "' ></input></td>"
                //               + "<td class='bg_bj_sj'><input type='text' style='width: 60px;margin:0.2%;' class='input_tr' name='gong_huo" + row + "' ></input></td>"
                //               + "<td style='border-right: 1px dashed #a8a8a8;'><input type='button' style='width: 50px;margin:0.2%;' class='rk_btu'value='删除' style='margin-left: 3px;'  onclick='del_row(" + row + ")'/></td>"
                //               + "</tr>";
                var insertStr = "<tr id='del_row" + row + "' >"
                               + "<td>" + rowLength + "</td>"
                               + "<td ><input type='text' class='input_tr' name='sp_dm" + row + "' ></input></td>"
                               + "<td class='bg_bj_dm'><input type='text'  class='input_tr' name='name" + row + "' ></input></td>"
                               + "<td class='bg_bj_lb'><input type='text'  class='input_tr' name='lei_bie" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text'  class='input_tr' name='dan_wei" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text'  class='input_tr' name='shou_huo" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text'  class='input_tr' name='gong_huo" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'></td>"
                               + "<td class='bg_bj_sj'></td>"
                               + "<td class='bg_bj_sj'></td>"
                               + "<td class='bg_bj_sj'></td>"
                               + "<td style='border-right: 1px dashed #a8a8a8;'><input type='button'  style='width:50px' value='删除' style='margin-left: 3px;'  onclick='del_row(" + row + ")'/></td>"
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

        td {
            text-align: center;
            height: 40px;
            background-color: white;
            font-size: 16px;
        }

        .auto-style1 {
           height: 49px;
            text-align: center;
            background-color: #143268;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position: sticky;
            top: 0;
        }

        .input_tr_tj {
            width: 91px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
            margin-left: 10px;
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

          /* 奇数行样式 */
        tr:nth-child(odd) .bg_bj {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .bg_bj {
            background-color: #e0f7fa;  /* 更浅的蓝色 */
        }

       
        #checkbox
        {
            zoom: 1.5;
        }
        .select_input {
            width: 300px;
            border: none;
            height: 64%;
            border-radius: 3px;
            /*margin-top:20px;*/
        }

        .d-main {
            overflow:auto;
            margin-left:1%;
            margin-top:30px;
            box-sizing: border-box;
            padding-left:5px;
            padding-right:5px;
            width:97%;
            height:80%;
            border:3px solid #D3D3D3;
             box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
            
        }
        .top-div {
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
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="hidden" id="xx_hidden" value="tj_false" />
            <div class="top-div">
                <asp:TextBox ID='jichu_cx' class='select_input' Autocomplete='off'  runat="server" placeholder="按商品名称查询"/>
                <asp:Button  ID="jichu_query" OnClick="jczl_chaxun" class="input_tr_tj" Text="查询" runat="server" />
                <input type="button" id="insert" class="input_tr_tj" value="添加">
                <asp:Button OnClick="jczl_tj" ID="dj_row" class="input_tr_tj" Text="提交" runat="server" />
                <asp:Button OnClick="del_qichu" ID="del_qc_btu" class="input_tr_tj" Text="删除" runat="server" />
                <asp:Button ID="Button2" class="input_tr_tj" OnClick="jczl_select_load" Text="刷新数据" runat="server" />
                <input type="button" id="qr_print" class="input_tr_tj" value="打印二维码">
                <input type="button" id="barcode_print" class="input_tr_tj" value="打印条形码">
                <input type="file" id="file" hidden="hidden">
            </div>
            <div class="d-main">
            <input type="hidden" id="tj_pd_id" name="tj_pd" />
            <input type="hidden" id="row_i1" name="row_i" />
            <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="">
                <tr id="dj_yh">
                    <th class="auto-style1" style="width: 70px">序号</th>
                    <th class="auto-style1" style="width: 130px">商品代码</th>
                    <th class="auto-style1" style="width: 155px">商品名称</th>
                    <th class="auto-style1" style="width: 155px">商品类别</th>
                    <th class="auto-style1" style="width: 155px">商品单位</th>
                    <th class="auto-style1" style="width: 155px">客户名称</th>
                    <th class="auto-style1" style="width: 155px">供应名称</th>
                    <th class="auto-style1" style="width: 155px">图片</th>
                    <th class="auto-style1" style="width: 145px">上传图片</th>
                    <th class="auto-style1" style="width: 105px">二维码</th>
                    <th class="auto-style1" style="width: 200px">条形码</th>
                    <th class="auto-style1" style="width: 90px">功能</th>
                </tr>
                <%
                    System.Collections.Generic.List<Web.Server.yh_jinxiaocun_jichuziliao> jczj_select = Session["jczj_select"] as System.Collections.Generic.List<Web.Server.yh_jinxiaocun_jichuziliao>;
                    if (jczj_select != null)
                    {
                        for (int i = 0; i < jczj_select.Count; i++)
                        {
                            if(jczj_select[i].mark1!=null && jczj_select[i].mark1!="" ){
                                jczj_select[i].mark1="data:image/jpg;base64,"+jczj_select[i].mark1;
                            }                          
                %>
                <tr id="del_row_cs<%=i%>">
                    <%--style="font-size: 90%; padding-left: 2%;"--%>
                    <td class="bg_bj"><%=(i+1) %></td>
                    <td >
                        <input type="text" class="input_tr" id="sp_name" name="sp_dm_cs<%=i%>" value="<%=jczj_select[i].sp_dm%>" /></td>
                    <td class="bg_bj">
                        <input type="text" class="input_tr" id="Text1" name="name_cs<%=i%>" value="<%=jczj_select[i].name%>" /></td>
                    <td class="bg_bj">
                        <input type="text" class="input_tr" id="Text2" name="lei_bie_cs<%=i%>" value="<%=jczj_select[i].lei_bie%>" /></td>
                    <td class="bg_bj">
                        <input type="text" class="input_tr" id="ck_dj<%=i%>" name="dan_wei_cs<%=i%>" value="<%=jczj_select[i].dan_wei%>" /></td>
                    <td class="bg_bj">
                        <input type="text" class="input_tr" id="Text5" name="shou_huo_cs<%=i%>" value="<%=jczj_select[i].shou_huo%>" /></td>
                    <td class="bg_bj">
                        <input type="text" class="input_tr" id="Text4" name="gong_huo_cs<%=i%>" value="<%=jczj_select[i].gong_huo%>" /></td>
                    <td class="bg_bj">
                        <img style="width: 60px;"  src="<%=jczj_select[i].mark1%>"/></td>
                    <td class="bg_bj">
<%--                        <asp:FileUpload  name="tupian<%=i%>" runat="server" accept="image/*" style="color: transparent;width:70px" />--%>
                        <input type="button" name="tupian<%=i%>" value="上传图片" onclick="fileUp(<%=jczj_select[i].id%>);" class="input_tr_tj"  id="Text6" accept="image/*" /></td>
                    <td class="bg_bj">
                        <div id="qrcode<%=i%>" style="width:60px;" name="<%=jczj_select[i].sp_dm%>"></div></td>
                    <td class="bg_bj">
                        <canvas id="barcode<%=i%>"  name="<%=jczj_select[i].sp_dm%>"></canvas></td>
                    <td class="bg_bj">
                        <input type="hidden" class="input_tr" id="Text3" name="id_cs<%=i%>" value="<%=jczj_select[i].id%>" /><input id="checkbox" name="Checkbox_bd<%=i%>" value=" <%=i%>" type="checkbox" /></td>
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
