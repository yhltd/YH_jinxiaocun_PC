<%@ page language="C#" autoeventwireup="true" codebehind="mianshiguanli.aspx.cs" inherits="Web.Personnel.mianshiguanli" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../Scripts/layui/layui.all.js"></script>
    <script src="../../Scripts/layui/lay/modules/layer.js"></script>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title>面试管理</title>
</head>
<body style="margin: 0;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="../Myadmin/js/jquerysession.js"></script>
    <script type="text/javascript" src="js/iframe_d.js"></script>
    <link rel="stylesheet" type="text/css" href="css/iframe_d.css" />
    <script type="text/javascript">
        // 文件上传相关函数
        function showUploadModal(id, name) {
            // 设置表单隐藏字段
            $('#uploadRecordId').val(id);
            $('#uploadRecordName').val(name);
            $('#uploadFileName').val('');
            $('#uploadModal').show();
        }

        function hideUploadModal() {
            $('#uploadModal').hide();
            $('#selectedFilesList').empty();
        }

        function showFileViewModal(id, name) {
            // 防止事件冒泡
            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }
    
            console.log('查看文件，记录ID:', id, '名称:', name);
    
            // 设置模态框标题
            $('#fileViewModal .modal-header').text(name + ' - 文件列表');
    
            // 显示加载中
            $('#fileListContent').html('<div style="text-align: center; padding: 20px;">加载中...</div>');
    
            // 显示模态框
            $('#fileViewModal').show();
    
            // 使用AJAX获取文件列表
            var formData = new FormData();
            formData.append('action', 'getfiles');
            formData.append('fileRecordId', id);
    
            $.ajax({
                url: 'mianshiguanli.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    console.log('获取文件列表成功:', response);
                    // 将服务器返回的HTML内容显示在模态框中
                    $('#fileListContent').html(response);
                },
                error: function (xhr, status, error) {
                    $('#fileListContent').html('<div style="color: red; text-align: center; padding: 20px;">加载失败，请重试</div>');
                }
            });
        }

        function hideFileViewModal() {
            $('#fileViewModal').hide();
        }

        function previewFile(url) {
            window.open(url, '_blank');
        }

        function deleteFile(id, url) {
            if (confirm('确定要删除这个文件吗？')) {
                // 从URL中提取文件名
                var fileName = url.substring(url.lastIndexOf('/') + 1);
                var cleanFileName = fileName.split('.')[0]; // 移除扩展名
        
                console.log('删除文件:', fileName, '清理后:', cleanFileName);
        
                // 显示加载状态
                $('#fileListContent').html('<div style="text-align: center; padding: 20px;">删除中...</div>');
        
                $.ajax({
                    url: 'https://yhocn.cn:9097/file/delete',
                    type: 'POST',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: {
                        order_number: cleanFileName,
                        path: '/人事系统/简历文件/'
                    },success: function(response) {
                        console.log('删除响应:', response);
                
                        try {
                    
                            if (response.code === 200 || response.success) {
                                // 从数据库移除文件记录
                                removeFileFromDatabase(url, id);
                                location.reload();
                        
                                alert('删除成功');
                            } else {
                                alert('删除失败: ' + (resData.msg || '未知错误'));
                                // 重新加载文件列表
                                showFileViewModal(id, '');
                            }
                        } catch (e) {
                            console.error('解析响应失败:', e);
                            alert('删除失败: 响应格式错误');
                            showFileViewModal(id, '');
                        }
                    },
                    error: function(xhr, status, error) {
                        console.error('删除请求失败:', error);
                        alert('删除请求失败');
                        showFileViewModal(id, '');
                    }
                });
            }
        }

        // 从数据库移除文件记录
        function removeFileFromDatabase(fileUrl, recordId) {
            $.ajax({
                url: 'mianshiguanli.aspx',
                type: 'POST',
                data: {
                    action: 'removefile',
                    id: recordId,
                    fileUrl: fileUrl
                },
                success: function(response) {
                    console.log('数据库更新成功');
                    // 重新加载文件列表
                    showFileViewModal(recordId, '');
                },
                error: function() {
                    console.log('数据库更新失败');
                    showFileViewModal(recordId, '');
                }
            });
        }

        // 文件选择
        $(document).ready(function () {
            $('#fileInput').change(function () {
                var files = this.files;
                var html = '';
                for (var i = 0; i < files.length; i++) {
                    html += '<div>' + (i + 1) + '. ' + files[i].name + ' (' + Math.round(files[i].size / 1024) + 'KB)</div>';
                }
                $('#selectedFilesList').html(html);
            });
        });

        // 开始上传
        function startUpload() {
            var fileInput = document.getElementById('fileInput');
            var files = fileInput.files;
            var recordId = $('#uploadRecordId').val();
            var recordName = $('#uploadRecordName').val();
            var fileName = $('#fileName').val(); 

            if (files.length === 0) {
                alert('请选择文件');
                return;
            }

            if (!recordId) {
                alert('请先选择记录');
                return;
            }

            if (!recordName) {
                alert('记录名称不能为空');
                return;
            }

            if (!fileName || fileName.trim() === '') {
                alert('请输入文件名称');
                return;
            }

            if (!confirm('确定要上传 ' + files.length + ' 个文件吗？')) {
                return;
            }

            var uploadedFiles = [];
            var totalFiles = files.length;
            var completedCount = 0;

            // 显示上传进度
            $('#uploadProgress').val(0);
            $('#uploadProgressText').text('0%');

            // 按顺序上传每个文件
            function uploadNextFile(index) {
                if (index >= totalFiles) {
                    // 所有文件上传完成
                    handleUploadComplete(uploadedFiles);
                    return;
                }

                var file = files[index];
                var fileExtension = file.name.split('.').pop().toLowerCase();
        
                // 清理文件名中的非法字符
                var baseName = fileName.trim().replace(/[\\/:*?"<>|]/g, '_');
        
                // 如果文件名已经包含扩展名，去掉它
                if (baseName.includes('.')) {
                    baseName = baseName.split('.').slice(0, -1).join('.');
                }
        
                // 构建最终文件名
                var finalFileName = '';
                if (totalFiles === 1) {
                    finalFileName = baseName + '.' + fileExtension;
                } else {
                    finalFileName = baseName + '_' + (index + 1) + '.' + fileExtension;
                }

                // 更新进度
                var progress = Math.round((index / totalFiles) * 100);
                $('#uploadProgress').val(progress);
                $('#uploadProgressText').text(progress + '%');

                // 使用FormData上传
                var formData = new FormData();
                formData.append('file', file);
                formData.append('name', finalFileName);
                formData.append('path', '/人事系统/简历文件/');
                formData.append('kongjian', '3');
                formData.append('fileType', fileExtension);
                formData.append('recordId', recordId);
                formData.append('recordName', recordName);
                formData.append('userFileName', fileName);
                formData.append('originalName', file.name);
                formData.append('index', index + 1);
                formData.append('total', totalFiles);
                formData.append('timestamp', Date.now());

                $.ajax({
                    url: 'https://yhocn.cn:9097/file/upload',
                    type: 'POST',
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function(response) {
                        completedCount++;
                
                        try {
                            var resData = typeof response === 'string' ? JSON.parse(response) : response;
                    
                            if (resData.code === 200 || resData.success) {
                                // 构建文件URL - 使用小程序中的URL格式
                                var fileUrl = "http://yhocn.cn:9088/人事系统/简历文件/" + finalFileName;
                                uploadedFiles.push({
                                    name: finalFileName,
                                    url: fileUrl,
                                    originalName: file.name,
                                    userFileName: fileName,
                                    size: file.size,
                                    type: fileExtension
                                });
                        
                                console.log('第 ' + (index + 1) + ' 个文件上传成功');
                        
                                // 继续上传下一个文件
                                setTimeout(function() {
                                    uploadNextFile(index + 1);
                                }, 500);
                            } else {
                                alert('第 ' + (index + 1) + ' 个文件上传失败: ' + (resData.msg || '未知错误'));
                                setTimeout(function() {
                                    uploadNextFile(index + 1);
                                }, 1000);
                            }
                        } catch (e) {
                            console.error('解析响应失败:', e, response);
                            setTimeout(function() {
                                uploadNextFile(index + 1);
                            }, 1000);
                        }
                    },
                    error: function(xhr, status, error) {
                        completedCount++;
                        console.error('上传失败:', error);
                        alert('第 ' + (index + 1) + ' 个文件上传失败');
                        setTimeout(function() {
                            uploadNextFile(index + 1);
                        }, 1000);
                    }
                });
            }

            // 开始上传第一个文件
            uploadNextFile(0);
        }

        // 处理上传完成
        function handleUploadComplete(uploadedFiles) {
            if (uploadedFiles.length > 0) {
                // 保存文件信息到数据库
                saveFilesToDatabase(uploadedFiles);
            }
    
            $('#uploadProgress').val(100);
            $('#uploadProgressText').text('100%');
    
            setTimeout(function() {
                hideUploadModal();
                alert('上传完成，成功 ' + uploadedFiles.length + ' 个文件');
                location.reload();
            }, 1000);
        }

        // 保存文件信息到数据库
        function saveFilesToDatabase(files) {
            var recordId = $('#uploadRecordId').val();
    
            if (!files || files.length === 0 || !recordId) return;
    
            // 获取所有文件的URL
            var fileUrls = files.map(function(file) {
                return file.url;
            }).join(',');
    
            // 使用AJAX更新数据库
            $.ajax({
                url: 'mianshiguanli.aspx',
                type: 'POST',
                data: {
                    action: 'savefileurls',
                    id: recordId,
                    fileUrls: fileUrls
                },
                success: function(response) {
                    console.log('文件信息保存到数据库成功');
                },
                error: function() {
                    console.log('文件信息保存失败');
                }
            });
        }




        function saveEdit() {
            var id = $('#<%= hiddenEditId.ClientID %>').val();
            var field = $('#<%= hiddenEditField.ClientID %>').val();
            var value = field === 'zhuangtai' ? $('#statusSelect').val() : $('#editValue').val();

            // 设置隐藏字段的值
            $('#<%= hiddenEditValue.ClientID %>').val(value);
            $('#<%= action.ClientID %>').val('edit');

            // 提交表单
            $('#form1').submit();
        }

        // 删除函数
        function deleteRecord(id, index) {
            if (!confirm('确认删除记录吗？')) return;
    
            var formData = new FormData();
            formData.append('action', 'delete');
            formData.append('id', id);

            $.ajax({
                url: 'mianshiguanli.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    try {
                        console.log("返回数据",response)

                        if (response.success) {
                            alert(response.message || '删除成功！');
                            location.reload();
                        } else {
                            // 直接显示服务器返回的消息
                            alert(response.message || '删除失败');
                        }
                    } catch (e) {
                        alert('删除失败：服务器响应异常');
                    }
                },
                error: function (xhr) {
                    try {
                        // 尝试解析错误响应
                        var result = JSON.parse(xhr.responseText);
                        alert(result.message || '删除失败');
                    } catch (e) {
                        alert('删除失败：服务器错误');
                    }
                }
            });
        }


        // 导出Excel
        function exportExcel() {
            window.open('mianshiguanli.aspx?action=export');
        }

        // 取消编辑
        function cancelEdit() {
            $('#editModal').hide();
        }

        // 显示编辑弹窗 - 编辑所有字段
        function showEditModal(id, touliren, xueli, mubiaogangwei, tijiaoshijian, beizhu, zhuangtai, mianshipizhu) {
            // 防止事件冒泡
            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }

            console.log('编辑数据:', {id, touliren, xueli, mubiaogangwei, tijiaoshijian, beizhu, zhuangtai, mianshipizhu});

            // 填充表单字段
            $('#editRecordIdModal').val(id);
            $('#editToulirenModal').val(touliren || '');
            $('#editXueliModal').val(xueli || '');
            $('#editMubiaogangweiModal').val(mubiaogangwei || '');
            if (tijiaoshijian) {
                // 如果数据库中是完整的日期时间格式，截取日期部分
                var datePart = tijiaoshijian.split(' ')[0];
                $('#editTijiaoshijianModal').val(datePart);
            } else {
                // 如果没有日期，设置当天日期
                var today = new Date();
                var formattedDate = today.getFullYear() + '-' + 
                                   String(today.getMonth() + 1).padStart(2, '0') + '-' + 
                                   String(today.getDate()).padStart(2, '0');
                $('#editTijiaoshijianModal').val(formattedDate);
            }
            $('#editBeizhuModal').val(beizhu || '');
            // 添加面试批注字段
            $('#editMianshipizhuModal').val(mianshipizhu || '');

            // 设置状态选择（如果需要保留状态字段用于内部逻辑）
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
            var touliren = $('#editToulirenModal').val();
            var xueli = $('#editXueliModal').val();
            var mubiaogangwei = $('#editMubiaogangweiModal').val();
            var tijiaoshijian = $('#editTijiaoshijianModal').val();
            var beizhu = $('#editBeizhuModal').val();
            var mianshipizhu = $('#editMianshipizhuModal').val(); // 新增
            var zhuangtai = $('#editZhuangtaiModal').val();

            if (!id) {
                alert('记录ID不能为空！');
                return;
            }

            // 创建FormData对象
            var formData = new FormData();
            formData.append('action', 'edital');
            formData.append('editRecordId', id);
            formData.append('editTouliren', touliren);
            formData.append('editXueli', xueli);
            formData.append('editMubiaogangwei', mubiaogangwei);
            formData.append('editTijiaoshijian', tijiaoshijian);
            formData.append('editBeizhu', beizhu);
            formData.append('editMianshipizhu', mianshipizhu); // 新增
            formData.append('editZhuangtai', zhuangtai);

            // 使用AJAX提交
            $.ajax({
                url: 'mianshiguanli.aspx',
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

        function deleteFileFromModal(id, url, fileName) {
            if (confirm('确定要删除文件吗？')) {
                var formData = new FormData();
                formData.append('action', 'deletefile');
                formData.append('deleteFileRecordId', id);
                formData.append('deleteFileUrl', url);

                $.ajax({
                    url: 'mianshiguanli.aspx',
                    type: 'POST',
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (response) {
                        alert('删除成功');
                        // 重新加载文件列表
                        var currentRecordId = $('#fileViewModal').data('currentRecordId');
                        if (currentRecordId) {
                            showFileViewModal(currentRecordId, '');
                        }
                    },
                    error: function () {
                        alert('删除失败');
                    }
                });
            }
        }

        // 预览文件函数
        function previewFileFromModal(url) {
            window.open(url, '_blank');
        }

        // 显示添加弹窗
        function showAddModal() {
            // 防止事件冒泡
            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }

            // 清空表单字段
            $('#addToulirenModal').val('');
            $('#addXueliModal').val('');
            $('#addMubiaogangweiModal').val('');
    
            // 设置当天日期
            var today = new Date();
            var formattedDate = today.getFullYear() + '-' + 
                               String(today.getMonth() + 1).padStart(2, '0') + '-' + 
                               String(today.getDate()).padStart(2, '0');
            $('#addTijiaoshijianModal').val(formattedDate);
    
            $('#addBeizhuModal').val('');
            $('#addMianshipizhuModal').val(''); // 新增：清空面试批注
            $('#addZhuangtaiModal').val('通过'); // 默认状态

            // 显示模态框
            $('#addModal').show();
        }

        // 保存添加的记录
        function saveAdd() {
            // 获取表单值
            var touliren = $('#addToulirenModal').val();
            var xueli = $('#addXueliModal').val();
            var mubiaogangwei = $('#addMubiaogangweiModal').val();
            var tijiaoshijian = $('#addTijiaoshijianModal').val();
            var beizhu = $('#addBeizhuModal').val();
            var mianshipizhu = $('#addMianshipizhuModal').val(); // 新增：获取面试批注
            var zhuangtai = $('#addZhuangtaiModal').val();

            // 验证必填字段
            if (!touliren) {
                alert('投历人名不能为空！');
                return;
            }

            // 创建FormData对象
            var formData = new FormData();
            formData.append('action', 'add');
            formData.append('addTouliren', touliren);
            formData.append('addXueli', xueli);
            formData.append('addMubiaogangwei', mubiaogangwei);
            formData.append('addTijiaoshijian', tijiaoshijian);
            formData.append('addBeizhu', beizhu);
            formData.append('addMianshipizhu', mianshipizhu); // 新增：添加面试批注
            formData.append('addZhuangtai', zhuangtai);

            // 使用AJAX提交
            $.ajax({
                url: 'mianshiguanli.aspx',
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

        // 查询记录
        function searchRecords() {
            var touliren = $('#searchTouliren').val();
            var xueli = $('#searchXueli').val();

            console.log('查询条件:', { touliren: touliren, xueli: xueli });

            // 使用AJAX提交查询
            var formData = new FormData();
            formData.append('action', 'search');
            formData.append('touliren', touliren);
            formData.append('xueli', xueli);

            $.ajax({
                url: 'mianshiguanli.aspx',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function(response) {
                    console.log('查询成功:', response);
                    try {
                        var result = JSON.parse(response);
                        if (result.success) {
                            // 刷新页面或重新加载数据
                            location.reload();
                        } else {
                            alert('查询失败: ' + result.message);
                        }
                    } catch (e) {
                        // 直接刷新页面
                        location.reload();
                    }
                },
                error: function(xhr, status, error) {
                    console.log('查询失败:', error);
                    alert('查询失败');
                }
            });
        }

        // 重置查询条件
        function resetSearch() {
            $('#searchTouliren').val('');
            $('#searchXueli').val('');
            $('#searchZhuangtai').val('');
    
            // 重置后重新加载所有数据
            var formData = new FormData();
            formData.append('action', 'resetsearch');
    
            $.ajax({
                url: 'mianshiguanli.aspx',
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
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            line-height: 10px;
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
        .btn-upload {
            background: #4CAF50;
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 3px;
            cursor: pointer;
            font-size: 12px;
            margin: 2px;
        }
        
        .btn-view {
            background: #2196F3;
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 3px;
            cursor: pointer;
            font-size: 12px;
            margin: 2px;
        }
        
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
        
        /* 分页样式 */
        .pagination {
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 20px 0;
            gap: 10px;
        }
        
        .page-info {
            padding: 5px 15px;
            background: #f5f5f5;
            border-radius: 4px;
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
            max-width: 600px;
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
        
        .file-list {
            max-height: 300px;
            overflow-y: auto;
            border: 1px solid #ddd;
            border-radius: 4px;
            padding: 10px;
        }
        
        .file-item {
            padding: 10px;
            border-bottom: 1px solid #eee;
        }
        
        .file-item:last-child {
            border-bottom: none;
        }
    </style>
    
    <form id="form1" runat="server">

        <input type="hidden" id="uploadRecordId" name="uploadRecordId" runat="server" />
        <input type="hidden" id="uploadRecordName" name="uploadRecordName" runat="server" />
        <input type="hidden" id="uploadFileName" name="uploadFileName" runat="server" />

        <input type="hidden" id="fileRecordId" name="fileRecordId" runat="server" />
        <input type="hidden" id="deleteFileRecordId" name="deleteFileRecordId" runat="server" />
        <input type="hidden" id="deleteFileUrl" name="deleteFileUrl" runat="server" />

        <input type="hidden" id="hiddenEditId" name="hiddenEditId" runat="server" />
        <input type="hidden" id="hiddenEditField" name="hiddenEditField" runat="server" />
        <input type="hidden" id="hiddenEditValue" name="hiddenEditValue" runat="server" />

        <input type="hidden" id="deleteId" name="deleteId" runat="server" />
        <input type="hidden" id="Hidden1" name="statusSelect" runat="server" />
        <input type="hidden" id="action" name="action" runat="server" />

        <input type="hidden" id="editRecordId" name="editRecordId" />
        <input type="hidden" id="editTouliren" name="editTouliren" />
        <input type="hidden" id="editXueli" name="editXueli" />
        <input type="hidden" id="editMubiaogangwei" name="editMubiaogangwei" />
        <input type="hidden" id="editTijiaoshijian" name="editTijiaoshijian" />
        <input type="hidden" id="editBeizhu" name="editBeizhu" />
        <input type="hidden" id="editZhuangtai" name="editZhuangtai" />
        <input type="hidden" id="editMianshipizhu" name="editMianshipizhu" />
        <input type="hidden" id="addMianshipizhu" name="addMianshipizhu" />

        <div>
            <div class="ti">
                <h1>面试管理</h1>
            </div>
            
            <div class="header-top">
                
    
                <!-- 查询条件区域 -->
                <div style="display: flex; align-items: center; gap: 10px;">
                    <div style="display: flex; align-items: center; gap: 5px;">
                        <label style="font-size: 14px;">投历人名：</label>
                        <input type="text" id="searchTouliren" placeholder="请输入姓名" style="padding: 5px 10px; border: 1px solid #ddd; border-radius: 4px; width: 120px;" />
                    </div>
        
                    <div style="display: flex; align-items: center; gap: 5px;">
                        <label style="font-size: 14px;">学历：</label>
                        <input type="text" id="searchXueli" placeholder="请输入学历" style="padding: 5px 10px; border: 1px solid #ddd; border-radius: 4px; width: 100px;" />
                    </div>
        
                    <button onclick="searchRecords()" class="top_bt" style="padding: 5px 15px; font-size: 14px;">查询</button>
                    <asp:Button ID="btnAdd" CssClass="top_bt" runat="server" Text="添加记录" OnClientClick="showAddModal(); return false;" />
                    <asp:Button ID="btnExport" CssClass="top_bt" runat="server" Text="导出Excel" OnClientClick="exportExcel(); return false;" />
                    <button onclick="resetSearch()" class="top_bt" style="padding: 5px 15px; font-size: 14px;">刷新</button>
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
                    
                    <asp:TemplateField HeaderText="投历人名" ItemStyle-Width="200">
                        <ItemTemplate>
                            <span style="cursor: pointer; ">
                                <%# Eval("touliren") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="学历" ItemStyle-Width="120">
                        <ItemTemplate>
                            <span  style="cursor: pointer; ">
                                <%# Eval("xueli") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="目标岗位" ItemStyle-Width="200">
                        <ItemTemplate>
                            <span  style="cursor: pointer; ">
                                <%# Eval("mubiaogangwei") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="提交时间" ItemStyle-Width="150">
                        <ItemTemplate>
                            <span  style="cursor: pointer;">
                                <%# Eval("tijiaoshijian") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="文件" ItemStyle-Width="150">
                        <ItemTemplate>
                            <div style="display: flex; justify-content: center; gap: 5px;">
                                <button class="btn-upload" onclick="showUploadModal('<%# Eval("id") %>', '<%# Eval("touliren") %>')">上传</button>
                                <%# string.IsNullOrEmpty(Eval("wenjian").ToString()) ? "" : 
                                    "<button class='btn-view' onclick='showFileViewModal(\"" + Eval("id") + "\", \"" + Eval("touliren") + "\")'>查看</button>" %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="备注" ItemStyle-Width="300">
                        <ItemTemplate>
                            <span  style="cursor: pointer; ">
                                <%# Eval("beizhu") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="面试批注" ItemStyle-Width="300">
                        <ItemTemplate>
                            <span  style="cursor: pointer;">
                                <%# Eval("mianshipizhu") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="150">
                        <ItemTemplate>
                            <div style="display: flex; justify-content: center; gap: 5px;">
                            <button class="btn-edit" onclick="showEditModal(
                                '<%# Eval("id") %>', 
                                '<%# Eval("touliren") %>', 
                                '<%# Eval("xueli") %>', 
                                '<%# Eval("mubiaogangwei") %>', 
                                '<%# Eval("tijiaoshijian") %>', 
                                '<%# Eval("beizhu") %>', 
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
                SelectCommand="SELECT id, touliren, xueli, mubiaogangwei, tijiaoshijian, wenjian, beizhu, zhuangtai FROM gongzi_jianliguanli WHERE gongsi = @gongsi AND zhuangtai = '通过' ORDER BY id DESC">
                <SelectParameters>
                    <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            
            
        </div>
        
        <!-- 文件上传模态框 -->
        <div id="uploadModal" class="modal">
            <div class="modal-content">
                <div class="modal-header">上传文件</div>
                <div class="modal-body">
                    <input type="hidden" id="currentRecordId" />
                    <input type="hidden" id="currentRecordName" />
                    
                    <div style="margin-bottom: 15px;">
                        <label>文件名称：</label>
                        <input type="text" id="fileName" placeholder="请输入文件名称" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" />
                    </div>
                    
                    <div style="margin-bottom: 15px;">
                        <label>选择文件：</label>
                        <input type="file" id="fileInput" multiple style="width: 100%; padding: 8px;" />
                        <div id="selectedFilesList" style="margin-top: 10px; padding: 10px; background: #f9f9f9; border-radius: 4px;"></div>
                    </div>
                    
                    <div style="margin-bottom: 15px;">
                        <label>上传进度：</label>
                        <progress id="uploadProgress" value="0" max="100" style="width: 100%;"></progress>
                        <span id="uploadProgressText">0%</span>
                    </div>
                </div>
                <div class="modal-footer">
                    <button onclick="hideUploadModal()" style="padding: 8px 16px; background: #f5f5f5; border: 1px solid #ddd; border-radius: 4px; cursor: pointer;">取消</button>
                    <button onclick="startUpload()" style="padding: 8px 16px; background: #5677fc; color: white; border: none; border-radius: 4px; cursor: pointer;">上传</button>
                </div>
            </div>
        </div>

       <!-- 批量编辑模态框 -->
        <div id="editAllModal" class="modal">
            <div class="modal-content">
                <div class="modal-header">编辑信息</div>
                <div class="modal-body">
                    <!-- 这里需要一个隐藏字段来存储记录ID -->
                    <input type="hidden" id="editRecordIdModal" />
            
                    <div style="margin-bottom: 15px;">
                        <label>投历人名：</label>
                        <input type="text" id="editToulirenModal" placeholder="请输入投历人名" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" />
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>学历：</label>
                        <input type="text" id="editXueliModal" placeholder="请输入学历" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" />
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>目标岗位：</label>
                        <input type="text" id="editMubiaogangweiModal" placeholder="请输入目标岗位" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" />
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>提交时间：</label>
                        <input type="date" id="editTijiaoshijianModal" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" />
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>备注：</label>
                        <textarea id="editBeizhuModal" placeholder="请输入备注" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px; height: 80px;"></textarea>
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>面试批注：</label>
                        <textarea id="editMianshipizhuModal" placeholder="请输入面试批注" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px; height: 80px;"></textarea>
                    </div>

                    <!-- 可以隐藏状态字段，但保留用于内部逻辑 -->
                    <div style="display: none;">
                        <label>状态：</label>
                        <select id="editZhuangtaiModal" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;">
                            <option value="通过">通过</option>
                        </select>
                    </div>
                </div>
                <div class="modal-footer">
                    <button onclick="hideEditAllModal()" style="padding: 8px 16px; background: #f5f5f5; border: 1px solid #ddd; border-radius: 4px; cursor: pointer;">取消</button>
                    <button onclick="saveAllEdit()" style="padding: 8px 16px; background: #5677fc; color: white; border: none; border-radius: 4px; cursor: pointer;">保存</button>
                </div>
            </div>
        </div>

        <!-- 添加记录模态框 -->
        <div id="addModal" class="modal">
            <div class="modal-content">
                <div class="modal-header">添加信息</div>
                <div class="modal-body">
                    <div style="margin-bottom: 15px;">
                        <label>投历人名：</label>
                        <input type="text" id="addToulirenModal" placeholder="请输入投历人名" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" required />
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>学历：</label>
                        <input type="text" id="addXueliModal" placeholder="请输入学历" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" />
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>目标岗位：</label>
                        <input type="text" id="addMubiaogangweiModal" placeholder="请输入目标岗位" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" />
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>提交时间：</label>
                        <input type="date" id="addTijiaoshijianModal" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" />
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>备注：</label>
                        <textarea id="addBeizhuModal" placeholder="请输入备注" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px; height: 80px;"></textarea>
                    </div>

                    <div style="margin-bottom: 15px;">
                        <label>面试批注：</label>
                        <textarea id="addMianshipizhuModal" placeholder="请输入面试批注" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px; height: 80px;"></textarea>
                    </div>

                    <!-- 可以隐藏状态字段，但保留用于内部逻辑 -->
                    <div style="display: none;">
                        <label>状态：</label>
                        <select id="addZhuangtaiModal" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;">
                            <option value="通过">通过</option>
                        </select>
                    </div>
                </div>
                <div class="modal-footer">
                    <button onclick="hideAddModal()" style="padding: 8px 16px; background: #f5f5f5; border: 1px solid #ddd; border-radius: 4px; cursor: pointer;">取消</button>
                    <button onclick="saveAdd()" style="padding: 8px 16px; background: #5677fc; color: white; border: none; border-radius: 4px; cursor: pointer;">保存</button>
                </div>
            </div>
        </div>
        
        <!-- 文件查看模态框 -->
        <div id="fileViewModal" class="modal">
            <div class="modal-content" style="max-width: 800px;">
                <div class="modal-header">文件列表</div>
                <div class="modal-body">
                    <div id="fileListContent" class="file-list">
                        <!-- 文件列表将通过AJAX动态加载 -->
                    </div>
                </div>
                <div class="modal-footer">
                    <button onclick="hideFileViewModal()" style="padding: 8px 16px; background: #5677fc; color: white; border: none; border-radius: 4px; cursor: pointer;">关闭</button>
                </div>
            </div>
        </div>
        
        <!-- 编辑模态框 -->
        <div id="editModal" class="modal">
            <div class="modal-content">
                <div class="modal-header">修改</div>
                <div class="modal-body">
                    <input type="hidden" id="editId" />
                    <input type="hidden" id="editField" />
                    <input type="hidden" id="editOldValue" />
                    
                    <div id="editInput">
                        <label>新值：</label>
                        <input type="text" id="editValue" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;" />
                    </div>
                    
                    <div id="editStatusSelect" style="display: none;">
                        <label>状态：</label>
                        <select id="statusSelect" style="width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px;">
                            <option value="待处理">提交审批</option>
                        </select>
                    </div>
                </div>
                <div class="modal-footer">
                    <button onclick="$('#editModal').hide()" style="padding: 8px 16px; background: #f5f5f5; border: 1px solid #ddd; border-radius: 4px; cursor: pointer;">取消</button>
                    <button onclick="saveEdit()" style="padding: 8px 16px; background: #5677fc; color: white; border: none; border-radius: 4px; cursor: pointer;">保存</button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>