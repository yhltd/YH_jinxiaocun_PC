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
    public partial class kaoqinAdd : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        DateTime dt3;
        int m = 0;
        int n = 0;
        int x = 0;
        int f = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            input1.Value = Session["year"].ToString();//DateTime.Now.Year.ToString();
            input2.Value = Session["moth"].ToString();//DateTime.Now.Month.ToString();
            DateTime dt2 = DateTime.Parse(Session["year"].ToString() + "/" + Session["moth"].ToString() + "/1").AddMonths(1).AddDays(-1);
            int x = dt2.Day;
            conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sqlStr = "select year,month,day from gongzi_peizhi where gongsi='" + Session["gongsi"].ToString() + "' and year!='' and month!='' and day!='';";
            cmd = new SqlCommand(sqlStr, conn);
            str = cmd.ExecuteReader();
            //TextBox1.Text = m.ToString();
            int a = Convert.ToInt32(input1.Value);
            int b = Convert.ToInt32(input2.Value);
            for (int i = 4; i < x + 4; i++)
            {
            //    dt3 = DateTime.Parse(Session["year"].ToString() + "/" + Session["moth"].ToString() + "/" + (i - 3));
            //    f = 0;
            //    while (str.Read())
            //    {
            //        for (int j = 0; j < str.FieldCount; j++)
            //        {
            //            string cc = str[2].ToString();
            //            int dd = Convert.ToInt32(cc) + 3;
            //            if (dt3.ToString("yyyy-MM-dd") == DateTime.Parse(str[0].ToString() + "-" + str[1].ToString() + "-" + str[2].ToString()).ToString("yyyy-MM-dd"))
            //            {
            //                f = f + 1;
            //                ((TextBox)this.FindControl("TextBox" + dd.ToString())).Text = "休";
            //            }
            //        }
            //    }
                if (((a + b + (i - 3) + 1 + (a / 4)) % 7) == 4 || ((a + b + (i - 3) + 1 + (a / 4)) % 7) == 5 || f != 0)
                {
                    ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = "休";
                    n = n + 1;
                }
                else
                {
                    ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = "卡";
                    m = m + 1;
                }
                if (f > 0) {
                    ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = "休";
                }
            }
            input35.Value = m.ToString();
            input36.Value = m.ToString();
            input37.Value = "0";
            input38.Value = "0";
            input39.Value = "0";
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/kaoqin.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextBox1"] != "" && Request.Form["TextBox2"] != "" && Request.Form["TextBox3"] != "")
            {
                conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //str = conn.BeginTransaction();
                string sqlStr = "insert into gongzi_kaoqinjilu (year,moth,name,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO) VALUES ('" + Request.Form["input1"] + "','" + Request.Form["input2"] + "',";
                for (int i = 3; i < 35; i++)
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
                sqlStr += "'" + Request.Form["input35"] + "','" + Request.Form["input36"] + "','" + Request.Form["input37"] + "','" + Request.Form["input38"] + "','" + Request.Form["input39"] + "','" + Session["gongsi"].ToString() + "');";
                cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Server.Transfer("../Personnel/kaoqin.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>MyFun();</script>");
            }
        }
    }
}