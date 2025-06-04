using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class InvoiceService
    {
        //model
        private InvoiceModel invoiceModel;

        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public InvoiceService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                invoiceModel = new InvoiceModel();
                commonModel = new CommonModel();
            }catch{
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<Invoice> getList(FinancePage<Invoice> financePage, string ks, string js, string unit)
        {
            financePage = invoiceModel.getList(financePage, account.company, ks, js, unit);
            financePage.total = invoiceModel.getCount(account.company);
            return financePage;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="simpleData"></param>
        /// <returns></returns>
        public Boolean upd(Invoice invoice)
        {
            invoice.company = account.company;
            int result = commonModel.comUpd<Invoice>(invoice);
            return result > 0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="simpleData"></param>
        /// <returns></returns>
        public Boolean add(Invoice invoice)
        {
            invoice.company = account.company;
            int result = commonModel.comAdd<Invoice>(invoice);
            return result > 0;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Boolean del(int[] ids)
        {
            Invoice invoice = new Invoice();
            for (int i = 0; i < ids.Length; i++)
            {
                invoice = commonModel.comFind<Invoice>(invoice, ids[i]);
                if (commonModel.comDel<Invoice>(invoice) <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
