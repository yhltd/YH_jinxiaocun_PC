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

namespace Web
{
    public partial class login : System.Web.UI.Page
    {
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
            else if (DropDownList1.SelectedItem.Text == "云合未来进销存系统")
            {
                DropDownList2.Items.Clear();
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
        protected void HtmlBtn_Click(object sender, EventArgs e)
        {
            string servename = DropDownList1.SelectedItem.Text;//这是获取选中的文本值
            string gs_name = DropDownList2.SelectedItem.Text;
            string username = Request.Form["username"];
            string txtSAPPassword = Request.Form["password"];
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
                    }
                }
            }
            else if (servename.ToString() == "云合未来进销存系统")
            {
                UserModel userModel = new UserModel();
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
                    FinanceToken.getFinanceCheckToken().setToken(token);
                    Response.Redirect("../finance/web/view/index.aspx");
                }
            }
            else if (servename.ToString().Equals("云合排产管理系统")) {
                try
                {
                    if (!UserInfoService.login(username.Trim(), txtSAPPassword.Trim(), gs_name.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('用户名密码错误！')", true);
                    }
                    else
                    {
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