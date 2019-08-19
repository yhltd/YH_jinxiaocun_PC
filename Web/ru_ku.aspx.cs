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




namespace Web
{
    public partial class ru_ku : System.Web.UI.Page
    {
        public string ConStr;
        public string ConStrPIC;
        public string rev_servename;

        public ru_ku() {
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

        public bool select_rk() { 
            bool check = false;
            clsAllnew BusinessHelp = new clsAllnew();


            return check;
        }

        public void insert_ruku(List<ming_xi_info> mxif) {
            string sql = "";
            foreach (ming_xi_info item in mxif)
            {
              
                sql = "insert into Yh_JinXiaoCun_mingxi(id,openid,cpid,cpjg,cplb,cpname,cpsj,cpsl,finduser,gongsi,mxtype,orderid,shijian) values ('" + item.Id + "','" + item.Openid + "',N'" + item.Cpid + "','" + item.Cpjg + "','" + item.Cplb + "','" + item.Cpname + "','" + item.Cpsj + "','" + item.Cpsl + "','" + item.Finduser + "','" + item.Gongsi + "','" + item.Mxtype + "','" + item.Orderid + "','" + item.Shijian + "')";

               

            }
            //int isrun = MySqlHelper.ExecuteSql(sql, ConStr);
        }
        protected void ru_ku_click(object sender, EventArgs e) {

            string username = Request.Form["sp_name"];
            
        }

    }
}