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
            String ks = Request.Form["ks"];
            String js = Request.Form["js"];
            Session["year"] = Request.Form["ks"].Split('-')[0] + Request.Form["ks"].Split('-')[1];
            Session["moth"] = Request.Form["js"].Split('-')[0] + Request.Form["js"].Split('-')[1];
            GridView1.DataSourceID = "SqlDataSource2";
            Response.Write("<script>document.getElementById('ks').value='" + ks + "';document.getElementById('js').value='" + js + "';</script>");
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
        protected void Button5_Click(object sender, EventArgs e)
        {
            var riqi = DateTime.Now.ToString("yyyy-MM-dd");
            string[] mm = riqi.Split('-');
            var rq = mm[0] + "-" + mm[1] + "-" + 01;
            int y = Convert.ToInt32(mm[0]);
            int m = Convert.ToInt32(mm[1]);
            int d = 01;
            if (m == 1 || m == 2)
            {
                m += 12;
                y--;
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400 + 1) % 7;
            if (week == 0)
            {
                week = 7;
            }
            string sql;
            string conString = ConfigurationManager.AppSettings["yao"];
            conn = new SqlConnection(conString);  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (week == 1)
            {
                sql = "update gongzi_kaoqinjilu set E ='',F='',G='',H='',I='',J='休',K='休',L='',M='',N='',O='',P='',Q='休',R='休',S='',T='',U='',V='',W='',X='',Y='休',Z='休',AA='',AB='',AC='',AD='',AE='',AF='休',AG='休',AH='',AI='' where  year ='" + y + "' and moth ='" + m + "';";
                cmd = new SqlCommand(sql, conn);
            }
            if (week == 2)
            {
                sql = "update gongzi_kaoqinjilu set E ='',F='',G='',H='',I='休',J='休',K='',L='',M='',N='',O='',P='休',Q='休',R='',S='',T='',U='',V='',W='',X='休',Y='休',Z='',AA='',AB='',AC='',AD='',AE='休',AF='休',AG='',AH='',AI='' where  year ='" + y + "' and moth ='" + m + "';";
                cmd = new SqlCommand(sql, conn);
            }
            if (week == 3)
            {
                sql = "update gongzi_kaoqinjilu set E ='',F='',G='',H='休',I='休',J='',K='',L='',M='',N='',O='休',P='休',Q='',R='',S='',T='',U='',V='休',W='休',X='',Y='',Z='',AA='',AB='',AC='休',AD='休',AE='',AF='',AG='',AH='',AI='' where  year ='" + y + "' and moth ='" + m + "';";
                cmd = new SqlCommand(sql, conn);
            }
            if (week == 4)
            {
                sql = "update gongzi_kaoqinjilu set E ='',F='',G='休',H='休',I='',J='',K='',L='',M='',N='休',O='休',P='',Q='',R='',S='',T='',U='休',V='休',W='',X='',Y='',Z='',AA='',AB='休',AC='休',AD='',AE='',AF='',AG='',AH='',AI='休' where year ='" + y + "' and moth ='" + m + "';";
                cmd = new SqlCommand(sql, conn);
            }
            if (week == 5)
            {
                sql = "update gongzi_kaoqinjilu set E ='',F='休',G='休',H='',I='',J='',K='',L='',M='休',N='休',O='',P='',Q='',R='',S='',T='休',U='休',V='',W='',X='',Y='',Z='',AA='休',AB='休',AC='',AD='',AE='',AF='',AG='',AH='休',AI='休' where year ='" + y + "' and moth ='" + m + "';";
                cmd = new SqlCommand(sql, conn);
            }
            if (week == 6)
            {
                sql = "update gongzi_kaoqinjilu set E ='休',F='',G='',H='',I='',J='',K='',L='休',M='休',N='',O='',P='',Q='',R='',S='休',T='休',U='',V='',W='',X='',Y='',Z='休',AA='休',AB='',AC='',AD='',AE='',AF='',AG='休',AH='休',AI='' where  year ='" + y + "' and moth ='" + m + "';";
                cmd = new SqlCommand(sql, conn);
            }
            if (week == 7)
            {
                sql = "update gongzi_kaoqinjilu set E ='休',F='',G='',H='',I='',J='',K='休',L='休',M='',N='',O='',P='',Q='',R='休',S='休',T='',U='',V='',W='',X='',Y='休',Z='休',AA='',AB='',AC='',AD='',AE='',AF='休',AG='休',AH='',AI='' where  year ='" + y + "' and moth ='" + m + "';";
                cmd = new SqlCommand(sql, conn);
            }

            
            cmd.ExecuteScalar();
            conn.Close();
            Server.Transfer("../Personnel/kaoqin.aspx");
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            var riqi = DateTime.Now.ToString("yyyy-MM-dd");
            string[] mm = riqi.Split('-');
            var rq = mm[0] + "-" + mm[1] + "-" + 01;
            int y = Convert.ToInt32(mm[0]);
            int m = Convert.ToInt32(mm[1]);
            int d = 01;
            if (m == 1 || m == 2)
            {
                m += 12;
                y--;
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400 + 1) % 7;
            if (week == 0)
            {
                week = 7;
            }
            string sql;
            string conString = ConfigurationManager.AppSettings["yao"];
            conn = new SqlConnection(conString);  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            sql = "update gongzi_kaoqinjilu set E ='',F='',G='',H='',I='',J='',K='',L='',M='',N='',O='',P='',Q='',R='',S='',T='',U='',V='',W='',X='',Y='',Z='',AA='',AB='',AC='',AD='',AE='',AF='',AG='',AH='',AI='' where year ='" + y + "' and moth ='" + m + "';";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteScalar();
            conn.Close();
            Server.Transfer("../Personnel/kaoqin.aspx");
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