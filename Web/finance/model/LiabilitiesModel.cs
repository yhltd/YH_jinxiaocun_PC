﻿using System;
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
    public class LiabilitiesModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public LiabilitiesModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pegeList的分页对象</returns>
        public FinancePage<Liabilities> getLiabilitiesList(FinancePage<Liabilities> financePage, string company)
        {

            var companyParam = new SqlParameter("@company", company);

            var minPageParam = new SqlParameter("@minPage", financePage.getMin());

            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());

            var classParam = new SqlParameter("@class", financePage.selectParamsMap["classId"]);

            var start_date = new SqlParameter("@start_date", financePage.selectParamsMap["start_date"]);

            var stop_date = new SqlParameter("@stop_date", financePage.selectParamsMap["stop_date"]);

            //string sql = "select all_.name,all_.load,all_.borrowed,all_.money from (select row_number() over(order by a.name) as rownum,a.name,sum(a.load) as load,sum(a.borrowed) as borrowed,isnull(sum(v.money),0) as money from Accounting as a left join VoucherSummary as v on a.code = v.code and v.company = @company and year(v.voucherDate) = @year and month(v.voucherDate) = @month where a.company = @company and left(a.code,1) = @class group by a.name,left(a.code,1)) as all_ where all_.rownum > @minPage and all_.rownum < @maxPage";
            string sql = "select name,[load],borrowed,CONVERT(Decimal,0) as money from (select row_number() over(order by a.name) as rownum, a.name,left(a.code,1) as class,v.company,(CASE @class WHEN 1 THEN sum(load-borrowed) ELSE sum(borrowed-load) END) as [load],(CASE @class WHEN 1 THEN sum([load]-borrowed+ISNULL(v.money, 0)) ELSE sum(borrowed-[load]+ISNULL(v.money, 0)) END) as borrowed from Accounting as a left join VoucherSummary as v on a.code = v.code WHERE left(a.code,1) = @class and a.company = @company and v.voucherDate >= convert(date,@start_date) and v.voucherDate <= convert(date,@stop_date) GROUP BY a.code,a.name,v.company) as a where (a.company = @company or a.company is null) and a.rownum > @minPage and a.rownum < @maxPage";
            //string sql = "select all_.name,all_.load,all_.borrowed,all_.money from (select row_number() over(order by a.name) as rownum,a.name,sum(a.load) as load,sum(a.borrowed) as borrowed,isnull(sum(v.money),0) as money from Accounting as a left join VoucherSummary as v on a.code = v.code and v.company = @company and v.voucherDate >= CONVERT(date,@start_date) and v.voucherDate <= CONVERT(date,@stop_date) where a.company = @company and left(a.code,1) = 1 group by a.name,left(a.code,1)) as all_ where all_.rownum > @minPage and all_.rownum < @maxPage";
            var result = fin.Database.SqlQuery<Liabilities>(sql, companyParam, minPageParam, maxPageParam, classParam, start_date, stop_date);
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
        public int getCount(string company,int classId)
        {
            var companyParam = new SqlParameter("@company", company);

            var classParam = new SqlParameter("@class", classId);

            string sql = "select a.name,sum(a.load) as load,sum(a.borrowed) as borrowed,isnull(sum(v.money),0) as money from Accounting as a left join VoucherSummary as v on a.code = v.code and v.company = @company where a.company = @company and left(a.code,1) = @class group by a.name,left(a.code,1)";

            var result = fin.Database.SqlQuery<Liabilities>(sql, companyParam, classParam);
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