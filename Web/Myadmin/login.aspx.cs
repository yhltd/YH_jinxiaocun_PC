using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                List<string> itemi = new List<string>();

                var myCol = System.Configuration.ConfigurationManager.AppSettings;
                for (int i = 0; i < myCol.Count; i++)
                {

                    itemi.Add(myCol.AllKeys[i]);

                }

                DataTable dt = new DataTable();
                //dap.Fill(dt); 
                DropDownList1.Items.Clear();
                DropDownList1.DataSource = itemi;

                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("选择", "绑定数据"));

                HttpCookie cookie1 = Request.Cookies["MyCook"];

                if (cookie1 != null &&cookie1["servename"]!=null&& cookie1["servename"].ToString() != "")
                {

                    DropDownList1.SelectedItem.Text = HttpUtility.UrlDecode(cookie1["servename"].ToString());



                }


            }
        }


        protected void HtmlBtn_Click(object sender, EventArgs e)
        {

            string username = Request.Form["username"];
            string txtSAPPassword = Request.Form["password"];
            string servename = DropDownList1.SelectedItem.Text;//这是获取选中的文本值
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

            NewMethoduserFind(username.Trim(), txtSAPPassword.Trim());

        }
        private bool NewMethoduserFind(string user, string pass)
        {

            try
            {
                clsAllnew BusinessHelp = new clsAllnew();

                List<clsuserinfo> userlist_Server = new List<clsuserinfo>();
                string strSelect = "select * from _user where name='" + user + "'";

                userlist_Server = BusinessHelp.findUser(strSelect.Trim());

                if (userlist_Server.Count > 0 && userlist_Server[0].Btype == "lock")
                {

                    return false;
                }
                if (userlist_Server.Count > 0 && userlist_Server[0].password.ToString().Trim() == pass.Trim() && userlist_Server[0].name.ToString().Trim() == user.Trim())
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