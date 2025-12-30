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
        public FinancePage<SimpleAccountingSummary> getList(FinancePage<SimpleAccountingSummary> financePage, string company)
        {
            var companyParam = new SqlParameter("@company", company);
            var minPageParam = new SqlParameter("@minPage", financePage.getMin());
            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());
            var accountingParam = new SqlParameter("@accounting", financePage.selectParamsMap["accounting"]);
            
            //string sql = "select a.id,a.accounting,a.company from (select row_number() over(order by id) as rownum,* from SimpleAccounting where company = @company and accounting like '%'+@accounting+'%') as a where a.rownum > @minPage and a.rownum < @maxPage";
            string sql = "select * from (select row_number() over(order by a.accounting desc) as ROW_ID,a.id,a.accounting,ISNULL(sum(d.receivable), 0) as receivable,ISNULL(sum(d.receipts), 0) as receipts,ISNULL(sum(d.receivable-d.receipts), 0) as notget1,ISNULL(sum(d.cope), 0) as cope,ISNULL(sum(d.payment), 0) as payment,ISNULL(sum(d.cope-d.payment), 0) as notget2 from SimpleAccounting as a LEFT JOIN SimpleData as d on a.accounting = d.accounting where a.company = @company GROUP BY a.accounting,a.company,a.id) as a where  a.ROW_ID > @minPage and a.ROW_ID < @maxPage";


            var result = fin.Database.SqlQuery<SimpleAccountingSummary>(sql, companyParam, minPageParam, maxPageParam);
            
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

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pegeList的分页对象</returns>
        public List<SimpleData> getZongZhang(string company, string kehu, string project)
        {
            var companyParam = new SqlParameter("@company", company);

            var kehuParam = new SqlParameter("@kehu", kehu);

            var projectParam = new SqlParameter("@project", project);

            string sql = "select '' as company,kehu,project,sum(receivable) as receivable,sum(nashuijine) as nashuijine,sum(yijiaoshuijine) as yijiaoshuijine,sum(receipts) as receipts,sum(cope) as cope,sum(payment) as payment,1 as id,'' as accounting,null as insert_date,'' as zhaiyao from SimpleData where company=@company and kehu like '%'+@kehu+'%' and project like '%'+@project+'%' group by kehu,project";

            var result = fin.Database.SqlQuery<SimpleData>(sql, companyParam, kehuParam, projectParam);

            return result.ToList();
        }



    }
}