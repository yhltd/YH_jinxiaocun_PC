using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.finance.util;

namespace Web.finance.model
{
    /// <author>
    /// dai
    /// </author>
    public class SimpleAccountingModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public SimpleAccountingModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pegeList的分页对象</returns>
        public FinancePage<SimpleAccounting> getList(FinancePage<SimpleAccounting> financePage,string company) {

            var companyParam = new SqlParameter("@company", company);

            var minPageParam = new SqlParameter("@minPage", financePage.getMin());

            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());

            var accountingParam = new SqlParameter("@accounting", financePage.selectParamsMap["accounting"]);

            string sql = "select a.id,a.accounting,a.company from (select row_number() over(order by id) as rownum,* from SimpleAccounting where company = @company and accounting like '%'+@accounting+'%') as a where a.rownum > @minPage and a.rownum < @maxPage";

            var result = fin.Database.SqlQuery<SimpleAccounting>(sql, companyParam, minPageParam, maxPageParam, accountingParam);
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
        /// 获取集合
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<SimpleAccounting> getList(string company) {
            var result = from u in fin.SimpleAccounting where u.company == company select u;

            List<SimpleAccounting> list = null;
            try
            {
                list = result.ToList();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return list;
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="company">公司名</param>
        /// <returns></returns>
        public int getCount(string company) {
            var result = from u in fin.SimpleAccounting where u.company == company select u;

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
    }
}