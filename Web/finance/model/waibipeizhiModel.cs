using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Web.finance.util;

namespace Web.finance.model
{
    public class waibipeizhiModel
   {
        //数据库模型
        private FinanceEntities fin;

        public waibipeizhiModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取分页集合
        /// </summary>
        public FinancePage<waibiPeizhi> getList(FinancePage<waibiPeizhi> financePage, string company, string huilv, string bizhong)
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

                if (!string.IsNullOrEmpty(huilv))
                {
                    whereClause += " and huilv like @huilv";
                    parameters.Add(new SqlParameter("@huilv", "%" + huilv + "%"));
                }

                if (!string.IsNullOrEmpty(bizhong))
                {
                    whereClause += " and bizhong like @bizhong";
                    parameters.Add(new SqlParameter("@bizhong", "%" + bizhong + "%"));
                }

                string sql = @"SELECT a.id, a.company, a.huilv, a.bizhong
                      FROM (SELECT ROW_NUMBER() OVER(ORDER BY id) AS rownum, * 
                            FROM waibiPeizhi 
                            WHERE " + whereClause + @") AS a 
                      WHERE a.rownum > @minPage AND a.rownum < @maxPage";

                var result = fin.Database.SqlQuery<waibiPeizhi>(sql, parameters.ToArray());
                financePage.pageList = result.ToList();
            }

            return financePage;
        }


        /// <summary>
        /// 获取所有数据（导出Excel用）
        /// </summary>
        public List<waibiPeizhi> getAllList(string company, string huilv, string bizhong)
        {
            using (var fin = new FinanceEntities())
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@company", company)
        };

                string whereClause = "company = @company";

                if (!string.IsNullOrEmpty(huilv))
                {
                    whereClause += " and huilv like @huilv";
                    parameters.Add(new SqlParameter("@huilv", "%" + huilv + "%"));
                }

                if (!string.IsNullOrEmpty(bizhong))
                {
                    whereClause += " and bizhong like @bizhong";
                    parameters.Add(new SqlParameter("@bizhong", "%" + bizhong + "%"));
                }

                string sql = @"SELECT id, company, huilv, bizhong
                      FROM waibiPeizhi 
                      WHERE " + whereClause + @" 
                      ORDER BY id";

                return fin.Database.SqlQuery<waibiPeizhi>(sql, parameters.ToArray()).ToList();
            }
        }


        /// <summary>
        /// 获取总行数
        /// </summary>
        public int getCount(string company, string huilv, string bizhong)
        {
            using (var fin = new FinanceEntities())
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@company", company)
        };

                string whereClause = "company = @company";

                if (!string.IsNullOrEmpty(huilv))
                {
                    whereClause += " and huilv like @huilv";
                    parameters.Add(new SqlParameter("@huilv", "%" + huilv + "%"));
                }

                if (!string.IsNullOrEmpty(bizhong))
                {
                    whereClause += " and bizhong like @bizhong";
                    parameters.Add(new SqlParameter("@bizhong", "%" + bizhong + "%"));
                }

                string sql = @"SELECT COUNT(*) FROM waibiPeizhi WHERE " + whereClause;

                var result = fin.Database.SqlQuery<int>(sql, parameters.ToArray());
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 新增数据（使用SQL）
        /// </summary>
        public int addBySql(waibiPeizhi entity)
        {
            using (var fin = new FinanceEntities())
            {
                string sql = @"INSERT INTO waibiPeizhi (company, huilv, bizhong) 
                     VALUES (@company, @huilv, @bizhong)";

                var parameters = new SqlParameter[]
        {
            new SqlParameter("@company", entity.company),
            new SqlParameter("@huilv", entity.huilv),  // 修正顺序：先huilv
            new SqlParameter("@bizhong", entity.bizhong),  // 再bizhong
        };

                return fin.Database.ExecuteSqlCommand(sql, parameters);
            }
        }

        /// <summary>
        /// 修改数据（使用SQL）
        /// </summary>
        public int updBySql(waibiPeizhi entity)
        {
            using (var fin = new FinanceEntities())
            {
                string sql = @"UPDATE waibiPeizhi 
                     SET huilv = @huilv, 
                         bizhong = @bizhong
                     WHERE id = @id AND company = @company";

                var parameters = new SqlParameter[]
        {
            new SqlParameter("@id", entity.id),
            new SqlParameter("@company", entity.company),
            new SqlParameter("@huilv", entity.huilv),
            new SqlParameter("@bizhong", entity.bizhong),
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
                string sql = @"DELETE FROM waibiPeizhi 
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