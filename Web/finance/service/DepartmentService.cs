using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.entiy;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    /// <author>
    /// dai
    /// </author>
    public class DepartmentService
    {
        //model层
        private DepartmentModel departmentModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public DepartmentService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                departmentModel = new DepartmentModel();
            }catch{
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="department">部门对象</param>
        /// <returns>添加是否成功</returns>
        public Boolean newDepartmentService(Department department)
        {
            //设置新部门的所属公司
            department.company = account.company;
            //影响行数大于0则添加成功
            return departmentModel.newDepartment(department) > 0;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns></returns>
        public Boolean delDepartmentService(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++) {
                if (departmentModel.delDepartment(ids[i]) <= 0) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="department">新部门对象</param>
        /// <returns>成功返回新对象，否则null</returns>
        public DepartmentItem updDepartmentService(DepartmentItem department)
        {
            department.company = account.company;
            int result = departmentModel.updDepartment(department.getParent());
            return result > 0 ? department : null;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<DepartmentItem> getListService(FinancePage<DepartmentItem> financePage)
        {
            //获取pageList
            financePage = departmentModel.getList(financePage,account.company);
            //获取总页数
            financePage.total = departmentModel.getPageCount(account.company);
            return financePage;
        }

        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <returns></returns>
        public List<Department> getList() {
            return departmentModel.getList(account.company);
        }
    }
}