using System;
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
    public class AccountingModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public AccountingModel() 
        {
            fin = new FinanceEntities();
        }

        public FinancePage<AccountingItem> getList(FinancePage<AccountingItem> financePage, string company, int classId)
        {
            //类别
            var classParam = new SqlParameter("@class", classId);
            //公司
            var companyParam = new SqlParameter("@company", company);
            //查询最小行号
            var minPageParam = new SqlParameter("@minPageParam", financePage.getMin());
            //查询最大行号
            var maxPageParam = new SqlParameter("@maxPageParam", financePage.getMax());

            string sql = "select (case len(code) when 4 then 'I' when 6 then 'II' when 8 then 'III' else '' end) as grade,*,isnull((SELECT SUM(money) FROM VoucherSummary WHERE VoucherSummary.code = a.code),0) as money,isnull((select top 1 name from Accounting as ac where ac.code = LEFT(a.code,4)),'') + isnull((select top 1 '-'+name from Accounting as ac where ac.code = LEFT(a.code,6) and ac.code != LEFT(a.code,4)),'') + isnull((select top 1 '-'+name from Accounting as ac where ac.code = LEFT(a.code,8) and ac.code != LEFT(a.code,6)),'') as fullName from (select *,ROW_NUMBER() over(order by LEN(code),id) as rownum from (select * from (SELECT *,LEFT(code, 1) AS class from Accounting) as t where t.class = @class and t.company = @company) as c )as a where a.rownum > @minPageParam and a.rownum < @maxPageParam";

            var result = fin.Database.SqlQuery<AccountingItem>(sql, classParam, companyParam, minPageParam, maxPageParam);
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

        public FinancePage<AccountingItem> getList2(FinancePage<AccountingItem> financePage, string company, int classId,string code)
        {
            //类别
            var classParam = new SqlParameter("@class", classId);
            //公司
            var companyParam = new SqlParameter("@company", company);
            //查询最小行号
            var minPageParam = new SqlParameter("@minPageParam", financePage.getMin());
            //查询最大行号
            var maxPageParam = new SqlParameter("@maxPageParam", financePage.getMax());

            var kemudaima = new SqlParameter("@code", code);

            string sql = "select (case len(code) when 4 then 'I' when 6 then 'II' when 8 then 'III' else '' end) as grade,*,isnull((SELECT SUM(money) FROM VoucherSummary WHERE VoucherSummary.code = a.code),0) as money,isnull((select top 1 name from Accounting as ac where ac.code = LEFT(a.code,4)),'') + isnull((select top 1 '-'+name from Accounting as ac where ac.code = LEFT(a.code,6) and ac.code != LEFT(a.code,4)),'') + isnull((select top 1 '-'+name from Accounting as ac where ac.code = LEFT(a.code,8) and ac.code != LEFT(a.code,6)),'') as fullName from (select *,ROW_NUMBER() over(order by LEN(code),id) as rownum from (select * from (SELECT *,LEFT(code, 1) AS class from Accounting) as t where t.class = @class and t.company = @company) as c )as a where a.rownum > @minPageParam and a.rownum < @maxPageParam";

            if (code != "")
            {
                sql = sql + " and code like '%" + code + "%'";
            }

            var result = fin.Database.SqlQuery<AccountingItem>(sql, classParam, companyParam, minPageParam, maxPageParam);
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


        public int getPageCount(string company,int classId) {
            //类别
            var classParam = new SqlParameter("@class", classId);
            //公司
            var companyParam = new SqlParameter("@company", company);

            string sql = "select count(*) as id from (SELECT *,LEFT(code, 1) AS class from Accounting as ac) as t where t.class = @class and t.company = @company";

            var result = fin.Database.SqlQuery<AccountingItem>(sql, classParam, companyParam);
            int idCount = 0;
            try
            {
                idCount = result.FirstOrDefault().id;
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return idCount;
        }


        public int updAccounting(Accounting accounting) {
            //新的实体类添加到上下文
            fin.Accounting.Attach(accounting);
            //手动修改状态
            fin.Entry<Accounting>(accounting).State = EntityState.Modified;
            int result = 0;
            try
            {
                //保存修改
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }


        public Accounting getAccounting(int id) {
            Accounting accounting = null;
            try
            {
                accounting = fin.Accounting.Find(id);
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return accounting;
        }

        public int delAccounting(int id)
        {
            //删除
            fin.Accounting.Remove(this.getAccounting(id));
            int result = 0;
            try
            {
                //保存修改
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }

        public Charts getLoadAndBorrword(string company) {
            //公司
            var companyParam = new SqlParameter("@company", company);

            string sql = "select sum([load]) as sum_load,sum(borrowed) as sum_borrowed from Accounting where company = @company";
            
            var result = fin.Database.SqlQuery<Charts>(sql,  companyParam);
            Charts charts = null;
            try
            {
                charts = result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return charts;
        }

        public List<Accounting> getList(string company, int classId, int grade,int code) {
            //公司
            var companyParam = new SqlParameter("@company", company);
            //公司
            var classParam = new SqlParameter("@classId", classId);
            //公司
            var gradeParam = new SqlParameter("@grade", grade);
            //公司
            var parentCodeParam = new SqlParameter("@code", code);
            
            string codeSql = "";
            if (code > 0) {
                codeSql = " and left(code," + (grade - 2) + ") = @code";
            }

            string sql = "select * from Accounting where company = @company and left(code,1) = @classId and len(code) = @grade" + codeSql;
            var result = fin.Database.SqlQuery<Accounting>(sql, companyParam, classParam, gradeParam, parentCodeParam);
            List<Accounting> accountingList = null;
            try
            {
                accountingList = result.ToList();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return accountingList;
        }


        public int newAccounting(Accounting accounting) {
            fin.Accounting.Add(accounting);
            int result = 0;
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