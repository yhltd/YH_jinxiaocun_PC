using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class SimpleAccountingService
    {
        //model
        private SimpleAccountingModel simpleAccountingModel;

        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public SimpleAccountingService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                simpleAccountingModel = new SimpleAccountingModel();
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
        public FinancePage<SimpleAccounting> getSimpleAccountingList(FinancePage<SimpleAccounting> financePage)
        {
            financePage = simpleAccountingModel.getList(financePage, account.company);
            financePage.total = simpleAccountingModel.getCount(account.company);
            return financePage;
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <returns>集合</returns>
        public List<SimpleAccounting> getSimpleAccountingList()
        {
            return simpleAccountingModel.getList(account.company);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="simpleAccounting"></param>
        /// <returns></returns>
        public Boolean newSimpleAccounting(SimpleAccounting simpleAccounting)
        {
            simpleAccounting.company = account.company;
            int result = commonModel.comAdd<SimpleAccounting>(simpleAccounting);
            return result > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="simpleAccounting"></param>
        /// <returns></returns>
        public Boolean updSimpleAccounting(SimpleAccounting simpleAccounting)
        {
            simpleAccounting.company = account.company;
            int result = commonModel.comUpd<SimpleAccounting>(simpleAccounting);
            return result > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Boolean delSimpleAccounting(int[] ids)
        {
            SimpleAccounting simpleAccounting = new SimpleAccounting();
            for (int i = 0; i < ids.Length; i++)
            {
                simpleAccounting = commonModel.comFind<SimpleAccounting>(simpleAccounting, ids[i]);
                if (commonModel.comDel<SimpleAccounting>(simpleAccounting) <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}