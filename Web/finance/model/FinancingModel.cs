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
    /// <summary>
    /// 经营结余
    /// </summary>
    public class FinancingModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public FinancingModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 某一月经营结余
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public decimal getFinancingMonth(string company, DateTime date)
        {

            var companyParam = new SqlParameter("@company", company);
            var dateParam = new SqlParameter("@data", date);
            string sql = "select ISNULL(sum(a.money_month), 0) as sum_month from (select expenditure,(select sum(s.money) from VoucherSummary as s where company = @company and year(voucherDate) = year(@date) and month(voucherDate) = month(@date) and s.expenditure = v.expenditure) as money_month from VoucherSummary as v where company = @company GROUP BY expenditure) as a where a.expenditure in (select financingExpenditure from FinancingExpenditure) or a.expenditure in (select financingIncome from FinancingIncome)";

            decimal financingMonth = 0;
            var result = fin.Database.SqlQuery<Charts>(sql, companyParam, dateParam);
            try
            {
                financingMonth = result.ToList()[0].sum_month;
            }
            catch (Exception ex)
            {
                financingMonth = 0;
                FinanceToError.getFinanceToError().toError();
            }
            return financingMonth;
        }

        /// <summary>
        /// 某一年经营结余
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public decimal getFinancingYear(string company, DateTime date)
        {

            var companyParam = new SqlParameter("@company", company);
            var dateParam = new SqlParameter("@data", date);
            string sql = "select ISNULL(sum(a.money_year), 0) as sum_year from (select expenditure,(select sum(s.money) from VoucherSummary as s where company = @company and year(voucherDate) = year(@data) and s.expenditure = v.expenditure) as money_year from VoucherSummary as v where company = @company GROUP BY expenditure) as a where a.expenditure in (select financingExpenditure from FinancingExpenditure) or a.expenditure in (select financingIncome from FinancingIncome)";

            decimal financingYear = 0;
            var result = fin.Database.SqlQuery<Charts>(sql, companyParam, dateParam);
            try
            {
                financingYear = result.ToList()[0].sum_year;
            }
            catch (Exception ex)
            {
                financingYear = 0;
                FinanceToError.getFinanceToError().toError();
            }
            return financingYear;
        }
    }
}