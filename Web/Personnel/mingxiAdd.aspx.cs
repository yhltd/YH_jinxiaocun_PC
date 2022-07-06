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
    public partial class mingxiAdd : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Textbox1.Attributes.Add("onpropertychange", "getInfo1()");
            }
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
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
            Textbox54.Text = DateTime.Now.ToString("yyyy-MM-dd");
            conn.Close();
            //Textbox1.Attributes.Add("onfocusout", "EnterTextBox()");
            Textbox1.Attributes["onblur"] = ClientScript.GetPostBackEventReference(Button3, null);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextBox1"] != "")
            {
                string conString = ConfigurationManager.AppSettings["yao"];
                conn = new SqlConnection(conString);  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sqlStr = "insert into gongzi_gongzimingxi (B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AP,AQ,AR,ASA,ATA,AU,AV,AW,AX,AY,AZ,BA,BB,BC,BD) VALUES (";
                for (int i = 1; i < 55; i++)
                {
                    if (i == 21 || i == 23)
                    {
                        sqlStr += "'" + Request.Form["DropDownList" + i] + "',";
                    }
                    else
                    {
                        if (Request.Form["TextBox" + i] != "")
                        {
                            sqlStr += "'" + Request.Form["TextBox" + i] + "',";
                        }
                        else if (i == 2 || i == 3 || i == 4 || i == 5 || i == 52 || i == 54)
                        {
                            sqlStr += "'',";
                        }
                        else
                        {
                            sqlStr += "'0',";
                        }
                    }

                }
                sqlStr += "'" + Session["gongsi"].ToString() + "');";
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                Server.Transfer("../Personnel/gongzimingxi.aspx");
                conn.Close();
            }
            else
            {

            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/gongzimingxi.aspx");
        }

        protected void getInfo(object sender, EventArgs e)
        {
            HrMingXiModel hm = new HrMingXiModel();
            string name = Request.Form["Textbox1"];
            List<gongzi_renyuan> list = hm.getRenYuanInfo(Session["gongsi"].ToString(), name);

            if (list.Count != 0)
            {
                ((TextBox)this.FindControl("TextBox2")).Text = list[0].C;//部门
                ((TextBox)this.FindControl("TextBox3")).Text = list[0].D;//岗位
                ((TextBox)this.FindControl("TextBox4")).Text = list[0].E;//身份证
                ((TextBox)this.FindControl("TextBox6")).Text = list[0].F;//基本工资
                ((TextBox)this.FindControl("TextBox5")).Text = list[0].H;//入职时间
                ((TextBox)this.FindControl("TextBox52")).Text = list[0].G;//银行账号
            }


        }
    }
}