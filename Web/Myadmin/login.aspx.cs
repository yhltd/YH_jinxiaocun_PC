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

                //List<string> itemi = new List<string>();

                //var myCol = System.Configuration.ConfigurationManager.AppSettings;
                //for (int i = 0; i < myCol.Count; i++)
                //{

                //    itemi.Add(myCol.AllKeys[i]);

                //}

                //DataTable dt = new DataTable();
                ////dap.Fill(dt); 
                //DropDownList1.Items.Clear();
                //DropDownList1.DataSource = itemi;

                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("选择", "绑定数据"));

                //HttpCookie cookie1 = Request.Cookies["MyCook"];

                //if (cookie1 != null &&cookie1["servename"]!=null&& cookie1["servename"].ToString() != "")
                //{

                //    DropDownList1.SelectedItem.Text = HttpUtility.UrlDecode(cookie1["servename"].ToString());



                //}


            }
        }

        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        protected void bian(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "云合人事管理系统") {
                conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sqlStr = "select L from gongzi_renyuan GROUP BY L;";
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                DropDownList2.Items.Clear();
                int a=0;
                List<string> itemi = new List<string>();
                while (str.Read()) { 
                    a=a+1;
                    itemi.Add(str[0].ToString());
                }
                DropDownList2.DataSource = itemi;
                DropDownList2.DataBind();
            }else if (DropDownList1.SelectedItem.Text == "服务器_jxc"){
                DataTable dt = new DataTable();
                string ConStr = "server=yhocn.cn;user=root;password=Lyh07910;database=YH_jinxiaocun_PC;pooling=true;";
                string sql="select gongsi from yh_jinxiaocun_user GROUP BY gongsi";
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
                    }
                }
            }
            else if (servename.ToString() == "服务器_jxc")
            {
                string ab = DropDownList1.SelectedValue;//获取DropDownList中你设定的Value值
                Cache["servename"] = servename;
                //   Session["servename"] = servename;

                HttpCookie cookie = new HttpCookie("MyCook");//初使化并设置Cookie的名称

                cookie.Values.Set("servename", HttpUtility.UrlEncode(servename));
                cookie.Expires = System.DateTime.Now.AddYears(100);

                Response.SetCookie(cookie);
                HttpCookie cookie1 = Request.Cookies["MyCook"];

                if (cookie1 != null && cookie1["servename"].ToString() != "")
                {
                    string dsdd = cookie1["servename"].ToString();
                }

                user = username;
                pass = txtSAPPassword;

                NewMethoduserFind(username.Trim(), txtSAPPassword.Trim(), gs_name.Trim());
            }
        }
        private bool NewMethoduserFind(string user, string pass, string gs_name)
        {

            try
            {
                clsAllnew BusinessHelp = new clsAllnew();

                List<clsuserinfo> userlist_Server = new List<clsuserinfo>();
                string strSelect = "select * from Yh_JinXiaoCun_user where name='" + user + "'";

                userlist_Server = BusinessHelp.findUser(strSelect.Trim());

                if (userlist_Server.Count > 0 && userlist_Server[0].Btype == "lock")
                {

                    return false;
                }
                if (userlist_Server.Count > 0 && userlist_Server[0].password.ToString().Trim() == pass.Trim() && userlist_Server[0].name.ToString().Trim() == user.Trim() && userlist_Server[0].gongsi.ToString().Trim() == gs_name.Trim())
                {
                    string servename = DropDownList1.SelectedItem.Text;//这是获取选中的文本值

                    alterinfo1 = "登录成功";

                    if (userlist_Server[0].AdminIS == "true")
                    {
                        HttpCookie cookie = new HttpCookie("adminCook");//初使化并设置Cookie的名称

                        cookie.Values.Set("AdminIS", HttpUtility.UrlEncode("true"));
                        cookie.Expires = System.DateTime.Now.AddYears(10);

                        Response.SetCookie(cookie);


                    }
                    Response.Redirect("~/frmMain.aspx");
                    logis++;
                }
                if (logis == 0)
                {
                    pass = "";

                    alterinfo1 = "登录失败，请确认用户名和密码或联系系统管理员，谢谢";

                    return false;
                
                }

               
                return false;


            }
            catch (Exception ex)
            {

                return false; ;

                throw;
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


    }
}