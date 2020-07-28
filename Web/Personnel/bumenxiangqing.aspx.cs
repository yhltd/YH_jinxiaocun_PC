using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class bumenxiangqing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a=Session["bm1"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["xm1"] = Request.Form["TextBox1"];
            GridView1.DataSourceID = "SqlDataSource2";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/shebao.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }
    }
}