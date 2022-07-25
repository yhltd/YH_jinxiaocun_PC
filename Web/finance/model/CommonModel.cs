using SDZdb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    public class CommonModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public CommonModel()
        {
            fin = new FinanceEntities();
        }

        //年初余额
        public List<Charts> getAccounting(string company)
        {
            var selectParam = new SqlParameter("@company", company);
            string sql = "select sum(a.load) as sum_load,sum(a.borrowed) as sum_borrowed from(select code,load,borrowed,LEFT(code,1) as class from Accounting where company = @company) as a GROUP BY a.class;";
            var result = fin.Database.SqlQuery<Charts>(sql, selectParam);
            List<Charts> list = null;
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

        //凭证金额
        public List<Charts> getSummary(string company,string start_date,string stop_date)
        {
            if (start_date == "")
            {
                start_date = "1900-01-01";
            }
            if (stop_date == "")
            {
                stop_date = "2100-12-31";
            }
            var selectParam = new SqlParameter[]{
                new SqlParameter("@company", company),
                new SqlParameter("@start_date", start_date),
                new SqlParameter("@stop_date", stop_date),
            };
            
            string sql = "select isnull(sum(v.money),0) as [sum],a.direction from VoucherSummary as v,Accounting as a where a.company = @company and v.company = @company and a.code = v.code and v.voucherDate >= @start_date and v.voucherDate <= @stop_date GROUP BY a.direction";

            

            var result = fin.Database.SqlQuery<Charts>(sql, selectParam);
            List<Charts> list = null;
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

        //科目余额
        public List<Charts> getAccountBalance(string company, string start_date, string stop_date)
        {
            if (start_date == "")
            {
                start_date = "1900-01-01";
            }
            if (stop_date == "")
            {
                stop_date = "2100-12-31";
            }
            var selectParam = new SqlParameter[]{
                new SqlParameter("@company", company),
                new SqlParameter("@start_date", start_date),
                new SqlParameter("@stop_date", stop_date),
            };
            string sql = "SELECT sum(a.load) +ISNULL(sum(v.money), 0) as sum_load,sum(a.borrowed) as sum_borrowed from Accounting as a LEFT JOIN VoucherSummary as v on v.code = a.code where a.company = @company  GROUP BY left(a.code,1)";
            var result = fin.Database.SqlQuery<Charts>(sql, selectParam);
            List<Charts> list = null;
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

        //资产负债
        public List<Charts> getLiabilities(string company,string start_date,string stop_date)
        {
            if (start_date == "")
            {
                start_date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            var selectParam = new SqlParameter[]{
                new SqlParameter("@company", company),
                new SqlParameter("@start_date", start_date),
            };
            string sql = "select isnull(sum(a.sum_load),0) as sum_load,isnull(sum(sum_borrowed),0) as sum_borrowed,isnull(sum(a.sum_money),0) as sum_money from (select v.company,sum(load) as sum_load,sum(borrowed) as sum_borrowed,sum(ISNULL(v.money, 0)) as sum_money,a.code from Accounting as a left join VoucherSummary as v on a.code = v.code WHERE a.company = @company and year(v.voucherDate) = year(@start_date) GROUP BY a.code,a.name,v.company) as a  where a.company = @company or a.company is null group by left(a.code,1) HAVING left(a.code,1) in (1,2,3)";

            List<Charts> list = new List<Charts>();
            var result = fin.Database.SqlQuery<Charts>(sql, selectParam);
            try
            {
                list = result.ToList();
            }
            catch (Exception ex)
            {
                list = null;
                FinanceToError.getFinanceToError().toError();
            }
            return list;
        }

        //利润合计
        public List<Charts> getProfit(string company,string start_date,string stop_date) {
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
            string sql = "SELECT isnull( SUM ( a.sum_month ), 0 ) AS sum_month,isnull( SUM ( a.sum_year ), 0 ) AS sum_year FROM(SELECT y.sum_month,y.sum_year,a.direction FROM Accounting AS a,(SELECT code,(SELECT SUM( money ) FROM VoucherSummary WHERE MONTH ( voucherDate ) >= MONTH ( @start_date ) AND MONTH ( voucherDate ) <= MONTH ( @stop_date ) AND code = y.code ) AS sum_month,(SELECT SUM( money ) FROM VoucherSummary WHERE YEAR ( voucherDate ) >= YEAR ( @start_date ) AND YEAR ( voucherDate ) <= YEAR ( @stop_date ) AND code = y.code ) AS sum_year FROM VoucherSummary AS y WHERE company = @company AND YEAR ( voucherDate ) >= YEAR ( @start_date ) AND YEAR ( voucherDate ) <= YEAR ( @stop_date ) GROUP BY y.code ) AS y WHERE a.code = y.code AND a.company = @company AND a.direction IN ( 0, 1)) AS a GROUP BY a.direction";

            List<Charts> list = new List<Charts>();
            var result = fin.Database.SqlQuery<Charts>(sql, selectParam);
            try
            {
                list = result.ToList();
            }
            catch (Exception ex)
            {
                list = null;
                FinanceToError.getFinanceToError().toError();
            }
            return list;
        }


        /// <summary>
        /// 获取泛型类的集合
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="entity">泛型对象</param>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <param name="columnName">特殊字段处理</param>
        /// <returns>有pageList的分页对象</returns>
        public FinancePage<T> getComList<T>(T entity, FinancePage<T> financePage, string company, string columnName)
        {

            var companyParam = new SqlParameter("@company", company);
            var maxPageParam = new SqlParameter("@maxPage", financePage.getMax());
            var minPageParam = new SqlParameter("@minPage", financePage.getMin());


            string sqlString = fin.Set(entity.GetType()).ToString();
            string sql = "select l.*,l." + columnName + " as " + columnName + "1 from (select ROW_NUMBER() over(order by id) as rownum,a.* from (" + sqlString + ") as a) as l where l.rownum > @minPage and l.rownum < @maxPage and l.company = @company";

            var result = fin.Set(entity.GetType()).SqlQuery(sql, companyParam, maxPageParam, minPageParam);
            try
            {
                var selectList = result.GetEnumerator();
                while (selectList.MoveNext()) 
                {
                    financePage.pageList.Add((T)selectList.Current);
                }
            }
            catch(Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return financePage;
        }

        /// <summary>
        /// 获取一个泛型类型的集合总行数
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="entity">泛型类型对象</param>
        /// <param name="company">公司</param>
        /// <returns>id为总行数的泛型类型对象</returns>
        public int getComTotal<T>(T entity, string company,string columnName)
        {
            int total = 0;
            var companyParam = new SqlParameter("@company", company);

            string sqlString = fin.Set(entity.GetType()).ToString();
            string sql = "select l.*,l." + columnName + " as " + columnName + "1 from (" + sqlString + ") as l where l.company = @company";

            var result = fin.Set(entity.GetType()).SqlQuery(sql, companyParam);
            try
            {
                var selectList = result.GetEnumerator();
                while (selectList.MoveNext())
                {
                    total++;
                }
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return total;
        }


        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="entity">泛型类型对象</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        public T comFind<T>(T entity, int id)
        {
            try
            {
                var result = fin.Set(entity.GetType()).Find(id);
                entity = (T)result;
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return entity;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="entity">泛型类型对象</param>
        /// <returns>影响行数</returns>
        public int comDel<T>(T entity) {
            int result = 0;
            fin.Set(entity.GetType()).Remove(entity);
            try
            {
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">以修改的泛型类型对象</param>
        /// <returns>影响行数</returns>
        public int comUpd<T>(T entity) where T : class
        {
            int result = 0;
            //新的实体类添加到上下文
            fin.Set(entity.GetType()).Attach(entity);
            //手动修改状态
            fin.Entry(entity).State = EntityState.Modified;
            try
            {
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">泛型类型对象</param>
        /// <returns>影响行数</returns>
        public int comAdd<T>(T entity) {
            int result = 0;

            fin.Set(entity.GetType()).Add(entity);
            try
            {
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }


        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<AccountingPeizhi> getAccountingPeizhi(string company)
        {
            var result = from u in fin.AccountingPeizhi where u.company == company select u;

            List<AccountingPeizhi> list = null;
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
        /// 获取集合
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<KehuPeizhi> getKehuPeizhi(string company)
        {
            var result = from u in fin.KehuPeizhi where u.company == company select u;

            List<KehuPeizhi> list = null;
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
        /// 获取集合
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<InvoicePeizhi> getInvoicePeizhi(string company)
        {
            var result = from u in fin.InvoicePeizhi where u.company == company select u;

            List<InvoicePeizhi> list = null;
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
        /// 获取集合
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<shoufubaobiao> getYingShou(string company,string kehu,string ks,string js)
        {
            var companyParam = new SqlParameter("@company", company);

            var kehuParam = new SqlParameter("@kehu", kehu);

            var ksParam = new SqlParameter("@ks", ks);

            var jsParam = new SqlParameter("@js", js);

            string sql = "select kehu,project,zhaiyao,receivable as jine1 from SimpleData where company=@company and kehu=@kehu and insert_date>=@ks and insert_date<=@js";

            var result = fin.Database.SqlQuery<shoufubaobiao>(sql, companyParam, kehuParam, ksParam, jsParam);

            return result.ToList();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<shoufubaobiao> getXiaoXiang(string company, string kehu,string ks,string js)
        {
            var companyParam = new SqlParameter("@company", company);

            var kehuParam = new SqlParameter("@kehu", kehu);

            var ksParam = new SqlParameter("@ks", ks);

            var jsParam = new SqlParameter("@js", js);

            string sql = "select unit,invoice_type,invoice_no,jine as jine2 from invoice where company=@company and unit=@kehu and type='销项发票' and convert(date,riqi)>=@ks and convert(date,riqi)<=@js ";

            var result = fin.Database.SqlQuery<shoufubaobiao>(sql, companyParam, kehuParam, ksParam, jsParam);

            return result.ToList();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<shoufubaobiao> getYingFu(string company, string kehu, string ks, string js)
        {
            var companyParam = new SqlParameter("@company", company);

            var kehuParam = new SqlParameter("@kehu", kehu);

            var ksParam = new SqlParameter("@ks", ks);

            var jsParam = new SqlParameter("@js", js);

            string sql = "select kehu,project,zhaiyao,cope as jine1 from SimpleData where company=@company and kehu=@kehu and insert_date>=@ks and insert_date<=@js";

            var result = fin.Database.SqlQuery<shoufubaobiao>(sql, companyParam, kehuParam, ksParam, jsParam);

            return result.ToList();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<shoufubaobiao> getJinXiang(string company, string kehu, string ks, string js)
        {
            var companyParam = new SqlParameter("@company", company);

            var kehuParam = new SqlParameter("@kehu", kehu);

            var ksParam = new SqlParameter("@ks", ks);

            var jsParam = new SqlParameter("@js", js);

            string sql = "select unit,invoice_type,invoice_no,jine as jine2 from invoice where company=@company and unit=@kehu and type='进项发票' and convert(date,riqi)>=@ks and convert(date,riqi)<=@js ";

            var result = fin.Database.SqlQuery<shoufubaobiao>(sql, companyParam, kehuParam, ksParam, jsParam);

            return result.ToList();
        }



    }
}
