using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class quanxian : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        string[] strstr1 = null;
        string[] strstr2 = null;
        string[] strstr3 = null;
        string[] strstr4 = null;
        string[] strstr5 = null;
        string[] strstr6 = null;
        string[] strstr7 = null;
        string[] strstr8 = null;
        string[] strstr9 = null;
        string[] strstr10 = null;
        string[] strstr11 = null;
        string[] strstr12 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            //aaaa = 0;
            string conString = ConfigurationManager.AppSettings["yao"];
            conn = new SqlConnection(conString);  //数据库连接。
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sqlStr = "select * from gongzi_renyuanManager where R_id='" + Session["id1"].ToString() + "';";
            string aaa = Session["id1"].ToString();
            cmd = new SqlCommand(sqlStr, conn);
            str = cmd.ExecuteReader();
            while (str.Read())
            {
                if (str[6].ToString() == "1")
                {
                    string[] arr1 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr1"] = arr1;
                }
                if (str[6].ToString() == "2")
                {
                    string[] arr2 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr2"] = arr2;
                }
                if (str[6].ToString() == "3")
                {

                    string[] arr3 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr3"] = arr3;
                }
                if (str[6].ToString() == "4")
                {
                    string[] arr4 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr4"] = arr4;
                }
                if (str[6].ToString() == "5")
                {
                    string[] arr5 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr5"] = arr5;
                }
                if (str[6].ToString() == "6")
                {
                    string[] arr6 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr6"] = arr6;
                }
                if (str[6].ToString() == "7")
                {
                    string[] arr7 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr7"] = arr7;
                }
                if (str[6].ToString() == "8")
                {
                    string[] arr8 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr8"] = arr8;
                }
                if (str[6].ToString() == "9")
                {
                    string[] arr9 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr9"] = arr9;
                }
                if (str[6].ToString() == "10")
                {
                    string[] arr10 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr10"] = arr10;
                }
                if (str[6].ToString() == "11")
                {
                    string[] arr11 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr11"] = arr11;
                }
                if (str[6].ToString() == "12")
                {
                    string[] arr12 = new string[] { str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString(), str[4].ToString(), str[5].ToString(), str[6].ToString() };
                    Session["arrarr12"] = arr12;
                }
            }
            strstr1 = (string[])Session["arrarr1"];
            strstr2 = (string[])Session["arrarr2"];
            strstr3 = (string[])Session["arrarr3"];
            strstr4 = (string[])Session["arrarr4"];
            strstr5 = (string[])Session["arrarr5"];
            strstr6 = (string[])Session["arrarr6"];
            strstr7 = (string[])Session["arrarr7"];
            strstr8 = (string[])Session["arrarr8"];
            strstr9 = (string[])Session["arrarr9"];
            strstr10 = (string[])Session["arrarr10"];
            strstr11 = (string[])Session["arrarr11"];
            strstr12 = (string[])Session["arrarr12"];
            if (Session["aaaa"].ToString() == "0")
            {
            if (strstr1[1].ToString() == "1")
            {
                CheckBox1.Checked = true;
            }
            if (strstr1[2].ToString() == "1")
            {
                CheckBox2.Checked = true;
            }
            if (strstr1[3].ToString() == "1")
            {
                CheckBox3.Checked = true;
            }
            if (strstr1[4].ToString() == "1")
            {
                CheckBox4.Checked = true;
            }
            if (strstr1[5].ToString() == "1")
            {
                CheckBox5.Checked = true;
            }




            if (strstr2[1].ToString() == "1")
            {
                CheckBox6.Checked = true;
            }
            if (strstr2[2].ToString() == "1")
            {
                CheckBox7.Checked = true;
            }
            if (strstr2[3].ToString() == "1")
            {
                CheckBox8.Checked = true;
            }
            if (strstr2[4].ToString() == "1")
            {
                CheckBox9.Checked = true;
            }
            if (strstr2[5].ToString() == "1")
            {
                CheckBox10.Checked = true;
            }




            if (strstr3[2].ToString() == "1")
            {
                CheckBox11.Checked = true;
            }
            if (strstr3[3].ToString() == "1")
            {
                CheckBox12.Checked = true;
            }
            if (strstr3[4].ToString() == "1")
            {
                CheckBox13.Checked = true;
            }
            if (strstr3[5].ToString() == "1")
            {
                CheckBox14.Checked = true;
            }


            if (strstr4[1].ToString() == "1")
            {
                CheckBox15.Checked = true;
            }
            if (strstr4[2].ToString() == "1")
            {
                CheckBox16.Checked = true;
            }
            if (strstr4[3].ToString() == "1")
            {
                CheckBox17.Checked = true;
            }
            if (strstr4[5].ToString() == "1")
            {
                CheckBox18.Checked = true;
            }



            if (strstr5[1].ToString() == "1")
            {
                CheckBox19.Checked = true;
            }
            if (strstr5[2].ToString() == "1")
            {
                CheckBox20.Checked = true;
            }
            if (strstr5[3].ToString() == "1")
            {
                CheckBox21.Checked = true;
            }
            if (strstr5[4].ToString() == "1")
            {
                CheckBox22.Checked = true;
            }
            if (strstr5[5].ToString() == "1")
            {
                CheckBox23.Checked = true;
            }



            if (strstr6[2].ToString() == "1")
            {
                CheckBox24.Checked = true;
            }
            if (strstr6[3].ToString() == "1")
            {
                CheckBox25.Checked = true;
            }
            if (strstr6[4].ToString() == "1")
            {
                CheckBox26.Checked = true;
            }
            if (strstr6[5].ToString() == "1")
            {
                CheckBox27.Checked = true;
            }



            if (strstr7[1].ToString() == "1")
            {
                CheckBox28.Checked = true;
            }
            if (strstr7[2].ToString() == "1")
            {
                CheckBox29.Checked = true;
            }
            if (strstr7[3].ToString() == "1")
            {
                CheckBox30.Checked = true;
            }
            if (strstr7[4].ToString() == "1")
            {
                CheckBox31.Checked = true;
            }
            if (strstr7[5].ToString() == "1")
            {
                CheckBox32.Checked = true;
            }



            if (strstr8[4].ToString() == "1")
            {
                CheckBox33.Checked = true;
            }
            if (strstr8[5].ToString() == "1")
            {
                CheckBox34.Checked = true;
            }






            if (strstr9[4].ToString() == "1")
            {
                CheckBox35.Checked = true;
            }
            if (strstr9[5].ToString() == "1")
            {
                CheckBox36.Checked = true;
            }



            if (strstr10[4].ToString() == "1")
            {
                CheckBox37.Checked = true;
            }
            if (strstr10[5].ToString() == "1")
            {
                CheckBox38.Checked = true;
            }



            if (strstr11[4].ToString() == "1")
            {
                CheckBox39.Checked = true;
            }
            if (strstr11[5].ToString() == "1")
            {
                CheckBox40.Checked = true;
            }



            if (strstr12[4].ToString() == "1")
            {
                CheckBox41.Checked = true;
            }
            if (strstr12[5].ToString() == "1")
            {
                CheckBox42.Checked = true;
            }
            Session["aaaa"] = "1";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.AppSettings["yao"];
            conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql ="";
                int xx =0;
                for (int i = 1; i < 43; i++)
                {
                    if (i == 1||i==6||i==11||i==15||i==19||i==24||i==28||i==33||i==35||i==37||i==39||i==41) {
                        sql += "UPDATE gongzi_renyuanManager SET ";
                    }
                    if (i == 1 || i == 6 || i == 15 || i == 19 || i == 28)
                    {
                        if (((CheckBox)this.FindControl("CheckBox" + i.ToString())).Checked.ToString() == "True")
                        {
                            sql += "[add]='1',";
                            Boolean v =CheckBox3.Checked;
                        }
                        else
                        {
                            sql += "[add]='0',";
                        }
                    }
                    if (i == 2 || i == 7 || i == 11 || i == 16 || i == 20 || i ==24|| i ==29)
                    {
                        if (((CheckBox)this.FindControl("CheckBox" + i.ToString())).Checked.ToString() == "True")
                        {
                            sql += "del='1',";
                        }
                        else
                        {
                            sql += "del='0',";
                        }
                    }
                    if (i == 3 || i == 8 || i == 12|| i == 17 || i == 21 || i == 25 || i ==30)
                    {
                        if (((CheckBox)this.FindControl("CheckBox" + i.ToString())).Checked.ToString() == "True")
                        {
                            sql += "upd='1',";
                        }
                        else
                        {
                            sql += "upd='0',";
                        }
                    }
                    if (i == 4 || i == 9 || i == 13 || i == 22 || i == 26 || i == 31 || i == 33|| i ==35|| i ==37|| i ==39|| i ==41)
                    {
                        if (((CheckBox)this.FindControl("CheckBox" + i.ToString())).Checked.ToString() == "True")
                        {
                            sql += "sel='1',";
                        }
                        else
                        {
                            sql += "sel='0',";
                        }
                    }
                    if (i == 5 || i == 10 || i == 14 || i == 18 || i == 23 || i == 27 || i == 32 || i == 34 || i == 36 || i == 38 || i == 40 || i == 42)
                    {
                        xx = xx+1;
                        if (((CheckBox)this.FindControl("CheckBox" + i.ToString())).Checked.ToString() == "True")
                        {
                            sql += "look='1' where R_id='" + Session["id1"].ToString() + "' and view_id='"+xx+"';";
                        }
                        else
                        {
                            sql += "look='0' where R_id='" + Session["id1"].ToString() + "' and view_id='" + xx + "';";
                        }
                    }
                }
                
                cmd = new SqlCommand(sql, conn);
               cmd.ExecuteScalar();
               //ClientScript.RegisterStartupScript(this.GetType(), "", "<script>a()</script>");
        }
        protected void Button14_Click1(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/renyuanxinxiAdd.aspx");
        }
    }
}