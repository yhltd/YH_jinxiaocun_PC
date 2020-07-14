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
    public partial class zheng_li_page : System.Web.UI.Page
    {

        private int row_count;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");
          
            if (Convert.ToInt32(Session["dq_ye_zl"]) == 0)
            {
                Session["dq_ye_zl"] = 0;
            }
        }
        protected void zl_select_load(object sender, EventArgs e)
        {
            List<zl_and_jc_info> list = zl_select(Session["username"].ToString(), Session["gs_name"].ToString());
            Session["zl_and_jc_select"] = list;
            
        }

        public List<zl_and_jc_info> zl_select(string zh_name, string gs_name)
        {

            List<zl_and_jc_info> list = new List<zl_and_jc_info>();
            clsAllnew buiness = new clsBuiness.clsAllnew();
            list = buiness.zl_select(zh_name, gs_name);

            return list;
        }




        protected void del_qichu(object sender, EventArgs e)
        {
            List<zl_and_jc_info> list = zl_select(Session["username"].ToString(), Session["gs_name"].ToString());
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
                        del_zl_ff(list[i].id);
                        Response.Write(" <script>alert('删除成功'); location='zheng_li_page.aspx';</script>");
                    }
                }
            }
        }

        public int del_zl_ff(string id)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int isrun = buiness.del_zl_ff(id);
            return isrun;

        }


        protected void zl_tj(object sender, EventArgs e)
        {
            if (Context.Request["tj_pd"].ToString() == "tj_true")
            {
                zl_and_jc_info zaji = new zl_and_jc_info();
                List<zl_and_jc_info> list = zl_select(Session["username"].ToString(), Session["gs_name"].ToString());
                row_count = list.Count;
                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    List<zl_and_jc_info> list_zl = new List<zl_and_jc_info>();
                    zaji.sp_dm = Context.Request["sp_dm" + i].ToString();
                    zaji.name = Context.Request["name" + i].ToString();
                    zaji.lei_bie = Context.Request["lei_bie" + i].ToString();
                    zaji.dan_wei = Context.Request["dan_wei" + i].ToString();
                    zaji.zh_name = Session["username"].ToString();
                    zaji.gs_name = Session["gs_name"].ToString();
                    list_zl.Add(zaji);
                    add_zl(list_zl);
                }

                for (int i = 0; i < row_count; i++)
                {
                    update_zl(Context.Request["sp_dm_cs" + i].ToString(), Context.Request["name_cs" + i].ToString(), Context.Request["lei_bie_cs" + i].ToString(), Context.Request["dan_wei_cs" + i].ToString(), Context.Request["id_cs" + i].ToString());

                }
                Response.Write(" <script>alert('提交成功'); location='zheng_li_page.aspx';</script>");

            }
        }

        public int update_zl(string sp_dm, string name, string lei_bie, string dan_wei, string id)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int isrun = buiness.update_zl(sp_dm, name, lei_bie, dan_wei, id);
            return isrun;

        }

        public void add_zl(List<zl_and_jc_info> list)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            buiness.add_zl(list);

        }



        protected void shou_ye_Click(object sender, EventArgs e)
        {
            Session["dq_ye_zl"] = 0;
            List<zl_and_jc_info> list = fen_ye(0, 1);
            Session["zl_and_jc_select"] = list;
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            if (Session["dq_ye_zl"] == null)
            {
                Response.Write(" <script>alert('已经是第一页！')</script>");
            }
            else
            {
                int dang_qian = Convert.ToInt32(Session["dq_ye_zl"]);
                List<zl_and_jc_info> list = fen_ye(dang_qian - 1, 1);
                Session["dq_ye_zl"] = dang_qian - 1;
                Session["zl_and_jc_select"] = list;
            }
        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye_zl"]);
            List<zl_and_jc_info> list = fen_ye(dang_qian + 1, 1);
            Session["dq_ye_zl"] = dang_qian + 1;
            Session["zl_and_jc_select"] = list;


        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            List<zl_and_jc_info> list1 = zl_select(Session["username"].ToString(), Session["gs_name"].ToString());
            row_count = list1.Count;
            Session["dq_ye_zl"] = row_count - 1;
            List<zl_and_jc_info> list = fen_ye(row_count - 1, 1);
            Session["zl_and_jc_select"] = list;
        }

        public List<zl_and_jc_info> fen_ye(int y_c, int e_c)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<zl_and_jc_info> list = buiness.zl_fenye(y_c, e_c, Session["username"].ToString(), Session["gs_name"].ToString());
            return list;
        }

    }
}