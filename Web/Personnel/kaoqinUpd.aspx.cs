using System;
using System.Collections.Generic;
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
                input1.Value = aa[0].ToString();
                input2.Value = aa[1].ToString();
                input35.Value = aa[34].ToString();
                input36.Value = aa[35].ToString();
                input37.Value = aa[36].ToString();
                input38.Value = aa[37].ToString();
                input39.Value = aa[38].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextBox1"] != "" && Request.Form["TextBox2"] != "" && Request.Form["TextBox3"] != "")
            {
                string a = Request["strs"].ToString();
                string[] bb = a.Split(new char[1] { ',' });
                conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //str = conn.BeginTransaction();
                string sqlStr = "update gongzi_kaoqinjilu set year='" + Request.Form["input1"] + "',moth='" + Request.Form["input2"] + "',name='" + Request.Form["TextBox3"] + "',E='" + Request.Form["TextBox4"] + "',F='" + Request.Form["TextBox5"] + "',G='" + Request.Form["TextBox6"] + "',H='" + Request.Form["TextBox7"] + "',I='" + Request.Form["TextBox8"] + "',J='" + Request.Form["TextBox9"] + "',K='" + Request.Form["TextBox10"] + "',L='" + Request.Form["TextBox11"] + "',M='" + Request.Form["TextBox12"] + "',N='" + Request.Form["TextBox13"] + "',O='" + Request.Form["TextBox14"] + "',P='" + Request.Form["TextBox15"] + "',Q='" + Request.Form["TextBox16"] + "',R='" + Request.Form["TextBox17"] + "',S='" + Request.Form["TextBox18"] + "',T='" + Request.Form["TextBox19"] + "',U='" + Request.Form["TextBox20"] + "',V='" + Request.Form["TextBox21"] + "',W='" + Request.Form["TextBox22"] + "',X='" + Request.Form["TextBox23"] + "',Y='" + Request.Form["TextBox24"] + "',Z='" + Request.Form["TextBox25"] + "',AA='" + Request.Form["TextBox26"] + "',AB='" + Request.Form["TextBox27"] + "',AC='" + Request.Form["TextBox28"] + "',AD='" + Request.Form["TextBox29"] + "',AE='" + Request.Form["TextBox30"] + "',AF='" + Request.Form["TextBox31"] + "',AG='" + Request.Form["TextBox32"] + "',AH='" + Request.Form["TextBox33"] + "',AI='" + Request.Form["TextBox34"] + "',AJ='" + Request.Form["input35"] + "',AK='" + Request.Form["input36"] + "',AL='" + Request.Form["input37"] + "',AM='" + Request.Form["input38"] + "',AN='" + Request.Form["input39"] + "' where id='" + bb[39] + "'";
                cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                for (int i = 2; i < 34; i++)
                {
                    aa[i] = Request.Form["TextBox" + i];
                }
                aa[0]=Request.Form["input1"];
                aa[1]=Request.Form["input2"];
                aa[34]=Request.Form["input35"];
                aa[35]=Request.Form["input36"];
                aa[36]=Request.Form["input37"];
                aa[37]=Request.Form["input38"];
                aa[38]=Request.Form["input39"];
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