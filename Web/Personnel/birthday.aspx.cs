using SDZdb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class birthday : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader str1 = null;
        SqlCommand cmd = null;
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            HrMingXiModel hm = new HrMingXiModel();

            DateTime date = DateTime.Now;
            int year = date.Year;
            int month = date.Month;
            int days = DateTime.DaysInMonth(date.Year, date.Month);

            List<gongzi_renyuan> ryList = hm.getBirthday(Session["gongsi"].ToString(), month);

            List<rili> rlList = new List<rili>();

            rili rl = new rili();
            rili rl2 = new rili();
            for (int i = 1; i <= days; i++) {
                DateTime dt = new DateTime(year, month, i);
                if (dt.DayOfWeek.ToString().Equals("Monday")) 
                {
                    rl.zhouyi = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++) 
                    {
                        if(ryList[j].Q.Equals(Convert.ToString(i))){
                            if (rl2.zhouyi == null)
                            {
                                rl2.zhouyi = ryList[j].B;
                            }
                            else 
                            {
                                rl2.zhouyi = rl2.zhouyi + "," + ryList[j].B;
                            }
                            
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Tuesday")) 
                {
                    rl.zhouer = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhouer == null)
                            {
                                rl2.zhouer = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhouer = rl2.zhouer + "," + ryList[j].B;
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Wednesday"))
                {
                    rl.zhousan = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhousan == null)
                            {
                                rl2.zhousan = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhousan = rl2.zhousan + "," + ryList[j].B;
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Thursday"))
                {
                    rl.zhousi = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhousi == null)
                            {
                                rl2.zhousi = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhousi = rl2.zhousi + "," + ryList[j].B;
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Friday"))
                {
                    rl.zhouwu = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (ryList[j].Q.Equals(Convert.ToString(i)))
                            {
                                if (rl2.zhouwu == null)
                                {
                                    rl2.zhouwu = ryList[j].B;
                                }
                                else
                                {
                                    rl2.zhouwu = rl2.zhouwu + "," + ryList[j].B;
                                }
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Saturday"))
                {
                    rl.zhouliu = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhouliu == null)
                            {
                                rl2.zhouliu = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhouliu = rl2.zhouliu + "," + ryList[j].B;
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Sunday"))
                {
                    rl.zhouri = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhouri == null)
                            {
                                rl2.zhouri = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhouri = rl2.zhouri + "," + ryList[j].B;
                            }
                        }
                    }

                    rlList.Add(rl);
                    rlList.Add(rl2);
                    rl = new rili();
                    rl2 = new rili();
                }

                if (i == days && !dt.DayOfWeek.ToString().Equals("Sunday"))
                {
                    rlList.Add(rl);
                }
            }

            this.GridView1.DataSource = rlList;
            this.GridView1.DataBind();
            this.GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

            int rowscount = this.GridView1.Rows.Count;
            int columnscount = this.GridView1.Columns.Count;
            for (int i = 1; i < rowscount; i++)
            {
                for (int j = 0; j < columnscount; j++)
                {
                    if (!GridView1.Rows[i].Cells[j].Text.Equals("&nbsp;") && !GridView1.Rows[i].Cells[j].Text.Equals("")) 
                    {
                        GridView1.Rows[i].Cells[j].BackColor = Color.Yellow;
                    }
                }
                i = i + 1;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string riqi = Request.Form["riqi"];

            if (riqi.Equals("")) 
            {
                Response.Write("<script>alert('请选择年月！');</script>");
                return;
            }
            string nian = riqi.Split('-')[0];
            string yue = riqi.Split('-')[1];

            HrMingXiModel hm = new HrMingXiModel();

            DateTime date = DateTime.Now;
            int year = Convert.ToInt32(nian);
            int month = Convert.ToInt32(yue);
            int days = DateTime.DaysInMonth(year, month);

            List<gongzi_renyuan> ryList = hm.getBirthday(Session["gongsi"].ToString(), month);

            List<rili> rlList = new List<rili>();

            rili rl = new rili();
            rili rl2 = new rili();
            for (int i = 1; i <= days; i++)
            {
                DateTime dt = new DateTime(year, month, i);
                if (dt.DayOfWeek.ToString().Equals("Monday"))
                {
                    rl.zhouyi = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhouyi == null)
                            {
                                rl2.zhouyi = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhouyi = rl2.zhouyi + "," + ryList[j].B;
                            }

                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Tuesday"))
                {
                    rl.zhouer = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhouer == null)
                            {
                                rl2.zhouer = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhouer = rl2.zhouer + "," + ryList[j].B;
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Wednesday"))
                {
                    rl.zhousan = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhousan == null)
                            {
                                rl2.zhousan = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhousan = rl2.zhousan + "," + ryList[j].B;
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Thursday"))
                {
                    rl.zhousi = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhousi == null)
                            {
                                rl2.zhousi = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhousi = rl2.zhousi + "," + ryList[j].B;
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Friday"))
                {
                    rl.zhouwu = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (ryList[j].Q.Equals(Convert.ToString(i)))
                            {
                                if (rl2.zhouwu == null)
                                {
                                    rl2.zhouwu = ryList[j].B;
                                }
                                else
                                {
                                    rl2.zhouwu = rl2.zhouwu + "," + ryList[j].B;
                                }
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Saturday"))
                {
                    rl.zhouliu = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhouliu == null)
                            {
                                rl2.zhouliu = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhouliu = rl2.zhouliu + "," + ryList[j].B;
                            }
                        }
                    }
                }
                else if (dt.DayOfWeek.ToString().Equals("Sunday"))
                {
                    rl.zhouri = Convert.ToString(i);
                    for (int j = 0; j < ryList.Count(); j++)
                    {
                        if (ryList[j].Q.Equals(Convert.ToString(i)))
                        {
                            if (rl2.zhouri == null)
                            {
                                rl2.zhouri = ryList[j].B;
                            }
                            else
                            {
                                rl2.zhouri = rl2.zhouri + "," + ryList[j].B;
                            }
                        }
                    }

                    rlList.Add(rl);
                    rlList.Add(rl2);
                    rl = new rili();
                    rl2 = new rili();
                }

                if (i == days && !dt.DayOfWeek.ToString().Equals("Sunday"))
                {
                    rlList.Add(rl);
                }
            }

            this.GridView1.DataSource = rlList;
            this.GridView1.DataBind();
            this.GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

            int rowscount = this.GridView1.Rows.Count;
            int columnscount = this.GridView1.Columns.Count;
            for (int i = 1; i < rowscount; i++)
            {
                for (int j = 0; j < columnscount; j++)
                {
                    if (!GridView1.Rows[i].Cells[j].Text.Equals("&nbsp;") && !GridView1.Rows[i].Cells[j].Text.Equals("")) 
                    {
                        GridView1.Rows[i].Cells[j].BackColor = Color.Yellow;
                    }
                }
                i = i + 1;
            }
        }



        protected void aaa(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Pager)
            {
                str = (string[])Session["arr3"];
                if (str[2].ToString() == "0")
                {
                    e.Row.Cells[1].Enabled = false;
                }
                if (str[3].ToString() == "0")
                {
                    e.Row.Cells[0].Enabled = false;
                }
            }
        }
    }
}