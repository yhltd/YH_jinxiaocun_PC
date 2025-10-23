using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.util;
using Web.Util;
using Web.Pushnews.model;
using Web.Pushnews.dao;

namespace Web.finance.web.view.web_service
{
    /// <author>
    /// dai
    /// </author>
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class space : System.Web.Services.WebService
    {
        [WebMethod]
        public string getSpace()
        {
            string msg = "错误";
            int code = 500;
            try
            {
                int state = FinanceSpace.getFinanceSpace().checkSpace();
                switch (state) { 
                    case -1:
                        msg = "您在我公司租用的数据库容量即将超出上限，请注意。";
                        code = 200;
                        break;
                    case 0:
                        msg = "已使用容量不超过90%，请放心使用。";
                        code = 200;
                        break;
                    default:
                        msg = "错误";
                        code = 500;
                        break;
                }
                return FinanceResultData.getFinanceResultData().success(code, null, msg);
            }
            catch
            {
                return FinanceResultData.getFinanceResultData().success(code, null, msg);
            }
        }



        //新加
        [WebMethod]
        public List<product_pushnews> GetPushNewsData(string companyName)
        {
            try
            {
                PushNewsDao dao = new PushNewsDao();
                return dao.SelectListCW(companyName);  // 传递公司名称参数
            }
            catch (InvalidOperationException)
            {
                return new List<product_pushnews>();
            }
            catch
            {
                return new List<product_pushnews>();
            }
        }






    }
}
