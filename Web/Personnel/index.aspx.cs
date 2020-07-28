using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=sqloledb;server=yhocn.cn;Database=yao;Uid=sa;Pwd=Lyh07910_001;");  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sqlStr = "select * from gongzi_renyuanManager where R_id='" + Session["id1"].ToString() + "';";
            cmd = new SqlCommand(sqlStr, conn);
            str = cmd.ExecuteReader();
            while (str.Read())
            {
                if (str[6].ToString() == "1") {
                    string[] arr1 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr1"] = arr1;
                }
                if (str[6].ToString() == "2")
                {
                    string[] arr2 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr2"] = arr2;
                }
                if (str[6].ToString() == "3")
                {

                    string[] arr3 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr3"] = arr3;
                }
                if (str[6].ToString() == "4")
                {
                    string[] arr4 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr4"] = arr4;
                }
                if (str[6].ToString() == "5")
                {
                    string[] arr5 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr5"] = arr5;
                }
                if (str[6].ToString() == "6")
                {
                    string[] arr6 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr6"] = arr6;
                }
                if (str[6].ToString() == "7")
                {
                    string[] arr7 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr7"] = arr7;
                }
                if (str[6].ToString() == "8")
                {
                    string[] arr8 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr8"] = arr8;
                }
                if (str[6].ToString() == "9")
                {
                    string[] arr9 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr9"] = arr9;
                }
                if (str[6].ToString() == "10")
                {
                    string[] arr10 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr10"] = arr10;
                }
                if (str[6].ToString() == "11")
                {
                    string[] arr11 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr11"] = arr11;
                }
                if (str[6].ToString() == "12")
                {
                    string[] arr12 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arr12"] = arr12;
                }
            }
        }
    }
}