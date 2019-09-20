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
            List<rc_ku_info> list = rc_ku_xl_select(Session["username"].ToString(), Session["gs_name"].ToString());
            Session["rc_ku_xl_select"] = list;
           
        }
        protected void rc_ku_select_Click(object sender, EventArgs e)
        {
            int shou_jia_r = 0;
            int shu_liang_r = 0;
            int jin_e_r = 0;
            int shou_jia_c = 0;
            int shu_liang_c = 0;
            int jin_e_c = 0;
            List<rc_ku_info> list = rc_ku_r_select(Context.Request["kui_lei"].ToString(), Session["username"].ToString(), Session["gs_name"].ToString());
            for (int i = 0; i < list.Count; i++)
            {
                shou_jia_r +=Convert.ToInt32( list[i].Shou_jia);
                shu_liang_r += Convert.ToInt32(list[i].Shu_liang);
                jin_e_r += shou_jia_r * shu_liang_r;
            }
            Session["rc_ku_r_select"] = list;
            List<rc_ku_info> list_c = rc_ku_c_select(Context.Request["kui_lei"].ToString());
            for (int i = 0; i < list_c.Count; i++)
            {
                shou_jia_c += Convert.ToInt32(list_c[i].Shou_jia);
                shu_liang_c += Convert.ToInt32(list_c[i].Shu_liang);
                jin_e_c += shou_jia_c * shu_liang_c;
            }
            Session["rc_ku_c_select"] = list_c;
            Session["shou_jia_r"] = shou_jia_r;
            Session["shu_liang_r"] = shu_liang_r;
            Session["jin_e_r"] = jin_e_r;
            Session["shou_jia_c"] = shou_jia_c;
            Session["shu_liang_c"] = shu_liang_c;
            Session["jin_e_c"] = jin_e_c;
            Session["rc_jc"] = shu_liang_r - shu_liang_c;
        }


        public List<rc_ku_info> rc_ku_r_select(string name, string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<rc_ku_info> list = buiness.rc_ku_r_select(name, zh_name, gs_name);
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