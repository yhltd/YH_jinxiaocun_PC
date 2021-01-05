using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class VoucherWordService
    {
        //model层
        private VoucherWordModel voucherWordModel;

        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public VoucherWordService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                voucherWordModel = new VoucherWordModel();
                commonModel = new CommonModel();
            }catch{
                throw new Exception("身份验证不通过");
            }
        }


        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<VoucherWord> getVoucherWordList(FinancePage<VoucherWord> financePage)
        {
            //获取pageList
            financePage = voucherWordModel.getList(financePage, account.company);
            //获取总行数
            financePage.total = voucherWordModel.getCount(account.company);
            return financePage;
        }

        /// <summary>
        /// 获取所有凭证字
        /// </summary>
        /// <returns></returns>
        public List<VoucherWord> getVoucherWordList()
        {
            return voucherWordModel.getList(account.company);;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addVoucherWord(VoucherWord voucherWord)
        {
            voucherWord.company = account.company;
            return commonModel.comAdd<VoucherWord>(voucherWord) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean deleteVoucherWord(int[] ids)
        {
            VoucherWord voucherWord = new VoucherWord();
            for (int i = 0; i < ids.Length; i++)
            {
                voucherWord = commonModel.comFind<VoucherWord>(voucherWord, ids[i]);
                if (commonModel.comDel<VoucherWord>(voucherWord) <= 0)
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
        public Boolean updateVoucherWord(VoucherWord voucherWord)
        {
            voucherWord.company = account.company;
            return commonModel.comUpd<VoucherWord>(voucherWord) > 0;
        }
    }
}