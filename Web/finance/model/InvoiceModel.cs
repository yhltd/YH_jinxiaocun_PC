using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.finance.util;

namespace Web.finance.model
{
    public class InvoiceModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public InvoiceModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pegeList的分页对象</returns>
        public FinancePage<Invoice> getList(FinancePage<Invoice> financePage, string company, string ks, string js, string unit)
        {
            var companyParam = new SqlParameter("@company", company);
            var minPageParam = new SqlParameter("@minPage", financePage.getMin());
            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());
            var ksParam = new SqlParameter("@ks", ks);
            var jsParam = new SqlParameter("@js", js);
            var unitParam = new SqlParameter("@unit", unit);

            //string sql = "select a.id,a.company,a.insert_date,a.project,a.kehu,a.receivable,a.receipts,a.cope,a.payment,a.accounting,a.zhaiyao from (select row_number() over(order by id) as rownum,* from SimpleData where company = @company and project like '%'+@project+'%') as a where a.rownum > @minPage and a.rownum < @maxPage";
            string sql = "select a.id,a.company,a.type,a.riqi,a.zhaiyao,a.unit,a.invoice_type,a.invoice_no,a.jine,a.remarks  from (select row_number() over(order by id) as rownum,* from invoice where company = @company and unit like '%'+@unit+'%' and convert(date,riqi)>=@ks and convert(date,riqi)<=@js) as a where a.rownum > @minPage and a.rownum < @maxPage";
            var result = fin.Database.SqlQuery<Invoice>(sql, companyParam, minPageParam, maxPageParam, ksParam, jsParam, unitParam);
            
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
            var result = from s in fin.Invoice where s.company == company select s;
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
