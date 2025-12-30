using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Web.finance.util;

namespace Web.finance.model
{
    public class gongzimingxiModel
    {
        //数据库模型
        private FinanceEntities fin;

        public gongzimingxiModel()
        {
            fin = new FinanceEntities();
        }

        /// <summary>
        /// 获取分页集合
        /// </summary>
        public FinancePage<gongzimingxi> getList(FinancePage<gongzimingxi> financePage, string company, string renming, string beizhu)
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

                if (!string.IsNullOrEmpty(renming))
                {
                    whereClause += " and renming like @renming";
                    parameters.Add(new SqlParameter("@renming", "%" + renming + "%"));
                }

                if (!string.IsNullOrEmpty(beizhu))
                {
                    whereClause += " and beizhu like @beizhu";
                    parameters.Add(new SqlParameter("@beizhu", "%" + beizhu + "%"));
                }

                string sql = @"SELECT a.id, a.company, a.renming, a.shijian, a.ticheng, 
                                     a.xiaoshoushuliang, a.xiaoshoujine, a.chanpinchengben,
                                     a.yinhangzhanghu, a.koukuan, a.gongzi, a.yifu, 
                                     a.beizhu, a.kkqgongzi,
                                     (a.kkqgongzi - ISNULL(a.koukuan, 0)) as weifu  -- 新增未付字段
                              FROM (SELECT ROW_NUMBER() OVER(ORDER BY id) AS rownum, * 
                                    FROM gongzimingxi 
                                    WHERE " + whereClause + @") AS a 
                              WHERE a.rownum > @minPage AND a.rownum < @maxPage";

                var result = fin.Database.SqlQuery<gongzimingxi>(sql, parameters.ToArray());

                // 处理结果，计算未付金额
                var list = result.ToList();
                foreach (var item in list)
                {
                    // 确保未付字段有值
                    if (item.kkqgongzi.HasValue && item.koukuan.HasValue)
                    {
                        // 计算未付金额：kkqgongzi - koukuan - yifu
                        decimal kkqgongzi = item.kkqgongzi.Value;
                        decimal koukuan = item.koukuan.Value;
                        decimal yifu = item.yifu.HasValue ? item.yifu.Value : 0;

                        item.gongzi = kkqgongzi - koukuan;  // gongzi = kkqgongzi - koukuan

                        // 设置未付字段（通过反射或扩展属性）
                        // 这里我们创建一个新对象来包含未付字段
                    }
                }

                financePage.pageList = list;
            }

            return financePage;
        }

        /// <summary>
        /// 获取所有数据（导出Excel用）
        /// </summary>
        public List<gongzimingxi> getAllList(string company, string renming, string beizhu)
        {
            using (var fin = new FinanceEntities())
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@company", company)
                };

                string whereClause = "company = @company";

                if (!string.IsNullOrEmpty(renming))
                {
                    whereClause += " and renming like @renming";
                    parameters.Add(new SqlParameter("@renming", "%" + renming + "%"));
                }

                if (!string.IsNullOrEmpty(beizhu))
                {
                    whereClause += " and beizhu like @beizhu";
                    parameters.Add(new SqlParameter("@beizhu", "%" + beizhu + "%"));
                }

                string sql = @"SELECT id, company, renming, shijian, ticheng, 
                                     xiaoshoushuliang, xiaoshoujine, chanpinchengben,
                                     yinhangzhanghu, koukuan, gongzi, yifu, 
                                     beizhu, kkqgongzi,
                                     (kkqgongzi - ISNULL(koukuan, 0)) as weifu
                              FROM gongzimingxi 
                              WHERE " + whereClause + @" 
                              ORDER BY id";

                return fin.Database.SqlQuery<gongzimingxi>(sql, parameters.ToArray()).ToList();
            }
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        public int getCount(string company, string renming, string beizhu)
        {
            using (var fin = new FinanceEntities())
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@company", company)
                };

                string whereClause = "company = @company";

                if (!string.IsNullOrEmpty(renming))
                {
                    whereClause += " and renming like @renming";
                    parameters.Add(new SqlParameter("@renming", "%" + renming + "%"));
                }

                if (!string.IsNullOrEmpty(beizhu))
                {
                    whereClause += " and beizhu like @beizhu";
                    parameters.Add(new SqlParameter("@beizhu", "%" + beizhu + "%"));
                }

                string sql = @"SELECT COUNT(*) FROM gongzimingxi WHERE " + whereClause;

                var result = fin.Database.SqlQuery<int>(sql, parameters.ToArray());
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 新增数据（使用SQL）
        /// </summary>
        public int addBySql(gongzimingxi entity)
        {
            using (var fin = new FinanceEntities())
            {
                // 计算工资：gongzi = kkqgongzi - koukuan
                decimal? gongziValue = null;
                if (entity.kkqgongzi.HasValue && entity.koukuan.HasValue)
                {
                    gongziValue = entity.kkqgongzi.Value - entity.koukuan.Value;
                }

                string sql = @"INSERT INTO gongzimingxi 
                             (company, renming, shijian, ticheng, xiaoshoushuliang, 
                              xiaoshoujine, chanpinchengben, yinhangzhanghu, 
                              koukuan, gongzi, yifu, beizhu, kkqgongzi) 
                             VALUES 
                             (@company, @renming, @shijian, @ticheng, @xiaoshoushuliang, 
                              @xiaoshoujine, @chanpinchengben, @yinhangzhanghu, 
                              @koukuan, @gongzi, @yifu, @beizhu, @kkqgongzi)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@company", entity.company),
                    new SqlParameter("@renming", entity.renming ?? (object)DBNull.Value),
                    new SqlParameter("@shijian", entity.shijian ?? (object)DBNull.Value),
                    new SqlParameter("@ticheng", entity.ticheng ?? (object)DBNull.Value),
                    new SqlParameter("@xiaoshoushuliang", entity.xiaoshoushuliang ?? (object)DBNull.Value),
                    new SqlParameter("@xiaoshoujine", entity.xiaoshoujine ?? (object)DBNull.Value),
                    new SqlParameter("@chanpinchengben", entity.chanpinchengben ?? (object)DBNull.Value),
                    new SqlParameter("@yinhangzhanghu", entity.yinhangzhanghu ?? (object)DBNull.Value),
                    new SqlParameter("@koukuan", entity.koukuan ?? (object)DBNull.Value),
                    new SqlParameter("@gongzi", gongziValue ?? (object)DBNull.Value),
                    new SqlParameter("@yifu", entity.yifu ?? (object)DBNull.Value),
                    new SqlParameter("@beizhu", entity.beizhu ?? (object)DBNull.Value),
                    new SqlParameter("@kkqgongzi", entity.kkqgongzi ?? (object)DBNull.Value)
                };

                return fin.Database.ExecuteSqlCommand(sql, parameters);
            }
        }

        /// <summary>
        /// 修改数据（使用SQL）
        /// </summary>
        public int updBySql(gongzimingxi entity)
        {
            using (var fin = new FinanceEntities())
            {
                // 计算工资：gongzi = kkqgongzi - koukuan
                decimal? gongziValue = null;
                if (entity.kkqgongzi.HasValue && entity.koukuan.HasValue)
                {
                    gongziValue = entity.kkqgongzi.Value - entity.koukuan.Value;
                }

                string sql = @"UPDATE gongzimingxi 
                             SET renming = @renming, 
                                 shijian = @shijian, 
                                 ticheng = @ticheng,
                                 xiaoshoushuliang = @xiaoshoushuliang,
                                 xiaoshoujine = @xiaoshoujine,
                                 chanpinchengben = @chanpinchengben,
                                 yinhangzhanghu = @yinhangzhanghu,
                                 koukuan = @koukuan,
                                 gongzi = @gongzi,
                                 yifu = @yifu,
                                 beizhu = @beizhu,
                                 kkqgongzi = @kkqgongzi
                             WHERE id = @id AND company = @company";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", entity.id),
                    new SqlParameter("@company", entity.company),
                    new SqlParameter("@renming", entity.renming ?? (object)DBNull.Value),
                    new SqlParameter("@shijian", entity.shijian ?? (object)DBNull.Value),
                    new SqlParameter("@ticheng", entity.ticheng ?? (object)DBNull.Value),
                    new SqlParameter("@xiaoshoushuliang", entity.xiaoshoushuliang ?? (object)DBNull.Value),
                    new SqlParameter("@xiaoshoujine", entity.xiaoshoujine ?? (object)DBNull.Value),
                    new SqlParameter("@chanpinchengben", entity.chanpinchengben ?? (object)DBNull.Value),
                    new SqlParameter("@yinhangzhanghu", entity.yinhangzhanghu ?? (object)DBNull.Value),
                    new SqlParameter("@koukuan", entity.koukuan ?? (object)DBNull.Value),
                    new SqlParameter("@gongzi", gongziValue ?? (object)DBNull.Value),
                    new SqlParameter("@yifu", entity.yifu ?? (object)DBNull.Value),
                    new SqlParameter("@beizhu", entity.beizhu ?? (object)DBNull.Value),
                    new SqlParameter("@kkqgongzi", entity.kkqgongzi ?? (object)DBNull.Value)
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

                string sql = @"DELETE FROM gongzimingxi 
                              WHERE company = @company 
                              AND id IN (" + idList + ")";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@company", company)
                };

                return fin.Database.ExecuteSqlCommand(sql, parameters);
            }
        }

        /// <summary>
        /// 创建包含未付字段的视图模型
        /// </summary>
        public class GongziViewModel : gongzimingxi
        {
            public decimal? weifu { get; set; }
        }
    }
}