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
    public partial class lizhishenpi : System.Web.UI.Page
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
                        // 可以在这里添加权限控制
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
            sqlBuilder.Append("SELECT id, bumen, xingming, tijiaoriqi, shenqingyuanyin, shenpijieguo, shenpiyuanyin ");
            sqlBuilder.Append("FROM gongzi_lizhishenpi ");
            sqlBuilder.Append("WHERE gongsi = @gongsi ");

            // 获取查询条件
            bool isSearching = Session["IsSearching"] != null && (bool)Session["IsSearching"];

            if (isSearching)
            {
                // 添加额外的查询条件
                string bumen = Session["SearchBumen"] != null ? Session["SearchBumen"].ToString() : "";
                string xingming = Session["SearchXingming"] != null ? Session["SearchXingming"].ToString() : "";
                string shenpijieguo = Session["SearchShenpijieguo"] != null ? Session["SearchShenpijieguo"].ToString() : "";

                // 构建条件
                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(bumen))
                {
                    conditions.Add("bumen LIKE @bumen");
                }

                if (!string.IsNullOrEmpty(xingming))
                {
                    conditions.Add("xingming LIKE @xingming");
                }

                if (!string.IsNullOrEmpty(shenpijieguo))
                {
                    conditions.Add("shenpijieguo = @shenpijieguo");
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
                string bumen = Session["SearchBumen"] != null ? Session["SearchBumen"].ToString() : "";
                string xingming = Session["SearchXingming"] != null ? Session["SearchXingming"].ToString() : "";
                string shenpijieguo = Session["SearchShenpijieguo"] != null ? Session["SearchShenpijieguo"].ToString() : "";

                if (!string.IsNullOrEmpty(bumen))
                {
                    SqlDataSource1.SelectParameters.Add("bumen", "%" + bumen + "%");
                }

                if (!string.IsNullOrEmpty(xingming))
                {
                    SqlDataSource1.SelectParameters.Add("xingming", "%" + xingming + "%");
                }

                if (!string.IsNullOrEmpty(shenpijieguo))
                {
                    SqlDataSource1.SelectParameters.Add("shenpijieguo", shenpijieguo);
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
                case "edital":
                    EditAllFields();
                    break;
                case "delete":
                    DeleteRecord();
                    break;
                case "export":
                    ExportToExcel();
                    break;
                case "search":
                    SearchRecords();
                    break;
                case "resetsearch":
                    ResetSearch();
                    break;
                case "quickadd":
                    QuickAddRecord();
                    break;
            }
        }

        private void BindGridView()
        {
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // 可以在这里添加行数据绑定的额外处理
        }

        // 查询记录
        private void SearchRecords()
        {
            // 获取查询条件
            string bumen = Request.Form["bumen"] ?? "";
            string xingming = Request.Form["xingming"] ?? "";
            string shenpijieguo = Request.Form["shenpijieguo"] ?? "";

            // 存储查询条件到Session
            Session["SearchBumen"] = bumen;
            Session["SearchXingming"] = xingming;
            Session["SearchShenpijieguo"] = shenpijieguo;

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
            Session["SearchBumen"] = null;
            Session["SearchXingming"] = null;
            Session["SearchShenpijieguo"] = null;
            Session["IsSearching"] = false;

            // 返回成功响应
            Response.Write("{\"success\": true, \"message\": \"查询条件已重置\"}");
            Response.End();
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
                    string bumen = Request.Form["addBumen"] ?? "";
                    string xingming = Request.Form["addXingming"] ?? "";
                    string tijiaoriqi = Request.Form["addTijiaoriqi"] ?? "";
                    string shenqingyuanyin = Request.Form["addShenqingyuanyin"] ?? "";
                    string shenpiyuanyin = Request.Form["addShenpiyuanyin"] ?? "";
                    string shenpijieguo = Request.Form["addShenpijieguo"] ?? "";

                    // 验证必填字段
                    if (string.IsNullOrEmpty(bumen))
                    {
                        responseMessage = "部门不能为空！";
                        isSuccess = false;
                    }
                    else if (string.IsNullOrEmpty(xingming))
                    {
                        responseMessage = "姓名不能为空！";
                        isSuccess = false;
                    }
                    else
                    {
                        using (conn = new SqlConnection(conString))
                        {
                            string sql = @"INSERT INTO gongzi_lizhishenpi 
                                  (gongsi, bumen, xingming, tijiaoriqi, shenqingyuanyin, shenpiyuanyin, shenpijieguo) 
                                  VALUES(@gongsi, @bumen, @xingming, @tijiaoriqi, @shenqingyuanyin, @shenpiyuanyin, @shenpijieguo)";

                            cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@gongsi", gongsi);
                            cmd.Parameters.AddWithValue("@bumen", bumen.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@xingming", xingming.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@tijiaoriqi", tijiaoriqi.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@shenqingyuanyin", shenqingyuanyin.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@shenpiyuanyin", shenpiyuanyin.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@shenpijieguo", shenpijieguo.Replace("'", "''"));

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

        // 快速添加记录（只添加公司和提交日期）
        private void QuickAddRecord()
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

                    // 获取当天日期
                    string today = DateTime.Now.ToString("yyyy-MM-dd");

                    using (conn = new SqlConnection(conString))
                    {
                        string sql = @"INSERT INTO gongzi_lizhishenpi (gongsi, tijiaoriqi) VALUES(@gongsi, @tijiaoriqi)";

                        cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@gongsi", gongsi);
                        cmd.Parameters.AddWithValue("@tijiaoriqi", today);

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

        // 批量编辑记录 - 编辑所有字段
        private void EditAllFields()
        {
            string id = Request.Form["editRecordId"];
            string bumen = Request.Form["editBumen"];
            string xingming = Request.Form["editXingming"];
            string tijiaoriqi = Request.Form["editTijiaoriqi"];
            string shenqingyuanyin = Request.Form["editShenqingyuanyin"];
            string shenpiyuanyin = Request.Form["editShenpiyuanyin"];
            string shenpijieguo = Request.Form["editShenpijieguo"];

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
                    string sql = @"UPDATE gongzi_lizhishenpi SET 
                           bumen = @bumen, 
                           xingming = @xingming, 
                           tijiaoriqi = @tijiaoriqi, 
                           shenqingyuanyin = @shenqingyuanyin, 
                           shenpiyuanyin = @shenpiyuanyin, 
                           shenpijieguo = @shenpijieguo 
                           WHERE id = @id";

                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@bumen", (bumen ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@xingming", (xingming ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@tijiaoriqi", (tijiaoriqi ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@shenqingyuanyin", (shenqingyuanyin ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@shenpiyuanyin", (shenpiyuanyin ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@shenpijieguo", (shenpijieguo ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Write("<script>alert('更新成功！'); location.href='lizhishenpi.aspx';</script>");
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
                // 从Form获取id
                string id = Request.Form["id"];

                if (string.IsNullOrEmpty(id))
                {
                    responseMessage = "参数错误！";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        string sql = "DELETE FROM gongzi_lizhishenpi WHERE id = @id";
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
                string sql = @"SELECT bumen, xingming, tijiaoriqi, shenqingyuanyin, shenpijieguo, shenpiyuanyin 
                               FROM gongzi_lizhishenpi 
                               WHERE gongsi = @gongsi 
                               ORDER BY id DESC";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 导出Excel
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=离职审批管理表.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    // 添加表头
                    hw.Write("<table border='1'><tr>");
                    hw.Write("<td>部门</td>");
                    hw.Write("<td>姓名</td>");
                    hw.Write("<td>提交日期</td>");
                    hw.Write("<td>申请原因</td>");
                    hw.Write("<td>审批结果</td>");
                    hw.Write("<td>审批原因</td>");
                    hw.Write("</tr>");

                    // 添加数据行
                    foreach (DataRow row in dt.Rows)
                    {
                        hw.Write("<tr>");
                        hw.Write("<td>" + (row["bumen"] != null ? row["bumen"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["xingming"] != null ? row["xingming"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["tijiaoriqi"] != null ? row["tijiaoriqi"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["shenqingyuanyin"] != null ? row["shenqingyuanyin"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["shenpijieguo"] != null ? row["shenpijieguo"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["shenpiyuanyin"] != null ? row["shenpiyuanyin"].ToString() : "") + "</td>");
                        hw.Write("</tr>");
                    }

                    hw.Write("</table>");
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }

        // 获取状态样式（用于前端调用）
        public string GetStatusClass(string status)
        {
            if (string.IsNullOrEmpty(status)) return "status-default";

            switch (status.ToLower())
            {
                case "通过":
                    return "status-tongguo";
                case "驳回":
                    return "status-bohui";
                case "待审批":
                    return "status-daishanpi";
                default:
                    return "status-default";
            }
        }
    }
}