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
    public partial class sp_rc_ku_select : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void rc_ku_select_load(object sender, EventArgs e)
        {
            
            try
            {
                if (Session["username"] == null && Session["gs_name"] == null)
                {
                    Response.Write("<script>alert('请登录！');location='/Myadmin/Login.aspx';</script>");
                }
                else
                {
                    List<rc_ku_info> list = rc_ku_xl_select(Session["username"].ToString(), Session["gs_name"].ToString());
                    Session["rc_ku_xl_select"] = list;
                }
            }
            catch (Exception ex) { throw; }
            
           
        }
        protected void rc_ku_select_Click(object sender, EventArgs e)
        {
            
            try
            {
                //int shou_jia_r = 0;
                //int shu_liang_r = 0;
                //int jin_e_r = 0;
                //int shou_jia_c = 0;
                //int shu_liang_c = 0;
                //int jin_e_c = 0;
                List<rc_ku_info> list = rc_ku_r_select(Context.Request["kui_lei"].ToString(), Session["username"].ToString(), Session["gs_name"].ToString());
                List<rc_ku_info> lista = rc_ku_select(Context.Request["kui_lei"].ToString(), Session["username"].ToString(), Session["gs_name"].ToString());
                Session["selectSp"] = lista;
                Session["rc_ku_r_select"] = list;
            }
            catch (Exception ex) { throw; }
            
        }


        public List<rc_ku_info> rc_ku_r_select(string name, string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<rc_ku_info> list = buiness.rc_ku_r_select(name, zh_name, gs_name);
            return list;
        }
        public List<rc_ku_info> rc_ku_select(string name, string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<rc_ku_info> list = buiness.rc_ku_select(name, zh_name, gs_name);
            return list;
        }
        public List<rc_ku_info> rc_ku_c_select(string name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<rc_ku_info> list = buiness.rc_ku_c_select(name);
            return list;
        }

        public List<rc_ku_info> rc_ku_xl_select(string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<rc_ku_info> list = buiness.rc_ku_xl_select(zh_name, gs_name);
            return list;
        }
    }
}