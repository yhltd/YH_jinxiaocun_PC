<%@ page language="C#" autoeventwireup="true" codebehind="lizhishenpi.aspx.cs" inherits="Web.Personnel.lizhishenpi" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>离职审批管理</title>
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
        
        .header-top {
            background: white;
            padding: 20px 30px;
            border-radius: 0 0 12px 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            align-items: center;
            margin-bottom: 20px;
        }
        
        .top_bt {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            padding: 8px 16px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            font-size: 14px;
        }
        
        .top_bt:hover {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(46, 139, 87, 0.3);
        }
        
        /* 表格样式 */
        table {
            border-collapse: separate !important;
            border-spacing: 0 !important;
            width: 100%;
            border-radius: 8px !important;
            overflow: hidden !important;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15) !important;
            background: white !important;
            border: 1px solid #ddd !important;
        }
        
        table th {
            background: linear-gradient(to bottom, #4b77d0, #0521e8);
            color: white !important;
            padding: 15px !important;
            text-align: center !important;
            font-weight: 600 !important;
            border: none !important;
        }
        
        table td {
            padding: 12px 15px !important;
            border: 1px solid #e0e0e0 !important;
            text-align: center !important;
        }
        
        /* 斑马条纹效果 */
        table tr:nth-child(even) td {
            background: linear-gradient(to bottom, #f9f9f9, #f0f0f0) !important;
        }
        
        table tr:nth-child(odd) td {
            background: linear-gradient(to bottom, #ffffff, #f7f7f7) !important;
        }
        
        table tr:hover td {
            background: linear-gradient(to bottom, #e8f5e9, #c8e6c9) !important;
        }
        
        /* 按钮样式 */
        .btn-edit {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 3px;
            cursor: pointer;
            font-size: 12px;
            margin: 2px;
        }
        
        .btn-delete {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 3px;
            cursor: pointer;
            font-size: 12px;
            margin: 2px;
        }
        
        /* 状态样式 */
        .status-tongguo {
            color: white;
            background: #4CAF50;
            padding: 3px 8px;
            border-radius: 3px;
            font-weight: bold;
        }
        
        .status-bohui {
            color: white;
            background: #f44336;
            padding: 3px 8px;
            border-radius: 3px;
            font-weight: bold;
        }
        
        .status-daishanpi {
            color: white;
            background: #2196F3;
            padding: 3px 8px;
            border-radius: 3px;
            font-weight: bold;
        }
        
        .status-default {
            color: #333;
            background: #f5f5f5;
            padding: 3px 8px;
            border-radius: 3px;
            cursor: pointer;
        }
        
        /* 模态框样式 */
        .modal {
            display: none;
            position: fixed;
            z-index: 1000;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0,0,0,0.5);
        }
        
        .modal-content {
            background-color: white;
            margin: 5% auto;
            padding: 20px;
            border-radius: 8px;
            width: 80%;
            max-width: 500px;
            max-height: 80vh;
            overflow-y: auto;
        }
        
        .modal-header {
            font-size: 20px;
            font-weight: bold;
            margin-bottom: 20px;
            text-align: center;
        }
        
        .modal-body {
            margin-bottom: 20px;
        }
        
        .modal-footer {
            display: flex;
            justify-content: flex-end;
            gap: 10px;
        }
        
        .form-group {
            margin-bottom: 15px;
        }
        
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: 600;
        }
        
        .form-group input,
        .form-group select,
        .form-group textarea {
            width: 100%;
            padding: 8px 12px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 14px;
        }
        
        .form-group textarea {
            min-height: 80px;
            resize: vertical;
        }
        
        /* 分页样式 */
        .pagination {
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 20px 0;
            gap: 10px;
        }
        
        .pagination a {
            padding: 5px 12px;
            border: 1px solid #ddd;
            border-radius: 4px;
            text-decoration: none;
            color: #333;
            transition: all 0.3s;
        }
        
        .pagination a:hover {
            background: #f5f5f5;
        }
        
        .pagination .current {
            background: #5677fc;
            color: white;
            border-color: #5677fc;
        }
        
        /* 查询条件区域 */
        .search-box {
            display: flex;
            align-items: center;
            gap: 15px;
            flex-wrap: wrap;
        }
        
        .search-item {
            display: flex;
            align-items: center;
            gap: 5px;
        }
        
        .search-item label {
            font-size: 14px;
            white-space: nowrap;
        }
        
        .search-item input,
        .search-item select {
            padding: 5px 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            width: 120px;
        }
    </style>
    <script src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        // 显示添加弹窗
        function showAddModal() {
            // 清空表单字段
            $('#addBumenModal').val('');
            $('#addXingmingModal').val('');
            $('#addShenqingyuanyinModal').val('');
            
            // 设置当天日期
            var today = new Date();
            var formattedDate = today.getFullYear() + '-' + 
                               String(today.getMonth() + 1).padStart(2, '0') + '-' + 
                               String(today.getDate()).padStart(2, '0');
            $('#addTijiaoriqiModal').val(formattedDate);
            
            $('#addShenpiyuanyinModal').val('');
            $('#addShenpijieguoModal').val(''); // 默认为空
            
            // 显示模态框
            $('#addModal').show();
        }

        // 保存添加的记录
        function saveAdd() {
            // 获取表单值
            var bumen = $('#addBumenModal').val();
            var xingming = $('#addXingmingModal').val();
            var tijiaoriqi = $('#addTijiaoriqiModal').val();
            var shenqingyuanyin = $('#addShenqingyuanyinModal').val();
            var shenpiyuanyin = $('#addShenpiyuanyinModal').val();
            var shenpijieguo = $('#addShenpijieguoModal').val();

            // 验证必填字段
            if (!bumen) {
                alert('部门不能为空！');
                return;
            }
            if (!xingming) {
                alert('姓名不能为空！');
                return;
            }

            // 创建FormData对象
            var formData = new FormData();
            formData.append('action', 'add');
            formData.append('addBumen', bumen);
            formData.append('addXingming', xingming);
            formData.append('addTijiaoriqi', tijiaoriqi);
            formData.append('addShenqingyuanyin', shenqingyuanyin);
            formData.append('addShenpiyuanyin', shenpiyuanyin);
            formData.append('addShenpijieguo', shenpijieguo);

            // 使用AJAX提交
            $.ajax({
                url: 'lizhishenpi.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    alert('添加成功！');
                    // 关闭模态框
                    hideAddModal();
                    // 刷新页面
                    location.reload();
                },
                error: function (xhr, status, error) {
                    alert('添加失败');
                }
            });
        }

        // 关闭添加弹窗
        function hideAddModal() {
            $('#addModal').hide();
        }

        // 显示编辑弹窗
        function showEditModal(id, bumen, xingming, tijiaoriqi, shenqingyuanyin, shenpiyuanyin, shenpijieguo) {
            // 防止事件冒泡
            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }
    
            console.log('编辑数据:', {id, bumen, xingming, tijiaoriqi, shenqingyuanyin, shenpiyuanyin, shenpijieguo});
    
            // 填充表单字段
            $('#editRecordIdModal').val(id);
            $('#editBumenModal').val(bumen || '');
            $('#editXingmingModal').val(xingming || '');
            
            if (tijiaoriqi) {
                // 如果数据库中是完整的日期时间格式，截取日期部分
                var datePart = tijiaoriqi.split(' ')[0]; // 分离日期和时间部分
                $('#editTijiaoriqiModal').val(datePart);
            } else {
                // 如果没有日期，设置当天日期
                var today = new Date();
                var formattedDate = today.getFullYear() + '-' + 
                                   String(today.getMonth() + 1).padStart(2, '0') + '-' + 
                                   String(today.getDate()).padStart(2, '0');
                $('#editTijiaoriqiModal').val(formattedDate);
            }
            
            $('#editShenqingyuanyinModal').val(shenqingyuanyin || '');
            $('#editShenpiyuanyinModal').val(shenpiyuanyin || '');
            
            // 设置状态选择
            if (shenpijieguo) {
                $('#editShenpijieguoModal').val(shenpijieguo);
            }

            // 显示模态框
            $('#editAllModal').show();
        }

        // 保存所有字段的编辑
        function saveAllEdit() {
            // 获取表单值
            var id = $('#editRecordIdModal').val();
            var bumen = $('#editBumenModal').val();
            var xingming = $('#editXingmingModal').val();
            var tijiaoriqi = $('#editTijiaoriqiModal').val();
            var shenqingyuanyin = $('#editShenqingyuanyinModal').val();
            var shenpiyuanyin = $('#editShenpiyuanyinModal').val();
            var shenpijieguo = $('#editShenpijieguoModal').val();

            if (!id) {
                alert('记录ID不能为空！');
                return;
            }

            // 验证必填字段
            if (!bumen) {
                alert('部门不能为空！');
                return;
            }
            if (!xingming) {
                alert('姓名不能为空！');
                return;
            }

            // 创建FormData对象
            var formData = new FormData();
            formData.append('action', 'edital');
            formData.append('editRecordId', id);
            formData.append('editBumen', bumen);
            formData.append('editXingming', xingming);
            formData.append('editTijiaoriqi', tijiaoriqi);
            formData.append('editShenqingyuanyin', shenqingyuanyin);
            formData.append('editShenpiyuanyin', shenpiyuanyin);
            formData.append('editShenpijieguo', shenpijieguo);

            // 使用AJAX提交
            $.ajax({
                url: 'lizhishenpi.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    console.log('保存成功:', response);
                    // 关闭模态框
                    hideEditAllModal();
                    // 刷新页面
                    location.reload();
                },
                error: function (xhr, status, error) {
                    console.log('保存失败:', error);
                    alert('更新失败');
                }
            });
        }

        // 关闭编辑弹窗
        function hideEditAllModal() {
            $('#editAllModal').hide();
        }

        // 删除记录
        function deleteRecord(id, index) {
            if (!confirm('确认删除序号为 ' + index + ' 的记录吗？')) return;
    
            var formData = new FormData();
            formData.append('action', 'delete');
            formData.append('id', id);

            $.ajax({
                url: 'lizhishenpi.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    try {
                        console.log("返回数据", response);

                        if (response.success) {
                            alert(response.message || '删除成功！');
                            location.reload();
                        } else {
                            alert(response.message || '删除失败');
                        }
                    } catch (e) {
                        alert('删除失败：服务器响应异常');
                    }
                },
                error: function (xhr) {
                    try {
                        var result = JSON.parse(xhr.responseText);
                        alert(result.message || '删除失败');
                    } catch (e) {
                        alert('删除失败：服务器错误');
                    }
                }
            });
        }

        // 查询记录
        function searchRecords() {
            var bumen = $('#searchBumen').val();
            var xingming = $('#searchXingming').val();
            var shenpijieguo = $('#searchShenpijieguo').val();
    
            console.log('查询条件:', { bumen: bumen, xingming: xingming, shenpijieguo: shenpijieguo });
    
            // 使用AJAX提交查询
            var formData = new FormData();
            formData.append('action', 'search');
            formData.append('bumen', bumen);
            formData.append('xingming', xingming);
            formData.append('shenpijieguo', shenpijieguo);
    
            $.ajax({
                url: 'lizhishenpi.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function(response) {
                    console.log('查询成功:', response);
                    // 刷新页面或重新加载数据
                    location.reload();
                },
                error: function(xhr, status, error) {
                    console.log('查询失败:', error);
                    alert('查询失败');
                }
            });
        }

        // 重置查询条件
        function resetSearch() {
            $('#searchBumen').val('');
            $('#searchXingming').val('');
            $('#searchShenpijieguo').val('');
    
            // 重置后重新加载所有数据
            var formData = new FormData();
            formData.append('action', 'resetsearch');
    
            $.ajax({
                url: 'lizhishenpi.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function(response) {
                    console.log('重置成功');
                    location.reload();
                },
                error: function() {
                    console.log('重置失败');
                    location.reload();
                }
            });
        }

        // 导出Excel
        function exportExcel() {
            window.open('lizhishenpi.aspx?action=export');
        }

        // 快速添加一行
        function quickAdd() {
            if (!confirm('确认添加新的离职申请记录吗？')) return;
    
            var formData = new FormData();
            formData.append('action', 'quickadd');
    
            $.ajax({
                url: 'lizhishenpi.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    alert('添加成功！');
                    location.reload();
                },
                error: function (xhr, status, error) {
                    alert('添加失败');
                }
            });
        }

        // 获取状态样式
        function getStatusClass(status) {
            if (!status) return 'status-default';
            switch(status) {
                case '通过':
                    return 'status-tongguo';
                case '驳回':
                    return 'status-bohui';
                case '待审批':
                    return 'status-daishanpi';
                default:
                    return 'status-default';
            }
        }
    </script>
</head>
<body style="margin: 0;">
    <form id="form1" runat="server">
        <div>
            <div class="ti">
                <h1>离职审批管理</h1>
            </div>
            
            <div class="header-top">
                <!-- 查询条件区域 -->
                <div class="search-box">
                    <div class="search-item">
                        <label>部门：</label>
                        <input type="text" id="searchBumen" placeholder="请输入部门" />
                    </div>
        
                    <div class="search-item">
                        <label>姓名：</label>
                        <input type="text" id="searchXingming" placeholder="请输入姓名" />
                    </div>
        
                    <div class="search-item">
                        <label>审批结果：</label>
                        <select id="searchShenpijieguo">
                            <option value="">全部</option>
                            <option value="通过">通过</option>
                            <option value="驳回">驳回</option>
                            <option value="待审批">待审批</option>
                        </select>
                    </div>
        
                    <button onclick="searchRecords()" class="top_bt">查询</button>
                    <button onclick="showAddModal()" class="top_bt">添加记录</button>
<%--                    <button onclick="quickAdd()" class="top_bt">快速添加</button>--%>
                    <button onclick="exportExcel()" class="top_bt">导出Excel</button>
                    <button onclick="resetSearch()" class="top_bt">刷新</button>
                </div>
            </div>
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" DataSourceID="SqlDataSource1" 
                AllowPaging="True" PageSize="100"
                OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="序号" ItemStyle-Width="80">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />
                    
                    <asp:TemplateField HeaderText="部门" ItemStyle-Width="150">
                        <ItemTemplate>
                            <span style="cursor: pointer;" onclick="showEditModal('<%# Eval("id") %>', '<%# Eval("bumen") %>', '<%# Eval("xingming") %>', '<%# Eval("tijiaoriqi") %>', '<%# Eval("shenqingyuanyin") %>', '<%# Eval("shenpiyuanyin") %>', '<%# Eval("shenpijieguo") %>')">
                                <%# Eval("bumen") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="姓名" ItemStyle-Width="120">
                        <ItemTemplate>
                            <span style="cursor: pointer;" onclick="showEditModal('<%# Eval("id") %>', '<%# Eval("bumen") %>', '<%# Eval("xingming") %>', '<%# Eval("tijiaoriqi") %>', '<%# Eval("shenqingyuanyin") %>', '<%# Eval("shenpiyuanyin") %>', '<%# Eval("shenpijieguo") %>')">
                                <%# Eval("xingming") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="提交日期" ItemStyle-Width="120">
                        <ItemTemplate>
                            <%# Eval("tijiaoriqi") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="申请原因" ItemStyle-Width="250">
                        <ItemTemplate>
                            <span style="cursor: pointer;" onclick="showEditModal('<%# Eval("id") %>', '<%# Eval("bumen") %>', '<%# Eval("xingming") %>', '<%# Eval("tijiaoriqi") %>', '<%# Eval("shenqingyuanyin") %>', '<%# Eval("shenpiyuanyin") %>', '<%# Eval("shenpijieguo") %>')">
                                <%# Eval("shenqingyuanyin") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="审批结果" ItemStyle-Width="120">
                        <ItemTemplate>
                            <span class='<%# GetStatusClass(Eval("shenpijieguo").ToString()) %>' onclick="showEditModal('<%# Eval("id") %>', '<%# Eval("bumen") %>', '<%# Eval("xingming") %>', '<%# Eval("tijiaoriqi") %>', '<%# Eval("shenqingyuanyin") %>', '<%# Eval("shenpiyuanyin") %>', '<%# Eval("shenpijieguo") %>')">
                                <%# Eval("shenpijieguo") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="审批原因" ItemStyle-Width="250">
                        <ItemTemplate>
                            <span style="cursor: pointer;" onclick="showEditModal('<%# Eval("id") %>', '<%# Eval("bumen") %>', '<%# Eval("xingming") %>', '<%# Eval("tijiaoriqi") %>', '<%# Eval("shenqingyuanyin") %>', '<%# Eval("shenpiyuanyin") %>', '<%# Eval("shenpijieguo") %>')">
                                <%# Eval("shenpiyuanyin") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="150">
                        <ItemTemplate>
                            <div style="display: flex; justify-content: center; gap: 5px;">
                                <button class="btn-edit" onclick="showEditModal(
                                    '<%# Eval("id") %>', 
                                    '<%# Eval("bumen") %>', 
                                    '<%# Eval("xingming") %>', 
                                    '<%# Eval("tijiaoriqi") %>', 
                                    '<%# Eval("shenqingyuanyin") %>', 
                                    '<%# Eval("shenpiyuanyin") %>', 
                                    '<%# Eval("shenpijieguo") %>'
                                )">编辑</button>
                                <button class="btn-delete" onclick="deleteRecord('<%# Eval("id") %>', '<%# Container.DataItemIndex + 1 %>')">删除</button>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
                <PagerSettings Mode="NumericFirstLast" FirstPageText="首页" LastPageText="末页" />
                <PagerStyle CssClass="pagination" HorizontalAlign="Center" />
            </asp:GridView>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:yaoConnectionString5 %>"
                SelectCommand="SELECT id, bumen, xingming, tijiaoriqi, shenqingyuanyin, shenpijieguo, shenpiyuanyin FROM gongzi_lizhishenpi WHERE gongsi = @gongsi ORDER BY id DESC">
                <SelectParameters>
                    <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        
        <!-- 添加记录模态框 -->
        <div id="addModal" class="modal">
            <div class="modal-content">
                <div class="modal-header">添加离职申请</div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>部门：</label>
                        <input type="text" id="addBumenModal" placeholder="请输入部门" required />
                    </div>

                    <div class="form-group">
                        <label>姓名：</label>
                        <input type="text" id="addXingmingModal" placeholder="请输入姓名" required />
                    </div>

                    <div class="form-group">
                        <label>提交日期：</label>
                        <input type="date" id="addTijiaoriqiModal" />
                    </div>

                    <div class="form-group">
                        <label>申请原因：</label>
                        <textarea id="addShenqingyuanyinModal" placeholder="请输入申请原因"></textarea>
                    </div>

                    <div class="form-group">
                        <label>审批原因：</label>
                        <textarea id="addShenpiyuanyinModal" placeholder="请输入审批原因"></textarea>
                    </div>

                    <div class="form-group">
                        <label>审批结果：</label>
                        <select id="addShenpijieguoModal">
                            <option value="">请选择</option>
                            <option value="通过">通过</option>
                            <option value="驳回">驳回</option>
                            <option value="待审批">待审批</option>
                        </select>
                    </div>
                </div>
                <div class="modal-footer">
                    <button onclick="hideAddModal()" style="padding: 8px 16px; background: #f5f5f5; border: 1px solid #ddd; border-radius: 4px; cursor: pointer;">取消</button>
                    <button onclick="saveAdd()" style="padding: 8px 16px; background: #5677fc; color: white; border: none; border-radius: 4px; cursor: pointer;">保存</button>
                </div>
            </div>
        </div>

        <!-- 批量编辑模态框 -->
        <div id="editAllModal" class="modal">
            <div class="modal-content">
                <div class="modal-header">编辑离职申请</div>
                <div class="modal-body">
                    <input type="hidden" id="editRecordIdModal" />
            
                    <div class="form-group">
                        <label>部门：</label>
                        <input type="text" id="editBumenModal" placeholder="请输入部门" required />
                    </div>

                    <div class="form-group">
                        <label>姓名：</label>
                        <input type="text" id="editXingmingModal" placeholder="请输入姓名" required />
                    </div>

                    <div class="form-group">
                        <label>提交日期：</label>
                        <input type="date" id="editTijiaoriqiModal" />
                    </div>

                    <div class="form-group">
                        <label>申请原因：</label>
                        <textarea id="editShenqingyuanyinModal" placeholder="请输入申请原因"></textarea>
                    </div>

                    <div class="form-group">
                        <label>审批原因：</label>
                        <textarea id="editShenpiyuanyinModal" placeholder="请输入审批原因"></textarea>
                    </div>

                    <div class="form-group">
                        <label>审批结果：</label>
                        <select id="editShenpijieguoModal">
                            <option value="">请选择</option>
                            <option value="通过">通过</option>
                            <option value="驳回">驳回</option>
                            <option value="待审批">待审批</option>
                        </select>
                    </div>
                </div>
                <div class="modal-footer">
                    <button onclick="hideEditAllModal()" style="padding: 8px 16px; background: #f5f5f5; border: 1px solid #ddd; border-radius: 4px; cursor: pointer;">取消</button>
                    <button onclick="saveAllEdit()" style="padding: 8px 16px; background: #5677fc; color: white; border: none; border-radius: 4px; cursor: pointer;">保存</button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>