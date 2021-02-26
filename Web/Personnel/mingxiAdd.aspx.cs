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
    public partial class mingxiAdd : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextBox1"] != "")
            {
                string conString = ConfigurationManager.AppSettings["yao"];
                conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sqlStr = "insert into gongzi_gongzimingxi (B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AP,AQ,AR,ASA,ATA,AU,AV,AW,AX,AY,AZ,BA,BB,BC,BD) VALUES (";
                for (int i = 1; i < 55; i++)
                {
                    if (Request.Form["TextBox" + i] != "")
                    {
                        sqlStr += "'" + Request.Form["TextBox" + i] + "',";
                    }
                    else if (i == 2 || i == 3 || i == 4 || i == 5 || i == 52 || i == 54)
                    {
                        sqlStr += "'',";
                    }
                    else
                    {
                        sqlStr += "'0',";
                    }
                }
                sqlStr += "'" + Session["gongsi"].ToString() + "');";
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                Server.Transfer("../Personnel/gongzimingxi.aspx");
                conn.Close();
            }
            else
            {

            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/gongzimingxi.aspx");
        }
    }
}