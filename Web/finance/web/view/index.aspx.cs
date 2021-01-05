using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.finance.util;

namespace Web.finance.web.view
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpRuntime.Cache.Insert("finance_allSpace", FinanceSpace.getFinanceSpace().getMark4());
                HttpRuntime.Cache.Insert("finance_useSpace", FinanceSpace.getFinanceSpace().getUseMark4());
                int state = FinanceSpace.getFinanceSpace().checkSpace();
                if (state == -1)
                {
                    Response.Write("<script>alert('您在我公司租用的数据库容量即将超出上限，请注意。')</script>");
                }
                else if (state == -2)
                {
                    Response.Write("<script>alert('您在我公司租用的数据库容量已超上限，该系统暂时无法使用。请联系我公司，官方微信号：1623005800。')</script>");
                    FinanceToError.getFinanceToError().toError("本系统您已无法使用，续费联系云合未来官方微信：1623005800。");
                }
            }
            catch
            {
                FinanceToError.getFinanceToError().toError("错误，请重新登录。");
            }
        }
    }
}