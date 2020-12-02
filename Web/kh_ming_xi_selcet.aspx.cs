using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SDZdb;
using System.ComponentModel;
using System.Configuration;
using Order.Common;
using clsBuiness;
using System.Reflection;

namespace Web
{
    public partial class kh_ming_xi_selcet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["gs_name"] == null)
            {
                Response.Write("<script>alert('请登录！');window.parent.location.href='../Myadmin/Login.aspx';</script>");
            }else{
                this.shuaxin();
            }
        }

        private void shuaxin(){
            clsAllnew buiness = new clsAllnew();
            string username = Session["username"].ToString();
            string gsname = Session["gs_name"].ToString();
            List<string> list = buiness.kh_mx_xl_select(username, gsname);
            Session["kh_mx_xl_select"] = list;
            Session["rk_mx_select"] = null;
        }

        protected void kh_mx_select_load(object sender, EventArgs e)
        {
            this.shuaxin();
        }
       

        protected void kh_mx_select_Click(object sender, EventArgs e)
        {
            string gong_huo = Context.Request["gonghuo"];
            string username = Session["username"].ToString();
            string gsname = Session["gs_name"].ToString();
            List<rc_ku_info_select> list = rc_ku_kh_select(gong_huo, username, gsname);
            Session["rk_mx_select"] = list;
        }



        public List<rc_ku_info_select> rc_ku_kh_select(string gong_huo, string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsAllnew();
            List<rc_ku_info_select> list = buiness.rc_ku_r_select(gong_huo, zh_name, gs_name);
            return list;
        }

        public List<string> kh_mx_xl_select(string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<string> list = buiness.kh_mx_xl_select(zh_name, gs_name);
            return list;
        }
    }
}