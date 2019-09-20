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
    public partial class ming_xi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Convert.ToInt32( Session["dq_ye_mx_dd"]) == 0){
                Session["dq_ye_mx_dd"] = 0;
            }
            
        }

        protected void bt_select_Click(object sender, EventArgs e)
        {
            List<ming_xi_info> list = ming_xi_select(Session["username"].ToString(), Session["gs_name"].ToString());
            Session["ming_xi_select_dd"] = list;
           

        }

        public List<ming_xi_info> ming_xi_select(string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.ming_xi_select(zh_name, gs_name);
            return list;
        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {
            Session["dq_ye_mx_dd"] = 0;
            List<ming_xi_info> list = fen_ye(0, 1);
            Session["ming_xi_select_dd"] = list;
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye_mx_dd"]);
            List<ming_xi_info> list = fen_ye(dang_qian-1, 1);
            Session["dq_ye_mx_dd"] = dang_qian - 1;
            Session["ming_xi_select_dd"] = list;

        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye_mx_dd"]);
            List<ming_xi_info> list = fen_ye(dang_qian + 1, 1);
            Session["dq_ye_mx_dd"] = dang_qian + 1;
            Session["ming_xi_select_dd"] = list;


        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            Session["dq_ye_mx_dd"] = select_row().Count - 1;
            List<ming_xi_info> list = fen_ye(select_row().Count - 1, 1);
            Session["ming_xi_select_dd"] = list;
        }

        public List<ming_xi_info> fen_ye(int y_c, int e_c)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.ru_ku_fenye(y_c, e_c, Session["username"].ToString(), Session["gs_name"].ToString());
            return list;
        }

        public List<ming_xi_info> select_row()
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.ru_ku_select_row();
            return list;
        }

        protected void rq_select(object sender, EventArgs e)
        {
            List<ming_xi_info> list = ri_qi_select(Context.Request["time_qs"].ToString(), Context.Request["time_jz"].ToString(), Session["username"].ToString(), Session["gs_name"].ToString());
            Session["ming_xi_select_dd"] = list;
        }

        public List<ming_xi_info> ri_qi_select(string time_qs, string time_jz, string zh_name, string gs_name) 
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.ri_qi_select(time_qs, time_jz, zh_name, gs_name);
            return list;
        }
    }
}