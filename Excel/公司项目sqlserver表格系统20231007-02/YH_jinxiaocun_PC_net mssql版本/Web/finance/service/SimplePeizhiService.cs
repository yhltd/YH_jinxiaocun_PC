using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class SimplePeizhiService : ApiController
    {
        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public SimplePeizhiService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
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
        public FinancePage<AccountingPeizhi> getAccounting(FinancePage<AccountingPeizhi> financePage)
        {
            AccountingPeizhi accountingPeizhi = new AccountingPeizhi();
            //获取pageList
            financePage = commonModel.getComList<AccountingPeizhi>(accountingPeizhi, financePage, account.company, "accounting");
            //获取总行数
            financePage.total = commonModel.getComTotal<AccountingPeizhi>(accountingPeizhi, account.company, "accounting");
            return financePage;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<KehuPeizhi> getKehu(FinancePage<KehuPeizhi> financePage)
        {
            KehuPeizhi kehuPeizhi = new KehuPeizhi();
            //获取pageList
            financePage = commonModel.getComList<KehuPeizhi>(kehuPeizhi, financePage, account.company, "kehu");
            //获取总行数
            financePage.total = commonModel.getComTotal<KehuPeizhi>(kehuPeizhi, account.company, "kehu");
            return financePage;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<InvoicePeizhi> getInvoice(FinancePage<InvoicePeizhi> financePage)
        {
            InvoicePeizhi invoicePeizhi = new InvoicePeizhi();
            //获取pageList
            financePage = commonModel.getComList<InvoicePeizhi>(invoicePeizhi, financePage, account.company, "invoice_type");
            //获取总行数
            financePage.total = commonModel.getComTotal<InvoicePeizhi>(invoicePeizhi, account.company, "invoice_type");
            return financePage;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addAccounting(AccountingPeizhi accountingPeizhi)
        {
            accountingPeizhi.company = account.company;
            return commonModel.comAdd<AccountingPeizhi>(accountingPeizhi) > 0;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addKehu(KehuPeizhi kehuPeizhi)
        {
            kehuPeizhi.company = account.company;
            return commonModel.comAdd<KehuPeizhi>(kehuPeizhi) > 0;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addInvoice(InvoicePeizhi invoicePeizhi)
        {
            invoicePeizhi.company = account.company;
            return commonModel.comAdd<InvoicePeizhi>(invoicePeizhi) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean updAccounting(AccountingPeizhi accountingPeizhi)
        {
            accountingPeizhi.company = account.company;
            return commonModel.comUpd<AccountingPeizhi>(accountingPeizhi) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean updKehu(KehuPeizhi kehuPeizhi)
        {
            kehuPeizhi.company = account.company;
            return commonModel.comUpd<KehuPeizhi>(kehuPeizhi) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean updInvoice(InvoicePeizhi invoicePeizhi)
        {
            invoicePeizhi.company = account.company;
            return commonModel.comUpd<InvoicePeizhi>(invoicePeizhi) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean delAccounting(int[] ids)
        {
            AccountingPeizhi accountingPeizhi = new AccountingPeizhi();
            for (int i = 0; i < ids.Length; i++)
            {
                accountingPeizhi = commonModel.comFind<AccountingPeizhi>(accountingPeizhi, ids[i]);
                if (commonModel.comDel<AccountingPeizhi>(accountingPeizhi) <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean delKehu(int[] ids)
        {
            KehuPeizhi kehuPeizhi = new KehuPeizhi();
            for (int i = 0; i < ids.Length; i++)
            {
                kehuPeizhi = commonModel.comFind<KehuPeizhi>(kehuPeizhi, ids[i]);
                if (commonModel.comDel<KehuPeizhi>(kehuPeizhi) <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean delInvoice(int[] ids)
        {
            InvoicePeizhi invoicePeizhi = new InvoicePeizhi();
            for (int i = 0; i < ids.Length; i++)
            {
                invoicePeizhi = commonModel.comFind<InvoicePeizhi>(invoicePeizhi, ids[i]);
                if (commonModel.comDel<InvoicePeizhi>(invoicePeizhi) <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <returns>集合</returns>
        public List<AccountingPeizhi> getAccountingPeizhi()
        {
            return commonModel.getAccountingPeizhi(account.company);
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <returns>集合</returns>
        public List<KehuPeizhi> getKehuPeizhi()
        {
            return commonModel.getKehuPeizhi(account.company);
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <returns>集合</returns>
        public List<InvoicePeizhi> getInvoicePeizhi()
        {
            return commonModel.getInvoicePeizhi(account.company);
        }
    }
}