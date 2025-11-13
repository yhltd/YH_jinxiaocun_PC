using MySql.Data.MySqlClient;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ServerEntity;
using Web.JxcServer;
using MySql.Data.MySqlClient; 

namespace Web.Server
{
    public class JinChuModel
    {

        //public List<JinChuZiLiaoItem> getSetStockDetail(string gongsi)
        //{
        //    List<zl_and_jc_info> list = new List<zl_and_jc_info>();

        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var gongsiParam = new MySqlParameter("@gongsi", gongsi);

        //        string sql = "select *,IFNULL((select sum(CASE mxtype WHEN '入库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
        //        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
        //        return result.ToList();
        //    }
        //}
        public List<JinChuZiLiaoItem> getSetStockDetail(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                        string sql = "select *,IFNULL((select sum(CASE mxtype WHEN '入库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var gongsiParam = new System.Data.SqlClient.SqlParameter("@gongsi", gongsi);
                        string sql = "select *,ISNULL((select sum(CASE mxtype WHEN '入库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi_mssql where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao_mssql as j where gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                string sql = "select *,IFNULL((select sum(CASE mxtype WHEN '入库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                return result.ToList();
            }
        }

        //public List<JinChuZiLiaoItem> getOutStockDetail(string gongsi)
        //{

        //    List<zl_and_jc_info> list = new List<zl_and_jc_info>();

        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var gongsiParam = new MySqlParameter("@gongsi", gongsi);

        //        string sql = "select *,IFNULL((select sum(CASE mxtype WHEN '出库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
        //        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
        //        return result.ToList();
        //    }
        //}
        public List<JinChuZiLiaoItem> getOutStockDetail(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                        string sql = "select *,IFNULL((select sum(CASE mxtype WHEN '出库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var gongsiParam = new System.Data.SqlClient.SqlParameter("@gongsi", gongsi);
                        string sql = "select *,ISNULL((select sum(CASE mxtype WHEN '出库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi_mssql where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao_mssql as j where gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                string sql = "select *,IFNULL((select sum(CASE mxtype WHEN '出库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                return result.ToList();
            }
        }

        //public List<yh_jinxiaocun_jichuziliao> getList(string gongsi) {
        //    List<zl_and_jc_info> list = new List<zl_and_jc_info>();

        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var gongsiParam = new MySqlParameter("@gongsi", gongsi);

        //        string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql, gongsiParam);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_jichuziliao> getList(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                        string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql, gongsiParam);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var gongsiParam = new System.Data.SqlClient.SqlParameter("@gongsi", gongsi);
                        string sql = "select * from yh_jinxiaocun_jichuziliao_mssql as j where gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql, gongsiParam);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql, gongsiParam);
                return result.ToList();
            }
        }

        //public List<yh_jinxiaocun_jichuziliao> getList_chaxun(string gongsi,string name)
        //{
        //    //List<zl_and_jc_info> list = new List<zl_and_jc_info>();

        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        //var gongsiParam = new MySqlParameter("@gongsi", gongsi);

        //        string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name ='"+ gongsi +"' and `name` like '%"+ name +"%'  ";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_jichuziliao> getList_chaxun(string gongsi, string name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi and `name` like @name";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql,
                            new MySqlParameter("@gongsi", gongsi),
                            new MySqlParameter("@name", "%" + name + "%"));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "select * from yh_jinxiaocun_jichuziliao_mssql as j where gs_name = @gongsi and name like @name";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql,
                            new System.Data.SqlClient.SqlParameter("@gongsi", gongsi),
                            new System.Data.SqlClient.SqlParameter("@name", "%" + name + "%"));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi and `name` like @name";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql,
                    new MySqlParameter("@gongsi", gongsi),
                    new MySqlParameter("@name", "%" + name + "%"));
                return result.ToList();
            }
        }

        //public List<yh_jinxiaocun_jichuziliao> getListById(string gongsi, int id)
        //{
        //    //List<zl_and_jc_info> list = new List<zl_and_jc_info>();

        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        //var gongsiParam = new MySqlParameter("@gongsi", gongsi);

        //        string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name ='" + gongsi + "' and id = '" + id + "'  ";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_jichuziliao> getListById(string gongsi, int id)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi and id = @id";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql,
                            new MySqlParameter("@gongsi", gongsi),
                            new MySqlParameter("@id", id));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "select * from yh_jinxiaocun_jichuziliao_mssql as j where gs_name = @gongsi and id = @id";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql,
                            new System.Data.SqlClient.SqlParameter("@gongsi", gongsi),
                            new System.Data.SqlClient.SqlParameter("@id", id));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi and id = @id";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql,
                    new MySqlParameter("@gongsi", gongsi),
                    new MySqlParameter("@id", id));
                return result.ToList();
            }
        }

        //public int delete(int id) {
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "DELETE FROM Yh_JinXiaoCun_jichuziliao WHERE id = '" + id + "'";
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
                        string sql = "DELETE FROM yh_jinxiaocun_jichuziliao WHERE id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "DELETE FROM yh_jinxiaocun_jichuziliao_mssql WHERE id = @id";
                        return sen.Database.ExecuteSqlCommand(sql, new System.Data.SqlClient.SqlParameter("@id", id));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "DELETE FROM yh_jinxiaocun_jichuziliao WHERE id = @id";
                return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@id", id));
            }
        }

        //public int add(List<yh_jinxiaocun_jichuziliao> list) {
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "";
        //        foreach (yh_jinxiaocun_jichuziliao item in list)
        //        {
        //            sql += "insert into Yh_JinXiaoCun_jichuziliao(sp_dm,name,lei_bie,dan_wei,shou_huo,gong_huo,zh_name,gs_name) values ('" + item.sp_dm + "','" + item.name + "','" + item.lei_bie + "','" + item.dan_wei + "','" + item.shou_huo + "','" + item.gong_huo + "','" + item.zh_name + "','" + item.gs_name + "');";
        //        }
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int add(List<yh_jinxiaocun_jichuziliao> list)
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

                        foreach (yh_jinxiaocun_jichuziliao item in list)
                        {
                            sql += "insert into yh_jinxiaocun_jichuziliao(sp_dm,name,lei_bie,dan_wei,shou_huo,gong_huo,zh_name,gs_name) values (@sp_dm" + paramIndex + ", @name" + paramIndex + ", @lei_bie" + paramIndex + ", @dan_wei" + paramIndex + ", @shou_huo" + paramIndex + ", @gong_huo" + paramIndex + ", @zh_name" + paramIndex + ", @gs_name" + paramIndex + ");";

                            parameters.Add(new MySqlParameter("@sp_dm" + paramIndex, item.sp_dm ?? ""));
                            parameters.Add(new MySqlParameter("@name" + paramIndex, item.name ?? ""));
                            parameters.Add(new MySqlParameter("@lei_bie" + paramIndex, item.lei_bie ?? ""));
                            parameters.Add(new MySqlParameter("@dan_wei" + paramIndex, item.dan_wei ?? ""));
                            parameters.Add(new MySqlParameter("@shou_huo" + paramIndex, item.shou_huo ?? ""));
                            parameters.Add(new MySqlParameter("@gong_huo" + paramIndex, item.gong_huo ?? ""));
                            parameters.Add(new MySqlParameter("@zh_name" + paramIndex, item.zh_name ?? ""));
                            parameters.Add(new MySqlParameter("@gs_name" + paramIndex, item.gs_name ?? ""));

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

                        foreach (yh_jinxiaocun_jichuziliao item in list)
                        {
                            sql += "insert into yh_jinxiaocun_jichuziliao_mssql(sp_dm,name,lei_bie,dan_wei,shou_huo,gong_huo,zh_name,gs_name) values (@sp_dm" + paramIndex + ", @name" + paramIndex + ", @lei_bie" + paramIndex + ", @dan_wei" + paramIndex + ", @shou_huo" + paramIndex + ", @gong_huo" + paramIndex + ", @zh_name" + paramIndex + ", @gs_name" + paramIndex + ");";

                            parameters.Add(new System.Data.SqlClient.SqlParameter("@sp_dm" + paramIndex, item.sp_dm ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@name" + paramIndex, item.name ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@lei_bie" + paramIndex, item.lei_bie ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@dan_wei" + paramIndex, item.dan_wei ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@shou_huo" + paramIndex, item.shou_huo ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@gong_huo" + paramIndex, item.gong_huo ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@zh_name" + paramIndex, item.zh_name ?? ""));
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@gs_name" + paramIndex, item.gs_name ?? ""));

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

                foreach (yh_jinxiaocun_jichuziliao item in list)
                {
                    sql += "insert into yh_jinxiaocun_jichuziliao(sp_dm,name,lei_bie,dan_wei,shou_huo,gong_huo,zh_name,gs_name) values (@sp_dm" + paramIndex + ", @name" + paramIndex + ", @lei_bie" + paramIndex + ", @dan_wei" + paramIndex + ", @shou_huo" + paramIndex + ", @gong_huo" + paramIndex + ", @zh_name" + paramIndex + ", @gs_name" + paramIndex + ");";

                    parameters.Add(new MySqlParameter("@sp_dm" + paramIndex, item.sp_dm ?? ""));
                    parameters.Add(new MySqlParameter("@name" + paramIndex, item.name ?? ""));
                    parameters.Add(new MySqlParameter("@lei_bie" + paramIndex, item.lei_bie ?? ""));
                    parameters.Add(new MySqlParameter("@dan_wei" + paramIndex, item.dan_wei ?? ""));
                    parameters.Add(new MySqlParameter("@shou_huo" + paramIndex, item.shou_huo ?? ""));
                    parameters.Add(new MySqlParameter("@gong_huo" + paramIndex, item.gong_huo ?? ""));
                    parameters.Add(new MySqlParameter("@zh_name" + paramIndex, item.zh_name ?? ""));
                    parameters.Add(new MySqlParameter("@gs_name" + paramIndex, item.gs_name ?? ""));

                    paramIndex++;
                }

                return sen.Database.ExecuteSqlCommand(sql, parameters.ToArray());
            }
        }

        //public int update(string sp_dm, string name, string lei_bie, string dan_wei, string shou_huo, string gong_huo, string id)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "UPDATE Yh_JinXiaoCun_jichuziliao SET sp_dm = '" + sp_dm + "',name = '" + name + "',lei_bie = '" + lei_bie + "' ,dan_wei = '" + dan_wei + "' ,shou_huo = '" + shou_huo + "' ,gong_huo = '" + gong_huo + "' WHERE id = '" + id + "'";
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int update(string sp_dm, string name, string lei_bie, string dan_wei, string shou_huo, string gong_huo, string id)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "UPDATE yh_jinxiaocun_jichuziliao SET sp_dm = @sp_dm, name = @name, lei_bie = @lei_bie, dan_wei = @dan_wei, shou_huo = @shou_huo, gong_huo = @gong_huo WHERE id = @id";
                        return sen.Database.ExecuteSqlCommand(sql,
                            new MySqlParameter("@sp_dm", sp_dm ?? ""),
                            new MySqlParameter("@name", name ?? ""),
                            new MySqlParameter("@lei_bie", lei_bie ?? ""),
                            new MySqlParameter("@dan_wei", dan_wei ?? ""),
                            new MySqlParameter("@shou_huo", shou_huo ?? ""),
                            new MySqlParameter("@gong_huo", gong_huo ?? ""),
                            new MySqlParameter("@id", id));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "UPDATE yh_jinxiaocun_jichuziliao_mssql SET sp_dm = @sp_dm, name = @name, lei_bie = @lei_bie, dan_wei = @dan_wei, shou_huo = @shou_huo, gong_huo = @gong_huo WHERE id = @id";
                        return sen.Database.ExecuteSqlCommand(sql,
                            new System.Data.SqlClient.SqlParameter("@sp_dm", sp_dm ?? ""),
                            new System.Data.SqlClient.SqlParameter("@name", name ?? ""),
                            new System.Data.SqlClient.SqlParameter("@lei_bie", lei_bie ?? ""),
                            new System.Data.SqlClient.SqlParameter("@dan_wei", dan_wei ?? ""),
                            new System.Data.SqlClient.SqlParameter("@shou_huo", shou_huo ?? ""),
                            new System.Data.SqlClient.SqlParameter("@gong_huo", gong_huo ?? ""),
                            new System.Data.SqlClient.SqlParameter("@id", id));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE yh_jinxiaocun_jichuziliao SET sp_dm = @sp_dm, name = @name, lei_bie = @lei_bie, dan_wei = @dan_wei, shou_huo = @shou_huo, gong_huo = @gong_huo WHERE id = @id";
                return sen.Database.ExecuteSqlCommand(sql,
                    new MySqlParameter("@sp_dm", sp_dm ?? ""),
                    new MySqlParameter("@name", name ?? ""),
                    new MySqlParameter("@lei_bie", lei_bie ?? ""),
                    new MySqlParameter("@dan_wei", dan_wei ?? ""),
                    new MySqlParameter("@shou_huo", shou_huo ?? ""),
                    new MySqlParameter("@gong_huo", gong_huo ?? ""),
                    new MySqlParameter("@id", id));
            }
        }
        //public int picture_upd(string id, string base64)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "UPDATE Yh_JinXiaoCun_jichuziliao SET mark1 = '" + base64 + "' WHERE id = '" + id + "'";
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int picture_upd(string id, string base64)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "UPDATE yh_jinxiaocun_jichuziliao SET mark1 = @base64 WHERE id = @id";
                        return sen.Database.ExecuteSqlCommand(sql,
                            new MySqlParameter("@base64", base64 ?? ""),
                            new MySqlParameter("@id", id));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "UPDATE yh_jinxiaocun_jichuziliao_mssql SET mark1 = @base64 WHERE id = @id";
                        return sen.Database.ExecuteSqlCommand(sql,
                            new System.Data.SqlClient.SqlParameter("@base64", base64 ?? ""),
                            new System.Data.SqlClient.SqlParameter("@id", id));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE yh_jinxiaocun_jichuziliao SET mark1 = @base64 WHERE id = @id";
                return sen.Database.ExecuteSqlCommand(sql,
                    new MySqlParameter("@base64", base64 ?? ""),
                    new MySqlParameter("@id", id));
            }
        }

    }
}