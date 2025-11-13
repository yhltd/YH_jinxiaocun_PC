using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.JxcServer;
using MySql.Data.MySqlClient; 

namespace Web.Server
{
    public class ZhengLiModel
    {

        //public List<yh_jinxiaocun_zhengli> getList(string gongsi)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    { 
        //        string sql = "select * from yh_jinxiaocun_zhengli where gs_name = '" + gongsi + "'";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_zhengli>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_zhengli> getList(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = "select * from yh_jinxiaocun_zhengli where gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_zhengli>(sql, new MySqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名可能需要调整
                        string sql = "SELECT * FROM yh_jinxiaocun_zhengli_mssql WHERE gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_zhengli>(sql, new System.Data.SqlClient.SqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_zhengli where gs_name = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_zhengli>(sql, new MySqlParameter("@gongsi", gongsi));
                return result.ToList();
            }
        }

        //public List<yh_jinxiaocun_zhengli> getList_chaxun(string gongsi,string name)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select * from yh_jinxiaocun_zhengli where gs_name = '" + gongsi + "' and name like '%"+ name +"%'";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_zhengli>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_zhengli> getList_chaxun(string gongsi, string name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = "select * from yh_jinxiaocun_zhengli where gs_name = @gongsi and name like @name";
                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@gongsi", gongsi),
                    new MySqlParameter("@name", "%" + name + "%")
                };
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_zhengli>(sql, parameters);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名可能需要调整
                        string sql = "SELECT * FROM yh_jinxiaocun_zhengli_mssql WHERE gs_name = @gongsi and name like @name";
                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@gongsi", gongsi),
                    new System.Data.SqlClient.SqlParameter("@name", "%" + name + "%")
                };
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_zhengli>(sql, parameters);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_zhengli where gs_name = @gongsi and name like @name";
                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@gongsi", gongsi),
            new MySqlParameter("@name", "%" + name + "%")
        };
                var result = sen.Database.SqlQuery<yh_jinxiaocun_zhengli>(sql, parameters);
                return result.ToList();
            }
        }

        //public int delete(int id) {
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "delete from yh_jinxiaocun_zhengli where id = '"+ id +"'";
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int delete(int id)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = "delete from yh_jinxiaocun_zhengli where id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名可能需要调整
                        string sql = "DELETE FROM yh_jinxiaocun_zhengli_mssql WHERE id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new System.Data.SqlClient.SqlParameter("@id", id));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "delete from yh_jinxiaocun_zhengli where id = @id";
                return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
            }
        }

        //public int add(List<yh_jinxiaocun_zhengli> list)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "";
        //        foreach (yh_jinxiaocun_zhengli item in list)
        //        {
        //            sql += "insert into Yh_JinXiaoCun_zhengli(sp_dm,name,lei_bie,dan_wei,zh_name,gs_name,beizhu) values ('" + item.sp_dm + "','" + item.name + "','" + item.lei_bie + "','" + item.dan_wei + "','" + item.zh_name + "','" + item.gs_name + "','" + item.beizhu + "');";
        //        }
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int add(List<yh_jinxiaocun_zhengli> list)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        int affectedRows = 0;
                        foreach (yh_jinxiaocun_zhengli item in list)
                        {
                            string sql = "insert into yh_jinxiaocun_zhengli(sp_dm, name, lei_bie, dan_wei, zh_name, gs_name, beizhu) " +
                                         "values (@sp_dm, @name, @lei_bie, @dan_wei, @zh_name, @gs_name, @beizhu)";

                            var parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("@sp_dm", item.sp_dm ?? (object)DBNull.Value),
                        new MySqlParameter("@name", item.name ?? (object)DBNull.Value),
                        new MySqlParameter("@lei_bie", item.lei_bie ?? (object)DBNull.Value),
                        new MySqlParameter("@dan_wei", item.dan_wei ?? (object)DBNull.Value),
                        new MySqlParameter("@zh_name", item.zh_name ?? (object)DBNull.Value),
                        new MySqlParameter("@gs_name", item.gs_name ?? (object)DBNull.Value),
                        new MySqlParameter("@beizhu", item.beizhu ?? (object)DBNull.Value)
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
                        foreach (yh_jinxiaocun_zhengli item in list)
                        {
                            string sql = "INSERT INTO yh_jinxiaocun_zhengli_mssql(sp_dm, name, lei_bie, dan_wei, zh_name, gs_name, beizhu) " +
                                         "VALUES (@sp_dm, @name, @lei_bie, @dan_wei, @zh_name, @gs_name, @beizhu)";

                            var parameters = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@sp_dm", item.sp_dm ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@name", item.name ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@lei_bie", item.lei_bie ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@dan_wei", item.dan_wei ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@zh_name", item.zh_name ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@gs_name", item.gs_name ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@beizhu", item.beizhu ?? (object)DBNull.Value)
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
                foreach (yh_jinxiaocun_zhengli item in list)
                {
                    string sql = "insert into yh_jinxiaocun_zhengli(sp_dm, name, lei_bie, dan_wei, zh_name, gs_name, beizhu) " +
                                 "values (@sp_dm, @name, @lei_bie, @dan_wei, @zh_name, @gs_name, @beizhu)";

                    var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@sp_dm", item.sp_dm ?? (object)DBNull.Value),
                new MySqlParameter("@name", item.name ?? (object)DBNull.Value),
                new MySqlParameter("@lei_bie", item.lei_bie ?? (object)DBNull.Value),
                new MySqlParameter("@dan_wei", item.dan_wei ?? (object)DBNull.Value),
                new MySqlParameter("@zh_name", item.zh_name ?? (object)DBNull.Value),
                new MySqlParameter("@gs_name", item.gs_name ?? (object)DBNull.Value),
                new MySqlParameter("@beizhu", item.beizhu ?? (object)DBNull.Value)
            };

                    affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                }
                return affectedRows;
            }
        }

        //public int update(string sp_dm, string name, string lei_bie, string dan_wei, string bei_zhu, string id)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "UPDATE Yh_JinXiaoCun_zhengli SET sp_dm = '" + sp_dm + "',name = '" + name + "',lei_bie = '" + lei_bie + "',beizhu = '" + bei_zhu + "' ,dan_wei = '" + dan_wei + "' WHERE id = '" + id + "'";
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int update(string sp_dm, string name, string lei_bie, string dan_wei, string bei_zhu, string id)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = "UPDATE yh_jinxiaocun_zhengli SET sp_dm = @sp_dm, name = @name, lei_bie = @lei_bie, beizhu = @beizhu, dan_wei = @dan_wei WHERE id = @id";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@sp_dm", sp_dm ?? (object)DBNull.Value),
                    new MySqlParameter("@name", name ?? (object)DBNull.Value),
                    new MySqlParameter("@lei_bie", lei_bie ?? (object)DBNull.Value),
                    new MySqlParameter("@dan_wei", dan_wei ?? (object)DBNull.Value),
                    new MySqlParameter("@beizhu", bei_zhu ?? (object)DBNull.Value),
                    new MySqlParameter("@id", id ?? (object)DBNull.Value)
                };

                        return sen.Database.ExecuteSqlCommand(sql, parameters);
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名可能需要调整
                        string sql = "UPDATE yh_jinxiaocun_zhengli_mssql SET sp_dm = @sp_dm, name = @name, lei_bie = @lei_bie, beizhu = @beizhu, dan_wei = @dan_wei WHERE id = @id";

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@sp_dm", sp_dm ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@name", name ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@lei_bie", lei_bie ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@dan_wei", dan_wei ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@beizhu", bei_zhu ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@id", id ?? (object)DBNull.Value)
                };

                        return sen.Database.ExecuteSqlCommand(sql, parameters);
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE yh_jinxiaocun_zhengli SET sp_dm = @sp_dm, name = @name, lei_bie = @lei_bie, beizhu = @beizhu, dan_wei = @dan_wei WHERE id = @id";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@sp_dm", sp_dm ?? (object)DBNull.Value),
            new MySqlParameter("@name", name ?? (object)DBNull.Value),
            new MySqlParameter("@lei_bie", lei_bie ?? (object)DBNull.Value),
            new MySqlParameter("@dan_wei", dan_wei ?? (object)DBNull.Value),
            new MySqlParameter("@beizhu", bei_zhu ?? (object)DBNull.Value),
            new MySqlParameter("@id", id ?? (object)DBNull.Value)
        };

                return sen.Database.ExecuteSqlCommand(sql, parameters);
            }
        }
    }
}