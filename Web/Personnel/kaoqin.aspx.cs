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
                Button5.Enabled = false; 
                Button6.Enabled = false;
                Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button5.BackColor = System.Drawing.ColorTranslator.FromHtml("gray"); 
                Button6.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
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
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (Request.Form["ks"] == "" || Request.Form["js"] == "") {
        //        Response.Write("<script>alert('请选择开始时间和结束时间！');</script>");
        //        return;
        //    }
        //    String ks = Request.Form["ks"];
        //    String js = Request.Form["js"];
        //    Session["year"] = Request.Form["ks"].Split('-')[0] + Request.Form["ks"].Split('-')[1];
        //    Session["moth"] = Request.Form["js"].Split('-')[0] + Request.Form["js"].Split('-')[1];
        //    GridView1.DataSourceID = "SqlDataSource2";
        //    Response.Write("<script>document.getElementById('ks').value='" + ks + "';document.getElementById('js').value='" + js + "';</script>");
        //}
        protected void Button1_Click(object sender, EventArgs e)
        {
            // 检查开始时间和结束时间是否为空
            if (Request.Form["ks"] == "" || Request.Form["js"] == "")
            {
                Response.Write("<script>alert('请选择开始时间和结束时间！');</script>");
                return;
            }

            String ks = Request.Form["ks"];
            String js = Request.Form["js"];

            // 验证结束时间不能小于开始时间
            try
            {
                DateTime startDate = DateTime.Parse(ks);
                DateTime endDate = DateTime.Parse(js);

                if (endDate < startDate)
                {
                    Response.Write("<script>alert('结束时间不能小于开始时间！');</script>");
                    return;
                }

                // 可选：验证时间范围是否合理（比如不超过1年）
                TimeSpan span = endDate - startDate;
                if (span.Days > 365)
                {
                    Response.Write("<script>alert('时间范围不能超过一年！');</script>");
                    return;
                }
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('时间格式不正确！');</script>");
                return;
            }

            // 保存搜索条件到Session
            Session["year"] = Request.Form["ks"].Split('-')[0] + Request.Form["ks"].Split('-')[1];
            Session["moth"] = Request.Form["js"].Split('-')[0] + Request.Form["js"].Split('-')[1];

            // 重新绑定数据源
            GridView1.DataSourceID = "SqlDataSource2";

            // 设置输入框的值
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
        //protected void Button5_Click(object sender, EventArgs e)
        //{


        //    var riqi = DateTime.Now.ToString("yyyy-MM-01");
        //    string[] mm = riqi.Split('-');
        //    var rq = mm[0] + "-" + mm[1] + "-" + 01;
        //    int y = Convert.ToInt32(mm[0]);
        //    int m = Convert.ToInt32(mm[1]);
        //    int d = Convert.ToInt32(mm[2]);



        //    if (m == 1 || m == 2)
        //    {
        //        m += 12;
        //        y--;
        //    }
        //    int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400 + 1) % 7;


        //    string sql;
        //    string conString = ConfigurationManager.AppSettings["yao"];
        //    conn = new SqlConnection(conString);  //数据库连接。
        //    if (conn.State == ConnectionState.Closed)
        //    {
        //        conn.Open();
        //    }
        //    if (week == 1)
        //    {
        //        sql = "update gongzi_kaoqinjilu set E ='',F='',G='',H='',I='',J='休',K='休',L='',M='',N='',O='',P='',Q='休',R='休',S='',T='',U='',V='',W='',X='',Y='休',Z='休',AA='',AB='',AC='',AD='',AE='',AF='休',AG='休',AH='',AI='' where  year ='" + y + "' and moth ='" + m + "';";
        //        cmd = new SqlCommand(sql, conn);
        //    }
        //    if (week == 2)
        //    {
        //        sql = "update gongzi_kaoqinjilu set E ='',F='',G='',H='',I='休',J='休',K='',L='',M='',N='',O='',P='休',Q='休',R='',S='',T='',U='',V='',W='',X='休',Y='休',Z='',AA='',AB='',AC='',AD='',AE='休',AF='休',AG='',AH='',AI='' where  year ='" + y + "' and moth ='" + m + "';";
        //        cmd = new SqlCommand(sql, conn);
        //    }
        //    if (week == 3)
        //    {
        //        sql = "update gongzi_kaoqinjilu set E ='',F='',G='',H='休',I='休',J='',K='',L='',M='',N='',O='休',P='休',Q='',R='',S='',T='',U='',V='休',W='休',X='',Y='',Z='',AA='',AB='',AC='休',AD='休',AE='',AF='',AG='',AH='',AI='' where  year ='" + y + "' and moth ='" + m + "';";
        //        cmd = new SqlCommand(sql, conn);
        //    }
        //    if (week == 4)
        //    {
        //        sql = "update gongzi_kaoqinjilu set E ='',F='',G='休',H='休',I='',J='',K='',L='',M='',N='休',O='休',P='',Q='',R='',S='',T='',U='休',V='休',W='',X='',Y='',Z='',AA='',AB='休',AC='休',AD='',AE='',AF='',AG='',AH='',AI='休' where year ='" + y + "' and moth ='" + m + "';";
        //        cmd = new SqlCommand(sql, conn);
        //    }
        //    if (week == 5)
        //    {
        //        sql = "update gongzi_kaoqinjilu set E ='',F='休',G='休',H='',I='',J='',K='',L='',M='休',N='休',O='',P='',Q='',R='',S='',T='休',U='休',V='',W='',X='',Y='',Z='',AA='休',AB='休',AC='',AD='',AE='',AF='',AG='',AH='休',AI='休' where year ='" + y + "' and moth ='" + m + "';";
        //        cmd = new SqlCommand(sql, conn);
        //    }
        //    if (week == 6)
        //    {
        //        sql = "update gongzi_kaoqinjilu set E ='休',F='',G='',H='',I='',J='',K='',L='休',M='休',N='',O='',P='',Q='',R='',S='休',T='休',U='',V='',W='',X='',Y='',Z='休',AA='休',AB='',AC='',AD='',AE='',AF='',AG='休',AH='休',AI='' where  year ='" + y + "' and moth ='" + m + "';";
        //        cmd = new SqlCommand(sql, conn);
        //    }
        //    if (week == 0)
        //    {
        //        sql = "update gongzi_kaoqinjilu set E ='休',F='',G='',H='',I='',J='',K='休',L='休',M='',N='',O='',P='',Q='',R='休',S='休',T='',U='',V='',W='',X='',Y='休',Z='休',AA='',AB='',AC='',AD='',AE='',AF='休',AG='休',AH='',AI='' where  year ='" + y + "' and moth ='" + m + "';";
        //        cmd = new SqlCommand(sql, conn);
        //    }


        //    cmd.ExecuteScalar();
        //    conn.Close();
        //    Server.Transfer("../Personnel/kaoqin.aspx");
        //}

        //protected void Button6_Click(object sender, EventArgs e)
        //{
        //    var riqi = DateTime.Now.ToString("yyyy-MM-dd");
        //    string[] mm = riqi.Split('-');
        //    var rq = mm[0] + "-" + mm[1] + "-" + 01;
        //    int y = Convert.ToInt32(mm[0]);
        //    int m = Convert.ToInt32(mm[1]);
            
        //    string sql;
        //    string conString = ConfigurationManager.AppSettings["yao"];
        //    conn = new SqlConnection(conString);  //数据库连接。
        //    if (conn.State == ConnectionState.Closed)
        //    {
        //        conn.Open();
        //    }
        //    sql = "update gongzi_kaoqinjilu set E ='',F='',G='',H='',I='',J='',K='',L='',M='',N='',O='',P='',Q='',R='',S='',T='',U='',V='',W='',X='',Y='',Z='',AA='',AB='',AC='',AD='',AE='',AF='',AG='',AH='',AI='' where year ='" + y + "' and moth ='" + m + "';";
        //    cmd = new SqlCommand(sql, conn);
        //    cmd.ExecuteScalar();
        //    conn.Close();
        //    Server.Transfer("../Personnel/kaoqin.aspx");
        //}

        //protected void Button5_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // 1. 获取当前月份
        //        DateTime now = DateTime.Now;
        //        int y = now.Year;
        //        int m = now.Month;
        //        int d = 1; // 每月第一天

        //        // 2. 计算本月第一天是星期几
        //        DateTime firstDayOfMonth = new DateTime(y, m, d);
        //        DayOfWeek dayOfWeek = firstDayOfMonth.DayOfWeek;
        //        int week = (int)dayOfWeek; // 0=周日，1=周一，...6=周六

        //        // 3. 获取公司信息
        //        string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
        //        if (string.IsNullOrEmpty(gongsi))
        //        {
        //            Response.Write("<script>alert('请先登录！');</script>");
        //            return;
        //        }

        //        // 4. 构建SQL（添加公司筛选）
        //        string sql = BuildUpdateSql(week, y, m, gongsi);

        //        // 5. 执行SQL
        //        string conString = ConfigurationManager.AppSettings["yao"];
        //        using (SqlConnection conn = new SqlConnection(conString))
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand(sql, conn))
        //            {
        //                // 需要添加参数！这是你缺少的关键步骤
        //                cmd.Parameters.AddWithValue("@year", y);
        //                cmd.Parameters.AddWithValue("@moth", m);
        //                cmd.Parameters.AddWithValue("@gongsi", gongsi);

        //                int affectedRows = cmd.ExecuteNonQuery();

        //                // 6. 显示成功消息
        //                Response.Write("<script>alert('当月休假设置成功');</script>");
        //            }
        //        }

        //        // 7. 重新绑定数据
        //        GridView1.DataBind();

        //        // 8. 刷新页面显示（可选）
        //        // Response.Write("<script>location.reload();</script>");
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('操作失败');</script>");
        //    }
        //}

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 获取当前月份
                DateTime now = DateTime.Now;
                int y = now.Year;
                int m = now.Month;
                int d = 1; // 每月第一天

                // 2. 计算本月第一天是星期几
                DateTime firstDayOfMonth = new DateTime(y, m, d);
                DayOfWeek dayOfWeek = firstDayOfMonth.DayOfWeek;
                int week = (int)dayOfWeek; // 0=周日，1=周一，...6=周六

                // 3. 获取公司信息
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                if (string.IsNullOrEmpty(gongsi))
                {
                    Response.Write("<script>alert('请先登录！');</script>");
                    return;
                }

                // 4. 构建SQL（添加公司筛选）
                string sql = BuildUpdateSql(week, y, m, gongsi);

                // 5. 执行SQL
                string conString = ConfigurationManager.AppSettings["yao"];
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // 需要添加参数！这是你缺少的关键步骤
                        cmd.Parameters.AddWithValue("@year", y);
                        cmd.Parameters.AddWithValue("@moth", m);
                        cmd.Parameters.AddWithValue("@gongsi", gongsi);

                        int affectedRows = cmd.ExecuteNonQuery();

                        // 6. 显示成功消息
                        Response.Write("<script>alert('当月休假设置成功');</script>");
                    }
                }

                // 7. 重新绑定数据
                GridView1.DataBind();

                // 8. 刷新页面显示（可选）
                // Response.Write("<script>location.reload();</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('操作失败');</script>");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取当前月份
                DateTime now = DateTime.Now;
                int y = now.Year;
                int m = now.Month;
        
                // 获取公司信息
                string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";
                if (string.IsNullOrEmpty(gongsi))
                {
                    Response.Write("<script>alert('请先登录！');</script>");
                    return;
                }
        
                // 构建SQL（添加公司筛选）
                string sql = "UPDATE gongzi_kaoqinjilu " +
                             "SET E='',F='',G='',H='',I='',J='',K='',L='',M='',N='',O='',P='',Q='',R='',S='',T='',U='',V='',W='',X='',Y='',Z='',AA='',AB='',AC='',AD='',AE='',AF='',AG='',AH='',AI='' " +
                             "WHERE year = @year AND moth = @moth AND AO LIKE '%' + @gongsi + '%'";
        
                // 执行SQL
                string conString = ConfigurationManager.AppSettings["yao"];
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // 使用参数化查询，避免SQL注入
                        cmd.Parameters.AddWithValue("@year", y);
                        cmd.Parameters.AddWithValue("@moth", m);
                        cmd.Parameters.AddWithValue("@gongsi", gongsi);
                
                        int affectedRows = cmd.ExecuteNonQuery();
                
                        // 显示成功消息
                        Response.Write("<script>alert('当月初始化成功');</script>");
                    }
                }
        
                // 重新绑定数据
                GridView1.DataBind();
        
                // 刷新页面显示（可选）
                // Response.Write("<script>location.reload();</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('操作失败');</script>");
            }
        }

        private string BuildUpdateSql(int week, int year, int month, string gongsi)
        {
            // 根据星期几设置不同的更新语句
            string setClause = "";
    
            // 使用传统的switch语句
            switch (week)
            {
                case 1: // 周一
                    setClause = "E='',F='',G='',H='',I='',J='休',K='休',L='',M='',N='',O='',P='',Q='休',R='休',S='',T='',U='',V='',W='',X='',Y='休',Z='休',AA='',AB='',AC='',AD='',AE='',AF='休',AG='休',AH='',AI=''";
                    break;
                case 2: // 周二
                    setClause = "E='',F='',G='',H='',I='休',J='休',K='',L='',M='',N='',O='',P='休',Q='休',R='',S='',T='',U='',V='',W='',X='休',Y='休',Z='',AA='',AB='',AC='',AD='',AE='休',AF='休',AG='',AH='',AI=''";
                    break;
                case 3: // 周三
                    setClause = "E='',F='',G='',H='休',I='休',J='',K='',L='',M='',N='',O='休',P='休',Q='',R='',S='',T='',U='',V='休',W='休',X='',Y='',Z='',AA='',AB='',AC='休',AD='休',AE='',AF='',AG='',AH='',AI=''";
                    break;
                case 4: // 周四
                    setClause = "E='',F='',G='休',H='休',I='',J='',K='',L='',M='',N='休',O='休',P='',Q='',R='',S='',T='',U='休',V='休',W='',X='',Y='',Z='',AA='',AB='休',AC='休',AD='',AE='',AF='',AG='',AH='',AI='休'";
                    break;
                case 5: // 周五
                    setClause = "E='',F='休',G='休',H='',I='',J='',K='',L='',M='休',N='休',O='',P='',Q='',R='',S='',T='休',U='休',V='',W='',X='',Y='',Z='',AA='休',AB='休',AC='',AD='',AE='',AF='',AG='',AH='休',AI='休'";
                    break;
                case 6: // 周六
                    setClause = "E='休',F='',G='',H='',I='',J='',K='',L='休',M='休',N='',O='',P='',Q='',R='',S='休',T='休',U='',V='',W='',X='',Y='',Z='休',AA='休',AB='',AC='',AD='',AE='',AF='',AG='休',AH='休',AI=''";
                    break;
                default: // 周日或0
                    setClause = "E='休',F='',G='',H='',I='',J='',K='休',L='休',M='',N='',O='',P='',Q='',R='休',S='休',T='',U='',V='',W='',X='',Y='休',Z='休',AA='',AB='',AC='',AD='',AE='',AF='休',AG='休',AH='',AI=''";
                    break;
            }
    
            // 使用参数化查询构建SQL
            return "UPDATE gongzi_kaoqinjilu " +
                   "SET " + setClause + " " +
                   "WHERE year = @year AND moth = @moth AND AO LIKE '%' + @gongsi + '%'";
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