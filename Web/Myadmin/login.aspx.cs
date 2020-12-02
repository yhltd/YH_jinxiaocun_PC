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
using Web.jxc_service;

namespace Web
{
    public partial class login : System.Web.UI.Page
    {
        public string alterinfo1;

        bool is_AdminIS = false;
        int logis = 0;
        public string user;
        public string pass;
        public string version;
        protected void Page_Load(object sender, EventArgs e)
        {
            version = "建议使用IE浏览器-当前系统版本: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (!Page.IsPostBack)
            {
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("选择", "绑定数据"));
            }
        }

        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
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
            else if (DropDownList1.SelectedItem.Text == "服务器_jxc")
            {
                DataTable dt = new DataTable();
                string ConStr = "server=yhocn.cn;user=root;password=Lyh07910;database=YH_jinxiaocun_PC;pooling=true;";
                string sql = "select gongsi from yh_jinxiaocun_user GROUP BY gongsi";
                MySql.Data.MySqlClient.MySqlDataReader reader = MySqlHelper.ExecuteReader(sql, ConStr);
                DropDownList2.Items.Clear();
                int a = 0;
                List<string> itemi = new List<string>();
                while (reader.Read())
                {
                    a = a + 1;
                    itemi.Add(reader[0].ToString());
                }
                DropDownList2.DataSource = itemi;
                DropDownList2.DataBind();
            }
        }
        protected void HtmlBtn_Click(object sender, EventArgs e)
        {
            Session.Timeout = 10000;
            string username = Request.Form["username"];
            Session["username"] = username;

            string txtSAPPassword = Request.Form["password"];
            string gs_name = DropDownList2.SelectedItem.Text;
            Session["gs_name"] = gs_name;
            string servename = DropDownList1.SelectedItem.Text;//这是获取选中的文本值
            if (servename.ToString() == "云合人事管理系统")
            {
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
                            string[] a = gs_name.Split('_');
                            Session["gongsi"] = a[0];
                            Session["id1"] = id;
                            Server.Transfer("../Personnel/index.aspx");

                        }
                        else
                        {
                            Response.Write("<script id='alert'>alert('输入密码有误，请重试')</script>");
                        }
                        conn.Close();
                        Response.Redirect("../Personnel/login.aspx");
                    }
                }
            }
            else if (servename.ToString() == "服务器_jxc")
            {
                jxc_user user = new jxc_user();
                int result = user.loginAndGetUser(username.Trim(), txtSAPPassword.Trim(), gs_name.Trim());
                string msg = "";

                if (result == 1)
                {
                    Response.Redirect("~/frmMain.aspx");
                    return;
                }
                else if (result == 0)
                {
                    msg = "用户名密码错误！";
                }
                else
                {

                    msg = "用户已被锁定！";
                }
                Response.Write("<script id='alert'>alert('" + msg + "')</script>");
            }
        }
        protected void HtmlBtcreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmUserManger.aspx");
        }

        protected void Btchangepas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Myadmin/changepassword.aspx");
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