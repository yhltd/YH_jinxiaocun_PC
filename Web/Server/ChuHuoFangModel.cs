using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.JxcServer;
using MySql.Data.MySqlClient;


namespace Web.Server
{
    public class ChuHuoFangModel
    {
        

        //public List<yh_jinxiaocun_chuhuofang> getList(string gongsi)
        //{
        //    if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
        //    {
        //        int shujukuValue = (int)HttpContext.Current.Session["shujuku"];
        //        if (shujukuValue != 1)
        //        {
        //            throw new UnauthorizedAccessException("没有数据库访问权限");
        //        }
        //    }
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select * from yh_jinxiaocun_chuhuofang where gongsi = '" + gongsi + "'";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_chuhuofang> getList(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select * from yh_jinxiaocun_chuhuofang where gongsi = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql, new MySqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "select * from yh_jinxiaocun_chuhuofang_mssql where gongsi = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql, new System.Data.SqlClient.SqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_chuhuofang where gongsi = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql, new MySqlParameter("@gongsi", gongsi));
                return result.ToList();
            }
        }

        //public List<yh_jinxiaocun_chuhuofang> getList_chaxun(string gongsi,string beizhu)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select * from yh_jinxiaocun_chuhuofang where gongsi = '" + gongsi + "' and beizhu like '%"+ beizhu +"%'";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_chuhuofang> getList_chaxun(string gongsi, string beizhu)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select * from yh_jinxiaocun_chuhuofang where gongsi = @gongsi and beizhu like @beizhu";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql,
                            new MySqlParameter("@gongsi", gongsi),
                            new MySqlParameter("@beizhu", "%" + beizhu + "%"));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "select * from yh_jinxiaocun_chuhuofang_mssql where gongsi = @gongsi and beizhu like @beizhu";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql,
                            new System.Data.SqlClient.SqlParameter("@gongsi", gongsi),
                            new System.Data.SqlClient.SqlParameter("@beizhu", "%" + beizhu + "%"));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_chuhuofang where gongsi = @gongsi and beizhu like @beizhu";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql,
                    new MySqlParameter("@gongsi", gongsi),
                    new MySqlParameter("@beizhu", "%" + beizhu + "%"));
                return result.ToList();
            }
        }

        //public int delete(int id)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "delete from yh_jinxiaocun_chuhuofang where _id = '" + id + "'";
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
                        string sql = "delete from yh_jinxiaocun_chuhuofang where _id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "delete from yh_jinxiaocun_chuhuofang_mssql where _id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new System.Data.SqlClient.SqlParameter("@id", id));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "delete from yh_jinxiaocun_chuhuofang where _id = @id";
                return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
            }
        }

        //public int add(List<yh_jinxiaocun_chuhuofang> list)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "";
        //        foreach (yh_jinxiaocun_chuhuofang item in list)
        //        {
        //            sql += "insert into yh_jinxiaocun_chuhuofang(beizhu,lianxidizhi,lianxifangshi,finduser,gongsi) values ('" + item.beizhu + "','" + item.lianxidizhi + "','" + item.lianxifangshi + "','" + item.finduser + "','" + item.gongsi + "');";
        //        }
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int add(List<yh_jinxiaocun_chuhuofang> list)
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

                        foreach (yh_jinxiaocun_chuhuofang item in list)
                        {
                            sql += "insert into yh_jinxiaocun_chuhuofang(beizhu,lianxidizhi,lianxifangshi,finduser,gongsi) values (@beizhu" + paramIndex + ", @lianxidizhi" + paramIndex + ", @lianxifangshi" + paramIndex + ", @finduser" + paramIndex + ", @gongsi" + paramIndex + ");";

                            parameters.Add(new MySqlParameter("@beizhu" + paramIndex, item.beizhu ?? ""));
                            parameters.Add(new MySqlParameter("@lianxidizhi" + paramIndex, item.lianxidizhi ?? ""));
                            parameters.Add(new MySqlParameter("@lianxifangshi" + paramIndex, item.lianxifangshi ?? ""));
                            parameters.Add(new MySqlParameter("@finduser" + paramIndex, item.finduser ?? ""));
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

                        foreach (yh_jinxiaocun_chuhuofang item in list)
                        {
                            sql += "insert into yh_jinxiaocun_chuhuofang_mssql(beizhu,lianxidizhi,lianxifangshi,finduser,gongsi) values (@beizhu" + paramIndex + ", @lianxidizhi" + paramIndex + ", @lianxifangshi" + paramIndex + ", @finduser" + paramIndex + ", @gongsi" + paramIndex + ");";

                            parameters.Add(new System.Data.SqlClient.SqlParameter("@beizhu" + paramIndex, item.beizhu ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@lianxidizhi" + paramIndex, item.lianxidizhi ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@lianxifangshi" + paramIndex, item.lianxifangshi ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@finduser" + paramIndex, item.finduser ?? ""));
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

                foreach (yh_jinxiaocun_chuhuofang item in list)
                {
                    sql += "insert into yh_jinxiaocun_chuhuofang(beizhu,lianxidizhi,lianxifangshi,finduser,gongsi) values (@beizhu" + paramIndex + ", @lianxidizhi" + paramIndex + ", @lianxifangshi" + paramIndex + ", @finduser" + paramIndex + ", @gongsi" + paramIndex + ");";

                    parameters.Add(new MySqlParameter("@beizhu" + paramIndex, item.beizhu ?? ""));
                    parameters.Add(new MySqlParameter("@lianxidizhi" + paramIndex, item.lianxidizhi ?? ""));
                    parameters.Add(new MySqlParameter("@lianxifangshi" + paramIndex, item.lianxifangshi ?? ""));
                    parameters.Add(new MySqlParameter("@finduser" + paramIndex, item.finduser ?? ""));
                    parameters.Add(new MySqlParameter("@gongsi" + paramIndex, item.gongsi ?? ""));

                    paramIndex++;
                }

                return sen.Database.ExecuteSqlCommand(sql, parameters.ToArray());
            }
        }

        //public int update(string beizhu, string lianxidizhi, string lianxifangshi,string id)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "UPDATE yh_jinxiaocun_chuhuofang SET beizhu = '" + beizhu + "',lianxidizhi = '" + lianxidizhi + "',lianxifangshi = '" + lianxifangshi + "'  WHERE _id = '" + id + "'";
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int update(string beizhu, string lianxidizhi, string lianxifangshi, string id)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "UPDATE yh_jinxiaocun_chuhuofang SET beizhu = @beizhu, lianxidizhi = @lianxidizhi, lianxifangshi = @lianxifangshi WHERE _id = @id";
                        return sen.Database.ExecuteSqlCommand(sql,
                            new MySqlParameter("@beizhu", beizhu ?? ""),
                            new MySqlParameter("@lianxidizhi", lianxidizhi ?? ""),
                            new MySqlParameter("@lianxifangshi", lianxifangshi ?? ""),
                            new MySqlParameter("@id", id));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "UPDATE yh_jinxiaocun_chuhuofang_mssql SET beizhu = @beizhu, lianxidizhi = @lianxidizhi, lianxifangshi = @lianxifangshi WHERE _id = @id";
                        return sen.Database.ExecuteSqlCommand(sql,
                            new System.Data.SqlClient.SqlParameter("@beizhu", beizhu ?? ""),
                            new System.Data.SqlClient.SqlParameter("@lianxidizhi", lianxidizhi ?? ""),
                            new System.Data.SqlClient.SqlParameter("@lianxifangshi", lianxifangshi ?? ""),
                            new System.Data.SqlClient.SqlParameter("@id", id));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE yh_jinxiaocun_chuhuofang SET beizhu = @beizhu, lianxidizhi = @lianxidizhi, lianxifangshi = @lianxifangshi WHERE _id = @id";
                return sen.Database.ExecuteSqlCommand(sql,
                    new MySqlParameter("@beizhu", beizhu ?? ""),
                    new MySqlParameter("@lianxidizhi", lianxidizhi ?? ""),
                    new MySqlParameter("@lianxifangshi", lianxifangshi ?? ""),
                    new MySqlParameter("@id", id));
            }
        }
    }
}