using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class ManagementService
    {
        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public ManagementService()
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
        public FinancePage<ManagementExpenditure> getManagementExpenditureList(FinancePage<ManagementExpenditure> financePage) 
        {
            ManagementExpenditure managementExpenditure = new ManagementExpenditure();
            //获取pageList
            financePage = commonModel.getComList<ManagementExpenditure>(managementExpenditure, financePage, account.company, "managementExpenditure");
            //获取总行数
            financePage.total = commonModel.getComTotal<ManagementExpenditure>(managementExpenditure, account.company, "managementExpenditure");
            return financePage;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addManagementExpenditure(ManagementExpenditure managementExpenditure)
        {
            managementExpenditure.company = account.company;
            return commonModel.comAdd<ManagementExpenditure>(managementExpenditure) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean deleteManagementExpenditure(int[] ids)
        {
            ManagementExpenditure managementExpenditure = new ManagementExpenditure();
            for (int i = 0; i < ids.Length; i++) {
                managementExpenditure = commonModel.comFind<ManagementExpenditure>(managementExpenditure, ids[i]);
                if (commonModel.comDel<ManagementExpenditure>(managementExpenditure) <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean updateManagementExpenditure(ManagementExpenditure managementExpenditure)
        {
            managementExpenditure.company = account.company;
            return commonModel.comUpd<ManagementExpenditure>(managementExpenditure) > 0;
        }






















        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<ManagementIncome> getManagementIncomeList(FinancePage<ManagementIncome> financePage)
        {
            ManagementIncome managementIncome = new ManagementIncome();
            //获取pageList
            financePage = commonModel.getComList<ManagementIncome>(managementIncome, financePage, account.company, "managementIncome");
            //获取总行数
            financePage.total = commonModel.getComTotal<ManagementIncome>(managementIncome, account.company, "managementIncome");
            return financePage;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addManagementIncome(ManagementIncome ManagementIncome)
        {
            ManagementIncome.company = account.company;
            return commonModel.comAdd<ManagementIncome>(ManagementIncome) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean deleteManagementIncome(int[] ids)
        {
            ManagementIncome ManagementIncome = new ManagementIncome();
            for (int i = 0; i < ids.Length; i++)
            {
                ManagementIncome = commonModel.comFind<ManagementIncome>(ManagementIncome, ids[i]);
                if (commonModel.comDel<ManagementIncome>(ManagementIncome) <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean updateManagementIncome(ManagementIncome ManagementIncome)
        {
            return commonModel.comUpd<ManagementIncome>(ManagementIncome) > 0;
        }
    }
}