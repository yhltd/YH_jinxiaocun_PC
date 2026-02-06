<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="renyuanxinxi.aspx.cs" Inherits="Web.Personnel.renyuanxinxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <script src="../Myadmin/js/Jquery.js"></script>
    <script src="../Myadmin/js/qrcode.min.js"></script>
    <title></title>
</head>
<body style="    margin: 0;">
    <script>
        function a() {
            var a= document.getelementbyid("header") 
            a.style.width="7%"
        }

        function qr_make(name, password, gongsi,xitong) {
            console.log(name)
            console.log(password)
            console.log(gongsi)
            var url = window.top.location.href
            console.log(url)
            var str = name + "`" + password + "`" + gongsi + "`" + xitong
            $.ajax({
                type: "post", //要用post方式     
                url: "/Myadmin/HouTai/YongHuGuanli.aspx/EncryptAes",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                data: JSON.stringify({
                    source: str,
                }),
                success: function (data) {
                    console.log(data)
                    console.log(window.top.location.href)
                    var this_url = window.top.location.href.replace("/Myadmin/login.aspx#", "/Myadmin/login.aspx")
                    console.log(this_url)
                    this_url = this_url + "?user=" + data.d
                    console.log(this_url)
                    var qrcode_container = document.getElementById('qrcode');
                    // 生成二维码
                    var qrcode = new QRCode(qrcode_container, {
                        text: this_url, // 二维码中的内容
                        width: 200, // 二维码的宽度
                        height: 200, // 二维码的高度
                        colorDark: "#000000", // 二维码的颜色
                        colorLight: "#ffffff", // 二维码的背景色
                    });
                    var base64_qrcode = qrcode_container.firstChild.toDataURL("image/png");
                    console.log(base64_qrcode)
                    downloadFileByBase64(name + ".png", base64_qrcode.split(",")[1])
                },
                error: function (err) {
                    console.log(err)
                }
            });
        }

        function dataURLtoBlob(dataurl, name) {//name:文件名
            var mime = name.substring(name.lastIndexOf('.') + 1)//后缀名
            var bstr = atob(dataurl), n = bstr.length, u8arr = new Uint8Array(n);
            while (n--) {
                u8arr[n] = bstr.charCodeAt(n);
            }
            return new Blob([u8arr], { type: mime });
        }

        function downloadFile(url, name) {
            var a = document.createElement("a")//创建a标签触发点击下载
            a.setAttribute("href", url)//附上
            a.setAttribute("download", name);
            a.setAttribute("target", "_blank");
            var clickEvent = document.createEvent("MouseEvents");
            clickEvent.initEvent("click", true, true);
            a.dispatchEvent(clickEvent);
        }

        //主函数
        function downloadFileByBase64(name, base64) {
            var myBlob = dataURLtoBlob(base64, name);
            var myUrl = URL.createObjectURL(myBlob);
            downloadFile(myUrl, name)
        }

        //获取后缀
        function getType(file) {
            var filename = file;
            var index1 = filename.lastIndexOf(".");
            var index2 = filename.length;
            var type = filename.substring(index1 + 1, index2);
            return type;
        }

        //根据文件后缀 获取base64前缀不同
        function getBase64Type(type) {
            switch (type) {
                case 'data:text/plain;base64':
                    return 'txt';
                case 'data:application/msword;base64':
                    return 'doc';
                case 'data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64':
                    return 'docx';
                case 'data:application/vnd.ms-excel;base64':
                    return 'xls';
                case 'data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64':
                    return 'xlsx';
                case 'data:application/pdf;base64':
                    return 'pdf';
                case 'data:application/vnd.openxmlformats-officedocument.presentationml.presentation;base64':
                    return 'pptx';
                case 'data:application/vnd.ms-powerpoint;base64':
                    return 'ppt';
                case 'data:image/png;base64':
                    return 'png';
                case 'data:image/jpeg;base64':
                    return 'jpg';
                case 'data:image/gif;base64':
                    return 'gif';
                case 'data:image/svg+xml;base64':
                    return 'svg';
                case 'data:image/x-icon;base64':
                    return 'ico';
                case 'data:image/bmp;base64':
                    return 'bmp';
            }
        }

        function base64ToBlob(code) {
            code = code.replace(/[\n\r]/g, '');
            var raw = window.atob(code);
            var rawLength = raw.length;
            var uInt8Array = new Uint8Array(rawLength);
            for (var i = 0; i < rawLength; ++i) {
                uInt8Array[i] = raw.charCodeAt(i)
            }
            return new Blob([uInt8Array], { type: 'application/pdf' })
        }

    </script>
  <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Segoe UI', 'Microsoft YaHei', sans-serif;
        }
        
        body {
            background: linear-gradient(135deg, #f5f7fa 0%, #e4e8f0 100%);
            padding: 10px;
            min-height: 100vh;
            display: flex;
        }
       .ti {
            background: linear-gradient(135deg, rgba(22, 10, 141, 0.95) 0%, rgba(59, 77, 203, 0.95) 50%, rgba(90, 95, 221, 0.95) 100%);
            color: white;
            padding: 6px 30px;
            border-radius: 12px 12px 0 0;
            display: flex;
            justify-content: space-between;
            align-items: center;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            position: relative;
            overflow: hidden;
        }
        
        .ti h1 {
            margin: 0;
            font-size: 24px;
            font-weight: 700;
            text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.2);
            z-index: 2;
        }
        
        .ti::before {
            content: "";
            position: absolute;
            top: -50%;
            right: -50%;
            width: 80%;
            height: 200%;
            background: rgba(255, 255, 255, 0.1);
            transform: rotate(25deg);
            z-index: 1;
        }
        
        .ti-content {
            display: flex;
            align-items: center;
            z-index: 2;
        }
        
        .ti-stats {
            display: flex;
            gap: 25px;
            margin-right: 20px;
        }
        
        .stat-item {
            text-align: center;
            padding: 0 15px;
            border-right: 1px solid rgba(255, 255, 255, 0.3);
        }
        
        .stat-item:last-child {
            border-right: none;
        }
        
        .stat-value {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 5px;
        }
        
        .stat-label {
            font-size: 14px;
            opacity: 0.9;
        }
        
        /* 表单区域样式 */
        .header-top {
            background: white;
            padding: 20px 30px;
            border-radius: 0 0 12px 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            align-items: center;
            margin-bottom:10px;
        }
        
        .header-top label {
            font-weight: 600;
            color: #2E8B57;
            margin-right: 8px;
            min-width: 80px;
            display: inline-block;
        }
        
        .top_select_input {
            padding: 12px 15px;
            border: 1px solid #ddd;
            border-radius: 6px;
            font-size: 15px;
            width: 150px;
            transition: all 0.3s;
        }
        
        .top_select_input:focus {
            outline: none;
            border-color: #3CB371;
            box-shadow: 0 0 0 2px rgba(46, 139, 87, 0.2);
        }
        
        .top_bt {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
            min-width: 80px;
            height: 42px;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            line-height:8px;
        }
        
        .top_bt:hover {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(46, 139, 87, 0.3);
        }
        
        /* 响应式调整 */
        @media (max-width: 768px) {
            .ti {
                flex-direction: column;
                text-align: center;
                gap: 20px;
            }
            
            .ti-stats {
                margin-right: 0;
                justify-content: center;
            }
            
            .header-top {
                flex-direction: column;
                align-items: stretch;
            }
            
            .top_select_input {
                width: 100%;
            }
        }

        .personnel-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 15px;
        }
        
        table#ridView1 th[scope="col"],
        table th[scope="col"] {
            background: linear-gradient(to bottom, #4b77d0, #0521e8);
            color: white !important;
            padding: 15px !important;
            text-align: center !important;
            font-weight: 600 !important;
            border: none !important;
        }
        
        table#GridView1 tr.item:nth-child(even),
        table tr.item:nth-child(even) {
            background: linear-gradient(to bottom, #FFF9C4, #FFF8E1) !important;
        }

        /* 针对奇数行 */
        table#GridView1 tr.item:nth-child(odd),
        table tr.item:nth-child(odd) {
            background: linear-gradient(to bottom, #E0F2F1, #C8E6C9) !important;
        }

        /* 行悬停效果 */
        table#GridView1 tr.item:hover,
        table tr.item:hover {
            background: linear-gradient(to bottom, #E1F5FE, #B3E5FC) !important;
            color:black !important;
            cursor: pointer;
        }

        /* 确保单元格也有背景色 */
        table#GridView1 tr.item td,
        table tr.item td {
            border: 1px solid #ddd !important;
            padding: 10px !important;
        }

        /* 针对可能的内联样式 */
        tr[class*="item"] {
            background-image: none !important; /* 清除可能的内联背景 */
        }

        table {
            border-collapse: separate !important;
            border-spacing: 0 !important;
            width: 100%;
            border-radius: 8px !important;
            overflow: hidden !important;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15), 
                        0 2px 6px rgba(0, 0, 0, 0.1) !important;
            background: white !important;
            border: 1px solid #ddd !important;
        }

        /* 表头立体效果 */
        table th {
            background: linear-gradient(to bottom, #4b77d0, #0521e8);
            color: white !important;
            padding: 15px !important;
            text-align: center !important;
            font-weight: 600 !important;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.3) !important;
            border-bottom: 2px solid #1B5E20 !important;
            position: relative;
        }

        /* 表头底部阴影，增强立体感 */
        table th:after {
            content: '';
            position: absolute;
            bottom: 0;
            left: 0;
            width: 100%;
            height: 2px;
            background: linear-gradient(to right, 
                rgba(0,0,0,0.1) 0%, 
                rgba(0,0,0,0.2) 50%, 
                rgba(0,0,0,0.1) 100%) !important;
        }

        /* 单元格立体效果 */
        table td {
            padding: 12px 15px !important;
            border: 1px solid #e0e0e0 !important;
            position: relative;
        }

        /* 单元格内部阴影，增强立体感 */
        table td:before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.05) !important;
            pointer-events: none;
        }

        /* 斑马条纹效果 - 立体版本 */
        table tr:nth-child(even) td {
            background: linear-gradient(to bottom, #f9f9f9, #f0f0f0) !important;
        }

        table tr:nth-child(odd) td {
            background: linear-gradient(to bottom, #ffffff, #f7f7f7) !important;
        }

        /* 行悬停效果 - 立体版本 */
        table tr:hover td {
            background: linear-gradient(to bottom, #e8f5e9, #c8e6c9) !important;
            box-shadow: inset 0 0 10px rgba(46, 139, 87, 0.1) !important;
        }

        /* 表格底部阴影，增强整体立体感 */
        table:after {
            content: '';
            position: absolute;
            bottom: -5px;
            left: 5px;
            right: 5px;
            height: 5px;
            background: linear-gradient(to bottom, 
                rgba(0,0,0,0.1) 0%, 
                rgba(0,0,0,0.05) 50%, 
                transparent 100%) !important;
            border-radius: 0 0 8px 8px;
            z-index: -1;
        }

        /* 为表格容器添加额外阴影增强立体感 */
        .table-container {
            position: relative;
            margin: 20px 0;
        }

        .table-container:before {
            content: '';
            position: absolute;
            top: 5px;
            left: 10px;
            right: 10px;
            bottom: -5px;
            background: rgba(0,0,0,0.05);
            border-radius: 8px;
            z-index: -1;
        }
    </style>
    
    <div id="qrcode" style="display: none"></div>
    <form id="form1" runat="server"  style="margin: 0; width: 100%;">
    <div>
        <div class="ti">
            <h1>人员信息管理</h1>
        </div>
        <div class ="header-top">
        <asp:Label ID="Label1" runat="server" Height="30px" Text="姓名：" Width="80px" style="text-align:center"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="top_select_input" Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Height="30px" Text="手机号：" Width="80px" style="text-align:center;"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="top_select_input" Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="搜索" CssClass="top_bt" Height="30px" Width="80px"  style="margin-right:-10px"/>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" CssClass="top_bt" Height="30px" Width="80px" style="margin-right:-10px" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="所有" CssClass="top_bt" Height="30px" Width="80px" style="margin-right:-10px" />
        <asp:Button ID="Button4" runat="server" OnClick="toExcel" Text="生成Excel" CssClass="top_bt" Height="30px" Width="80px" style="margin-right:-10px" />
        <br />
         </div>
        <div class="for-top">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1"  OnRowDataBound="gvData_RowDataBound"  OnRowCommand="GridView_OnRowCommand" OnRowCreated="aaa" Width="100%"><%--AllowPaging="True"--%>
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="修改" CommandName="Btn_Operation" ItemStyle-CssClass="bt_upd1">
                        <ControlStyle Width="50px"  />
                    <HeaderStyle Wrap="False" />
                        <ItemStyle HorizontalAlign="Center" Wrap="False" ></ItemStyle>
                </asp:ButtonField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2" DeleteText="删除">
                    <ControlStyle Width="50px"/>
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>

                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" HeaderStyle-CssClass="personnel-th" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
<ControlStyle Width="80%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" HeaderStyle-CssClass="personnel-th" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
<ControlStyle Width="80%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="职务" SortExpression="D" HeaderStyle-CssClass="personnel-th" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
<ControlStyle Width="80%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="E" SortExpression="E"   />
                <asp:BoundField DataField="F" HeaderText="F" SortExpression="F"   />
                <asp:BoundField DataField="G" HeaderText="G" SortExpression="G"   />
                <asp:BoundField DataField="H" HeaderText="H" SortExpression="H"   />
                <asp:BoundField DataField="I" HeaderText="I" SortExpression="I"   />
                <asp:BoundField DataField="J" HeaderText="J" SortExpression="J"   />
                <asp:BoundField DataField="K" HeaderText="K" SortExpression="K"   />
                <asp:BoundField DataField="L" HeaderText="L" SortExpression="L"   />
                <asp:BoundField DataField="M" HeaderText="M" SortExpression="M"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="N" HeaderText="N" SortExpression="N"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="O" HeaderText="O" SortExpression="O"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="Q" HeaderText="Q" SortExpression="Q"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="R" HeaderText="R" SortExpression="R"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S"   />
                <asp:BoundField DataField="T" HeaderText="T" SortExpression="T"   />
                <asp:BoundField DataField="U" HeaderText="U" SortExpression="U"   />
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V"   />
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W"   />
                <asp:BoundField DataField="X" HeaderText="X" SortExpression="X"   />
                <asp:BoundField DataField="Y" HeaderText="Y" SortExpression="Y"   />
                <asp:BoundField DataField="Z" HeaderText="Z" SortExpression="Z"   />
                <asp:BoundField DataField="AA" HeaderText="AA" SortExpression="AA"   />
                <asp:BoundField DataField="AB" HeaderText="AB" SortExpression="AB"   />
                <asp:BoundField DataField="AC" HeaderText="AC" SortExpression="AC"   />
                <asp:BoundField DataField="AD" HeaderText="AD" SortExpression="AD"   />
                <%--</asp:BoundField>--%>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString19 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="if exists(SELECT * FROM [gongzi_renyuan] where ([L] like '%'+@L+'%') AND ([B] like '%'+@B+'%')  AND ([O] like '%'+@O+'%') ) begin SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%') AND ([B] like '%'+@B+'%') AND ([O] like '%'+@O+'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="L" SessionField="gongsi2" Type="String" />
                <asp:SessionParameter Name="B" SessionField="xm1" Type="String" />
                <asp:SessionParameter Name="O" SessionField="xm2" Type="String" />
                <%--<asp:Parameter Name="O">
                </asp:Parameter>--%>
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString18 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="if exists(SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%')) begin SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="L" SessionField="gongsi2" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString19 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="if exists(SELECT * FROM [gongzi_renyuan] where ([L] like '%'+@L+'%') AND ([B] like '%'+@B+'%')  ) begin SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%') AND ([B] like '%'+@B+'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="L" SessionField="gongsi2" Type="String" />
                <asp:SessionParameter Name="B" SessionField="xm1" Type="String" />
                <%--<asp:Parameter Name="O">
                </asp:Parameter>--%>
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString19 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="if exists(SELECT * FROM [gongzi_renyuan] where ([L] like '%'+@L+'%') AND ([O] like '%'+@O+'%') ) begin SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%') AND ([O] like '%'+@O+'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="L" SessionField="gongsi2" Type="String" />
                <asp:SessionParameter Name="O" SessionField="xm2" Type="String" />
                <%--<asp:Parameter Name="O">
                </asp:Parameter>--%>
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
