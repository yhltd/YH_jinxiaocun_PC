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
    public class VoucherSummaryModel
    {

        //数据库模型
        private FinanceEntities fin;

        //实例化
        public VoucherSummaryModel() 
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
            var result = from u in fin.VoucherSummary where u.company == company select u;

            int count = 0;
            try {
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
        public FinancePage<VoucherSummaryItem> getList(FinancePage<VoucherSummaryItem> financePage, string company)         {
            //年
            string start_date = financePage.selectParamsMap["start_date"];
            //月
            string stop_date = financePage.selectParamsMap["stop_date"];

            var @params = new SqlParameter[6]{
                //公司
                new SqlParameter("@company", company),
                //查询最小行数
                new SqlParameter("@minPage", financePage.getMin()),
                //查询最大行数
                new SqlParameter("@maxPage", financePage.getMax()),
                //凭证字
                new SqlParameter("@word", financePage.selectParamsMap["word"]),
                //年
                new SqlParameter("@start_date", start_date),
                //月
                new SqlParameter("@stop_date", stop_date)
            };

            //string sql = "select * from (select isnull((select name from Accounting where code = LEFT (vs.code, 4)),'')+isnull((select top 1 '-'+name from Accounting where code = LEFT (vs.code, 6) and code != LEFT (vs.code, 4)),'')+isnull((select top 1 '-'+name from Accounting where code = LEFT (vs.code, 8) and code != LEFT (vs.code, 6)),'') as fullName,vs.id,vs.word,vs.[no],voucherDate,vs.abstract,vs.code,vs.department,vs.expenditure,vs.note,vs.man,ac.name,isnull(ac.load,0) as load,isnull(ac.borrowed,0) as borrowed,vs.money,vs.real,ROW_NUMBER() over(order by vs.id) rownum from VoucherSummary as vs left join Accounting as ac on vs.code = ac.code and ac.company = @company where vs.company = @company) t where t.rownum > @minPage and t.rownum < @maxPage and t.word like '%'+@word+'%'";
            //string sql = "select * from (select isnull((select name from Accounting where code = LEFT (CONVERT(varchar(10), vs.code), 4)),'')+isnull((select top 1 '-'+name from Accounting where code = LEFT (CONVERT(varchar(10), vs.code), 6) and code != LEFT (CONVERT(varchar(10), vs.code), 4)),'')+isnull((select top 1 '-'+name from Accounting where code = LEFT (CONVERT(varchar(10), vs.code), 8) and code != LEFT (CONVERT(varchar(10), vs.code), 6)),'') as fullName,vs.id,vs.word,vs.[no],voucherDate,vs.abstract,vs.code,vs.department,vs.expenditure,vs.note,vs.man,ac.name,isnull(ac.load,0) as load,isnull(ac.borrowed,0) as borrowed,vs.money,vs.real,ROW_NUMBER() over(order by vs.id) rownum from VoucherSummary as vs left join Accounting as ac on vs.code = ac.code and ac.company = @company where vs.company = @company) t where t.rownum > @minPage and t.rownum < @maxPage and t.word like '%'+@word+'%'";
            string sql = @"select * from (
    select 
        isnull((select TOP 1 name from Accounting where code = CONVERT(int, LEFT(CONVERT(varchar(10), vs.code), 4))),'')
        +isnull((select TOP 1 '-'+name from Accounting where code = CONVERT(int, LEFT(CONVERT(varchar(10), vs.code), 6)) and code != CONVERT(int, LEFT(CONVERT(varchar(10), vs.code), 4))),'')
        +isnull((select TOP 1 '-'+name from Accounting where code = CONVERT(int, LEFT(CONVERT(varchar(10), vs.code), 8)) and code != CONVERT(int, LEFT(CONVERT(varchar(10), vs.code), 6))),'') as fullName,
        vs.id,vs.word,vs.[no],voucherDate,vs.abstract,vs.code,vs.department,vs.expenditure,vs.note,vs.man,
        ac.name,isnull(ac.load,0) as load,isnull(ac.borrowed,0) as borrowed,vs.money,vs.real,
        ROW_NUMBER() over(order by vs.id) rownum 
    from VoucherSummary as vs 
    left join Accounting as ac on vs.code = ac.code and ac.company = @company 
    where vs.company = @company
) t 
where t.rownum > @minPage and t.rownum < @maxPage 
and t.word like '%'+@word+'%'";

            if (!start_date.Equals(string.Empty))
            {
                sql += " and t.voucherDate >= @start_date";
            }
            if (!stop_date.Equals(string.Empty))
            {
                sql += " and t.voucherDate <= @stop_date";
            }

            var result = fin.Database.SqlQuery<VoucherSummaryItem>(sql, @params);
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


    }
}