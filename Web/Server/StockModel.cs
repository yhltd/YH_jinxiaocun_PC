using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.JxcServer;
using MySql.Data.MySqlClient; 

namespace Web.Server
{
    public class StockModel
    {

        //public int get_jxc_PageCount(string gongsi) {
        //    using (ServerEntities sen = new ServerEntities()) {
        //        string sql = "select count(cpid) from (select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje from (select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje from(select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje from(select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = '" + gongsi + "' union select sp_dm,cpname,cplb from  yh_jinxiaocun_mingxi where gs_name = '" + gongsi + "') as cp left join (select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje from yh_jinxiaocun_qichushu where gs_name = '" + gongsi + "' GROUP BY cpid,cpname,cplb) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb) as link_qc left join (select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = '" + gongsi + "' and shijian between '1900-01-01' and '2100-12-31' group by sp_dm,cpname,cplb) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname  and rk.cplb = link_qc.cplb) as link_rk left join (select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = '" + gongsi + "' and shijian between '1900-01-01' and '2100-12-31' group by sp_dm,cpname,cplb) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb) as jxc left join(select sp_dm,lei_bie,`name`,bianyuan,mark1 from yh_jinxiaocun_jichuziliao where gs_name = '" + gongsi + "') as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie";
        //        return sen.Database.SqlQuery<int>(sql).SingleOrDefault();
        //    }
        //}
        public int get_jxc_PageCount(string gongsi)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = "select count(cpid) from (select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje from (select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje from(select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje from(select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = '" + gongsi + "' union select sp_dm,cpname,cplb from  yh_jinxiaocun_mingxi where gs_name = '" + gongsi + "') as cp left join (select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje from yh_jinxiaocun_qichushu where gs_name = '" + gongsi + "' GROUP BY cpid,cpname,cplb) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb) as link_qc left join (select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = '" + gongsi + "' and shijian between '1900-01-01' and '2100-12-31' group by sp_dm,cpname,cplb) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname  and rk.cplb = link_qc.cplb) as link_rk left join (select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = '" + gongsi + "' and shijian between '1900-01-01' and '2100-12-31' group by sp_dm,cpname,cplb) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb) as jxc left join(select sp_dm,lei_bie,`name`,bianyuan,mark1 from yh_jinxiaocun_jichuziliao where gs_name = '" + gongsi + "') as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie";
                        return sen.Database.SqlQuery<int>(sql).SingleOrDefault();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"select count(cpid) from (
                    select isnull(link_rk.cpid,'') as cpid,isnull(link_rk.cpname,'') as cpname,isnull(link_rk.cplb,'') as cplb,
                    isnull(link_rk.cpsl,0) as qcsl,isnull(link_rk.cpje,0) as qcje,isnull(link_rk.rksl,0) as rksl,
                    isnull(link_rk.rkje,0) as rkje,isnull(ck.cksl,0) as cksl,isnull(ck.ckje,0) as ckje,
                    isnull(cpsl,0)+isnull(rksl,0)-isnull(cksl,0) as jcsl,isnull(cpje,0)+isnull(rkje,0)-isnull(ckje,0) as jcje 
                    from (
                        select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                        from(
                            select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                            from(
                                select cpid,cpname,cplb from yh_jinxiaocun_qichushu_mssql where gs_name = @gongsi 
                                union 
                                select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi_mssql where gs_name = @gongsi
                            ) as cp 
                            left join (
                                select cpid,cplb,cpname,
                                sum(case when cpsl is null or cpsl = '' then 0 else CAST(cpsl as decimal(18,2)) end) as cpsl,
                                sum(case when cpsl is null or cpsl = '' or cpsj is null or cpsj = '' then 0 else CAST(cpsj as decimal(18,2)) * CAST(cpsl as decimal(18,2)) end) as cpje 
                                from yh_jinxiaocun_qichushu_mssql where gs_name = @gongsi 
                                GROUP BY cpid,cpname,cplb
                            ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                        ) as link_qc 
                        left join (
                            select sp_dm,cpname,cplb,
                            sum(case when cpsl is null or cpsl = '' then 0 else CAST(cpsl as decimal(18,2)) end) as rksl,
                            sum(case when cpsl is null or cpsl = '' or cpsj is null or cpsj = '' then 0 else CAST(cpsj as decimal(18,2)) * CAST(cpsl as decimal(18,2)) end) as rkje 
                            from yh_jinxiaocun_mingxi_mssql 
                            where mxtype = '入库' and gs_name = @gongsi and shijian between '1900-01-01' and '2100-12-31' 
                            group by sp_dm,cpname,cplb
                        ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
                    ) as link_rk 
                    left join (
                        select sp_dm,cpname,cplb,
                        sum(case when cpsl is null or cpsl = '' then 0 else CAST(cpsl as decimal(18,2)) end) as cksl,
                        sum(case when cpsl is null or cpsl = '' or cpsj is null or cpsj = '' then 0 else CAST(cpsj as decimal(18,2)) * CAST(cpsl as decimal(18,2)) end) as ckje 
                        from yh_jinxiaocun_mingxi_mssql 
                        where mxtype = '出库' and gs_name = @gongsi and shijian between '1900-01-01' and '2100-12-31' 
                        group by sp_dm,cpname,cplb
                    ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
                ) as jxc 
                left join(
                    select sp_dm,lei_bie,[name],bianyuan,mark1 
                    from yh_jinxiaocun_jichuziliao_mssql where gs_name = @gongsi
                ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.[name] and jxc.cplb = bian_yuan.lei_bie";

                        return sen.Database.SqlQuery<int>(sql, new System.Data.SqlClient.SqlParameter("@gongsi", gongsi)).SingleOrDefault();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select count(cpid) from (
            select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,
            ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,
            ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,
            ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje 
            from (
                select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                from(
                    select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                    from(
                        select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = @gongsi 
                        union 
                        select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongsi
                    ) as cp 
                    left join (
                        select cpid,cplb,cpname,
                        sum(case when ISNULL(cpsl,'') = '' then 0 else CAST(cpsl as decimal(18,2)) end) as cpsl,
                        sum(case when ISNULL(cpsl,'') = '' or ISNULL(cpsj,'') = '' then 0 else CAST(cpsj as decimal(18,2)) * CAST(cpsl as decimal(18,2)) end) as cpje 
                        from yh_jinxiaocun_qichushu where gs_name = @gongsi 
                        GROUP BY cpid,cpname,cplb
                    ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                ) as link_qc 
                left join (
                    select sp_dm,cpname,cplb,
                    sum(case when ISNULL(cpsl,'') = '' then 0 else CAST(cpsl as decimal(18,2)) end) as rksl,
                    sum(case when ISNULL(cpsl,'') = '' or ISNULL(cpsj,'') = '' then 0 else CAST(cpsj as decimal(18,2)) * CAST(cpsl as decimal(18,2)) end) as rkje 
                    from yh_jinxiaocun_mingxi 
                    where mxtype = '入库' and gs_name = @gongsi and shijian between '1900-01-01' and '2100-12-31' 
                    group by sp_dm,cpname,cplb
                ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
            ) as link_rk 
            left join (
                select sp_dm,cpname,cplb,
                sum(case when ISNULL(cpsl,'') = '' then 0 else CAST(cpsl as decimal(18,2)) end) as cksl,
                sum(case when ISNULL(cpsl,'') = '' or ISNULL(cpsj,'') = '' then 0 else CAST(cpsj as decimal(18,2)) * CAST(cpsl as decimal(18,2)) end) as ckje 
                from yh_jinxiaocun_mingxi 
                where mxtype = '出库' and gs_name = @gongsi and shijian between '1900-01-01' and '2100-12-31' 
                group by sp_dm,cpname,cplb
            ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
        ) as jxc 
        left join(
            select sp_dm,lei_bie,`name`,bianyuan,mark1 
            from yh_jinxiaocun_jichuziliao where gs_name = @gongsi
        ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie";

                return sen.Database.SqlQuery<int>(sql, new MySqlParameter("@gongsi", gongsi)).SingleOrDefault();
            }
        }

        //public List<jxc_z_info> jxc_z_select(string gs_name, string code, int limit1, int limit2)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string limit = " limit " + limit1 + "," + limit2;
        //        var time_start = DateTime.Now.ToString("yyyy-MM-01");
        //        var time_end = DateTime.Now.ToString("yyyy-MM-31");
        //        string[] mm = time_start.Split('-');
        //        int m = Convert.ToInt32(mm[1]);
        //        if (m == 2)
        //        {
        //            time_end = DateTime.Now.ToString("yyyy-MM-28");
        //        }
        //        else
        //        {
        //            time_end = DateTime.Now.ToString("yyyy-MM-31");
        //        }

        //        string sql = "select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 from (select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje from (select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje from(select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje from(select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' union select sp_dm,cpname,cplb from  yh_jinxiaocun_mingxi where gs_name = '" + gs_name + "') as cp left join (select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' GROUP BY cpid,cpname,cplb) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb) as link_qc left join (select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = '" + gs_name + "' and shijian between '" + time_start + "' and '" + time_end + "' group by sp_dm,cpname,cplb) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname  and rk.cplb = link_qc.cplb) as link_rk left join (select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = '" + gs_name + "' and shijian between '" + time_start + "' and '" + time_end + "' group by sp_dm,cpname,cplb) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb) as jxc left join(select sp_dm,lei_bie,`name`,bianyuan,mark1 from yh_jinxiaocun_jichuziliao where gs_name = '" + gs_name + "') as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie  where cpid like '%" + code + "%'";
        //        //string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,ifnull(sum(jq.cpsl),0) as jq_cpsl,ifnull(sum(jq.cpsl*jq.cpsj),0) as jq_price,ifnull(mx_ruku.cpsl,0) as mx_ruku_cpsl,ifnull(mx_ruku.cp_price,0) as mx_ruku_price,ifnull(mx_chuku.cpsl,0) as mx_chuku_cpsl,ifnull(mx_chuku.cp_price,0) as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '入库' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '出库' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc";
        //        //string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,sum(jq.cpsl) as jq_cpsl,sum(jq.cpsl*jq.cpsj) as jq_price,mx_ruku.cpsl as mx_ruku_cpsl,mx_ruku.cp_price as mx_ruku_price,mx_chuku.cpsl as mx_chuku_cpsl,mx_chuku.cp_price as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '入库' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '出库' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc" + limit;

        //        var result = sen.Database.SqlQuery<jxc_z_info>(sql);
        //        return result.ToList();
        //    }
        //}

        public List<jxc_z_info> jxc_z_select(string gs_name, string code, int limit1, int limit2)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        var time_start = DateTime.Now.ToString("yyyy-MM-01");
                        var time_end = DateTime.Now.ToString("yyyy-MM-31");
                        string[] mm = time_start.Split('-');
                        int m = Convert.ToInt32(mm[1]);
                        if (m == 2)
                        {
                            time_end = DateTime.Now.ToString("yyyy-MM-28");
                        }
                        else
                        {
                            time_end = DateTime.Now.ToString("yyyy-MM-31");
                        }

                        string sql = @"select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,
                    rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,
                    jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 
                    from (
                        select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,
                        ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,
                        ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,
                        ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje 
                        from (
                            select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                            from(
                                select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                                from(
                                    select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                                    union 
                                    select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gs_name
                                ) as cp 
                                left join (
                                    select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje 
                                    from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                                    GROUP BY cpid,cpname,cplb
                                ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                            ) as link_qc 
                            left join (
                                select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje 
                                from yh_jinxiaocun_mingxi 
                                where mxtype = '入库' and gs_name = @gs_name and shijian between @time_start and @time_end 
                                group by sp_dm,cpname,cplb
                            ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
                        ) as link_rk 
                        left join (
                            select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje 
                            from yh_jinxiaocun_mingxi 
                            where mxtype = '出库' and gs_name = @gs_name and shijian between @time_start and @time_end 
                            group by sp_dm,cpname,cplb
                        ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
                    ) as jxc 
                    left join(
                        select sp_dm,lei_bie,`name`,bianyuan,mark1 
                        from yh_jinxiaocun_jichuziliao where gs_name = @gs_name
                    ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie  
                    where cpid like @code limit @limit1, @limit2";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@gs_name", gs_name),
                    new MySqlParameter("@time_start", time_start),
                    new MySqlParameter("@time_end", time_end),
                    new MySqlParameter("@code", "%" + code + "%"),
                    new MySqlParameter("@limit1", limit1),
                    new MySqlParameter("@limit2", limit2)
                };

                        var result = sen.Database.SqlQuery<jxc_z_info>(sql, parameters);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        // 使用正确的日期格式
                        var time_start = DateTime.Now.ToString("yyyy-MM-dd");
                        var time_end = DateTime.Now.ToString("yyyy-MM-dd");

                        // 获取当月第一天和最后一天
                        var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                        time_start = firstDayOfMonth.ToString("yyyy-MM-dd");
                        time_end = lastDayOfMonth.ToString("yyyy-MM-dd");

                        // SQL Server 兼容版本
                        string sql = @"
SELECT * FROM (
    SELECT 
        cpid as sp_dm,
        cpname as [name],
        cplb as lei_bie,
        CONVERT(varchar(50), CONVERT(decimal(18,2), ISNULL(qcsl, 0))) as jq_cpsl,
        CONVERT(varchar(50), CONVERT(decimal(18,2), ISNULL(qcje, 0))) as jq_price,
        CONVERT(varchar(50), CONVERT(decimal(18,2), ISNULL(rksl, 0))) as mx_ruku_cpsl,
        CONVERT(varchar(50), CONVERT(decimal(18,2), ISNULL(rkje, 0))) as mx_ruku_price,
        CONVERT(varchar(50), CONVERT(decimal(18,2), ISNULL(cksl, 0))) as mx_chuku_cpsl,
        CONVERT(varchar(50), CONVERT(decimal(18,2), ISNULL(ckje, 0))) as mx_chuku_price,
        CONVERT(varchar(50), CONVERT(decimal(18,2), ISNULL(jcsl, 0))) as jc_sl,
        CONVERT(varchar(50), CONVERT(decimal(18,2), ISNULL(jcje, 0))) as jc_price,
        ISNULL(bian_yuan.bianyuan, '') as bianyuan,
        ISNULL(bian_yuan.mark1, '') as mark1,
        ROW_NUMBER() OVER (ORDER BY cpid) as RowNum
    FROM (
        SELECT 
            ISNULL(link_rk.cpid, '') as cpid,
            ISNULL(link_rk.cpname, '') as cpname,
            ISNULL(link_rk.cplb, '') as cplb,
            CONVERT(decimal(18,2), ISNULL(link_rk.cpsl, 0)) as qcsl,
            CONVERT(decimal(18,2), ISNULL(link_rk.cpje, 0)) as qcje,
            CONVERT(decimal(18,2), ISNULL(link_rk.rksl, 0)) as rksl,
            CONVERT(decimal(18,2), ISNULL(link_rk.rkje, 0)) as rkje,
            CONVERT(decimal(18,2), ISNULL(ck.cksl, 0)) as cksl,
            CONVERT(decimal(18,2), ISNULL(ck.ckje, 0)) as ckje,
            CONVERT(decimal(18,2), ISNULL(link_rk.cpsl, 0) + ISNULL(link_rk.rksl, 0) - ISNULL(ck.cksl, 0)) as jcsl,
            CONVERT(decimal(18,2), ISNULL(link_rk.cpje, 0) + ISNULL(link_rk.rkje, 0) - ISNULL(ck.ckje, 0)) as jcje 
        FROM (
            SELECT 
                link_qc.cpid,
                link_qc.cpname,
                link_qc.cplb,
                link_qc.cpsl,
                link_qc.cpje,
                rk.rksl,
                rk.rkje 
            FROM (
                SELECT 
                    cp.cpid,
                    cp.cpname,
                    cp.cplb,
                    qc.cpsl,
                    qc.cpje 
                FROM (
                    SELECT cpid, cpname, cplb FROM yh_jinxiaocun_qichushu_mssql WHERE gs_name = @gs_name 
                    UNION 
                    SELECT sp_dm, cpname, cplb FROM yh_jinxiaocun_mingxi_mssql WHERE gs_name = @gs_name
                ) as cp 
                LEFT JOIN (
                    SELECT 
                        cpid, cplb, cpname,
                        SUM(CASE WHEN cpsl IS NULL OR cpsl = '' THEN 0 ELSE CONVERT(decimal(18,2), cpsl) END) as cpsl,
                        SUM(CASE WHEN cpsl IS NULL OR cpsl = '' OR cpsj IS NULL OR cpsj = '' THEN 0 ELSE CONVERT(decimal(18,2), cpsj) * CONVERT(decimal(18,2), cpsl) END) as cpje 
                    FROM yh_jinxiaocun_qichushu_mssql 
                    WHERE gs_name = @gs_name 
                    GROUP BY cpid, cpname, cplb
                ) as qc ON cp.cpid = qc.cpid AND cp.cpname = qc.cpname AND cp.cplb = qc.cplb
            ) as link_qc 
            LEFT JOIN (
                SELECT 
                    sp_dm, cpname, cplb,
                    SUM(CASE WHEN cpsl IS NULL OR cpsl = '' THEN 0 ELSE CONVERT(decimal(18,2), cpsl) END) as rksl,
                    SUM(CASE WHEN cpsl IS NULL OR cpsl = '' OR cpsj IS NULL OR cpsj = '' THEN 0 ELSE CONVERT(decimal(18,2), cpsj) * CONVERT(decimal(18,2), cpsl) END) as rkje 
                FROM yh_jinxiaocun_mingxi_mssql 
                WHERE mxtype = '入库' AND gs_name = @gs_name AND shijian BETWEEN @time_start AND @time_end 
                GROUP BY sp_dm, cpname, cplb
            ) as rk ON rk.sp_dm = link_qc.cpid AND rk.cpname = link_qc.cpname AND rk.cplb = link_qc.cplb
        ) as link_rk 
        LEFT JOIN (
            SELECT 
                sp_dm, cpname, cplb,
                SUM(CASE WHEN cpsl IS NULL OR cpsl = '' THEN 0 ELSE CONVERT(decimal(18,2), cpsl) END) as cksl,
                SUM(CASE WHEN cpsl IS NULL OR cpsl = '' OR cpsj IS NULL OR cpsj = '' THEN 0 ELSE CONVERT(decimal(18,2), cpsj) * CONVERT(decimal(18,2), cpsl) END) as ckje 
            FROM yh_jinxiaocun_mingxi_mssql 
            WHERE mxtype = '出库' AND gs_name = @gs_name AND shijian BETWEEN @time_start AND @time_end 
            GROUP BY sp_dm, cpname, cplb
        ) as ck ON ck.sp_dm = link_rk.cpid AND ck.cpname = link_rk.cpname AND ck.cplb = link_rk.cplb
    ) as jxc 
    LEFT JOIN (
        SELECT sp_dm, lei_bie, [name], bianyuan, mark1 
        FROM yh_jinxiaocun_jichuziliao_mssql 
        WHERE gs_name = @gs_name
    ) as bian_yuan ON jxc.cpid = bian_yuan.sp_dm AND jxc.cpname = bian_yuan.[name] AND jxc.cplb = bian_yuan.lei_bie  
    WHERE cpid LIKE @code
) AS MyResults
WHERE RowNum BETWEEN @startRow AND @endRow";

                        // 计算行号范围
                        int startRow = limit1 + 1;
                        int endRow = limit1 + limit2;

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name),
                    new System.Data.SqlClient.SqlParameter("@time_start", time_start),
                    new System.Data.SqlClient.SqlParameter("@time_end", time_end),
                    new System.Data.SqlClient.SqlParameter("@code", "%" + code + "%"),
                    new System.Data.SqlClient.SqlParameter("@startRow", startRow),
                    new System.Data.SqlClient.SqlParameter("@endRow", endRow)
                };

                        var result = sen.Database.SqlQuery<jxc_z_info>(sql, parameters);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库（保持不变）
            using (ServerEntities sen = new ServerEntities())
            {
                var time_start = DateTime.Now.ToString("yyyy-MM-01");
                var time_end = DateTime.Now.ToString("yyyy-MM-31");
                string[] mm = time_start.Split('-');
                int m = Convert.ToInt32(mm[1]);
                if (m == 2)
                {
                    time_end = DateTime.Now.ToString("yyyy-MM-28");
                }
                else
                {
                    time_end = DateTime.Now.ToString("yyyy-MM-31");
                }

                string sql = @"select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,
            rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,
            jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 
            from (
                select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,
                ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,
                ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,
                ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje 
                from (
                    select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                    from(
                        select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                        from(
                            select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                            union 
                            select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gs_name
                        ) as cp 
                        left join (
                            select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje 
                            from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                            GROUP BY cpid,cpname,cplb
                        ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                    ) as link_qc 
                    left join (
                        select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje 
                        from yh_jinxiaocun_mingxi 
                        where mxtype = '入库' and gs_name = @gs_name and shijian between @time_start and @time_end 
                        group by sp_dm,cpname,cplb
                    ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
                ) as link_rk 
                left join (
                    select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje 
                    from yh_jinxiaocun_mingxi 
                    where mxtype = '出库' and gs_name = @gs_name and shijian between @time_start and @time_end 
                    group by sp_dm,cpname,cplb
                ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
            ) as jxc 
            left join(
                select sp_dm,lei_bie,`name`,bianyuan,mark1 
                from yh_jinxiaocun_jichuziliao where gs_name = @gs_name
            ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie  
            where cpid like @code limit @limit1, @limit2";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@gs_name", gs_name),
            new MySqlParameter("@time_start", time_start),
            new MySqlParameter("@time_end", time_end),
            new MySqlParameter("@code", "%" + code + "%"),
            new MySqlParameter("@limit1", limit1),
            new MySqlParameter("@limit2", limit2)
        };

                var result = sen.Database.SqlQuery<jxc_z_info>(sql, parameters);
                return result.ToList();
            }
        }

        //public List<jxc_z_info> jxc_select(string gs_name, string code, string start_time, string end_time)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 from (select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje from (select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje from(select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje from(select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' union select sp_dm,cpname,cplb from  yh_jinxiaocun_mingxi where gs_name = '" + gs_name + "') as cp left join (select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' GROUP BY cpid,cpname,cplb) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb) as link_qc left join (select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = '" + gs_name + "' and shijian between '" + start_time + "' and '" + end_time + "' group by sp_dm,cpname,cplb) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname  and rk.cplb = link_qc.cplb) as link_rk left join (select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = '" + gs_name + "' and shijian between '" + start_time + "' and '" + end_time + "' group by sp_dm,cpname,cplb) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb) as jxc left join(select sp_dm,lei_bie,`name`,bianyuan,mark1 from yh_jinxiaocun_jichuziliao where gs_name = '" + gs_name + "') as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie  where cpid like '%" + code + "%'";
        //        //string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,sum(jq.cpsl) as jq_cpsl,sum(jq.cpsl*jq.cpsj) as jq_price,mx_ruku.cpsl as mx_ruku_cpsl,mx_ruku.cp_price as mx_ruku_price,mx_chuku.cpsl as mx_chuku_cpsl,mx_chuku.cp_price as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.zh_name = '1' and jm.gs_name = '1' and jm.mxtype = '入库' and jm.shijian between '" + start_time + "' and '" + end_time + "' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.zh_name = '1' and jm.gs_name = '1' and jm.mxtype = '出库' and jm.shijian between '" + start_time + "' and '" + end_time + "' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc where sp_dm like '%" + code + "%'";

        //        var result = sen.Database.SqlQuery<jxc_z_info>(sql);
        //        return result.ToList();
        //    }
        //}

        public List<jxc_z_info> jxc_select(string gs_name, string code, string start_time, string end_time)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,
                    rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,
                    jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 
                    from (
                        select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,
                        ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,
                        ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,
                        ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje 
                        from (
                            select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                            from(
                                select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                                from(
                                    select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                                    union 
                                    select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gs_name
                                ) as cp 
                                left join (
                                    select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje 
                                    from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                                    GROUP BY cpid,cpname,cplb
                                ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                            ) as link_qc 
                            left join (
                                select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje 
                                from yh_jinxiaocun_mingxi 
                                where mxtype = '入库' and gs_name = @gs_name and shijian between @start_time and @end_time 
                                group by sp_dm,cpname,cplb
                            ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
                        ) as link_rk 
                        left join (
                            select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje 
                            from yh_jinxiaocun_mingxi 
                            where mxtype = '出库' and gs_name = @gs_name and shijian between @start_time and @end_time 
                            group by sp_dm,cpname,cplb
                        ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
                    ) as jxc 
                    left join(
                        select sp_dm,lei_bie,`name`,bianyuan,mark1 
                        from yh_jinxiaocun_jichuziliao where gs_name = @gs_name
                    ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie  
                    where cpid like @code";

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@gs_name", gs_name),
                    new MySqlParameter("@start_time", start_time),
                    new MySqlParameter("@end_time", end_time),
                    new MySqlParameter("@code", "%" + code + "%")
                };

                        var result = sen.Database.SqlQuery<jxc_z_info>(sql, parameters);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"select cpid as sp_dm,cpname as [name],cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,
                    rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,
                    jcsl as jc_sl,jcje as jc_price,isnull(bian_yuan.bianyuan,'') as bianyuan,mark1 
                    from (
                        select isnull(link_rk.cpid,'') as cpid,isnull(link_rk.cpname,'') as cpname,isnull(link_rk.cplb,'') as cplb,
                        isnull(link_rk.cpsl,0) as qcsl,isnull(link_rk.cpje,0) as qcje,isnull(link_rk.rksl,0) as rksl,
                        isnull(link_rk.rkje,0) as rkje,isnull(ck.cksl,0) as cksl,isnull(ck.ckje,0) as ckje,
                        isnull(cpsl,0)+isnull(rksl,0)-isnull(cksl,0) as jcsl,isnull(cpje,0)+isnull(rkje,0)-isnull(ckje,0) as jcje 
                        from (
                            select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                            from(
                                select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                                from(
                                    select cpid,cpname,cplb from yh_jinxiaocun_qichushu_mssql where gs_name = @gs_name 
                                    union 
                                    select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi_mssql where gs_name = @gs_name
                                ) as cp 
                                left join (
                                    select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje 
                                    from yh_jinxiaocun_qichushu_mssql where gs_name = @gs_name 
                                    GROUP BY cpid,cpname,cplb
                                ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                            ) as link_qc 
                            left join (
                                select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje 
                                from yh_jinxiaocun_mingxi_mssql 
                                where mxtype = '入库' and gs_name = @gs_name and shijian between @start_time and @end_time 
                                group by sp_dm,cpname,cplb
                            ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
                        ) as link_rk 
                        left join (
                            select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje 
                            from yh_jinxiaocun_mingxi_mssql 
                            where mxtype = '出库' and gs_name = @gs_name and shijian between @start_time and @end_time 
                            group by sp_dm,cpname,cplb
                        ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
                    ) as jxc 
                    left join(
                        select sp_dm,lei_bie,[name],bianyuan,mark1 
                        from yh_jinxiaocun_jichuziliao_mssql where gs_name = @gs_name
                    ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.[name] and jxc.cplb = bian_yuan.lei_bie  
                    where cpid like @code";

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name),
                    new System.Data.SqlClient.SqlParameter("@start_time", start_time),
                    new System.Data.SqlClient.SqlParameter("@end_time", end_time),
                    new System.Data.SqlClient.SqlParameter("@code", "%" + code + "%")
                };

                        var result = sen.Database.SqlQuery<jxc_z_info>(sql, parameters);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,
            rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,
            jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 
            from (
                select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,
                ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,
                ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,
                ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje 
                from (
                    select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                    from(
                        select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                        from(
                            select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                            union 
                            select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gs_name
                        ) as cp 
                        left join (
                            select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje 
                            from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                            GROUP BY cpid,cpname,cplb
                        ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                    ) as link_qc 
                    left join (
                        select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje 
                        from yh_jinxiaocun_mingxi 
                        where mxtype = '入库' and gs_name = @gs_name and shijian between @start_time and @end_time 
                        group by sp_dm,cpname,cplb
                    ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
                ) as link_rk 
                left join (
                    select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje 
                    from yh_jinxiaocun_mingxi 
                    where mxtype = '出库' and gs_name = @gs_name and shijian between @start_time and @end_time 
                    group by sp_dm,cpname,cplb
                ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
            ) as jxc 
            left join(
                select sp_dm,lei_bie,`name`,bianyuan,mark1 
                from yh_jinxiaocun_jichuziliao where gs_name = @gs_name
            ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie  
            where cpid like @code";

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@gs_name", gs_name),
            new MySqlParameter("@start_time", start_time),
            new MySqlParameter("@end_time", end_time),
            new MySqlParameter("@code", "%" + code + "%")
        };

                var result = sen.Database.SqlQuery<jxc_z_info>(sql, parameters);
                return result.ToList();
            }
        }

        //public List<jxc_z_info> jxc_select_qrcode(string gs_name, string code)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        string sql = "select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 from (select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje from (select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje from(select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje from(select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' union select sp_dm,cpname,cplb from  yh_jinxiaocun_mingxi where gs_name = '" + gs_name + "') as cp left join (select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' GROUP BY cpid,cpname,cplb) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb) as link_qc left join (select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = '" + gs_name + "' group by sp_dm,cpname,cplb) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname  and rk.cplb = link_qc.cplb) as link_rk left join (select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = '" + gs_name + "' group by sp_dm,cpname,cplb) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb) as jxc left join(select sp_dm,lei_bie,`name`,bianyuan,mark1 from yh_jinxiaocun_jichuziliao where gs_name = '" + gs_name + "') as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie " + code;
        //        //string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,sum(jq.cpsl) as jq_cpsl,sum(jq.cpsl*jq.cpsj) as jq_price,mx_ruku.cpsl as mx_ruku_cpsl,mx_ruku.cp_price as mx_ruku_price,mx_chuku.cpsl as mx_chuku_cpsl,mx_chuku.cp_price as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.zh_name = '1' and jm.gs_name = '1' and jm.mxtype = '入库' and jm.shijian between '" + start_time + "' and '" + end_time + "' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.zh_name = '1' and jm.gs_name = '1' and jm.mxtype = '出库' and jm.shijian between '" + start_time + "' and '" + end_time + "' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc where sp_dm like '%" + code + "%'";

        //        var result = sen.Database.SqlQuery<jxc_z_info>(sql);
        //        return result.ToList();
        //    }
        //}
        public List<jxc_z_info> jxc_select_qrcode(string gs_name, string code)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
                {
                    using (ServerEntities sen = new ServerEntities())
                    {
                        string sql = @"select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,
                    rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,
                    jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 
                    from (
                        select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,
                        ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,
                        ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,
                        ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje 
                        from (
                            select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                            from(
                                select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                                from(
                                    select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                                    union 
                                    select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gs_name
                                ) as cp 
                                left join (
                                    select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje 
                                    from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                                    GROUP BY cpid,cpname,cplb
                                ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                            ) as link_qc 
                            left join (
                                select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje 
                                from yh_jinxiaocun_mingxi 
                                where mxtype = '入库' and gs_name = @gs_name 
                                group by sp_dm,cpname,cplb
                            ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
                        ) as link_rk 
                        left join (
                            select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje 
                            from yh_jinxiaocun_mingxi 
                            where mxtype = '出库' and gs_name = @gs_name 
                            group by sp_dm,cpname,cplb
                        ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
                    ) as jxc 
                    left join(
                        select sp_dm,lei_bie,`name`,bianyuan,mark1 
                        from yh_jinxiaocun_jichuziliao where gs_name = @gs_name
                    ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie " + code;

                        var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@gs_name", gs_name)
                };

                        var result = sen.Database.SqlQuery<jxc_z_info>(sql, parameters);
                        return result.ToList();
                    }
                }
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        string sql = @"select cpid as sp_dm,cpname as [name],cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,
                    rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,
                    jcsl as jc_sl,jcje as jc_price,isnull(bian_yuan.bianyuan,'') as bianyuan,mark1 
                    from (
                        select isnull(link_rk.cpid,'') as cpid,isnull(link_rk.cpname,'') as cpname,isnull(link_rk.cplb,'') as cplb,
                        isnull(link_rk.cpsl,0) as qcsl,isnull(link_rk.cpje,0) as qcje,isnull(link_rk.rksl,0) as rksl,
                        isnull(link_rk.rkje,0) as rkje,isnull(ck.cksl,0) as cksl,isnull(ck.ckje,0) as ckje,
                        isnull(cpsl,0)+isnull(rksl,0)-isnull(cksl,0) as jcsl,isnull(cpje,0)+isnull(rkje,0)-isnull(ckje,0) as jcje 
                        from (
                            select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                            from(
                                select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                                from(
                                    select cpid,cpname,cplb from yh_jinxiaocun_qichushu_mssql where gs_name = @gs_name 
                                    union 
                                    select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi_mssql where gs_name = @gs_name
                                ) as cp 
                                left join (
                                    select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje 
                                    from yh_jinxiaocun_qichushu_mssql where gs_name = @gs_name 
                                    GROUP BY cpid,cpname,cplb
                                ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                            ) as link_qc 
                            left join (
                                select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje 
                                from yh_jinxiaocun_mingxi_mssql 
                                where mxtype = '入库' and gs_name = @gs_name 
                                group by sp_dm,cpname,cplb
                            ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
                        ) as link_rk 
                        left join (
                            select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje 
                            from yh_jinxiaocun_mingxi_mssql 
                            where mxtype = '出库' and gs_name = @gs_name 
                            group by sp_dm,cpname,cplb
                        ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
                    ) as jxc 
                    left join(
                        select sp_dm,lei_bie,[name],bianyuan,mark1 
                        from yh_jinxiaocun_jichuziliao_mssql where gs_name = @gs_name
                    ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.[name] and jxc.cplb = bian_yuan.lei_bie " + code;

                        var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@gs_name", gs_name)
                };

                        var result = sen.Database.SqlQuery<jxc_z_info>(sql, parameters);
                        return result.ToList();
                    }
                }
            }

            // 默认使用MySQL数据库
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = @"select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,
            rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,
            jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 
            from (
                select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,
                ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,
                ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,
                ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje 
                from (
                    select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje 
                    from(
                        select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje 
                        from(
                            select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                            union 
                            select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gs_name
                        ) as cp 
                        left join (
                            select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje 
                            from yh_jinxiaocun_qichushu where gs_name = @gs_name 
                            GROUP BY cpid,cpname,cplb
                        ) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb
                    ) as link_qc 
                    left join (
                        select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje 
                        from yh_jinxiaocun_mingxi 
                        where mxtype = '入库' and gs_name = @gs_name 
                        group by sp_dm,cpname,cplb
                    ) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname and rk.cplb = link_qc.cplb
                ) as link_rk 
                left join (
                    select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje 
                    from yh_jinxiaocun_mingxi 
                    where mxtype = '出库' and gs_name = @gs_name 
                    group by sp_dm,cpname,cplb
                ) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb
            ) as jxc 
            left join(
                select sp_dm,lei_bie,`name`,bianyuan,mark1 
                from yh_jinxiaocun_jichuziliao where gs_name = @gs_name
            ) as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie " + code;

                var parameters = new MySqlParameter[]
        {
            new MySqlParameter("@gs_name", gs_name)
        };

                var result = sen.Database.SqlQuery<jxc_z_info>(sql, parameters);
                return result.ToList();
            }
        }
    }
}