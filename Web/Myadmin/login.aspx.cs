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
            // 检查两个参数是否都有值，没有则直接返回空列表
            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(systemName))
            {
                return new List<product_pushnews>();
            }

            // 两个参数都有值，执行查询
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
            //var i = Web.login.
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

        SqlConnection conn = null;
        SqlConnection conn2 = null;
        SqlConnection conn3 = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;

        protected void xitong_select(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=bds28428944.my3w.com;Initial Catalog=bds28428944_db;User ID=bds28428944;Password=07910Lyh");  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sqlStr = "";
            if (DropDownList3.SelectedItem.Text == "云合未来")
            {
                sqlStr = "select systemName from all_systems where type = '1';";
            }
            if (DropDownList3.SelectedItem.Text == "其他")
            {
                sqlStr = "select systemName from all_systems where type != '1';";
            }
            if (sqlStr != "")
            {
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                DropDownList1.Items.Clear();
                int a = 0;
                List<string> itemi = new List<string>();
                while (str.Read())
                {
                    a = a + 1;
                    itemi.Add(str[0].ToString());
                }
                DropDownList1.DataSource = itemi;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("选择", "绑定数据"));
            }
            else
            {
                DropDownList1.Items.Clear();
                DropDownList1.Items.Insert(0, new ListItem("选择", "绑定数据"));
            }
            
        }

        protected void bian(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "云合人事管理系统")
            {
                conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sqlStr = "select L from gongzi_renyuan GROUP BY L;";
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                DropDownList2.Items.Clear();
                int a = 0;
                List<string> itemi = new List<string>();
                while (str.Read())
                {
                    a = a + 1;
                    itemi.Add(str[0].ToString());
                }
                DropDownList2.DataSource = itemi;
                DropDownList2.DataBind();
            }
            else if (DropDownList1.SelectedItem.Text == "云合未来进销存系统")
            {
                conn3 = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yh_jinxiaocun_excel;Uid=sa;Pwd=Lyh07910_001;");
                if (conn3.State == ConnectionState.Closed)
                {
                    conn3.Open();
                }
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
            else if (DropDownList1.SelectedItem.Text == "云合未来财务系统")
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
            else if (DropDownList1.SelectedItem.Text.Equals("云合排产管理系统"))
            {
                DropDownList2.Items.Clear();
                DropDownList2.DataSource = UserInfoService.companyList();
                DropDownList2.DataBind();
            }
        }


        //public static void HtmlBtn_Click(string xitong, string company, string username, string password)
        //{
        //    string txtSAPPassword = password;
        //    string servename = xitong;//这是获取选中的文本值

        //    string gs_name = company;


        //    if (servename.ToString() == "云合人事管理系统")
        //    {
        //        System.Web.SessionState.HttpSessionState Session = new System.Web.SessionState.HttpSessionState();
        //        HttpServerUtility Server = new HttpServerUtility();


        //        Session.Timeout = 10000;
        //        Session["username"] = username;
        //        Session["gs_name"] = gs_name;

        //        if (gs_name != null || username != null || txtSAPPassword != null)
        //        {
        //            if (gs_name != null && username != null && txtSAPPassword != null)
        //            {
        //                string connStr = ConfigurationManager.AppSettings["yao"];
        //                var conn = new SqlConnection(connStr);
        //                //conn = new SqlConnection(connStr);
        //                if (conn.State == ConnectionState.Closed)
        //                {
        //                    conn.Open();
        //                }
        //                //str = conn.BeginTransaction();
        //                string sqlStr = "select id from gongzi_renyuan where L='" + gs_name + "' and I='" + username + "' and J='" + txtSAPPassword + "';";
        //                var cmd = new SqlCommand(sqlStr, conn);
        //                int id = Convert.ToInt32(cmd.ExecuteScalar());
        //                if (id != 0)
        //                {

        //                    conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;MultipleActiveResultSets=true;Uid=bds28428944;Pwd=07910Lyh;");  //数据库连接。
        //                    if (conn.State == ConnectionState.Closed)
        //                    {
        //                        conn.Open();
        //                    }
        //                    string now = DateTime.Now.ToShortDateString().ToString();
        //                    string this_sql = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3 from control_soft_time where name ='" + gs_name.Trim() + "' and soft_name='人事'";
        //                    cmd = new SqlCommand(this_sql, conn);
        //                    var str = cmd.ExecuteReader();
        //                    string thisNum = "";
        //                    int a = 0;
        //                    List<string> itemi = new List<string>();
        //                    while (str.Read())
        //                    {
        //                        thisNum = str["mark3"].ToString().Trim();
        //                        if (!thisNum.Equals(""))
        //                        {
        //                            thisNum = thisNum.Split(':')[1];
        //                            thisNum = thisNum.Replace("(", "");
        //                            thisNum = thisNum.Replace(")", "");
        //                        }

        //                    }
        //                    string[] b = gs_name.Split('_');
        //                    Session["gongsi"] = b[0];
        //                    Session["id1"] = id;
        //                    Session["userNum"] = thisNum;
        //                    Server.Transfer("../Personnel/index.aspx");

        //                }
        //                else
        //                {
        //                    Response.Write("<script id='alert'>alert('输入密码有误，请重试')</script>");
        //                }
        //                conn.Close();
        //            }
        //        }
        //    }
        //    else if (servename.ToString() == "云合未来进销存系统")
        //    {
        //        UserModel userModel = new UserModel();
        //        string msg = "";
        //        yh_jinxiaocun_user user;
        //        try
        //        {
        //            user = userModel.login(gs_name.Trim(), username.Trim(), txtSAPPassword.Trim());
        //        }
        //        catch
        //        {
        //            Response.Write("<script>alert('网络超时，请稍后再试。')</script>");
        //            return;
        //        }

        //        if (user != null)
        //        {
        //            if (user.Btype.Equals("锁定"))
        //            {
        //                msg = "用户已被锁定！";
        //            }

        //            else
        //            {

        //                conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=07910Lyh;");  //数据库连接。
        //                if (conn.State == ConnectionState.Closed)
        //                {
        //                    conn.Open();
        //                }
        //                string now = DateTime.Now.ToShortDateString().ToString();
        //                string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3 from control_soft_time where name ='" + gs_name.Trim() + "' and soft_name='进销存'";
        //                cmd = new SqlCommand(sqlStr, conn);
        //                str = cmd.ExecuteReader();
        //                string thisNum = "";
        //                int a = 0;
        //                List<string> itemi = new List<string>();
        //                while (str.Read())
        //                {
        //                    if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
        //                    {
        //                        if (str["endtime"].Equals(1))
        //                        {
        //                            Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>");
        //                            return;
        //                        }
        //                        if (str["mark2"].Equals(1))
        //                        {
        //                            Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>");
        //                            return;
        //                        }
        //                    }
        //                    thisNum = str["mark3"].ToString().Trim();
        //                    if (!thisNum.Equals(""))
        //                    {
        //                        thisNum = thisNum.Split(':')[1];
        //                        thisNum = thisNum.Replace("(", "");
        //                        thisNum = thisNum.Replace(")", "");
        //                    }

        //                }
        //                Session["userNum"] = thisNum;
        //                Session.Timeout = 10000;
        //                Session["user"] = user;
        //                Response.Redirect("~/frmMain.aspx");
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            msg = "用户名密码错误！";
        //        }
        //        Response.Write("<script id='alert'>alert('" + msg + "')</script>");
        //    }
        //    else if (servename.ToString() == "云合未来财务系统")
        //    {
        //        AccountService accountService = new AccountService(false);
        //        string token = accountService.login(gs_name.Trim(), username.Trim(), txtSAPPassword.Trim());
        //        if (token.Equals(""))
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('用户名密码错误！')", true);
        //        }
        //        else
        //        {
        //            conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=07910Lyh;");  //数据库连接。
        //            if (conn.State == ConnectionState.Closed)
        //            {
        //                conn.Open();
        //            }
        //            string now = DateTime.Now.ToShortDateString().ToString();
        //            string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3 from control_soft_time where name ='" + gs_name.Trim() + "' and soft_name='财务'";
        //            cmd = new SqlCommand(sqlStr, conn);
        //            str = cmd.ExecuteReader();
        //            string thisNum = "";
        //            int a = 0;
        //            List<string> itemi = new List<string>();
        //            while (str.Read())
        //            {
        //                if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
        //                {
        //                    if (str["endtime"].Equals(1))
        //                    {
        //                        Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>");
        //                        return;
        //                    }
        //                    if (str["mark2"].Equals(1))
        //                    {
        //                        Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>");
        //                        return;
        //                    }
        //                }
        //                thisNum = str["mark3"].ToString().Trim();
        //                if (!thisNum.Equals(""))
        //                {
        //                    thisNum = thisNum.Split(':')[1];
        //                    thisNum = thisNum.Replace("(", "");
        //                    thisNum = thisNum.Replace(")", "");
        //                }

        //            }
        //            Session["userNum"] = thisNum;
        //            FinanceToken.getFinanceCheckToken().setToken(token);
        //            Response.Redirect("../finance/web/view/index.aspx");
        //        }
        //    }
        //    else if (servename.ToString().Equals("云合排产管理系统"))
        //    {
        //        int state = 0;
        //        try
        //        {
        //            if (!UserInfoService.login(username.Trim(), txtSAPPassword.Trim(), gs_name.Trim()))
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('用户名密码错误或用户被禁用！')", true);
        //            }
        //            else
        //            {
        //                conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=07910Lyh;");  //数据库连接。
        //                if (conn.State == ConnectionState.Closed)
        //                {
        //                    conn.Open();
        //                }
        //                string now = DateTime.Now.ToShortDateString().ToString();
        //                string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3 from control_soft_time where name ='" + gs_name + "' and soft_name='排产'";
        //                cmd = new SqlCommand(sqlStr, conn);
        //                str = cmd.ExecuteReader();
        //                string thisNum = "";
        //                int a = 0;
        //                List<string> itemi = new List<string>();
        //                while (str.Read())
        //                {
        //                    if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
        //                    {
        //                        if (str["endtime"].Equals(1))
        //                        {
        //                            Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>");
        //                            return;
        //                        }
        //                        if (str["mark2"].Equals(1))
        //                        {
        //                            Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>");
        //                            return;
        //                        }
        //                    }
        //                    thisNum = str["mark3"].ToString().Trim();
        //                    if (!thisNum.Equals(""))
        //                    {
        //                        thisNum = thisNum.Split(':')[1];
        //                        thisNum = thisNum.Replace("(", "");
        //                        thisNum = thisNum.Replace(")", "");
        //                    }

        //                }

        //                int ky_rongliang = FinanceSpace.getFinanceSpace().getMark4_all(gs_name, "排产");
        //                int sy_rongliang = FinanceSpace.getFinanceSpace().getUseMark4_all(gs_name, "排产");

        //                if (sy_rongliang >= ky_rongliang)
        //                {
        //                    Response.Write("<script>alert('您在我公司租用的数据库容量已超上限，该系统暂时无法使用。请联系我公司，官方微信号：1623005800。')</script>");
        //                    return;
        //                }
        //                Session["userNum"] = thisNum;
        //                Response.Redirect("../scheduling/web/index.html");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write(ex.Message);
        //        }
        //    }
        //}

        protected void HtmlBtn_Click(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string txtSAPPassword = Request.Form["password"];
            string servename = "";
            string gs_name = "";

            string _DropDownList1 = Request.Form["_DropDownList1"].ToString();
            string _DropDownList2 = Request.Form["_DropDownList2"].ToString();
            if (_DropDownList1 == null || _DropDownList1 == "")
            {
                servename = DropDownList1.SelectedItem.Text;//这是获取选中的文本值
            }
            else {
                servename = _DropDownList1;
            }
            if (_DropDownList2 == null || _DropDownList2 == "")
            {
                gs_name = DropDownList2.SelectedItem.Text;
            }
            else
            {
                gs_name = _DropDownList2;
            }

            if (servename == "选择")
            {
                Response.Write("<script id='alert'>alert('请选择数据库!')</script>");
                return;
            }
            
            if (servename.ToString() == "云合人事管理系统")
            {
                Session.Timeout = 10000;
                Session["username"] = username;
                Session["gs_name"] = gs_name;

                if (gs_name != null || username != null || txtSAPPassword != null)
                {
                    if (gs_name != null && username != null && txtSAPPassword != null)
                    {
                        string connStr = ConfigurationManager.AppSettings["yao"];
                        conn = new SqlConnection(connStr);
                        //conn = new SqlConnection(connStr);
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        //str = conn.BeginTransaction();
                        string sqlStr = "select id from gongzi_renyuan where L='" + gs_name + "' and I='" + username + "' and J='" + txtSAPPassword + "';";
                        cmd = new SqlCommand(sqlStr, conn);
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        if (id != 0)
                        {

                            conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;MultipleActiveResultSets=true;Uid=bds28428944;Pwd=07910Lyh;");  //数据库连接。
                            conn2 = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yh_notice;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
                            if (conn.State == ConnectionState.Closed)
                            {
                                conn.Open();
                            }
                            if (conn2.State == ConnectionState.Closed)
                            {
                                conn2.Open();
                            }
                            string now = DateTime.Now.ToShortDateString().ToString();
                            string this_sql = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3,isnull(mark5,'') as mark5,isnull(mark4,'') as mark4 from control_soft_time where name ='" + gs_name.Trim() + "' and soft_name='人事'";
                            cmd = new SqlCommand(this_sql, conn);
                            str = cmd.ExecuteReader();
                            string thisNum = "";
                            string thisStorageSpace = ""; 
                            int a = 0;
                            List<string> itemi = new List<string>();
                            while (str.Read())
                            {
                                if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
                                {
                                    if (str["mark5"] == null || !str["mark5"].ToString().Contains("PC端"))
                                    {
                                        Response.Write("<script>alert('您没有当前使用端权限，请联系我公司续费或者购买系统。')</script>");
                                        return;
                                    }

                                    if (str["endtime"].Equals(1))
                                    {
                                        Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>");
                                        return;
                                    }
                                    if (str["mark2"].Equals(1))
                                    {
                                        Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>");
                                        return;
                                    }

                                    thisStorageSpace = str["mark4"].ToString().Trim();
                                   
                                }
                                thisNum = str["mark3"].ToString().Trim();
                                if (!thisNum.Equals(""))
                                {
                                    thisNum = thisNum.Split(':')[1];
                                    thisNum = thisNum.Replace("(","");
                                    thisNum = thisNum.Replace(")", "");
                                }
                                
                            }
                            double totalDBSizeKB = GetDatabaseSizeByRenShi(gs_name.Trim());
                            string[] b = gs_name.Split('_');
                            Session["gongsi"] = b[0];
                            Session["id1"] = id;
                            Session["userNum"] = thisNum;

                            HttpCookie storageCookie = new HttpCookie("storageSpace");
                            storageCookie.Value = thisStorageSpace;
                            storageCookie.Expires = DateTime.Now.AddDays(7);
                            Response.Cookies.Add(storageCookie);

                            HttpCookie dbSizeCookie = new HttpCookie("dbSizeKB");
                            dbSizeCookie.Value = totalDBSizeKB.ToString();
                            dbSizeCookie.Expires = DateTime.Now.AddDays(7);
                            Response.Cookies.Add(dbSizeCookie);

                            Server.Transfer("../Personnel/index.aspx");

                        }
                        else
                        {
                            Response.Write("<script id='alert'>alert('输入密码有误，请重试')</script>");
                        }
                        conn.Close();
                    }
                }
            }
            else if (servename.ToString() == "云合未来进销存系统")
            {
                UserModel userModel = new UserModel();
                conn3 = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yh_jinxiaocun_excel;Uid=sa;Pwd=Lyh07910_001;");
                if (conn3.State == ConnectionState.Closed)
                {
                    conn3.Open();
                }
                Session["shujuku"] = 0;
                string sqlStr3 = "select * from yh_jinxiaocun_user_mssql where gongsi = '" + gs_name + "' and name = '" + username + "' and password = '" + txtSAPPassword + "'";

                cmd = new SqlCommand(sqlStr3, conn3);
                str = cmd.ExecuteReader();


                if (str.Read()) // 移动到第一行
                {
                    Session["shujuku"] = 1;
                }

                string msg = "";
                yh_jinxiaocun_user user;
                try
                {
                    user = userModel.login(gs_name.Trim(), username.Trim(), txtSAPPassword.Trim());
                }
                catch
                {
                    Response.Write("<script>alert('网络超时，请稍后再试。')</script>");
                    return;
                }
                
                if (user != null)
                {
                    if (user.Btype.Equals("锁定"))
                    {
                        msg = "用户已被锁定！";
                    }
              
                    else
                    {

                        conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=07910Lyh;");  //数据库连接。
                        conn2 = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yh_notice;Uid=sa;Pwd=Lyh07910_001;");
                       
                        //SqlConnection conn4 = new SqlConnection("Data Source=server;Initial Catalog=yh_jinxiaocun_pc;User ID=sa;Password=Lyh07910_001;");

                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        if (conn2.State == ConnectionState.Closed)
                        {
                            conn2.Open();
                        }
      
                        //if (conn4.State == ConnectionState.Closed)
                        //{
                        //    conn4.Open();
                        //}


                        string now = DateTime.Now.ToShortDateString().ToString();
                        string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3,isnull(mark5,'') as mark5,isnull(mark4,'') as mark4 from control_soft_time where name ='" + gs_name.Trim() + "' and soft_name='进销存'";
                        cmd = new SqlCommand(sqlStr, conn);
                        str = cmd.ExecuteReader();
                        string thisNum = "";
                        string thisStorageSpace = ""; 
                        int a = 0;
                        List<string> itemi = new List<string>();
                        while (str.Read())
                        {
                            if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
                            {
                                if (str["mark5"] == null || !str["mark5"].ToString().Contains("PC端"))
                                {
                                    Response.Write("<script>alert('您没有当前使用端权限，请联系我公司续费或者购买系统。')</script>");
                                    return;
                                }
                                if (str["endtime"].Equals(1))
                                {
                                    Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>");
                                    return;
                                }
                                if (str["mark2"].Equals(1))
                                {
                                    Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>");
                                    return;
                                }
                                thisStorageSpace = str["mark4"].ToString().Trim();
                            }
                            thisNum = str["mark3"].ToString().Trim();
                            if (!thisNum.Equals(""))
                            {
                                thisNum = thisNum.Split(':')[1];
                                thisNum = thisNum.Replace("(", "");
                                thisNum = thisNum.Replace(")", "");
                            }

                        }

                        double totalDBSizeKB = GetDatabaseSizeByJXC(gs_name.Trim());

                       

                        Session["userNum"] = thisNum;
                        Session.Timeout = 10000;
                        Session["user"] = user;

                        HttpCookie storageCookie = new HttpCookie("storageSpace");
                        storageCookie.Value = thisStorageSpace;
                        storageCookie.Expires = DateTime.Now.AddDays(7);

                        HttpCookie dbSizeCookie = new HttpCookie("dbSizeKB");
                        dbSizeCookie.Value = totalDBSizeKB.ToString();
                        dbSizeCookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(dbSizeCookie);

                        Response.Cookies.Add(storageCookie);
                        Response.Redirect("~/frmMain.aspx");
                        return;
                    }
                }
                else
                {
                    msg = "用户名密码错误！";
                }
                Response.Write("<script id='alert'>alert('" + msg + "')</script>");
            }
            else if (servename.ToString() == "云合未来财务系统")
            {
                AccountService accountService = new AccountService(false);
                string token = accountService.login(gs_name.Trim(), username.Trim(), txtSAPPassword.Trim());
                if (token.Equals(""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('用户名密码错误！')", true);
                }
                else
                {

                    conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=07910Lyh;");  //数据库连接。
                    conn2 = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yh_notice;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (conn2.State == ConnectionState.Closed)
                    {
                        conn2.Open();
                    }
                    string now = DateTime.Now.ToShortDateString().ToString();
                    string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3,isnull(mark5,'') as mark5,isnull(mark4,'') as mark4 from control_soft_time where name ='" + gs_name.Trim() + "' and soft_name='财务'";
                    cmd = new SqlCommand(sqlStr, conn);
                    str = cmd.ExecuteReader();
                    string thisStorageSpace = ""; 
                    string thisNum = "";
                    int a = 0;
                    List<string> itemi = new List<string>();
                    while (str.Read())
                    {
                        if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
                        {
                            if (str["mark5"] == null || !str["mark5"].ToString().Contains("PC端"))
                            {
                                Response.Write("<script>alert('您没有当前使用端权限，请联系我公司续费或者购买系统。')</script>");
                                return;
                            }
                            if (str["endtime"].Equals(1))
                            {
                                Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>");
                                return;
                            }
                            if (str["mark2"].Equals(1))
                            {
                                Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>");
                                return;
                            }
                            thisStorageSpace = str["mark4"].ToString().Trim();
                        }
                        thisNum = str["mark3"].ToString().Trim();
                        if (!thisNum.Equals(""))
                        {
                            thisNum = thisNum.Split(':')[1];
                            thisNum = thisNum.Replace("(", "");
                            thisNum = thisNum.Replace(")", "");
                        }

                    }

                    double totalDBSizeKB = GetDatabaseSizeByCW(gs_name.Trim());

                    Session["userNum"] = thisNum;
                    FinanceToken.getFinanceCheckToken().setToken(token);
                    HttpCookie storageCookie = new HttpCookie("storageSpace");
                    storageCookie.Value = thisStorageSpace;
                    storageCookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(storageCookie);

                    HttpCookie dbSizeCookie = new HttpCookie("dbSizeKB");
                    dbSizeCookie.Value = totalDBSizeKB.ToString();
                    dbSizeCookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(dbSizeCookie);

                    Response.Redirect("../finance/web/view/index.aspx");
                }
            }
            else if (servename.ToString().Equals("云合排产管理系统")) {
                int state = 0;
                try
                {
                    if (!UserInfoService.login(username.Trim(), txtSAPPassword.Trim(), gs_name.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('用户名密码错误或用户被禁用！')", true);
                    }
                    else
                    {
                        conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=07910Lyh;");  //数据库连接。
                        conn2 = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yh_notice;Uid=sa;Pwd=Lyh07910_001;");
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        if (conn2.State == ConnectionState.Closed)
                        {
                            conn2.Open();
                        }
                        string now = DateTime.Now.ToShortDateString().ToString();
                        string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3,isnull(mark5,'') as mark5,isnull(mark4,'') as mark4 from control_soft_time where name ='" + gs_name + "' and soft_name='排产'";
                        cmd = new SqlCommand(sqlStr, conn);
                        str = cmd.ExecuteReader();
                        string thisNum = "";
                        string thisStorageSpace = ""; 
                        int a = 0;
                        List<string> itemi = new List<string>();
                        while (str.Read())
                        {
                            if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
                            {
                                if (str["mark5"] == null || !str["mark5"].ToString().Contains("PC端"))
                                {
                                    Response.Write("<script>alert('您没有当前使用端权限，请联系我公司续费或者购买系统。')</script>");
                                    return;
                                }
                                if (str["endtime"].Equals(1))
                                {
                                    Response.Write("<script>alert('工具到期，请联系我公司续费。')</script>");
                                    return;
                                }
                                if (str["mark2"].Equals(1))
                                {
                                    Response.Write("<script>alert('服务器到期，请联系我公司续费。')</script>");
                                    return;
                                }
                                thisStorageSpace = str["mark4"].ToString().Trim();
                            }
                            thisNum = str["mark3"].ToString().Trim();
                            if (!thisNum.Equals(""))
                            {
                                thisNum = thisNum.Split(':')[1];
                                thisNum = thisNum.Replace("(", "");
                                thisNum = thisNum.Replace(")", "");
                            }

                        }

                        double totalDBSizeKB = GetDatabaseSizeByPC(gs_name.Trim());

                        int ky_rongliang = FinanceSpace.getFinanceSpace().getMark4_all(gs_name,"排产");
                        int sy_rongliang = FinanceSpace.getFinanceSpace().getUseMark4_all(gs_name, "排产");

                        if (sy_rongliang >= ky_rongliang)
                        {
                            Response.Write("<script>alert('您在我公司租用的数据库容量已超上限，该系统暂时无法使用。请联系我公司，官方微信号：1623005800。')</script>");
                            return;
                        }
                        Session["userNum"] = thisNum;
                        HttpCookie storageCookie = new HttpCookie("storageSpace");
                        storageCookie.Value = thisStorageSpace;
                        storageCookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(storageCookie);

                        HttpCookie dbSizeCookie = new HttpCookie("dbSizeKB");
                        dbSizeCookie.Value = totalDBSizeKB.ToString();
                        dbSizeCookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(dbSizeCookie);

                        Response.Redirect("../scheduling/web/index.html");
                    }
                }
                catch (Exception ex) {
                    Response.Write(ex.Message);
                }
            }
        }


        private double GetDatabaseSizeByRenShi(string companyName)
        {
            double totalSizeKB = 0;

            // 定义表名和对应的公司字段名
            var tables = new Dictionary<string, string>
            {
                { "gongzi_dongtaimingxi", "gongsi" },
                { "gongzi_gongzimingxi", "BD" },
                { "gongzi_jianliguanli", "gongsi" },
                { "gongzi_kaoqinjilu", "AO" },
                { "gongzi_kaoqinmingxi", "K" },
                { "gongzi_lizhishenpi", "gongsi" },
                { "gongzi_shenpi", "gongsi" },
                { "gongzi_shezhi", "gongsi" },
                { "gongzi_renyuan", "L" },
                { "gongzi_qingjiashenpi", "gongsi" }
            };

            // 处理公司名：去掉 _hr 后缀
            string searchCompanyName = companyName;
            if (searchCompanyName.EndsWith("_hr"))
            {
                searchCompanyName = searchCompanyName.Substring(0, searchCompanyName.Length - 3);
            }

            try
            {
                using (SqlConnection dbConn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;"))
                {
                    dbConn.Open();

                    foreach (var table in tables)
                    {
                        string tableName = table.Key;
                        string companyColumn = table.Value;

                        try
                        {
                            // 1. 使用模糊搜索查询该公司的数据行数
                            string countSql = string.Format(
                                "SELECT COUNT(*) FROM {0} WHERE {1} LIKE @companyName",
                                tableName, companyColumn);

                            using (SqlCommand countCmd = new SqlCommand(countSql, dbConn))
                            {
                                // 使用 % 进行模糊匹配
                                countCmd.Parameters.AddWithValue("@companyName", "%" + searchCompanyName + "%");
                                int rowCount = (int)countCmd.ExecuteScalar();

                                System.Diagnostics.Debug.WriteLine(string.Format(
                                    "表 {0}: 模糊匹配行数 = {1}", tableName, rowCount));

                                if (rowCount > 0)
                                {
                                    // 2. 获取该表的总大小
                                    string spaceSql = "EXEC sp_spaceused @tableName";
                                    using (SqlCommand spaceCmd = new SqlCommand(spaceSql, dbConn))
                                    {
                                        spaceCmd.Parameters.AddWithValue("@tableName", tableName);
                                        using (SqlDataReader reader = spaceCmd.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                // 获取表总大小（KB）
                                                string totalDataSize = reader["data"].ToString();
                                                double totalSizeKB_Table = ParseSizeToKB(totalDataSize);

                                                // 获取表总行数
                                                string totalRows = reader["rows"].ToString();
                                                int totalRowCount = int.Parse(totalRows);

                                                // 3. 按行数比例估算该公司占用的空间
                                                if (totalRowCount > 0)
                                                {
                                                    double ratio = (double)rowCount / totalRowCount;
                                                    double companySizeKB = totalSizeKB_Table * ratio;
                                                    totalSizeKB += companySizeKB;

                                                    System.Diagnostics.Debug.WriteLine(string.Format(
                                                        "表 {0}: 公司行数={1}, 总行数={2}, 比例={3:P}, 公司大小={4:F2} KB",
                                                        tableName, rowCount, totalRowCount, ratio, companySizeKB));
                                                }
                                            }
                                            reader.Close();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("获取表 {0} 大小失败: {1}", tableName, ex.Message));
                        }
                    }

                    dbConn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("获取数据库大小失败: " + ex.Message);
                totalSizeKB = 0;
            }

            return totalSizeKB;
        }


        private double GetDatabaseSizeByJXC(string companyName)
        {
            double totalSizeKB = 0;

            // 定义表名和对应的公司字段名
            var tables = new Dictionary<string, string>
            {
                { "yh_jinxiaocun_cangku_mssql", "gongsi" },
                { "yh_jinxiaocun_chuhuofang_mssql", "gongsi" },
                { "yh_jinxiaocun_jichuziliao_mssql", "gs_name" },
                { "yh_jinxiaocun_jinhuofang_mssql", "gongsi" },
                { "yh_jinxiaocun_mingxi_mssql", "gs_name" },
                { "yh_jinxiaocun_qichushu_mssql", "gs_name" },
                { "yh_jinxiaocun_tuihuomingxi_mssql", "gs_name" },
                { "yh_jinxiaocun_user_mssql", "gongsi" },
                { "yh_jinxiaocun_zhengli_mssql", "gs_name" },
            };

            string searchCompanyName = companyName;

            try
            {
                using (SqlConnection dbConn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yh_jinxiaocun_excel;Uid=sa;Pwd=Lyh07910_001;"))
                {
                    dbConn.Open();

                    foreach (var table in tables)
                    {
                        string tableName = table.Key;
                        string companyColumn = table.Value;

                        try
                        {
                            // 1. 使用模糊搜索查询该公司的数据行数
                            string countSql = string.Format(
                                "SELECT COUNT(*) FROM {0} WHERE {1} LIKE @companyName",
                                tableName, companyColumn);

                            using (SqlCommand countCmd = new SqlCommand(countSql, dbConn))
                            {
                                // 使用 % 进行模糊匹配
                                countCmd.Parameters.AddWithValue("@companyName", "%" + searchCompanyName + "%");
                                int rowCount = (int)countCmd.ExecuteScalar();

                                System.Diagnostics.Debug.WriteLine(string.Format(
                                    "表 {0}: 模糊匹配行数 = {1}", tableName, rowCount));

                                if (rowCount > 0)
                                {
                                    // 2. 获取该表的总大小
                                    string spaceSql = "EXEC sp_spaceused @tableName";
                                    using (SqlCommand spaceCmd = new SqlCommand(spaceSql, dbConn))
                                    {
                                        spaceCmd.Parameters.AddWithValue("@tableName", tableName);
                                        using (SqlDataReader reader = spaceCmd.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                // 获取表总大小（KB）
                                                string totalDataSize = reader["data"].ToString();
                                                double totalSizeKB_Table = ParseSizeToKB(totalDataSize);

                                                // 获取表总行数
                                                string totalRows = reader["rows"].ToString();
                                                int totalRowCount = int.Parse(totalRows);

                                                // 3. 按行数比例估算该公司占用的空间
                                                if (totalRowCount > 0)
                                                {
                                                    double ratio = (double)rowCount / totalRowCount;
                                                    double companySizeKB = totalSizeKB_Table * ratio;
                                                    totalSizeKB += companySizeKB;

                                                    System.Diagnostics.Debug.WriteLine(string.Format(
                                                        "表 {0}: 公司行数={1}, 总行数={2}, 比例={3:P}, 公司大小={4:F2} KB",
                                                        tableName, rowCount, totalRowCount, ratio, companySizeKB));
                                                }
                                            }
                                            reader.Close();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("获取表 {0} 大小失败: {1}", tableName, ex.Message));
                        }
                    }

                    dbConn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("获取数据库大小失败: " + ex.Message);
                totalSizeKB = 0;
            }

            return totalSizeKB;
        }

        private double GetDatabaseSizeByCW(string companyName)
        {
            double totalSizeKB = 0;

            // 定义表名和对应的公司字段名
            var tables = new Dictionary<string, string>
            {
                { "Account", "company" },
                { "Accounting", "company" },
                { "Department", "company" },
                { "FinancingExpenditure", "company" },
                { "FinancingIncome", "company" },
                { "gongzimingxi", "company" },
                { "InvestmentExpenditure", "company" },
                { "InvestmentIncome", "company" },
                { "Invoice", "company" },
                { "InvoicePeizhi", "company" },
                { "KehuPeizhi", "company" },
                { "ManagementExpenditure", "company" },
                { "ManagementIncome", "company" },
                { "shuilvPeizhi", "company" },
                { "SimpleAccounting", "company" },
                { "SimpleData", "company" },
                { "VoucherSummary", "company" },
                { "VoucherWord", "company" },
                { "waibiPeizhi", "company" },
                { "ysyfpeizhi", "company" }                
            };

            string searchCompanyName = companyName;

            try
            {
                using (SqlConnection dbConn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=Finance;Uid=sa;Pwd=Lyh07910_001;"))
                {
                    dbConn.Open();

                    foreach (var table in tables)
                    {
                        string tableName = table.Key;
                        string companyColumn = table.Value;

                        try
                        {
                            // 1. 使用模糊搜索查询该公司的数据行数
                            string countSql = string.Format(
                                "SELECT COUNT(*) FROM {0} WHERE {1} LIKE @companyName",
                                tableName, companyColumn);

                            using (SqlCommand countCmd = new SqlCommand(countSql, dbConn))
                            {
                                // 使用 % 进行模糊匹配
                                countCmd.Parameters.AddWithValue("@companyName", "%" + searchCompanyName + "%");
                                int rowCount = (int)countCmd.ExecuteScalar();

                                System.Diagnostics.Debug.WriteLine(string.Format(
                                    "表 {0}: 模糊匹配行数 = {1}", tableName, rowCount));

                                if (rowCount > 0)
                                {
                                    // 2. 获取该表的总大小
                                    string spaceSql = "EXEC sp_spaceused @tableName";
                                    using (SqlCommand spaceCmd = new SqlCommand(spaceSql, dbConn))
                                    {
                                        spaceCmd.Parameters.AddWithValue("@tableName", tableName);
                                        using (SqlDataReader reader = spaceCmd.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                // 获取表总大小（KB）
                                                string totalDataSize = reader["data"].ToString();
                                                double totalSizeKB_Table = ParseSizeToKB(totalDataSize);

                                                // 获取表总行数
                                                string totalRows = reader["rows"].ToString();
                                                int totalRowCount = int.Parse(totalRows);

                                                // 3. 按行数比例估算该公司占用的空间
                                                if (totalRowCount > 0)
                                                {
                                                    double ratio = (double)rowCount / totalRowCount;
                                                    double companySizeKB = totalSizeKB_Table * ratio;
                                                    totalSizeKB += companySizeKB;

                                                    System.Diagnostics.Debug.WriteLine(string.Format(
                                                        "表 {0}: 公司行数={1}, 总行数={2}, 比例={3:P}, 公司大小={4:F2} KB",
                                                        tableName, rowCount, totalRowCount, ratio, companySizeKB));
                                                }
                                            }
                                            reader.Close();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("获取表 {0} 大小失败: {1}", tableName, ex.Message));
                        }
                    }

                    dbConn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("获取数据库大小失败: " + ex.Message);
                totalSizeKB = 0;
            }

            return totalSizeKB;
        }

        private double GetDatabaseSizeByPC(string companyName)
        {
            double totalSizeKB = 0;

            // 定义表名和对应的公司字段名
            var tables = new Dictionary<string, string>
            {
                { "bom_info", "company" },
                { "department", "company" },
                { "holiday_config", "company" },
                { "module_type", "company" },
                { "order_check", "company" },
                { "order_info", "company" },
                { "paibanbiao_info", "remarks1" },
                { "paibanbiao_renyuan", "company" },
                { "paibanbiao_detail", "company" },
                { "shengchanxian", "gongsi" },
                { "time_config", "company" },
                { "user_info", "company" },
                { "work_detail", "company" }
            };

            try
            {
                using (SqlConnection dbConn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=scheduling;Uid=sa;Pwd=Lyh07910_001;"))
                {
                    dbConn.Open();

                    foreach (var table in tables)
                    {
                        string tableName = table.Key;
                        string companyColumn = table.Value;

                        string searchCompanyName = companyName;

                        try
                        {
                            // 1. 使用模糊搜索查询该公司的数据行数
                            string countSql = string.Format(
                                "SELECT COUNT(*) FROM {0} WHERE {1} LIKE @companyName",
                                tableName, companyColumn);

                            using (SqlCommand countCmd = new SqlCommand(countSql, dbConn))
                            {
                                // 使用 % 进行模糊匹配
                                countCmd.Parameters.AddWithValue("@companyName", "%" + searchCompanyName + "%");
                                int rowCount = (int)countCmd.ExecuteScalar();

                                System.Diagnostics.Debug.WriteLine(string.Format(
                                    "表 {0}: 模糊匹配行数 = {1}", tableName, rowCount));

                                if (rowCount > 0)
                                {
                                    // 2. 获取该表的总大小
                                    string spaceSql = "EXEC sp_spaceused @tableName";
                                    using (SqlCommand spaceCmd = new SqlCommand(spaceSql, dbConn))
                                    {
                                        spaceCmd.Parameters.AddWithValue("@tableName", tableName);
                                        using (SqlDataReader reader = spaceCmd.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                // 获取表总大小（KB）
                                                string totalDataSize = reader["data"].ToString();
                                                double totalSizeKB_Table = ParseSizeToKB(totalDataSize);

                                                // 获取表总行数
                                                string totalRows = reader["rows"].ToString();
                                                int totalRowCount = int.Parse(totalRows);

                                                // 3. 按行数比例估算该公司占用的空间
                                                if (totalRowCount > 0)
                                                {
                                                    double ratio = (double)rowCount / totalRowCount;
                                                    double companySizeKB = totalSizeKB_Table * ratio;
                                                    totalSizeKB += companySizeKB;

                                                    System.Diagnostics.Debug.WriteLine(string.Format(
                                                        "表 {0}: 公司行数={1}, 总行数={2}, 比例={3:P}, 公司大小={4:F2} KB",
                                                        tableName, rowCount, totalRowCount, ratio, companySizeKB));
                                                }
                                            }
                                            reader.Close();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("获取表 {0} 大小失败: {1}", tableName, ex.Message));
                        }
                    }

                    dbConn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("获取数据库大小失败: " + ex.Message);
                totalSizeKB = 0;
            }

            return totalSizeKB;
        }





        /// <summary>
        /// 解析大小字符串为 KB
        /// </summary>
        private double ParseSizeToKB(string sizeStr)
        {
            if (string.IsNullOrEmpty(sizeStr)) return 0;

            sizeStr = sizeStr.Trim();

            try
            {
                // 如果是 "8 KB"，按 0 处理（空表）
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


        protected void HtmlBtcreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmUserManger.aspx");
        }

        protected void Btchangepas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('请联系管理员！')", true);
            //Response.Redirect("~/Myadmin/changepassword.aspx");
        }

        protected void Btmain_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmReadIDCare.aspx");

        }

        protected void HtmlNOlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmReadIDCare.aspx?dengluleibie=nologin");


        }

        private void InitializeComponent()
        {

        }


    }
}