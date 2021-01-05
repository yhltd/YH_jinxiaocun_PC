using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.finance.util
{
    /// <author>
    /// dai
    /// </author>
    public class FinanceToError
    {
        private FinanceToError() { }

        private static FinanceToError financeToError;

        public static FinanceToError getFinanceToError() {
            if (financeToError == null) {
                financeToError = new FinanceToError();
            }
            return financeToError;
        }
        
        public void toError(string msg) {
            HttpRuntime.Cache.Remove("finance_isLogin");
            HttpRuntime.Cache.Remove("finance_token");
            HttpRuntime.Cache.Insert("msg", msg);
            System.Web.HttpContext.Current.Response.Redirect("~/finance/web/view/error.aspx");
        }

        public void toError()
        {
            //HttpRuntime.Cache.Remove("finance_token");
        }
    }
}