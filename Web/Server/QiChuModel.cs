using MySql.Data.MySqlClient;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.JxcServer;
using MySql.Data.MySqlClient; 

namespace Web.Server
{
    public class QiChuModel
    {

        //public List<yh_jinxiaocun_qichushu> getQiChu(string gs_name)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var gsParam = new MySqlParameter("@gs", gs_name);
        //        string sql = "select _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 from Yh_JinXiaoCun_qichushu left join (select sp_dm,mark1 from yh_jinxiaocun_jichuziliao) as pic on Yh_JinXiaoCun_qichushu.cpid = pic.sp_dm where gs_name = @gs";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, gsParam);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_qichushu> getQiChu(string gs_name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var gsParam = new MySqlParameter("@gs", gs_name);
                        string sql = @"select _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 
                             from yh_jinxiaocun_qichushu 
                             left join (select sp_dm,mark1 from yh_jinxiaocun_jichuziliao) as pic 
                             on yh_jinxiaocun_qichushu.cpid = pic.sp_dm 
                             where gs_name = @gs";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, gsParam);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var gsParam = new System.Data.SqlClient.SqlParameter("@gs", gs_name);
                        string sql = @"SELECT _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 
                             FROM yh_jinxiaocun_qichushu_mssql 
                             LEFT JOIN (SELECT sp_dm,mark1 FROM yh_jinxiaocun_jichuziliao_mssql) as pic 
                             ON yh_jinxiaocun_qichushu_mssql.cpid = pic.sp_dm 
                             WHERE gs_name = @gs";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, gsParam);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var gsParam = new MySqlParameter("@gs", gs_name);
                string sql = @"select _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 
                     from yh_jinxiaocun_qichushu 
                     left join (select sp_dm,mark1 from yh_jinxiaocun_jichuziliao) as pic 
                     on yh_jinxiaocun_qichushu.cpid = pic.sp_dm 
                     where gs_name = @gs";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, gsParam);
                return result.ToList();
            }
        }

        //public int add_qichu(List<qi_chu_info> qci)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "";
        //        foreach (qi_chu_info item in qci)
        //        {
        //            sql += "insert into Yh_JinXiaoCun_qichushu(_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name) values ('" + item.Openid + "','" + item.Cpid + "','" + item.Cpjg + "','" + item.Cpjj + "','" + item.Cplb + "','" + item.Cpname + "','" + item.Cpsj + "','" + item.Cpsl + "','" + item.Mxtype + "','" + item.Shijian + "','" + item.zh_name + "','" + item.gs_name + "');";
        //        }
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }

        //}


        public int add_qichu(List<qi_chu_info> qci)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        int affectedRows = 0;
                        foreach (qi_chu_info item in qci)
                        {
                            string sql = @"insert into yh_jinxiaocun_qichushu(_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name) 
                                 values (@_openid, @cpid, @cpjg, @cpjj, @cplb, @cpname, @cpsj, @cpsl, @mxtype, @shijian, @zh_name, @gs_name)";

                            var parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("@_openid", item.Openid ?? (object)DBNull.Value),
                        new MySqlParameter("@cpid", item.Cpid ?? (object)DBNull.Value),
                        new MySqlParameter("@cpjg", item.Cpjg ?? (object)DBNull.Value),
                        new MySqlParameter("@cpjj", item.Cpjj ?? (object)DBNull.Value),
                        new MySqlParameter("@cplb", item.Cplb ?? (object)DBNull.Value),
                        new MySqlParameter("@cpname", item.Cpname ?? (object)DBNull.Value),
                        new MySqlParameter("@cpsj", item.Cpsj ?? (object)DBNull.Value),
                        new MySqlParameter("@cpsl", item.Cpsl ?? (object)DBNull.Value),
                        new MySqlParameter("@mxtype", item.Mxtype ?? (object)DBNull.Value),
                        new MySqlParameter("@shijian", item.Shijian ?? (object)DBNull.Value),
                        new MySqlParameter("@zh_name", item.zh_name ?? (object)DBNull.Value),
                        new MySqlParameter("@gs_name", item.gs_name ?? (object)DBNull.Value)
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
                        foreach (qi_chu_info item in qci)
                        {
                            string sql = @"INSERT INTO yh_jinxiaocun_qichushu_mssql(_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name) 
                                 VALUES (@_openid, @cpid, @cpjg, @cpjj, @cplb, @cpname, @cpsj, @cpsl, @mxtype, @shijian, @zh_name, @gs_name)";

                            var parameters = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@_openid", item.Openid ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cpid", item.Cpid ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cpjg", item.Cpjg ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cpjj", item.Cpjj ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cplb", item.Cplb ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cpname", item.Cpname ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cpsj", item.Cpsj ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@cpsl", item.Cpsl ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@mxtype", item.Mxtype ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@shijian", item.Shijian ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@zh_name", item.zh_name ?? (object)DBNull.Value),
                        new System.Data.SqlClient.SqlParameter("@gs_name", item.gs_name ?? (object)DBNull.Value)
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
                foreach (qi_chu_info item in qci)
                {
                    string sql = @"insert into yh_jinxiaocun_qichushu(_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name) 
                         values (@_openid, @cpid, @cpjg, @cpjj, @cplb, @cpname, @cpsj, @cpsl, @mxtype, @shijian, @zh_name, @gs_name)";

                    var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@_openid", item.Openid ?? (object)DBNull.Value),
                new MySqlParameter("@cpid", item.Cpid ?? (object)DBNull.Value),
                new MySqlParameter("@cpjg", item.Cpjg ?? (object)DBNull.Value),
                new MySqlParameter("@cpjj", item.Cpjj ?? (object)DBNull.Value),
                new MySqlParameter("@cplb", item.Cplb ?? (object)DBNull.Value),
                new MySqlParameter("@cpname", item.Cpname ?? (object)DBNull.Value),
                new MySqlParameter("@cpsj", item.Cpsj ?? (object)DBNull.Value),
                new MySqlParameter("@cpsl", item.Cpsl ?? (object)DBNull.Value),
                new MySqlParameter("@mxtype", item.Mxtype ?? (object)DBNull.Value),
                new MySqlParameter("@shijian", item.Shijian ?? (object)DBNull.Value),
                new MySqlParameter("@zh_name", item.zh_name ?? (object)DBNull.Value),
                new MySqlParameter("@gs_name", item.gs_name ?? (object)DBNull.Value)
            };

                    affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                }
                return affectedRows;
            }
        }

        //public int update_qichu(string id, string cpid, string cpname, string cplb, string cpsj, string cpsl)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "UPDATE Yh_JinXiaoCun_qichushu SET cpid = '" + cpid + "',cplb = '" + cplb + "',cpname = '" + cpname + "',cpsj = '" + cpsj + "' ,cpsl = '" + cpsl + "' WHERE _id = '" + id + "'";
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int update_qichu(string id, string cpid, string cpname, string cplb, string cpsj, string cpsl)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = "UPDATE yh_jinxiaocun_qichushu SET cpid = @cpid, cplb = @cplb, cpname = @cpname, cpsj = @cpsj, cpsl = @cpsl WHERE _id = @id";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@cpid", cpid ?? (object)DBNull.Value),
                    new MySqlParameter("@cplb", cplb ?? (object)DBNull.Value),
                    new MySqlParameter("@cpname", cpname ?? (object)DBNull.Value),
                    new MySqlParameter("@cpsj", cpsj ?? (object)DBNull.Value),
                    new MySqlParameter("@cpsl", cpsl ?? (object)DBNull.Value),
                    new MySqlParameter("@id", id ?? (object)DBNull.Value)
                };

                        return sen.Database.ExecuteSqlCommand(sql, parameters);
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名不同
                        string sql = "UPDATE yh_jinxiaocun_qichushu_mssql SET cpid = @cpid, cplb = @cplb, cpname = @cpname, cpsj = @cpsj, cpsl = @cpsl WHERE _id = @id";

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@cpid", cpid ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@cplb", cplb ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@cpname", cpname ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@cpsj", cpsj ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@cpsl", cpsl ?? (object)DBNull.Value),
                    new System.Data.SqlClient.SqlParameter("@id", id ?? (object)DBNull.Value)
                };

                        return sen.Database.ExecuteSqlCommand(sql, parameters);
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE yh_jinxiaocun_qichushu SET cpid = @cpid, cplb = @cplb, cpname = @cpname, cpsj = @cpsj, cpsl = @cpsl WHERE _id = @id";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@cpid", cpid ?? (object)DBNull.Value),
            new MySqlParameter("@cplb", cplb ?? (object)DBNull.Value),
            new MySqlParameter("@cpname", cpname ?? (object)DBNull.Value),
            new MySqlParameter("@cpsj", cpsj ?? (object)DBNull.Value),
            new MySqlParameter("@cpsl", cpsl ?? (object)DBNull.Value),
            new MySqlParameter("@id", id ?? (object)DBNull.Value)
        };

                return sen.Database.ExecuteSqlCommand(sql, parameters);
            }
        }

        //public int del_qichu_ff(int cpid)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "DELETE FROM Yh_JinXiaoCun_qichushu WHERE _id = '" + cpid + "'";
        //        return sen.Database.ExecuteSqlCommand(sql); ;
        //    }

        //}
        public int del_qichu_ff(int cpid)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        // 使用参数化查询，避免SQL注入
                        string sql = "DELETE FROM yh_jinxiaocun_qichushu WHERE _id = @cpid";
                        return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@cpid", cpid));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名不同
                        string sql = "DELETE FROM yh_jinxiaocun_qichushu_mssql WHERE _id = @cpid";
                        return sen.Database.ExecuteSqlCommand(sql, new System.Data.SqlClient.SqlParameter("@cpid", cpid));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "DELETE FROM yh_jinxiaocun_qichushu WHERE _id = @cpid";
                return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@cpid", cpid));
            }
        }

        //public List<yh_jinxiaocun_qichushu> ming_xi_fenye(int yi_c, int er_c, string gs_name)
        //{
        //    using (ServerEntities sen = new ServerEntities()) {
        //        string sql = "select _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 from Yh_JinXiaoCun_qichushu left join (select sp_dm,mark1 from yh_jinxiaocun_jichuziliao) as pic on Yh_JinXiaoCun_qichushu.cpid = pic.sp_dm where gs_name = '" + gs_name + "' limit " + yi_c + "," + er_c + "";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_qichushu> ming_xi_fenye(int yi_c, int er_c, string gs_name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"select _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 
                             from yh_jinxiaocun_qichushu 
                             left join (select sp_dm,mark1 from yh_jinxiaocun_jichuziliao) as pic 
                             on yh_jinxiaocun_qichushu.cpid = pic.sp_dm 
                             where gs_name = @gs_name 
                             limit @yi_c, @er_c";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@gs_name", gs_name),
                    new MySqlParameter("@yi_c", yi_c),
                    new MySqlParameter("@er_c", er_c)
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, parameters);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"SELECT _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 
                             FROM yh_jinxiaocun_qichushu_mssql 
                             LEFT JOIN (SELECT sp_dm,mark1 FROM yh_jinxiaocun_jichuziliao_mssql) as pic 
                             ON yh_jinxiaocun_qichushu_mssql.cpid = pic.sp_dm 
                             WHERE gs_name = @gs_name 
                             ORDER BY _id 
                             OFFSET @yi_c ROWS FETCH NEXT @er_c ROWS ONLY";

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name),
                    new System.Data.SqlClient.SqlParameter("@yi_c", yi_c),
                    new System.Data.SqlClient.SqlParameter("@er_c", er_c)
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, parameters);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 
                     from yh_jinxiaocun_qichushu 
                     left join (select sp_dm,mark1 from yh_jinxiaocun_jichuziliao) as pic 
                     on yh_jinxiaocun_qichushu.cpid = pic.sp_dm 
                     where gs_name = @gs_name 
                     limit @yi_c, @er_c";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@gs_name", gs_name),
            new MySqlParameter("@yi_c", yi_c),
            new MySqlParameter("@er_c", er_c)
        };

                var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, parameters);
                return result.ToList();
            }
        }

        //public List<yh_jinxiaocun_qichushu> ming_xi_chaxun(int yi_c, int er_c, string gs_name,string cpname)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 from Yh_JinXiaoCun_qichushu left join (select sp_dm,mark1 from yh_jinxiaocun_jichuziliao) as pic on Yh_JinXiaoCun_qichushu.cpid = pic.sp_dm where gs_name = '" + gs_name + "' and cpname like '%" + cpname + "%' limit " + yi_c + "," + er_c + "";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_qichushu> ming_xi_chaxun(int yi_c, int er_c, string gs_name, string cpname)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"select _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 
                             from yh_jinxiaocun_qichushu 
                             left join (select sp_dm,mark1 from yh_jinxiaocun_jichuziliao) as pic 
                             on yh_jinxiaocun_qichushu.cpid = pic.sp_dm 
                             where gs_name = @gs_name and cpname like @cpname 
                             limit @yi_c, @er_c";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@gs_name", gs_name),
                    new MySqlParameter("@cpname", "%" + cpname + "%"),
                    new MySqlParameter("@yi_c", yi_c),
                    new MySqlParameter("@er_c", er_c)
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, parameters);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"SELECT _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 
                             FROM yh_jinxiaocun_qichushu_mssql 
                             LEFT JOIN (SELECT sp_dm,mark1 FROM yh_jinxiaocun_jichuziliao_mssql) as pic 
                             ON yh_jinxiaocun_qichushu_mssql.cpid = pic.sp_dm 
                             WHERE gs_name = @gs_name and cpname like @cpname 
                             ORDER BY _id 
                             OFFSET @yi_c ROWS FETCH NEXT @er_c ROWS ONLY";

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name),
                    new System.Data.SqlClient.SqlParameter("@cpname", "%" + cpname + "%"),
                    new System.Data.SqlClient.SqlParameter("@yi_c", yi_c),
                    new System.Data.SqlClient.SqlParameter("@er_c", er_c)
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, parameters);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select _id,_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name,pic.mark1 
                     from yh_jinxiaocun_qichushu 
                     left join (select sp_dm,mark1 from yh_jinxiaocun_jichuziliao) as pic 
                     on yh_jinxiaocun_qichushu.cpid = pic.sp_dm 
                     where gs_name = @gs_name and cpname like @cpname 
                     limit @yi_c, @er_c";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@gs_name", gs_name),
            new MySqlParameter("@cpname", "%" + cpname + "%"),
            new MySqlParameter("@yi_c", yi_c),
            new MySqlParameter("@er_c", er_c)
        };

                var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, parameters);
                return result.ToList();
            }
        }

        //public List<yh_jinxiaocun_qichushu> qi_chu_select_row(string gs_name)
        //{
        //    using (ServerEntities sen = new ServerEntities()) {
        //        string sql = "SELECT cpid FROM Yh_JinXiaoCun_qichushu where gs_name = '" + gs_name + "'";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_qichushu> qi_chu_select_row(string gs_name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "SELECT cpid FROM yh_jinxiaocun_qichushu WHERE gs_name = @gs_name";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, new MySqlParameter("@gs_name", gs_name));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "SELECT cpid FROM yh_jinxiaocun_qichushu_mssql WHERE gs_name = @gs_name";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, new System.Data.SqlClient.SqlParameter("@gs_name", gs_name));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "SELECT cpid FROM yh_jinxiaocun_qichushu WHERE gs_name = @gs_name";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, new MySqlParameter("@gs_name", gs_name));
                return result.ToList();
            }
        }
    }
}
