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
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class gongzimingxiUpd : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str = null;
        SqlCommand cmd = null;
        string[] aa = new string[56];
        public static string a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList21.Items.Clear();
                DropDownList23.Items.Clear();
                DropDownList22.Items.Clear();
                DropDownList32.Items.Clear();
                DropDownList24.Items.Clear();
                DropDownList42.Items.Clear();
                DropDownList33.Items.Clear();
                DropDownList11.Items.Clear();
                DropDownList49.Items.Clear();
                DropDownList51.Items.Clear();
                DropDownList10.Items.Clear();
                DropDownList41.Items.Clear();

                HrMingXiModel hm = new HrMingXiModel();
                List<gongzi_peizhi> list = hm.getPeizhi(Session["gongsi"].ToString());

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].yiliao_jishu != null && !list[i].yiliao_jishu.Equals(""))
                    {
                        DropDownList22.Items.Add(new ListItem(list[i].yiliao_jishu, list[i].yiliao_jishu));//医疗技术
                    }
                    if (list[i].zhinajin != null && !list[i].zhinajin.Equals(""))
                    {
                        DropDownList32.Items.Add(new ListItem(list[i].zhinajin, list[i].zhinajin));//企业滞纳金
                        DropDownList41.Items.Add(new ListItem(list[i].zhinajin, list[i].zhinajin));//个人滞纳金
                    }
                    if (list[i].nianjin_jishu != null && !list[i].nianjin_jishu.Equals(""))
                    {
                        DropDownList24.Items.Add(new ListItem(list[i].nianjin_jishu, list[i].nianjin_jishu));//年金基数
                    }
                    if (list[i].lixi != null && !list[i].lixi.Equals(""))
                    {
                        DropDownList42.Items.Add(new ListItem(list[i].lixi, list[i].lixi));//个人利息
                    }
                    if (list[i].lixi != null && !list[i].lixi.Equals(""))
                    {
                        DropDownList33.Items.Add(new ListItem(list[i].lixi, list[i].lixi));//公司利息
                    }
                    if (list[i].jintie != null && !list[i].jintie.Equals(""))
                    {
                        DropDownList11.Items.Add(new ListItem(list[i].jintie, list[i].jintie));//职称津贴
                    }
                    if (list[i].nianjin1 != null && !list[i].nianjin1.Equals(""))
                    {
                        DropDownList49.Items.Add(new ListItem(list[i].nianjin1, list[i].nianjin1));//年金1%
                    }
                    if (list[i].yansuangongshi != null && !list[i].yansuangongshi.Equals(""))
                    {
                        DropDownList51.Items.Add(new ListItem(list[i].yansuangongshi, list[i].yansuangongshi));//验算公式
                    }
                    if (list[i].kuadu_gongzi != null && !list[i].kuadu_gongzi.Equals(""))
                    {
                        DropDownList10.Items.Add(new ListItem(list[i].kuadu_gongzi, list[i].kuadu_gongzi));//跨度工资
                    }
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
                    aa[55] = (string)str["BE"];
                }
                for (int i = 1; i < 56; i++)
                {
                    if (i == 21 || i == 23 || i == 22 || i == 32 || i == 24 || i == 42 || i == 33 || i == 11 || i == 49 || i == 51 || i == 10 || i == 41)
                    {
                        ListItem item = ((DropDownList)this.FindControl("DropDownList" + i.ToString())).Items.FindByText(aa[i - 1].ToString());
                        if (item != null)
                        {
                            item.Selected = true;
                        }
                    }
                    else
                    {
                        ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = aa[i - 1];
                    }

                    //if (i == 1 || i == 4 || i == 51 || i == 3 || i == 22 || i == 49 || i == 2 || i == 52)
                    //{
                        
                    //    ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = aa[i - 1];
                    //}
                    //else if (i == 5 || i == 50 || i == 47)
                    //{
                    //    //((HtmlInputGenericControl)this.FindControl("TextBox" + i.ToString())).Value = aa[i - 1];
                    //    ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = aa[i - 1];
                    //}
                    //else if (i == 21 || i == 23 || i == 22 || i == 32 || i == 24 || i == 42 || i == 33 || i == 11 || i == 49 || i == 51 || i == 10 || i == 41) 
                    //{
                    //    ListItem item = ((DropDownList)this.FindControl("DropDownList" + i.ToString())).Items.FindByText(aa[i-1].ToString());
                    //    if (item != null)
                    //    {
                    //        item.Selected = true;
                    //    }
                    //}
                    //else
                    //{
                    //    //((HtmlInputControl)this.FindControl("TextBox" + (i).ToString())).Value = aa[i - 1];
                    //    ((TextBox)this.FindControl("TextBox" + i.ToString())).Text = aa[i - 1];
                    //}
                }
                ((TextBox)this.FindControl("TextBox55")).Text = aa[55];
                Textbox1.Attributes["onblur"] = ClientScript.GetPostBackEventReference(Button3, null);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] sqlarry = new string[] { "B", "C", "D", "E", " F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "ASA", "ATA", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC","BE","BD" };
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
                if (i < 54 && (i != 21 && i != 23 && i != 22 && i != 32 && i != 24 && i != 42 && i != 33 && i != 11 && i != 49 && i != 51 && i != 10 && i != 41))
                {
                    sqlStr += sqlarry[i - 1] + "='" + Request.Form["TextBox" + i] + "',";
                }
                else if (i == 21 || i == 23 || i == 22 || i == 32 || i == 24 || i == 42 || i == 33 || i == 11 || i == 49 || i == 51 || i == 10 || i == 41)
                {
                    sqlStr += sqlarry[i - 1] + "='" + Request.Form["DropDownList" + i] + "',";
                }
                else
                {
                    sqlStr += sqlarry[i - 1] + "='" + Request.Form["TextBox" + i] + "'";
                }
            }
            sqlStr += ",BE='" + Request.Form["TextBox55"] + "' ";
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
                ((TextBox)this.FindControl("Textbox7")).Text = list[0].AC;//绩效工资
            }

            string yue = (Request.Form["Textbox54"]).Split('-')[1];
            List<gongzi_kaoqinjilu> kq = hm.getKaoQinByName(Session["gongsi"].ToString(), name, yue);
            if (kq.Count != 0)
            {
                ((TextBox)this.FindControl("Textbox12")).Text = kq[0].AK;//出勤天数
                ((TextBox)this.FindControl("Textbox16")).Text = Convert.ToString(Convert.ToInt32(kq[0].AJ) - Convert.ToInt32(kq[0].AK));//缺勤天数
                ((TextBox)this.FindControl("Textbox18")).Text = kq[0].AN;//迟到天数
                ((TextBox)this.FindControl("Textbox13")).Text = kq[0].AM;//加班

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (notisnull(Request.Form["Textbox1"]) == false)
            {
                return;
            }
            HrMingXiModel hm = new HrMingXiModel();
            List<gongzi_peizhi> list = hm.getPeizhi(Session["gongsi"].ToString());
            double chidao_koukuan = 0;
            double jiabanfei = 0;
            double queqin_koukuan = 0;
            double geren_yiliao = 0;
            double qiye_yiliao = 0;
            double geren_shengyu = 0;
            double qiye_shengyu = 0;
            double geren_yanglao = 0;
            double qiye_yanglao = 0;
            double geren_shiye = 0;
            double qiye_shiye = 0;
            double qiye_gongshang = 0;
            double geren_nianjin = 0;
            double qiye_nianjin = 0;
            double geren_gongjijin = 0;
            double qiye_gongjijin = 0;

            double yingshui_gongzi = 0;
            double shifa_gongzi = 0;
            double daikou_geshui = 0;

            //迟到扣款
            if (notisnull(Request.Form["Textbox18"]) && notisnull(list[0].chidao_koukuan) && isnumeric(list[0].chidao_koukuan))
            {
                ((TextBox)this.FindControl("TextBox19")).Text = Convert.ToString(Convert.ToDouble(list[0].chidao_koukuan) * Convert.ToDouble(Request.Form["Textbox18"]));
                chidao_koukuan = Convert.ToDouble(list[0].chidao_koukuan) * Convert.ToDouble(Request.Form["Textbox18"]);
            }
            //加班费
            if (notisnull(Request.Form["Textbox13"]) && notisnull(list[0].jiabanfei) && isnumeric(list[0].jiabanfei))
            {
                ((TextBox)this.FindControl("Textbox14")).Text = Convert.ToString(Convert.ToDouble(list[0].jiabanfei) * Convert.ToDouble(Request.Form["Textbox13"]));
                jiabanfei = Convert.ToDouble(list[0].jiabanfei) * Convert.ToDouble(Request.Form["Textbox13"]);
            }
            //缺勤扣款
            if (notisnull(Request.Form["Textbox16"]) && notisnull(list[0].queqin_koukuan) && isnumeric(list[0].queqin_koukuan))
            {
                ((TextBox)this.FindControl("Textbox17")).Text = Convert.ToString(Convert.ToDouble(list[0].queqin_koukuan) * Convert.ToDouble(Request.Form["Textbox16"]));
                queqin_koukuan = Convert.ToDouble(list[0].queqin_koukuan) * Convert.ToDouble(Request.Form["Textbox16"]);
            }
            //个人医疗
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].geren_yiliao) && isnumeric(list[0].geren_yiliao))
            {
                ((TextBox)this.FindControl("Textbox37")).Text = Convert.ToString(Convert.ToDouble(list[0].geren_yiliao) * Convert.ToDouble(Request.Form["Textbox6"]));
                geren_yiliao = Convert.ToDouble(list[0].geren_yiliao) * Convert.ToDouble(Request.Form["Textbox6"]);
            }
            //企业医疗
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].qiye_yiliao) && isnumeric(list[0].qiye_yiliao))
            {
                ((TextBox)this.FindControl("Textbox27")).Text = Convert.ToString(Convert.ToDouble(list[0].qiye_yiliao) * Convert.ToDouble(Request.Form["Textbox6"]));
                qiye_yiliao = Convert.ToDouble(list[0].qiye_yiliao) * Convert.ToDouble(Request.Form["Textbox6"]);
            }
            //个人生育
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].geren_shengyu) && isnumeric(list[0].geren_shengyu))
            {
                ((TextBox)this.FindControl("Textbox38")).Text = Convert.ToString(Convert.ToDouble(list[0].geren_shengyu) * Convert.ToDouble(Request.Form["Textbox6"]));
                geren_shengyu = Convert.ToDouble(list[0].geren_shengyu) * Convert.ToDouble(Request.Form["Textbox6"]);
            }
            //企业生育
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].qiye_shengyu) && isnumeric(list[0].qiye_shengyu))
            {
                ((TextBox)this.FindControl("Textbox29")).Text = Convert.ToString(Convert.ToDouble(list[0].qiye_shengyu) * Convert.ToDouble(Request.Form["Textbox6"]));
                qiye_shengyu = Convert.ToDouble(list[0].qiye_shengyu) * Convert.ToDouble(Request.Form["Textbox6"]);
            }
            //个人养老
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].geren_yanglao) && isnumeric(list[0].geren_yanglao))
            {
                ((TextBox)this.FindControl("Textbox35")).Text = Convert.ToString(Convert.ToDouble(list[0].geren_yanglao) * Convert.ToDouble(Request.Form["Textbox6"]));
                geren_yanglao = Convert.ToDouble(list[0].geren_yanglao) * Convert.ToDouble(Request.Form["Textbox6"]);
            }
            //企业养老
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].qiye_yanglao) && isnumeric(list[0].qiye_yanglao))
            {
                ((TextBox)this.FindControl("Textbox25")).Text = Convert.ToString(Convert.ToDouble(list[0].qiye_yanglao) * Convert.ToDouble(Request.Form["Textbox6"]));
                qiye_yanglao = Convert.ToDouble(list[0].qiye_yanglao) * Convert.ToDouble(Request.Form["Textbox6"]);
            }
            //个人失业
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].geren_shiye) && isnumeric(list[0].geren_shiye))
            {
                ((TextBox)this.FindControl("Textbox36")).Text = Convert.ToString(Convert.ToDouble(list[0].geren_shiye) * Convert.ToDouble(Request.Form["Textbox6"]));
                geren_shiye = Convert.ToDouble(list[0].geren_shiye) * Convert.ToDouble(Request.Form["Textbox6"]);
            }
            //企业失业
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].qiye_shiye) && isnumeric(list[0].qiye_shiye))
            {
                ((TextBox)this.FindControl("Textbox26")).Text = Convert.ToString(Convert.ToDouble(list[0].qiye_shiye) * Convert.ToDouble(Request.Form["Textbox6"]));
                qiye_shiye = Convert.ToDouble(list[0].qiye_shiye) * Convert.ToDouble(Request.Form["Textbox6"]);
            }
            //企业工伤
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].qiye_gongshang) && isnumeric(list[0].qiye_gongshang))
            {
                ((TextBox)this.FindControl("Textbox28")).Text = Convert.ToString(Convert.ToDouble(list[0].qiye_gongshang) * Convert.ToDouble(Request.Form["Textbox6"]));
                qiye_gongshang = Convert.ToDouble(list[0].qiye_gongshang) * Convert.ToDouble(Request.Form["Textbox6"]);
            }
            //个人年金
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].geren_nianjin) && isnumeric(list[0].geren_nianjin))
            {
                ((TextBox)this.FindControl("Textbox40")).Text = Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) * Convert.ToDouble(list[0].geren_nianjin));
                geren_nianjin = Convert.ToDouble(Request.Form["Textbox6"]) * Convert.ToDouble(list[0].geren_nianjin);
            }
            //企业年金
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].qiye_nianjin) && isnumeric(list[0].qiye_nianjin))
            {
                ((TextBox)this.FindControl("Textbox31")).Text = Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) * Convert.ToDouble(list[0].qiye_nianjin));
                qiye_nianjin = Convert.ToDouble(Request.Form["Textbox6"]) * Convert.ToDouble(list[0].qiye_nianjin);
            }
            //个人公积金
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].geren_gongjijin) && isnumeric(list[0].geren_gongjijin))
            {
                ((TextBox)this.FindControl("Textbox39")).Text = Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) * Convert.ToDouble(list[0].geren_gongjijin));
                geren_gongjijin = Convert.ToDouble(Request.Form["Textbox6"]) * Convert.ToDouble(list[0].geren_gongjijin);
            }
            //企业公积金
            if (notisnull(Request.Form["Textbox6"]) && notisnull(list[0].qiye_gongjijin) && isnumeric(list[0].qiye_gongjijin))
            {
                ((TextBox)this.FindControl("Textbox30")).Text = Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) * Convert.ToDouble(list[0].qiye_gongjijin));
                qiye_gongjijin = Convert.ToDouble(Request.Form["Textbox6"]) * Convert.ToDouble(list[0].qiye_gongjijin);
            }



            //税前工资
            ((TextBox)this.FindControl("TextBox44")).Text = Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]));

            for (int i = 0; i < list.Count; i++)
            {
                //岗位工资
                if (Request.Form["Textbox3"].Equals(list[i].gangwei))
                {
                    ((TextBox)this.FindControl("TextBox8")).Text = list[i].gangwei_gongzi;
                }
                //应税工资
                if (notisnull(Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]))) && notisnull(list[i].gongzi) && list[i].gongzi.Contains("-"))
                {
                    if (isnumeric(list[i].gongzi.Split('-')[0]) && isnumeric(list[i].gongzi.Split('-')[1]))
                    {
                        if (Convert.ToDouble(Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]))) >= Convert.ToDouble(list[i].gongzi.Split('-')[0]) && Convert.ToDouble(Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]))) <= Convert.ToDouble(list[i].gongzi.Split('-')[1]))
                        {
                            if (isnumeric(list[i].shuilv))
                            {
                                ((TextBox)this.FindControl("TextBox45")).Text = Convert.ToString(Convert.ToDouble(Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]))) - Convert.ToDouble(Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]))) * Convert.ToDouble(list[i].shuilv));
                                ((TextBox)this.FindControl("Textbox46")).Text = list[i].shuilv;
                                yingshui_gongzi = Convert.ToDouble(Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]))) - Convert.ToDouble(Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]))) * Convert.ToDouble(list[i].shuilv);
                                daikou_geshui = Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]) * Convert.ToDouble(list[i].shuilv);
                            }
                        }
                    }
                }
            }

            //个人小计
            ((TextBox)this.FindControl("Textbox43")).Text = Convert.ToString(geren_gongjijin + geren_nianjin + geren_shengyu + geren_shiye + geren_yanglao + geren_yiliao + Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]));
            //企业小计
            ((TextBox)this.FindControl("Textbox34")).Text = Convert.ToString(qiye_gongjijin + qiye_gongshang + qiye_nianjin + qiye_shengyu + qiye_shiye + qiye_yanglao + qiye_yiliao);
            //实发工资
            ((TextBox)this.FindControl("Textbox50")).Text = Convert.ToString(yingshui_gongzi - geren_gongjijin + geren_nianjin + geren_shengyu + geren_shiye + geren_yanglao + geren_yiliao + Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]));
            shifa_gongzi = yingshui_gongzi - geren_gongjijin + geren_nianjin + geren_shengyu + geren_shiye + geren_yanglao + geren_yiliao + Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]);
            //应发工资
            ((TextBox)this.FindControl("Textbox20")).Text = Convert.ToString(Convert.ToDouble(Request.Form["Textbox6"]) + Convert.ToDouble(Request.Form["Textbox7"]) - (geren_gongjijin + geren_nianjin + geren_shengyu + geren_shiye + geren_yanglao + geren_yiliao));
            //当月工资合计
            ((TextBox)this.FindControl("Textbox9")).Text = Convert.ToString(shifa_gongzi + jiabanfei - queqin_koukuan - chidao_koukuan);
            //代扣个税
            ((TextBox)this.FindControl("Textbox48")).Text = Convert.ToString(daikou_geshui);


        }

        //判断字符串是否为数字
        public bool isnumeric(string str)
        {
            foreach (char c in str)                   //遍历这个数组里的内容  
            {
                int d = 0;
                for (int i = 0; i <= 9; i++)
                {
                    if (c.ToString() == i.ToString() || c.ToString() == ".")
                    {
                        d = d + 1;
                    }
                }
                if (d < 1)
                {
                    return false;
                }
            }
            return true;
        }

        //判断字符串是否为空或null
        public bool notisnull(string str)
        {
            if (str == null || str.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}