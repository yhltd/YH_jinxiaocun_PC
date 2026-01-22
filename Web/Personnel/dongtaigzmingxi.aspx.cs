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
using System.Text.RegularExpressions;

namespace Web.Personnel
{
    public partial class dongtaigzmingxi : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string[] str = null;
        private const string TitleSeparator = "|||";
        private const int TitleConfigId = 1;
        private int pageSize = 100;
        private int currentPage = 1;
        private int totalRecords = 0;
        private int totalPages = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"] == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
                return;
            }

            // 处理各种操作请求
            ProcessAction();

            if (!IsPostBack)
            {
                str = (string[])Session["arr1"];
                if (str != null)
                {
                    // 权限控制
                    if (str.Length > 1 && str[1].ToString() == "0")
                    {
                        // 可以在这里添加权限控制
                    }
                }

                // 初始化分页
                currentPage = 1;
                LoadPageData();
                BindDynamicHeaders();
            }
        }

        private void ProcessAction()
        {
            string action = Request.Form["action"];
            if (string.IsNullOrEmpty(action))
                return;

            switch (action.ToLower())
            {
                case "loadtitleconfig":
                    LoadTitleConfig();
                    break;
                case "savetitleconfig":
                    SaveTitleConfig();
                    break;
                case "loadformulalist":
                    LoadFormulaList();
                    break;
                case "saveformula":
                    SaveFormula();
                    break;
                case "deleteformula":
                    DeleteFormula();
                    break;
                case "addrow":
                    AddRow();
                    break;
                case "deleterow":
                    DeleteRow();
                    break;
                case "editcell":
                    EditCell();
                    break;
                case "calculateall":
                    CalculateAllData();
                    break;
                case "calculateformulaonly": 
                    CalculateFormulaOnly();
                    break;
            }
        }

        private void LoadPageData()
        {
            string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";

            // 加载标题配置
            var titleConfig = LoadTitleConfigFromDb(gongsi);
            var dynamicTitles = ParseTitleConfig(titleConfig);

            // 计算分页
            totalRecords = GetTotalRecords(gongsi);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (currentPage < 1) currentPage = 1;
            if (currentPage > totalPages) currentPage = totalPages;

            // 加载当前页数据
            var data = LoadPageDataFromDb(gongsi, currentPage, pageSize, dynamicTitles);
            
            rptData.DataSource = data;
            rptData.DataBind();

            // 更新分页显示
            lblCurrentPage.Text = currentPage.ToString();
            lblTotalPages.Text = totalPages.ToString();

            // 设置分页按钮状态
            btnFirst.Enabled = currentPage > 1;
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnLast.Enabled = currentPage < totalPages;
        }

        private void BindDynamicHeaders()
        {
            string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
            var titleConfig = LoadTitleConfigFromDb(gongsi);
            var dynamicTitles = ParseTitleConfig(titleConfig);

            rptDynamicHeaders.DataSource = dynamicTitles.Select(t => t.Text);
            rptDynamicHeaders.DataBind();
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Dictionary<string, object> rowData = (Dictionary<string, object>)e.Item.DataItem;

                // 找到Literal控件
                Literal ltlDeleteButton = (Literal)e.Item.FindControl("ltlDeleteButton");
                if (ltlDeleteButton != null && rowData.ContainsKey("id"))
                {
                    string id = "";
                    object idValue = rowData["id"];
                    if (idValue != null)
                    {
                        id = idValue.ToString();
                    }

                    int index = e.Item.ItemIndex + 1;

                    // 构建HTML按钮
                    string buttonHtml = string.Format(
                        "<button onclick=\"deleteRow('{0}', '{1}')\" class=\"btn-delete\">删除</button>",
                        id, index);

                    ltlDeleteButton.Text = buttonHtml;
                }

                // 处理内部Repeater的数据绑定 - 这是内容显示的关键部分
                var rptRowData = (Repeater)e.Item.FindControl("rptRowData");
                if (rptRowData != null)
                {
                    string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                    var titleConfig = LoadTitleConfigFromDb(gongsi);
                    var dynamicTitles = ParseTitleConfig(titleConfig);

                    var rowValues = new List<string>();

                    // 从rowData中获取字段值
                    for (int i = 0; i < dynamicTitles.Count; i++)
                    {
                        string columnName = dynamicTitles[i].ColumnName;
                        string value = "";
                        
                        if (rowData.ContainsKey(columnName))
                        {
                            object valueObj = rowData[columnName];
                            if (valueObj != null)
                            {
                                value = valueObj.ToString();
                            }
                        }
                        
                        rowValues.Add(value);
                    }

                    rptRowData.DataSource = rowValues;
                    rptRowData.DataBind();
                }
            }
        }

        // 分页按钮事件
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadPageData();
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadPageData();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPageData();
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadPageData();
        }

        // 加载标题配置
        private void LoadTitleConfig()
        {
            string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
            var titleConfig = LoadTitleConfigFromDb(gongsi);
            var dynamicTitles = ParseTitleConfig(titleConfig);

            var fields = dynamicTitles.Select(t => t.Text).ToList();
            if (fields.Count == 0)
            {
                fields = new List<string> { "字段1" };
            }

            Response.ContentType = "application/json";
            Response.Write(new JavaScriptSerializer().Serialize(new
            {
                success = true,
                fields = fields
            }));
            Response.End();
        }

        // 保存标题配置
        private void SaveTitleConfig()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                string fieldsJson = Request.Form["fields"] ?? "[]";
                var fields = new JavaScriptSerializer().Deserialize<List<string>>(fieldsJson);

                if (fields.Count == 0)
                {
                    responseMessage = "请至少输入一个字段";
                    isSuccess = false;
                    return;
                }

                string titleStr = string.Join(TitleSeparator, fields);
                string conString = ConfigurationManager.AppSettings["yao"];

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    // 检查标题配置是否存在
                    string checkSql = "SELECT COUNT(*) FROM gongzi_dongtaimingxi WHERE id = @id AND gongsi = @gongsi";
                    SqlCommand cmd = new SqlCommand(checkSql, conn);
                    cmd.Parameters.AddWithValue("@id", TitleConfigId);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    string sql;
                    if (count > 0)
                    {
                        // 更新
                        sql = "UPDATE gongzi_dongtaimingxi SET name = @name WHERE id = @id AND gongsi = @gongsi";
                    }
                    else
                    {
                        // 插入
                        sql = "INSERT INTO gongzi_dongtaimingxi (id, gongsi, name) VALUES (@id, @gongsi, @name)";
                    }

                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", TitleConfigId);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);
                    cmd.Parameters.AddWithValue("@name", titleStr);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // 如果列数减少，截断现有数据
                    var oldTitleConfig = LoadTitleConfigFromDb(gongsi);
                    var oldDynamicTitles = ParseTitleConfig(oldTitleConfig);
                    var newFieldCount = fields.Count;

                    if (oldDynamicTitles.Count > newFieldCount)
                    {
                        TruncateExistingData(gongsi, oldDynamicTitles.Count, newFieldCount);
                    }

                    responseMessage = "保存成功";
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                responseMessage = "保存失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }

        // 加载公式列表
        private void LoadFormulaList()
        {
            string responseMessage = "";
            bool isSuccess = false;
            List<Dictionary<string, object>> formulas = null;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                string conString = ConfigurationManager.AppSettings["yao"];

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = "SELECT id, zhuziduan, gongshi FROM gongzi_dongtaigongshi WHERE gongsi = @gongsi ORDER BY id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    formulas = new List<Dictionary<string, object>>();
                    while (reader.Read())
                    {
                        formulas.Add(new Dictionary<string, object>
                {
                    { "id", reader["id"] != DBNull.Value ? reader["id"] : null },
                    { "zhuziduan", reader["zhuziduan"] != DBNull.Value ? reader["zhuziduan"] : "" },
                    { "gongshi", reader["gongshi"] != DBNull.Value ? reader["gongshi"] : "" }
                });
                    }
                    reader.Close();
                    conn.Close();

                    responseMessage = "加载成功";
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                responseMessage = "加载失败：" + ex.Message;
                isSuccess = false;
                formulas = new List<Dictionary<string, object>>(); // 确保不会为null
            }
            finally
            {
                // 统一返回JSON响应
                Response.ContentType = "application/json";

                if (isSuccess)
                {
                    Response.Write(new JavaScriptSerializer().Serialize(new
                    {
                        success = true,
                        formulas = formulas ?? new List<Dictionary<string, object>>(), // 确保不为null
                        message = responseMessage
                    }));
                }
                else
                {
                    Response.Write(new JavaScriptSerializer().Serialize(new
                    {
                        success = false,
                        message = responseMessage
                    }));
                }

                Response.End();
            }
        }

        // 保存公式
        private void SaveFormula()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                string targetField = Request.Form["targetField"] ?? "";
                string expression = Request.Form["expression"] ?? "";

                if (string.IsNullOrEmpty(targetField))
                {
                    responseMessage = "请选择目标字段";
                    isSuccess = false;
                    return;
                }

                if (string.IsNullOrEmpty(expression))
                {
                    responseMessage = "请输入计算公式";
                    isSuccess = false;
                    return;
                }

                string conString = ConfigurationManager.AppSettings["yao"];

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    // 检查是否已存在相同的目标字段公式
                    string checkSql = "SELECT id FROM gongzi_dongtaigongshi WHERE zhuziduan = @zhuziduan AND gongsi = @gongsi";
                    SqlCommand cmd = new SqlCommand(checkSql, conn);
                    cmd.Parameters.AddWithValue("@zhuziduan", targetField);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);

                    conn.Open();
                    var existingId = cmd.ExecuteScalar();
                    conn.Close();

                    string sql;
                    if (existingId != null)
                    {
                        // 更新
                        sql = "UPDATE gongzi_dongtaigongshi SET gongshi = @gongshi WHERE id = @id";
                        cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@gongshi", expression);
                        cmd.Parameters.AddWithValue("@id", existingId);
                    }
                    else
                    {
                        // 插入
                        sql = "INSERT INTO gongzi_dongtaigongshi (zhuziduan, gongshi, gongsi) VALUES (@zhuziduan, @gongshi, @gongsi)";
                        cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@zhuziduan", targetField);
                        cmd.Parameters.AddWithValue("@gongshi", expression);
                        cmd.Parameters.AddWithValue("@gongsi", gongsi);
                    }

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        responseMessage = "保存成功";
                        isSuccess = true;
                    }
                    else
                    {
                        responseMessage = "保存失败：未影响任何记录";
                        isSuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "保存失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }

        // 删除公式
        private void DeleteFormula()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                string formulaId = Request.Form["formulaId"] ?? "";

                if (string.IsNullOrEmpty(formulaId))
                {
                    responseMessage = "参数错误";
                    isSuccess = false;
                    return;
                }

                string conString = ConfigurationManager.AppSettings["yao"];

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = "DELETE FROM gongzi_dongtaigongshi WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(formulaId));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        responseMessage = "删除成功";
                        isSuccess = true;
                    }
                    else
                    {
                        responseMessage = "删除失败：公式不存在";
                        isSuccess = false;
                    }
                }
            }
            catch (FormatException)
            {
                responseMessage = "参数格式错误：ID必须是数字";
                isSuccess = false;
            }
            catch (Exception ex)
            {
                responseMessage = "删除失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }

        // 添加一行数据
        private void AddRow()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";

                if (string.IsNullOrEmpty(gongsi))
                {
                    responseMessage = "请先登录";
                    isSuccess = false;
                    return;
                }

                string conString = ConfigurationManager.AppSettings["yao"];

                // 获取标题配置
                var titleConfig = LoadTitleConfigFromDb(gongsi);
                var dynamicTitles = ParseTitleConfig(titleConfig);

                // 创建空数据
                var emptyFields = new List<string>();
                for (int i = 0; i < dynamicTitles.Count; i++)
                {
                    emptyFields.Add("");
                }
                string emptyData = string.Join(TitleSeparator, emptyFields);

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = "INSERT INTO gongzi_dongtaimingxi (gongsi, name) VALUES (@gongsi, @name)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);
                    cmd.Parameters.AddWithValue("@name", emptyData);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        responseMessage = "添加成功";
                        isSuccess = true;
                    }
                    else
                    {
                        responseMessage = "添加失败：未能插入数据";
                        isSuccess = false;
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
                // 统一返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }

        // 删除数据行 - 修正后的方法
        private void DeleteRow()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                string id = Request.Form["id"] ?? "";

                if (string.IsNullOrEmpty(id))
                {
                    responseMessage = "参数错误！";
                    isSuccess = false;
                }
                else
                {
                    string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                    string conString = ConfigurationManager.AppSettings["yao"];

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        string sql = "DELETE FROM gongzi_dongtaimingxi WHERE id = @id AND gongsi = @gongsi";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            cmd.Parameters.AddWithValue("@gongsi", gongsi);

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
                Response.End();
            }
        }

        // 编辑单元格
        private void EditCell()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                string id = Request.Form["id"] ?? "";
                string columnIndexStr = Request.Form["columnIndex"] ?? "";
                string newValue = Request.Form["newValue"] ?? "";

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(columnIndexStr))
                {
                    responseMessage = "参数错误";
                    isSuccess = false;
                    return;
                }

                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";

                if (string.IsNullOrEmpty(gongsi))
                {
                    responseMessage = "请先登录";
                    isSuccess = false;
                    return;
                }

                // 转换为整数
                int recordId = Convert.ToInt32(id);
                int columnIndex = Convert.ToInt32(columnIndexStr);

                // 验证列索引
                if (columnIndex < 0)
                {
                    responseMessage = "列索引不能小于0";
                    isSuccess = false;
                    return;
                }

                string conString = ConfigurationManager.AppSettings["yao"];

                // 获取当前行数据
                var currentRow = GetRowData(gongsi, recordId);
                if (currentRow == null)
                {
                    responseMessage = "数据不存在";
                    isSuccess = false;
                    return;
                }

                // 解析数据
                var dataArray = new List<string>();
                if (!string.IsNullOrEmpty(currentRow.Name))
                {
                    dataArray = currentRow.Name.Split(new string[] { TitleSeparator }, StringSplitOptions.None).ToList();
                }

                // 确保数组长度足够
                while (dataArray.Count <= columnIndex)
                {
                    dataArray.Add("");
                }

                // 更新值
                dataArray[columnIndex] = newValue;
                string updatedName = string.Join(TitleSeparator, dataArray);

                // 更新数据库
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = "UPDATE gongzi_dongtaimingxi SET name = @name WHERE id = @id AND gongsi = @gongsi";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", updatedName);
                    cmd.Parameters.AddWithValue("@id", recordId);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        responseMessage = "修改成功";
                        isSuccess = true;
                    }
                    else
                    {
                        responseMessage = "修改失败：未找到对应记录";
                        isSuccess = false;
                    }
                }
            }
            catch (FormatException)
            {
                responseMessage = "参数格式错误：ID和列索引必须是数字";
                isSuccess = false;
            }
            catch (Exception ex)
            {
                responseMessage = "修改失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }

        // 计算所有数据
        private void CalculateAllData()
        {
            string responseMessage = "";
            bool isSuccess = false;
            int processedCount = 0;
            int totalRows = 0;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
        
                if (string.IsNullOrEmpty(gongsi))
                {
                    responseMessage = "请先登录";
                    isSuccess = false;
                    return;
                }

                // 获取标题配置
                var titleConfig = LoadTitleConfigFromDb(gongsi);
                var dynamicTitles = ParseTitleConfig(titleConfig);

                // 获取所有公式
                var formulas = LoadFormulasFromDb(gongsi);
        
                if (formulas.Count == 0)
                {
                    responseMessage = "没有需要计算的公式";
                    isSuccess = true;
                    return;
                }

                // 获取所有数据行（排除标题配置行）
                var allRows = GetAllDataRows(gongsi);
                totalRows = allRows.Count(r => r.Id != TitleConfigId);
        
                if (totalRows == 0)
                {
                    responseMessage = "没有需要计算的数据";
                    isSuccess = true;
                    return;
                }

                foreach (var row in allRows)
                {
                    if (row.Id == TitleConfigId) continue;

                    try
                    {
                        // 解析数据
                        var dataArray = new List<string>();
                        if (!string.IsNullOrEmpty(row.Name))
                        {
                            dataArray = row.Name.Split(new string[] { TitleSeparator }, StringSplitOptions.None).ToList();
                        }

                        // 确保数组长度与标题一致
                        while (dataArray.Count < dynamicTitles.Count)
                        {
                            dataArray.Add("");
                        }

                        // 计算公式
                        var originalData = new List<string>(dataArray);
                        dataArray = CalculateFormulas(dataArray, dynamicTitles, formulas);

                        // 检查数据是否有变化
                        bool hasChanged = false;
                        for (int i = 0; i < dataArray.Count; i++)
                        {
                            if (i < originalData.Count && originalData[i] != dataArray[i])
                            {
                                hasChanged = true;
                                break;
                            }
                        }

                        // 如果有变化才更新数据库
                        if (hasChanged)
                        {
                            UpdateRowData(gongsi, row.Id, dataArray);
                        }

                        processedCount++;
                    }
                    catch (Exception rowEx)
                    {
                        // 记录错误但继续处理其他行
                        // 可以在这里记录日志：rowEx.Message
                    }
                }

                responseMessage = "计算完成";
                isSuccess = true;
            }
            catch (Exception ex)
            {
                responseMessage = "计算失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\", \"processedCount\": " + processedCount + "}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }

        // 计算公式
        private List<string> CalculateFormulas(List<string> dataArray, List<DynamicTitle> dynamicTitles, List<Formula> formulas)
        {
            if (formulas.Count == 0) return dataArray;

            // 创建字段值字典
            var fieldValues = new Dictionary<string, double>();
            for (int i = 0; i < dynamicTitles.Count; i++)
            {
                double value = 0;
                double.TryParse(dataArray[i], out value);
                fieldValues[dynamicTitles[i].Text] = value;
            }

            // 迭代计算，解决依赖问题
            bool hasChanged = true;
            int maxIterations = 5;
            int iteration = 0;

            while (hasChanged && iteration < maxIterations)
            {
                hasChanged = false;
                iteration++;

                foreach (var formula in formulas)
                {
                    try
                    {
                        // 获取目标字段索引
                        int targetIndex = -1;
                        for (int i = 0; i < dynamicTitles.Count; i++)
                        {
                            if (dynamicTitles[i].Text == formula.TargetField)
                            {
                                targetIndex = i;
                                break;
                            }
                        }

                        if (targetIndex == -1) continue;

                        // 替换字段名为数值
                        string expression = formula.Expression;
                        foreach (var field in fieldValues)
                        {
                            expression = expression.Replace(field.Key, field.Value.ToString());
                        }

                        // 计算表达式
                        double result = SafeEvaluateExpression(expression);
                        
                        // 更新值
                        if (Math.Abs(fieldValues[formula.TargetField] - result) > 0.001)
                        {
                            fieldValues[formula.TargetField] = result;
                            hasChanged = true;
                        }
                    }
                    catch (Exception)
                    {
                        // 忽略计算错误
                    }
                }
            }

            // 更新数据数组
            for (int i = 0; i < dynamicTitles.Count; i++)
            {
                if (fieldValues.ContainsKey(dynamicTitles[i].Text))
                {
                    dataArray[i] = fieldValues[dynamicTitles[i].Text].ToString("F2");
                }
            }

            return dataArray;
        }

        // 安全计算表达式
        private double SafeEvaluateExpression(string expression)
        {
            try
            {
                // 移除所有空格
                expression = expression.Replace(" ", "");

                // 使用DataTable计算
                DataTable dt = new DataTable();
                var result = dt.Compute(expression, "");
                return Convert.ToDouble(result);
            }
            catch
            {
                return 0;
            }
        }

        // 辅助方法
        private TitleConfig LoadTitleConfigFromDb(string gongsi)
        {
            string conString = ConfigurationManager.AppSettings["yao"];
            using (conn = new SqlConnection(conString))
            {
                string sql = "SELECT id, gongsi, name FROM gongzi_dongtaimingxi WHERE id = @id AND gongsi = @gongsi";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", TitleConfigId);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new TitleConfig
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Gongsi = reader["gongsi"].ToString(),
                        Name = reader["name"].ToString()
                    };
                }
                reader.Close();
            }
            return null;
        }

        private List<DynamicTitle> ParseTitleConfig(TitleConfig titleConfig)
        {
            var dynamicTitles = new List<DynamicTitle>();

            if (titleConfig != null && !string.IsNullOrEmpty(titleConfig.Name))
            {
                var titleArray = titleConfig.Name.Split(new string[] { TitleSeparator }, StringSplitOptions.None);
                for (int i = 0; i < titleArray.Length; i++)
                {
                    dynamicTitles.Add(new DynamicTitle
                    {
                        Text = titleArray[i].Trim(),
                        ColumnName = string.Format("field_{0}", i + 1),
                        ColumnIndex = i
                    });
                }
            }
            else
            {
                // 默认字段
                for (int i = 0; i < 5; i++)
                {
                    dynamicTitles.Add(new DynamicTitle
                    {
                        Text = string.Format("字段{0}", i + 1),
                        ColumnName = string.Format("field_{0}", i + 1),
                        ColumnIndex = i
                    });
                }
            }

            return dynamicTitles;
        }

        private int GetTotalRecords(string gongsi)
        {
            string conString = ConfigurationManager.AppSettings["yao"];
            using (conn = new SqlConnection(conString))
            {
                string sql = "SELECT COUNT(*) FROM gongzi_dongtaimingxi WHERE gongsi = @gongsi AND id > @titleId";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);
                cmd.Parameters.AddWithValue("@titleId", TitleConfigId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count;
            }
        }

        private List<Dictionary<string, object>> LoadPageDataFromDb(string gongsi, int page, int pageSize, List<DynamicTitle> dynamicTitles)
        {
            var result = new List<Dictionary<string, object>>();
            string conString = ConfigurationManager.AppSettings["yao"];

            using (conn = new SqlConnection(conString))
            {
                int startIndex = (page - 1) * pageSize + 1;
                int endIndex = page * pageSize;

                string sql = @"
                    SELECT * FROM (
                        SELECT ROW_NUMBER() OVER (ORDER BY id) AS RowNum, id, name
                        FROM gongzi_dongtaimingxi 
                        WHERE gongsi = @gongsi AND id > @titleId
                    ) AS T
                    WHERE RowNum BETWEEN @start AND @end";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);
                cmd.Parameters.AddWithValue("@titleId", TitleConfigId);
                cmd.Parameters.AddWithValue("@start", startIndex);
                cmd.Parameters.AddWithValue("@end", endIndex);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var row = new Dictionary<string, object>
                    {
                        { "id", reader["id"] }
                    };

                    string name = "";
                    if (reader["name"] != null && reader["name"] != DBNull.Value)
                    {
                        name = reader["name"].ToString();
                    }
                    var dataArray = name.Split(new string[] { TitleSeparator }, StringSplitOptions.None);

                    // 为每个动态字段添加数据
                    for (int i = 0; i < dynamicTitles.Count; i++)
                    {
                        string value = i < dataArray.Length ? dataArray[i] : "";
                        row[dynamicTitles[i].ColumnName] = value;
                    }

                    result.Add(row);
                }
                reader.Close();
            }

            return result;
        }

        private void TruncateExistingData(string gongsi, int oldFieldCount, int newFieldCount)
        {
            string conString = ConfigurationManager.AppSettings["yao"];

            // 获取所有数据行
            var allRows = GetAllDataRows(gongsi);

            using (conn = new SqlConnection(conString))
            {
                conn.Open();
                
                foreach (var row in allRows)
                {
                    if (row.Id == TitleConfigId) continue;

                    var dataArray = new List<string>();
                    if (!string.IsNullOrEmpty(row.Name))
                    {
                        dataArray = row.Name.Split(new string[] { TitleSeparator }, StringSplitOptions.None).ToList();
                    }

                    // 截断到新的列数
                    var truncatedArray = dataArray.Take(newFieldCount).ToList();
                    while (truncatedArray.Count < newFieldCount)
                    {
                        truncatedArray.Add("");
                    }

                    string newName = string.Join(TitleSeparator, truncatedArray);

                    string sql = "UPDATE gongzi_dongtaimingxi SET name = @name WHERE id = @id AND gongsi = @gongsi";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@id", row.Id);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        private List<DataRow> GetAllDataRows(string gongsi)
        {
            var rows = new List<DataRow>();
            string conString = ConfigurationManager.AppSettings["yao"];

            using (SqlConnection conn = new SqlConnection(conString))
            {
                string sql = "SELECT id, name FROM gongzi_dongtaimingxi WHERE gongsi = @gongsi ORDER BY id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rows.Add(new DataRow
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"] != DBNull.Value ? Convert.ToString(reader["name"]) : ""
                    });
                }
                reader.Close();
            }

            return rows;
        }

        // 用于前端JS调用的方法
        public string GetDynamicTitlesJson()
        {
            string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
            var titleConfig = LoadTitleConfigFromDb(gongsi);
            var dynamicTitles = ParseTitleConfig(titleConfig);
            return new JavaScriptSerializer().Serialize(dynamicTitles);
        }

        public string GetFormulaListJson()
        {
            string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
            var formulas = LoadFormulasFromDb(gongsi);
            return new JavaScriptSerializer().Serialize(formulas);
        }

        private DataRow GetRowData(string gongsi, int id)
        {
            string conString = ConfigurationManager.AppSettings["yao"];

            using (SqlConnection conn = new SqlConnection(conString))
            {
                string sql = "SELECT id, name FROM gongzi_dongtaimingxi WHERE id = @id AND gongsi = @gongsi";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new DataRow
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"] != DBNull.Value ? Convert.ToString(reader["name"]) : ""
                    };
                }
                reader.Close();
            }

            return null;
        }

        private void UpdateRowData(string gongsi, int id, List<string> dataArray)
        {
            string conString = ConfigurationManager.AppSettings["yao"];

            using (conn = new SqlConnection(conString))
            {
                string newName = string.Join(TitleSeparator, dataArray);
                string sql = "UPDATE gongzi_dongtaimingxi SET name = @name WHERE id = @id AND gongsi = @gongsi";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private List<Formula> LoadFormulasFromDb(string gongsi)
        {
            var formulas = new List<Formula>();
            string conString = ConfigurationManager.AppSettings["yao"];

            using (SqlConnection conn = new SqlConnection(conString))
            {
                string sql = "SELECT id, zhuziduan, gongshi FROM gongzi_dongtaigongshi WHERE gongsi = @gongsi ORDER BY id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    formulas.Add(new Formula
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TargetField = reader["zhuziduan"] != DBNull.Value ? Convert.ToString(reader["zhuziduan"]) : "",
                        Expression = reader["gongshi"] != DBNull.Value ? Convert.ToString(reader["gongshi"]) : ""
                    });
                }
                reader.Close();
            }

            return formulas;
        }

        private void CalculateFormulaOnly()
        {
            string responseMessage = "";
            bool isSuccess = false;
            int updatedRows = 0;
            int processedRows = 0;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
        
                if (string.IsNullOrEmpty(gongsi))
                {
                    responseMessage = "请先登录";
                    isSuccess = false;
                    return;
                }

                // 获取标题配置
                var titleConfig = LoadTitleConfigFromDb(gongsi);
                var dynamicTitles = ParseTitleConfig(titleConfig);

                // 获取所有公式
                var formulas = LoadFormulasFromDb(gongsi);
        
                if (formulas.Count == 0)
                {
                    responseMessage = "没有需要计算的公式";
                    isSuccess = true;
                    return;
                }

                // 获取所有需要计算的字段（公式的目标字段）
                var formulaTargetFields = formulas.Select(f => f.TargetField).Distinct().ToList();
        
                // 获取公式中引用的所有字段（依赖字段）
                var formulaDependencyFields = new HashSet<string>();
                foreach (var formula in formulas)
                {
                    var dependencies = ExtractDependenciesFromFormula(formula.Expression, dynamicTitles);
                    foreach (var dependency in dependencies)
                    {
                        formulaDependencyFields.Add(dependency);
                    }
                }

                // 合并所有公式相关的字段（目标和依赖）
                var allFormulaRelatedFields = new HashSet<string>(formulaTargetFields);
                foreach (var field in formulaDependencyFields)
                {
                    allFormulaRelatedFields.Add(field);
                }

                // 获取所有数据行（排除标题配置行）
                var allRows = GetAllDataRows(gongsi);
        
                if (allRows.Count(r => r.Id != TitleConfigId) == 0)
                {
                    responseMessage = "没有需要计算的数据";
                    isSuccess = true;
                    return;
                }

                // 为每个公式目标字段找到对应的列索引
                var targetFieldIndices = new Dictionary<string, int>();
                foreach (var targetField in formulaTargetFields)
                {
                    for (int i = 0; i < dynamicTitles.Count; i++)
                    {
                        if (dynamicTitles[i].Text == targetField)
                        {
                            targetFieldIndices[targetField] = i;
                            break;
                        }
                    }
                }

                foreach (var row in allRows)
                {
                    if (row.Id == TitleConfigId) continue;

                    processedRows++;
                    bool rowUpdated = false;

                    try
                    {
                        // 解析数据
                        var dataArray = new List<string>();
                        if (!string.IsNullOrEmpty(row.Name))
                        {
                            dataArray = row.Name.Split(new string[] { TitleSeparator }, StringSplitOptions.None).ToList();
                        }

                        // 确保数组长度与标题一致
                        while (dataArray.Count < dynamicTitles.Count)
                        {
                            dataArray.Add("");
                        }

                        // 备份原始数据
                        var originalData = new List<string>(dataArray);

                        // 创建字段值字典（只包含公式相关的字段）
                        var fieldValues = new Dictionary<string, double>();
                        for (int i = 0; i < dynamicTitles.Count; i++)
                        {
                            // 只存储公式相关的字段
                            if (allFormulaRelatedFields.Contains(dynamicTitles[i].Text))
                            {
                                double value = 0;
                                double.TryParse(dataArray[i], out value);
                                fieldValues[dynamicTitles[i].Text] = value;
                            }
                        }

                        // 按顺序计算公式（处理依赖关系）
                        var sortedFormulas = SortFormulasByDependency(formulas, dynamicTitles);
                
                        foreach (var formula in sortedFormulas)
                        {
                            try
                            {
                                // 检查目标字段是否有效
                                if (!targetFieldIndices.ContainsKey(formula.TargetField))
                                {
                                    continue;
                                }

                                int targetIndex = targetFieldIndices[formula.TargetField];

                                // 替换字段名为数值
                                string expression = formula.Expression;
                                foreach (var field in fieldValues)
                                {
                                    expression = expression.Replace(field.Key, field.Value.ToString("F2"));
                                }

                                // 计算表达式
                                double result = SafeEvaluateExpression(expression);
                        
                                // 检查是否需要更新
                                double originalValue = 0;
                                if (fieldValues.ContainsKey(formula.TargetField))
                                {
                                    originalValue = fieldValues[formula.TargetField];
                                }

                                // 如果值有变化，则更新
                                if (Math.Abs(originalValue - result) > 0.001)
                                {
                                    fieldValues[formula.TargetField] = result;
                                    dataArray[targetIndex] = result.ToString("F2");
                                    rowUpdated = true;
                                }
                            }
                            catch (Exception formulaEx)
                            {
                                // 记录错误但继续处理其他公式
                                // Log.Error($"公式计算失败: {formula.TargetField} = {formula.Expression}", formulaEx);
                            }
                        }

                        // 如果行数据有更新，保存到数据库
                        if (rowUpdated)
                        {
                            UpdateRowData(gongsi, row.Id, dataArray);
                            updatedRows++;
                        }
                    }
                    catch (Exception rowEx)
                    {
                        // 记录行处理错误但继续处理其他行
                        // Log.Error($"处理行失败 ID: {row.Id}", rowEx);
                    }
                }

                responseMessage = "计算完成";
                isSuccess = true;
            }
            catch (Exception ex)
            {
                responseMessage = "计算失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\", \"updatedRows\": " + updatedRows + "}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }

        // 从公式中提取依赖字段
        private List<string> ExtractDependenciesFromFormula(string formula, List<DynamicTitle> dynamicTitles)
        {
            var dependencies = new List<string>();
    
            if (string.IsNullOrEmpty(formula) || dynamicTitles == null)
                return dependencies;

            // 简单的字段名提取逻辑
            foreach (var title in dynamicTitles)
            {
                // 在公式中查找字段名
                // 使用正则表达式确保字段名是独立的单词（避免部分匹配）
                string pattern = @"\b" + Regex.Escape(title.Text) + @"\b";
                if (Regex.IsMatch(formula, pattern))
                {
                    dependencies.Add(title.Text);
                }
            }

            return dependencies;
        }

        // 按依赖关系排序公式
        private List<Formula> SortFormulasByDependency(List<Formula> formulas, List<DynamicTitle> dynamicTitles)
        {
            // 创建一个依赖图
            var graph = new Dictionary<string, List<string>>();
            var formulaMap = new Dictionary<string, Formula>();
    
            foreach (var formula in formulas)
            {
                formulaMap[formula.TargetField] = formula;
                var dependencies = ExtractDependenciesFromFormula(formula.Expression, dynamicTitles);
                graph[formula.TargetField] = dependencies;
            }

            // 拓扑排序
            var visited = new Dictionary<string, bool>();
            var sorted = new List<Formula>();
    
            foreach (var formula in formulas)
            {
                TopologicalSort(formula.TargetField, graph, visited, sorted, formulaMap);
            }

            return sorted;
        }

        // 拓扑排序辅助方法
        private void TopologicalSort(string node, Dictionary<string, List<string>> graph, 
                                   Dictionary<string, bool> visited, List<Formula> sorted, 
                                   Dictionary<string, Formula> formulaMap)
        {
            if (!visited.ContainsKey(node))
                visited[node] = false;

            if (visited[node])
                return;

            visited[node] = true;

            // 递归处理依赖
            if (graph.ContainsKey(node))
            {
                foreach (var dependency in graph[node])
                {
                    if (formulaMap.ContainsKey(dependency))
                    {
                        TopologicalSort(dependency, graph, visited, sorted, formulaMap);
                    }
                }
            }

            // 所有依赖都处理完后，添加当前节点
            if (formulaMap.ContainsKey(node))
            {
                sorted.Add(formulaMap[node]);
            }
        }

        // 数据模型类
        private class TitleConfig
        {
            public int Id { get; set; }
            public string Gongsi { get; set; }
            public string Name { get; set; }
        }

        private class DynamicTitle
        {
            public string Text { get; set; }
            public string ColumnName { get; set; }
            public int ColumnIndex { get; set; }
        }

        private class DataRow
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private class Formula
        {
            public int Id { get; set; }
            public string TargetField { get; set; }
            public string Expression { get; set; }
        }
    }
}