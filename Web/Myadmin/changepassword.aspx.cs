using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Server;

namespace Web.Myadmin
{
    public partial class changepassword : System.Web.UI.Page
    {
        private static yh_jinxiaocun_user user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string msg = "";
            string oldPwd = Request.Form["textBox5"].ToString();
            string newPwd = Request.Form["textBox4"].ToString();
            if (user.password.Equals(oldPwd))
            {
                try
                {
                    UserModel u = new UserModel();
                    user.password = newPwd;
                    int result = u.update(user);
                    if (result > 0)
                    {
                        msg = "修改成功";
                        Session["user"] = user;
                    }
                    else {
                        msg = "未修改";
                    }
                }
                catch {
                    msg = "网络错误，请稍后再试。";
                }
            }
            else 
            {
                msg = "旧密码错误！";
            }
            Response.Write("<script>alert('" + msg + "');</script>");
        }
    }
}