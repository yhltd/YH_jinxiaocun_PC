using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Web.finance.util;

namespace Web.finance.model
{
    public class shuilvpeizhiModel
     {
        //数据库模型
        private FinanceEntities fin;

        public shuilvpeizhiModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取分页集合
        /// </summary>
        public FinancePage<shuilvPeizhi> getList(FinancePage<shuilvPeizhi> financePage, string company, string shuilv, string linjiezhi)
        {
            using (var fin = new FinanceEntities())
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@company", company),
            new SqlParameter("@minPage", financePage.getMin()),
            new SqlParameter("@maxPage", financePage.getMax())
        };

                string whereClause = "company = @company";

                if (!string.IsNullOrEmpty(shuilv))
                {
                    whereClause += " and shuilv like @shuilv";
                    parameters.Add(new SqlParameter("@shuilv", "%" + shuilv + "%"));
                }

                if (!string.IsNullOrEmpty(linjiezhi))
                {
                    whereClause += " and linjiezhi like @linjiezhi";
                    parameters.Add(new SqlParameter("@linjiezhi", "%" + linjiezhi + "%"));
                }

                string sql = @"SELECT a.id, a.company, a.shuilv, a.linjiezhi 
                      FROM (SELECT ROW_NUMBER() OVER(ORDER BY id) AS rownum, * 
                            FROM shuilvPeizhi 
                            WHERE " + whereClause + @") AS a 
                      WHERE a.rownum > @minPage AND a.rownum < @maxPage";

                var result = fin.Database.SqlQuery<shuilvPeizhi>(sql, parameters.ToArray());
                financePage.pageList = result.ToList();
            }

            return financePage;
        }

        /// <summary>
        /// 获取所有数据（导出Excel用）
        /// </summary>
        public List<shuilvPeizhi> getAllList(string company, string shuilv, string linjiezhi)
        {
            using (var fin = new FinanceEntities())
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@company", company)
        };

                string whereClause = "company = @company";

                if (!string.IsNullOrEmpty(shuilv))
                {
                    whereClause += " and shuilv like @shuilv";
                    parameters.Add(new SqlParameter("@shuilv", "%" + shuilv + "%"));
                }

                if (!string.IsNullOrEmpty(linjiezhi))
                {
                    whereClause += " and linjiezhi like @linjiezhi";
                    parameters.Add(new SqlParameter("@linjiezhi", "%" + linjiezhi + "%"));
                }

                string sql = @"SELECT id, company, shuilv, linjiezhi 
                      FROM shuilvPeizhi 
                      WHERE " + whereClause + @" 
                      ORDER BY id";

                return fin.Database.SqlQuery<shuilvPeizhi>(sql, parameters.ToArray()).ToList();
            }
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        public int getCount(string company, string shuilv, string linjiezhi)
        {
            using (var fin = new FinanceEntities())
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@company", company)
        };

                string whereClause = "company = @company";

                if (!string.IsNullOrEmpty(shuilv))
                {
                    whereClause += " and shuilv like @shuilv";
                    parameters.Add(new SqlParameter("@shuilv", "%" + shuilv + "%"));
                }

                if (!string.IsNullOrEmpty(linjiezhi))
                {
                    whereClause += " and linjiezhi like @linjiezhi";
                    parameters.Add(new SqlParameter("@linjiezhi", "%" + linjiezhi + "%"));
                }

                string sql = @"SELECT COUNT(*) FROM shuilvPeizhi WHERE " + whereClause;

                var result = fin.Database.SqlQuery<int>(sql, parameters.ToArray());
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 新增数据（使用SQL）
        /// </summary>
        public int addBySql(shuilvPeizhi entity)
        {
            using (var fin = new FinanceEntities())
            {
                string sql = @"INSERT INTO shuilvPeizhi (company, shuilv, linjiezhi) 
                             VALUES (@company, @shuilv, @linjiezhi)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@company", entity.company),
                    new SqlParameter("@shuilv", entity.shuilv),
                    new SqlParameter("@linjiezhi", entity.linjiezhi),
                };

                return fin.Database.ExecuteSqlCommand(sql, parameters);
            }
        }

        /// <summary>
        /// 修改数据（使用SQL）
        /// </summary>
        public int updBySql(shuilvPeizhi entity)
        {
            using (var fin = new FinanceEntities())
            {
                string sql = @"UPDATE shuilvPeizhi 
                     SET shuilv = @shuilv, 
                         linjiezhi = @linjiezhi
                     WHERE id = @id AND company = @company";

                var parameters = new SqlParameter[]
        {
            new SqlParameter("@id", entity.id),
            new SqlParameter("@company", entity.company),
            new SqlParameter("@shuilv", entity.shuilv),
            new SqlParameter("@linjiezhi", entity.linjiezhi),
        };

                return fin.Database.ExecuteSqlCommand(sql, parameters);
            }
        }

        /// <summary>
        /// 删除数据（使用SQL）
        /// </summary>
        public int delBySql(string company, int[] ids)
        {
            using (var fin = new FinanceEntities())
            {
                // 构建ID列表字符串
                var idList = string.Join(",", ids);

                // 修正：使用字符串拼接
                string sql = @"DELETE FROM shuilvPeizhi 
                              WHERE company = @company 
                              AND id IN (" + idList + ")";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@company", company)
                };

                return fin.Database.ExecuteSqlCommand(sql, parameters);
            }
        }
    }
}