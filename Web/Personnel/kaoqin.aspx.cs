using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Web.Personnel.HrModel;
using System.IO;

namespace Web.Personnel
{
    public partial class kaoqin : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader strs = null;
        SqlCommand cmd = null;
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");

            }
            str = (string[])Session["arr1"];
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
            //string nian = DateTime.Now.Year.ToString();
            //ListItem item = DropDownList1.Items.FindByText(nian);
            //if (item != null) {
            //    //防止出现多选的情况，将选中项 清除
            //    DropDownList1.ClearSelection();
            //    item.Selected = true;
            //}
        } 
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["ks"] == "" || Request.Form["js"] == "") {
                Response.Write("<script>alert('请选择开始时间和结束时间！');</script>");
                return;
            }
            Session["year"] = Request.Form["ks"].Split('-')[0] + Request.Form["ks"].Split('-')[1];
            Session["moth"] = Request.Form["js"].Split('-')[0] + Request.Form["js"].Split('-')[1];
            GridView1.DataSourceID = "SqlDataSource2";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Session["year"] = DateTime.Now.Year.ToString();
                Session["moth"] = DateTime.Now.Month.ToString();
                Server.Transfer("../Personnel/kaoqinAdd.aspx", true);
            }
            catch (Exception ex) {
                Response.Write("<script>window.location.href = '../Personnel/kaoqinAdd.aspx'</script>");
            }
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
                str = (string[])Session["arr1"];
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

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string[] a = new string[40];
            for (int i = 2; i <= 41; i++)
            {
                a[i - 2] = GridView1.Rows[GridView1.SelectedIndex].Cells[i + 1].Text;
            }
            a[39] = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string result = js.Serialize(a); //upUser(" + result + ");iframe_d_open
            //ClientScript.RegisterStartupScript(this.GetType(), "", "<script>upUser(" + result + ");</script>");
            if (a[39] == "0") {
                return;
            }
            Session["b"] = a[39];
            Session["year"] = a[0];
            Session["moth"] = a[1];
            Session["name"] = a[2];
            Server.Transfer("../Personnel/kaoqinUpd.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/kaoqin.aspx");
            
            
           
        }

        protected void toExcel(object sender, EventArgs e)
        {
            HrMingXiModel hm = new HrMingXiModel();
            List<gongzi_kaoqinjilu> list = hm.kaoqin_list(Session["gongsi"].ToString());
            if (list != null)
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("年\t月\t姓名\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\t17\t18\t19\t20\t21\t22\t23\t24\t25\t26\t27\t28\t29\t30\t31\t全勤天数\t实际天数\t请假/小时\t加班/小时\t迟到天数");

                foreach (gongzi_kaoqinjilu kaoqin in list)
                {

                    sw.WriteLine(kaoqin.year + "\t" + kaoqin.moth + "\t" + kaoqin.name + "\t" + kaoqin.E + "\t" + kaoqin.F + "\t" + kaoqin.G + "\t" + kaoqin.H + "\t" + kaoqin.I + "\t" + kaoqin.J + "\t" + kaoqin.K + "\t" + kaoqin.L + "\t" + kaoqin.M + "\t" + kaoqin.N + "\t" + kaoqin.O + "\t" + kaoqin.P + "\t" + kaoqin.Q + "\t" + kaoqin.R + "\t" + kaoqin.S + "\t" + kaoqin.T + "\t" + kaoqin.U + "\t" + kaoqin.V + "\t" + kaoqin.W + "\t" + kaoqin.X + "\t" + kaoqin.Y + "\t" + kaoqin.Z + "\t" + kaoqin.AA + "\t" + kaoqin.AB + "\t" + kaoqin.AC + "\t" + kaoqin.AD + "\t" + kaoqin.AE + "\t" + kaoqin.AF + "\t" + kaoqin.AG + "\t" + kaoqin.AH + "\t" + kaoqin.AI + "\t" + kaoqin.AJ + "\t" + kaoqin.AK + "\t" + kaoqin.AL + "\t" + kaoqin.AM + "\t" + kaoqin.AN);

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=考勤.xls");

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