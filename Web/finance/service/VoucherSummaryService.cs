using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.entiy;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    /// <author>
    /// dai
    /// </author>
    public class VoucherSummaryService
    {
        //model层
        private VoucherSummaryModel voucherSummaryModel;

        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public VoucherSummaryService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                voucherSummaryModel = new VoucherSummaryModel();
                commonModel = new CommonModel();
            }catch{
                throw new Exception("身份验证不通过");
            }
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>有pageList的分页对象</returns>
        public FinancePage<VoucherSummaryItem> getVoucherSummaryList(FinancePage<VoucherSummaryItem> financePage) {
            financePage = voucherSummaryModel.getList(financePage, account.company);
            financePage.total = voucherSummaryModel.getCount(account.company);
            return financePage;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="voucherSummaryItem">子类</param>
        /// <returns>是否成功</returns>
        public Boolean updVoucherSummary(VoucherSummaryItem voucherSummaryItem) {
            voucherSummaryItem.company = account.company;
            int result = commonModel.comUpd<VoucherSummary>(voucherSummaryItem.getParent());
            return result > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>是否成功</returns>
        public Boolean delVoucherSummary(int[] ids) {
            VoucherSummary voucherSummary = new VoucherSummary();
            for (int i = 0; i < ids.Length; i++) { 
                voucherSummary = commonModel.comFind<VoucherSummary>(voucherSummary,ids[i]);
                if (commonModel.comDel<VoucherSummary>(voucherSummary) <= 0) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="voucherSummary">新对象</param>
        /// <returns>是否成功</returns>
        public Boolean addVoucherSummary(VoucherSummary voucherSummary)
        {
            voucherSummary.company = account.company;
            return commonModel.comAdd<VoucherSummary>(voucherSummary) > 0;
        }

        
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <param name="examineName">审核人姓名</param>
        /// <returns>是否成功</returns>
        public Boolean examineVoucherSummary(int[] ids, string examineName) {
            VoucherSummary voucherSummary = new VoucherSummary();
            for (int i = 0; i < ids.Length; i++) {
                voucherSummary = commonModel.comFind<VoucherSummary>(voucherSummary, ids[i]);
                voucherSummary.man = examineName;
                if(commonModel.comUpd<VoucherSummary>(voucherSummary) <= 0){
                    return false;
                }
            }
            return true;
        }
    }
}