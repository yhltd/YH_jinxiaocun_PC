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
                    MingxiModel mingxi = new MingxiModel();
                    List<MingXiItem> list = mingxi.getChMingxi_all(user.gongsi);
                    Session["rk_mx_select"] = list;
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
                MingxiModel mingxi = new MingxiModel();
                List<MingXiItem> list = mingxi.getChMingxi_all( user.gongsi);
                Session["rk_mx_select"] = list;
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

        protected void toExcel(object sender, EventArgs e)
        {

            List<ming_xi_info> OnlineShow_datas1 = new List<ming_xi_info>();
            int id = 0;
            {

                List<MingXiItem> list = Session["rk_mx_select"] as List<MingXiItem>;
                //List<MingXiItem> list = Session["now_lisetcount_1"] as List<MingXiItem>;
                foreach (MingXiItem m in list)
                {

                    ming_xi_info itemhew = new ming_xi_info();

                    itemhew.shou_h = m.shou_h;
                    itemhew.sp_dm = m.sp_dm;
                    itemhew.Cpname = m.cpname;
                    itemhew.Cplb = m.cplb;
                    itemhew.ruku_num = m.ruku_num;
                    itemhew.ruku_price = m.ruku_price;

                    OnlineShow_datas1.Add(itemhew);

                }

            }
            if (OnlineShow_datas1.Count > 0)
            {
                Session["printList"] = OnlineShow_datas1;

                Response.Redirect("~/RDLC/kh_ming_xi_selcet_dayin.aspx");
            }

        }

    }
}