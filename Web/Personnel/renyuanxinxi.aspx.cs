using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class renyuanxinxi : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            HrMingXiModel hm = new HrMingXiModel();
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
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
            Session["gongsi2"] = Session["gongsi"].ToString();
            GridView1.DataSourceID = "SqlDataSource1";
            string yue = DateTime.Now.Month.ToString();
            string ri = DateTime.Now.Day.ToString();  
            string name = "";

            List<gongzi_renyuan> getList = hm.getListByRenYuan(Session["gongsi"].ToString(),yue,ri);
            for (int i = 0; i < getList.Count; i++) 
            {
                if (!name.Equals(""))
                {
                    name = name + "、" + getList[i].B;
                }
                else 
                {
                    name = getList[i].B;
                }
                
            }
            //if (!name.Equals("")) 
            //{
            //    name = "<script>alert('今天是" + name + "的生日')</script>";
            //    Response.Write(name);
            //    //Response.Clear();
            //}
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
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[20].Visible = false;
            e.Row.Cells[21].Visible = false;
            e.Row.Cells[22].Visible = false;
            e.Row.Cells[23].Visible = false;
            e.Row.Cells[24].Visible = false;
            e.Row.Cells[25].Visible = false;
            e.Row.Cells[26].Visible = false;
            e.Row.Cells[27].Visible = false;
            e.Row.Cells[28].Visible = false;
            e.Row.Cells[29].Visible = false;
            e.Row.Cells[30].Visible = false;
            e.Row.Cells[31].Visible = false;

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
                if (GridView1.Rows[RowRemark].Cells[2].Text == "0")
                {
                    return;
                }
                string valueId = isStr(GridView1.Rows[RowRemark].Cells[2].Text);
                string value1 = isStr(GridView1.Rows[RowRemark].Cells[3].Text);
                string value2 = isStr(GridView1.Rows[RowRemark].Cells[4].Text);
                string value3 = isStr(GridView1.Rows[RowRemark].Cells[5].Text);
                string value4 = isStr(GridView1.Rows[RowRemark].Cells[6].Text);
                string value5 = isStr(GridView1.Rows[RowRemark].Cells[7].Text);
                string value6 = isStr(GridView1.Rows[RowRemark].Cells[8].Text);
                string value7 = isStr(GridView1.Rows[RowRemark].Cells[9].Text);
                string value8 = isStr(GridView1.Rows[RowRemark].Cells[10].Text);
                string value9 = isStr(GridView1.Rows[RowRemark].Cells[11].Text);
                string value10 = isStr(GridView1.Rows[RowRemark].Cells[12].Text);

                string value11 = isStr(GridView1.Rows[RowRemark].Cells[14].Text);
                string value12 = isStr(GridView1.Rows[RowRemark].Cells[15].Text);
                string value13 = isStr(GridView1.Rows[RowRemark].Cells[16].Text);
                string value14 = isStr(GridView1.Rows[RowRemark].Cells[17].Text);
                string value15 = isStr(GridView1.Rows[RowRemark].Cells[18].Text);
                string value16 = isStr(GridView1.Rows[RowRemark].Cells[19].Text);
                string value17 = isStr(GridView1.Rows[RowRemark].Cells[20].Text);
                string value18 = isStr(GridView1.Rows[RowRemark].Cells[30].Text);
                string value19 = isStr(GridView1.Rows[RowRemark].Cells[31].Text);

                string str = "修改," + valueId + "," + value1 + "," + value2 + "," + value3 + "," + value4 + "," + value5 + "," + value6 + "," + value7 + "," + value10 + "," + value8 + "," + value9 + "," + value11 + "," + value12 + "," + value13 + "," + value14 + "," + value15 + "," + value16 + "," + value17 + "," + value18 + "," + value19;

                //Server.Transfer("../Personnel/renyuanxinxiAdd.aspx?修改," + valueId + "," + value1 + "," + value2 + "," + value3 + "," + value4 + "," + value5 + "," + value6 + "," + value7 + "," + value10 + "," + value8 + "," + value9 + "," + value11 + "," + value12 + "," + value13 + "," + value14 + "," + value15 + "," + value16 + "," + value17 + "," + value18);
                Server.Transfer("../Personnel/renyuanxinxiAdd.aspx?"+str);
            }
        }

        //判断字符串是否为&nbsp
        public string isStr(string str)
        {
            if (str.Equals("&nbsp;"))
            {
                return "";
            }
            else 
            {
                return str;
            }
        } 

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/renyuanxinxiAdd.aspx?添加,");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["xm1"] = Request.Form["TextBox1"];
            Session["xm2"] = Request.Form["TextBox2"];
            if (Request.Form["TextBox1"].Equals("") && Request.Form["TextBox2"].Equals(""))
            {
                GridView1.DataSourceID = "SqlDataSource1";
            }
            else if (!Request.Form["TextBox1"].Equals("") && !Request.Form["TextBox2"].Equals(""))
            {
                GridView1.DataSourceID = "SqlDataSource2";
            }
            else if (!Request.Form["TextBox1"].Equals("") && Request.Form["TextBox2"].Equals(""))
            {
                GridView1.DataSourceID = "SqlDataSource3";
            }
            else if (Request.Form["TextBox1"].Equals("") && !Request.Form["TextBox2"].Equals(""))
            {
                GridView1.DataSourceID = "SqlDataSource4";
            }


            //if (Request.Form["TextBox2"].Equals(""))
            //{
            //    Response.Write("<script>alert('请填写手机号！');</script>");
            //    return;
            //}
            //Session["xm1"] = Request.Form["TextBox1"];
            //Session["xm2"] = Request.Form["TextBox2"];
            //GridView1.DataSourceID = "SqlDataSource2";
            //if (Request.Form["TextBox1"].Equals("") && Request.Form["TextBox2"].Equals(""))
            //{
            //    GridView1.DataSourceID = "SqlDataSource1";
            //}
            //else
            //{
            //    GridView1.DataSourceID = "SqlDataSource2";
            //}
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }

        protected void toExcel(object sender, EventArgs e)
        {
            List<gongzi_renyuan> list = new List<gongzi_renyuan>();

            for (var i = 0; i < GridView1.Rows.Count; i++)
            {
                gongzi_renyuan item = new gongzi_renyuan();
                item.B = GridView1.Rows[i].Cells[3].Text.Trim();
                item.C = GridView1.Rows[i].Cells[4].Text.Trim();
                item.D = GridView1.Rows[i].Cells[5].Text.Trim();
                

                if (item.B == "&nbsp;") { item.B = ""; }
                if (item.C == "&nbsp;") { item.C = ""; }
                if (item.D == "&nbsp;") { item.D = ""; }

                list.Add(item);
            }

            if (list != null)
            {
                StringWriter sw = new StringWriter();
                
                sw.WriteLine("姓名\t部门\t职务");

                foreach (gongzi_renyuan ry in list)
                {

                    sw.WriteLine(ry.B + "\t" + ry.C + "\t" + ry.D );

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=人员信息管理.xls");

                Response.ContentType = "application/ms-excel";

                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

                Response.Write(sw);

                Response.End();
            }
        }
    }
}