using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class kaoqin : System.Web.UI.Page
    {

        string[] str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"].ToString() == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");

            }
            str = (string[])Session["arr1"];
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
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Session["year"] = Request.Form["DropDownList1"];
                Session["moth"] = Request.Form["DropDownList2"];
                Server.Transfer("../Personnel/kaoqinAdd.aspx", true);
            }
            catch (Exception ex) {
                Response.Write("<script>window.location.href = '../Personnel/kaoqinAdd.aspx'</script>");
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }
        protected void aaa(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Pager)
            {
                str = (string[])Session["arr1"];
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

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string[] a = new string[40];
            for(int i=2;i<=41;i++){
             a[i-2] = GridView1.Rows[GridView1.SelectedIndex].Cells[i+1].Text;
            }
            a[39] = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string result = js.Serialize(a); //upUser(" + result + ");iframe_d_open
           ClientScript.RegisterStartupScript(this.GetType(), "", "<script>upUser(" + result + ");</script>");
    
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Personnel/kaoqin.aspx");
        }
    }
}