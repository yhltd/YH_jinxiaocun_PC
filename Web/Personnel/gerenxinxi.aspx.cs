﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class gerenxinxi : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            str = (string[])Session["arr10"];
            if (str[4].ToString() == "0")
            {
                Button2.Enabled = false;
                Button1.Enabled = false;
                Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[5].ToString() == "0")
            {
                Server.Transfer("../Personnel/wuquanxian.aspx");
            }
            Session["gongsi2"] = Session["gongsi"].ToString() + "_hr";
            string a = Session["gongsi2"].ToString();
            GridView1.Columns[0].Visible = false;
            GridView1.Columns[11].Visible = false;
            GridView1.Columns[8].Visible = false;
            GridView1.Columns[9].Visible = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                if (!Request.Form["TextBox1"].Equals(""))
                {
                    Session["xm1"] = Request.Form["TextBox1"];
                    GridView1.DataSourceID = "SqlDataSource2";
                }
                else
                {
                    GridView1.DataSourceID = "SqlDataSource1";
                    GridView1.DataBind();
                }
                //TextBox1.Text = "";
            }
            else
            {
                GridView1.DataSourceID = "SqlDataSource1";
                GridView1.DataBind();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["xm1"] = DateTime.Now.ToString("yyyy-MM-dd");
            GridView1.DataSourceID = "SqlDataSource3";
            GridView1.DataBind();
        }
    }
}