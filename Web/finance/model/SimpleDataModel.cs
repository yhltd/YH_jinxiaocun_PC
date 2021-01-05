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
        public FinancePage<SimpleData> getSimpleDataList(FinancePage<SimpleData> financePage, string company)
        {

            var companyParam = new SqlParameter("@company", company);

            var minPageParam = new SqlParameter("@minPage", financePage.getMin());

            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());

            var projectParam = new SqlParameter("@project", financePage.selectParamsMap["project"]);

            string sql = "select a.id,a.company,a.project,a.receivable,a.receipts,a.cope,a.payment,a.accounting from (select row_number() over(order by id) as rownum,* from SimpleData where company = @company and project like '%'+@project+'%') as a where a.rownum > @minPage and a.rownum < @maxPage";

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
    }
}