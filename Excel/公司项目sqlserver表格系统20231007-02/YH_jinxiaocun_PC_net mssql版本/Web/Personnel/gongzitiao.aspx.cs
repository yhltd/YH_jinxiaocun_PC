using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.Personnel
{
    public partial class gongzitiao : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            str = (string[])Session["arr12"];
            if (str[4].ToString() == "0")
            {
                Button1.Enabled = false;
                Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
                Button2.Enabled = false;
                Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("gray");
            }
            if (str[5].ToString() == "0")
            {
                Server.Transfer("../Personnel/wuquanxian.aspx");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Session["sss"] = "SELECT * FROM [gongzi_gongzimingxi] WHERE (([BD] = '" + Session["gongsi"].ToString() + "')";
            //Session["bm1"] = Request.Form["DropDownList1"].ToString();
            //string dd1;
            //string dd2;
            //string dd3;
            //string dd4;
            //if (Request.Form["DropDownList1"].ToString() == "")
            //{
            //    dd1 = "";
            //}else{
            //    dd1 = Request.Form["DropDownList1"].ToString();    
            //}
            //if (Request.Form["DropDownList2"].ToString() == "")
            //{
            //    dd2 = "";
            //}
            //else{
            //    dd2 = Request.Form["DropDownList2"].ToString();
            //}
            //if (Request.Form["DropDownList3"].ToString() == "")
            //{
            //    dd3 = "";
            //}
            //else{
            //    dd3 = Request.Form["DropDownList3"].ToString();
            //}
            //if (Request.Form["DropDownList4"].ToString() == "")
            //{
            //    dd4 = "";
            //}
            //else{
            //    dd4 = Request.Form["DropDownList4"].ToString();
            //}
            //Session["sss"] = Session["sss"].ToString() + ")";
            //string aa = Session["sss"].ToString();
            //Session["bm1"] = Request.Form["DropDownList1"].ToString();
            //Session["zw1"] = Request.Form["DropDownList2"].ToString();
            //Session["Nian"] = Request.Form["DropDownList3"].ToString();
            //Session["Yue"] = Request.Form["DropDownList4"].ToString();

            HrMingXiModel hm = new HrMingXiModel();//

            List<gongzi_gongzimingxi> list = hm.getTiao(Session["gongsi"].ToString(), Request.Form["DropDownList1"].ToString(), Request.Form["DropDownList2"].ToString(), Request.Form["DropDownList3"].ToString(), Request.Form["DropDownList4"].ToString());
            //if (Request.Form["DropDownList4"].ToString()==""){
            //    GridView1.DataSourceID = "SqlDataSource2";
            GridView1.DataSourceID = null;
            GridView1.DataSource = list;
            //}else{
            //    GridView1.DataSourceID = "SqlDataSource3";
            //}
            GridView1.DataBind();
            //if (Request.Form["DropDownList1"].ToString() != "" && Request.Form["DropDownList2"].ToString() != "" ) {
            //    Session["bm1"] = Request.Form["DropDownList1"].ToString();
            //    Session["zw1"] = Request.Form["DropDownList2"].ToString();
            //    GridView1.DataSourceID = "SqlDataSource4";
            //    GridView1.DataBind();
            //}
            //else if (Request.Form["DropDownList1"].ToString() != "" && Request.Form["DropDownList2"].ToString() == "")
            //{
            //    Session["bm1"] = Request.Form["DropDownList1"].ToString();
            //    GridView1.DataSourceID = "SqlDataSource2";
            //    GridView1.DataBind();
            //}else if(Request.Form["DropDownList2"].ToString() != "" ){
            //    Session["zw1"] = Request.Form["DropDownList2"].ToString();
            //    GridView1.DataSourceID = "SqlDataSource3";
            //    GridView1.DataBind();
            //}
        }

        protected void toExcel(object sender, EventArgs e)
        {
            //List<yh_jinxiaocun_mingxi> list = ri_qi_select(string.Empty, string.Empty, user.gongsi);
            HrMingXiModel hm = new HrMingXiModel();
            List<gongzi_gongzimingxi> list = hm.gongzitiao_list(Session["gongsi"].ToString());
            if (list != null)
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("姓名\t部门\t岗位\t身份证号\t入职时间\t基本工资\t绩效工资\t岗位工资\t当月合计工资\t跨度工资\t职称津贴\t月出勤天数\t加班时间\t加班费\t全勤应发\t缺勤天数\t缺勤扣款\t迟到天数\t迟到扣款\t应发工资\t社保基数\t医疗基数\t公积金基数\t年金基数\t企业养老\t企业失业\t企业医疗\t企业工伤\t企业生育\t企业公积金\t企业年金\t滞纳金\t利息\t企业小计\t个人养老\t个人失业\t个人医疗\t个人生育\t个人公积金\t个人年金4%\t滞纳金\t利息\t个人小计\t税前工资\t应税工资\t税率\t扣除数\t代扣个人所得税\t年金1%\t实发工资\t验算公式");

                foreach (gongzi_gongzimingxi gongzitiao in list)
                {

                    sw.WriteLine(gongzitiao.B + "\t" + gongzitiao.C + "\t" + gongzitiao.D + "\t'" + gongzitiao.E + "\t'" + gongzitiao.F + "\t" + gongzitiao.G + "\t" + gongzitiao.H + "\t" + gongzitiao.I + "\t" + gongzitiao.J + "\t" + gongzitiao.K + "\t" + gongzitiao.L + "\t" + gongzitiao.M + "\t" + gongzitiao.N + "\t" + gongzitiao.O + "\t" + gongzitiao.P + "\t" + gongzitiao.Q + "\t" + gongzitiao.R + "\t" + gongzitiao.S + "\t" + gongzitiao.T + "\t" + gongzitiao.U + "\t" + gongzitiao.V + "\t" + gongzitiao.W + "\t" + gongzitiao.X + "\t" + gongzitiao.Y + "\t" + gongzitiao.Z + "\t" + gongzitiao.AA + "\t" + gongzitiao.AB + "\t" + gongzitiao.AC + "\t" + gongzitiao.AD + "\t" + gongzitiao.AE + "\t" + gongzitiao.AF + "\t" + gongzitiao.AG + "\t" + gongzitiao.AH + "\t" + gongzitiao.AI + "\t" + gongzitiao.AJ + "\t" + gongzitiao.AK + "\t" + gongzitiao.AL + "\t" + gongzitiao.AM + "\t" + gongzitiao.AN + "\t" + gongzitiao.AO + "\t" + gongzitiao.AP + "\t" + gongzitiao.AQ + "\t" + gongzitiao.AR + "\t" + gongzitiao.ASA + "\t" + gongzitiao.ATA + "\t" + gongzitiao.AU + "\t" + gongzitiao.AV + "\t" + gongzitiao.AW + "\t" + gongzitiao.AX + "\t" + gongzitiao.AY + "\t" + gongzitiao.AZ);

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=工资条.xls");

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

        public void print(object sender, EventArgs e) 
        {
            List<gongzi_gongzimingxi>list=new List<gongzi_gongzimingxi>();
            for (var i = 0; i < GridView1.Rows.Count; i++) 
            {
                gongzi_gongzimingxi item=new gongzi_gongzimingxi();
                item.B = GridView1.Rows[i].Cells[1].Text.Trim();
                item.C = GridView1.Rows[i].Cells[2].Text.Trim();
                item.D = GridView1.Rows[i].Cells[3].Text.Trim();
                item.G = GridView1.Rows[i].Cells[6].Text.Trim();
                item.AJ = GridView1.Rows[i].Cells[35].Text.Trim();
                item.AK = GridView1.Rows[i].Cells[36].Text.Trim();
                item.AL = GridView1.Rows[i].Cells[37].Text.Trim();
                item.AM = GridView1.Rows[i].Cells[38].Text.Trim();
                item.AN = GridView1.Rows[i].Cells[39].Text.Trim();
                item.ASA = GridView1.Rows[i].Cells[44].Text.Trim();
                item.AW = GridView1.Rows[i].Cells[49].Text.Trim();
                item.AY = GridView1.Rows[i].Cells[50].Text.Trim();

                if (item.B == "&nbsp;") { item.B = ""; }
                if (item.C == "&nbsp;") { item.C = ""; }
                if (item.D == "&nbsp;") { item.D = ""; }
                if (item.G == "&nbsp;") { item.G = ""; }
                if (item.AJ == "&nbsp;") { item.AJ = ""; }
                if (item.AK == "&nbsp;") { item.AK = ""; }
                if (item.AL == "&nbsp;") { item.AL = ""; }
                if (item.AM == "&nbsp;") { item.AM = ""; }
                if (item.AN == "&nbsp;") { item.AN = ""; }
                if (item.ASA == "&nbsp;") { item.ASA = ""; }
                if (item.AW == "&nbsp;") { item.AW = ""; }
                if (item.AY == "&nbsp;") { item.AY = ""; }

                list.Add(item);
            }
            Session["printList"] = list;

            Response.Redirect("../RDLC/gongzitiao_print.aspx");
            
        }
    }
}