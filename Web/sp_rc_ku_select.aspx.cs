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
    public partial class sp_rc_ku_select : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.shuaxin();
        }
        protected void rc_ku_select_load(object sender, EventArgs e)
        {
            shuaxin();
        }

        private void shuaxin() {
            try
            {
                if (Session["username"] == null && Session["gs_name"] == null)
                {
                    Response.Write("<script>alert('请登录！');window.parent.location.href='../Myadmin/Login.aspx';</script>");
                }
                else
                {
                    List<string> list = rc_ku_xl_select(Session["username"].ToString(), Session["gs_name"].ToString());
                    Session["rc_ku_xl_select"] = list;
                    Session["selectSp"] = null;
                }
            }
            catch (Exception ex) { throw; }
        }
        protected void rc_ku_select_Click(object sender, EventArgs e)
        {
            string spname = Context.Request["kui_lei"].ToString();
            string username = Session["username"].ToString();
            string gs_name = Session["gs_name"].ToString();
            if (!spname.Equals("请选择"))
            {
                List<rc_ku_info> lista = rc_ku_select(spname, username, gs_name);
                Session["selectSp"] = lista;
            }
            else
            {
                Session["selectSp"] = null;
            }
        }
        public List<rc_ku_info> rc_ku_select(string name, string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<rc_ku_info> list = buiness.rc_ku_select(name, zh_name, gs_name);
            return list;
        }

        public List<string> rc_ku_xl_select(string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<string> list = buiness.rc_ku_xl_select(zh_name, gs_name);
            return list;
        }
    }
}