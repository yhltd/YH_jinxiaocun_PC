using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Myadmin
{
    public partial class changepassword : System.Web.UI.Page
    {
        public string alterinfo1;
        List<clsuserinfo> userlist_Server;
        private static clsuserinfo user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsuserinfo)Session["user"];
            textBox6.Text = user.name;
            textBox5.Text = user.password;
            if (user == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            else
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //BusinessHelp.changeUserpassword_Server(userlist_Server);


            //alterinfo1 = "密码修改成功！";


        }
    }
}