using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using clsBuiness;
using SDZdb;
using Web.Server;
namespace Web.Myadmin.HouTai
{
    public partial class YongHuGuanli : System.Web.UI.Page
    {
        protected List<yh_jinxiaocun_user> YongHutable;
        private static yh_jinxiaocun_user user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user.AdminIS.Equals("false"))
            {
                Response.Redirect("~/wqx.aspx");
            }
            if (user == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            
            if (!IsPostBack)
            {
                string act = Request["act"] == null ? "" : Request["act"].ToString();
                if (act.Equals("PostUser"))
                {
                    string id = Request["id"] == null ? "0" : Request["id"].ToString();
                    Response.Write(delete(id));
                    Response.End();
                }
                this.SelectUser();
            }
        }
        //protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        //{
            //string[] a = new string[10];
            //for (int i = 2; i <= 41; i++)
            //{
                //a[i - 2] = GridView1.Rows[GridView1.SelectedIndex].Cells[i + 1].Text;
            //}
            //a[1] = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString();

            //Session["b"] = a[39];
            //Session["year"] = a[0];
            //Session["moth"] = a[1];
            //Session["name"] = a[2];
            //Server.Transfer("../Personnel/kaoqinUpd.aspx");
        //}
        public int delete(string id)
        {
            string msg = string.Empty;
            UserModel s = new UserModel();
            int result = 0;
            try
            {
                result = s.delete(id);
            }
            catch
            {
                result = -1;
            }
            return result;
        }

        private void SelectUser()
        {
            UserModel s = new UserModel();
            UserFor.DataSource = s.getList(user.gongsi);
            UserFor.DataBind();
        }
        protected void BTN_UP_Click(object sender, EventArgs e)
        {
            Server.Transfer("../InsertUser.aspx");
        }
        protected void BTN_ShuaXing_Click(object sender, EventArgs e)
        {
            try
            {
                SelectUser();
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }
    }
}