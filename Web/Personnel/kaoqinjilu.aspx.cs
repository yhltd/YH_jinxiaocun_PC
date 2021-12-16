using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class kaoqinjilu : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            DropDownList1.Items.FindByText(DateTime.Now.Year.ToString()).Selected = true;
            str = (string[])Session["arr7"];
            if (str[1].ToString() == "0")
            {
                Button2.Enabled = false;
                Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[4].ToString() == "0")
            {
                Button1.Enabled = false;
                Button3.Enabled = false;
                Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[5].ToString() == "0")
            {
                Server.Transfer("../Personnel/wuquanxian.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["year"] = Request.Form["DropDownList1"];
            Session["moth"] = Request.Form["DropDownList2"];
            GridView1.DataSourceID = "SqlDataSource2";
            DropDownList1.ClearSelection();
            DropDownList1.Items.FindByText(DateTime.Now.Year.ToString()).Selected = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["year"] = Request.Form["DropDownList1"];
            Session["moth"] = Request.Form["DropDownList2"];
            Server.Transfer("../Personnel/kaoqinjiluAdd.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
            DropDownList1.ClearSelection();
            DropDownList1.Items.FindByText(DateTime.Now.Year.ToString()).Selected = true;
        }
        protected void aaa(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Pager)
            {
                str = (string[])Session["arr7"];
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

        protected void toExcel(object sender, EventArgs e)
        {
            HrMingXiModel hm = new HrMingXiModel();
            List<gongzi_kaoqinmingxi> list = hm.kaoqin_mingxi_list(Session["gongsi"].ToString());
            if (list != null)
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("姓名\t年\t月\t应到\t实到\t请假\t加班\t迟到\t部门");

                foreach (gongzi_kaoqinmingxi kaoqin in list)
                {

                    sw.WriteLine(kaoqin.name + "\t" + kaoqin.C + "\t" + kaoqin.D + "\t" + kaoqin.E + "\t" + kaoqin.F + "\t" + kaoqin.G + "\t" + kaoqin.H + "\t" + kaoqin.I + "\t" + kaoqin.J );

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=考勤记录.xls");

                Response.ContentType = "application/ms-excel";

                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

                Response.Write(sw);

                Response.End();
            }
            else
            {
                Response.Write(" <script>alert('保存失败'); location='ming_xi.aspx';</script>");
            }

        }
    }
}