using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class BomDao
    {

        private schedulingEntities se;

        /// <summary>
        /// 查询所有bom
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<bom_info> list(string company)
        {
            using (se = new schedulingEntities()) 
            {
                var result = se.bom_info.Where(b => b.company == company);
                return result.ToList();
            }
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="skip">跳过行数</param>
        /// <param name="take">查询行数</param>
        /// <param name="code">编码</param>
        /// <param name="name">名称</param>
        /// <param name="type">类别</param>
        /// <returns></returns>
        public List<BomInfoItem> list(string company, int skip, int take, string code, string name, string type)
        {
            using (se = new schedulingEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@company", company),
                    new SqlParameter("@code", code),
                    new SqlParameter("@name", name),
                    new SqlParameter("@type", type),
                    new SqlParameter("@minRowNumber", skip * take),
                    new SqlParameter("@maxRowNumber", (skip + 1) * take + 1)
                };
                string sql = "select * from (select row_number() over(order by b.id) as rownum,b.*,isnull((select sum(o.use_num*oi.set_num) from order_bom as o left join order_info as oi on o.order_id = oi.id where o.bom_id = b.id), 0) as useNum from bom_info as b where b.company = @company and code like '%' + @code + '%' and name like '%' + @name + '%' and type like '%' + @type + '%') as bom where bom.rownum > @minRowNumber and rownum < @maxRowNumber";

                var result = se.Database.SqlQuery<BomInfoItem>(sql, @params);
                return result.ToList();
            }
        }

        /// <summary>
        /// 总行数
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public int count(string company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.bom_info.Count();
                return (int)result;
            }
        }
    }
}