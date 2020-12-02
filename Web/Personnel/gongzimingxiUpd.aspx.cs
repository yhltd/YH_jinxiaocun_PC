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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string a = Request["strs"].ToString();
                string[] strs = a.Split(new char[1] { ',' });
                aa = strs;
                for (int i = 1; i < 54; i++)
                {

                    if (i == 1 || i == 4 || i == 51 || i == 3 || i == 22 || i == 49 || i == 2 || i == 52)
                    {
                        ((HtmlInputText)this.FindControl("input" + i.ToString())).Value = aa[i-1];
                    }
                    else if (i == 5 || i == 50 || i == 47)
                    {
                        ((HtmlInputGenericControl)this.FindControl("input" + (i).ToString())).Value = aa[i-1];
                    }
                    else
                    {
                        ((HtmlInputControl)this.FindControl("input" + (i).ToString())).Value = aa[i-1];
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] sqlarry = new string[] { "B", "C", "D", "E", " F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "ASA", "ATA", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD" };
            string a = Request["strs"].ToString();
            string[] bb = a.Split(new char[1] { ',' });
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
                if (i < 54)
                {
                    sqlStr += sqlarry[i - 1] + "='" + Request.Form["input" + i] + "',";
                }
                else {
                    sqlStr += sqlarry[i - 1] + "='" + Request.Form["input" + i] + "'";
                }
            }
            sqlStr += " where id='"+bb[54]+"';";
            cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            for (int i = 2; i < 34; i++)
            {
                aa[i] = Request.Form["input" + i];
            }
        }
    }
}