using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class changepwd1 : System.Web.UI.Page
    {

        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null || Session["id1"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='../Myadmin/Login.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string msg = "";
            string queren_newPwd = Request.Form["textBox5"].ToString();
            string newPwd = Request.Form["textBox4"].ToString();
            if (!newPwd.Equals("") && newPwd.Equals(queren_newPwd))
            {
                try
                {
                    string conString = ConfigurationManager.AppSettings["yao"];
                    conn = new SqlConnection(conString);  //数据库连接。
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    string sqlStr = "update gongzi_renyuan set J='" + newPwd + "' where id='" + Session["id1"].ToString() + "'";
                    cmd = new SqlCommand(sqlStr, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    msg = "修改成功";
                }
                catch
                {
                    msg = "网络错误，请稍后再试。";
                }
            }
            else if (newPwd.Equals("") || queren_newPwd.Equals(""))
            {
                msg = "请输入新密码！";
            }
            else if (!newPwd.Equals(queren_newPwd))
            {
                msg = "两次密码不一致请重新输入！";
            }
            Response.Write("<script>alert('" + msg + "');</script>");
        }
    }
}