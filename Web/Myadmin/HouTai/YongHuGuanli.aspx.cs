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