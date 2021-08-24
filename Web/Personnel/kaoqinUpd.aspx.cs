using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class kaoqinUpd : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        string[] aa=new string[39];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string a = Request["strs"].ToString();
                string[] strs = a.Split(new char[1] { ',' });
                aa = strs;
                for (int i = 2; i < 34; i++)
                {
                    string b = ((TextBox)this.FindControl("TextBox" + (i + 1).ToString())).ToString();
                    ((TextBox)this.FindControl("TextBox" + (i + 1).ToString())).Text = aa[i].ToString();
                }
                TextBox1.Text = aa[0].ToString();
                TextBox2.Text = aa[1].ToString();
                TextBox35.Text = aa[34].ToString();
                TextBox36.Text = aa[35].ToString();
                TextBox37.Text = aa[36].ToString();
                TextBox38.Text = aa[37].ToString();
                TextBox39.Text = aa[38].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextBox1"] != "" && Request.Form["TextBox2"] != "" && Request.Form["TextBox3"] != "" && Request.Form["TextBox1"] != " " && Request.Form["TextBox2"] != " " && Request.Form["TextBox3"] != " ")
            {
                string a = Request["strs"].ToString();
                string[] bb = a.Split(new char[1] { ',' });
                string conString = ConfigurationManager.AppSettings["yao"];
                conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //str = conn.BeginTransaction();
                string sqlStr = "update gongzi_kaoqinjilu set year='" + Request.Form["TextBox1"].Trim() + "',moth='" + Request.Form["TextBox2"].Trim() + "',name='" + Request.Form["TextBox3"].Trim() + "',E='" + Request.Form["TextBox4"].Trim() + "',F='" + Request.Form["TextBox5"].Trim() + "',G='" + Request.Form["TextBox6"].Trim() + "',H='" + Request.Form["TextBox7"].Trim() + "',I='" + Request.Form["TextBox8"].Trim() + "',J='" + Request.Form["TextBox9"].Trim() + "',K='" + Request.Form["TextBox10"].Trim() + "',L='" + Request.Form["TextBox11"].Trim() + "',M='" + Request.Form["TextBox12"].Trim() + "',N='" + Request.Form["TextBox13"].Trim() + "',O='" + Request.Form["TextBox14"].Trim() + "',P='" + Request.Form["TextBox15"].Trim() + "',Q='" + Request.Form["TextBox16"].Trim() + "',R='" + Request.Form["TextBox17"].Trim() + "',S='" + Request.Form["TextBox18"].Trim() + "',T='" + Request.Form["TextBox19"].Trim() + "',U='" + Request.Form["TextBox20"].Trim() + "',V='" + Request.Form["TextBox21"].Trim() + "',W='" + Request.Form["TextBox22"].Trim() + "',X='" + Request.Form["TextBox23"].Trim() + "',Y='" + Request.Form["TextBox24"].Trim() + "',Z='" + Request.Form["TextBox25"].Trim() + "',AA='" + Request.Form["TextBox26"].Trim() + "',AB='" + Request.Form["TextBox27"].Trim() + "',AC='" + Request.Form["TextBox28"].Trim() + "',AD='" + Request.Form["TextBox29"].Trim() + "',AE='" + Request.Form["TextBox30"].Trim() + "',AF='" + Request.Form["TextBox31"].Trim() + "',AG='" + Request.Form["TextBox32"].Trim() + "',AH='" + Request.Form["TextBox33"].Trim() + "',AI='" + Request.Form["TextBox34"].Trim() + "',AJ='" + Request.Form["TextBox35"].Trim() + "',AK='" + Request.Form["TextBox36"].Trim() + "',AL='" + Request.Form["TextBox37"].Trim() + "',AM='" + Request.Form["TextBox38"].Trim() + "',AN='" + Request.Form["TextBox39"].Trim() + "' where id='" + bb[39] + "'";
                cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                
                for (int i = 2; i < 34; i++)
                {
                    aa[i] = Request.Form["TextBox" + i];
                }
                aa[0] = Request.Form["TextBox1"];
                aa[1] = Request.Form["TextBox2"];
                aa[34] = Request.Form["TextBox35"];
                aa[35] = Request.Form["TextBox36"];
                aa[36] = Request.Form["TextBox37"];
                aa[37] = Request.Form["TextBox38"];
                aa[38] = Request.Form["TextBox39"];
                Server.Transfer("../Personnel/kaoqin.aspx");
        
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>MyFun();</script>");
            }
           
            
        }


        
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}