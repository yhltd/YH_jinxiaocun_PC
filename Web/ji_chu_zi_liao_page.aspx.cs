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
    public partial class ji_chu_zi_liao_page : System.Web.UI.Page
    {
        private int row_count;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null && Session["gs_name"] == null)
            {
                Response.Write("<script>alert('请登录！');location='/Myadmin/Login.aspx';</script>");
            }
            else 
            {
                this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");

                if (Convert.ToInt32(Session["dq_ye_jczl"]) == 0)
                {
                    Session["dq_ye_jczl"] = 0;
                }

            }
        }
        protected void jczl_select_load(object sender, EventArgs e)
        {
            
                List<zl_and_jc_info> list = jczl_select(Session["username"].ToString(), Session["gs_name"].ToString());
                Session["jczj_select"] = list;
            
            
        }

        public List<zl_and_jc_info> jczl_select(string zh_name, string gs_name)
        {

            List<zl_and_jc_info> list = new List<zl_and_jc_info>();
            clsAllnew buiness = new clsBuiness.clsAllnew();
            list = buiness.jczl_select(zh_name, gs_name);

            return list;
        }

        protected void del_qichu(object sender, EventArgs e)
        {
            List<zl_and_jc_info> list = jczl_select(Session["username"].ToString(), Session["gs_name"].ToString());
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
                        del_jczl_ff(list[i].id);
                        jczl_select_load(sender,e);
                        Response.Write(" <script>alert('删除成功'); location='ji_chu_zi_liao_page.aspx';</script>");
                    }
                }
            }
        }

        public int del_jczl_ff(string id)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int isrun = buiness.del_jczl_ff(id);
            return isrun;

        }


        public void add_jczl(List<zl_and_jc_info> list)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            buiness.add_jczl(list);

        }



        protected void jczl_tj(object sender, EventArgs e)
        {
          
            if (Context.Request["tj_pd"].ToString() == "tj_true")
            {
                List<zl_and_jc_info> list = jczl_select(Session["username"].ToString(), Session["gs_name"].ToString());
                row_count = list.Count;
                zl_and_jc_info zaji = new zl_and_jc_info();
                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    List<zl_and_jc_info> list_jczl = new List<zl_and_jc_info>();
                    zaji.sp_dm = Context.Request["sp_dm" + i].ToString();
                    zaji.name = Context.Request["name" + i].ToString();
                    zaji.lei_bie = Context.Request["lei_bie" + i].ToString();
                    zaji.dan_wei = Context.Request["dan_wei" + i].ToString();
                    zaji.shou_huo = Context.Request["shou_huo" + i].ToString();
                    zaji.Gong_huo = Context.Request["Gong_huo" + i].ToString();
                    zaji.zh_name = Session["username"].ToString();
                    zaji.gs_name = Session["gs_name"].ToString();
                    list_jczl.Add(zaji);
                    add_jczl(list_jczl);
                }

                for (int i = 0; i < row_count; i++)
                {
                    update_jczl(Context.Request["sp_dm_cs" + i].ToString(), Context.Request["name_cs" + i].ToString(), Context.Request["lei_bie_cs" + i].ToString(), Context.Request["dan_wei_cs" + i].ToString(), Context.Request["shou_huo_cs" + i].ToString(), Context.Request["gong_huo_cs" + i].ToString(), Context.Request["id_cs" + i].ToString());

                }
                jczl_select_load(sender, e);
                Response.Write(" <script>alert('提交成功'); location='ji_chu_zi_liao_page.aspx';</script>");

            }
        }

        public int update_jczl(string sp_dm, string name, string lei_bie, string dan_wei, string shou_huo, string gong_huo, string id)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int isrun = buiness.update_jczl(sp_dm, name, lei_bie, dan_wei, shou_huo, gong_huo, id);
            return isrun;

        }



        protected void shou_ye_Click(object sender, EventArgs e)
        {
            Session["dq_ye_jczl"] = 0;
            List<zl_and_jc_info> list = fen_ye(0, 1);
            Session["jczj_select"] = list;
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye_jczl"]);
            List<zl_and_jc_info> list = fen_ye(dang_qian - 1, 1);
            Session["dq_ye_jczl"] = dang_qian - 1;
            Session["jczj_select"] = list;

        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye_jczl"]);
            List<zl_and_jc_info> list = fen_ye(dang_qian + 1, 1);
            Session["dq_ye_jczl"] = dang_qian + 1;
            Session["jczj_select"] = list;


        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            List<zl_and_jc_info> list1 = jczl_select(Session["username"].ToString(), Session["gs_name"].ToString());
            row_count = list1.Count;
            Session["dq_ye_jczl"] = row_count - 1;
            List<zl_and_jc_info> list = fen_ye(row_count - 1, 1);
            Session["jczj_select"] = list;
        }

        public List<zl_and_jc_info> fen_ye(int y_c, int e_c)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<zl_and_jc_info> list = buiness.jczl_fenye(y_c, e_c, Session["username"].ToString(), Session["gs_name"].ToString());
            return list;
        }

    }
}