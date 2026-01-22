<%@ page language="C#" autoeventwireup="true" codebehind="qingjiashenpi.aspx.cs" inherits="Web.Personnel.qingjiashenpi" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>请假审批管理</title>
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
        .status-daishanpi {
            color: white;
            background: #2196F3;
            padding: 3px 8px;
            border-radius: 3px;
            font-weight: bold;
            cursor: pointer;
        }
        
        .status-tongguo {
            color: white;
            background: #4CAF50;
            padding: 3px 8px;
            border-radius: 3px;
            font-weight: bold;
            cursor: pointer;
        }
        
        .status-bohui {
            color: white;
            background: #f44336;
            padding: 3px 8px;
            border-radius: 3px;
            font-weight: bold;
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
        
        /* 响应式设计 */
        @media (max-width: 768px) {
            .search-box {
                flex-direction: column;
                align-items: flex-start;
            }
            
            .search-item {
                width: 100%;
            }
            
            .search-item input,
            .search-item select {
                flex: 1;
            }
        }
        
        /* 单元格样式 */
        .cell-date {
            color: #1976d2;
        }
        
        /* 序号列样式 */
        .sequence-cell {
            color: #666;
            font-size: 12px;
        }
    </style>
    <script src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        // 显示添加弹窗
        function showAddModal() {
            // 清空表单字段
            $('#addBumenModal').val('');
            $('#addXingmingModal').val('');
            $('#addTijiaoshijianModal').val('');
            $('#addQsqingjiashijianModal').val('');
            $('#addJzqingjiashijanModal').val('');
            $('#addQingjiayuanyinModal').val('');
            $('#addShenpiyuanyinModal').val('');
            $('#addZhuangtaiModal').val('待审批');
            
            // 设置当天日期
            var today = new Date();
            var formattedDate = today.getFullYear() + '-' + 
                               String(today.getMonth() + 1).padStart(2, '0') + '-' + 
                               String(today.getDate()).padStart(2, '0');
            $('#addTijiaoshijianModal').val(formattedDate);
            
            // 显示模态框
            $('#addModal').show();
        }

        // 保存添加的记录
        function saveAdd() {
            // 获取表单值
            var bumen = $('#addBumenModal').val();
            var xingming = $('#addXingmingModal').val();
            var tijiaoshijian = $('#addTijiaoshijianModal').val();
            var qsqingjiashijian = $('#addQsqingjiashijianModal').val();
            var jzqingjiashijan = $('#addJzqingjiashijanModal').val();
            var qingjiayuanyin = $('#addQingjiayuanyinModal').val();
            var shenpiyuanyin = $('#addShenpiyuanyinModal').val();
            var zhuangtai = $('#addZhuangtaiModal').val();

            // 验证必填字段
            if (!bumen) {
                alert('部门不能为空！');
                return;
            }
            if (!xingming) {
                alert('员工名称不能为空！');
                return;
            }

            // 创建FormData对象
            var formData = new FormData();
            formData.append('action', 'add');
            formData.append('addBumen', bumen);
            formData.append('addXingming', xingming);
            formData.append('addTijiaoshijian', tijiaoshijian);
            formData.append('addQsqingjiashijian', qsqingjiashijian);
            formData.append('addJzqingjiashijan', jzqingjiashijan);
            formData.append('addQingjiayuanyin', qingjiayuanyin);
            formData.append('addShenpiyuanyin', shenpiyuanyin);
            formData.append('addZhuangtai', zhuangtai);

            // 使用AJAX提交
            $.ajax({
                url: 'qingjiashenpi.aspx',
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
        function showEditModal(id, bumen, xingming, tijiaoshijian, qsqingjiashijian, jzqingjiashijan, qingjiayuanyin, shenpiyuanyin, zhuangtai) {
            // 防止事件冒泡
            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }
    
            console.log('编辑数据:', {id, bumen, xingming, tijiaoshijian, qsqingjiashijian, jzqingjiashijan, qingjiayuanyin, shenpiyuanyin, zhuangtai});
    
            // 填充表单字段
            $('#editRecordIdModal').val(id);
            $('#editBumenModal').val(bumen || '');
            $('#editXingmingModal').val(xingming || '');
            
            // 处理日期字段
            var dateFields = ['tijiaoshijian', 'qsqingjiashijian', 'jzqingjiashijan'];
            var dateValues = [tijiaoshijian, qsqingjiashijian, jzqingjiashijan];
            
            for (var i = 0; i < dateFields.length; i++) {
                var field = dateFields[i];
                var value = dateValues[i];
                
                if (value) {
                    // 如果数据库中是完整的日期时间格式，截取日期部分
                    var datePart = value.split(' ')[0]; // 分离日期和时间部分
                    $('#edit' + field.charAt(0).toUpperCase() + field.slice(1) + 'Modal').val(datePart);
                } else {
                    // 如果没有日期，设置当天日期
                    var today = new Date();
                    var formattedDate = today.getFullYear() + '-' + 
                                       String(today.getMonth() + 1).padStart(2, '0') + '-' + 
                                       String(today.getDate()).padStart(2, '0');
                    $('#edit' + field.charAt(0).toUpperCase() + field.slice(1) + 'Modal').val(formattedDate);
                }
            }
            
            $('#editQingjiayuanyinModal').val(qingjiayuanyin || '');
            $('#editShenpiyuanyinModal').val(shenpiyuanyin || '');
            
            // 设置状态选择
            if (zhuangtai) {
                $('#editZhuangtaiModal').val(zhuangtai);
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
            var tijiaoshijian = $('#editTijiaoshijianModal').val();
            var qsqingjiashijian = $('#editQsqingjiashijianModal').val();
            var jzqingjiashijan = $('#editJzqingjiashijanModal').val();
            var qingjiayuanyin = $('#editQingjiayuanyinModal').val();
            var shenpiyuanyin = $('#editShenpiyuanyinModal').val();
            var zhuangtai = $('#editZhuangtaiModal').val();

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
                alert('员工名称不能为空！');
                return;
            }

            // 创建FormData对象
            var formData = new FormData();
            formData.append('action', 'edital');
            formData.append('editRecordId', id);
            formData.append('editBumen', bumen);
            formData.append('editXingming', xingming);
            formData.append('editTijiaoshijian', tijiaoshijian);
            formData.append('editQsqingjiashijian', qsqingjiashijian);
            formData.append('editJzqingjiashijan', jzqingjiashijan);
            formData.append('editQingjiayuanyin', qingjiayuanyin);
            formData.append('editShenpiyuanyin', shenpiyuanyin);
            formData.append('editZhuangtai', zhuangtai);

            // 使用AJAX提交
            $.ajax({
                url: 'qingjiashenpi.aspx',
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
                url: 'qingjiashenpi.aspx',
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
            var zhuangtai = $('#searchZhuangtai').val();
    
            console.log('查询条件:', { bumen: bumen, xingming: xingming, zhuangtai: zhuangtai });
    
            // 使用AJAX提交查询
            var formData = new FormData();
            formData.append('action', 'search');
            formData.append('bumen', bumen);
            formData.append('xingming', xingming);
            formData.append('zhuangtai', zhuangtai);
    
            $.ajax({
                url: 'qingjiashenpi.aspx',
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
            $('#searchZhuangtai').val('');
    
            // 重置后重新加载所有数据
            var formData = new FormData();
            formData.append('action', 'resetsearch');
    
            $.ajax({
                url: 'qingjiashenpi.aspx',
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
            window.open('qingjiashenpi.aspx?action=export');
        }

        // 更新审批状态
        function updateStatus(id, currentValue) {
            var statusOptions = ['待审批', '通过', '驳回'];
            var currentIndex = statusOptions.indexOf(currentValue);
            if (currentIndex === -1) currentIndex = 0;
            
            var newValue = prompt('请输入审批状态 (待审批/通过/驳回):', statusOptions[currentIndex]);
            if (newValue !== null) {
                if (statusOptions.indexOf(newValue) !== -1) {
                    // 直接调用更新状态的方法，后端会自动更新考勤记录
                    updateStatusRecord(id, newValue);
                } else {
                    alert('状态值不正确，请选择：待审批、通过或驳回');
                }
            }
        }

        // 更新状态记录
        function updateStatusRecord(id, newStatus) {
            var formData = new FormData();
            formData.append('action', 'updatestatus');
            formData.append('id', id);
            formData.append('status', newStatus);

            $.ajax({
                url: 'qingjiashenpi.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function(response) {
                    try {
                        var result = typeof response === 'string' ? JSON.parse(response) : response;
                        if (result.success) {
                            alert(result.message);
                            location.reload();
                        } else {
                            alert(result.message || '更新失败');
                        }
                    } catch (e) {
                        console.log('解析响应失败:', e);
                        alert('更新成功');
                        location.reload();
                    }
                },
                error: function(xhr, status, error) {
                    console.log('更新失败:', error);
                    alert('更新失败');
                }
            });
        }

        // 获取状态样式
        function getStatusClass(status) {
            if (!status) return 'status-daishanpi';
            switch(status) {
                case '通过':
                    return 'status-tongguo';
                case '驳回':
                    return 'status-bohui';
                case '待审批':
                    return 'status-daishanpi';
                default:
                    return 'status-daishanpi';
            }
        }
    </script>
</head>
<body style="margin: 0;">
    <form id="form1" runat="server">
        <div>
            <div class="ti">
                <h1>请假审批管理</h1>
            </div>
            
            <div class="header-top">
                <!-- 查询条件区域 -->
                <div class="search-box">
                    <div class="search-item">
                        <label>部门：</label>
                        <input type="text" id="searchBumen" placeholder="请输入部门" />
                    </div>
        
                    <div class="search-item">
                        <label>员工名称：</label>
                        <input type="text" id="searchXingming" placeholder="请输入姓名" />
                    </div>
        
                    <div class="search-item">
                        <label>审批状态：</label>
                        <select id="searchZhuangtai">
                            <option value="">全部</option>
                            <option value="待审批">待审批</option>
                            <option value="通过">通过</option>
                            <option value="驳回">驳回</option>
                        </select>
                    </div>
        
                    <button onclick="searchRecords()" class="top_bt">查询</button>
                    <button onclick="showAddModal()" class="top_bt">添加记录</button>
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
                    
                    <asp:BoundField DataField="bumen" HeaderText="部门" ItemStyle-Width="120" />
                    
                    <asp:BoundField DataField="xingming" HeaderText="员工名称" ItemStyle-Width="120" />
                    
                    <asp:BoundField DataField="tijiaoshijian" HeaderText="申请时间" ItemStyle-Width="120" 
                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                    
                    <asp:BoundField DataField="qsqingjiashijian" HeaderText="起始日期" ItemStyle-Width="120"
                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                    
                    <asp:BoundField DataField="jzqingjiashijan" HeaderText="截止日期" ItemStyle-Width="120"
                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                    
                    <asp:BoundField DataField="qingjiayuanyin" HeaderText="请假原因" ItemStyle-Width="200" />
                    
                    <asp:TemplateField HeaderText="审批状态" ItemStyle-Width="110">
                        <ItemTemplate>
                            <span class='<%# GetStatusClass(Eval("zhuangtai").ToString()) %>' onclick="updateStatus('<%# Eval("id") %>', '<%# Eval("zhuangtai") %>')">
                                <%# Eval("zhuangtai") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="shenpiyuanyin" HeaderText="审批原因" ItemStyle-Width="200" />
                    
                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="150">
                        <ItemTemplate>
                            <div style="display: flex; justify-content: center; gap: 5px;">
                                <button class="btn-edit" onclick="showEditModal(
                                    '<%# Eval("id") %>', 
                                    '<%# Eval("bumen") %>', 
                                    '<%# Eval("xingming") %>', 
                                    '<%# Eval("tijiaoshijian") %>', 
                                    '<%# Eval("qsqingjiashijian") %>', 
                                    '<%# Eval("jzqingjiashijan") %>', 
                                    '<%# Eval("qingjiayuanyin") %>', 
                                    '<%# Eval("shenpiyuanyin") %>', 
                                    '<%# Eval("zhuangtai") %>'
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
                SelectCommand="SELECT id, bumen, xingming, tijiaoshijian, qsqingjiashijian, jzqingjiashijan, qingjiayuanyin, zhuangtai, shenpiyuanyin FROM gongzi_qingjiashenpi WHERE gongsi = @gongsi ORDER BY id DESC">
                <SelectParameters>
                    <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        
        <!-- 添加记录模态框 -->
        <div id="addModal" class="modal">
            <div class="modal-content">
                <div class="modal-header">添加请假申请</div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>部门：</label>
                        <input type="text" id="addBumenModal" placeholder="请输入部门" required />
                    </div>

                    <div class="form-group">
                        <label>员工名称：</label>
                        <input type="text" id="addXingmingModal" placeholder="请输入员工名称" required />
                    </div>

                    <div class="form-group">
                        <label>申请时间：</label>
                        <input type="date" id="addTijiaoshijianModal" />
                    </div>

                    <div class="form-group">
                        <label>起始请假日期：</label>
                        <input type="date" id="addQsqingjiashijianModal" />
                    </div>

                    <div class="form-group">
                        <label>截止请假日期：</label>
                        <input type="date" id="addJzqingjiashijanModal" />
                    </div>

                    <div class="form-group">
                        <label>请假原因：</label>
                        <textarea id="addQingjiayuanyinModal" placeholder="请输入请假原因"></textarea>
                    </div>

                    <div class="form-group">
                        <label>审批原因：</label>
                        <textarea id="addShenpiyuanyinModal" placeholder="请输入审批原因"></textarea>
                    </div>

                    <div class="form-group">
                        <label>审批状态：</label>
                        <select id="addZhuangtaiModal">
                            <option value="待审批">待审批</option>
                            <option value="通过">通过</option>
                            <option value="驳回">驳回</option>
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
                <div class="modal-header">编辑请假申请</div>
                <div class="modal-body">
                    <input type="hidden" id="editRecordIdModal" />
            
                    <div class="form-group">
                        <label>部门：</label>
                        <input type="text" id="editBumenModal" placeholder="请输入部门" required />
                    </div>

                    <div class="form-group">
                        <label>员工名称：</label>
                        <input type="text" id="editXingmingModal" placeholder="请输入员工名称" required />
                    </div>

                    <div class="form-group">
                        <label>申请时间：</label>
                        <input type="date" id="editTijiaoshijianModal" />
                    </div>

                    <div class="form-group">
                        <label>起始请假日期：</label>
                        <input type="date" id="editQsqingjiashijianModal" />
                    </div>

                    <div class="form-group">
                        <label>截止请假日期：</label>
                        <input type="date" id="editJzqingjiashijanModal" />
                    </div>

                    <div class="form-group">
                        <label>请假原因：</label>
                        <textarea id="editQingjiayuanyinModal" placeholder="请输入请假原因"></textarea>
                    </div>

                    <div class="form-group">
                        <label>审批原因：</label>
                        <textarea id="editShenpiyuanyinModal" placeholder="请输入审批原因"></textarea>
                    </div>

                    <div class="form-group">
                        <label>审批状态：</label>
                        <select id="editZhuangtaiModal">
                            <option value="待审批">待审批</option>
                            <option value="通过">通过</option>
                            <option value="驳回">驳回</option>
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