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

        public List<JinChuZiLiaoItem> getSetStockDetailDB(string gongsi, string warehouse)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                        var warehouseParam = new MySqlParameter("@warehouse", warehouse);

                        // 保留原有格式，添加仓库筛选
                        string sql = "select *,IFNULL((select sum(CASE WHEN mxtype IN ('入库', '调拨入库', '盘盈入库') THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi and cangku = @warehouse),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";

                        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam, warehouseParam);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var gongsiParam = new System.Data.SqlClient.SqlParameter("@gongsi", gongsi);
                        var warehouseParam = new System.Data.SqlClient.SqlParameter("@warehouse", warehouse);

                        // SQL Server版本，添加仓库筛选
                        string sql = "select *,ISNULL((select sum(CASE WHEN mxtype IN ('入库', '调拨入库', '盘盈入库') THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi_mssql where cpname = j.name and gs_name = @gongsi and cangku = @warehouse),0) as maxNum from yh_jinxiaocun_jichuziliao_mssql as j where gs_name = @gongsi";

                        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam, warehouseParam);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                var warehouseParam = new MySqlParameter("@warehouse", warehouse);

                string sql = "select *,IFNULL((select sum(CASE WHEN mxtype IN ('入库', '调拨入库', '盘盈入库') THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi and cangku = @warehouse),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";

                var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam, warehouseParam);
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
                        string sql = "select *,IFNULL((select sum(CASE WHEN mxtype IN ('出库','调拨出库','盘亏出库') THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var gongsiParam = new System.Data.SqlClient.SqlParameter("@gongsi", gongsi);
                        string sql = "select *,ISNULL((select sum(CASE WHEN mxtype IN ('出库','调拨出库','盘亏出库') THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi_mssql where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao_mssql as j where gs_name = @gongsi";
                        var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                string sql = "select *,IFNULL((select sum(CASE WHEN mxtype IN ('出库','调拨出库','盘亏出库') THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                return result.ToList();
            }
        }


        public List<QiChuQiMoShuItem> getOutStockDetailQM(string gongsi, string startDate, string endDate, string cpname, string cangku)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                        var parameters = new List<MySqlParameter>();
                        parameters.Add(gongsiParam);

                        // 构建共同的查询条件部分
                        string commonConditions = "";

                        // 添加仓库条件
                        if (!string.IsNullOrEmpty(cangku))
                        {
                            commonConditions = " AND m.cangku = @cangku";
                            parameters.Add(new MySqlParameter("@cangku", cangku));
                        }

                        // 构建期初和期末的日期条件
                        string qichuDateCondition = "";
                        string qimoDateCondition = "";

                        if (!string.IsNullOrEmpty(startDate))
                        {
                            qichuDateCondition = " AND m.shijian <= @startDate";
                            parameters.Add(new MySqlParameter("@startDate", startDate));
                        }

                        if (!string.IsNullOrEmpty(endDate))
                        {
                            qimoDateCondition = " AND m.shijian <= @endDate";
                            parameters.Add(new MySqlParameter("@endDate", endDate + " 23:59:59"));
                        }

                        // 构建商品名称条件
                        string cpnameCondition = "";
                        if (!string.IsNullOrEmpty(cpname))
                        {
                            cpnameCondition = " AND j.name LIKE @cpname";
                            parameters.Add(new MySqlParameter("@cpname", "%" + cpname + "%"));
                        }

                        // 使用StringBuilder构建SQL，避免字符串过长
                        StringBuilder sqlBuilder = new StringBuilder();

                        sqlBuilder.Append(@"
                    SELECT 
                        j.id,
                        j.sp_dm,
                        j.name,
                        j.lei_bie,
                        j.mark1,
                        -- 期初数量
                        ROUND(IFNULL((
                            SELECT SUM(CASE 
                                WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN (m.cpsl * -1)
                                ELSE m.cpsl
                            END)
                            FROM yh_jinxiaocun_mingxi m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加期初查询的仓库和日期条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(qichuDateCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qichu_shuliang,
                        -- 期初金额
                        ROUND(IFNULL((
                            SELECT SUM(
                                CASE 
                                    WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN TRIM(m.cpsj) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END * -1)
                                    ELSE 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN TRIM(m.cpsj) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END)
                                END
                            )
                            FROM yh_jinxiaocun_mingxi m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加期初金额查询的条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(qichuDateCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qichu_jine,
                        -- 期末数量
                        ROUND(IFNULL((
                            SELECT SUM(CASE 
                                WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN (m.cpsl * -1) 
                                ELSE m.cpsl
                            END)
                            FROM yh_jinxiaocun_mingxi m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加期末数量查询的条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(qimoDateCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qimo_shuliang,
                        -- 期末金额
                        ROUND(IFNULL((
                            SELECT SUM(
                                CASE 
                                    WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN TRIM(m.cpsj) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END * -1)
                                    ELSE 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN TRIM(m.cpsj) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END)
                                END
                            )
                            FROM yh_jinxiaocun_mingxi m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加期末金额查询的条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(qimoDateCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qimo_jine
                    FROM yh_jinxiaocun_jichuziliao as j 
                    WHERE j.gs_name = @gongsi");

                        sqlBuilder.Append(cpnameCondition);

                        string sql = sqlBuilder.ToString();
                        var result = sen.Database.SqlQuery<QiChuQiMoShuItem>(sql, parameters.ToArray());
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var gongsiParam = new System.Data.SqlClient.SqlParameter("@gongsi", gongsi);
                        var parameters = new List<System.Data.SqlClient.SqlParameter>();
                        parameters.Add(gongsiParam);

                        // 构建共同的查询条件部分
                        string commonConditions = "";

                        // 添加仓库条件
                        if (!string.IsNullOrEmpty(cangku))
                        {
                            commonConditions = " AND m.cangku = @cangku";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@cangku", cangku));
                        }

                        // 构建期初和期末的日期条件
                        string qichuDateCondition = "";
                        string qimoDateCondition = "";

                        if (!string.IsNullOrEmpty(startDate))
                        {
                            qichuDateCondition = " AND m.shijian <= @startDate";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@startDate", startDate));
                        }

                        if (!string.IsNullOrEmpty(endDate))
                        {
                            qimoDateCondition = " AND m.shijian <= @endDate";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@endDate", endDate + " 23:59:59"));
                        }

                        // 构建商品名称条件
                        string cpnameCondition = "";
                        if (!string.IsNullOrEmpty(cpname))
                        {
                            cpnameCondition = " AND j.name LIKE @cpname";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@cpname", "%" + cpname + "%"));
                        }

                        // 使用StringBuilder构建SQL，避免字符串过长
                        StringBuilder sqlBuilder = new StringBuilder();

                        sqlBuilder.Append(@"
                    SELECT 
                        j.id,
                        j.sp_dm,
                        j.name,
                        j.lei_bie,
                        j.mark1,
                        -- 期初数量
                        ROUND(ISNULL((
                            SELECT SUM(CASE 
                                WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN m.cpsl 
                                ELSE (m.cpsl * -1) 
                            END)
                            FROM yh_jinxiaocun_mingxi_mssql m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加期初查询的仓库和日期条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(qichuDateCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qichu_shuliang,
                        -- 期初金额
                        ROUND(ISNULL((
                            SELECT SUM(
                                CASE 
                                    WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN LTRIM(RTRIM(m.cpsj)) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END * -1)
                                    ELSE 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN LTRIM(RTRIM(m.cpsj)) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END)
                                END
                            )
                            FROM yh_jinxiaocun_mingxi_mssql m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加期初金额查询的条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(qichuDateCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qichu_jine,
                        -- 期末数量
                        ROUND(ISNULL((
                            SELECT SUM(CASE 
                                WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN m.cpsl 
                                ELSE (m.cpsl * -1) 
                            END)
                            FROM yh_jinxiaocun_mingxi_mssql m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加期末数量查询的条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(qimoDateCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qimo_shuliang,
                        -- 期末金额
                        ROUND(ISNULL((
                            SELECT SUM(
                                CASE 
                                    WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN LTRIM(RTRIM(m.cpsj)) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END * -1)
                                    ELSE 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN LTRIM(RTRIM(m.cpsj)) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END)
                                END
                            )
                            FROM yh_jinxiaocun_mingxi_mssql m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加期末金额查询的条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(qimoDateCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qimo_jine
                    FROM yh_jinxiaocun_jichuziliao_mssql as j 
                    WHERE j.gs_name = @gongsi");

                        sqlBuilder.Append(cpnameCondition);

                        string sql = sqlBuilder.ToString();
                        var result = sen.Database.SqlQuery<QiChuQiMoShuItem>(sql, parameters.ToArray());
                        return result.ToList();
                    }
                }
            }

            return new List<QiChuQiMoShuItem>();
        }


        public List<QiChuQiMoShuItem> getOutStockDetailJY(string gongsi, string shijian, string shuliang, string cpname, string cangku)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var gongsiParam = new MySqlParameter("@gongsi", gongsi);
                        var parameters = new List<MySqlParameter>();
                        parameters.Add(gongsiParam);

                        // 构建共同的查询条件部分
                        string commonConditions = "";

                        // 添加仓库条件
                        if (!string.IsNullOrEmpty(cangku))
                        {
                            commonConditions = " AND m.cangku = @cangku";
                            parameters.Add(new MySqlParameter("@cangku", cangku));
                        }

                        // 构建商品名称条件
                        string cpnameCondition = "";
                        if (!string.IsNullOrEmpty(cpname))
                        {
                            cpnameCondition = " AND j.name LIKE @cpname";
                            parameters.Add(new MySqlParameter("@cpname", "%" + cpname + "%"));
                        }

                        // 构建积压时间条件
                        string timeCondition = "";
                        if (!string.IsNullOrEmpty(shijian))
                        {
                            // 将shijian参数转换为天数
                            int days;
                            if (int.TryParse(shijian, out days))
                            {
                                // 计算截止日期：当前时间减去指定天数
                                DateTime endDate = DateTime.Now.AddDays(-days);
                                timeCondition = " AND m.shijian <= @endDate";
                                parameters.Add(new MySqlParameter("@endDate", endDate.ToString("yyyy-MM-dd")));
                            }
                        }

                        // 构建数量条件
                        string quantityCondition = "";
                        decimal quantity = 0;
                        if (!string.IsNullOrEmpty(shuliang))
                        {
                            // 将shuliang参数转换为数字
                            if (decimal.TryParse(shuliang, out quantity))
                            {
                                // 将在HAVING子句中添加数量条件
                                quantityCondition = " HAVING current_qty > @quantity";
                                parameters.Add(new MySqlParameter("@quantity", quantity));
                            }
                        }

                        // 使用StringBuilder构建SQL，避免字符串过长
                        StringBuilder sqlBuilder = new StringBuilder();

                        sqlBuilder.Append(@"
                    SELECT 
                        j.id,
                        j.sp_dm,
                        j.name,
                        j.lei_bie,
                        j.mark1,
                        -- 当前库存数量（保留两位小数）
                        ROUND(IFNULL((
                            SELECT SUM(CASE 
                                WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN (m.cpsl * -1)
                                ELSE m.cpsl
                            END)
                            FROM yh_jinxiaocun_mingxi m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加仓库和时间条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(timeCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qimo_shuliang, -- 当前库存作为期末数量
                        -- 当前库存金额
                        ROUND(IFNULL((
                            SELECT SUM(
                                CASE 
                                    WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN TRIM(m.cpsj) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END * -1)
                                    ELSE 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN TRIM(m.cpsj) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END)
                                END
                            )
                            FROM yh_jinxiaocun_mingxi m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        // 添加仓库和时间条件
                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(timeCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qimo_jine, -- 当前库存金额作为期末金额
                        -- 积压天数（如果shijian有值，返回超过指定天数的库存）
                        CASE WHEN @shijian_days > 0 THEN 
                            DATEDIFF(NOW(), (
                                SELECT MAX(m.shijian) 
                                FROM yh_jinxiaocun_mingxi m 
                                WHERE m.cpname = j.name 
                                    AND m.gs_name = @gongsi
                                    AND m.cpsl > 0
                                    ");

                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(@"
                            ))
                        ELSE 0 END as jiya_days,
                        -- 期初数量和金额置为0，因为我们只关心当前库存
                        0 as qichu_shuliang,
                        0 as qichu_jine
                    FROM yh_jinxiaocun_jichuziliao as j 
                    WHERE j.gs_name = @gongsi");

                        sqlBuilder.Append(cpnameCondition);

                        // 添加数量筛选条件（HAVING子句）
                        if (!string.IsNullOrEmpty(shuliang) && quantity > 0)
                        {
                            // 修正：为子查询创建独立的条件，修正别名
                            string subqueryConditions = "";
                            if (!string.IsNullOrEmpty(cangku))
                            {
                                subqueryConditions = " AND m2.cangku = @cangku";
                                // 参数已经添加，不需要重复添加
                            }

                            if (!string.IsNullOrEmpty(timeCondition))
                            {
                                // 修正时间条件的别名
                                string correctedTimeCondition = timeCondition.Replace("m.shijian", "m2.shijian");
                                subqueryConditions += correctedTimeCondition;
                            }

                            sqlBuilder.Append(@"
                    AND EXISTS (
                        SELECT 1
                        FROM yh_jinxiaocun_mingxi m2
                        WHERE m2.cpname = j.name 
                            AND m2.gs_name = @gongsi
                            ");
                            sqlBuilder.Append(subqueryConditions);
                            sqlBuilder.Append(@"
                        GROUP BY m2.cpname, m2.cangku
                        HAVING SUM(CASE 
                            WHEN m2.mxtype IN ('出库','调拨出库','盘亏出库') THEN (m2.cpsl * -1)
                            ELSE m2.cpsl
                        END) > @quantity
                    )");
                        }

                        // 添加积压天数筛选条件
                        if (!string.IsNullOrEmpty(shijian))
                        {
                            int days;
                            if (int.TryParse(shijian, out days))
                            {
                                parameters.Add(new MySqlParameter("@shijian_days", days));

                                // 修正：为积压天数子查询创建独立的条件，修正别名
                                string subqueryConditions = "";
                                if (!string.IsNullOrEmpty(cangku))
                                {
                                    subqueryConditions = " AND m3.cangku = @cangku";
                                }

                                sqlBuilder.Append(@"
                            AND EXISTS (
                                SELECT 1
                                FROM yh_jinxiaocun_mingxi m3
                                WHERE m3.cpname = j.name 
                                    AND m3.gs_name = @gongsi
                                    ");
                                sqlBuilder.Append(subqueryConditions);
                                sqlBuilder.Append(@"
                                AND DATEDIFF(NOW(), m3.shijian) > @shijian_days
                            )");
                            }
                        }

                        string sql = sqlBuilder.ToString();
                        var result = sen.Database.SqlQuery<QiChuQiMoShuItem>(sql, parameters.ToArray());

                        // 过滤结果：如果设置了shuliang参数，只返回库存大于该值的记录
                        var resultList = result.ToList();
                        if (!string.IsNullOrEmpty(shuliang))
                        {
                            decimal qtyFilter;
                            if (decimal.TryParse(shuliang, out qtyFilter))
                            {
                                var filteredList = new List<QiChuQiMoShuItem>();
                                foreach (var item in resultList)
                                {
                                    try
                                    {
                                        decimal currentQty = Convert.ToDecimal(item.qimo_shuliang);
                                        if (currentQty > qtyFilter)
                                        {
                                            filteredList.Add(item);
                                        }
                                    }
                                    catch
                                    {
                                        // 如果转换失败，跳过此项
                                        continue;
                                    }
                                }
                                resultList = filteredList;
                            }
                        }
                        return resultList;
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var gongsiParam = new System.Data.SqlClient.SqlParameter("@gongsi", gongsi);
                        var parameters = new List<System.Data.SqlClient.SqlParameter>();
                        parameters.Add(gongsiParam);

                        // 构建共同的查询条件部分
                        string commonConditions = "";

                        // 添加仓库条件
                        if (!string.IsNullOrEmpty(cangku))
                        {
                            commonConditions = " AND m.cangku = @cangku";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@cangku", cangku));
                        }

                        // 构建商品名称条件
                        string cpnameCondition = "";
                        if (!string.IsNullOrEmpty(cpname))
                        {
                            cpnameCondition = " AND j.name LIKE @cpname";
                            parameters.Add(new System.Data.SqlClient.SqlParameter("@cpname", "%" + cpname + "%"));
                        }

                        // 构建积压时间条件
                        string timeCondition = "";
                        if (!string.IsNullOrEmpty(shijian))
                        {
                            int days;
                            if (int.TryParse(shijian, out days))
                            {
                                DateTime endDate = DateTime.Now.AddDays(-days);
                                timeCondition = " AND m.shijian <= @endDate";
                                parameters.Add(new System.Data.SqlClient.SqlParameter("@endDate", endDate));
                            }
                        }

                        // 构建数量条件
                        string quantityCondition = "";
                        decimal quantity = 0;
                        if (!string.IsNullOrEmpty(shuliang))
                        {
                            // 将shuliang参数转换为数字
                            if (decimal.TryParse(shuliang, out quantity))
                            {
                                // 将在HAVING子句中添加数量条件
                                quantityCondition = " HAVING current_qty > @quantity";
                                parameters.Add(new System.Data.SqlClient.SqlParameter("@quantity", quantity));
                            }
                        }

                        // SQL Server版本的查询
                        StringBuilder sqlBuilder = new StringBuilder();

                        sqlBuilder.Append(@"
                    SELECT 
                        j.id,
                        j.sp_dm,
                        j.name,
                        j.lei_bie,
                        j.mark1,
                        -- 当前库存数量
                        ROUND(ISNULL((
                            SELECT SUM(CASE 
                                WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN m.cpsl 
                                ELSE (m.cpsl * -1) 
                            END)
                            FROM yh_jinxiaocun_mingxi_mssql m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(timeCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qimo_shuliang,
                        -- 当前库存金额
                        ROUND(ISNULL((
                            SELECT SUM(
                                CASE 
                                    WHEN m.mxtype IN ('出库','调拨出库','盘亏出库') THEN 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN LTRIM(RTRIM(m.cpsj)) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END * -1)
                                    ELSE 
                                        (m.cpsl * 
                                         CASE 
                                            WHEN LTRIM(RTRIM(m.cpsj)) != '' AND m.cpsj IS NOT NULL THEN m.cpsj 
                                            ELSE 0 
                                         END)
                                END
                            )
                            FROM yh_jinxiaocun_mingxi_mssql m
                            WHERE m.cpname = j.name 
                                AND m.gs_name = @gongsi
                                ");

                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(timeCondition);

                        sqlBuilder.Append(@"
                        ), 0), 2) as qimo_jine,
                        -- 积压天数（SQL Server使用DATEDIFF）
                        CASE WHEN @shijian_days > 0 THEN 
                            DATEDIFF(DAY, (
                                SELECT MAX(m.shijian) 
                                FROM yh_jinxiaocun_mingxi_mssql m 
                                WHERE m.cpname = j.name 
                                    AND m.gs_name = @gongsi
                                    AND m.cpsl > 0
                                    ");

                        sqlBuilder.Append(commonConditions);
                        sqlBuilder.Append(@"
                            ), GETDATE())
                        ELSE 0 END as jiya_days,
                        -- 期初数量和金额置为0
                        0 as qichu_shuliang,
                        0 as qichu_jine
                    FROM yh_jinxiaocun_jichuziliao_mssql as j 
                    WHERE j.gs_name = @gongsi");

                        sqlBuilder.Append(cpnameCondition);

                        // 添加数量筛选条件
                        if (!string.IsNullOrEmpty(shuliang) && quantity > 0)
                        {
                            // 修正：为子查询创建独立的条件，修正别名
                            string subqueryConditions = "";
                            if (!string.IsNullOrEmpty(cangku))
                            {
                                subqueryConditions = " AND m2.cangku = @cangku";
                            }

                            if (!string.IsNullOrEmpty(timeCondition))
                            {
                                // 修正时间条件的别名
                                string correctedTimeCondition = timeCondition.Replace("m.shijian", "m2.shijian");
                                subqueryConditions += correctedTimeCondition;
                            }

                            sqlBuilder.Append(@"
                    AND EXISTS (
                        SELECT 1
                        FROM yh_jinxiaocun_mingxi_mssql m2
                        WHERE m2.cpname = j.name 
                            AND m2.gs_name = @gongsi
                            ");
                            sqlBuilder.Append(subqueryConditions);
                            sqlBuilder.Append(@"
                        GROUP BY m2.cpname, m2.cangku
                        HAVING SUM(CASE 
                            WHEN m2.mxtype IN ('出库','调拨出库','盘亏出库') THEN m2.cpsl 
                            ELSE (m2.cpsl * -1) 
                        END) > @quantity
                    )");
                        }

                        // 添加积压天数筛选条件
                        if (!string.IsNullOrEmpty(shijian))
                        {
                            int days;
                            if (int.TryParse(shijian, out days))
                            {
                                parameters.Add(new System.Data.SqlClient.SqlParameter("@shijian_days", days));

                                // 修正：为积压天数子查询创建独立的条件，修正别名
                                string subqueryConditions = "";
                                if (!string.IsNullOrEmpty(cangku))
                                {
                                    subqueryConditions = " AND m3.cangku = @cangku";
                                }

                                sqlBuilder.Append(@"
                            AND EXISTS (
                                SELECT 1
                                FROM yh_jinxiaocun_mingxi_mssql m3
                                WHERE m3.cpname = j.name 
                                    AND m3.gs_name = @gongsi
                                    ");
                                sqlBuilder.Append(subqueryConditions);
                                sqlBuilder.Append(@"
                                AND DATEDIFF(DAY, m3.shijian, GETDATE()) > @shijian_days
                            )");
                            }
                        }

                        string sql = sqlBuilder.ToString();
                        var result = sen.Database.SqlQuery<QiChuQiMoShuItem>(sql, parameters.ToArray());

                        // 过滤结果：如果设置了shuliang参数，只返回库存大于该值的记录
                        var resultList = result.ToList();
                        if (!string.IsNullOrEmpty(shuliang))
                        {
                            decimal qtyFilter;
                            if (decimal.TryParse(shuliang, out qtyFilter))
                            {
                                var filteredList = new List<QiChuQiMoShuItem>();
                                foreach (var item in resultList)
                                {
                                    try
                                    {
                                        decimal currentQty = Convert.ToDecimal(item.qimo_shuliang);
                                        if (currentQty > qtyFilter)
                                        {
                                            filteredList.Add(item);
                                        }
                                    }
                                    catch
                                    {
                                        // 如果转换失败，跳过此项
                                        continue;
                                    }
                                }
                                resultList = filteredList;
                            }
                        }
                        return resultList;
                    }
                }
            }

            return new List<QiChuQiMoShuItem>();
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