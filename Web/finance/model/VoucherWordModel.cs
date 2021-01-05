using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.finance.util;

namespace Web.finance.model
{
    public class VoucherWordModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public VoucherWordModel() 
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="company">公司名</param>
        /// <returns>行数</returns>
        public int getCount(string company)
        {
            var selectParam = new SqlParameter("@company", company);
            var result = from u in fin.VoucherWord where u.company == company select u;

            int count = 0;
            try
            {
                count = result.ToList().Count;
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return count;
        }

        /// <summary>
        /// 查询list
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司</param>
        /// <returns>有pageList的分页对象</returns>
        public FinancePage<VoucherWord> getList(FinancePage<VoucherWord> financePage, string company)
        {
            //公司
            var companyParam = new SqlParameter("@company", company);
            //查询最小行数
            var minPageParam = new SqlParameter("@minPage", financePage.getMin());
            //查询最大行数
            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());

            string sql = "select a.* from (select ROW_NUMBER() over(order by id) rownum,* from VoucherWord where company = @company) as a where a.rownum > @minPage and a.rownum < @maxPage";

            var result = fin.Database.SqlQuery<VoucherWord>(sql, companyParam, minPageParam, maxPageParam);
            try
            {
                financePage.pageList = result.ToList();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return financePage;
        }

        /// <summary>
        /// 获取所有凭证字
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<VoucherWord> getList(string company) {
            var selectParam = new SqlParameter("@company", company);
            var result = from u in fin.VoucherWord where u.company == company select u;

            List<VoucherWord> voucherWordList = null;
            try
            {
                voucherWordList = result.ToList();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return voucherWordList;
        }
    }
}