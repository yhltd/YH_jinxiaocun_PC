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
    public partial class kaoqinjiluAdd : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox2.Text = Session["year"].ToString();
            TextBox3.Text = Session["moth"].ToString();
            TextBox4.Text = "0";
            TextBox5.Text = "0";
            TextBox6.Text = "0";
            TextBox7.Text = "0";
            TextBox8.Text = "0";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/kaoqinjilu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //str = conn.BeginTransaction();
            string sqlStr = "insert into gongzi_kaoqinmingxi (name,C,D,E,F,G,H,I,J,K) VALUES (";
            for (int i = 1; i < 9; i++)
            {
                if (Request.Form["TextBox" + i] != "")
                {
                    sqlStr += "'" + Request.Form["TextBox" + i] + "',";
                }
                else
                {
                    sqlStr += "'_',";
                }
            }
            sqlStr += "'" + Request.Form["DropDownList1"] + "',";
            sqlStr += "'" + Session["gongsi"].ToString() + "');";
            cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Server.Transfer("../Personnel/kaoqinjilu.aspx");
        }

    }
}