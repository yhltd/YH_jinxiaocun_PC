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
using System.Security.Cryptography;
using System.Text;

namespace Web
{
    public partial class ji_chu_zi_liao_page : System.Web.UI.Page
    {
        private int row_count;
        private static yh_jinxiaocun_user user;
        int now_lisetcount;

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
            else 
            {
                this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");
                if (!Page.IsPostBack)
                    jczl_select_load(sender, e);
            }
        }
        protected void jczl_select_load(object sender, EventArgs e)
        {
            try
            {
                JinChuModel jinchu = new JinChuModel();
                Session["jczj_select"] = jinchu.getList(user.gongsi);

                List<yh_jinxiaocun_jichuziliao> list = Session["jczj_select"] as List<yh_jinxiaocun_jichuziliao>;
                now_lisetcount = list.Count();
                Session["now_lisetcount_1"] = now_lisetcount;
            }
            catch
            {
                //Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }
        protected void jczl_chaxun(object sender, EventArgs e)
        {
            try
            {
                string name = Request.Form["jichu_cx"];
                JinChuModel jinchu = new JinChuModel();
                Session["jczj_select"] = jinchu.getList_chaxun(user.gongsi, name);
                // 保存 查询条数到Session  方便之后保存提交 调用此数据
                List<yh_jinxiaocun_jichuziliao> list = Session["jczj_select"] as List<yh_jinxiaocun_jichuziliao>;
                now_lisetcount = list.Count();
                Session["now_lisetcount_1"] = now_lisetcount;

            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }

        protected void del_qichu(object sender, EventArgs e)
        {
            JinChuModel jinchu = new JinChuModel();
            List<yh_jinxiaocun_jichuziliao> list = jinchu.getList(user.gongsi);
            row_count = list.Count;
            for (int i = 0; i < row_count; i++)
            {
                string name = Request["Checkbox_bd" + i];

                if (name != null)
                {
                    if (Convert.ToInt32(name) == i)
                    {
                        del_jczl_ff(list[i].id);
                        jczl_select_load(sender, e);
                        Response.Write(" <script>alert('删除成功'); location='ji_chu_zi_liao_page.aspx';</script>");
                    }
                }
            }
        }

        public int del_jczl_ff(int id)
        {
            JinChuModel jinchu = new JinChuModel();
            int isrun = jinchu.delete(id);
            return isrun;

        }

        [System.Web.Services.WebMethod]
        public static string picture_upd(string id, string base64)
        {
            JinChuModel jinchu = new JinChuModel();
            jinchu.picture_upd(id, base64);
            return "完成";
        }

        protected void jczl_tj(object sender, EventArgs e)
        {
          
            if (Context.Request["tj_pd"].ToString() == "tj_true")
            {
                JinChuModel jinchu = new JinChuModel();
                //row_count = jinchu.getList(user.gongsi).Count;
                List<yh_jinxiaocun_jichuziliao> list_jczl = new List<yh_jinxiaocun_jichuziliao>();
                row_count = Convert.ToInt32(Session["now_lisetcount_1"].ToString());

                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    yh_jinxiaocun_jichuziliao zaji = new yh_jinxiaocun_jichuziliao();
                    zaji.sp_dm = Context.Request["sp_dm" + i].ToString();
                    zaji.name = Context.Request["name" + i].ToString();
                    zaji.lei_bie = Context.Request["lei_bie" + i].ToString();
                    zaji.dan_wei = Context.Request["dan_wei" + i].ToString();
                    zaji.shou_huo = Context.Request["shou_huo" + i].ToString();
                    zaji.gong_huo = Context.Request["Gong_huo" + i].ToString();
                    zaji.mark1 = "";
                    zaji.zh_name = user.name;
                    zaji.gs_name = user.gongsi;
                    list_jczl.Add(zaji);
                }
                if (list_jczl.Count > 0) {
                    jinchu.add(list_jczl);
                }
                
                for (int i = 0; i < row_count; i++)
                {
                    jinchu.update(Context.Request["sp_dm_cs" + i].ToString(), Context.Request["name_cs" + i].ToString(), Context.Request["lei_bie_cs" + i].ToString(), Context.Request["dan_wei_cs" + i].ToString(), Context.Request["shou_huo_cs" + i].ToString(), Context.Request["gong_huo_cs" + i].ToString(), Context.Request["id_cs" + i].ToString());
                }
                jczl_select_load(sender, e);
                Response.Write(" <script>alert('提交成功'); location='ji_chu_zi_liao_page.aspx';</script>");
            }
        }

    }
}