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
    public partial class baoshui : System.Web.UI.Page
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
                Session["xm1"] = Request.Form["TextBox1"];
                GridView1.DataSourceID = "SqlDataSource2";
               
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

        protected void toExcel(object sender, EventArgs e)
        {
            HrMingXiModel hm = new HrMingXiModel();
            List<gongzi_gongzimingxi> list = hm.gongzi_list(Session["gongsi"].ToString());
            if (list != null)
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("姓名\t证件类型\t证件号码\t收入金额\t基本养老保险金\t失业保险金\t住房公积金\t年金（个人部分）");

                foreach (gongzi_gongzimingxi baoshui in list)
                {

                    sw.WriteLine(baoshui.B + "\t" + "身份证" + "\t'" + baoshui.E + "\t" + baoshui.U + "\t" + baoshui.AI + "\t" + baoshui.AK + "\t" + baoshui.AN + "\t" + baoshui.AO);

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=报税.xls");

                Response.ContentType = "application/ms-excel";

                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

                Response.Write(sw);

                Response.End();
            }
            else
            {
                Response.Write(" <script>alert('保存失败'); location='ming_xi.aspx';</script>");
            }

        }
    }
}