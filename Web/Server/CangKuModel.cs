using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.JxcServer;
using MySql.Data.MySqlClient;

namespace Web.Server
{
    public class CangKuModel
    {
        // 获取仓库列表
        public List<yh_jinxiaocun_cangku> getList(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select * from yh_jinxiaocun_cangku where gongsi = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_cangku>(sql, new MySqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "select * from yh_jinxiaocun_cangku_mssql where gongsi = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_cangku>(sql, new System.Data.SqlClient.SqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_cangku where gongsi = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_cangku>(sql, new MySqlParameter("@gongsi", gongsi));
                return result.ToList();
            }
        }

        // 查询仓库
        public List<yh_jinxiaocun_cangku> getList_chaxun(string gongsi, string cangkuName)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select * from yh_jinxiaocun_cangku where gongsi = @gongsi and cangku like @cangku";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_cangku>(sql,
                            new MySqlParameter("@gongsi", gongsi),
                            new MySqlParameter("@cangku", "%" + cangkuName + "%"));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "select * from yh_jinxiaocun_cangku_mssql where gongsi = @gongsi and cangku like @cangku";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_cangku>(sql,
                            new System.Data.SqlClient.SqlParameter("@gongsi", gongsi),
                            new System.Data.SqlClient.SqlParameter("@cangku", "%" + cangkuName + "%"));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_cangku where gongsi = @gongsi and cangku like @cangku";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_cangku>(sql,
                    new MySqlParameter("@gongsi", gongsi),
                    new MySqlParameter("@cangku", "%" + cangkuName + "%"));
                return result.ToList();
            }
        }

        // 删除仓库
        public int delete(int id)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "delete from yh_jinxiaocun_cangku where id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "delete from yh_jinxiaocun_cangku_mssql where id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new System.Data.SqlClient.SqlParameter("@id", id));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "delete from yh_jinxiaocun_cangku where id = @id";
                return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
            }
        }

        // 添加仓库
        public int add(List<yh_jinxiaocun_cangku> list)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "";
                        var parameters = new List<MySqlParameter>();
                        int paramIndex = 0;

                        foreach (yh_jinxiaocun_cangku item in list)
                        {
                            sql += "insert into yh_jinxiaocun_cangku(cangku, gongsi) values (@cangku" + paramIndex + ", @gongsi" + paramIndex + ");";

                            parameters.Add(new MySqlParameter("@cangku" + paramIndex, item.cangku ?? ""));
                            parameters.Add(new MySqlParameter("@gongsi" + paramIndex, item.gongsi ?? ""));

                            paramIndex++;
                        }

                        return sen.Database.ExecuteSqlCommand(sql, parameters.ToArray());
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "";
                        var parameters = new List<System.Data.SqlClient.SqlParameter>();
                        int paramIndex = 0;

                        foreach (yh_jinxiaocun_cangku item in list)
                        {
                            sql += "insert into yh_jinxiaocun_cangku_mssql(cangku, gongsi) values (@cangku" + paramIndex + ", @gongsi" + paramIndex + ");";

                            parameters.Add(new System.Data.SqlClient.SqlParameter("@cangku" + paramIndex, item.cangku ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@gongsi" + paramIndex, item.gongsi ?? ""));

                            paramIndex++;
                        }

                        return sen.Database.ExecuteSqlCommand(sql, parameters.ToArray());
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "";
                var parameters = new List<MySqlParameter>();
                int paramIndex = 0;

                foreach (yh_jinxiaocun_cangku item in list)
                {
                    sql += "insert into yh_jinxiaocun_cangku(cangku, gongsi) values (@cangku" + paramIndex + ", @gongsi" + paramIndex + ");";

                    parameters.Add(new MySqlParameter("@cangku" + paramIndex, item.cangku ?? ""));
                    parameters.Add(new MySqlParameter("@gongsi" + paramIndex, item.gongsi ?? ""));

                    paramIndex++;
                }

                return sen.Database.ExecuteSqlCommand(sql, parameters.ToArray());
            }
        }

        // 更新仓库
        public int update(string cangku, string id, string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "UPDATE yh_jinxiaocun_cangku SET cangku = @cangku, gongsi = @gongsi WHERE id = @id";
                        return sen.Database.ExecuteSqlCommand(sql,
                            new MySqlParameter("@cangku", cangku ?? ""),
                            new MySqlParameter("@gongsi", gongsi ?? ""),
                            new MySqlParameter("@id", id));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "UPDATE yh_jinxiaocun_cangku_mssql SET cangku = @cangku, gongsi = @gongsi WHERE id = @id";
                        return sen.Database.ExecuteSqlCommand(sql,
                            new System.Data.SqlClient.SqlParameter("@cangku", cangku ?? ""),
                            new System.Data.SqlClient.SqlParameter("@gongsi", gongsi ?? ""),
                            new System.Data.SqlClient.SqlParameter("@id", id));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE yh_jinxiaocun_cangku SET cangku = @cangku, gongsi = @gongsi WHERE id = @id";
                return sen.Database.ExecuteSqlCommand(sql,
                    new MySqlParameter("@cangku", cangku ?? ""),
                    new MySqlParameter("@gongsi", gongsi ?? ""),
                    new MySqlParameter("@id", id));
            }
        }
    }
}