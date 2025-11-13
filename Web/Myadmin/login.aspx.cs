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
                            string this_sql = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3 from control_soft_time where name ='" + gs_name.Trim() + "' and soft_name='人事'";
                            cmd = new SqlCommand(this_sql, conn);
                            str = cmd.ExecuteReader();
                            string thisNum = "";
                            int a = 0;
                            List<string> itemi = new List<string>();
                            while (str.Read())
                            {
                                if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
                                {
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
                                }
                                thisNum = str["mark3"].ToString().Trim();
                                if (!thisNum.Equals(""))
                                {
                                    thisNum = thisNum.Split(':')[1];
                                    thisNum = thisNum.Replace("(","");
                                    thisNum = thisNum.Replace(")", "");
                                }
                                
                            }
                            string[] b = gs_name.Split('_');
                            Session["gongsi"] = b[0];
                            Session["id1"] = id;
                            Session["userNum"] = thisNum;
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
                        string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3 from control_soft_time where name ='" + gs_name.Trim() + "' and soft_name='进销存'";
                        cmd = new SqlCommand(sqlStr, conn);
                        str = cmd.ExecuteReader();
                        string thisNum = "";
                        int a = 0;
                        List<string> itemi = new List<string>();
                        while (str.Read())
                        {
                            if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
                            {
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
                            }
                            thisNum = str["mark3"].ToString().Trim();
                            if (!thisNum.Equals(""))
                            {
                                thisNum = thisNum.Split(':')[1];
                                thisNum = thisNum.Replace("(", "");
                                thisNum = thisNum.Replace(")", "");
                            }

                        }

                       

                        Session["userNum"] = thisNum;
                        Session.Timeout = 10000;
                        Session["user"] = user;
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
                    string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3 from control_soft_time where name ='" + gs_name.Trim() + "' and soft_name='财务'";
                    cmd = new SqlCommand(sqlStr, conn);
                    str = cmd.ExecuteReader();
                    string thisNum = "";
                    int a = 0;
                    List<string> itemi = new List<string>();
                    while (str.Read())
                    {
                        if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
                        {
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
                        }
                        thisNum = str["mark3"].ToString().Trim();
                        if (!thisNum.Equals(""))
                        {
                            thisNum = thisNum.Split(':')[1];
                            thisNum = thisNum.Replace("(", "");
                            thisNum = thisNum.Replace(")", "");
                        }

                    }
                    Session["userNum"] = thisNum;
                    FinanceToken.getFinanceCheckToken().setToken(token);
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
                        string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3 from control_soft_time where name ='" + gs_name + "' and soft_name='排产'";
                        cmd = new SqlCommand(sqlStr, conn);
                        str = cmd.ExecuteReader();
                        string thisNum = "";
                        int a = 0;
                        List<string> itemi = new List<string>();
                        while (str.Read())
                        {
                            if (!str["mark1"].Equals("a8xd2s                                                                                                                                                                                                                                                         "))
                            {
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
                            }
                            thisNum = str["mark3"].ToString().Trim();
                            if (!thisNum.Equals(""))
                            {
                                thisNum = thisNum.Split(':')[1];
                                thisNum = thisNum.Replace("(", "");
                                thisNum = thisNum.Replace(")", "");
                            }

                        }

                        int ky_rongliang = FinanceSpace.getFinanceSpace().getMark4_all(gs_name,"排产");
                        int sy_rongliang = FinanceSpace.getFinanceSpace().getUseMark4_all(gs_name, "排产");

                        if (sy_rongliang >= ky_rongliang)
                        {
                            Response.Write("<script>alert('您在我公司租用的数据库容量已超上限，该系统暂时无法使用。请联系我公司，官方微信号：1623005800。')</script>");
                            return;
                        }
                        Session["userNum"] = thisNum;
                        Response.Redirect("../scheduling/web/index.html");
                    }
                }
                catch (Exception ex) {
                    Response.Write(ex.Message);
                }
            }
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