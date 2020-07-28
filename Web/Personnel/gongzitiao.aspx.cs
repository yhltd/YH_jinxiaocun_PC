using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class gongzitiao : System.Web.UI.Page
    {
        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["DropDownList1"].ToString() != "" && Request.Form["DropDownList2"].ToString() != "" ) {
                Session["bm1"] = Request.Form["DropDownList1"].ToString();
                Session["zw1"] = Request.Form["DropDownList2"].ToString();
                GridView1.DataSourceID = "SqlDataSource4";
                GridView1.DataBind();
            }
            else if (Request.Form["DropDownList1"].ToString() != "" && Request.Form["DropDownList2"].ToString() == "")
            {
                Session["bm1"] = Request.Form["DropDownList1"].ToString();
                GridView1.DataSourceID = "SqlDataSource2";
                GridView1.DataBind();
            }else if(Request.Form["DropDownList2"].ToString() != "" ){
                Session["zw1"] = Request.Form["DropDownList2"].ToString();
                GridView1.DataSourceID = "SqlDataSource3";
                GridView1.DataBind();
            }
        }
    }
}