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
    public class DepartmentModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public DepartmentModel() 
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="department">部门对象</param>
        /// <returns>影响行数</returns>
        public int newDepartment(Department department) {
            fin.Department.Add(department);
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

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="department">部门对象</param>
        /// <returns>影响行数</returns>
        public int delDepartment(Department department)
        {
            fin.Department.Remove(department);
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

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id">部门id</param>
        /// <returns>影响行数</returns>
        public int delDepartment(int id)
        {
            fin.Department.Remove(this.findDepartment(id));
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

        /// <summary>
        /// 获取部门对象
        /// </summary>
        /// <param name="id">部门id</param>
        /// <returns>部门对象</returns>
        public Department findDepartment(int id)
        {
            Department deopartment = null;
            try
            {
                deopartment = fin.Department.Find(id);
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return deopartment;
        }

        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="department">新的部门对象</param>
        /// <returns>影响行数</returns>
        public int updDepartment(Department department) {
            //新的实体类添加到上下文
            fin.Department.Attach(department);
            //手动修改状态
            fin.Entry<Department>(department).State = EntityState.Modified;
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

        /// <summary>
        /// 查询部门list
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="company">公司名</param>
        /// <returns>有pageList的分页对象</returns>
        public FinancePage<DepartmentItem> getList(FinancePage<DepartmentItem> financePage, string company) {
            //公司
            var companyParam = new SqlParameter("@company", company);
            //查询最小行号
            var minPageParam = new SqlParameter("@minPageParam", financePage.getMin());
            //查询最大行号
            var maxPageParam = new SqlParameter("@maxPageParam", financePage.getMax());

            string sql = "select a.id,a.rownum,a.department as department1,a.man,a.company from (select *,row_number() over(order by id) as rownum from Department where company = @company) as a where a.rownum > @minPageParam and a.rownum < @maxPageParam";
            var result = fin.Database.SqlQuery<DepartmentItem>(sql, companyParam, minPageParam, maxPageParam);
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
        /// 查询部门list
        /// </summary>
        /// <param name="company">公司名</param>
        /// <returns></returns>
        public List<Department> getList(string company)
        {
            //公司
            var companyParam = new SqlParameter("@company", company);

            var result = from d in fin.Department where d.company == company select d;

            List<Department> list = null;
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
        /// <returns>总行数</returns>
        public int getPageCount(string company)
        {
            //公司
            var companyParam = new SqlParameter("@company", company);

            string sql = "select count(*) as total from Department where company = @company";

            var result = fin.Database.SqlQuery<FinancePage<Department>>(sql, companyParam);
            int total = 0;
            try
            {
                total = result.FirstOrDefault().total;
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return total;
        }
    }
}