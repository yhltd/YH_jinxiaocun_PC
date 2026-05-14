using clsBuiness;
using Order.Common;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.finance.util;
using Web.jxc_service;
using Web.scheduling;
using Web.Server;
using Web.Service;
using Web.Pushnews.dao;
using Web.Pushnews.model;
using MySql.Data.MySqlClient;

namespace Web
{
    public partial class login : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod]
        public static List<product_pushnews> GetPushNewsLogo(string companyName, string systemName)
        {
            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(systemName))
            {
                return new List<product_pushnews>();
            }
            PushNewsDao pushNewsDao = new PushNewsDao();
            return pushNewsDao.SelectListByCompanyAndSystem(companyName, systemName);
        }

        public string alterinfo1;
        public string user;
        public string pass;
        public string version;

        protected void Page_Load(object sender, EventArgs e)
        {
            version = "建议使用谷歌浏览器效果最好- 当前系统版本: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (!Page.IsPostBack)
            {
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("选择", "绑定数据"));
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, new ListItem("选择"));
                DropDownList3.Items.Insert(1, new ListItem("云合未来"));
                DropDownList3.Items.Insert(2, new ListItem("其他"));
            }
        }

        protected void xitong_select(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=bds28428944.my3w.com;Initial Catalog=bds28428944_db;User ID=bds28428944;Password=07910Lyh"))
            {
                conn.Open();
                string sqlStr = "";
                if (DropDownList3.SelectedItem.Text == "云合未来")
                {
                    sqlStr = "select systemName from all_systems where type = '1';";
                }
                else if (DropDownList3.SelectedItem.Text == "其他")
                {
                    sqlStr = "select systemName from all_systems where type != '1';";
                }

                if (!string.IsNullOrEmpty(sqlStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                    {
                        using (SqlDataReader str = cmd.ExecuteReader())
                        {
                            DropDownList1.Items.Clear();
                            List<string> itemi = new List<string>();
                            while (str.Read())
                            {
                                itemi.Add(str[0].ToString());
                            }
                            DropDownList1.DataSource = itemi;
                            DropDownList1.DataBind();
                            DropDownList1.Items.Insert(0, new ListItem("选择", "绑定数据"));
                        }
                    }
                }
                else
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Insert(0, new ListItem("选择", "绑定数据"));
                }
            }
        }

        protected void bian(object sender, EventArgs e)
        {
            string selectedSystem = DropDownList1.SelectedItem.Text;
            if (selectedSystem == "云合人事管理系统")
            {
                using (SqlConnection conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;"))
                {
                    conn.Open();
                    string sqlStr = "select L from gongzi_renyuan GROUP BY L;";
                    using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                    {
                        using (SqlDataReader str = cmd.ExecuteReader())
                        {
                            DropDownList2.Items.Clear();
                            List<string> itemi = new List<string>();
                            while (str.Read())
                            {
                                itemi.Add(str[0].ToString());
                            }
                            DropDownList2.DataSource = itemi;
                            DropDownList2.DataBind();
                        }
                    }
                }
            }
            else if (selectedSystem == "云合未来进销存系统")
            {
                using (SqlConnection conn3 = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yh_jinxiaocun_excel;Uid=sa;Pwd=Lyh07910_001;"))
                {
                    conn3.Open();
                    DropDownList2.Items.Clear();
                    Session["shujuku"] = 1;
                    UserModel userModel = new UserModel();
                    try
                    {
                        DropDownList2.DataSource = userModel.selectCompanys();
                    }
                    catch
                    {
                        Response.Write("<script>alert('网络超时，请稍后再试。')</script>");
                    }
                    DropDownList2.DataBind();
                }
            }
            else if (selectedSystem == "云合未来财务系统")
            {
                DropDownList2.Items.Clear();
                AccountService accountService = new AccountService(false);
                try
                {
                    DropDownList2.DataSource = accountService.getCompanys();
                }
                catch
                {
                    Response.Write("<script>alert('网络超时，请稍后再试。')</script>");
                }
                DropDownList2.DataBind();
            }
            else if (selectedSystem == "云合排产管理系统")
            {
                DropDownList2.Items.Clear();
                DropDownList2.DataSource = UserInfoService.companyList();
                DropDownList2.DataBind();
            }
        }

        protected void HtmlBtn_Click(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string txtSAPPassword = Request.Form["password"];
            string servename = "";
            string gs_name = "";

            string _DropDownList1 = Request.Form["_DropDownList1"];
            string _DropDownList2 = Request.Form["_DropDownList2"];

            servename = (!string.IsNullOrEmpty(_DropDownList1)) ? _DropDownList1 : DropDownList1.SelectedItem.Text;
            gs_name = (!string.IsNullOrEmpty(_DropDownList2)) ? _DropDownList2 : DropDownList2.SelectedItem.Text;

            if (servename == "选择")
            {
                Response.Write("<script id='alert'>alert('请选择数据库!')</script>");
                return;
            }

            if (servename == "云合人事管理系统")
            {
                Session.Timeout = 10000;
                Session["username"] = username;
                Session["gs_name"] = gs_name;

                if (!string.IsNullOrEmpty(gs_name) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(txtSAPPassword))
                {
                    string connStr = ConfigurationManager.AppSettings["yao"];
                    int id = 0;
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        string sqlStr = "select id from gongzi_renyuan where L=@gs_name and I=@username and J=@pass;";
                        using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                        {
                            cmd.Parameters.AddWithValue("@gs_name", gs_name);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@pass", txtSAPPassword);
                            object result = cmd.ExecuteScalar();
                            if (result != null) id = Convert.ToInt32(result);
                        }
                    }

                    if (id != 0)
                    {
                        string thisNum = "";
                        string thisStorageSpace = "";
                        using (SqlConnection conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;MultipleActiveResultSets=true;Uid=bds28428944;Pwd=07910Lyh;"))
                        {
                            conn.Open();
                            string now = DateTime.Now.ToShortDateString();
                            string this_sql = "select CASE WHEN convert(date,endtime)< @now THEN 1 ELSE 0 END as endtime, CASE WHEN convert(date,mark2)< @now THEN 1 ELSE 0 END as mark2, mark1, isnull(mark3,'') as mark3, isnull(mark5,'') as mark5, isnull(mark4,'') as mark4 from control_soft_time where name = @gs_name and soft_name='人事'";
                            using (SqlCommand cmd = new SqlCommand(this_sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@now", now);
                                cmd.Parameters.AddWithValue("@gs_name", gs_name.Trim());
                                using (SqlDataReader str = cmd.ExecuteReader())
                                {
                                    if (str.Read())
                                    {
                                        if (!str["mark1"].ToString().Trim().Equals("a8xd2s"))
                                        {
                                            if (str["mark5"] == DBNull.Value || !str["mark5"].ToString().Contains("PC端"))
                                            {
                                                Response.Write("<script>alert('您没有当前使用端权限，请联系我公司续费或者购买系统。')</script>");
                                                return;
                                            }
                                            if (Convert.ToInt32(str["endtime"]) == 1)
                                            {
                                                Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>");
                                                return;
                                            }
                                            if (Convert.ToInt32(str["mark2"]) == 1)
                                            {
                                                Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>");
                                                return;
                                            }
                                            thisStorageSpace = str["mark4"].ToString().Trim();
                                        }
                                        string m3 = str["mark3"].ToString().Trim();
                                        if (!string.IsNullOrEmpty(m3) && m3.Contains(":"))
                                        {
                                            thisNum = m3.Split(':')[1].Replace("(", "").Replace(")", "");
                                        }
                                    }
                                }
                            }
                        }
                        double totalDBSizeKB = GetDatabaseSize( "Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;", gs_name.Trim(), new Dictionary<string, string> { { "gongzi_dongtaimingxi", "gongsi" }, { "gongzi_gongzimingxi", "BD" }, { "gongzi_jianliguanli", "gongsi" }, { "gongzi_kaoqinjilu", "AO" }, { "gongzi_kaoqinmingxi", "K" }, { "gongzi_lizhishenpi", "gongsi" }, { "gongzi_shenpi", "gongsi" }, { "gongzi_shezhi", "gongsi" }, { "gongzi_renyuan", "L" }, { "gongzi_qingjiashenpi", "gongsi" } }, true);

                        string[] b = gs_name.Split('_');
                        Session["gongsi"] = b[0];
                        Session["id1"] = id;
                        Session["userNum"] = thisNum;

                        HttpCookie storageCookie = new HttpCookie("storageSpace") { Value = thisStorageSpace, Expires = DateTime.Now.AddDays(7) };
                        Response.Cookies.Add(storageCookie);
                        HttpCookie dbSizeCookie = new HttpCookie("dbSizeKB") { Value = totalDBSizeKB.ToString(), Expires = DateTime.Now.AddDays(7) };
                        Response.Cookies.Add(dbSizeCookie);

                        Server.Transfer("../Personnel/index.aspx");
                    }
                    else
                    {
                        Response.Write("<script id='alert'>alert('输入密码有误，请重试')</script>");
                    }
                }
            }
            else if (servename == "云合未来进销存系统")
            {
                UserModel userModel = new UserModel();
                using (SqlConnection conn3 = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yh_jinxiaocun_excel;Uid=sa;Pwd=Lyh07910_001;"))
                {
                    conn3.Open();
                    string sqlStr3 = "select * from yh_jinxiaocun_user_mssql where gongsi = @gs_name and name = @username and password = @pass";
                    using (SqlCommand cmd = new SqlCommand(sqlStr3, conn3))
                    {
                        cmd.Parameters.AddWithValue("@gs_name", gs_name);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@pass", txtSAPPassword);
                        using (SqlDataReader str = cmd.ExecuteReader())
                        {
                            Session["shujuku"] = str.Read() ? 1 : 0;
                        }
                    }
                }

                yh_jinxiaocun_user user;
                try { user = userModel.login(gs_name.Trim(), username.Trim(), txtSAPPassword.Trim()); }
                catch { Response.Write("<script>alert('网络超时，请稍后再试。')</script>"); return; }

                if (user != null)
                {
                    if (user.Btype == "锁定") { Response.Write("<script id='alert'>alert('用户已被锁定！')</script>"); }
                    else
                    {
                        string thisNum = "";
                        string thisStorageSpace = "";
                        using (SqlConnection conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=07910Lyh;"))
                        {
                            conn.Open();
                            string now = DateTime.Now.ToShortDateString();
                            string sqlStr = "select CASE WHEN convert(date,endtime)< @now THEN 1 ELSE 0 END as endtime, CASE WHEN convert(date,mark2)< @now THEN 1 ELSE 0 END as mark2, mark1, isnull(mark3,'') as mark3, isnull(mark5,'') as mark5, isnull(mark4,'') as mark4 from control_soft_time where name = @gs_name and soft_name='进销存'";
                            using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                            {
                                cmd.Parameters.AddWithValue("@now", now);
                                cmd.Parameters.AddWithValue("@gs_name", gs_name.Trim());
                                using (SqlDataReader str = cmd.ExecuteReader())
                                {
                                    if (str.Read())
                                    {
                                        if (!str["mark1"].ToString().Trim().Equals("a8xd2s"))
                                        {
                                            if (str["mark5"] == DBNull.Value || !str["mark5"].ToString().Contains("PC端"))
                                            {
                                                Response.Write("<script>alert('您没有当前使用端权限，请联系我公司续费或者购买系统。')</script>");
                                                return;
                                            }
                                            if (Convert.ToInt32(str["endtime"]) == 1) { Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>"); return; }
                                            if (Convert.ToInt32(str["mark2"]) == 1) { Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>"); return; }
                                            thisStorageSpace = str["mark4"].ToString().Trim();
                                        }
                                        string m3 = str["mark3"].ToString().Trim();
                                        if (!string.IsNullOrEmpty(m3) && m3.Contains(":")) { thisNum = m3.Split(':')[1].Replace("(", "").Replace(")", ""); }
                                    }
                                }
                            }
                        }
                        double totalDBSizeKB = GetDatabaseSize("Data Source=sqloledb;server=yhocn.cn;Database=yh_jinxiaocun_excel;Uid=sa;Pwd=Lyh07910_001;", gs_name.Trim(), new Dictionary<string, string> { { "yh_jinxiaocun_cangku_mssql", "gongsi" }, { "yh_jinxiaocun_chuhuofang_mssql", "gongsi" }, { "yh_jinxiaocun_jichuziliao_mssql", "gs_name" }, { "yh_jinxiaocun_jinhuofang_mssql", "gongsi" }, { "yh_jinxiaocun_mingxi_mssql", "gs_name" }, { "yh_jinxiaocun_qichushu_mssql", "gs_name" }, { "yh_jinxiaocun_tuihuomingxi_mssql", "gs_name" }, { "yh_jinxiaocun_user_mssql", "gongsi" }, { "yh_jinxiaocun_zhengli_mssql", "gs_name" } }, false);
                        Session["userNum"] = thisNum;
                        Session.Timeout = 10000;
                        Session["user"] = user;
                        Response.Cookies.Add(new HttpCookie("storageSpace") { Value = thisStorageSpace, Expires = DateTime.Now.AddDays(7) });
                        Response.Cookies.Add(new HttpCookie("dbSizeKB") { Value = totalDBSizeKB.ToString(), Expires = DateTime.Now.AddDays(7) });
                        Response.Redirect("~/frmMain.aspx");
                        return;
                    }
                }
                else { Response.Write("<script id='alert'>alert('用户名密码错误！')</script>"); }
            }
            else if (servename == "云合未来财务系统")
            {
                AccountService accountService = new AccountService(false);
                string token = accountService.login(gs_name.Trim(), username.Trim(), txtSAPPassword.Trim());
                if (string.IsNullOrEmpty(token)) { ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('用户名密码错误！')", true); }
                else
                {
                    string thisNum = "";
                    string thisStorageSpace = "";
                    using (SqlConnection conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=07910Lyh;"))
                    {
                        conn.Open();
                        string now = DateTime.Now.ToShortDateString();
                        string sqlStr = "select CASE WHEN convert(date,endtime)< @now THEN 1 ELSE 0 END as endtime, CASE WHEN convert(date,mark2)< @now THEN 1 ELSE 0 END as mark2, mark1, isnull(mark3,'') as mark3, isnull(mark5,'') as mark5, isnull(mark4,'') as mark4 from control_soft_time where name = @gs_name and soft_name='财务'";
                        using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                        {
                            cmd.Parameters.AddWithValue("@now", now);
                            cmd.Parameters.AddWithValue("@gs_name", gs_name.Trim());
                            using (SqlDataReader str = cmd.ExecuteReader())
                            {
                                if (str.Read())
                                {
                                    if (!str["mark1"].ToString().Trim().Equals("a8xd2s"))
                                    {
                                        if (str["mark5"] == DBNull.Value || !str["mark5"].ToString().Contains("PC端"))
                                        {
                                            Response.Write("<script>alert('您没有当前使用端权限，请联系我公司续费或者购买系统。')</script>");
                                            return;
                                        }
                                        if (Convert.ToInt32(str["endtime"]) == 1) { Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>"); return; }
                                        if (Convert.ToInt32(str["mark2"]) == 1) { Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>"); return; }
                                        thisStorageSpace = str["mark4"].ToString().Trim();
                                    }
                                    string m3 = str["mark3"].ToString().Trim();
                                    if (!string.IsNullOrEmpty(m3) && m3.Contains(":")) { thisNum = m3.Split(':')[1].Replace("(", "").Replace(")", ""); }
                                }
                            }
                        }
                    }
                    double totalDBSizeKB = GetDatabaseSize("Data Source=sqloledb;server=yhocn.cn;Database=Finance;Uid=sa;Pwd=Lyh07910_001;", gs_name.Trim(), new Dictionary<string, string> { { "Account", "company" }, { "Accounting", "company" }, { "Department", "company" }, { "FinancingExpenditure", "company" }, { "FinancingIncome", "company" }, { "gongzimingxi", "company" }, { "InvestmentExpenditure", "company" }, { "InvestmentIncome", "company" }, { "Invoice", "company" }, { "InvoicePeizhi", "company" }, { "KehuPeizhi", "company" }, { "ManagementExpenditure", "company" }, { "ManagementIncome", "company" }, { "shuilvPeizhi", "company" }, { "SimpleAccounting", "company" }, { "SimpleData", "company" }, { "VoucherSummary", "company" }, { "VoucherWord", "company" }, { "waibiPeizhi", "company" }, { "ysyfpeizhi", "company" } }, false);
                    Session["userNum"] = thisNum;
                    FinanceToken.getFinanceCheckToken().setToken(token);
                    Response.Cookies.Add(new HttpCookie("storageSpace") { Value = thisStorageSpace, Expires = DateTime.Now.AddDays(7) });
                    Response.Cookies.Add(new HttpCookie("dbSizeKB") { Value = totalDBSizeKB.ToString(), Expires = DateTime.Now.AddDays(7) });
                    Response.Redirect("../finance/web/view/index.aspx");
                }
            }
            else if (servename == "云合排产管理系统")
            {
                try
                {
                    if (!UserInfoService.login(username.Trim(), txtSAPPassword.Trim(), gs_name.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('用户名密码错误或用户被禁用！')", true);
                    }
                    else
                    {
                        string thisNum = "";
                        string thisStorageSpace = "";
                        using (SqlConnection conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=07910Lyh;"))
                        {
                            conn.Open();
                            string now = DateTime.Now.ToShortDateString();
                            string sqlStr = "select CASE WHEN convert(date,endtime)< @now THEN 1 ELSE 0 END as endtime, CASE WHEN convert(date,mark2)< @now THEN 1 ELSE 0 END as mark2, mark1, isnull(mark3,'') as mark3, isnull(mark5,'') as mark5, isnull(mark4,'') as mark4 from control_soft_time where name = @gs_name and soft_name='排产'";
                            using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                            {
                                cmd.Parameters.AddWithValue("@now", now);
                                cmd.Parameters.AddWithValue("@gs_name", gs_name);
                                using (SqlDataReader str = cmd.ExecuteReader())
                                {
                                    if (str.Read())
                                    {
                                        if (!str["mark1"].ToString().Trim().Equals("a8xd2s"))
                                        {
                                            if (str["mark5"] == DBNull.Value || !str["mark5"].ToString().Contains("PC端"))
                                            {
                                                Response.Write("<script>alert('您没有当前使用端权限，请联系我公司续费或者购买系统。')</script>");
                                                return;
                                            }
                                            if (Convert.ToInt32(str["endtime"]) == 1) { Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>"); return; }
                                            if (Convert.ToInt32(str["mark2"]) == 1) { Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>"); return; }
                                            thisStorageSpace = str["mark4"].ToString().Trim();
                                        }
                                        string m3 = str["mark3"].ToString().Trim();
                                        if (!string.IsNullOrEmpty(m3) && m3.Contains(":")) { thisNum = m3.Split(':')[1].Replace("(", "").Replace(")", ""); }
                                    }
                                }
                            }
                        }
                        double totalDBSizeKB = GetDatabaseSize("Data Source=sqloledb;server=yhocn.cn;Database=scheduling;Uid=sa;Pwd=Lyh07910_001;", gs_name.Trim(), new Dictionary<string, string> { { "bom_info", "company" }, { "department", "company" }, { "holiday_config", "company" }, { "module_type", "company" }, { "order_check", "company" }, { "order_info", "company" }, { "paibanbiao_info", "remarks1" }, { "paibanbiao_renyuan", "company" }, { "paibanbiao_detail", "company" }, { "shengchanxian", "gongsi" }, { "time_config", "company" }, { "user_info", "company" }, { "work_detail", "company" } }, false);
                        int ky_rongliang = FinanceSpace.getFinanceSpace().getMark4_all(gs_name, "排产");
                        int sy_rongliang = FinanceSpace.getFinanceSpace().getUseMark4_all(gs_name, "排产");
                        if (sy_rongliang >= ky_rongliang)
                        {
                            Response.Write("<script>alert('您在我公司租用的数据库容量已超上限，该系统暂时无法使用。请联系我公司，官方微信号：1623005800。')</script>");
                            return;
                        }
                        Session["userNum"] = thisNum;
                        Response.Cookies.Add(new HttpCookie("storageSpace") { Value = thisStorageSpace, Expires = DateTime.Now.AddDays(7) });
                        Response.Cookies.Add(new HttpCookie("dbSizeKB") { Value = totalDBSizeKB.ToString(), Expires = DateTime.Now.AddDays(7) });
                        Response.Redirect("../scheduling/web/index.html");
                    }
                }
                catch (Exception) { Response.Write("系统执行出错，请稍后再试。"); }
            }
        }

        private double GetDatabaseSize(string connectionString, string companyName, Dictionary<string, string> tables, bool isPersonnel)
        {
            double totalSizeKB = 0;
            string searchCompanyName = companyName;
            if (isPersonnel && searchCompanyName.EndsWith("_hr"))
            {
                searchCompanyName = searchCompanyName.Substring(0, searchCompanyName.Length - 3);
            }

            try
            {
                using (SqlConnection dbConn = new SqlConnection(connectionString))
                {
                    dbConn.Open();
                    foreach (var table in tables)
                    {
                        string tableName = table.Key;
                        string companyColumn = table.Value;
                        try
                        {
                            string countSql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} LIKE @companyName", tableName, companyColumn);
                            using (SqlCommand countCmd = new SqlCommand(countSql, dbConn))
                            {
                                countCmd.Parameters.AddWithValue("@companyName", "%" + searchCompanyName + "%");
                                int rowCount = (int)countCmd.ExecuteScalar();
                                if (rowCount > 0)
                                {
                                    using (SqlCommand spaceCmd = new SqlCommand("EXEC sp_spaceused @tableName", dbConn))
                                    {
                                        spaceCmd.Parameters.AddWithValue("@tableName", tableName);
                                        using (SqlDataReader reader = spaceCmd.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                double totalSizeKB_Table = ParseSizeToKB(reader["data"].ToString());
                                                int totalRowCount = int.Parse(reader["rows"].ToString());
                                                if (totalRowCount > 0)
                                                {
                                                    totalSizeKB += totalSizeKB_Table * ((double)rowCount / totalRowCount);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            catch { totalSizeKB = 0; }
            return totalSizeKB;
        }

        private double ParseSizeToKB(string sizeStr)
        {
            if (string.IsNullOrEmpty(sizeStr)) return 0;
            sizeStr = sizeStr.Trim();
            try
            {
                if (sizeStr == "8 KB") return 0;
                string[] parts = sizeStr.Split(' ');
                if (parts.Length == 2)
                {
                    double value = double.Parse(parts[0]);
                    string unit = parts[1].ToUpper();
                    switch (unit)
                    {
                        case "KB": return value;
                        case "MB": return value * 1024;
                        case "GB": return value * 1024 * 1024;
                        case "TB": return value * 1024 * 1024 * 1024;
                        default: return value;
                    }
                }
            }
            catch { }
            return 0;
        }

        protected void HtmlBtcreate_Click(object sender, EventArgs e) { Response.Redirect("~/frmUserManger.aspx"); }
        protected void Btchangepas_Click(object sender, EventArgs e) { ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('请联系管理员！')", true); }
        protected void Btmain_Click(object sender, EventArgs e) { Response.Redirect("~/frmReadIDCare.aspx"); }
        protected void HtmlNOlogin_Click(object sender, EventArgs e) { Response.Redirect("~/frmReadIDCare.aspx?dengluleibie=nologin"); }
        private void InitializeComponent() { }
    }
}