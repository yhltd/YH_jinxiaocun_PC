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
    public partial class renyuanxinxiAdd : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        string[] a;
        protected void Page_Load(object sender, EventArgs e)
        {

            a = Request.QueryString[0].Split(',');
            if (a[0] == "修改")
            {
                TextBox1.Text = a[2];
                TextBox2.Text = a[3];
                TextBox3.Text = a[4];
                TextBox4.Text = a[5];
                TextBox5.Text = a[6];
                TextBox6.Text = a[7];
                TextBox7.Text = a[8];
                TextBox8.Text = a[9];
                TextBox9.Text = a[10];
                TextBox10.Text = a[11];
                Button1.Text = "修改";
                Button3.Enabled = true;
                Session["zh1"] = a[10];
            }
            else if (a[0] == "添加")
            {
                Button1.Text = "添加";
                Button3.Enabled = false;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            int count;
            string sql;
            if (Request.Form["TextBox1"].ToString() != "" && Request.Form["TextBox2"].ToString() != "" && Request.Form["TextBox3"].ToString() != "" && Request.Form["TextBox9"].ToString() != "" && Request.Form["TextBox10"].ToString() != "")
            {
                conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }             
                if (Button1.Text == "添加")
                {
                    sql = "select count(id) from gongzi_renyuan where i ='" + Request.Form["TextBox9"].ToString() + "';";
                    cmd = new SqlCommand(sql, conn);
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count>0) {
                        ClientScript.RegisterStartupScript( this.GetType(), "", "<script>MyFun();</script>");
                    }
                   else 
                    {
                        string sqlStr = "insert into gongzi_renyuan (B,C,D,E,F,G,H,J,K,I,L) VALUES (";
                        for (int i = 1; i < 11; i++)
                        {
                            if (Request.Form["TextBox" + i] != "")
                            {
                                sqlStr += "'" + Request.Form["TextBox" + i] + "',";
                            }
                            else
                            {
                                sqlStr += "'-',";
                            }
                        }
                        sqlStr += "'" + Session["gongsi"].ToString() + "_hr');select @@identity";
                        cmd = new SqlCommand(sqlStr, conn);
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        sqlStr = "insert into gongzi_renyuanManager (R_id,[add],del,upd,sel,look,view_id) values('" + id + "','1','1','1','1','1','1'),('" + id + "','0','0','0','0','0','2'),('" + id + "','1','1','1','1','1','3'),('" + id + "','1','1','1','1','1','4'),('" + id + "','1','1','1','1','1','5'),('" + id + "','1','1','1','1','1','6'),('" + id + "','1','1','1','1','1','7'),('" + id + "','1','1','1','1','1','8'),('" + id + "','1','1','1','1','1','9'),('" + id + "','0','0','0','0','0','10'),('" + id + "','1','1','1','1','1','11'),('" + id + "','1','1','1','1','1','12')";
                        cmd = new SqlCommand(sqlStr, conn);
                        cmd.ExecuteScalar();
                        conn.Close();
                        Server.Transfer("../Personnel/renyuanxinxi.aspx");
                    }
                }
                else if (Button1.Text == "修改")
                {
                    if (Request.Form["TextBox9"].ToString()!=Session["zh1"].ToString()){
                    sql = "select count(id) from gongzi_renyuan where i ='" + Request.Form["TextBox9"].ToString() + "';";
                    cmd = new SqlCommand(sql, conn);
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }else{
                    count=0;
                }
                    if (count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>MyFun();</script>");
                    }
                    else
                    {
                        string sqlStr = "update gongzi_renyuan set B='" + Request.Form["TextBox1"] + "',C='" + Request.Form["TextBox2"] + "',D='" + Request.Form["TextBox3"] + "',E='" + Request.Form["TextBox4"] + "',F='" + Request.Form["TextBox5"] + "',G='" + Request.Form["TextBox6"] + "',H='" + Request.Form["TextBox7"] + "',J='" + Request.Form["TextBox8"] + "',K='" + Request.Form["TextBox9"] + "',I='" + Request.Form["TextBox10"] + "',L='" + Session["gongsi"].ToString() + "_hr' where id='" + a[1] + "';";
                        cmd = new SqlCommand(sqlStr, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Server.Transfer("../Personnel/renyuanxinxi.aspx");
                    }
                }
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/renyuanxinxi.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            a = Request.QueryString[0].Split(',');
            Session["qx1"]=a[2];
            Session["id1"] = a[1];
            Server.Transfer("../Personnel/quanxian.aspx");
        }
    }
}