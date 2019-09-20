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
    public partial class yl_set_page : System.Web.UI.Page
    {
        private int row_count;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");
           
            if (Convert.ToInt32(Session["dq_ye_yl"]) == 0)
            {
                Session["dq_ye_zl"] = 0;
            }
        }
        protected void yl_set_select_load(object sender, EventArgs e)
        {
            List<yong_liao_set_info> list = yl_set_select(Session["username"].ToString(), Session["gs_name"].ToString());
            Session["yl_set_select"] = list;

        }
        public List<yong_liao_set_info> yl_set_select(string zh_name, string gs_name)
        {

            List<yong_liao_set_info> list = new List<yong_liao_set_info>();
            clsAllnew buiness = new clsBuiness.clsAllnew();
            list = buiness.yl_set_select(zh_name, gs_name);

            return list;
        }


        protected void del_yong_liao(object sender, EventArgs e)
        {
            List<yong_liao_set_info> list = yl_set_select(Session["username"].ToString(), Session["gs_name"].ToString());

            row_count = list.Count;
            for (int i = 0; i < row_count; i++)
            {
                string name = Request["Checkbox_bd" + i];

                if (name == null)
                {

                }
                else
                {
                    if (Convert.ToInt32(name) == i)
                    {
                        del_yl_ff(list[i].id);
                        Response.Write(" <script>alert('删除成功'); location='yl_set_page.aspx';</script>");
                    }
                }
            }
        }

        public int del_yl_ff(string id)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int isrun = buiness.del_yl_ff(id);
            return isrun;

        }


        protected void yl_tj(object sender, EventArgs e)
        {
            if (Context.Request["tj_pd"].ToString() == "tj_true")
            {
                yong_liao_set_info ylsi = new yong_liao_set_info();
                List<yong_liao_set_info> list = yl_set_select(Session["username"].ToString(), Session["gs_name"].ToString());
                row_count = list.Count;
                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    List<yong_liao_set_info> list_yl = new List<yong_liao_set_info>();
                    ylsi.cp_name = Context.Request["cp_name" + i].ToString();
                    ylsi.yl_dm = Context.Request["yl_dm" + i].ToString();
                    ylsi.yl_name = Context.Request["yl_name" + i].ToString();
                    ylsi.yl_sl = Context.Request["yl_sl" + i].ToString();
                    ylsi.yl_tx = Context.Request["yl_tx" + i].ToString();
                    ylsi.zh_name = Session["username"].ToString();
                    ylsi.gs_name = Session["gs_name"].ToString();
                    list_yl.Add(ylsi);
                    add_yl(list_yl);
                }
                for (int i = 0; i < row_count; i++)
                {
                    update_yl(Context.Request["cp_name_cs" + i].ToString(), Context.Request["yl_dm_cs" + i].ToString(), Context.Request["yl_name_cs" + i].ToString(), Context.Request["yl_sl_cs" + i].ToString(), Context.Request["id_cs" + i].ToString(), Context.Request["yl_tx_cs" + i].ToString());
                }
                Response.Write(" <script>alert('提交成功'); location='yl_set_page.aspx';</script>");
            }
        }

        public int update_yl(string cp_name, string yl_dm, string yl_name, string yl_sl, string id, string yl_tx)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int isrun = buiness.update_yl(cp_name, yl_dm, yl_name, yl_sl, id, yl_tx);
            return isrun;

        }

        public void add_yl(List<yong_liao_set_info> list)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            buiness.add_yl(list);

        }


        protected void shou_ye_Click(object sender, EventArgs e)
        {
            Session["dq_ye_yl"] = 0;
            List<yong_liao_set_info> list = fen_ye(0, 1);
            Session["yl_set_select"] = list;
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye_yl"]);
            List<yong_liao_set_info> list = fen_ye(dang_qian-1, 1);
            Session["dq_ye_yl"] = dang_qian - 1;
            Session["yl_set_select"] = list;

        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye_yl"]);
            List<yong_liao_set_info> list = fen_ye(dang_qian + 1, 1);
            Session["dq_ye_yl"] = dang_qian + 1;
            Session["yl_set_select"] = list;


        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            List<yong_liao_set_info> list1 = yl_set_select(Session["username"].ToString(), Session["gs_name"].ToString());
            row_count = list1.Count;
            Session["dq_ye_yl"] = row_count - 1;
            List<yong_liao_set_info> list = fen_ye(row_count - 1, 1);
            Session["yl_set_select"] = list;
        }

        public List<yong_liao_set_info> fen_ye(int y_c, int e_c)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<yong_liao_set_info> list = buiness.yl_fenye(y_c, e_c, Session["username"].ToString(), Session["gs_name"].ToString());
            return list;
        }

    }
}