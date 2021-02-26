using System;
using System.Collections.Generic;
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
    }
}