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
        public List<Charts> getSummary(string company)
        {
            var selectParam = new SqlParameter("@company", company);
            string sql = "select isnull(sum(v.money),0) as [sum],a.direction from VoucherSummary as v,Accounting as a where a.company = @company and v.company = @company and a.code = v.code GROUP BY a.direction";

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
        public List<Charts> getAccountBalance(string company)
        {
            var selectParam = new SqlParameter("@company", company);
            string sql = "SELECT sum(a.load) +ISNULL(sum(v.money), 0) as sum_load,sum(a.borrowed) as sum_borrowed from Accounting as a LEFT JOIN VoucherSummary as v on v.code = a.code where a.company = @company GROUP BY left(a.code,1)";
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

        //现金流量
        public List<Charts> getLiabilities(string company)
        {
            var selectParam = new SqlParameter("@company", company);

            string sql = "select isnull(sum(a.sum_load),0) as sum_load,isnull(sum(sum_borrowed),0) as sum_borrowed,isnull(sum(a.sum_money),0) as sum_money from (select v.company,sum(load) as sum_load,sum(borrowed) as sum_borrowed,sum(ISNULL(v.money, 0)) as sum_money,a.code from Accounting as a left join VoucherSummary as v on a.code = v.code WHERE a.company = @company and year(v.voucherDate) = year(getDate()) GROUP BY a.code,a.name,v.company) as a  where a.company = @company or a.company is null group by left(a.code,1) HAVING left(a.code,1) in (1,2,3)";

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
        public List<Charts> getProfit(string company) {
            var selectParam = new SqlParameter("@company", company);
            string sql = "select isnull(sum(a.sum_month),0) as sum_month,isnull(sum(a.sum_year),0) as sum_year from (select y.sum_month,y.sum_year,a.direction from Accounting as a,(SELECT code,(SELECT sum(money) FROM VoucherSummary WHERE MONTH(voucherDate) = MONTH(GETDATE()) AND code = y.code) AS sum_month,(SELECT sum(money) FROM VoucherSummary WHERE YEAR(voucherDate) = YEAR(GETDATE()) AND code = y.code) AS sum_year FROM VoucherSummary AS y WHERE company = @company and YEAR(voucherDate) = YEAR(GETDATE()) GROUP BY y.code) as y where a.code = y.code and a.company = @company and a.direction in (0,1)) as a GROUP BY a.direction";

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
    }
}
