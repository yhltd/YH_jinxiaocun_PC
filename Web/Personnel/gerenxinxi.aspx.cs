﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class gerenxinxi : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                Session["xm1"] = TextBox1.Text;
                GridView1.DataSourceID = "SqlDataSource2";
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }
    }
}