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
    public class FlowModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public FlowModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pegeList的分页对象</returns>
        public FinancePage<Flow> getFlowList(FinancePage<Flow> financePage, string company)
        {

            var companyParam = new SqlParameter("@company", company);

            var minPageParam = new SqlParameter("@minPage", financePage.getMin());

            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());

            var start_date = new SqlParameter("@start_date", financePage.selectParamsMap["start_date"]);

            var stop_date = new SqlParameter("@stop_date", financePage.selectParamsMap["stop_date"]);

            //string sql = "select all_.expenditure,all_.money_month,all_.money_year from (select row_number() over(order by expenditure) as rownum,expenditure,isnull((select sum(s.money) from VoucherSummary as s where company = @company and year(voucherDate) = @year and month(voucherDate) = @month and s.expenditure = v.expenditure),0) as money_month,isnull((select sum(s.money) from VoucherSummary as s where company = @company and year(voucherDate) = @year and s.expenditure = v.expenditure),0) as money_year from VoucherSummary as v where company = @company GROUP BY expenditure) as all_ where all_.rownum > @minPage and all_.rownum < @maxPage";
            string sql = "select all_.expenditure,all_.money_month,all_.money_year from (select row_number() over(order by expenditure) as rownum,expenditure,isnull((select sum(s.money) from VoucherSummary as s where company = @company and voucherDate >= CONVERT(date,@start_date) and voucherDate <= CONVERT(date,@stop_date) and s.expenditure = v.expenditure),0) as money_month,isnull((select sum(s.money) from VoucherSummary as s where company = @company and year(voucherDate) = year(CONVERT(date,@start_date)) and s.expenditure = v.expenditure),0) as money_year from VoucherSummary as v where company = @company GROUP BY expenditure) as all_ where all_.rownum > @minPage and all_.rownum < @maxPage";
            var result = fin.Database.SqlQuery<Flow>(sql, companyParam, minPageParam, maxPageParam, start_date, stop_date);
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
        public int getCount(string company) {

            var result = from u in fin.VoucherSummary where u.company == company group u by u.expenditure;

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