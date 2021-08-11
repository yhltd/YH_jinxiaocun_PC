using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class shebao : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            str = (string[])Session["arr9"];
            if (str[4].ToString() == "0")
            {
                Button2.Enabled = false;
                Button3.Enabled = false;
                Button1.Enabled = false;
                Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[5].ToString() == "0")
            {
                Server.Transfer("../Personnel/wuquanxian.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["bm1"] = Request.Form["DropDownList1"];
            GridView1.DataSourceID = "SqlDataSource2";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["bm1"] = Request.Form["DropDownList1"];
            Server.Transfer("../Personnel/bumenxiangqing.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }

    }


}