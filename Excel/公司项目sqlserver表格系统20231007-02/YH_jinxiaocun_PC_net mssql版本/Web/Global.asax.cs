using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Web.finance;
using Web.finance.util;

namespace Web
{
    public class Global1 : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception objErr = Server.GetLastError().GetBaseException();
            string error = "发生异常页: " + Request.Url.ToString() + "";
            error += "异常信息: " + objErr.Message + "";
            Server.ClearError();
            if (error .Contains("异常信息: DataBinding:“System.Data.DataRowView”不包含名为“id”的属性"))
            {
                error = "此页面没有相关数据，请按照操作流程先后顺序填入其他页面相应数据后会自动显示此页面信息";
            }
                Application["error"] = error;
            Response.Redirect("~/ErrorPage/ErrorPage.aspx?Error=" + error);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}