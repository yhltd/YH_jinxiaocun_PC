using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.Services;
using Web.Server;


namespace Web
{
    public partial class frmMain : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl frame1;


        public static string nowpage;
        private static yh_jinxiaocun_user user;


        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user != null)
            {
                userName.InnerHtml = user.name;
                HtmlControl frame1 = (HtmlControl)this.FindControl("frame1");

                clsAllnew allbewn = new clsAllnew();

                allbewn.inputcookvalue("入库");

                NewMethod();
            }
            else {
                Response.Write("<script>alert('请登录！');location='/Myadmin/Login.aspx';</script>");
            }
        }

        private void NewMethod()
        {
            HttpCookie cookie1 = Request.Cookies["nowpage"];

            if (cookie1 != null && cookie1["nowpage_name"].ToString() != "")
            {
                nowpage = HttpUtility.UrlDecode(cookie1["nowpage_name"].ToString());

            }
        }
        [WebMethod]
        [STAThread]
       public static string update_laber(string mingcheng, string minzu)
        
        {
            try
            {
                clsAllnew allbewn = new clsAllnew();

                allbewn.inputcookvalue(mingcheng);

                HttpCookie cookie1 = System.Web.HttpContext.Current.Request.Cookies["nowpage"];

                if (cookie1 != null && cookie1["nowpage_name"].ToString() != "")
                {
                    nowpage = HttpUtility.UrlDecode(cookie1["nowpage_name"].ToString());

                }

                return "读取成功" + mingcheng;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        protected void goUserManager_Click(Object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>goUserManager(" + user.AdminIS=="true"?"1":"0" + ");</script>");
        }

    }
}