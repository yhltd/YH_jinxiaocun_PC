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

using clsBuiness;
using System.ComponentModel;
using System.Reflection;

namespace Web
{
    public partial class ru_ku : System.Web.UI.Page
    {
        public string ConStr;
        public string ConStrPIC;
        public string rev_servename;

        public ru_ku()
        {
            if (HttpRuntime.Cache.Get("servename") != null)
            {
                var objCache = HttpRuntime.Cache.Get("servename");

                ConStr = System.Web.Configuration.WebConfigurationManager.AppSettings[objCache.ToString()];
                ConStrPIC = ConStr.Replace("Provider=SQLOLEDB;", "");

            }
            else
            {
                if (HttpContext.Current.Request.Cookies["MyCook"] != null)
                {
                    HttpCookie cookie1 = HttpContext.Current.Request.Cookies["MyCook"];

                    if (cookie1 != null && cookie1["servename"].ToString() != "")
                    {
                        rev_servename = cookie1["servename"].ToString();

                        // var rev_servename = HttpContext.Current.Session["servename"];
                        if (rev_servename != "" && rev_servename != null)
                        {

                            //ConStr = System.Web.Configuration.WebConfigurationManager.AppSettings[cookie1["servename"].ToString()];
                            ConStr = System.Web.Configuration.WebConfigurationManager.AppSettings[HttpUtility.UrlDecode(cookie1["servename"].ToString()).ToString()];

                            ConStrPIC = ConStr.Replace("Provider=SQLOLEDB;", "");

                        }
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool select_rk()
        {
            bool check = false;
            clsAllnew BusinessHelp = new clsAllnew();


            return check;
        }

        public void insert_ruku(List<ming_xi_info> mxif)
        {
 
            clsAllnew buiness = new clsBuiness.clsAllnew();
            buiness.buindess_addinput_ku(mxif);
 
            //MySqlHelper.ExecuteSql(sql, ConStr);
        }



        public void xxx()
        {
            Response.Write("<script>alert('修改成功');</script>");
        }

        protected void bt_add_Click(object sender, EventArgs e)
        {
            List<ming_xi_info> list = new List<ming_xi_info>();
            ming_xi_info mxi = new ming_xi_info();
            mxi.Cpname = Context.Request["sp_name"].ToString();
            mxi.sp_dm = Context.Request["sp_dm"].ToString();
            mxi.Cplb = Context.Request["sp_cplb"].ToString();
            mxi.Cpsj = Context.Request["sp_cpsj"].ToString();
            mxi.Cpsl = Context.Request["sp_cpsl"].ToString();
            list.Add(mxi);
            insert_ruku(list);
            //string sp_name = Context.Request["sp_name"].ToString();
            //string sp_dm = Context.Request["sp_dm"].ToString();
            //string sp_cplb = Context.Request["sp_cplb"].ToString();
            //string sp_cpsj = Context.Request["sp_cpsj"].ToString();
            //string sp_cpsl = Context.Request["sp_cpsl"].ToString();
            //string sp_je = Context.Request["sp_name"].ToString();
            //string sp_bz = Context.Request["sp_bz"].ToString();
        }
        public void print()
        {

        }

    }
}