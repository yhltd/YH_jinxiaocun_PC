using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Server
{
    public class StockModel
    {

        public int get_jxc_PageCount(string gongsi) {
            using (ServerEntities sen = new ServerEntities()) {
                string sql = "select count(cpid) from (select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje from (select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje from(select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje from(select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = '" + gongsi + "' union select sp_dm,cpname,cplb from  yh_jinxiaocun_mingxi where gs_name = '" + gongsi + "') as cp left join (select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje from yh_jinxiaocun_qichushu where gs_name = '" + gongsi + "' GROUP BY cpid,cpname,cplb) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb) as link_qc left join (select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = '" + gongsi + "' and shijian between '1900-01-01' and '2100-12-31' group by sp_dm,cpname,cplb) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname  and rk.cplb = link_qc.cplb) as link_rk left join (select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = '" + gongsi + "' and shijian between '1900-01-01' and '2100-12-31' group by sp_dm,cpname,cplb) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb) as jxc left join(select sp_dm,lei_bie,`name`,bianyuan,mark1 from yh_jinxiaocun_jichuziliao where gs_name = '" + gongsi + "') as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie";
                return sen.Database.SqlQuery<int>(sql).SingleOrDefault();
            }
        }

        public List<jxc_z_info> jxc_z_select(string gs_name, string code, int limit1, int limit2)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string limit = " limit " + limit1 + "," + limit2;
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

                string sql = "select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 from (select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje from (select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje from(select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje from(select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' union select sp_dm,cpname,cplb from  yh_jinxiaocun_mingxi where gs_name = '" + gs_name + "') as cp left join (select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' GROUP BY cpid,cpname,cplb) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb) as link_qc left join (select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = '" + gs_name + "' and shijian between '" + time_start + "' and '" + time_end + "' group by sp_dm,cpname,cplb) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname  and rk.cplb = link_qc.cplb) as link_rk left join (select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = '" + gs_name + "' and shijian between '" + time_start + "' and '" + time_end + "' group by sp_dm,cpname,cplb) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb) as jxc left join(select sp_dm,lei_bie,`name`,bianyuan,mark1 from yh_jinxiaocun_jichuziliao where gs_name = '" + gs_name + "') as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie  where cpid like '%" + code + "%'";
                //string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,ifnull(sum(jq.cpsl),0) as jq_cpsl,ifnull(sum(jq.cpsl*jq.cpsj),0) as jq_price,ifnull(mx_ruku.cpsl,0) as mx_ruku_cpsl,ifnull(mx_ruku.cp_price,0) as mx_ruku_price,ifnull(mx_chuku.cpsl,0) as mx_chuku_cpsl,ifnull(mx_chuku.cp_price,0) as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '入库' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '出库' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc";
                //string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,sum(jq.cpsl) as jq_cpsl,sum(jq.cpsl*jq.cpsj) as jq_price,mx_ruku.cpsl as mx_ruku_cpsl,mx_ruku.cp_price as mx_ruku_price,mx_chuku.cpsl as mx_chuku_cpsl,mx_chuku.cp_price as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '入库' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '出库' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc" + limit;

                var result = sen.Database.SqlQuery<jxc_z_info>(sql);
                return result.ToList();
            }
        }

        public List<jxc_z_info> jxc_select(string gs_name, string code, string start_time, string end_time)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select cpid as sp_dm,cpname as `name`,cplb as lei_bie,qcsl as jq_cpsl,qcje as jq_price,rksl as mx_ruku_cpsl,rkje as mx_ruku_price,cksl as mx_chuku_cpsl,ckje as mx_chuku_price,jcsl as jc_sl,jcje as jc_price,ifnull(bian_yuan.bianyuan,'') as bianyuan,mark1 from (select ifnull(link_rk.cpid,'') as cpid,ifnull(link_rk.cpname,'') as cpname,ifnull(link_rk.cplb,'') as cplb,ifnull(link_rk.cpsl,0) as qcsl,ifnull(link_rk.cpje,0) as qcje,ifnull(link_rk.rksl,0) as rksl,ifnull(link_rk.rkje,0) as rkje,ifnull(ck.cksl,0) as cksl,ifnull(ck.ckje,0) as ckje,ifnull(cpsl,0)+ifnull(rksl,0)-ifnull(cksl,0) as jcsl,ifnull(cpje,0)+ifnull(rkje,0)-ifnull(ckje,0) as jcje from (select link_qc.cpid,link_qc.cpname,link_qc.cplb,link_qc.cpsl,link_qc.cpje,rk.rksl,rk.rkje from(select cp.cpid,cp.cpname,cp.cplb,qc.cpsl,qc.cpje from(select cpid,cpname,cplb from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' union select sp_dm,cpname,cplb from  yh_jinxiaocun_mingxi where gs_name = '" + gs_name + "') as cp left join (select cpid,cplb,cpname,sum(cpsl) as cpsl,sum(cpsj*cpsl) as cpje from yh_jinxiaocun_qichushu where gs_name = '" + gs_name + "' GROUP BY cpid,cpname,cplb) as qc on cp.cpid = qc.cpid and cp.cpname = qc.cpname and cp.cplb = qc.cplb) as link_qc left join (select sp_dm,cpname,cplb,sum(cpsl) as rksl,sum(cpsl*cpsj) as rkje from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = '" + gs_name + "' and shijian between '" + start_time + "' and '" + end_time + "' group by sp_dm,cpname,cplb) as rk on rk.sp_dm = link_qc.cpid and rk.cpname = link_qc.cpname  and rk.cplb = link_qc.cplb) as link_rk left join (select sp_dm,cpname,cplb,sum(cpsl) as cksl,sum(cpsl*cpsj) as ckje from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = '" + gs_name + "' and shijian between '" + start_time + "' and '" + end_time + "' group by sp_dm,cpname,cplb) as ck on ck.sp_dm = link_rk.cpid and ck.cpname = link_rk.cpname and ck.cplb = link_rk.cplb) as jxc left join(select sp_dm,lei_bie,`name`,bianyuan,mark1 from yh_jinxiaocun_jichuziliao where gs_name = '" + gs_name + "') as bian_yuan on jxc.cpid = bian_yuan.sp_dm and jxc.cpname = bian_yuan.`name` and jxc.cplb = bian_yuan.lei_bie  where cpid like '%" + code + "%'";
                //string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,sum(jq.cpsl) as jq_cpsl,sum(jq.cpsl*jq.cpsj) as jq_price,mx_ruku.cpsl as mx_ruku_cpsl,mx_ruku.cp_price as mx_ruku_price,mx_chuku.cpsl as mx_chuku_cpsl,mx_chuku.cp_price as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.zh_name = '1' and jm.gs_name = '1' and jm.mxtype = '入库' and jm.shijian between '" + start_time + "' and '" + end_time + "' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.zh_name = '1' and jm.gs_name = '1' and jm.mxtype = '出库' and jm.shijian between '" + start_time + "' and '" + end_time + "' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc where sp_dm like '%" + code + "%'";

                var result = sen.Database.SqlQuery<jxc_z_info>(sql);
                return result.ToList();
            }
        }
    }
}