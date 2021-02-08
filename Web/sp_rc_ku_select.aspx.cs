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

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user == null)
            {
                Response.Write("<script>alert('请登录！');window.parent.location.href='../Myadmin/Login.aspx';</script>");
            }
            else {
                try
                {
                    shuaxin();
                }
                catch {
                    Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
                }
            }
        }

        protected void Page_Unload(object serfer, EventArgs e) {
            Session["cpname"] = "";
        }

        protected void rc_ku_select_load(object sender, EventArgs e)
        {
            try
            {
                
                shuaxin();
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }

        private void shuaxin() {
            Session["cpname"] = "";
            List<string> list = rc_ku_xl_select(user.gongsi);
            Session["rc_ku_xl_select"] = list;
            Session["selectSp"] = null;
        }

        protected void rc_ku_select_Click(object sender, EventArgs e)
        {
            string spname = Context.Request["kui_lei"].ToString();
            Session["cpname"] = spname;
            try
            {
                if (!spname.Equals("请选择"))
                {
                    MingxiModel mingxi = new MingxiModel();
                    Session["selectSp"] = mingxi.getCpMingXi(spname, user.gongsi); ;
                }
                else
                {
                    Session["selectSp"] = null;
                }
            }
            catch {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }

        public List<string> rc_ku_xl_select(string gs_name)
        {
            MingxiModel mingxi = new MingxiModel();
            List<yh_jinxiaocun_mingxi> list = mingxi.getCpNames(gs_name);
            List<string> cpNames = new List<string>();

            foreach (yh_jinxiaocun_mingxi m in list) {
                cpNames.Add(m.cpname);
            }
            return cpNames;
        }
    }
}