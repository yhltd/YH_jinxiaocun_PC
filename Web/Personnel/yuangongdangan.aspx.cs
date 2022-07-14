using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class yuangongdangan : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            HrMingXiModel hm = new HrMingXiModel();
            List<gongzi_renyuan> list = hm.getRenYuanById(Session["gongsi"].ToString(), Session["renyuan_id"].ToString());

            TextBox1.Text = list[0].T;
            TextBox2.Text = list[0].U;
            TextBox3.Text = list[0].V;
            TextBox4.Text = list[0].W;
            TextBox5.Text = list[0].X;
            TextBox6.Text = list[0].Y;
            TextBox7.Text = list[0].Z;
            TextBox8.Text = list[0].AA;
            TextBox9.Text = list[0].AB;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.AppSettings["yao"];
            conn = new SqlConnection(conString);  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string sqlStr = "update gongzi_renyuan set T='" + Request.Form["TextBox1"] + "',U='" + Request.Form["TextBox2"] + "',V='" + Request.Form["TextBox3"] + "',W='" + Request.Form["TextBox4"] + "',X='" + Request.Form["TextBox5"] + "',Y='" + Request.Form["TextBox6"] + "',Z='" + Request.Form["TextBox7"] + "',AA='" + Request.Form["TextBox8"] + "',AB='" + Request.Form["TextBox9"] + "' where id='" + Session["renyuan_id"].ToString() + "';";
            cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            Server.Transfer("../Personnel/renyuanxinxi.aspx");
        }
    }
}