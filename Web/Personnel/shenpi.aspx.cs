﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class shenpi : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            str = (string[])Session["arr6"];
            if (str[4].ToString() == "0")
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
                Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[5].ToString() == "0")
            {
                Server.Transfer("../Personnel/wuquanxian.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Request.Form["TextBox1"].Equals(""))
            {
                Session["shenpiren"] = Request.Form["TextBox1"];
                if (Request.Form["ks"].Equals(""))
                {
                    Session["ks"] = "1900-01-01";
                }
                else
                {
                    Session["ks"] = Request.Form["ks"];
                }
                if (Request.Form["js"].Equals(""))
                {
                    Session["js"] = "2200-01-01";
                }
                else
                {
                    Session["js"] = Request.Form["js"];
                }

                GridView1.DataSourceID = "SqlDataSource2";
                //GridView1.DataBind();
            }
            else
            {

                Response.Write("<script>alert('请填写审批人！');</script>");
                
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }

        protected void aaa(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Pager)
            {
                str = (string[])Session["arr6"];
                if (str[2].ToString() == "0")
                {
                    e.Row.Cells[1].Enabled = false;
                }
                if (str[3].ToString() == "0")
                {
                    e.Row.Cells[0].Enabled = false;
                }
            }
        }

        
    }
}