using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class bumenxiangqing1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/bumenhuizong.aspx");
        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            Session["xm1"] = Request.Form["TextBox1"];
            GridView1.DataSourceID = "SqlDataSource2";
            GridView1.DataBind();
        }
        protected void Button3_Click1(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }
    }
}