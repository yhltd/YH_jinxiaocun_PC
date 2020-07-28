using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class renyuanxinxi : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            str = (string[])Session["arr2"];
            if (str[1].ToString() == "0")
            {
                Button1.Enabled = false;
                Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[4].ToString() == "0")
            {
                Button2.Enabled = false;
                Button3.Enabled = false;
                Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[5].ToString() == "0")
            {
                Server.Transfer("../Personnel/wuquanxian.aspx");
            }
            Session["gongsi2"] = Session["gongsi"].ToString() + "_hr";
            GridView1.DataSourceID = "SqlDataSource1";
        }
        protected void aaa(object sender,  GridViewRowEventArgs e) {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Pager)
            {
                str = (string[])Session["arr2"];
                string a = str[2].ToString();
                a = str[3].ToString();
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
        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_Operation")
            {

                int RowRemark = Convert.ToInt32(e.CommandArgument);
                string valueId = GridView1.Rows[RowRemark].Cells[2].Text;
                string value1 = GridView1.Rows[RowRemark].Cells[3].Text;
                string value2 = GridView1.Rows[RowRemark].Cells[4].Text;
                string value3 = GridView1.Rows[RowRemark].Cells[5].Text;
                string value4 = GridView1.Rows[RowRemark].Cells[6].Text;
                string value5 = GridView1.Rows[RowRemark].Cells[7].Text;
                string value6 = GridView1.Rows[RowRemark].Cells[8].Text;
                string value7 = GridView1.Rows[RowRemark].Cells[9].Text;
                string value8 = GridView1.Rows[RowRemark].Cells[10].Text;
                string value9 = GridView1.Rows[RowRemark].Cells[11].Text;
                string value10 = GridView1.Rows[RowRemark].Cells[12].Text;
                Server.Transfer("../Personnel/renyuanxinxiAdd.aspx?修改," + valueId + "," + value1 + "," + value2 + "," + value3 + "," + value4 + "," + value5 + "," + value6 + "," + value7 + "," + value8 + "," + value9 + "," + value10);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/renyuanxinxiAdd.aspx?添加,");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["xm1"] = Request.Form["TextBox1"];
            GridView1.DataSourceID = "SqlDataSource2";
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }
    }
}