using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class gongzimingxi : System.Web.UI.Page
    {
        string[] str = null;
        protected void GridView1_RowUpdating(object sender, GridViewEditEventArgs e)
        {
            int b = e.NewEditIndex;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>updinput(" + b + ");</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
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
                if (!Request.Form["TextBox1"].Equals(""))
                {
                    Session["xm1"] = Request.Form["TextBox1"];
                    GridView1.DataSourceID = "SqlDataSource2";
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSourceID = "SqlDataSource1";
                    GridView1.DataBind();
                }
               
            }
            else if (Request.Form["DropDownList1"] == "部门")
            {
                if (!Request.Form["TextBox1"].Equals(""))
                {
                    Session["xm1"] = Request.Form["TextBox1"];
                    GridView1.DataSourceID = "SqlDataSource2";
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSourceID = "SqlDataSource1";
                    GridView1.DataBind();
                }
            }
            else if (Request.Form["DropDownList1"] == "岗位")
            {
                if (!Request.Form["TextBox1"].Equals(""))
                {
                    Session["xm1"] = Request.Form["TextBox1"];
                    GridView1.DataSourceID = "SqlDataSource2";
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSourceID = "SqlDataSource1";
                    GridView1.DataBind();
                }
            }
            else if (Request.Form["DropDownList1"] == "")
            {
                GridView1.DataSourceID = "SqlDataSource1";
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

    //    protected void Button4_Click(object sender, EventArgs e)
   //     {
    //        Server.Transfer("../Personnel/gongzimingxi.aspx");
  //      }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] a = new string[55];
            for (int i = 2; i <= 55; i++)
            {
                a[i - 2] = GridView1.Rows[GridView1.SelectedIndex].Cells[i + 1].Text;
            }
            a[54] = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string result = js.Serialize(a); //upUser(" + result + ");iframe_d_open
            //ClientScript.RegisterStartupScript(this.GetType(), "", "<script>upUser(" + result + ");</script>");
            if (a[1].Equals("&nbsp;"))
            {
                a[1] = "";
            }
            if (a[2].Equals("&nbsp;"))
            {
                a[2] = "";
            }
            if (a[4].Equals("&nbsp;"))
            {
                a[4] = "";
            }
            if (a[54] == "0") {
                return;
            }
            Session["b"] = a[0];
            Session["year"] = a[1];
            Session["moth"] = a[2];
            Session["name"] = a[4];
            Server.Transfer("../Personnel/gongzimingxiUpd.aspx");
        }

        protected void toExcel(object sender, EventArgs e)
        {
            HrMingXiModel hm = new HrMingXiModel();
            List<gongzi_gongzimingxi> list = hm.gongzi_list(Session["gongsi"].ToString());
            if (list != null)
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("姓名\t部门\t岗位\t身份证号\t入职时间\t基本工资\t绩效工资\t岗位工资\t当月合计工资\t跨度工资\t职称津贴\t当月出勤天数\t加班时间\t加班费\t全勤应发\t缺勤天数\t缺勤扣款\t迟到天数\t迟到扣款\t应发工资\t社保基数\t医疗技术\t公积金基数\t年金基数\t企业养老\t企业失业\t企业医疗\t企业工伤\t企业生育\t企业公积金\t企业年金\t滞纳金\t利息\t企业小计\t个人养老\t个人失业\t个人医疗\t个人生育\t个人公积金\t个人年金4%\t滞纳金\t利息\t个人小计\t税前工资\t应税工资\t税率\t扣除数\t代扣个人所得税\t年金1%\t实发工资\t验算公式\t银行账号\t调薪时间\t录入时间");

                foreach (gongzi_gongzimingxi gz in list)
                {

                    sw.WriteLine(gz.B + "\t" + gz.C + "\t" + gz.D + "\t'" + gz.E + "\t'" + gz.F + "\t" + gz.G + "\t" + gz.H + "\t" + gz.I + "\t" + gz.J + "\t" + gz.K + "\t" + gz.L + "\t" + gz.M + "\t" + gz.N + "\t" + gz.O + "\t" + gz.P + "\t" + gz.Q + "\t" + gz.R + "\t" + gz.S + "\t" + gz.T + "\t" + gz.U + "\t" + gz.V + "\t" + gz.W + "\t" + gz.X + "\t" + gz.Y + "\t" + gz.Z + "\t" + gz.AA + "\t" + gz.AB + "\t" + gz.AC + "\t" + gz.AD + "\t" + gz.AE + "\t" + gz.AF + "\t" + gz.AG + "\t" + gz.AH + "\t" + gz.AI + "\t" + gz.AJ + "\t" + gz.AK + "\t" + gz.AL + "\t" + gz.AM + "\t" + gz.AN + "\t" + gz.AO + "\t" + gz.AP + "\t" + gz.AQ + "\t" + gz.AR + "\t" + gz.ASA + "\t" + gz.ATA + "\t" + gz.AU + "\t" + gz.AV + "\t" + gz.AW + "\t" + gz.AX + "\t" + gz.AY + "\t" + gz.AZ + "\t'" + gz.BA + "\t" + gz.BB + "\t" + gz.BC);

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=工资明细.xls");

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