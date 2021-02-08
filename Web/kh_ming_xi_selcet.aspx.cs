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
using Web.ServerEntity;

namespace Web
{
    public partial class kh_ming_xi_selcet : System.Web.UI.Page
    {
        private static yh_jinxiaocun_user user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user == null)
            {
                Response.Write("<script>alert('请登录！');window.parent.location.href='../Myadmin/Login.aspx';</script>");
            }
            else
            {
                try
                {
                    this.shuaxin();
                }
                catch
                {
                    Response.Write("<script>alert('网络错误，请稍后再试！');window.parent.location.href='../Myadmin/Login.aspx';</script>");
                }
                
            }
        }

        protected void Page_Unload(object serfer, EventArgs e)
        {
            Session["shouhuo"] = "";
        }

        private void shuaxin(){
            Session["shouhuo"] = "";
            MingxiModel mingxi = new MingxiModel();
            List<yh_jinxiaocun_mingxi> list = mingxi.getShouHuoMingXi(user.gongsi);
            List<string> gonghuos = new List<string>();
            foreach (yh_jinxiaocun_mingxi m in list)
            {
                gonghuos.Add(m.shou_h);
            }
            Session["kh_mx_xl_select"] = gonghuos;
            Session["rk_mx_select"] = null;
        }

        protected void kh_mx_select_load(object sender, EventArgs e)
        {
            try
            {
                this.shuaxin();
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');window.parent.location.href='../Myadmin/Login.aspx';</script>");
            }
        }
       

        protected void kh_mx_select_Click(object sender, EventArgs e)
        {
            try
            {
                string gong_huo = Context.Request["gonghuo"];
                Session["shouhuo"] = gong_huo;
                MingxiModel mingxi = new MingxiModel();
                List<MingXiItem> list = mingxi.getChMingxi(gong_huo, user.gongsi);
                Session["rk_mx_select"] = list;
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');window.parent.location.href='../Myadmin/Login.aspx';</script>");
            }
        }
    }
}