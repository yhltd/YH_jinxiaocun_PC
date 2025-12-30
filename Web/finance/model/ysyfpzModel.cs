using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Web.finance.util;

namespace Web.finance.model
{
    public class ysyfpzModel
    {
        //数据库模型
        private FinanceEntities fin;

        public ysyfpzModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取分页集合
        /// </summary>
        public FinancePage<ysyfpeizhi> getList(FinancePage<ysyfpeizhi> financePage, string company, string ysyf, string xiangmumingcheng)
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

                if (!string.IsNullOrEmpty(ysyf))
                {
                    whereClause += " and ysyf = @ysyf";
                    parameters.Add(new SqlParameter("@ysyf", ysyf));
                }

                if (!string.IsNullOrEmpty(xiangmumingcheng))
                {
                    whereClause += " and xiangmumingcheng like @xiangmumingcheng";
                    parameters.Add(new SqlParameter("@xiangmumingcheng", "%" + xiangmumingcheng + "%"));
                }

                // 修正：使用字符串拼接而不是插值
                string sql = @"SELECT a.id, a.company, a.ysyf, a.xiangmumingcheng, a.jine, a.ysyfkemu 
                              FROM (SELECT ROW_NUMBER() OVER(ORDER BY id) AS rownum, * 
                                    FROM ysyfpeizhi 
                                    WHERE " + whereClause + @") AS a 
                              WHERE a.rownum > @minPage AND a.rownum < @maxPage";

                var result = fin.Database.SqlQuery<ysyfpeizhi>(sql, parameters.ToArray());
                financePage.pageList = result.ToList();
            }

            return financePage;
        }

        /// <summary>
        /// 获取所有数据（导出Excel用）
        /// </summary>
        public List<ysyfpeizhi> getAllList(string company, string ysyf, string xiangmumingcheng)
        {
            using (var fin = new FinanceEntities())
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@company", company)
                };

                string whereClause = "company = @company";

                if (!string.IsNullOrEmpty(ysyf))
                {
                    whereClause += " and ysyf = @ysyf";
                    parameters.Add(new SqlParameter("@ysyf", ysyf));
                }

                if (!string.IsNullOrEmpty(xiangmumingcheng))
                {
                    whereClause += " and xiangmumingcheng like @xiangmumingcheng";
                    parameters.Add(new SqlParameter("@xiangmumingcheng", "%" + xiangmumingcheng + "%"));
                }

                // 修正：使用字符串拼接
                string sql = @"SELECT id, company, ysyf, xiangmumingcheng, jine, ysyfkemu 
                              FROM ysyfpeizhi 
                              WHERE " + whereClause + @" 
                              ORDER BY id";

                return fin.Database.SqlQuery<ysyfpeizhi>(sql, parameters.ToArray()).ToList();
            }
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        public int getCount(string company, string ysyf, string xiangmumingcheng)
        {
            using (var fin = new FinanceEntities())
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@company", company)
                };

                string whereClause = "company = @company";

                if (!string.IsNullOrEmpty(ysyf))
                {
                    whereClause += " and ysyf = @ysyf";
                    parameters.Add(new SqlParameter("@ysyf", ysyf));
                }

                if (!string.IsNullOrEmpty(xiangmumingcheng))
                {
                    whereClause += " and xiangmumingcheng like @xiangmumingcheng";
                    parameters.Add(new SqlParameter("@xiangmumingcheng", "%" + xiangmumingcheng + "%"));
                }

                // 修正：使用字符串拼接
                string sql = @"SELECT COUNT(*) FROM ysyfpeizhi WHERE " + whereClause;

                var result = fin.Database.SqlQuery<int>(sql, parameters.ToArray());
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 新增数据（使用SQL）
        /// </summary>
        public int addBySql(ysyfpeizhi entity)
        {
            using (var fin = new FinanceEntities())
            {
                string sql = @"INSERT INTO ysyfpeizhi (company, ysyf, xiangmumingcheng, jine, ysyfkemu) 
                             VALUES (@company, @ysyf, @xiangmumingcheng, @jine, @ysyfkemu)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@company", entity.company),
                    new SqlParameter("@ysyf", entity.ysyf),
                    new SqlParameter("@xiangmumingcheng", entity.xiangmumingcheng),
                    new SqlParameter("@jine", entity.jine),
                    new SqlParameter("@ysyfkemu", entity.ysyfkemu ?? (object)DBNull.Value)
                };

                return fin.Database.ExecuteSqlCommand(sql, parameters);
            }
        }

        /// <summary>
        /// 修改数据（使用SQL）
        /// </summary>
        public int updBySql(ysyfpeizhi entity)
        {
            using (var fin = new FinanceEntities())
            {
                string sql = @"UPDATE ysyfpeizhi 
                             SET ysyf = @ysyf, 
                                 xiangmumingcheng = @xiangmumingcheng, 
                                 jine = @jine, 
                                 ysyfkemu = @ysyfkemu
                             WHERE id = @id AND company = @company";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", entity.id),
                    new SqlParameter("@company", entity.company),
                    new SqlParameter("@ysyf", entity.ysyf),
                    new SqlParameter("@xiangmumingcheng", entity.xiangmumingcheng),
                    new SqlParameter("@jine", entity.jine),
                    new SqlParameter("@ysyfkemu", entity.ysyfkemu ?? (object)DBNull.Value)
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
                string sql = @"DELETE FROM ysyfpeizhi 
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