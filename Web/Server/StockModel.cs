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
                string sql = "select count(*) from yh_jinxiaocun_jichuziliao";
                return sen.Database.SqlQuery<int>(sql).SingleOrDefault();
            }
        }

        public List<jxc_z_info> jxc_z_select(string gs_name, int limit1, int limit2)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string limit = " limit " + limit1 + "," + limit2;

                string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,ifnull(sum(jq.cpsl),0) as jq_cpsl,ifnull(sum(jq.cpsl*jq.cpsj),0) as jq_price,ifnull(mx_ruku.cpsl,0) as mx_ruku_cpsl,ifnull(mx_ruku.cp_price,0) as mx_ruku_price,ifnull(mx_chuku.cpsl,0) as mx_chuku_cpsl,ifnull(mx_chuku.cp_price,0) as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '入库' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '出库' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc";
                //string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,sum(jq.cpsl) as jq_cpsl,sum(jq.cpsl*jq.cpsj) as jq_price,mx_ruku.cpsl as mx_ruku_cpsl,mx_ruku.cp_price as mx_ruku_price,mx_chuku.cpsl as mx_chuku_cpsl,mx_chuku.cp_price as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '入库' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '出库' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc" + limit;

                var result = sen.Database.SqlQuery<jxc_z_info>(sql);
                return result.ToList();
            }
        }

        public List<jxc_z_info> jxc_select(string gs_name, string code, string start_time, string end_time)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,ifnull(sum(jq.cpsl),0) as jq_cpsl,ifnull(sum(jq.cpsl*jq.cpsj),0) as jq_price,ifnull(mx_ruku.cpsl,0) as mx_ruku_cpsl,ifnull(mx_ruku.cp_price,0) as mx_ruku_price,ifnull(mx_chuku.cpsl,0) as mx_chuku_cpsl,ifnull(mx_chuku.cp_price,0) as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '入库' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.gs_name = '" + gs_name + "' and jm.mxtype = '出库' and jm.shijian between '" + start_time + "' and '" + end_time + "' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc where sp_dm like '%" + code + "%'";
                //string sql = "select *,(jq_cpsl+mx_ruku_cpsl-mx_chuku_cpsl) as jc_sl,(jq_price+mx_ruku_price-mx_chuku_price) as jc_price from (select jj.sp_dm,jj.name,jj.lei_bie,sum(jq.cpsl) as jq_cpsl,sum(jq.cpsl*jq.cpsj) as jq_price,mx_ruku.cpsl as mx_ruku_cpsl,mx_ruku.cp_price as mx_ruku_price,mx_chuku.cpsl as mx_chuku_cpsl,mx_chuku.cp_price as mx_chuku_price from yh_jinxiaocun_jichuziliao as jj left join yh_jinxiaocun_qichushu as jq on jj.sp_dm = jq.cpid and jq.gs_name = '" + gs_name + "' left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.zh_name = '1' and jm.gs_name = '1' and jm.mxtype = '入库' and jm.shijian between '" + start_time + "' and '" + end_time + "' group by jm.sp_dm) as mx_ruku on mx_ruku.sp_dm = jj.sp_dm left join (select jm.sp_dm,sum(jm.cpsl) as cpsl,sum(jm.cpsl*jm.cpsj) as cp_price from yh_jinxiaocun_mingxi as jm where jm.zh_name = '1' and jm.gs_name = '1' and jm.mxtype = '出库' and jm.shijian between '" + start_time + "' and '" + end_time + "' group by jm.sp_dm ) as mx_chuku on mx_chuku.sp_dm = jj.sp_dm where jj.gs_name = '" + gs_name + "' GROUP BY jj.sp_dm,jj.name,jj.lei_bie) as jxc where sp_dm like '%" + code + "%'";

                var result = sen.Database.SqlQuery<jxc_z_info>(sql);
                return result.ToList();
            }
        }
    }
}