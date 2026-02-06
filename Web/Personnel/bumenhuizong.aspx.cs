using SDZdb;
using System;
using System.Collections.Generic;
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
    public partial class bumenhuizong : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            str = (string[])Session["arr8"];
            if (str[4].ToString() == "0")
            {
                Button2.Enabled = false;
                Button3.Enabled = false;
                Button1.Enabled = false;
                Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[5].ToString() == "0")
            {
                Server.Transfer("../Personnel/wuquanxian.aspx");
            }
            //conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
            //if (conn.State == ConnectionState.Closed)
            //{
            //    conn.Open();
            //}
            //string sqlStr = "select C from gongzi_gongzimingxi where BD='" + Session["gongsi"].ToString() + "';";
            //cmd = new SqlCommand(sqlStr, conn);
            //str = cmd.ExecuteReader();
            //a = new string[100];
            //while (str.Read())
            //{
            //    string b = str.GetString(0).ToString();
            //    a[i] = b;
            //    i = i + 1;
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Request.Form["DropDownList1"].Equals(""))
            {
                Session["bm1"] = Request.Form["DropDownList1"];
                if (Request.Form["ks"].Equals(""))
                {
                    Session["ks"] = "1900-1-1";
                }
                else 
                {
                    Session["ks"] = Request.Form["ks"];
                }
                if (Request.Form["js"].Equals(""))
                {
                    Session["js"] = "2900-1-1";
                }
                else
                {
                    Session["js"] = Request.Form["js"];
                }

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
            Session["bm1"] = Request.Form["DropDownList1"];
            Server.Transfer("../Personnel/bumenxiangqing1.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            HrMingXiModel hm = new HrMingXiModel();
            List<bumenExcel> list = hm.bumenToExcel(Session["gongsi"].ToString());
            
            if (list != null) 
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("部门\t人数\t基本工资\t绩效工资\t岗位工资\t标准工资\t跨度工资\t职称津贴");

                foreach (bumenExcel gz in list) 
                {
                    sw.WriteLine(gz.C + "\t" + gz.ID + "\t" + gz.G + "\t" + gz.H + "\t" + gz.I + "\t" + gz.J + "\t" + gz.K + "\t" + gz.L);
                }
                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=部门汇总.xls");

                Response.ContentType = "application/ms-excel";

                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

                Response.Write(sw);

                Response.End();
            }
            else
            {
                Response.Write(" <script>alert('无数据');</script>");
            }


        }
        
    }
}