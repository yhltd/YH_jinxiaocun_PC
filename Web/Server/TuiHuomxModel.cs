using MySql.Data.MySqlClient;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ServerEntity;
using Web.JxcServer;
using MySql.Data.MySqlClient;
using System.Text;

namespace Web.Server
{
    public class TuiHuomxModel
    {
        public string checkOrder_id(string order_id, string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var @params = new MySqlParameter[]
                {
                    new MySqlParameter("@order", order_id),
                    new MySqlParameter("@gongsi", gongsi)
                };

                        string sql = "select orderid from yh_jinxiaocun_tuihuomingxi where orderid = @order and gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, @params);
                        List<yh_jinxiaocun_tuihuomingxi> list = result.ToList();
                        return list.Count > 0 ? list[0].orderid : string.Empty;
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var @params = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@order", order_id),
                    new System.Data.SqlClient.SqlParameter("@gongsi", gongsi)
                };

                        string sql = "SELECT orderid FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE orderid = @order AND gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, @params);
                        List<yh_jinxiaocun_tuihuomingxi> list = result.ToList();
                        return list.Count > 0 ? list[0].orderid : string.Empty;
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var @params = new MySqlParameter[]
        {
            new MySqlParameter("@order", order_id),
            new MySqlParameter("@gongsi", gongsi)
        };

                string sql = "select orderid from yh_jinxiaocun_tuihuomingxi where orderid = @order and gs_name = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, @params);
                List<yh_jinxiaocun_tuihuomingxi> list = result.ToList();
                return list.Count > 0 ? list[0].orderid : string.Empty;
            }
        }


        public List<yh_jinxiaocun_tuihuomingxi> checkOrder_mingxi(string order_id, string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var @params = new MySqlParameter[]
                {
                    new MySqlParameter("@order", order_id),
                    new MySqlParameter("@gongsi", gongsi)
                };

                        string sql = "select * from yh_jinxiaocun_tuihuomingxi where orderid = @order and gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, @params);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var @params = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@order", order_id),
                    new System.Data.SqlClient.SqlParameter("@gongsi", gongsi)
                };

                        string sql = "SELECT * FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE orderid = @order AND gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, @params);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var @params = new MySqlParameter[]
        {
            new MySqlParameter("@order", order_id),
            new MySqlParameter("@gongsi", gongsi)
        };

                string sql = "select * from yh_jinxiaocun_tuihuomingxi where orderid = @order and gs_name = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, @params);
                return result.ToList();
            }
        }

        public int add(items item, string company, string name, string mxtype, string Rwarehouse, string ruku)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string date_now = DateTime.Now.ToString();
                        int affectedRows = 0;

                        for (int i = 0; i < item.itemList.Count; i++)
                        {
                            string sql = @"insert into yh_jinxiaocun_tuihuomingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku,ruku) 
                                 select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku,@ruku as ruku  
                                 from yh_jinxiaocun_jichuziliao where id = @id";

                            var parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("@price", item.itemList[i].price),
                        new MySqlParameter("@num", item.itemList[i].num),
                        new MySqlParameter("@mxtype", mxtype),
                        new MySqlParameter("@orderid", item.orderid),
                        new MySqlParameter("@shijian", date_now),
                        new MySqlParameter("@shou_h", item.gonghuo),
                        new MySqlParameter("@zh_name", name),
                        new MySqlParameter("@gs_name", company),
                        new MySqlParameter("@cangku", Rwarehouse),
                        new MySqlParameter("@ruku", ruku),
                        new MySqlParameter("@id", item.itemList[i].id)
                    };

                            affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                        }
                        return affectedRows;
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string date_now = DateTime.Now.ToString();
                        int affectedRows = 0;

                        for (int i = 0; i < item.itemList.Count; i++)
                        {
                            string sql = @"INSERT INTO yh_jinxiaocun_tuihuomingxi_mssql(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku,ruku) 
                                 SELECT lei_bie as cplb,[name] as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name ,@cangku as cangku ,@ruku as ruku 
                                 FROM yh_jinxiaocun_jichuziliao_mssql WHERE id = @id";

                            var parameters = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@price", item.itemList[i].price),
                        new System.Data.SqlClient.SqlParameter("@num", item.itemList[i].num),
                        new System.Data.SqlClient.SqlParameter("@mxtype", mxtype),
                        new System.Data.SqlClient.SqlParameter("@orderid", item.orderid),
                        new System.Data.SqlClient.SqlParameter("@shijian", date_now),
                        new System.Data.SqlClient.SqlParameter("@shou_h", item.gonghuo),
                        new System.Data.SqlClient.SqlParameter("@zh_name", name),
                        new System.Data.SqlClient.SqlParameter("@gs_name", company),
                        new System.Data.SqlClient.SqlParameter("@cangku", Rwarehouse),
                        new System.Data.SqlClient.SqlParameter("@ruku", ruku),
                        new System.Data.SqlClient.SqlParameter("@id", item.itemList[i].id)
                    };

                            affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                        }
                        return affectedRows;
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string date_now = DateTime.Now.ToString();
                int affectedRows = 0;

                for (int i = 0; i < item.itemList.Count; i++)
                {
                    string sql = @"insert into yh_jinxiaocun_tuihuomingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku,ruku) 
                                 select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku,@ruku as ruku  
                                 from yh_jinxiaocun_jichuziliao where id = @id";

                    var parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("@price", item.itemList[i].price),
                        new MySqlParameter("@num", item.itemList[i].num),
                        new MySqlParameter("@mxtype", mxtype),
                        new MySqlParameter("@orderid", item.orderid),
                        new MySqlParameter("@shijian", date_now),
                        new MySqlParameter("@shou_h", item.gonghuo),
                        new MySqlParameter("@zh_name", name),
                        new MySqlParameter("@gs_name", company),
                        new MySqlParameter("@cangku", Rwarehouse),
                        new MySqlParameter("@ruku", ruku),
                        new MySqlParameter("@id", item.itemList[i].id)
            };

                    affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                }
                return affectedRows;
            }
        }



        public List<yh_jinxiaocun_tuihuomingxi> ming_xi_select(string gs_name, int limit1, int limit2, String kstime88, String jstime88)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var riqi1 = DateTime.Now.ToString("yyyy-MM-01");
                        var riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                        if (string.IsNullOrEmpty(kstime88))
                            kstime88 = riqi1;
                        if (string.IsNullOrEmpty(jstime88))
                            jstime88 = riqi2;

                        // 修复：添加日期条件到查询
                        string sql = @"SELECT * FROM yh_jinxiaocun_tuihuomingxi 
                     WHERE gs_name = @gs_name 
                     AND ruku != '已入库' 
                     AND DATE(shijian) >= @kstime 
                     AND DATE(shijian) <= @jstime 
                     ORDER BY shijian DESC 
                     LIMIT @limit1, @limit2";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@gs_name", gs_name),
                    new MySqlParameter("@kstime", kstime88),
                    new MySqlParameter("@jstime", jstime88),
                    new MySqlParameter("@limit1", limit1),
                    new MySqlParameter("@limit2", limit2)
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var riqi1 = DateTime.Now.ToString("yyyy-MM-01");
                        var riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                        if (string.IsNullOrEmpty(kstime88))
                            kstime88 = riqi1;
                        if (string.IsNullOrEmpty(jstime88))
                            jstime88 = riqi2;

                        string sql = @"SELECT * FROM (
                     SELECT *, ROW_NUMBER() OVER (ORDER BY shijian DESC) as RowNum 
                     FROM yh_jinxiaocun_tuihuomingxi_mssql 
                     WHERE gs_name = @gs_name 
                    AND ruku != '已入库'
                     AND CONVERT(DATE, shijian) >= @kstime 
                     AND CONVERT(DATE, shijian) <= @jstime
                   ) AS MyResults
                   WHERE RowNum BETWEEN @startRow AND @endRow";

                        int startRow = limit1 + 1;
                        int endRow = limit1 + limit2;

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name),
                    new System.Data.SqlClient.SqlParameter("@kstime", kstime88),
                    new System.Data.SqlClient.SqlParameter("@jstime", jstime88),
                    new System.Data.SqlClient.SqlParameter("@startRow", startRow),
                    new System.Data.SqlClient.SqlParameter("@endRow", endRow)
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var riqi1 = DateTime.Now.ToString("yyyy-MM-01");
                var riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                if (string.IsNullOrEmpty(kstime88))
                    kstime88 = riqi1;
                if (string.IsNullOrEmpty(jstime88))
                    jstime88 = riqi2;

                string sql = @"SELECT * FROM yh_jinxiaocun_tuihuomingxi 
             WHERE gs_name = @gs_name 
             AND ruku != '已入库'
             AND DATE(shijian) >= @kstime 
             AND DATE(shijian) <= @jstime 
             ORDER BY shijian DESC 
             LIMIT @limit1, @limit2";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@gs_name", gs_name),
            new MySqlParameter("@kstime", kstime88),
            new MySqlParameter("@jstime", jstime88),
            new MySqlParameter("@limit1", limit1),
            new MySqlParameter("@limit2", limit2)
        };

                var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters);
                return result.ToList();
            }
        }

        public int getPageCount(string gs_name, string kstime88 = null, string jstime88 = null)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var riqi1 = DateTime.Now.ToString("yyyy-MM-01");
                        var riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                        if (string.IsNullOrEmpty(kstime88))
                            kstime88 = riqi1;
                        if (string.IsNullOrEmpty(jstime88))
                            jstime88 = riqi2;

                        string sql = @"SELECT COUNT(*) FROM yh_jinxiaocun_tuihuomingxi 
                     WHERE gs_name = @gs_name 
                     AND DATE(shijian) >= @kstime 
                     AND DATE(shijian) <= @jstime";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@gs_name", gs_name),
                    new MySqlParameter("@kstime", kstime88),
                    new MySqlParameter("@jstime", jstime88)
                };

                        var result = sen.Database.SqlQuery<int>(sql, parameters);
                        return result.SingleOrDefault();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var riqi1 = DateTime.Now.ToString("yyyy-MM-01");
                        var riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                        if (string.IsNullOrEmpty(kstime88))
                            kstime88 = riqi1;
                        if (string.IsNullOrEmpty(jstime88))
                            jstime88 = riqi2;

                        string sql = @"SELECT COUNT(*) FROM yh_jinxiaocun_tuihuomingxi_mssql 
                     WHERE gs_name = @gs_name 
                     AND CONVERT(DATE, shijian) >= @kstime 
                     AND CONVERT(DATE, shijian) <= @jstime";

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name),
                    new System.Data.SqlClient.SqlParameter("@kstime", kstime88),
                    new System.Data.SqlClient.SqlParameter("@jstime", jstime88)
                };

                        var result = sen.Database.SqlQuery<int>(sql, parameters);
                        return result.SingleOrDefault();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var riqi1 = DateTime.Now.ToString("yyyy-MM-01");
                var riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                if (string.IsNullOrEmpty(kstime88))
                    kstime88 = riqi1;
                if (string.IsNullOrEmpty(jstime88))
                    jstime88 = riqi2;

                string sql = @"SELECT COUNT(*) FROM yh_jinxiaocun_tuihuomingxi 
             WHERE gs_name = @gs_name 
             AND DATE(shijian) >= @kstime 
             AND DATE(shijian) <= @jstime";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@gs_name", gs_name),
            new MySqlParameter("@kstime", kstime88),
            new MySqlParameter("@jstime", jstime88)
        };

                var result = sen.Database.SqlQuery<int>(sql, parameters);
                return result.SingleOrDefault();
            }
        }

        public List<yh_jinxiaocun_tuihuomingxi> ri_qi_select(string time_qs, string time_jz, string order_number, string cangku, string shou_h, string gs_name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 处理日期格式：将结束日期加上一天，确保包含当天的所有记录
                        DateTime startDate, endDate;

                        if (!DateTime.TryParse(time_qs, out startDate))
                            startDate = new DateTime(1999, 1, 1);

                        if (!DateTime.TryParse(time_jz, out endDate))
                            endDate = new DateTime(2999, 12, 31);

                        // 将结束日期加一天，确保包含当天的所有记录
                        endDate = endDate.AddDays(1);

                        // 构建动态SQL
                        StringBuilder sqlBuilder = new StringBuilder();
                        sqlBuilder.Append(@"SELECT * FROM yh_jinxiaocun_tuihuomingxi 
                     WHERE gs_name = @gs_name 
                     AND ruku != '已入库' ");

                        // 修改日期条件：使用 >= 和 < 而不是 BETWEEN
                        sqlBuilder.Append(@"AND shijian >= @time_qs 
                     AND shijian < @time_jz ");

                        // 添加其他条件
                        if (!string.IsNullOrEmpty(order_number))
                        {
                            sqlBuilder.Append(@"AND orderid LIKE @order_number ");
                        }

                        if (!string.IsNullOrEmpty(cangku))
                        {
                            sqlBuilder.Append(@"AND cangku LIKE @cangku ");
                        }

                        if (!string.IsNullOrEmpty(shou_h))
                        {
                            sqlBuilder.Append(@"AND shou_h LIKE @shou_h ");
                        }

                        sqlBuilder.Append(@"ORDER BY shijian DESC");

                        string sql = sqlBuilder.ToString();

                        // 创建参数列表
                        List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@time_qs", startDate),
                    new MySqlParameter("@time_jz", endDate),
                    new MySqlParameter("@gs_name", gs_name ?? (object)DBNull.Value)
                };

                        // 添加可选参数
                        parameters.Add(new MySqlParameter("@order_number", "%" + (order_number ?? "") + "%"));
                        parameters.Add(new MySqlParameter("@cangku", "%" + (cangku ?? "") + "%"));
                        parameters.Add(new MySqlParameter("@shou_h", "%" + (shou_h ?? "") + "%"));

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters.ToArray());
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 处理日期格式
                        DateTime startDate, endDate;

                        if (!DateTime.TryParse(time_qs, out startDate))
                            startDate = new DateTime(1999, 1, 1);

                        if (!DateTime.TryParse(time_jz, out endDate))
                            endDate = new DateTime(2999, 12, 31);

                        endDate = endDate.AddDays(1);

                        StringBuilder sqlBuilder = new StringBuilder();
                        sqlBuilder.Append(@"SELECT * FROM yh_jinxiaocun_tuihuomingxi_mssql 
                     WHERE gs_name = @gs_name 
                     AND ruku != '已入库' ");

                        sqlBuilder.Append(@"AND shijian >= @time_qs 
                     AND shijian < @time_jz ");

                        if (!string.IsNullOrEmpty(order_number))
                        {
                            sqlBuilder.Append(@"AND orderid LIKE @order_number ");
                        }

                        if (!string.IsNullOrEmpty(cangku))
                        {
                            sqlBuilder.Append(@"AND cangku LIKE @cangku ");
                        }

                        if (!string.IsNullOrEmpty(shou_h))
                        {
                            sqlBuilder.Append(@"AND shou_h LIKE @shou_h ");
                        }

                        sqlBuilder.Append(@"ORDER BY shijian DESC");

                        string sql = sqlBuilder.ToString();

                        List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>
                {
                    new System.Data.SqlClient.SqlParameter("@time_qs", startDate),
                    new System.Data.SqlClient.SqlParameter("@time_jz", endDate),
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name ?? (object)DBNull.Value)
                };

                        parameters.Add(new System.Data.SqlClient.SqlParameter("@order_number", "%" + (order_number ?? "") + "%"));
                        parameters.Add(new System.Data.SqlClient.SqlParameter("@cangku", "%" + (cangku ?? "") + "%"));
                        parameters.Add(new System.Data.SqlClient.SqlParameter("@shou_h", "%" + (shou_h ?? "") + "%"));

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters.ToArray());
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                // 处理日期格式
                DateTime startDate, endDate;

                if (!DateTime.TryParse(time_qs, out startDate))
                    startDate = new DateTime(1999, 1, 1);

                if (!DateTime.TryParse(time_jz, out endDate))
                    endDate = new DateTime(2999, 12, 31);

                endDate = endDate.AddDays(1);

                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"SELECT * FROM yh_jinxiaocun_tuihuomingxi 
             WHERE gs_name = @gs_name 
             AND ruku != '已入库' ");

                sqlBuilder.Append(@"AND shijian >= @time_qs 
             AND shijian < @time_jz ");

                if (!string.IsNullOrEmpty(order_number))
                {
                    sqlBuilder.Append(@"AND orderid LIKE @order_number ");
                }

                if (!string.IsNullOrEmpty(cangku))
                {
                    sqlBuilder.Append(@"AND cangku LIKE @cangku ");
                }

                if (!string.IsNullOrEmpty(shou_h))
                {
                    sqlBuilder.Append(@"AND shou_h LIKE @shou_h ");
                }

                sqlBuilder.Append(@"ORDER BY shijian DESC");

                string sql = sqlBuilder.ToString();

                List<MySqlParameter> parameters = new List<MySqlParameter>
        {
            new MySqlParameter("@time_qs", startDate),
            new MySqlParameter("@time_jz", endDate),
            new MySqlParameter("@gs_name", gs_name ?? (object)DBNull.Value)
        };

                parameters.Add(new MySqlParameter("@order_number", "%" + (order_number ?? "") + "%"));
                parameters.Add(new MySqlParameter("@cangku", "%" + (cangku ?? "") + "%"));
                parameters.Add(new MySqlParameter("@shou_h", "%" + (shou_h ?? "") + "%"));

                var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters.ToArray());
                return result.ToList();
            }
        }

        public List<yh_jinxiaocun_tuihuomingxi> getCpNames(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select cpname from yh_jinxiaocun_tuihuomingxi where gs_name = @gongsi group by cpname";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, new MySqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "SELECT cpname FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE gs_name = @gongsi GROUP BY cpname";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, new System.Data.SqlClient.SqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select cpname from yh_jinxiaocun_tuihuomingxi where gs_name = @gongsi group by cpname";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, new MySqlParameter("@gongsi", gongsi));
                return result.ToList();
            }
        }

       
        public List<MingXiItem> getCpMingXi(string sp_dm, string cplb, string cpname, string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"select mx.sp_dm,mx.cpname,mx.cplb,
                             ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,
                             ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price 
                             from (select sp_dm,cpname,cplb from yh_jinxiaocun_tuihuomingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm 
                             where mx.cpname = @cpname and mx.sp_dm like @sp_dm and mx.cplb like @cplb";

                        var @params = new MySqlParameter[]{
                    new MySqlParameter("@cpname", cpname ?? (object)DBNull.Value),
                    new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value),
                    new MySqlParameter("@sp_dm", "%" + sp_dm + "%"),
                    new MySqlParameter("@cplb", "%" + cplb + "%")
                };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"SELECT mx.sp_dm,mx.cpname,mx.cplb,
                             ISNULL(rk.cpsl,0) as ruku_num,ISNULL(rk.cp_price,0) as ruku_price,
                             ISNULL(ck.cpsl,0) as chuku_num,ISNULL(ck.cp_price,0) as chuku_price 
                             FROM (SELECT sp_dm,cpname,cplb FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE gs_name = @gongxi GROUP BY sp_dm,cpname,cplb) as mx 
                             LEFT JOIN (SELECT sp_dm,SUM(cpsl) as cpsl,SUM(cpsl*cpsj) as cp_price FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE mxtype = '入库' AND gs_name = @gongxi GROUP BY sp_dm) as rk ON mx.sp_dm=rk.sp_dm 
                             LEFT JOIN (SELECT sp_dm,SUM(cpsl) as cpsl,SUM(cpsl*cpsj) as cp_price FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE mxtype = '出库' AND gs_name = @gongxi GROUP BY sp_dm) as ck ON ck.sp_dm=rk.sp_dm 
                             WHERE mx.cpname = @cpname AND mx.sp_dm LIKE @sp_dm AND mx.cplb LIKE @cplb";

                        var @params = new System.Data.SqlClient.SqlParameter[]{
                    new System.Data.SqlClient.SqlParameter("@cpname", cpname ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@gongxi", gongsi ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@sp_dm", "%" + sp_dm + "%"),
                    new System.Data.SqlClient.SqlParameter("@cplb", "%" + cplb + "%")
                };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select mx.sp_dm,mx.cpname,mx.cplb,
                     ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,
                     ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price 
                     from (select sp_dm,cpname,cplb from yh_jinxiaocun_tuihuomingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm 
                     where mx.cpname = @cpname and mx.sp_dm like @sp_dm and mx.cplb like @cplb";

                var @params = new MySqlParameter[]{
            new MySqlParameter("@cpname", cpname ?? (object)DBNull.Value),
            new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value),
            new MySqlParameter("@sp_dm", "%" + sp_dm + "%"),
            new MySqlParameter("@cplb", "%" + cplb + "%")
        };

                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

  
        public List<MingXiItem> getCpMingXi2(string sp_dm, string cplb, string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"select mx.sp_dm,mx.cpname,mx.cplb,
                             ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,
                             ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price 
                             from (select sp_dm,cpname,cplb from yh_jinxiaocun_tuihuomingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm 
                             where mx.sp_dm like @sp_dm and mx.cplb like @cplb";

                        var @params = new MySqlParameter[]{
                    new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value),
                    new MySqlParameter("@sp_dm", "%" + sp_dm + "%"),
                    new MySqlParameter("@cplb", "%" + cplb + "%")
                };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"SELECT mx.sp_dm,mx.cpname,mx.cplb,
                             ISNULL(rk.cpsl,0) as ruku_num,ISNULL(rk.cp_price,0) as ruku_price,
                             ISNULL(ck.cpsl,0) as chuku_num,ISNULL(ck.cp_price,0) as chuku_price 
                             FROM (SELECT sp_dm,cpname,cplb FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE gs_name = @gongxi GROUP BY sp_dm,cpname,cplb) as mx 
                             LEFT JOIN (SELECT sp_dm,SUM(cpsl) as cpsl,SUM(cpsl*cpsj) as cp_price FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE mxtype = '入库' AND gs_name = @gongxi GROUP BY sp_dm) as rk ON mx.sp_dm=rk.sp_dm 
                             LEFT JOIN (SELECT sp_dm,SUM(cpsl) as cpsl,SUM(cpsl*cpsj) as cp_price FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE mxtype = '出库' AND gs_name = @gongxi GROUP BY sp_dm) as ck ON ck.sp_dm=rk.sp_dm 
                             WHERE mx.sp_dm LIKE @sp_dm AND mx.cplb LIKE @cplb";

                        var @params = new System.Data.SqlClient.SqlParameter[]{
                    new System.Data.SqlClient.SqlParameter("@gongxi", gongsi ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@sp_dm", "%" + sp_dm + "%"),
                    new System.Data.SqlClient.SqlParameter("@cplb", "%" + cplb + "%")
                };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select mx.sp_dm,mx.cpname,mx.cplb,
                     ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,
                     ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price 
                     from (select sp_dm,cpname,cplb from yh_jinxiaocun_tuihuomingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm 
                     where mx.sp_dm like @sp_dm and mx.cplb like @cplb";

                var @params = new MySqlParameter[]{
            new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value),
            new MySqlParameter("@sp_dm", "%" + sp_dm + "%"),
            new MySqlParameter("@cplb", "%" + cplb + "%")
        };

                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

        //public List<MingXiItem> getCpMingXi_all(string gongsi)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var @params = new MySqlParameter[]{
        //            new MySqlParameter("@gongxi", gongsi)
        //        };
        //        string sql = "select mx.sp_dm,mx.cpname,mx.cplb,ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm";
        //        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
        //        return result.ToList();
        //    }
        //}
        public List<MingXiItem> getCpMingXi_all(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"select mx.sp_dm,mx.cpname,mx.cplb,
                     ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,
                     ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price 
                     from (select sp_dm,cpname,cplb from yh_jinxiaocun_tuihuomingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm";

                        var @params = new MySqlParameter[]{
                    new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
                };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server - 精确匹配类型
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"
        SELECT 
            mx.sp_dm, 
            mx.cpname, 
            mx.cplb,
            -- ruku_num 和 chuku_num 返回 int 类型
            CAST(ISNULL(rk.cpsl, 0) AS INT) as ruku_num, 
            -- ruku_price 和 chuku_price 返回 decimal 类型
            CAST(ISNULL(rk.cp_price, 0) AS DECIMAL(18,2)) as ruku_price,
            CAST(ISNULL(ck.cpsl, 0) AS INT) as chuku_num, 
            CAST(ISNULL(ck.cp_price, 0) AS DECIMAL(18,2)) as chuku_price 
        FROM 
            (SELECT sp_dm, cpname, cplb 
             FROM yh_jinxiaocun_tuihuomingxi_mssql 
             WHERE gs_name = @gongxi 
             GROUP BY sp_dm, cpname, cplb) as mx 
        LEFT JOIN (
            SELECT 
                sp_dm, 
                -- 内部计算使用 decimal，最终转换为对应类型
                SUM(CAST(ISNULL(cpsl, 0) AS DECIMAL(18,2))) as cpsl,
                SUM(CAST(ISNULL(cpsl, 0) AS DECIMAL(18,2)) * CAST(ISNULL(cpsj, 0) AS DECIMAL(18,2))) as cp_price 
            FROM yh_jinxiaocun_tuihuomingxi_mssql 
            WHERE mxtype = '入库' AND gs_name = @gongxi 
            GROUP BY sp_dm
        ) as rk ON mx.sp_dm = rk.sp_dm 
        LEFT JOIN (
            SELECT 
                sp_dm, 
                SUM(CAST(ISNULL(cpsl, 0) AS DECIMAL(18,2))) as cpsl,
                SUM(CAST(ISNULL(cpsl, 0) AS DECIMAL(18,2)) * CAST(ISNULL(cpsj, 0) AS DECIMAL(18,2))) as cp_price 
            FROM yh_jinxiaocun_tuihuomingxi_mssql 
            WHERE mxtype = '出库' AND gs_name = @gongxi 
            GROUP BY sp_dm
        ) as ck ON mx.sp_dm = ck.sp_dm";

                        var @params = new System.Data.SqlClient.SqlParameter[]{
            new System.Data.SqlClient.SqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
        };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select mx.sp_dm,mx.cpname,mx.cplb,
             ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,
             ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price 
             from (select sp_dm,cpname,cplb from yh_jinxiaocun_tuihuomingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_tuihuomingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm";

                var @params = new MySqlParameter[]{
            new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
        };

                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

        public List<yh_jinxiaocun_tuihuomingxi> getShouHuoMingXi(string gsname)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select shou_h from yh_jinxiaocun_tuihuomingxi where shou_h != '' and gs_name = @gsname group by shou_h";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, new MySqlParameter("@gsname", gsname));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "SELECT shou_h FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE shou_h != '' AND gs_name = @gsname GROUP BY shou_h";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, new System.Data.SqlClient.SqlParameter("@gsname", gsname));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select shou_h from yh_jinxiaocun_tuihuomingxi where shou_h != '' and gs_name = @gsname group by shou_h";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, new MySqlParameter("@gsname", gsname));
                return result.ToList();
            }
        }

      
        public List<MingXiItem> getChMingxi(string shouhuo, string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"select shou_h,sp_dm,cpname,cplb,
                             ifnull(sum(cpsl),0) as ruku_num,ifnull(sum(cpsl*cpsj),0) as ruku_price 
                             from yh_jinxiaocun_tuihuomingxi 
                             where gs_name = @gongxi 
                             group by shou_h,sp_dm,cpname,cplb 
                             having shou_h != '' and shou_h = @shouhuo";

                        var @params = new MySqlParameter[]{
                    new MySqlParameter("@shouhuo", shouhuo ?? (object)DBNull.Value),
                    new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
                };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"SELECT shou_h,sp_dm,cpname,cplb,
                             ISNULL(SUM(cpsl),0) as ruku_num,ISNULL(SUM(cpsl*cpsj),0) as ruku_price 
                             FROM yh_jinxiaocun_tuihuomingxi_mssql 
                             WHERE gs_name = @gongxi 
                             GROUP BY shou_h,sp_dm,cpname,cplb 
                             HAVING shou_h != '' AND shou_h = @shouhuo";

                        var @params = new System.Data.SqlClient.SqlParameter[]{
                    new System.Data.SqlClient.SqlParameter("@shouhuo", shouhuo ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
                };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select shou_h,sp_dm,cpname,cplb,
                     ifnull(sum(cpsl),0) as ruku_num,ifnull(sum(cpsl*cpsj),0) as ruku_price 
                     from yh_jinxiaocun_tuihuomingxi 
                     where gs_name = @gongxi 
                     group by shou_h,sp_dm,cpname,cplb 
                     having shou_h != '' and shou_h = @shouhuo";

                var @params = new MySqlParameter[]{
            new MySqlParameter("@shouhuo", shouhuo ?? (object)DBNull.Value),
            new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
        };

                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

      
        public List<MingXiItem> getChMingxi_all(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"select shou_h,sp_dm,cpname,cplb,
                     ifnull(sum(cpsl),0) as ruku_num,ifnull(sum(cpsl*cpsj),0) as ruku_price 
                     from yh_jinxiaocun_tuihuomingxi 
                     where gs_name = @gongxi 
                     group by shou_h,sp_dm,cpname,cplb 
                     having shou_h != '' 
                     order by shou_h";

                        var @params = new MySqlParameter[]{
                    new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
                };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server - 精确匹配类型
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"SELECT shou_h,sp_dm,cpname,cplb,
             -- ruku_num 返回 int 类型
             CAST(ISNULL(SUM(CASE 
                 WHEN cpsl IS NULL OR cpsl = '' THEN 0
                 WHEN ISNUMERIC(cpsl) = 1 THEN CAST(cpsl AS DECIMAL(18,2))
                 ELSE 0
             END), 0) AS INT) as ruku_num,
             -- ruku_price 返回 decimal 类型
             CAST(ISNULL(SUM(CASE 
                 WHEN cpsl IS NULL OR cpsl = '' OR cpsj IS NULL OR cpsj = '' THEN 0
                 WHEN ISNUMERIC(cpsl) = 1 AND ISNUMERIC(cpsj) = 1 THEN 
                     CAST(cpsl AS DECIMAL(18,2)) * CAST(cpsj AS DECIMAL(18,2))
                 ELSE 0
             END), 0) AS DECIMAL(18,2)) as ruku_price 
             FROM yh_jinxiaocun_tuihuomingxi_mssql 
             WHERE gs_name = @gongxi 
             GROUP BY shou_h,sp_dm,cpname,cplb 
             HAVING shou_h != '' 
             ORDER BY shou_h";

                        var @params = new System.Data.SqlClient.SqlParameter[]{
                    new System.Data.SqlClient.SqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
                };

                        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select shou_h,sp_dm,cpname,cplb,
             ifnull(sum(cpsl),0) as ruku_num,ifnull(sum(cpsl*cpsj),0) as ruku_price 
             from yh_jinxiaocun_tuihuomingxi 
             where gs_name = @gongxi 
             group by shou_h,sp_dm,cpname,cplb 
             having shou_h != '' 
             order by shou_h";

                var @params = new MySqlParameter[]{
            new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
        };

                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

        public int del_mingxi(int cpid)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = "DELETE FROM yh_jinxiaocun_tuihuomingxi WHERE id = @cpid";
                        return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@cpid", cpid));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名不同
                        string sql = "DELETE FROM yh_jinxiaocun_tuihuomingxi_mssql WHERE id = @cpid";
                        return sen.Database.ExecuteSqlCommand(sql, new System.Data.SqlClient.SqlParameter("@cpid", cpid));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "DELETE FROM yh_jinxiaocun_tuihuomingxi WHERE id = @cpid";
                return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@cpid", cpid));
            }
        }

        public int update(List<yh_jinxiaocun_tuihuomingxi> list)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        int affectedRows = 0;
                        foreach (yh_jinxiaocun_tuihuomingxi item in list)
                        {
                            string sql = @"update yh_jinxiaocun_tuihuomingxi 
                             set orderid = @orderid, sp_dm = @sp_dm, cpname = @cpname, 
                                 cplb = @cplb, cpsj = @cpsj, cpsl = @cpsl, 
                                 mxtype = @mxtype, shou_h = @shou_h, 
                                 cangku = @cangku, ruku = @ruku 
                             where id = @id";

                            var parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("@orderid", item.orderid ?? (object)DBNull.Value),
                        new MySqlParameter("@sp_dm", item.sp_dm ?? (object)DBNull.Value),
                        new MySqlParameter("@cpname", item.cpname ?? (object)DBNull.Value),
                        new MySqlParameter("@cplb", item.cplb ?? (object)DBNull.Value),
                        new MySqlParameter("@cpsj", item.cpsj ?? (object)DBNull.Value),
                        new MySqlParameter("@cpsl", item.cpsl ?? (object)DBNull.Value),
                        new MySqlParameter("@mxtype", item.mxtype ?? (object)DBNull.Value),
                        new MySqlParameter("@shou_h", item.shou_h ?? (object)DBNull.Value),
                        new MySqlParameter("@cangku", item.cangku ?? (object)DBNull.Value),
                        new MySqlParameter("@ruku", item.ruku ?? (object)DBNull.Value),
                        new MySqlParameter("@id", item.id)
                    };

                            affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                        }
                        return affectedRows;
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        int affectedRows = 0;
                        foreach (yh_jinxiaocun_tuihuomingxi item in list)
                        {
                            string sql = @"update yh_jinxiaocun_tuihuomingxi 
                             set orderid = @orderid, sp_dm = @sp_dm, cpname = @cpname, 
                                 cplb = @cplb, cpsj = @cpsj, cpsl = @cpsl, 
                                 mxtype = @mxtype, shou_h = @shou_h, 
                                 cangku = @cangku, ruku = @ruku 
                             where id = @id";

                            var parameters = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@orderid", item.orderid ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@sp_dm", item.sp_dm ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cpname", item.cpname ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cplb", item.cplb ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cpsj", item.cpsj ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cpsl", item.cpsl ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@mxtype", item.mxtype ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@shou_h", item.shou_h ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cangku", item.cangku ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@ruku", item.ruku ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@id", item.id)
                    };

                            affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                        }
                        return affectedRows;
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                int affectedRows = 0;
                foreach (yh_jinxiaocun_tuihuomingxi item in list)
                {
                    string sql = @"update yh_jinxiaocun_tuihuomingxi 
                             set orderid = @orderid, sp_dm = @sp_dm, cpname = @cpname, 
                                 cplb = @cplb, cpsj = @cpsj, cpsl = @cpsl, 
                                 mxtype = @mxtype, shou_h = @shou_h, 
                                 cangku = @cangku, ruku = @ruku 
                             where id = @id";

                    var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@orderid", item.orderid ?? (object)DBNull.Value),
                new MySqlParameter("@sp_dm", item.sp_dm ?? (object)DBNull.Value),
                new MySqlParameter("@cpname", item.cpname ?? (object)DBNull.Value),
                new MySqlParameter("@cplb", item.cplb ?? (object)DBNull.Value),
                new MySqlParameter("@cpsj", item.cpsj ?? (object)DBNull.Value),
                new MySqlParameter("@cpsl", item.cpsl ?? (object)DBNull.Value),
                new MySqlParameter("@mxtype", item.mxtype ?? (object)DBNull.Value),
                new MySqlParameter("@shou_h", item.shou_h ?? (object)DBNull.Value),
                new MySqlParameter("@cangku", item.cangku ?? (object)DBNull.Value),
                new MySqlParameter("@ruku", item.ruku ?? (object)DBNull.Value),
                new MySqlParameter("@id", item.id)
            };

                    affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                }
                return affectedRows;
            }
        }

        // 获取所有销售退货数据（带基本筛选）
        public List<yh_jinxiaocun_tuihuomingxi> GetAllSalesReturns(string gongsi, string startDate = null, string endDate = null)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 构建基本查询
                        string sql = @"
                        SELECT * 
                        FROM yh_jinxiaocun_tuihuomingxi 
                        WHERE gs_name = @gongsi 
                        AND mxtype = '销售退货'";

                        var parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@gongsi", gongsi)
                    };

                        // 添加日期筛选
                        if (!string.IsNullOrEmpty(startDate))
                        {
                            sql += " AND DATE(shijian) >= @startDate";
                            parameters.Add(new MySqlParameter("@startDate", startDate));
                        }

                        if (!string.IsNullOrEmpty(endDate))
                        {
                            sql += " AND DATE(shijian) <= @endDate";
                            parameters.Add(new MySqlParameter("@endDate", endDate));
                        }

                        sql += " ORDER BY shijian DESC";

                        return sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters.ToArray()).ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 构建基本查询
                        string sql = @"
                        SELECT * 
                        FROM yh_jinxiaocun_tuihuomingxi 
                        WHERE gs_name = @gongsi 
                        AND mxtype = '销售退货'";

                        var parameters = new List<System.Data.SqlClient.SqlParameter>
                    {
                        new System.Data.SqlClient.SqlParameter("@gongsi", gongsi)
                    };

                        // 添加日期筛选
                        if (!string.IsNullOrEmpty(startDate))
                        {
                            sql += " AND CONVERT(date, shijian) >= @startDate";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@startDate", startDate));
                        }

                        if (!string.IsNullOrEmpty(endDate))
                        {
                            sql += " AND CONVERT(date, shijian) <= @endDate";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@endDate", endDate));
                        }

                        sql += " ORDER BY shijian DESC";

                        return sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters.ToArray()).ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"
                SELECT * 
                FROM yh_jinxiaocun_tuihuomingxi 
                WHERE gs_name = @gongsi 
                AND mxtype = '销售退货'";

                var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@gongsi", gongsi)
            };

                if (!string.IsNullOrEmpty(startDate))
                {
                    sql += " AND DATE(shijian) >= @startDate";
                    parameters.Add(new MySqlParameter("@startDate", startDate));
                }

                if (!string.IsNullOrEmpty(endDate))
                {
                    sql += " AND DATE(shijian) <= @endDate";
                    parameters.Add(new MySqlParameter("@endDate", endDate));
                }

                sql += " ORDER BY shijian DESC";

                return sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters.ToArray()).ToList();
            }
        }

        // 获取所有采购退货数据（带基本筛选）
        public List<yh_jinxiaocun_tuihuomingxi> GetAllSalesReturnsCG(string gongsi, string startDate = null, string endDate = null)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 构建基本查询
                        string sql = @"
                        SELECT * 
                        FROM yh_jinxiaocun_tuihuomingxi 
                        WHERE gs_name = @gongsi 
                        AND mxtype = '采购退货'";

                        var parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@gongsi", gongsi)
                    };

                        // 添加日期筛选
                        if (!string.IsNullOrEmpty(startDate))
                        {
                            sql += " AND DATE(shijian) >= @startDate";
                            parameters.Add(new MySqlParameter("@startDate", startDate));
                        }

                        if (!string.IsNullOrEmpty(endDate))
                        {
                            sql += " AND DATE(shijian) <= @endDate";
                            parameters.Add(new MySqlParameter("@endDate", endDate));
                        }

                        sql += " ORDER BY shijian DESC";

                        return sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters.ToArray()).ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 构建基本查询
                        string sql = @"
                        SELECT * 
                        FROM yh_jinxiaocun_tuihuomingxi 
                        WHERE gs_name = @gongsi 
                        AND mxtype = '采购退货'";

                        var parameters = new List<System.Data.SqlClient.SqlParameter>
                    {
                        new System.Data.SqlClient.SqlParameter("@gongsi", gongsi)
                    };

                        // 添加日期筛选
                        if (!string.IsNullOrEmpty(startDate))
                        {
                            sql += " AND CONVERT(date, shijian) >= @startDate";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@startDate", startDate));
                        }

                        if (!string.IsNullOrEmpty(endDate))
                        {
                            sql += " AND CONVERT(date, shijian) <= @endDate";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@endDate", endDate));
                        }

                        sql += " ORDER BY shijian DESC";

                        return sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters.ToArray()).ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"
                SELECT * 
                FROM yh_jinxiaocun_tuihuomingxi 
                WHERE gs_name = @gongsi 
                AND mxtype = '采购退货'";

                var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@gongsi", gongsi)
            };

                if (!string.IsNullOrEmpty(startDate))
                {
                    sql += " AND DATE(shijian) >= @startDate";
                    parameters.Add(new MySqlParameter("@startDate", startDate));
                }

                if (!string.IsNullOrEmpty(endDate))
                {
                    sql += " AND DATE(shijian) <= @endDate";
                    parameters.Add(new MySqlParameter("@endDate", endDate));
                }

                sql += " ORDER BY shijian DESC";

                return sen.Database.SqlQuery<yh_jinxiaocun_tuihuomingxi>(sql, parameters.ToArray()).ToList();
            }
        }

    }
}