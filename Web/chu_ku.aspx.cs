using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;
using Order.Common;
using clsBuiness;
using System.Reflection;
using System.Web.Services;
using System.Web.Script.Serialization;
using Web.jxc_service;
using System.Collections;
using SDZdb;

namespace Web
{
    public partial class chu_ku : System.Web.UI.Page
    {
        public string ConStr;
        public string ConStrPIC;
        public string rev_servename;
        protected int sb;

        private string kc_id;
        private static clsuserinfo user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsuserinfo)Session["user"];
            if (user != null)
            {
                string act = Request["act"] == null ? "" : Request["act"].ToString();

                try
                {

                    if (act.Equals("newSp"))
                    {
                        Response.Write(getNewSp());
                        Response.End();
                        return;
                    }
                    if (act.Equals("checkOrder"))
                    {
                        Response.Write(checkOrderId(Request["order_id"]));
                        Response.End();
                        return;
                    }
                    if (act.Equals("shouhuoList"))
                    {
                        Response.Write(getShouHuoList());
                        Response.End();
                        return;
                    }
                    if (act.Equals("insert"))
                    {
                        Response.Write(insert_ruku(Request["infos"].ToString()));
                        Response.End();
                        return;
                    }

                }
                catch (Exception ex) { throw; }

            }
            else
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }



        }

        public static string checkOrderId(string order_id)
        {
            mingxi r = new mingxi();
            return r.checkOrder_id(order_id, user.gongsi).ToString();
        }

        public static string getNewSp()
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<zl_and_jc_info> list = buiness.select_jczl(user.name, user.gongsi);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string result = js.Serialize(list);
            return result;
        }


        public string insert_ruku(string list)
        {
            items infoList = new items();
            JavaScriptSerializer js = new JavaScriptSerializer();
            infoList = js.Deserialize<items>(list);
            mingxi r = new mingxi();
            string result = r.insertMingxi(infoList, user.gongsi, user.name, "出库").ToString();
            return result;
        }

        public static string getShouHuoList()
        {
            mingxi r = new mingxi();
            List<string> gonghuo = r.getShouHuo(user.name, user.gongsi);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string result = js.Serialize(gonghuo);
            return result;
        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {

        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {

        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {

        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {

        }
    }
}