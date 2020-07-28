using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class gongzimingxi : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            str = (string[])Session["arr5"];
            if (str[1].ToString() == "0")
            {
                Button2.Enabled = false;
                Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[4].ToString() == "0")
            {
                Button1.Enabled = false;
                Button3.Enabled = false;
                Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[5].ToString() == "0")
            {
                Server.Transfer("../Personnel/wuquanxian.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["DropDownList1"] == "姓名")
            {
                Session["xm1"] = Request.Form["TextBox1"];
                GridView1.DataSourceID = "SqlDataSource2";
                GridView1.DataBind();
            }
            else if (Request.Form["DropDownList1"] == "部门")
            {
                Session["bm1"] = Request.Form["TextBox1"];
                GridView1.DataSourceID = "SqlDataSource3";
                GridView1.DataBind();
            }
            else if (Request.Form["DropDownList1"] == "岗位")
            {
                Session["zw1"] = Request.Form["TextBox1"];
                GridView1.DataSourceID = "SqlDataSource4";
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/mingxiAdd.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }
        protected void aaa(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Pager)
            {
                str = (string[])Session["arr5"];
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