using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class bumenhuizong : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            str = (string[])Session["arr8"];
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
            //conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
            //if (conn.State == ConnectionState.Closed)
            //{
            //    conn.Open();
            //}
            //string sqlStr = "select C from gongzi_gongzimingxi where BD='" + Session["gongsi"].ToString() + "';";
            //cmd = new SqlCommand(sqlStr, conn);
            //str = cmd.ExecuteReader();
            //a = new string[100];
            //while (str.Read())
            //{
            //    string b = str.GetString(0).ToString();
            //    a[i] = b;
            //    i = i + 1;
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["bm1"] = Request.Form["DropDownList1"];
            GridView1.DataSourceID = "SqlDataSource2";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["bm1"] = Request.Form["DropDownList1"];
            Server.Transfer("../Personnel/bumenxiangqing1.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }
        
    }
}