using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;

namespace Web.finance.entiy
{
    /// <author>
    /// dai
    /// </author>
    public class DepartmentItem : Department
    {
        //行号
        public Int64 rownum { get; set; }

        public Department getParent()
        {
            Department department = new Department();
            department.id = this.id;
            department.department1 = this.department1;
            department.man = this.man;
            department.company = this.company;
            return department;
        }
    }
}