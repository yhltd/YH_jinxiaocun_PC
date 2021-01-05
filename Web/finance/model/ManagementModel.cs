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
    /// 投资结余
    /// </summary>
    public class ManagementModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public ManagementModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 某一月投资结余
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public decimal getManagementMonth(string company, DateTime date)
        {

            var companyParam = new SqlParameter("@company", company);
            var dateParam = new SqlParameter("@data", date);
            string sql = "select ISNULL(sum(a.money_month), 0) as sum_month from (select expenditure,(select sum(s.money) from VoucherSummary as s where company = @company and year(voucherDate) = year(@date) and month(voucherDate) = month(@date) and s.expenditure = v.expenditure) as money_month from VoucherSummary as v where company = @company GROUP BY expenditure) as a where a.expenditure in (select managementExpenditure from ManagementExpenditure) or a.expenditure in (select managementIncome from ManagementIncome);";

            decimal managementMonth = 0;
            var result = fin.Database.SqlQuery<Charts>(sql, companyParam, dateParam);
            try
            {
                managementMonth = result.ToList()[0].sum_month;
            }
            catch (Exception ex)
            {
                managementMonth = 0;
                FinanceToError.getFinanceToError().toError();
            }
            return managementMonth;
        }

        /// <summary>
        /// 某一年投资结余
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public decimal getManagementYear(string company, DateTime date)
        {

            var companyParam = new SqlParameter("@company", company);
            var dateParam = new SqlParameter("@data", date);
            string sql = "select ISNULL(sum(a.money_year), 0) as sum_year from (select expenditure,(select sum(s.money) from VoucherSummary as s where company = @company and year(voucherDate) = year(@data) and s.expenditure = v.expenditure) as money_year from VoucherSummary as v where company = @company GROUP BY expenditure) as a where a.expenditure in (select managementExpenditure from ManagementExpenditure) or a.expenditure in (select managementIncome from ManagementIncome);";

            decimal managementYear = 0;
            var result = fin.Database.SqlQuery<Charts>(sql, companyParam, dateParam);
            try
            {
                managementYear = result.ToList()[0].sum_year;
            }
            catch (Exception ex)
            {
                managementYear = 0;
                FinanceToError.getFinanceToError().toError();
            }
            return managementYear;
        }
    }
}