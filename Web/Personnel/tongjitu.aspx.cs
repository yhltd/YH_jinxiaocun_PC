using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Web.Script.Serialization;

namespace Web.Personnel
{
    public partial class tongjitu : System.Web.UI.Page
    {
        private const string TitleSeparator = "|||";
        private const int TitleConfigId = 1;
        private JavaScriptSerializer serializer = new JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 检查登录
            if (Session["gongsi"] == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
                return;
            }

            // 处理AJAX请求
            ProcessAction();
        }

        private void ProcessAction()
        {
            string action = Request.Form["action"];
            if (string.IsNullOrEmpty(action))
                return;

            switch (action.ToLower())
            {
                case "loaddata":
                    LoadChartData();
                    break;
                case "savechartconfig":
                    SaveChartConfig();
                    break;
                case "loadchartconfigs":
                    LoadChartConfigs();
                    break;
                case "deletechartconfig":
                    DeleteChartConfig();
                    break;
            }
        }

        // 加载图表数据
        private void LoadChartData()
        {
            string responseMessage = "";
            bool isSuccess = false;
            object responseData = null;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";

                if (string.IsNullOrEmpty(gongsi))
                {
                    responseMessage = "请先登录";
                    isSuccess = false;
                }
                else
                {
                    // 获取标题配置
                    var titleConfig = LoadTitleConfigFromDb(gongsi);
                    var dynamicTitles = ParseTitleConfig(titleConfig);

                    // 获取所有数据行（排除标题配置行）
                    var allRows = GetAllDataRows(gongsi);

                    // 准备返回数据
                    var fields = dynamicTitles.Select(t => t.Text).ToList();
                    var data = new List<Dictionary<string, object>>();

                    foreach (var row in allRows)
                    {
                        if (row.Id == TitleConfigId) continue;

                        var rowDict = new Dictionary<string, object>
                        {
                            { "id", row.Id }
                        };

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

                        // 添加字段值
                        rowDict["values"] = dataArray.ToArray();
                        data.Add(rowDict);
                    }

                    responseData = new
                    {
                        fields = fields,
                        data = data
                    };

                    responseMessage = "加载成功";
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                responseMessage = "加载失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage },
                    { "data", responseData }
                };

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 保存图表配置
        private void SaveChartConfig()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                string name = Request.Form["name"] ?? "";
                string configData = Request.Form["configData"] ?? "{}";

                if (string.IsNullOrEmpty(name))
                {
                    responseMessage = "配置名称不能为空";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        string sql = @"INSERT INTO gongzi_tongjitu 
                                     (gongsi, name, config_data, created_time) 
                                     VALUES (@gongsi, @name, @config_data, GETDATE())";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@gongsi", gongsi);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@config_data", configData);

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            responseMessage = "保存成功";
                            isSuccess = true;
                        }
                        else
                        {
                            responseMessage = "保存失败";
                            isSuccess = false;
                        }
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
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage }
                };

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 加载图表配置列表
        private void LoadChartConfigs()
        {
            string responseMessage = "";
            bool isSuccess = false;
            object responseData = null;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                string conString = ConfigurationManager.AppSettings["yao"];

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = @"SELECT id, name, config_data, created_time 
                                 FROM gongzi_tongjitu 
                                 WHERE gongsi = @gongsi 
                                 ORDER BY created_time DESC";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Dictionary<string, object>> configs = new List<Dictionary<string, object>>();

                    while (reader.Read())
                    {
                        var config = new Dictionary<string, object>();
                        config["id"] = reader["id"] != DBNull.Value ? reader["id"] : 0;
                        config["name"] = reader["name"] != DBNull.Value ? reader["name"].ToString() : "";
                        config["created_time"] = reader["created_time"] != DBNull.Value ?
                                               Convert.ToDateTime(reader["created_time"]).ToString("yyyy-MM-dd HH:mm") : "";

                        // 解析配置数据
                        string configDataStr = reader["config_data"] != DBNull.Value ? reader["config_data"].ToString() : "{}";
                        try
                        {
                            config["config"] = serializer.Deserialize<Dictionary<string, object>>(configDataStr);
                        }
                        catch
                        {
                            config["config"] = new Dictionary<string, object>();
                        }

                        configs.Add(config);
                    }
                    reader.Close();

                    responseData = new { configs = configs };
                    responseMessage = "加载成功";
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                responseMessage = "加载失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage },
                    { "data", responseData }
                };

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 删除图表配置
        private void DeleteChartConfig()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                string configIdStr = Request.Form["configId"] ?? "0";

                int configId;
                if (!int.TryParse(configIdStr, out configId))
                {
                    responseMessage = "参数错误";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        string sql = @"DELETE FROM gongzi_tongjitu 
                                     WHERE id = @id AND gongsi = @gongsi";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", configId);
                        cmd.Parameters.AddWithValue("@gongsi", gongsi);

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            responseMessage = "删除成功";
                            isSuccess = true;
                        }
                        else
                        {
                            responseMessage = "删除失败，记录不存在或无权限";
                            isSuccess = false;
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
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage }
                };

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 辅助方法 - 从数据库加载标题配置
        private TitleConfig LoadTitleConfigFromDb(string gongsi)
        {
            string conString = ConfigurationManager.AppSettings["yao"];
            using (SqlConnection conn = new SqlConnection(conString))
            {
                string sql = "SELECT id, gongsi, name FROM gongzi_dongtaimingxi WHERE id = @id AND gongsi = @gongsi";
                SqlCommand cmd = new SqlCommand(sql, conn);
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

        // 辅助方法 - 解析标题配置
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

        // 辅助方法 - 获取所有数据行
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
    }
}