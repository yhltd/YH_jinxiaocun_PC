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
        public static string a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = Session["year"].ToString();//DateTime.Now.Year.ToString();
                TextBox2.Text = Session["moth"].ToString();//DateTime.Now.Month.ToString();
                TextBox3.Text = Session["name"].ToString();
                DateTime dt2 = DateTime.Parse(Session["year"].ToString() + "/" + Session["moth"].ToString() + "/1").AddMonths(1).AddDays(-1);
                int x = dt2.Day;
                string conString = ConfigurationManager.AppSettings["yao"];
                conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string moth = "";
                if (Convert.ToInt32(TextBox2.Text) < 10)
                {
                    moth = "0" + TextBox2.Text;
                }
                else 
                {
                    moth = TextBox2.Text;
                }
                string sqlStr = "select * from gongzi_kaoqinjilu where year='" + TextBox1.Text + "' and moth='" + moth + "' and name='" + TextBox3.Text + "' ;";
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                string[] aa = new string[40];

                //for (int i = 2; i < 34; i++)
                //{
                //    string b = ((TextBox)this.FindControl("TextBox" + (i + 1).ToString())).ToString();
                //    ((TextBox)this.FindControl("TextBox" + (i + 1).ToString())).Text = aa[i].ToString();
                //}


                //string a = (string)str;
                //aa[i] = (string)str[i];
                while (str.Read())
                {

                    a = Convert.ToString(str["id"]);
                    //(string)str["id"]; 
                    aa[0] = (string)str["year"];
                    aa[1] = (string)str["moth"];
                    aa[2] = (string)str["name"];
                    aa[3] = (string)str["E"];
                    aa[4] = (string)str["F"];
                    aa[5] = (string)str["G"];
                    aa[6] = (string)str["H"];
                    aa[7] = (string)str["I"];
                    aa[8] = (string)str["J"];
                    aa[9] = (string)str["K"];
                    aa[10] = (string)str["L"];
                    aa[11] = (string)str["M"];
                    aa[12] = (string)str["N"];
                    aa[13] = (string)str["O"];
                    aa[14] = (string)str["P"];
                    aa[15] = (string)str["Q"];
                    aa[16] = (string)str["R"];
                    aa[17] = (string)str["S"];
                    aa[18] = (string)str["T"];
                    aa[19] = (string)str["U"];
                    aa[20] = (string)str["V"];
                    aa[21] = (string)str["W"];
                    aa[22] = (string)str["X"];
                    aa[23] = (string)str["Y"];
                    aa[24] = (string)str["Z"];
                    aa[25] = (string)str["AA"];
                    aa[26] = (string)str["AB"];
                    aa[27] = (string)str["AC"];
                    aa[28] = (string)str["AD"];
                    aa[29] = (string)str["AE"];
                    aa[30] = (string)str["AF"];
                    aa[31] = (string)str["AG"];
                    aa[32] = (string)str["AH"];
                    aa[33] = (string)str["AI"];
                    aa[34] = (string)str["AJ"];
                    aa[35] = (string)str["AK"];
                    aa[36] = (string)str["AL"];
                    aa[37] = (string)str["AM"];
                    aa[38] = (string)str["AN"];
                    aa[39] = (string)str["AO"];
                }
                
                
                    
                
                for (int i = 4; i <= 34; i++)
                {
                    //string b = ((DropDownList)this.FindControl("DropDownList" + (i + 1).ToString())).ToString();
                    //((DropDownList)this.FindControl("DropDownList" + (i + 1).ToString())).Text = aa[i].ToString();
                    ListItem item = ((DropDownList)this.FindControl("DropDownList" + i.ToString())).Items.FindByText(aa[i].ToString());
                    if (item != null) {
                        item.Selected = true;
                    }
                }
                TextBox1.Text = aa[0].ToString();
                TextBox2.Text = aa[1].ToString();
                TextBox3.Text = aa[2].ToString();
                TextBox35.Text = aa[34].ToString();
                TextBox36.Text = aa[35].ToString();
                TextBox37.Text = aa[36].ToString();
                TextBox38.Text = aa[37].ToString();
                TextBox39.Text = aa[38].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextBox1"] != "" && Request.Form["TextBox2"] != "" && Request.Form["TextBox3"] != "" && Request.Form["TextBox1"] != " " && Request.Form["TextBox2"] != " " && Request.Form["TextBox3"] != " " && Convert.ToInt32(Request.Form["TextBox2"]) > 0 && Convert.ToInt32(Request.Form["TextBox2"]) < 13)
            {
                //string a = Request["strs"].ToString();
                string[] bb = new string[40];
                bb[39] = a;
                string conString = ConfigurationManager.AppSettings["yao"];
                conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string moth = "";
                if (Convert.ToInt32(Request.Form["TextBox2"].Trim()) < 10)
                {
                    moth = "0" + Convert.ToInt32(Request.Form["TextBox2"].Trim());
                }
                else 
                {
                    moth =  Request.Form["TextBox2"].Trim();
                }
                //str = conn.BeginTransaction();
                string sqlStr = "update gongzi_kaoqinjilu set year='" + Request.Form["TextBox1"].Trim() + "',moth='" + moth + "',name='" + Request.Form["TextBox3"].Trim() + "',E='" + Request.Form["DropDownList4"].Trim() + "',F='" + Request.Form["DropDownList5"].Trim() + "',G='" + Request.Form["DropDownList6"].Trim() + "',H='" + Request.Form["DropDownList7"].Trim() + "',I='" + Request.Form["DropDownList8"].Trim() + "',J='" + Request.Form["DropDownList9"].Trim() + "',K='" + Request.Form["DropDownList10"].Trim() + "',L='" + Request.Form["DropDownList11"].Trim() + "',M='" + Request.Form["DropDownList12"].Trim() + "',N='" + Request.Form["DropDownList13"].Trim() + "',O='" + Request.Form["DropDownList14"].Trim() + "',P='" + Request.Form["DropDownList15"].Trim() + "',Q='" + Request.Form["DropDownList16"].Trim() + "',R='" + Request.Form["DropDownList17"].Trim() + "',S='" + Request.Form["DropDownList18"].Trim() + "',T='" + Request.Form["DropDownList19"].Trim() + "',U='" + Request.Form["DropDownList20"].Trim() + "',V='" + Request.Form["DropDownList21"].Trim() + "',W='" + Request.Form["DropDownList22"].Trim() + "',X='" + Request.Form["DropDownList23"].Trim() + "',Y='" + Request.Form["DropDownList24"].Trim() + "',Z='" + Request.Form["DropDownList25"].Trim() + "',AA='" + Request.Form["DropDownList26"].Trim() + "',AB='" + Request.Form["DropDownList27"].Trim() + "',AC='" + Request.Form["DropDownList28"].Trim() + "',AD='" + Request.Form["DropDownList29"].Trim() + "',AE='" + Request.Form["DropDownList30"].Trim() + "',AF='" + Request.Form["DropDownList31"].Trim() + "',AG='" + Request.Form["DropDownList32"].Trim() + "',AH='" + Request.Form["DropDownList33"].Trim() + "',AI='" + Request.Form["DropDownList34"].Trim() + "',AJ='" + Request.Form["TextBox35"].Trim() + "',AK='" + Request.Form["TextBox36"].Trim() + "',AL='" + Request.Form["TextBox37"].Trim() + "',AM='" + Request.Form["TextBox38"].Trim() + "',AN='" + Request.Form["TextBox39"].Trim() + "' where id='" + bb[39] + "'";
                cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                
                //for (int i = 2; i < 34; i++)
                //{
                //    aa[i] = ((TextBox)this.FindControl("TextBox" + (i + 1).ToString())).Text;
                //}
                //aa[0] = Request.Form["TextBox1"];
                //aa[1] = Request.Form["TextBox2"];
                //aa[34] = Request.Form["TextBox35"];
                //aa[35] = Request.Form["TextBox36"];
                //aa[36] = Request.Form["TextBox37"];
                //aa[37] = Request.Form["TextBox38"];
                //aa[38] = Request.Form["TextBox39"];
                Server.Transfer("../Personnel/kaoqin.aspx");
        
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>MyFun();</script>");
                
            }
           
            
        }


        
        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/kaoqin.aspx");
        }
    }
}