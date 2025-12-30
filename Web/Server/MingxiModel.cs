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
    public class MingxiModel
    {

        //public string checkOrder_id(string order_id, string gongsi)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var @params = new MySqlParameter[]
        //        {
        //            new MySqlParameter("@order", order_id),
        //            new MySqlParameter("@gongsi", gongsi)
        //        };
                
        //        string sql = "select orderid from yh_jinxiaocun_mingxi where orderid = @order and gongsi = @gongsi";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, @params);
        //        List<yh_jinxiaocun_mingxi> list = result.ToList();
        //        return list.Count > 0 ? list[0].orderid : string.Empty;
        //    }
        //}
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

                        string sql = "select orderid from yh_jinxiaocun_mingxi where orderid = @order and gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, @params);
                        List<yh_jinxiaocun_mingxi> list = result.ToList();
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

                        string sql = "SELECT orderid FROM yh_jinxiaocun_mingxi_mssql WHERE orderid = @order AND gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, @params);
                        List<yh_jinxiaocun_mingxi> list = result.ToList();
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

                string sql = "select orderid from yh_jinxiaocun_mingxi where orderid = @order and gs_name = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, @params);
                List<yh_jinxiaocun_mingxi> list = result.ToList();
                return list.Count > 0 ? list[0].orderid : string.Empty;
            }
        }

        //public List<yh_jinxiaocun_mingxi> checkOrder_mingxi(string order_id, string gongsi)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var @params = new MySqlParameter[]
        //        {
        //            new MySqlParameter("@order", order_id),
        //            new MySqlParameter("@gongsi", gongsi)
        //        };

        //        string sql = "select * from yh_jinxiaocun_mingxi where orderid = @order and gs_name = @gongsi";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, @params);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_mingxi> checkOrder_mingxi(string order_id, string gongsi)
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

                        string sql = "select * from yh_jinxiaocun_mingxi where orderid = @order and gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, @params);
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

                        string sql = "SELECT * FROM yh_jinxiaocun_mingxi_mssql WHERE orderid = @order AND gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, @params);
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

                string sql = "select * from yh_jinxiaocun_mingxi where orderid = @order and gs_name = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, @params);
                return result.ToList();
            }
        }

        //public int add(items item, string company, string name, string mxtype)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string date_now = DateTime.Now.ToString();
        //        string sql = string.Empty;

        //        for (int i = 0; i < item.itemList.Count; i++)
        //        {
        //            sql += "insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name) select lei_bie as cplb,`name` as cpname," + item.itemList[i].price + " as cpsj," + item.itemList[i].num + " as cpsl,'" + mxtype + "' as mxtype,'" + item.orderid + "' as orderid,'" + date_now + "' as shijian,sp_dm,'" + item.gonghuo + "' as shou_h,'" + name + "' as zh_name,'" + company + "' as gs_name from yh_jinxiaocun_jichuziliao where id = " + item.itemList[i].id + ";";
        //        }
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int add(items item, string company, string name, string mxtype, string Rwarehouse)
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
                            string sql = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                                 select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
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
                            string sql = @"INSERT INTO yh_jinxiaocun_mingxi_mssql(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                                 SELECT lei_bie as cplb,[name] as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name ,@cangku as cangku 
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
                    string sql = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                         select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name ,@cangku as cangku 
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
                new MySqlParameter("@id", item.itemList[i].id)
            };

                    affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                }
                return affectedRows;
            }
        }


        public int addCG(List<yh_jinxiaocun_mingxi> list)
        {
            if (list == null || list.Count == 0)
            {
                return 0;
            }

            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string date_now = DateTime.Now.ToString();
                        int affectedRows = 0;

                        foreach (var item in list)
                        {
                            // 构建参数化SQL
                            string sql = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                                 select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                                 from yh_jinxiaocun_jichuziliao where sp_dm = @sp_dm and gs_name = @gs_name";

                            var parameters = new MySqlParameter[]
                            {
                                new MySqlParameter("@price", item.cpsj ?? (object)DBNull.Value),
                                new MySqlParameter("@num", item.cpsl ?? (object)DBNull.Value),
                                new MySqlParameter("@mxtype", item.mxtype ?? (object)DBNull.Value),
                                new MySqlParameter("@orderid", item.orderid ?? (object)DBNull.Value),
                                new MySqlParameter("@shijian", date_now),
                                new MySqlParameter("@shou_h", item.shou_h ?? (object)DBNull.Value),
                                new MySqlParameter("@zh_name", item.zh_name ?? (object)DBNull.Value),
                                new MySqlParameter("@gs_name", item.gs_name ?? (object)DBNull.Value),
                                new MySqlParameter("@cangku", item.cangku ?? (object)DBNull.Value),
                                new MySqlParameter("@sp_dm", item.sp_dm ?? (object)DBNull.Value),
                                new MySqlParameter("@gs_name_basic", item.gs_name ?? (object)DBNull.Value)
                            };

                            try
                            {
                                affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                            }
                            catch (Exception ex)
                            {
                                // 记录错误但继续处理其他记录
                                System.Diagnostics.Debug.WriteLine("错误");
                            }
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

                        foreach (var item in list)
                        {
                            string sql = @"INSERT INTO yh_jinxiaocun_mingxi_mssql(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                                 SELECT lei_bie as cplb,[name] as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                                 FROM yh_jinxiaocun_jichuziliao_mssql WHERE sp_dm = @sp_dm AND gs_name = @gs_name_basic";

                            var parameters = new System.Data.SqlClient.SqlParameter[]
                            {
                                new System.Data.SqlClient.SqlParameter("@price", item.cpsj ?? (object)DBNull.Value),
                                new System.Data.SqlClient.SqlParameter("@num", item.cpsl ?? (object)DBNull.Value),
                                new System.Data.SqlClient.SqlParameter("@mxtype", item.mxtype ?? (object)DBNull.Value),
                                new System.Data.SqlClient.SqlParameter("@orderid", item.orderid ?? (object)DBNull.Value),
                                new System.Data.SqlClient.SqlParameter("@shijian", date_now),
                                new System.Data.SqlClient.SqlParameter("@shou_h", item.shou_h ?? (object)DBNull.Value),
                                new System.Data.SqlClient.SqlParameter("@zh_name", item.zh_name ?? (object)DBNull.Value),
                                new System.Data.SqlClient.SqlParameter("@gs_name", item.gs_name ?? (object)DBNull.Value),
                                new System.Data.SqlClient.SqlParameter("@cangku", item.cangku ?? (object)DBNull.Value),
                                new System.Data.SqlClient.SqlParameter("@sp_dm", item.sp_dm ?? (object)DBNull.Value),
                                new System.Data.SqlClient.SqlParameter("@gs_name_basic", item.gs_name ?? (object)DBNull.Value)
                            };

                            try
                            {
                                affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                            }
                            catch (Exception ex)
                            {
                                // 记录错误但继续处理其他记录
                                System.Diagnostics.Debug.WriteLine("错误");
                            }
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

                foreach (var item in list)
                {
                    string sql = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                         select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                         from yh_jinxiaocun_jichuziliao where sp_dm = @sp_dm and gs_name = @gs_name_basic";

                    var parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("@price", item.cpsj ?? (object)DBNull.Value),
                        new MySqlParameter("@num", item.cpsl ?? (object)DBNull.Value),
                        new MySqlParameter("@mxtype", item.mxtype ?? (object)DBNull.Value),
                        new MySqlParameter("@orderid", item.orderid ?? (object)DBNull.Value),
                        new MySqlParameter("@shijian", date_now),
                        new MySqlParameter("@shou_h", item.shou_h ?? (object)DBNull.Value),
                        new MySqlParameter("@zh_name", item.zh_name ?? (object)DBNull.Value),
                        new MySqlParameter("@gs_name", item.gs_name ?? (object)DBNull.Value),
                        new MySqlParameter("@cangku", item.cangku ?? (object)DBNull.Value),
                        new MySqlParameter("@sp_dm", item.sp_dm ?? (object)DBNull.Value),
                        new MySqlParameter("@gs_name_basic", item.gs_name ?? (object)DBNull.Value)
                    };

                    try
                    {
                        affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                    }
                    catch (Exception ex)
                    {
                        // 记录错误但继续处理其他记录
                        System.Diagnostics.Debug.WriteLine("错误");
                    }
                }
                return affectedRows;
            }
        }

        public int addPD(items item, string company, string name,string warehouse)
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
                            string sql = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                                 select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                                 from yh_jinxiaocun_jichuziliao where id = @id";

                            var parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("@price", item.itemList[i].price),
                        new MySqlParameter("@num", item.itemList[i].sjsl),
                        new MySqlParameter("@mxtype", item.itemList[i].kcsl),
                        new MySqlParameter("@orderid", item.orderid),
                        new MySqlParameter("@shijian", date_now),
                        new MySqlParameter("@shou_h", item.gonghuo),
                        new MySqlParameter("@zh_name", name),
                        new MySqlParameter("@gs_name", company),
                        new MySqlParameter("@cangku", warehouse),
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
                            string sql = @"INSERT INTO yh_jinxiaocun_mingxi_mssql(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                                 SELECT lei_bie as cplb,[name] as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name ,@cangku as cangku 
                                 FROM yh_jinxiaocun_jichuziliao_mssql WHERE id = @id";

                            var parameters = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@price", item.itemList[i].price),
                        new System.Data.SqlClient.SqlParameter("@num", item.itemList[i].sjsl),
                        new System.Data.SqlClient.SqlParameter("@mxtype", item.itemList[i].kcsl),
                        new System.Data.SqlClient.SqlParameter("@orderid", item.orderid),
                        new System.Data.SqlClient.SqlParameter("@shijian", date_now),
                        new System.Data.SqlClient.SqlParameter("@shou_h", item.gonghuo),
                        new System.Data.SqlClient.SqlParameter("@zh_name", name),
                        new System.Data.SqlClient.SqlParameter("@gs_name", company),
                        new System.Data.SqlClient.SqlParameter("@cangku", warehouse),
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
                    string sql = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                         select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name ,@cangku as cangku 
                         from yh_jinxiaocun_jichuziliao where id = @id";

                    var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@price", item.itemList[i].price),
                new MySqlParameter("@num", item.itemList[i].sjsl),
                new MySqlParameter("@mxtype", item.itemList[i].kcsl),
                new MySqlParameter("@orderid", item.orderid),
                new MySqlParameter("@shijian", date_now),
                new MySqlParameter("@shou_h", item.gonghuo),
                new MySqlParameter("@zh_name", name),
                new MySqlParameter("@gs_name", company),
                new MySqlParameter("@cangku", warehouse),
                new MySqlParameter("@id", item.itemList[i].id)
            };

                    affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                }
                return affectedRows;
            }
        }

        public int addDB(items item, string company, string name, string Rmxtype, string Cmxtype, string Rwarehouse, string Cwarehouse)
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
                            // 第一条记录：调拨入库到Rwarehouse（调入仓库）
                            string sqlIn = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                         select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                         from yh_jinxiaocun_jichuziliao where id = @id";

                            var parametersIn = new MySqlParameter[]
                    {
                        new MySqlParameter("@price", item.itemList[i].price),
                        new MySqlParameter("@num", item.itemList[i].num),
                        new MySqlParameter("@mxtype", Rmxtype), // 调拨入库
                        new MySqlParameter("@orderid", item.orderid),
                        new MySqlParameter("@shijian", date_now),
                        new MySqlParameter("@shou_h", item.gonghuo),
                        new MySqlParameter("@zh_name", name),
                        new MySqlParameter("@gs_name", company),
                        new MySqlParameter("@cangku", Rwarehouse), // 调入仓库
                        new MySqlParameter("@id", item.itemList[i].id)
                    };

                            affectedRows += sen.Database.ExecuteSqlCommand(sqlIn, parametersIn);

                            // 第二条记录：调拨出库从Cwarehouse（调出仓库）
                            string sqlOut = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                         select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                         from yh_jinxiaocun_jichuziliao where id = @id";

                            var parametersOut = new MySqlParameter[]
                    {
                        new MySqlParameter("@price", item.itemList[i].price),
                        new MySqlParameter("@num", item.itemList[i].num),
                        new MySqlParameter("@mxtype", Cmxtype), // 调拨出库
                        new MySqlParameter("@orderid", item.orderid),
                        new MySqlParameter("@shijian", date_now),
                        new MySqlParameter("@shou_h", item.gonghuo),
                        new MySqlParameter("@zh_name", name),
                        new MySqlParameter("@gs_name", company),
                        new MySqlParameter("@cangku", Cwarehouse), // 调出仓库
                        new MySqlParameter("@id", item.itemList[i].id)
                    };

                            affectedRows += sen.Database.ExecuteSqlCommand(sqlOut, parametersOut);
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
                            // 第一条记录：调拨入库
                            string sqlIn = @"INSERT INTO yh_jinxiaocun_mingxi_mssql(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                         SELECT lei_bie as cplb,[name] as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                         FROM yh_jinxiaocun_jichuziliao_mssql WHERE id = @id";

                            var parametersIn = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@price", item.itemList[i].price),
                        new System.Data.SqlClient.SqlParameter("@num", item.itemList[i].num),
                        new System.Data.SqlClient.SqlParameter("@mxtype", Rmxtype), // 调拨入库
                        new System.Data.SqlClient.SqlParameter("@orderid", item.orderid),
                        new System.Data.SqlClient.SqlParameter("@shijian", date_now),
                        new System.Data.SqlClient.SqlParameter("@shou_h", item.gonghuo),
                        new System.Data.SqlClient.SqlParameter("@zh_name", name),
                        new System.Data.SqlClient.SqlParameter("@gs_name", company),
                        new System.Data.SqlClient.SqlParameter("@cangku", Rwarehouse), // 调入仓库
                        new System.Data.SqlClient.SqlParameter("@id", item.itemList[i].id)
                    };

                            affectedRows += sen.Database.ExecuteSqlCommand(sqlIn, parametersIn);

                            // 第二条记录：调拨出库
                            string sqlOut = @"INSERT INTO yh_jinxiaocun_mingxi_mssql(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                         SELECT lei_bie as cplb,[name] as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                         FROM yh_jinxiaocun_jichuziliao_mssql WHERE id = @id";

                            var parametersOut = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@price", item.itemList[i].price),
                        new System.Data.SqlClient.SqlParameter("@num", item.itemList[i].num),
                        new System.Data.SqlClient.SqlParameter("@mxtype", Cmxtype), // 调拨出库
                        new System.Data.SqlClient.SqlParameter("@orderid", item.orderid),
                        new System.Data.SqlClient.SqlParameter("@shijian", date_now),
                        new System.Data.SqlClient.SqlParameter("@shou_h", item.gonghuo),
                        new System.Data.SqlClient.SqlParameter("@zh_name", name),
                        new System.Data.SqlClient.SqlParameter("@gs_name", company),
                        new System.Data.SqlClient.SqlParameter("@cangku", Cwarehouse), // 调出仓库
                        new System.Data.SqlClient.SqlParameter("@id", item.itemList[i].id)
                    };

                            affectedRows += sen.Database.ExecuteSqlCommand(sqlOut, parametersOut);
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
                    // 调拨入库记录
                    string sqlIn = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                 select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                 from yh_jinxiaocun_jichuziliao where id = @id";

                    var parametersIn = new MySqlParameter[]
            {
                new MySqlParameter("@price", item.itemList[i].price),
                new MySqlParameter("@num", item.itemList[i].num),
                new MySqlParameter("@mxtype", Rmxtype), // 调拨入库
                new MySqlParameter("@orderid", item.orderid),
                new MySqlParameter("@shijian", date_now),
                new MySqlParameter("@shou_h", item.gonghuo),
                new MySqlParameter("@zh_name", name),
                new MySqlParameter("@gs_name", company),
                new MySqlParameter("@cangku", Rwarehouse), // 调入仓库
                new MySqlParameter("@id", item.itemList[i].id)
            };

                    affectedRows += sen.Database.ExecuteSqlCommand(sqlIn, parametersIn);

                    // 调拨出库记录
                    string sqlOut = @"insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name,cangku) 
                 select lei_bie as cplb,`name` as cpname,@price as cpsj,@num as cpsl,@mxtype as mxtype,@orderid as orderid,@shijian as shijian,sp_dm,@shou_h as shou_h,@zh_name as zh_name,@gs_name as gs_name,@cangku as cangku 
                 from yh_jinxiaocun_jichuziliao where id = @id";

                    var parametersOut = new MySqlParameter[]
            {
                new MySqlParameter("@price", item.itemList[i].price),
                new MySqlParameter("@num", item.itemList[i].num),
                new MySqlParameter("@mxtype", Cmxtype), // 调拨出库
                new MySqlParameter("@orderid", item.orderid),
                new MySqlParameter("@shijian", date_now),
                new MySqlParameter("@shou_h", item.gonghuo),
                new MySqlParameter("@zh_name", name),
                new MySqlParameter("@gs_name", company),
                new MySqlParameter("@cangku", Cwarehouse), // 调出仓库
                new MySqlParameter("@id", item.itemList[i].id)
            };

                    affectedRows += sen.Database.ExecuteSqlCommand(sqlOut, parametersOut);
                }
                return affectedRows;
            }
        }

        //public List<yh_jinxiaocun_mingxi> ming_xi_select(string gs_name, int limit1, int limit2, String kstime88, String jstime88)
        //{
            
        //    using (ServerEntities sen = new ServerEntities()) {
        //       var limit = 20;
        //       var riqi1 = DateTime.Now.ToString("yyyy-MM-01");
        //       var riqi2 = DateTime.Now.ToString("yyyy-MM-31");

        //       string[] mm = riqi1.Split('-');
        //       int m = Convert.ToInt32(mm[1]);
        //        //if (m == 2)
        //        //{
        //        //    riqi2 = DateTime.Now.ToString("yyyy-MM-28");
        //        //}
        //        //else {
        //        //    riqi2 = DateTime.Now.ToString("yyyy-MM-31");
        //        //   // DateTime dt2 = DateTime.Parse(DateTime.Now.ToString("yyyy")).ToString() + "/" + DateTime.Now.ToString("MM")).ToString() + "/1").AddMonths(1).AddDays(-1);
        //        //    riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy").ToString() + "/" + DateTime.Now.ToString("MM").ToString() + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
           
        //        //   // riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
        //        //}

        //      riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy").ToString() + "/" + DateTime.Now.ToString("MM").ToString() + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

        //       if (kstime88 == null || kstime88.Length < 1)
        //           kstime88 = riqi1;
        //       if (jstime88 == null || jstime88.Length < 1)
        //           jstime88 = riqi2; 

        //       string sql = "select * from yh_jinxiaocun_mingxi where gs_name = '" + gs_name + "'and shijian>'" + kstime88 + "'and shijian<'" + jstime88 + "' order by shijian desc limit " + limit1 + "," + limit2 + " ";
        //       // string sql = "select * from yh_jinxiaocun_mingxi where shijian>='" + riqi1 + "' and shijian<='" + riqi2 + "' ";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_mingxi> ming_xi_select(string gs_name, int limit1, int limit2, String kstime88, String jstime88)
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

                        if (kstime88 == null || kstime88.Length < 1)
                            kstime88 = riqi1;
                        if (jstime88 == null || jstime88.Length < 1)
                            jstime88 = riqi2;

                        // MySQL 分页语法
                        string sql = @"select * from yh_jinxiaocun_mingxi 
                         where gs_name = @gs_name 
                         and shijian > @kstime 
                         and shijian < @jstime 
                         order by shijian desc 
                         limit @limit1, @limit2";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@gs_name", gs_name),
                    new MySqlParameter("@kstime", kstime88),
                    new MySqlParameter("@jstime", jstime88),
                    new MySqlParameter("@limit1", limit1),
                    new MySqlParameter("@limit2", limit2)
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, parameters);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var riqi1 = DateTime.Now.ToString("yyyy-MM-01");
                        var riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                        if (kstime88 == null || kstime88.Length < 1)
                            kstime88 = riqi1;
                        if (jstime88 == null || jstime88.Length < 1)
                            jstime88 = riqi2;

                        // SQL Server 兼容分页语法 - 使用 ROW_NUMBER()
                        string sql = @"SELECT * FROM (
                         SELECT *, ROW_NUMBER() OVER (ORDER BY shijian DESC) as RowNum 
                         FROM yh_jinxiaocun_mingxi_mssql 
                         WHERE gs_name = @gs_name 
                         AND shijian > @kstime 
                         AND shijian < @jstime
                       ) AS MyResults
                       WHERE RowNum BETWEEN @startRow AND @endRow";

                        // 计算行号范围
                        int startRow = limit1 + 1;  // ROW_NUMBER() 从1开始
                        int endRow = limit1 + limit2;

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name),
                    new System.Data.SqlClient.SqlParameter("@kstime", kstime88),
                    new System.Data.SqlClient.SqlParameter("@jstime", jstime88),
                    new System.Data.SqlClient.SqlParameter("@startRow", startRow),
                    new System.Data.SqlClient.SqlParameter("@endRow", endRow)
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, parameters);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var riqi1 = DateTime.Now.ToString("yyyy-MM-01");
                var riqi2 = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/1").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                if (kstime88 == null || kstime88.Length < 1)
                    kstime88 = riqi1;
                if (jstime88 == null || jstime88.Length < 1)
                    jstime88 = riqi2;

                // MySQL 分页语法
                string sql = @"select * from yh_jinxiaocun_mingxi 
                 where gs_name = @gs_name 
                 and shijian > @kstime 
                 and shijian < @jstime 
                 order by shijian desc 
                 limit @limit1, @limit2";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@gs_name", gs_name),
            new MySqlParameter("@kstime", kstime88),
            new MySqlParameter("@jstime", jstime88),
            new MySqlParameter("@limit1", limit1),
            new MySqlParameter("@limit2", limit2)
        };

                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, parameters);
                return result.ToList();
            }
        }

        //public int getPageCount(string gs_name)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "SELECT * FROM Yh_JinXiaoCun_mingxi where gs_name = '" + gs_name + "'";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
        //        return result.ToList().Count;
        //    }
        //}
        public int getPageCount(string gs_name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "SELECT COUNT(*) FROM yh_jinxiaocun_mingxi WHERE gs_name = @gs_name";
                        var result = sen.Database.SqlQuery<int>(sql, new MySqlParameter("@gs_name", gs_name));
                        return result.SingleOrDefault();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "SELECT COUNT(*) FROM yh_jinxiaocun_mingxi_mssql WHERE gs_name = @gs_name";
                        var result = sen.Database.SqlQuery<int>(sql, new System.Data.SqlClient.SqlParameter("@gs_name", gs_name));
                        return result.SingleOrDefault();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "SELECT COUNT(*) FROM yh_jinxiaocun_mingxi WHERE gs_name = @gs_name";
                var result = sen.Database.SqlQuery<int>(sql, new MySqlParameter("@gs_name", gs_name));
                return result.SingleOrDefault();
            }
        }

        //public List<yh_jinxiaocun_mingxi> ri_qi_select(string time_qs, string time_jz,string order_number, string gs_name)
        //{
        //    using (ServerEntities sen = new ServerEntities()) {
        //        string sql = "SELECT * FROM Yh_JinXiaoCun_mingxi WHERE shijian between '" + time_qs + "' and '" + time_jz + "' and gs_name = '" + gs_name + "' and orderid like '%" + order_number + "%'   order by shijian desc";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_mingxi> ri_qi_select(string time_qs, string time_jz, string order_number, string gs_name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"SELECT * FROM yh_jinxiaocun_mingxi 
                             WHERE shijian BETWEEN @time_qs AND @time_jz 
                             AND gs_name = @gs_name 
                             AND orderid LIKE @order_number 
                             ORDER BY shijian DESC";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@time_qs", time_qs),
                    new MySqlParameter("@time_jz", time_jz),
                    new MySqlParameter("@gs_name", gs_name),
                    new MySqlParameter("@order_number", "%" + order_number + "%")
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, parameters);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"SELECT * FROM yh_jinxiaocun_mingxi_mssql 
                             WHERE shijian BETWEEN @time_qs AND @time_jz 
                             AND gs_name = @gs_name 
                             AND orderid LIKE @order_number 
                             ORDER BY shijian DESC";

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@time_qs", time_qs),
                    new System.Data.SqlClient.SqlParameter("@time_jz", time_jz),
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name),
                    new System.Data.SqlClient.SqlParameter("@order_number", "%" + order_number + "%")
                };

                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, parameters);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"SELECT * FROM yh_jinxiaocun_mingxi 
                     WHERE shijian BETWEEN @time_qs AND @time_jz 
                     AND gs_name = @gs_name 
                     AND orderid LIKE @order_number 
                     ORDER BY shijian DESC";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@time_qs", time_qs),
            new MySqlParameter("@time_jz", time_jz),
            new MySqlParameter("@gs_name", gs_name),
            new MySqlParameter("@order_number", "%" + order_number + "%")
        };

                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, parameters);
                return result.ToList();
            }
        }

        //public List<yh_jinxiaocun_mingxi> getCpNames(string gongsi) {
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select cpname from yh_jinxiaocun_mingxi where gs_name = '" + gongsi + "' group by cpname";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_mingxi> getCpNames(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select cpname from yh_jinxiaocun_mingxi where gs_name = @gongsi group by cpname";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, new MySqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "SELECT cpname FROM yh_jinxiaocun_mingxi_mssql WHERE gs_name = @gongsi GROUP BY cpname";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, new System.Data.SqlClient.SqlParameter("@gongsi", gongsi));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select cpname from yh_jinxiaocun_mingxi where gs_name = @gongsi group by cpname";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, new MySqlParameter("@gongsi", gongsi));
                return result.ToList();
            }
        }

        //public List<MingXiItem> getCpMingXi(string sp_dm, string cplb, string cpname, string gongsi)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var @params = new MySqlParameter[]{
        //            new MySqlParameter("@cpname", cpname),
        //            new MySqlParameter("@gongxi", gongsi),

        //        };


        //        //string sql = "select mx.sp_dm,mx.cpname,mx.cplb,ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = '' group by sp_dm,cpname,cplb) as mx left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm having mx.cpname like '%'+ @cpname + '%' and mx.sp_dm like '%' + @sp_dm + '%' and mx.cplb like '%' + @cplb + '%'";
        //        string sql = "select mx.sp_dm,mx.cpname,mx.cplb,ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm where mx.cpname = @cpname and mx.sp_dm like '%" + sp_dm + "%' and mx.cplb like '%" + cplb + "%'";
                
        //        //string sql = "select mx.sp_dm,mx.cpname,mx.cplb,ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm having mx.cpname = @cpname";
        //        //string sql = "select mx.shijian,mx.orderid,mx.sp_dm,mx.cpname,ifnull(ruku.cpsl,0) as ruku_num,ifnull(ruku.cp_price,0) as ruku_price,ifnull(chuku.cpsl,0) as chuku_num,ifnull(chuku.cp_price,0) as chuku_price from yh_jinxiaocun_mingxi as mx left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by orderid) as ruku on mx.orderid = ruku.orderid left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by orderid) as chuku on mx.orderid = chuku.orderid where mx.gs_name = @gongxi GROUP BY mx.orderid having mx.cpname = @cpname";
        //        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
        //        return result.ToList();
        //    }
        //}
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
                             from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm 
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
                             FROM (SELECT sp_dm,cpname,cplb FROM yh_jinxiaocun_mingxi_mssql WHERE gs_name = @gongxi GROUP BY sp_dm,cpname,cplb) as mx 
                             LEFT JOIN (SELECT sp_dm,SUM(cpsl) as cpsl,SUM(cpsl*cpsj) as cp_price FROM yh_jinxiaocun_mingxi_mssql WHERE mxtype = '入库' AND gs_name = @gongxi GROUP BY sp_dm) as rk ON mx.sp_dm=rk.sp_dm 
                             LEFT JOIN (SELECT sp_dm,SUM(cpsl) as cpsl,SUM(cpsl*cpsj) as cp_price FROM yh_jinxiaocun_mingxi_mssql WHERE mxtype = '出库' AND gs_name = @gongxi GROUP BY sp_dm) as ck ON ck.sp_dm=rk.sp_dm 
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
                     from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm 
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

        //public List<MingXiItem> getCpMingXi2(string sp_dm, string cplb, string gongsi)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var @params = new MySqlParameter[]{
        //            new MySqlParameter("@gongxi", gongsi),

        //        };


        //        //string sql = "select mx.sp_dm,mx.cpname,mx.cplb,ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = '' group by sp_dm,cpname,cplb) as mx left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm having mx.cpname like '%'+ @cpname + '%' and mx.sp_dm like '%' + @sp_dm + '%' and mx.cplb like '%' + @cplb + '%'";
        //        string sql = "select mx.sp_dm,mx.cpname,mx.cplb,ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm where mx.sp_dm like '%" + sp_dm + "%' and mx.cplb like '%" + cplb + "%'";

        //        //string sql = "select mx.sp_dm,mx.cpname,mx.cplb,ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm having mx.cpname = @cpname";
        //        //string sql = "select mx.shijian,mx.orderid,mx.sp_dm,mx.cpname,ifnull(ruku.cpsl,0) as ruku_num,ifnull(ruku.cp_price,0) as ruku_price,ifnull(chuku.cpsl,0) as chuku_num,ifnull(chuku.cp_price,0) as chuku_price from yh_jinxiaocun_mingxi as mx left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by orderid) as ruku on mx.orderid = ruku.orderid left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by orderid) as chuku on mx.orderid = chuku.orderid where mx.gs_name = @gongxi GROUP BY mx.orderid having mx.cpname = @cpname";
        //        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
        //        return result.ToList();
        //    }
        //}
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
                             from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm 
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
                             FROM (SELECT sp_dm,cpname,cplb FROM yh_jinxiaocun_mingxi_mssql WHERE gs_name = @gongxi GROUP BY sp_dm,cpname,cplb) as mx 
                             LEFT JOIN (SELECT sp_dm,SUM(cpsl) as cpsl,SUM(cpsl*cpsj) as cp_price FROM yh_jinxiaocun_mingxi_mssql WHERE mxtype = '入库' AND gs_name = @gongxi GROUP BY sp_dm) as rk ON mx.sp_dm=rk.sp_dm 
                             LEFT JOIN (SELECT sp_dm,SUM(cpsl) as cpsl,SUM(cpsl*cpsj) as cp_price FROM yh_jinxiaocun_mingxi_mssql WHERE mxtype = '出库' AND gs_name = @gongxi GROUP BY sp_dm) as ck ON ck.sp_dm=rk.sp_dm 
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
                     from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm 
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
                     from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
                     left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm";

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
             FROM yh_jinxiaocun_mingxi_mssql 
             WHERE gs_name = @gongxi 
             GROUP BY sp_dm, cpname, cplb) as mx 
        LEFT JOIN (
            SELECT 
                sp_dm, 
                -- 内部计算使用 decimal，最终转换为对应类型
                SUM(CAST(ISNULL(cpsl, 0) AS DECIMAL(18,2))) as cpsl,
                SUM(CAST(ISNULL(cpsl, 0) AS DECIMAL(18,2)) * CAST(ISNULL(cpsj, 0) AS DECIMAL(18,2))) as cp_price 
            FROM yh_jinxiaocun_mingxi_mssql 
            WHERE mxtype = '入库' AND gs_name = @gongxi 
            GROUP BY sp_dm
        ) as rk ON mx.sp_dm = rk.sp_dm 
        LEFT JOIN (
            SELECT 
                sp_dm, 
                SUM(CAST(ISNULL(cpsl, 0) AS DECIMAL(18,2))) as cpsl,
                SUM(CAST(ISNULL(cpsl, 0) AS DECIMAL(18,2)) * CAST(ISNULL(cpsj, 0) AS DECIMAL(18,2))) as cp_price 
            FROM yh_jinxiaocun_mingxi_mssql 
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
             from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx 
             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm 
             left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm";

                var @params = new MySqlParameter[]{
            new MySqlParameter("@gongxi", gongsi ?? (object)DBNull.Value)
        };

                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

        //public List<yh_jinxiaocun_mingxi> getShouHuoMingXi(string gsname) 
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select shou_h from yh_jinxiaocun_mingxi where shou_h != '' and gs_name = '" + gsname + "' group by shou_h";
        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<yh_jinxiaocun_mingxi> getShouHuoMingXi(string gsname)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select shou_h from yh_jinxiaocun_mingxi where shou_h != '' and gs_name = @gsname group by shou_h";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, new MySqlParameter("@gsname", gsname));
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = "SELECT shou_h FROM yh_jinxiaocun_mingxi_mssql WHERE shou_h != '' AND gs_name = @gsname GROUP BY shou_h";
                        var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, new System.Data.SqlClient.SqlParameter("@gsname", gsname));
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select shou_h from yh_jinxiaocun_mingxi where shou_h != '' and gs_name = @gsname group by shou_h";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, new MySqlParameter("@gsname", gsname));
                return result.ToList();
            }
        }

        //public List<MingXiItem> getChMingxi(string shouhuo, string gongsi)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var @params = new MySqlParameter[]{
        //            new MySqlParameter("@shouhuo", shouhuo),
        //            new MySqlParameter("@gongxi", gongsi)
        //        };
        //        string sql = "select shou_h,sp_dm,cpname,cplb,ifnull(sum(cpsl),0) as ruku_num,ifnull(sum(cpsl*cpsj),0) as ruku_price from yh_jinxiaocun_mingxi where gs_name=@gongxi group by shou_h,sp_dm,cpname,cplb having shou_h != '' and shou_h = @shouhuo";
        //        //string sql = "select mx.shijian,mx.shou_h,mx.orderid,mx.sp_dm,mx.cpname,ifnull(ruku.cpsl,0) as ruku_num,ifnull(ruku.cp_price,0) as ruku_price from yh_jinxiaocun_mingxi as mx left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by orderid) as ruku on mx.orderid = ruku.orderid where mx.gs_name = @gongxi GROUP BY mx.orderid having mx.shou_h != '' and mx.shou_h = @shouhuo";
        //        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
        //        return result.ToList();
        //    }
        //}
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
                             from yh_jinxiaocun_mingxi 
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
                             FROM yh_jinxiaocun_mingxi_mssql 
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
                     from yh_jinxiaocun_mingxi 
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

        //public List<MingXiItem> getChMingxi_all(string gongsi)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var @params = new MySqlParameter[]{
        //            new MySqlParameter("@gongxi", gongsi)
        //        };
        //        string sql = "select shou_h,sp_dm,cpname,cplb,ifnull(sum(cpsl),0) as ruku_num,ifnull(sum(cpsl*cpsj),0) as ruku_price from yh_jinxiaocun_mingxi where gs_name=@gongxi group by shou_h,sp_dm,cpname,cplb having shou_h != '' order by shou_h";
        //        //string sql = "select mx.shijian,mx.shou_h,mx.orderid,mx.sp_dm,mx.cpname,ifnull(ruku.cpsl,0) as ruku_num,ifnull(ruku.cp_price,0) as ruku_price from yh_jinxiaocun_mingxi as mx left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by orderid) as ruku on mx.orderid = ruku.orderid where mx.gs_name = @gongxi GROUP BY mx.orderid having mx.shou_h != '' and mx.shou_h = @shouhuo";
        //        var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
        //        return result.ToList();
        //    }
        //}
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
                     from yh_jinxiaocun_mingxi 
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
             FROM yh_jinxiaocun_mingxi_mssql 
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
             from yh_jinxiaocun_mingxi 
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
        //public int del_mingxi(int cpid)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "DELETE FROM yh_jinxiaocun_mingxi WHERE _id = '" + cpid + "'";
        //        return sen.Database.ExecuteSqlCommand(sql); ;
        //    }

        //}
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
                        string sql = "DELETE FROM yh_jinxiaocun_mingxi WHERE _id = @cpid";
                        return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@cpid", cpid));
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 注意：SQL Server 表名不同
                        string sql = "DELETE FROM yh_jinxiaocun_mingxi_mssql WHERE _id = @cpid";
                        return sen.Database.ExecuteSqlCommand(sql, new System.Data.SqlClient.SqlParameter("@cpid", cpid));
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "DELETE FROM yh_jinxiaocun_mingxi WHERE _id = @cpid";
                return sen.Database.ExecuteSqlCommand(sql, new MySqlParameter("@cpid", cpid));
            }
        }

        //public int update(List<yh_jinxiaocun_mingxi> list)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "";
        //        foreach (yh_jinxiaocun_mingxi item in list)
        //        {
        //            sql += "update yh_jinxiaocun_mingxi set orderid= '" + item.orderid + "',sp_dm= '" + item.sp_dm + "',cpname= '" + item.cpname + "',cplb= '" + item.cplb + "',cpsj= '" + item.cpsj + "',cpsl= '" + item.cpsl + "',mxtype= '" + item.mxtype + "',shou_h= '" + item.shou_h + "' where _id='" + item._id + "' ;";
        //        }
        //        return sen.Database.ExecuteSqlCommand(sql);
        //    }
        //}
        public int update(List<yh_jinxiaocun_mingxi> list)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        int affectedRows = 0;
                        foreach (yh_jinxiaocun_mingxi item in list)
                        {
                            string sql = @"update yh_jinxiaocun_mingxi 
                                 set orderid = @orderid, sp_dm = @sp_dm, cpname = @cpname, 
                                     cplb = @cplb, cpsj = @cpsj, cpsl = @cpsl, 
                                     mxtype = @mxtype, shou_h = @shou_h 
                                 where _id = @_id";

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
                        new MySqlParameter("@_id", item._id)
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
                        foreach (yh_jinxiaocun_mingxi item in list)
                        {
                            string sql = @"UPDATE yh_jinxiaocun_mingxi_mssql 
                                 SET orderid = @orderid, sp_dm = @sp_dm, cpname = @cpname, 
                                     cplb = @cplb, cpsj = @cpsj, cpsl = @cpsl, 
                                     mxtype = @mxtype, shou_h = @shou_h 
                                 WHERE _id = @_id";

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
                        new System.Data.SqlClient.SqlParameter("@_id", item._id)
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
                foreach (yh_jinxiaocun_mingxi item in list)
                {
                    string sql = @"update yh_jinxiaocun_mingxi 
                         set orderid = @orderid, sp_dm = @sp_dm, cpname = @cpname, 
                             cplb = @cplb, cpsj = @cpsj, cpsl = @cpsl, 
                             mxtype = @mxtype, shou_h = @shou_h 
                         where _id = @_id";

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
                new MySqlParameter("@_id", item._id)
            };

                    affectedRows += sen.Database.ExecuteSqlCommand(sql, parameters);
                }
                return affectedRows;
            }
        }



        // 获取所有进出明细数据（带基本筛选）
        public List<yh_jinxiaocun_mingxi> GetAllJinchuDetails(string gongsi, string mxtype = null, string startDate = null, string endDate = null)
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
                FROM yh_jinxiaocun_mingxi 
                WHERE gs_name = @gongsi";

                        var parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@gongsi", gongsi)
                };

                        // 添加进出类型筛选
                        if (!string.IsNullOrEmpty(mxtype))
                        {
                            sql += " AND mxtype = @mxtype";
                            parameters.Add(new MySqlParameter("@mxtype", mxtype));
                        }

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

                        return sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, parameters.ToArray()).ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 构建基本查询
                        string sql = @"
                SELECT * 
                FROM yh_jinxiaocun_mingxi_mssql
                WHERE gs_name = @gongsi";

                        var parameters = new List<System.Data.SqlClient.SqlParameter>
                {
                    new System.Data.SqlClient.SqlParameter("@gongsi", gongsi)
                };

                        // 添加进出类型筛选
                        if (!string.IsNullOrEmpty(mxtype))
                        {
                            sql += " AND mxtype = @mxtype";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@mxtype", mxtype));
                        }

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

                        return sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, parameters.ToArray()).ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"
        SELECT * 
        FROM yh_jinxiaocun_mingxi 
        WHERE gs_name = @gongsi";

                var parameters = new List<MySqlParameter>
        {
            new MySqlParameter("@gongsi", gongsi)
        };

                // 添加进出类型筛选
                if (!string.IsNullOrEmpty(mxtype))
                {
                    sql += " AND mxtype = @mxtype";
                    parameters.Add(new MySqlParameter("@mxtype", mxtype));
                }

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

                return sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, parameters.ToArray()).ToList();
            }
        }
    }
}