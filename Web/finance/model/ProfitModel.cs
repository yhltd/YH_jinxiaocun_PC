using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.finance.entiy;
using Web.finance.util;

namespace Web.finance.model
{
    /// <author>
    /// dai
    /// </author>
    public class ProfitModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public ProfitModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pegeList的分页对象</returns>
        public FinancePage<Profit> getProfitList(FinancePage<Profit> financePage, string company)
        {

            var companyParam = new SqlParameter("@company", company);

            var minPageParam = new SqlParameter("@minPage", financePage.getMin());

            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());

            var directionsParam = new SqlParameter("@direction", financePage.selectParamsMap["direction"]);

            var monthParam = new SqlParameter("@month", financePage.selectParamsMap["month"]);

            var yearParam = new SqlParameter("@year", financePage.selectParamsMap["year"]);

            string sql = "select name,sum_month,sum_year from (select name,y.sum_month,y.sum_year,row_number() over(order by name) as rownum from Accounting as a,(SELECT code,isnull((SELECT sum(money) FROM VoucherSummary WHERE MONTH(voucherDate) = @month AND code = y.code),0) AS sum_month,isnull((SELECT sum(money) FROM VoucherSummary WHERE YEAR(voucherDate) = @year AND code = y.code),0) AS sum_year FROM VoucherSummary AS y WHERE company = 'admin' and YEAR(voucherDate) = @year GROUP BY y.code) as y where a.code = y.code and a.company = @company and a.direction = @direction) as t where t.rownum > @minPage and t.rownum < @maxPage";

            var result = fin.Database.SqlQuery<Profit>(sql, companyParam, minPageParam, maxPageParam, directionsParam, monthParam, yearParam);
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
        /// 获取总行数
        /// </summary>
        /// <param name="company">公司名</param>
        /// <returns>总条数</returns>
        public int getCount(FinancePage<Profit> financePage, string company)
        {
            var companyParam = new SqlParameter("@company", company);

            var directionsParam = new SqlParameter("@direction", financePage.selectParamsMap["direction"]);

            var monthParam = new SqlParameter("@month", financePage.selectParamsMap["month"]);

            var yearParam = new SqlParameter("@year", financePage.selectParamsMap["year"]);

            string sql = "select name,y.sum_month,y.sum_year from Accounting as a,(SELECT code,isnull((SELECT sum(money) FROM VoucherSummary WHERE MONTH(voucherDate) = @month AND code = y.code),0) AS sum_month,isnull((SELECT sum(money) FROM VoucherSummary WHERE YEAR(voucherDate) = @year AND code = y.code),0) AS sum_year FROM VoucherSummary AS y WHERE company = 'admin' and YEAR(voucherDate) = @year GROUP BY y.code) as y where a.code = y.code and a.company = @company and a.direction = @direction";

            var result = fin.Database.SqlQuery<Liabilities>(sql, companyParam, directionsParam, monthParam, yearParam);
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