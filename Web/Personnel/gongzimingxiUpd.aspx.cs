using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class gongzimingxiUpd : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        string[] aa = new string[55];
        public static string a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string conString = ConfigurationManager.AppSettings["yao"];

                conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sqlStr = "select kaoqin from gongzi_peizhi  where kaoqin!='' and kaoqin is not null group by kaoqin ;";
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                while (str.Read())
                {
                    DropDownList21.Items.Add(new ListItem((string)str["kaoqin"], (string)str["kaoqin"]));
                }
                conn.Close();

                conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                sqlStr = "select kaoqin_peizhi from gongzi_peizhi  where kaoqin_peizhi!='' and kaoqin_peizhi is not null group by kaoqin_peizhi ;";
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                while (str.Read())
                {
                    DropDownList23.Items.Add(new ListItem((string)str["kaoqin_peizhi"], (string)str["kaoqin_peizhi"]));
                }
                conn.Close();

                conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                sqlStr = "select * from gongzi_gongzimingxi where B='" + Session["b"].ToString() + "'";
                String sa = Session["year"].ToString();
                if (!sa.Equals(""))
                {
                    sqlStr = sqlStr + " and C='" + Session["year"].ToString() + "'";
                }
                if (!Session["moth"].ToString().Equals(""))
                {
                    sqlStr = sqlStr + " and D='" + Session["moth"].ToString() + "'";
                }
                if (!Session["name"].ToString().Equals(""))
                {
                    sqlStr = sqlStr + " and F='" + Session["name"].ToString() + "'";
                }
                sqlStr = sqlStr + ";";
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                //string a = Request["strs"].ToString();
                //string[] strs = a.Split(new char[1] { ',' });
                while (str.Read())
                {

                    a = Convert.ToString(str["id"]);
                    //(string)str["id"]; 
                    aa[0] = (string)str["B"];
                    aa[1] = (string)str["C"];
                    aa[2] = (string)str["D"];
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
                    aa[40] = (string)str["AP"];
                    aa[41] = (string)str["AQ"];
                    aa[42] = (string)str["AR"];
                    aa[43] = (string)str["ASA"];
                    aa[44] = (string)str["ATA"];
                    aa[45] = (string)str["AU"];
                    aa[46] = (string)str["AV"];
                    aa[47] = (string)str["AW"];
                    aa[48] = (string)str["AX"];
                    aa[49] = (string)str["AY"];
                    aa[50] = (string)str["AZ"];
                    aa[51] = (string)str["BA"];
                    aa[52] = (string)str["BB"];
                    aa[53] = (string)str["BC"];
                    aa[54] = (string)str["BD"];
                }
                for (int i = 1; i < 55; i++)
                {

                    if (i == 1 || i == 4 || i == 51 || i == 3 || i == 22 || i == 49 || i == 2 || i == 52)
                    {
                        
                        ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = aa[i - 1];
                    }
                    else if (i == 5 || i == 50 || i == 47)
                    {
                        //((HtmlInputGenericControl)this.FindControl("TextBox" + i.ToString())).Value = aa[i - 1];
                        ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = aa[i - 1];
                    }
                    else if (i == 21 || i == 23) 
                    {
                        ListItem item = ((DropDownList)this.FindControl("DropDownList" + i.ToString())).Items.FindByText(aa[i-1].ToString());
                        if (item != null)
                        {
                            item.Selected = true;
                        }
                    }
                    else
                    {
                        //((HtmlInputControl)this.FindControl("TextBox" + (i).ToString())).Value = aa[i - 1];
                        ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = aa[i - 1];
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] sqlarry = new string[] { "B", "C", "D", "E", " F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "ASA", "ATA", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD" };
            //string a = Request["strs"].ToString();
            string[] bb = new string[55];
            bb[54] = a;
            string conString = ConfigurationManager.AppSettings["yao"];
            conn = new SqlConnection(conString);  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //str = conn.BeginTransaction();
            string sqlStr = "update gongzi_gongzimingxi set " ;
            for (int i = 1; i < 55; i++)
            {
                if (i < 54 &&(i!=21 || i!=23))
                {
                    sqlStr += sqlarry[i - 1] + "='" + Request.Form["TextBox" + i] + "',";
                }
                else if (i == 21 || i == 23)
                {
                    sqlStr += sqlarry[i - 1] + "='" + Request.Form["DropDownList" + i] + "',";
                }
                else
                {
                    sqlStr += sqlarry[i - 1] + "='" + Request.Form["TextBox" + i] + "'";
                }
            }
            sqlStr += " where id='"+bb[54]+"';";
            cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            //for (int i = 2; i < 34; i++)
            //{
            //   aa[i] = Request.Form["TextBox" + i];
            //}
            Server.Transfer("../Personnel/gongzimingxi.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/gongzimingxi.aspx");
        }
    }
}