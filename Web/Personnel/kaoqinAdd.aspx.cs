﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class kaoqinAdd : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        //DateTime dt3;
        int m = 0;
        int n = 0;
        int x = 0;
        int f = 0;
        int chidao = 0;
        int chuqin = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            TextBox1.Text = DateTime.Now.Year.ToString(); ;//DateTime.Now.Year.ToString();
            TextBox2.Text = DateTime.Now.Month.ToString(); ;//DateTime.Now.Month.ToString();
            DateTime dt2 = DateTime.Parse(Session["year"].ToString() + "/" + Session["moth"].ToString() + "/1").AddMonths(1).AddDays(-1);
            int x = dt2.Day;
            string conString = ConfigurationManager.AppSettings["yao"];
            conn = new SqlConnection(conString);  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sqlStr = "select year,month,day from gongzi_peizhi where gongsi='" + Session["gongsi"].ToString() + "' and year!='' and month!='' and day!='';";
            cmd = new SqlCommand(sqlStr, conn);
            str = cmd.ExecuteReader();
            //TextBox1.Text = m.ToString();
            int ss = Convert.ToInt32(TextBox1.Text);
            int b = Convert.ToInt32(TextBox2.Text);
            
            for (int i = 4; i <= 34; i++) {
                ListItem item = ((DropDownList)this.FindControl("DropDownList" + i.ToString())).Items.FindByText("出勤");
                item.Selected = true;
                m = m + 1;
            }
            

            //if (item != null) {
            //    //防止出现多选的情况，将选中项 清除
            //    DropDownList4.ClearSelection();
                
            //}
            //for (int i = 4; i <=34; i++)
            //{
            //    //string nian = DateTime.Now.Year.ToString();
            //    //ListItem item = DropDownList1.Items.FindByText(nian);
            //    //if (item != null) {
            //    //    //防止出现多选的情况，将选中项 清除
            //    //    DropDownList1.ClearSelection();
            //    //    item.Selected = true;
            //    //}
            //    //    dt3 = DateTime.Parse(Session["year"].ToString() + "/" + Session["moth"].ToString() + "/" + (i - 3));
            //    //    f = 0;
            //    //    while (str.Read())
            //    //    {
            //    //        for (int j = 0; j < str.FieldCount; j++)
            //    //        {
            //    //            string cc = str[2].ToString();
            //    //            int dd = Convert.ToInt32(cc) + 3;
            //    //            if (dt3.ToString("yyyy-MM-dd") == DateTime.Parse(str[0].ToString() + "-" + str[1].ToString() + "-" + str[2].ToString()).ToString("yyyy-MM-dd"))
            //    //            {
            //    //                f = f + 1;
            //    //                ((TextBox)this.FindControl("TextBox" + dd.ToString())).Text = "休";
            //    //            }
            //    //        }
            //    //    }
            //    //if (((ss + b + (i - 3) + 1 + (ss / 4)) % 7) == 4 || ((ss + b + (i - 3) + 1 + (ss / 4)) % 7) == 5 || f != 0)
            //    //{
            //    //    ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = "休";
            //    //    n = n + 1;
            //    //}
            //    //else
            //    //{
            //    //    ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = "卡";
            //    //    m = m + 1;
            //    //}
            //    //if (f > 0)
            //    //{
            //    //    ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = "休";
            //    //}
            //}
            TextBox35.Text = m.ToString();
            TextBox36.Text = m.ToString();
            TextBox37.Text = "0";
            TextBox38.Text = "0";
            TextBox39.Text = "0";
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/kaoqin.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextBox1"] != "" && Request.Form["TextBox2"] != "" && Request.Form["TextBox3"] != "" && Convert.ToInt32(Request.Form["TextBox2"]) > 0 && Convert.ToInt32(Request.Form["TextBox2"]) < 13)
            {
                string conString = ConfigurationManager.AppSettings["yao"];
                conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                
                //str = conn.BeginTransaction();
                string moth = "";
                if (Convert.ToInt32(Request.Form["TextBox2"]) < 10)
                {
                    moth = "0" + Request.Form["TextBox2"];
                }
                else
                {
                    moth = Request.Form["TextBox2"];
                }
                for (int i = 4; i <= 34; i++)
                {
                    
                    if (Request.Form["DropDownList" + i] == "迟到")
                    {
                        chidao = chidao + 1;
                    }
                }
               
                for (int i = 4; i <= 34; i++)
                {
                    if (Request.Form["DropDownList" + i] != "旷勤")
                    {
                       chuqin = chuqin + 1;
                    }
                }
              
                string sqlStr = "insert into gongzi_kaoqinjilu (year,moth,name,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO) VALUES ('" + Request.Form["TextBox1"] + "','" + moth + "','" + Request.Form["TextBox3"] + "',";
                for (int i = 4; i < 35; i++)
                {
                    if (Request.Form["DropDownList" + i] != "")
                    {
                        sqlStr += "'" + Request.Form["DropDownList" + i] + "',";
                    }
                    else
                    {
                        sqlStr += "'_',";
                    }
                }
                TextBox36.Text = chuqin.ToString();
                TextBox39.Text = chidao.ToString();
                //sqlStr += "'" + Request.Form["TextBox35"] + "','" + Request.Form["TextBox36"] + "','" + Request.Form["TextBox37"] + "','" + Request.Form["TextBox38"] + "','" + Request.Form["TextBox39"] + "','" + Session["gongsi"].ToString() + "');";
                sqlStr += "'" + Request.Form["TextBox35"] + "','" + chuqin.ToString() + "','" + Request.Form["TextBox37"] + "','" + Request.Form["TextBox38"] + "','" + chidao.ToString() +"','" + Session["gongsi"].ToString() + "');";
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