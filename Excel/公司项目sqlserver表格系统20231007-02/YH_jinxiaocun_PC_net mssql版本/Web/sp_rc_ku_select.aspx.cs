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
    public partial class sp_rc_ku_select : System.Web.UI.Page
    {
        private static yh_jinxiaocun_user user;
        int now_lisetcount;

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
                    if (!Page.IsPostBack)
                        shuaxin();
                    MingxiModel mingxi = new MingxiModel();
                    if (!Page.IsPostBack)
                        Session["selectSp"] = mingxi.getCpMingXi_all(user.gongsi); ;
                }
                catch
                {
                    Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
                }
            }
        }

        protected void Page_Unload(object serfer, EventArgs e)
        {
            Session["cpname"] = "";
        }

        protected void rc_ku_select_load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                    shuaxin();
                MingxiModel mingxi = new MingxiModel();
                Session["selectSp"] = mingxi.getCpMingXi_all(user.gongsi); 

            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }

        private void shuaxin()
        {
            Session["cpname"] = "";
            List<string> list = rc_ku_xl_select(user.gongsi);
            Session["rc_ku_xl_select"] = list;
            Session["selectSp"] = null;
        }

        protected void rc_ku_select_Click(object sender, EventArgs e)
        {
            string sp_dm = Context.Request["sp_dm"].ToString();
            Session["sp_dm"] = sp_dm;
            string cplb = Context.Request["cplb"].ToString();
            Session["cplb"] = cplb;
            string spname = Context.Request["kui_lei"].ToString();
            Session["cpname"] = spname;
            try
            {
                if (!spname.Equals("请选择"))
                {
                    MingxiModel mingxi = new MingxiModel();
                    Session["selectSp"] = mingxi.getCpMingXi(sp_dm,cplb,spname, user.gongsi);

                }
                else
                {
                    MingxiModel mingxi = new MingxiModel();
                    Session["selectSp"] = mingxi.getCpMingXi2(sp_dm, cplb, user.gongsi);
                }
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }

        public List<string> rc_ku_xl_select(string gs_name)
        {
            MingxiModel mingxi = new MingxiModel();
            List<yh_jinxiaocun_mingxi> list = mingxi.getCpNames(gs_name);
            List<string> cpNames = new List<string>();

            //List<yh_jinxiaocun_jinhuofang> list = Session["gys_select"] as List<yh_jinxiaocun_jinhuofang>;
            now_lisetcount = list.Count();
            Session["now_lisetcount_1"] = list;

            foreach (yh_jinxiaocun_mingxi m in list)
            {
                cpNames.Add(m.cpname);
            }
            return cpNames;
        }
        protected void toExcel(object sender, EventArgs e)
        {

            List<ming_xi_info> OnlineShow_datas1 = new List<ming_xi_info>();
            int id = 0;
            {
                
                List<MingXiItem> list = Session["selectSp"] as List<MingXiItem>;
                //List<MingXiItem> list = Session["now_lisetcount_1"] as List<MingXiItem>;
                foreach (MingXiItem m in list)
                {

                    ming_xi_info itemhew = new ming_xi_info();

                    itemhew.sp_dm = m.sp_dm;
                    itemhew.Cpname = m.cpname;
                    itemhew.Cplb = m.cplb;
                    itemhew.ruku_num = m.ruku_num;
                    itemhew.ruku_price = m.ruku_price;
                    itemhew.chuku_num = m.chuku_num;
                    itemhew.chuku_price = m.chuku_price;

                    OnlineShow_datas1.Add(itemhew);

                }

            }
            if (OnlineShow_datas1.Count > 0)
            {
                Session["printList"] = OnlineShow_datas1;

                Response.Redirect("./RDLC/sp_rc_ku_select_dayin.aspx");
            }

        }
    }
}