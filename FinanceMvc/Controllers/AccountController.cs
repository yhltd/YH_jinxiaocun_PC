using Web.Models;
using Web.Service;
using Web.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Web.Controllers
{
    /// <author>
    /// dai
    /// </author>
    public class AccountController : Controller
    {
        private AccountService asi = new AccountService();

        /// <summary>
        /// 跳转到主页面
        /// </summary>
        /// <param name="token">密钥</param>
        /// <returns>视图</returns>
        public ActionResult toIndex(string token)
        {
            Account account = null;
            if (!(token == null || token.Equals(""))) {
                account = asi.getAccount(token);
            }
            if (account != null)
            {
                FinanceResultData resultData = FinanceResultData.getFinanceResultData();
                ViewBag.data = resultData.success(200, token, "成功");
                return View(FinanceViewPath.getViewName("index"));
            }
            else 
            {
                ViewBag.code = "404";
                ViewBag.msg = "未找到该页面";
                return View(FinanceViewPath.getViewName("error"));
            }
        }

        public ActionResult test() {
            string token = asi.login("admin", "ppp", "pwd");
            return this.toIndex(token);
        }

    }
}