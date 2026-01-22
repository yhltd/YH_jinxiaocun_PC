using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Web.Personnel
{
    public partial class jianlishenpi : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string[] str = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"] == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
                return;
            }

            // 处理各种操作请求
            ProcessAction(null);

            if (!IsPostBack)
            {
                str = (string[])Session["arr1"];
                if (str != null)
                {
                    // 权限控制
                    if (str.Length > 1 && str[1].ToString() == "0")
                    {
                        btnAdd.Enabled = false;
                        btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                    }
                }

                // 动态构建查询条件
                BuildSqlDataSource();

                BindGridView();
            }
        }

        private void BuildSqlDataSource()
        {
            string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";

            // 构建基础查询
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT id, touliren, xueli, mubiaogangwei, tijiaoshijian, wenjian, beizhu, zhuangtai ");
            sqlBuilder.Append("FROM gongzi_jianliguanli ");
            sqlBuilder.Append("WHERE gongsi = @gongsi ");

            // 修改这里：只查询状态为"待处理"的记录
            sqlBuilder.Append("AND zhuangtai = '待处理' ");  // 只查询待处理状态

            // 获取查询条件
            bool isSearching = Session["IsSearching"] != null && (bool)Session["IsSearching"];

            if (isSearching)
            {
                // 添加额外的查询条件
                string touliren = Session["SearchTouliren"] != null ? Session["SearchTouliren"].ToString() : "";
                string xueli = Session["SearchXueli"] != null ? Session["SearchXueli"].ToString() : "";
                string zhuangtai = Session["SearchZhuangtai"] != null ? Session["SearchZhuangtai"].ToString() : "";

                // 构建条件
                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(touliren))
                {
                    conditions.Add("touliren LIKE @touliren");
                }

                if (!string.IsNullOrEmpty(xueli))
                {
                    conditions.Add("xueli LIKE @xueli");
                }

                if (conditions.Count > 0)
                {
                    sqlBuilder.Append("AND (" + string.Join(" AND ", conditions) + ") ");
                }
            }

            sqlBuilder.Append("ORDER BY id DESC");

            // 设置 SqlDataSource
            SqlDataSource1.SelectCommand = sqlBuilder.ToString();

            // 清除现有参数
            SqlDataSource1.SelectParameters.Clear();

            // 添加公司参数
            SqlDataSource1.SelectParameters.Add("gongsi", gongsi);

            // 如果是查询模式，添加额外的参数
            if (isSearching)
            {
                string touliren = Session["SearchTouliren"] != null ? Session["SearchTouliren"].ToString() : "";
                string xueli = Session["SearchXueli"] != null ? Session["SearchXueli"].ToString() : "";

                if (!string.IsNullOrEmpty(touliren))
                {
                    SqlDataSource1.SelectParameters.Add("touliren", "%" + touliren + "%");
                }

                if (!string.IsNullOrEmpty(xueli))
                {
                    SqlDataSource1.SelectParameters.Add("xueli", "%" + xueli + "%");
                }

            }
        }

        private void ProcessAction(string action)
        {
            // 从查询字符串或Form中获取action
            string actionType = Request.QueryString["action"];
            if (string.IsNullOrEmpty(actionType))
            {
                actionType = Request.Form["action"];
            }

            if (string.IsNullOrEmpty(actionType))
                return;

            switch (actionType.ToLower())
            {
                case "add":
                    AddRecord();
                    break;
                case "edit":
                    EditRecord();
                    break;
                case "edital":
                    EditAllFields();
                    break;
                case "checkfile":  // 新增：检查文件
                    CheckFileExists();
                    break;
                case "delete":
                    DeleteRecord();
                    break;
                case "getfiles":
                    GetFiles();
                    break;
                case "deletefile":
                    DeleteFile();
                    break;
                case "upload":
                    UploadFiles();
                    break;
                case "export":
                    ExportToExcel();
                    break;
                case "savefileurls":
                    SaveFileUrls();
                    break;
                case "removefile":
                    RemoveFileFromDatabase();
                    break;
                case "search":
                    SearchRecords();
                    break;
                case "resetsearch":
                    ResetSearch();
                    break;
            }
        }

        private void BindGridView()
        {
            GridView1.DataBind();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        // 查询记录
        private void SearchRecords()
        {
            // 获取查询条件
            string touliren = Request.Form["touliren"] ?? "";
            string xueli = Request.Form["xueli"] ?? "";
            string zhuangtai = Request.Form["zhuangtai"] ?? "";

            // 存储查询条件到Session
            Session["SearchTouliren"] = touliren;
            Session["SearchXueli"] = xueli;
            Session["SearchZhuangtai"] = zhuangtai;

            // 设置标志表示正在查询
            Session["IsSearching"] = true;

            // 返回成功响应
            Response.Write("{\"success\": true, \"message\": \"查询条件已设置\"}");
            Response.End();
        }

        // 重置查询
        private void ResetSearch()
        {
            // 清除查询条件
            Session["SearchTouliren"] = null;
            Session["SearchXueli"] = null;
            Session["SearchZhuangtai"] = null;
            Session["IsSearching"] = false;

            // 返回成功响应
            Response.Write("{\"success\": true, \"message\": \"查询条件已重置\"}");
            Response.End();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // 可以在这里添加行数据绑定的额外处理
        }

        // 添加记录
        private void AddRecord()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                if (Session["gongsi"] == null)
                {
                    responseMessage = "请登录！";
                    isSuccess = false;
                }
                else
                {
                    string gongsi = Session["gongsi"].ToString();
                    string conString = ConfigurationManager.AppSettings["yao"];

                    // 从Form获取参数
                    string touliren = Request.Form["addTouliren"] ?? "";
                    string xueli = Request.Form["addXueli"] ?? "";
                    string mubiaogangwei = Request.Form["addMubiaogangwei"] ?? "";
                    string tijiaoshijian = Request.Form["addTijiaoshijian"] ?? "";
                    string beizhu = Request.Form["addBeizhu"] ?? "";
                    string zhuangtai = Request.Form["addZhuangtai"] ?? "待处理";

                    // 验证必填字段
                    if (string.IsNullOrEmpty(touliren))
                    {
                        responseMessage = "投历人名不能为空！";
                        isSuccess = false;
                    }
                    else
                    {
                        using (conn = new SqlConnection(conString))
                        {
                            string sql = @"INSERT INTO gongzi_jianliguanli 
                                  (gongsi, touliren, xueli, mubiaogangwei, tijiaoshijian, beizhu, zhuangtai, wenjian) 
                                  VALUES(@gongsi, @touliren, @xueli, @mubiaogangwei, @tijiaoshijian, @beizhu, @zhuangtai, '')";

                            cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@gongsi", gongsi);
                            cmd.Parameters.AddWithValue("@touliren", touliren.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@xueli", xueli.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@mubiaogangwei", mubiaogangwei.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@tijiaoshijian", tijiaoshijian.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@beizhu", beizhu.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@zhuangtai", zhuangtai.Replace("'", "''"));

                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            conn.Close();

                            if (result > 0)
                            {
                                responseMessage = "添加成功！";
                                isSuccess = true;
                            }
                            else
                            {
                                responseMessage = "添加失败！";
                                isSuccess = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "添加失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }

        private void EditRecord()
        {
            // 从Form或QueryString获取参数
            string id = Request.Form["hiddenEditId"] ?? Request.QueryString["id"];
            string field = Request.Form["hiddenEditField"] ?? Request.QueryString["field"];
            string value = Request.Form["hiddenEditValue"] ?? Request.QueryString["value"];

            // 如果是状态字段，从statusSelect获取值
            if (field == "zhuangtai")
            {
                value = Request.Form["statusSelect"] ?? Request.QueryString["statusSelect"];
            }

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(field))
            {
                Response.Write("<script>alert('参数错误！');</script>");
                return;
            }

            string conString = ConfigurationManager.AppSettings["yao"];

            try
            {
                using (conn = new SqlConnection(conString))
                {
                    // 防止SQL注入
                    string safeValue = (value ?? "").Replace("'", "''");
                    string sql = string.Format("UPDATE gongzi_jianliguanli SET {0} = @value WHERE id = @id", field);

                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@value", safeValue);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Write("<script>alert('更新成功！'); location.href='jianli.aspx';</script>");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('更新失败：" + ex.Message.Replace("'", "\\'") + "'); history.back();</script>");
                Response.End();
            }
        }

        // 检查文件是否存在（供AJAX调用）
        private void CheckFileExists()
        {
            // 从Form获取id参数
            string id = Request.Form["id"];
            if (string.IsNullOrEmpty(id))
            {
                // 尝试从QueryString获取
                id = Request.QueryString["id"];
                if (string.IsNullOrEmpty(id))
                {
                    Response.Write("false");
                    Response.End();
                    return;
                }
            }

            string conString = ConfigurationManager.AppSettings["yao"];

            try
            {
                using (conn = new SqlConnection(conString))
                {
                    string sql = "SELECT wenjian FROM gongzi_jianliguanli WHERE id = @id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();

                    bool hasFiles = (result != null && !string.IsNullOrEmpty(result.ToString()));
                    Response.Write(hasFiles ? "true" : "false");
                    Response.End();
                }
            }
            catch
            {
                Response.Write("false");
                Response.End();
            }
        }

        // 批量编辑记录 - 编辑所有字段
        private void EditAllFields()
        {
            string id = Request.Form["editRecordId"];
            string touliren = Request.Form["editTouliren"];
            string xueli = Request.Form["editXueli"];
            string mubiaogangwei = Request.Form["editMubiaogangwei"];
            string tijiaoshijian = Request.Form["editTijiaoshijian"];
            string beizhu = Request.Form["editBeizhu"];
            string zhuangtai = Request.Form["editZhuangtai"];

            if (string.IsNullOrEmpty(id))
            {
                Response.Write("<script>alert('参数错误！');</script>");
                return;
            }

            string conString = ConfigurationManager.AppSettings["yao"];

            try
            {
                using (conn = new SqlConnection(conString))
                {
                    string sql = @"UPDATE gongzi_jianliguanli SET 
                           touliren = @touliren, 
                           xueli = @xueli, 
                           mubiaogangwei = @mubiaogangwei, 
                           tijiaoshijian = @tijiaoshijian, 
                           beizhu = @beizhu, 
                           zhuangtai = @zhuangtai 
                           WHERE id = @id";

                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@touliren", (touliren ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@xueli", (xueli ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@mubiaogangwei", (mubiaogangwei ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@tijiaoshijian", (tijiaoshijian ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@beizhu", (beizhu ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@zhuangtai", (zhuangtai ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Write("<script>alert('更新成功！'); location.href='jianli.aspx';</script>");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('更新失败：" + ex.Message.Replace("'", "\\'") + "'); history.back();</script>");
                Response.End();
            }
        }

        // 删除记录
        private void DeleteRecord()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                // 从Form或QueryString获取id
                string id = Request.Form["id"] ?? Request.QueryString["id"];

                if (string.IsNullOrEmpty(id))
                {
                    id = Request.Form["deleteId"] ?? Request.QueryString["deleteId"];
                }

                if (string.IsNullOrEmpty(id))
                {
                    responseMessage = "参数错误！";
                    isSuccess = false;
                }
                else if (CheckFileExists(Convert.ToInt32(id)))
                {
                    responseMessage = "该记录关联了文件，请先删除所有文件后再删除记录。";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        string sql = "DELETE FROM gongzi_jianliguanli WHERE id = @id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            conn.Close();

                            if (result > 0)
                            {
                                responseMessage = "删除成功！";
                                isSuccess = true;
                            }
                            else
                            {
                                responseMessage = "删除失败：记录不存在！";
                                isSuccess = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "删除失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一在 finally 块中返回响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\"}";
                Response.Write(jsonResponse);
                Response.End(); // 在这里使用 Response.End()
            }
        }

        // 检查文件是否存在
        private bool CheckFileExists(int id)
        {
            string conString = ConfigurationManager.AppSettings["yao"];

            try
            {
                using (conn = new SqlConnection(conString))
                {
                    string sql = "SELECT wenjian FROM gongzi_jianliguanli WHERE id = @id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();

                    return (result != null && !string.IsNullOrEmpty(result.ToString()));
                }
            }
            catch
            {
                return false;
            }
        }

        // 获取文件列表
        private void GetFiles()
        {
            string id = Request.Form["fileRecordId"];
            if (string.IsNullOrEmpty(id))
            {
                Response.Write("<script>alert('参数错误！');</script>");
                return;
            }

            List<FileInfo> fileList = new List<FileInfo>();
            string conString = ConfigurationManager.AppSettings["yao"];

            try
            {
                using (conn = new SqlConnection(conString))
                {
                    string sql = "SELECT wenjian FROM gongzi_jianliguanli WHERE id = @id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string files = reader["wenjian"] != null ? reader["wenjian"].ToString() : "";
                        if (!string.IsNullOrEmpty(files))
                        {
                            string[] fileArray = files.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string fileUrl in fileArray)
                            {
                                string fileName = Path.GetFileName(fileUrl.Trim());
                                fileList.Add(new FileInfo
                                {
                                    name = fileName,
                                    url = fileUrl.Trim()
                                });
                            }
                        }
                    }
                    reader.Close();
                    conn.Close();
                }

                // 构建HTML响应
                StringBuilder html = new StringBuilder();
                if (fileList.Count > 0)
                {
                    foreach (var file in fileList)
                    {
                        html.AppendFormat("<div class='file-item'>");
                        html.AppendFormat("<div style='display: flex; justify-content: space-between; align-items: center;'>");
                        html.AppendFormat("<div>");
                        html.AppendFormat("<strong>{0}</strong><br/>", file.name);
                        html.AppendFormat("<small>{0}</small>", file.url);
                        html.AppendFormat("</div>");
                        html.AppendFormat("<div>");
                        html.AppendFormat("<button class='btn-view-file' onclick=\"previewFile('{0}')\" style='background: #2196F3; color: white; border: none; padding: 5px 10px; margin-right: 5px; cursor: pointer;'>预览</button>", file.url);
                        html.AppendFormat("<button class='btn-delete-file' onclick=\"deleteFile({0}, '{1}')\" style='background: #ff4444; color: white; border: none; padding: 5px 10px; cursor: pointer;'>删除</button>", id, file.url);
                        html.AppendFormat("</div>");
                        html.AppendFormat("</div>");
                        html.AppendFormat("</div>");
                    }
                }
                else
                {
                    html.Append("<div style='padding: 20px; text-align: center; color: #999;'>暂无文件</div>");
                }

                Response.Write(html.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                Response.End();
            }
        }

        // 删除文件
        private void DeleteFile()
        {
            string id = Request.Form["deleteFileRecordId"];
            string fileUrl = Request.Form["deleteFileUrl"];

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(fileUrl))
            {
                Response.Write("<script>alert('参数错误！');</script>");
                return;
            }

            string conString = ConfigurationManager.AppSettings["yao"];

            try
            {
                using (conn = new SqlConnection(conString))
                {
                    // 获取当前文件列表
                    string sql = "SELECT wenjian FROM gongzi_jianliguanli WHERE id = @id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    string currentFiles = "";
                    if (reader.Read())
                    {
                        currentFiles = reader["wenjian"] != null ? reader["wenjian"].ToString() : "";
                    }
                    reader.Close();

                    // 移除指定的文件
                    string[] fileArray = currentFiles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> newFileList = new List<string>();
                    foreach (string file in fileArray)
                    {
                        if (file.Trim() != fileUrl.Trim())
                        {
                            newFileList.Add(file.Trim());
                        }
                    }

                    string newFiles = string.Join(",", newFileList.ToArray());

                    // 更新数据库
                    sql = "UPDATE gongzi_jianliguanli SET wenjian = @wenjian WHERE id = @id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@wenjian", newFiles);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    Response.Write("<script>alert('文件删除成功！'); location.href='jianli.aspx';</script>");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('删除失败：" + ex.Message.Replace("'", "\\'") + "'); history.back();</script>");
                Response.End();
            }
        }

        // 上传文件
        private void UploadFiles()
        {
            string recordId = Request.Form["uploadRecordId"];
            string fileName = Request.Form["uploadFileName"];
            string recordName = Request.Form["uploadRecordName"];

            if (string.IsNullOrEmpty(recordId))
            {
                Response.Write("<script>alert('记录ID不能为空！');</script>");
                return;
            }

            HttpFileCollection files = Request.Files;
            if (files.Count == 0)
            {
                Response.Write("<script>alert('没有选择文件！');</script>");
                return;
            }

            List<string> uploadedFiles = new List<string>();

            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];

                    if (file.ContentLength > 0)
                    {
                        // 构建最终文件名
                        string finalFileName;
                        if (string.IsNullOrEmpty(fileName))
                        {
                            finalFileName = string.Format("简历_{0}_{1:yyyyMMddHHmmss}_{2}{3}",
                                recordName,
                                DateTime.Now,
                                i + 1,
                                Path.GetExtension(file.FileName));
                        }
                        else
                        {
                            finalFileName = string.Format("{0}_{1}{2}",
                                fileName,
                                i + 1,
                                Path.GetExtension(file.FileName));
                        }

                        // 保存文件到服务器
                        string uploadPath = Server.MapPath("~/uploads/jianli/");
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        string savePath = Path.Combine(uploadPath, finalFileName);
                        file.SaveAs(savePath);

                        // 构建文件URL
                        string fileUrl = string.Format("/uploads/jianli/{0}", finalFileName);
                        uploadedFiles.Add(fileUrl);
                    }
                }

                // 保存到数据库
                SaveFilesToDatabase(Convert.ToInt32(recordId), uploadedFiles);

                Response.Write("<script>alert('上传成功！'); location.href='jianli.aspx';</script>");
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('上传失败：" + ex.Message.Replace("'", "\\'") + "'); history.back();</script>");
                Response.End();
            }
        }

        private void SaveFilesToDatabase(int recordId, List<string> files)
        {
            if (files.Count == 0) return;

            string conString = ConfigurationManager.AppSettings["yao"];

            using (conn = new SqlConnection(conString))
            {
                // 获取现有文件
                string sql = "SELECT wenjian FROM gongzi_jianliguanli WHERE id = @id";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", recordId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string existingFiles = "";
                if (reader.Read())
                {
                    existingFiles = reader["wenjian"] != null ? reader["wenjian"].ToString() : "";
                }
                reader.Close();

                // 合并文件列表
                List<string> existingArray = new List<string>();
                if (!string.IsNullOrEmpty(existingFiles))
                {
                    string[] temp = existingFiles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in temp)
                    {
                        existingArray.Add(item.Trim());
                    }
                }

                existingArray.AddRange(files);

                // 去重
                List<string> uniqueFiles = new List<string>();
                foreach (string file in existingArray)
                {
                    if (!uniqueFiles.Contains(file))
                    {
                        uniqueFiles.Add(file);
                    }
                }

                string newFiles = string.Join(",", uniqueFiles.ToArray());

                // 更新数据库
                sql = "UPDATE gongzi_jianliguanli SET wenjian = @wenjian WHERE id = @id";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@wenjian", newFiles);
                cmd.Parameters.AddWithValue("@id", recordId);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        // 保存文件URL到数据库
        private void SaveFileUrls()
        {
            string id = Request.Form["id"];
            string fileUrls = Request.Form["fileUrls"];

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(fileUrls))
            {
                Response.Write("{\"success\": false, \"message\": \"参数错误\"}");
                Response.End();
                return;
            }

            string conString = ConfigurationManager.AppSettings["yao"];

            try
            {
                using (conn = new SqlConnection(conString))
                {
                    // 获取现有文件
                    string sql = "SELECT wenjian FROM gongzi_jianliguanli WHERE id = @id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    string existingFiles = "";
                    if (reader.Read())
                    {
                        existingFiles = reader["wenjian"] != null ? reader["wenjian"].ToString() : "";
                    }
                    reader.Close();

                    // 合并文件列表
                    List<string> existingArray = new List<string>();
                    if (!string.IsNullOrEmpty(existingFiles))
                    {
                        string[] temp = existingFiles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string item in temp)
                        {
                            existingArray.Add(item.Trim());
                        }
                    }

                    // 添加新文件
                    string[] newFiles = fileUrls.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    existingArray.AddRange(newFiles);

                    // 去重
                    List<string> uniqueFiles = new List<string>();
                    foreach (string file in existingArray)
                    {
                        if (!uniqueFiles.Contains(file))
                        {
                            uniqueFiles.Add(file);
                        }
                    }

                    string newFilesString = string.Join(",", uniqueFiles.ToArray());

                    // 更新数据库
                    sql = "UPDATE gongzi_jianliguanli SET wenjian = @wenjian WHERE id = @id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@wenjian", newFilesString);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    Response.Write("{\"success\": true, \"message\": \"保存成功\"}");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write("{\"success\": false, \"message\": \"保存失败: " + ex.Message.Replace("\"", "\\\"") + "\"}");
                Response.End();
            }
        }

        // 从数据库移除文件
        private void RemoveFileFromDatabase()
        {
            string id = Request.Form["id"];
            string fileUrl = Request.Form["fileUrl"];

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(fileUrl))
            {
                Response.Write("{\"success\": false, \"message\": \"参数错误\"}");
                Response.End();
                return;
            }

            string conString = ConfigurationManager.AppSettings["yao"];

            try
            {
                using (conn = new SqlConnection(conString))
                {
                    // 获取当前文件列表
                    string sql = "SELECT wenjian FROM gongzi_jianliguanli WHERE id = @id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    string currentFiles = "";
                    if (reader.Read())
                    {
                        currentFiles = reader["wenjian"] != null ? reader["wenjian"].ToString() : "";
                    }
                    reader.Close();

                    // 移除指定的文件
                    string[] fileArray = currentFiles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> newFileList = new List<string>();
                    foreach (string file in fileArray)
                    {
                        if (file.Trim() != fileUrl.Trim())
                        {
                            newFileList.Add(file.Trim());
                        }
                    }

                    string newFiles = string.Join(",", newFileList.ToArray());

                    // 更新数据库
                    sql = "UPDATE gongzi_jianliguanli SET wenjian = @wenjian WHERE id = @id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@wenjian", newFiles);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    Response.Write("{\"success\": true, \"message\": \"删除成功\"}");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write("{\"success\": false, \"message\": \"删除失败: " + ex.Message.Replace("\"", "\\\"") + "\"}");
                Response.End();
            }
        }

        // 导出Excel功能
        private void ExportToExcel()
        {
            if (Session["gongsi"] == null)
            {
                Response.Write("<script>alert('请登录！');</script>");
                return;
            }

            string gongsi = Session["gongsi"].ToString();
            string conString = ConfigurationManager.AppSettings["yao"];

            using (conn = new SqlConnection(conString))
            {
                // 修改这里：只导出状态为"待处理"的记录
                string sql = @"SELECT touliren, xueli, mubiaogangwei, tijiaoshijian, wenjian, beizhu, zhuangtai 
                       FROM gongzi_jianliguanli 
                       WHERE gongsi = @gongsi 
                       AND zhuangtai = '待处理'
                       ORDER BY id DESC";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 导出Excel
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=简历管理表.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    // 添加表头
                    hw.Write("<table border='1'><tr>");
                    hw.Write("<td>投历人名</td>");
                    hw.Write("<td>学历</td>");
                    hw.Write("<td>目标岗位</td>");
                    hw.Write("<td>提交时间</td>");
                    hw.Write("<td>文件</td>");
                    hw.Write("<td>备注</td>");
                    hw.Write("<td>状态</td>");
                    hw.Write("</tr>");

                    // 添加数据行
                    foreach (DataRow row in dt.Rows)
                    {
                        hw.Write("<tr>");
                        hw.Write("<td>" + (row["touliren"] != null ? row["touliren"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["xueli"] != null ? row["xueli"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["mubiaogangwei"] != null ? row["mubiaogangwei"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["tijiaoshijian"] != null ? row["tijiaoshijian"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["wenjian"] != null ? row["wenjian"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["beizhu"] != null ? row["beizhu"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["zhuangtai"] != null ? row["zhuangtai"].ToString() : "") + "</td>");
                        hw.Write("</tr>");
                    }

                    hw.Write("</table>");
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }

        public class FileInfo
        {
            public string name { get; set; }
            public string url { get; set; }
        }
    }
}