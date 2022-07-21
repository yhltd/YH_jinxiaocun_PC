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
    public class SimpleDataModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public SimpleDataModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pegeList的分页对象</returns>
        public FinancePage<SimpleData> getSimpleDataList(FinancePage<SimpleData> financePage, string company,string start_date,string stop_date)
        {

            var companyParam = new SqlParameter("@company", company);

            var minPageParam = new SqlParameter("@minPage", financePage.getMin());

            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());

            var projectParam = new SqlParameter("@project", financePage.selectParamsMap["project"]);

            string sql = "select a.id,a.company,a.insert_date,a.project,a.kehu,a.receivable,a.receipts,a.cope,a.payment,a.accounting,a.zhaiyao from (select row_number() over(order by id) as rownum,* from SimpleData where company = @company and project like '%'+@project+'%') as a where a.rownum > @minPage and a.rownum < @maxPage";

            if (start_date != "")
            {
                sql = sql + " and a.insert_date >= CONVERT(date,'" + start_date + "')";
            }

            if (stop_date != "")
            {
                sql = sql + " and a.insert_date <= CONVERT(date,'" + stop_date + "')";
            }

            var result = fin.Database.SqlQuery<SimpleData>(sql, companyParam, minPageParam, maxPageParam, projectParam);
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
        public int getCount(string company)
        {
            var result = from s in fin.SimpleData where s.company == company select s;
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
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pegeList的分页对象</returns>
        public List<SimpleData> getNianBaoByNian_shouru(string company, string ks, string js)
        {
            var companyParam = new SqlParameter("@company", company);

            var ksParam = new SqlParameter("@ks", ks);

            var jsParam = new SqlParameter("@js", js);

            string sql = "select a.id,a.zhaiyao,a.kehu,a.receivable,'' as project,'' as company,0.0 as receipts,0.0 as cope,0.0 as payment,'' as accounting, insert_date from (select id,zhaiyao,kehu,(convert(Decimal,receivable)-convert(Decimal,receipts)) as receivable,insert_date from SimpleData where company= @company and (convert(Decimal,receivable)-convert(Decimal,receipts))<>0 and insert_date>= @ks and insert_date<= @js) as a";

            var result = fin.Database.SqlQuery<SimpleData>(sql, companyParam, ksParam, jsParam);

            return result.ToList();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pegeList的分页对象</returns>
        public List<SimpleData> getNianBaoByNian_zhichu(string company, string ks, string js)
        {
            var companyParam = new SqlParameter("@company", company);

            var ksParam = new SqlParameter("@ks", ks);

            var jsParam = new SqlParameter("@js", js);

            string sql = "select a.id,a.zhaiyao,a.kehu,a.cope,'' as project,'' as company,0.0 as receipts,0.0 as receivable,0.0 as payment,'' as accounting,insert_date from (select id,zhaiyao,kehu,(convert(Decimal,cope)-convert(Decimal,payment)) as cope,insert_date from SimpleData where company= @company and (convert(Decimal,cope)-convert(Decimal,payment))<>0 and insert_date>= @ks and insert_date<= @js) as a";

            var result = fin.Database.SqlQuery<SimpleData>(sql, companyParam, ksParam, jsParam);

            return result.ToList();
        }

    }
}