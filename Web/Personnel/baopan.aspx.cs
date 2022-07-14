using SDZdb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class baopan : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str1 = null;
        SqlCommand cmd = null;
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString()== null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            str = (string[])Session["arr3"];
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

            HrMingXiModel hm = new HrMingXiModel();
            string ks = "";
            string js = "";
            if (notisnull(ks) == false)
            {
                ks = "1900-01-01";
            }
            if (notisnull(js) == false)
            {
                js = "2200-01-01";
            }
            List<gongzi_gongzimingxi> list = hm.getBaoPan(Session["gongsi"].ToString(), ks, js);
            List<banpanhz> gongzimingxi = new List<banpanhz>();
            double qiye = 0;
            double geren = 0;
            for (int i = 0; i < list.Count; i++)
            {
                qiye = 0;
                geren = 0;
                banpanhz bp = new banpanhz();
                bp.B = list[i].B;//姓名
                bp.C = list[i].BC;//录入日期
                bp.D = list[i].AY;//实发工资
                bp.E = list[i].M;//全勤天数

                if (notisnull(list[i].AJ) && isnumeric(list[i].AJ))
                {
                    geren = geren + Convert.ToDouble(list[i].AJ);
                }
                if (notisnull(list[i].AK) && isnumeric(list[i].AK))
                {
                    geren = geren + Convert.ToDouble(list[i].AK);
                }
                if (notisnull(list[i].AL) && isnumeric(list[i].AL))
                {
                    geren = geren + Convert.ToDouble(list[i].AL);
                }
                if (notisnull(list[i].AM) && isnumeric(list[i].AM))
                {
                    geren = geren + Convert.ToDouble(list[i].AM);
                }
                if (notisnull(list[i].AN) && isnumeric(list[i].AN))
                {
                    geren = geren + Convert.ToDouble(list[i].AN);
                }
                if (notisnull(list[i].AO) && isnumeric(list[i].AO))
                {
                    geren = geren + Convert.ToDouble(list[i].AO);
                }

                bp.F = Convert.ToString(geren);//个人支出

                if (notisnull(list[i].Z) && isnumeric(list[i].Z))
                {
                    qiye = qiye + Convert.ToDouble(list[i].Z);
                }
                if (notisnull(list[i].AA) && isnumeric(list[i].AA))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AA);
                }
                if (notisnull(list[i].AB) && isnumeric(list[i].AB))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AB);
                }
                if (notisnull(list[i].AC) && isnumeric(list[i].AC))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AC);
                }
                if (notisnull(list[i].AD) && isnumeric(list[i].AD))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AD);
                }
                if (notisnull(list[i].AE) && isnumeric(list[i].AE))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AE);
                }
                if (notisnull(list[i].AF) && isnumeric(list[i].AF))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AF);
                }

                bp.G = Convert.ToString(qiye);//企业支出
                gongzimingxi.Add(bp);
            }
            this.GridView1.DataSource = gongzimingxi;
            this.GridView1.DataBind();

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            HrMingXiModel hm = new HrMingXiModel();
            string ks = Request.Form["ks"];
            string js = Request.Form["js"];
            if (notisnull(ks) == false)
            {
                ks = "1900-01-01";
            }
            if (notisnull(js) == false)
            {
                js = "2200-01-01";
            }
            List<gongzi_gongzimingxi> list = hm.getBaoPan(Session["gongsi"].ToString(), ks, js);
            List<banpanhz> gongzimingxi = new List<banpanhz>();
            double qiye = 0;
            double geren = 0;

            double hz_shifagongzi = 0;
            double hz_geren = 0;
            double hz_qiye = 0;
            double renshu = 0;
            double hz_kaoqin = 0;


            for (int i = 0; i < list.Count; i++)
            {
                qiye = 0;
                geren = 0;
                banpanhz bp = new banpanhz();
                bp.B = list[i].B;//姓名
                bp.C = list[i].BC;//录入日期

                bp.D = list[i].AY;//实发工资
                if (notisnull(list[i].AY) && isnumeric(list[i].AY))
                {
                    hz_shifagongzi=hz_shifagongzi+Convert.ToDouble(list[i].AY);
                }

                bp.E = list[i].M;//全勤天数
                if (notisnull(list[i].M) && isnumeric(list[i].M))
                {
                    hz_kaoqin = hz_kaoqin + Convert.ToDouble(list[i].M);
                }



                if (notisnull(list[i].AJ) && isnumeric(list[i].AJ))
                {
                    geren = geren + Convert.ToDouble(list[i].AJ);
                }
                if (notisnull(list[i].AK) && isnumeric(list[i].AK))
                {
                    geren = geren + Convert.ToDouble(list[i].AK);
                }
                if (notisnull(list[i].AL) && isnumeric(list[i].AL))
                {
                    geren = geren + Convert.ToDouble(list[i].AL);
                }
                if (notisnull(list[i].AM) && isnumeric(list[i].AM))
                {
                    geren = geren + Convert.ToDouble(list[i].AM);
                }
                if (notisnull(list[i].AN) && isnumeric(list[i].AN))
                {
                    geren = geren + Convert.ToDouble(list[i].AN);
                }
                if (notisnull(list[i].AO) && isnumeric(list[i].AO))
                {
                    geren = geren + Convert.ToDouble(list[i].AO);
                }

                bp.F = Convert.ToString(geren);//个人支出
                hz_geren=hz_geren+geren;


                if (notisnull(list[i].Z) && isnumeric(list[i].Z))
                {
                    qiye = qiye + Convert.ToDouble(list[i].Z);
                }
                if (notisnull(list[i].AA) && isnumeric(list[i].AA))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AA);
                }
                if (notisnull(list[i].AB) && isnumeric(list[i].AB))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AB);
                }
                if (notisnull(list[i].AC) && isnumeric(list[i].AC))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AC);
                }
                if (notisnull(list[i].AD) && isnumeric(list[i].AD))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AD);
                }
                if (notisnull(list[i].AE) && isnumeric(list[i].AE))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AE);
                }
                if (notisnull(list[i].AF) && isnumeric(list[i].AF))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AF);
                }

                bp.G = Convert.ToString(qiye);//企业支出
                hz_qiye=hz_qiye+qiye;
                gongzimingxi.Add(bp);
            }

            Textbox11.Text=Convert.ToString(hz_shifagongzi);
            Textbox12.Text=Convert.ToString(hz_geren);
            Textbox13.Text=Convert.ToString(hz_qiye);
            Textbox14.Text=Convert.ToString(list.Count);
            Textbox15.Text=Convert.ToString(hz_kaoqin);
            Textbox17.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.GridView1.DataSource = gongzimingxi;
            this.GridView1.DataBind();

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Textbox11.Text = "";
            Textbox12.Text = "";
            Textbox13.Text = "";
            Textbox14.Text = "";
            Textbox15.Text = "";
            Textbox17.Text = "";
            HrMingXiModel hm = new HrMingXiModel();
            string ks ="";
            string js = "";
            if (notisnull(ks)==false) 
            {
                ks = "1900-01-01";
            }
            if (notisnull(js) == false)
            {
                js = "2200-01-01";
            }
            List<gongzi_gongzimingxi> list = hm.getBaoPan(Session["gongsi"].ToString(),ks,js);
            List<banpanhz> gongzimingxi = new List<banpanhz>();
            double qiye = 0;
            double geren = 0;
            for (int i = 0; i < list.Count; i++)
            {
                qiye = 0;
                geren = 0;
                banpanhz bp = new banpanhz();
                bp.B = list[i].B;//姓名
                bp.C = list[i].BC;//录入日期
                bp.D = list[i].AY;//实发工资
                bp.E = list[i].M;//全勤天数

                if (notisnull(list[i].AJ) && isnumeric(list[i].AJ)) 
                {
                    geren=geren+Convert.ToDouble(list[i].AJ);
                }
                if (notisnull(list[i].AK) && isnumeric(list[i].AK)) 
                {
                    geren = geren + Convert.ToDouble(list[i].AK);
                }
                if (notisnull(list[i].AL) && isnumeric(list[i].AL))
                {
                    geren = geren + Convert.ToDouble(list[i].AL);
                }
                if (notisnull(list[i].AM) && isnumeric(list[i].AM))
                {
                    geren = geren + Convert.ToDouble(list[i].AM);
                }
                if (notisnull(list[i].AN) && isnumeric(list[i].AN))
                {
                    geren = geren + Convert.ToDouble(list[i].AN);
                }
                if (notisnull(list[i].AO) && isnumeric(list[i].AO))
                {
                    geren = geren + Convert.ToDouble(list[i].AO);
                }

                bp.F = Convert.ToString(geren);//个人支出

                if (notisnull(list[i].Z) && isnumeric(list[i].Z))
                {
                    qiye = qiye + Convert.ToDouble(list[i].Z);
                }
                if (notisnull(list[i].AA) && isnumeric(list[i].AA))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AA);
                }
                if (notisnull(list[i].AB) && isnumeric(list[i].AB))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AB);
                }
                if (notisnull(list[i].AC) && isnumeric(list[i].AC))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AC);
                }
                if (notisnull(list[i].AD) && isnumeric(list[i].AD))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AD);
                }
                if (notisnull(list[i].AE) && isnumeric(list[i].AE))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AE);
                }
                if (notisnull(list[i].AF) && isnumeric(list[i].AF))
                {
                    qiye = qiye + Convert.ToDouble(list[i].AF);
                }

                bp.G = Convert.ToString(qiye);//企业支出
                gongzimingxi.Add(bp);
            }
            this.GridView1.DataSource = gongzimingxi;
            this.GridView1.DataBind();

            //TextBox1.Text = "";
            //GridView1.DataSourceID = "SqlDataSource1";
            //GridView1.DataBind();
        }

        protected void aaa(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Pager)
            {
                str = (string[])Session["arr3"];
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

        protected void saveShenpi(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.AppSettings["yao"];
            conn = new SqlConnection(conString);  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sqlStr = "insert into gongzi_shenpi (shifa_gongzi,geren_zhichu,qiye_zhichu,yuangong_renshu,quanqin_tianshu,shenpiren,riqi,gongsi) VALUES ('" + Request.Form["Textbox11"] + "','" + Request.Form["Textbox12"] + "','" + Request.Form["Textbox13"] + "','" + Request.Form["Textbox14"] + "','" + Request.Form["Textbox15"] + "','" + Request.Form["Textbox16"] + "','" + Request.Form["Textbox17"] + "','" + Session["gongsi"].ToString() + "')";
            cmd = new SqlCommand(sqlStr, conn);
            str1 = cmd.ExecuteReader();
            conn.Close();
            Textbox11.Text = "";
            Textbox12.Text = "";
            Textbox13.Text = "";
            Textbox14.Text = "";
            Textbox15.Text = "";
            Textbox17.Text = "";
            Response.Write("<script>alert('保存成功！');</script>");

        }

        protected void toExcel(object sender, EventArgs e)
        {
            List<banpanhz> list = new List<banpanhz>();

            for (var i = 0; i < GridView1.Rows.Count; i++)
            {
                banpanhz item = new banpanhz();
                item.B = GridView1.Rows[i].Cells[1].Text.Trim();
                item.C = GridView1.Rows[i].Cells[2].Text.Trim();
                item.D = GridView1.Rows[i].Cells[3].Text.Trim();
                item.E = GridView1.Rows[i].Cells[4].Text.Trim();
                item.F = GridView1.Rows[i].Cells[5].Text.Trim();
                item.G = GridView1.Rows[i].Cells[6].Text.Trim();


                if (item.B == "&nbsp;") { item.B = ""; }
                if (item.C == "&nbsp;") { item.C = ""; }
                if (item.D == "&nbsp;") { item.D = ""; }
                if (item.E == "&nbsp;") { item.E = ""; }
                if (item.F == "&nbsp;") { item.F = ""; }
                if (item.G == "&nbsp;") { item.G = ""; }

                list.Add(item);
            }

            if (list != null)
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("员工姓名\t录入日期\t实发工资\t全勤天数\t个人支出\t企业支出");

                foreach (banpanhz bp in list)
                {

                    sw.WriteLine(bp.B + "\t" + bp.C + "\t" + bp.D + "\t" + bp.E + "\t" + bp.F + "\t" + bp.G);

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=报盘.xls");

                Response.ContentType = "application/ms-excel";

                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

                Response.Write(sw);

                Response.End();
            }else
            {
                Response.Write(" <script>alert('生成失败'); location='ming_xi.aspx';</script>");
            }
            

        }

        //判断字符串是否为空或null
        public bool notisnull(string str)
        {
            if (str == null || str.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //判断字符串是否为数字
        public bool isnumeric(string str)
        {
            foreach (char c in str)                   //遍历这个数组里的内容  
            {
                int d = 0;
                for (int i = 0; i <= 9; i++)
                {
                    if (c.ToString() == i.ToString() || c.ToString() == ".")
                    {
                        d = d + 1;
                    }
                }
                if (d < 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}