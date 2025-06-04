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
        public decimal getManagementMonth(string company, string start_date,string stop_date)
        {

            if (start_date == "")
            {
                start_date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (stop_date == "")
            {
                stop_date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            var selectParam = new SqlParameter[]{
                new SqlParameter("@company", company),
                new SqlParameter("@start_date", start_date),
                new SqlParameter("@stop_date", stop_date),
            };
            string sql = "select ISNULL(sum(a.money_month), 0) as sum_month from (select expenditure,(select sum(s.money) from VoucherSummary as s where company = @company and year(voucherDate) >= year(@start_date) and year(voucherDate) <= year(@stop_date) and month(voucherDate) >= month(@start_date) and month(voucherDate) <= month(@stop_date) and s.expenditure = v.expenditure) as money_month from VoucherSummary as v where company = @company GROUP BY expenditure) as a where a.expenditure in (select managementExpenditure from ManagementExpenditure) or a.expenditure in (select managementIncome from ManagementIncome);";

            decimal managementMonth = 0;
            var result = fin.Database.SqlQuery<Charts>(sql, selectParam);
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
        public decimal getManagementYear(string company, string start_date,string stop_date)
        {

            if (start_date == "")
            {
                start_date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (stop_date == "")
            {
                stop_date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            var selectParam = new SqlParameter[]{
                new SqlParameter("@company", company),
                new SqlParameter("@start_date", start_date),
                new SqlParameter("@stop_date", stop_date),
            };
            string sql = "select ISNULL(sum(a.money_year), 0) as sum_year from (select expenditure,(select sum(s.money) from VoucherSummary as s where company = @company and year(voucherDate) >= year(@start_date) and year(voucherDate) <= year(@stop_date) and s.expenditure = v.expenditure) as money_year from VoucherSummary as v where company = @company GROUP BY expenditure) as a where a.expenditure in (select managementExpenditure from ManagementExpenditure) or a.expenditure in (select managementIncome from ManagementIncome);";

            decimal managementYear = 0;
            var result = fin.Database.SqlQuery<Charts>(sql, selectParam);
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