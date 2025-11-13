using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.JxcServer;

namespace Web.Server
{
    public class UserModel
    {

        public List<string> selectCompanys()
        {
            //if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            //{
            //    int shujukuValue = (int)HttpContext.Current.Session["shujuku"];
            //    if (shujukuValue != 0)
            //    {
                   
            //    }
            //}

            //using (ServerEntities sen = new ServerEntities())
            //{
            //    string sql = "select gongsi from yh_jinxiaocun_user group by gongsi";
            //    var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql);
            //    List<yh_jinxiaocun_user> userList = result.ToList();
            //    List<string> companys = new List<string>();
            //    foreach (var user in userList)
            //    {
            //        companys.Add(user.gongsi);
            //    }
            //    return companys;
            //}

            using (ServerEntities sen = new ServerEntities())
            {
                // 第一个查询：从 yh_jinxiaocun_user 表
                string sql1 = "select gongsi from yh_jinxiaocun_user group by gongsi";
                var result1 = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql1);
                List<yh_jinxiaocun_user> userList1 = result1.ToList();

                List<string> companys = new List<string>();
                foreach (var user in userList1)
                {
                    if (!string.IsNullOrEmpty(user.gongsi))
                    {
                        companys.Add(user.gongsi);
                    }
                }

                // 第二个查询：使用 Entity Framework 查询另一个数据库
                using (yh_jinxiaocun_excelEntities3 sen2 = new yh_jinxiaocun_excelEntities3())
                {
                    string sql2 = "select gongsi from yh_jinxiaocun_user_mssql group by gongsi";
                    var result2 = sen2.Database.SqlQuery<string>(sql2);  // 直接查询字符串
                    List<string> companys2 = result2.ToList();

                    foreach (string gongsi in companys2)
                    {
                        if (!string.IsNullOrEmpty(gongsi) && !companys.Contains(gongsi))
                        {
                            companys.Add(gongsi);
                        }
                    }
                }

                return companys;
            }
        }

        //public yh_jinxiaocun_user login(string gongsi, string username, string pwd)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var @params = new MySqlParameter[]
        //        {
        //            new MySqlParameter("@gongsi", gongsi),
        //            new MySqlParameter("@username", username),
        //            new MySqlParameter("@pwd", pwd)
        //        };

        //        string sql = "select * from yh_jinxiaocun_user where gongsi = @gongsi and `name` = @username and `password` = @pwd";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql, @params);
        //        List<yh_jinxiaocun_user> list = result.ToList();
        //        return list.Count == 0 ? null : list[0];
        //    }
        //}

        public yh_jinxiaocun_user login(string gongsi, string username, string pwd)
        {
            
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0)
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var @params = new MySqlParameter[]
                    {
                        new MySqlParameter("@gongsi", gongsi),
                        new MySqlParameter("@username", username),
                        new MySqlParameter("@pwd", pwd)
                    };

                        string sql = "select * from yh_jinxiaocun_user where gongsi = @gongsi and `name` = @username and `password` = @pwd";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql, @params);
                        List<yh_jinxiaocun_user> list = result.ToList();
                        return list.Count == 0 ? null : list[0];
                    }
                }
                else if (shujukuValue == 1)
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var @params = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@gongsi", gongsi),
                        new System.Data.SqlClient.SqlParameter("@username", username),
                        new System.Data.SqlClient.SqlParameter("@pwd", pwd)
                    };

                        string sql = "SELECT * FROM yh_jinxiaocun_user_mssql WHERE gongsi = @gongsi AND name = @username AND password = @pwd";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql, @params);
                        List<yh_jinxiaocun_user> list = result.ToList();
                        return list.Count == 0 ? null : list[0];
                    }
                }
            }

             return null;
        }




        //public List<yh_jinxiaocun_user> getList(string gongsi) {
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select * from yh_jinxiaocun_user where gongsi = '" + gongsi + "'";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql);
        //        return result.ToList();
        //    }
        //}

        public List<yh_jinxiaocun_user> getList(string gongsi)
        {

            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];
                if (shujukuValue == 0)
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select * from yh_jinxiaocun_user where gongsi = '" + gongsi + "'";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql);
                        return result.ToList();
                    }

                }
                else if (shujukuValue == 1)
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 参数化查询，避免SQL注入
                        string sql = "SELECT * FROM yh_jinxiaocun_user_mssql WHERE gongsi = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql, new System.Data.SqlClient.SqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                
                }
            }
            return new List<yh_jinxiaocun_user>();
        }


        //public List<yh_jinxiaocun_user> getUserNum(string gongsi)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select count(_id) as _id from yh_jinxiaocun_user where gongsi = '" + gongsi + "'";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql);
        //        return result.ToList();
        //    }
        //}

        public List<yh_jinxiaocun_user> getUserNum(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = "select count(_id) as _id from yh_jinxiaocun_user where gongsi = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql, new MySqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名不同
                        string sql = "SELECT count(_id) as _id FROM yh_jinxiaocun_user_mssql WHERE gongsi = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql, new System.Data.SqlClient.SqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
            }

            // 默认返回空列表或使用默认数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select count(_id) as _id from yh_jinxiaocun_user where gongsi = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql, new MySqlParameter("@gongsi", gongsi));
                return result.ToList();
            }
        }

        //public int delete(string id)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "delete from yh_jinxiaocun_user where _id = '" + id + "'";
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}

        public int delete(string id)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = "delete from yh_jinxiaocun_user where _id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名不同
                        string sql = "DELETE FROM yh_jinxiaocun_user_mssql WHERE _id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new System.Data.SqlClient.SqlParameter("@id", id));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "delete from yh_jinxiaocun_user where _id = @id";
                return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
            }
        }

        //public int add(yh_jinxiaocun_user user) {
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "insert into yh_jinxiaocun_user(name,password,_id,gongsi,AdminIS,Btype) values('" + user.name + "','" + user.password + "','" + user._id + "','" + user.gongsi + "','" + user.AdminIS + "','" + user.Btype + "')";
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int add(yh_jinxiaocun_user user)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = @"insert into yh_jinxiaocun_user(name, password, _id, gongsi, AdminIS, Btype) 
                              values(@name, @password, @_id, @gongsi, @AdminIS, @Btype)";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@name", user.name),
                    new MySqlParameter("@password", user.password),
                    new MySqlParameter("@_id", user._id),
                    new MySqlParameter("@gongsi", user.gongsi),
                    new MySqlParameter("@AdminIS", user.AdminIS),
                    new MySqlParameter("@Btype", user.Btype)
                };

                        return sen.Database.ExecuteSqlCommand(sql, parameters);
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名不同
                        string sql = @"INSERT INTO yh_jinxiaocun_user_mssql(name, password, _id, gongsi, AdminIS, Btype) 
                              VALUES(@name, @password, @_id, @gongsi, @AdminIS, @Btype)";

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@name", user.name),
                    new System.Data.SqlClient.SqlParameter("@password", user.password),
                    new System.Data.SqlClient.SqlParameter("@_id", user._id),
                    new System.Data.SqlClient.SqlParameter("@gongsi", user.gongsi),
                    new System.Data.SqlClient.SqlParameter("@AdminIS", user.AdminIS),
                    new System.Data.SqlClient.SqlParameter("@Btype", user.Btype)
                };

                        return sen.Database.ExecuteSqlCommand(sql, parameters);
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"insert into yh_jinxiaocun_user(name, password, _id, gongsi, AdminIS, Btype) 
                      values(@name, @password, @_id, @gongsi, @AdminIS, @Btype)";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@name", user.name),
            new MySqlParameter("@password", user.password),
            new MySqlParameter("@_id", user._id),
            new MySqlParameter("@gongsi", user.gongsi),
            new MySqlParameter("@AdminIS", user.AdminIS),
            new MySqlParameter("@Btype", user.Btype)
        };

                return sen.Database.ExecuteSqlCommand(sql, parameters);
            }
        }
        //public int update(yh_jinxiaocun_user user)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "update yh_jinxiaocun_user set name = '" + user.name + "',password = '" + user.password + "',gongsi = '" + user.gongsi + "',AdminIS = '" + user.AdminIS + "' where _id = '"+user._id+"'";
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}

        public int update(yh_jinxiaocun_user user)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = @"update yh_jinxiaocun_user 
                              set name = @name, password = @password, gongsi = @gongsi, AdminIS = @AdminIS 
                              where _id = @_id";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@name", user.name),
                    new MySqlParameter("@password", user.password),
                    new MySqlParameter("@gongsi", user.gongsi),
                    new MySqlParameter("@AdminIS", user.AdminIS),
                    new MySqlParameter("@_id", user._id)
                };

                        return sen.Database.ExecuteSqlCommand(sql, parameters);
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名不同
                        string sql = @"UPDATE yh_jinxiaocun_user_mssql 
                              SET name = @name, password = @password, gongsi = @gongsi, AdminIS = @AdminIS 
                              WHERE _id = @_id";

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@name", user.name),
                    new System.Data.SqlClient.SqlParameter("@password", user.password),
                    new System.Data.SqlClient.SqlParameter("@gongsi", user.gongsi),
                    new System.Data.SqlClient.SqlParameter("@AdminIS", user.AdminIS),
                    new System.Data.SqlClient.SqlParameter("@_id", user._id)
                };

                        return sen.Database.ExecuteSqlCommand(sql, parameters);
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"update yh_jinxiaocun_user 
                      set name = @name, password = @password, gongsi = @gongsi, AdminIS = @AdminIS 
                      where _id = @_id";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@name", user.name),
            new MySqlParameter("@password", user.password),
            new MySqlParameter("@gongsi", user.gongsi),
            new MySqlParameter("@AdminIS", user.AdminIS),
            new MySqlParameter("@_id", user._id)
        };

                return sen.Database.ExecuteSqlCommand(sql, parameters);
            }
        }
    }
}
