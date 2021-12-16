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
using Web.Server;

namespace Web
{
    public partial class zheng_li_page : System.Web.UI.Page
    {

        private int row_count;
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
            else {
                try
                {
                    this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");

                    if (Convert.ToInt32(Session["dq_ye_zl"]) == 0)
                    {
                        Session["dq_ye_zl"] = 0;
                    }

                    this.zl_select_load(sender, e);
                }
                catch
                {
                    Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
                }
            }
        }

        protected void zl_select_load(object sender, EventArgs e)
        {
            try
            {
                Session["zl_and_jc_select"] = zl_select(user.gongsi);
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }

        protected void chaxun(object sender, EventArgs e)
        {
            try
            {
                string name = Request.Form["zl_cx"];
                Session["zl_and_jc_select"] = zl_chaxun(user.gongsi, name);
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }

        }

        public List<yh_jinxiaocun_zhengli> zl_chaxun(string gs_name, string name)
        {
            ZhengLiModel zhengli = new ZhengLiModel();
            return zhengli.getList_chaxun(gs_name,name);
        }

        public List<yh_jinxiaocun_zhengli> zl_select(string gs_name)
        {
            ZhengLiModel zhengli = new ZhengLiModel();
            return zhengli.getList(gs_name);
        }

        protected void del_qichu(object sender, EventArgs e)
        {
            List<yh_jinxiaocun_zhengli> list = zl_select(user.gongsi);
            row_count = list.Count;
            ZhengLiModel zhengli = new ZhengLiModel();
            for (int i = 0; i < row_count; i++)
            {
                string name = Request["Checkbox_bd" + i];
                if (name != null)
                {
                    if (Convert.ToInt32(name) == i)
                    {
                        zhengli.delete(list[i].id);
                    }
                }
            }
            Response.Write("<script>alert('删除成功');</script>");
            this.zl_select_load(sender, e);
        }


        protected void zl_tj(object sender, EventArgs e)
        {
            if (Context.Request["tj_pd"].ToString() == "tj_true")
            {
                ZhengLiModel zhengli = new ZhengLiModel();
                List<yh_jinxiaocun_zhengli> list = zl_select(user.gongsi);
                row_count = list.Count;

                List<yh_jinxiaocun_zhengli> list_zl = new List<yh_jinxiaocun_zhengli>();
                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    yh_jinxiaocun_zhengli zaji = new yh_jinxiaocun_zhengli();
                    zaji.sp_dm = Context.Request["sp_dm" + i].ToString();
                    zaji.name = Context.Request["name" + i].ToString();
                    zaji.lei_bie = Context.Request["lei_bie" + i].ToString();
                    zaji.dan_wei = Context.Request["dan_wei" + i].ToString();
                    zaji.zh_name = user.name;
                    zaji.gs_name = user.gongsi;
                    list_zl.Add(zaji);
                }
                if (list_zl.Count > 0)
                {
                    zhengli.add(list_zl);
                }
                

                for (int i = 0; i < row_count; i++)
                {
                    zhengli.update(Context.Request["sp_dm_cs" + i].ToString(), Context.Request["name_cs" + i].ToString(), Context.Request["lei_bie_cs" + i].ToString(), Context.Request["dan_wei_cs" + i].ToString(), Context.Request["id_cs" + i].ToString());
                }
                Response.Write(" <script>alert('提交成功');</script>");
                this.zl_select_load(sender, e);
            }
        }
    }
}