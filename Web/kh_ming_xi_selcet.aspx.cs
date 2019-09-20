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
           
        }

        protected void kh_mx_select_load(object sender, EventArgs e)
        {
            List<rc_ku_info> list = kh_mx_xl_select(Session["username"].ToString(), Session["gs_name"].ToString());
            Session["kh_mx_xl_select"] = list;

        }
        public List<rc_ku_info> kh_mx_xl_select(string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<rc_ku_info> list = buiness.kh_mx_xl_select(zh_name, gs_name);
            return list;
        }


        protected void kh_mx_select_Click(object sender, EventArgs e)
        {
            int shou_jia_r = 0;
            int shu_liang_r = 0;
            int jin_e_r = 0;
            List<rc_ku_info> list = rc_ku_kh_select(Context.Request["kui_lei"].ToString(), Session["username"].ToString(), Session["gs_name"].ToString());
            for (int i = 0; i < list.Count; i++)
            {
                shou_jia_r += Convert.ToInt32(list[i].Shou_jia);
                shu_liang_r += Convert.ToInt32(list[i].Shu_liang);
                jin_e_r += shou_jia_r * shu_liang_r;
            }
            Session["rk_mx_select"] = list;
          


            Session["shou_jia_r"] = shou_jia_r;
            Session["shu_liang_r"] = shu_liang_r;
            Session["jin_e_r"] = jin_e_r;
           
        }



        public List<rc_ku_info> rc_ku_kh_select(string gong_huo, string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<rc_ku_info> list = buiness.rc_ku_kh_select(gong_huo, zh_name, gs_name);
            return list;
        }
    }
}