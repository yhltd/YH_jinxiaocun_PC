using MySql.Data.MySqlClient;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ServerEntity;

namespace Web.Server
{
    public class MingxiModel
    {

        public string checkOrder_id(string order_id, string gongsi)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                var @params = new MySqlParameter[]
                {
                    new MySqlParameter("@order", order_id),
                    new MySqlParameter("@gongsi", gongsi)
                };

                string sql = "select orderid from yh_jinxiaocun_mingxi where orderid = @order and gongsi = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql, @params);
                List<yh_jinxiaocun_mingxi> list = result.ToList();
                return list.Count > 0 ? list[0].orderid : string.Empty;
            }
        }

        public int add(items item, string company, string name, string mxtype)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string date_now = DateTime.Now.ToString();
                string sql = string.Empty;

                for (int i = 0; i < item.itemList.Count; i++)
                {
                    sql += "insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name) select lei_bie as cplb,`name` as cpname," + item.itemList[i].price + " as cpsj," + item.itemList[i].num + " as cpsl,'" + mxtype + "' as mxtype,'" + item.orderid + "' as orderid,'" + date_now + "' as shijian,sp_dm,'" + item.gonghuo + "' as shou_h,'" + name + "' as zh_name,'" + company + "' as gs_name from yh_jinxiaocun_jichuziliao where id = " + item.itemList[i].id + ";";
                }
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public List<yh_jinxiaocun_mingxi> ming_xi_select(string gs_name, int limit1, int limit2)
        {
            limit2 = 20;
            using (ServerEntities sen = new ServerEntities()) {
                string sql = "select * from yh_jinxiaocun_mingxi where gs_name = '" + gs_name + "' order by shijian desc limit " + limit1 + "," + limit2 + " ";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
                return result.ToList();
            }
        }

        public int getPageCount(string gs_name)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "SELECT * FROM Yh_JinXiaoCun_mingxi where gs_name = '" + gs_name + "'";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
                return result.ToList().Count;
            }
        }

        public List<yh_jinxiaocun_mingxi> ri_qi_select(string time_qs, string time_jz,string order_number, string gs_name)
        {
            using (ServerEntities sen = new ServerEntities()) {
                string sql = "SELECT * FROM Yh_JinXiaoCun_mingxi WHERE shijian between '" + time_qs + "' and '" + time_jz + "' and gs_name = '" + gs_name + "' and orderid like '%" + order_number + "%'   order by shijian desc";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
                return result.ToList();
            }
        }

        public List<yh_jinxiaocun_mingxi> getCpNames(string gongsi) {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select cpname from yh_jinxiaocun_mingxi where gs_name = '" + gongsi + "' group by cpname";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
                return result.ToList();
            }
        }

        public List<MingXiItem> getCpMingXi(string cpname, string gongsi)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                var @params = new MySqlParameter[]{
                    new MySqlParameter("@cpname", cpname),
                    new MySqlParameter("@gongxi", gongsi)
                };
                string sql = "select mx.sp_dm,mx.cpname,mx.cplb,ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm having mx.cpname = @cpname";
                //string sql = "select mx.shijian,mx.orderid,mx.sp_dm,mx.cpname,ifnull(ruku.cpsl,0) as ruku_num,ifnull(ruku.cp_price,0) as ruku_price,ifnull(chuku.cpsl,0) as chuku_num,ifnull(chuku.cp_price,0) as chuku_price from yh_jinxiaocun_mingxi as mx left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by orderid) as ruku on mx.orderid = ruku.orderid left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by orderid) as chuku on mx.orderid = chuku.orderid where mx.gs_name = @gongxi GROUP BY mx.orderid having mx.cpname = @cpname";
                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

        public List<MingXiItem> getCpMingXi_all(string gongsi)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                var @params = new MySqlParameter[]{
                    new MySqlParameter("@gongxi", gongsi)
                };
                string sql = "select mx.sp_dm,mx.cpname,mx.cplb,ifnull(rk.cpsl,0) as ruku_num,ifnull(rk.cp_price,0) as ruku_price,ifnull(ck.cpsl,0) as chuku_num,ifnull(ck.cp_price,0) as chuku_price from (select sp_dm,cpname,cplb from yh_jinxiaocun_mingxi where gs_name = @gongxi group by sp_dm,cpname,cplb) as mx left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by sp_dm) as rk on mx.sp_dm=rk.sp_dm left join (select sp_dm,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '出库' and gs_name = @gongxi group by sp_dm) as ck on ck.sp_dm=rk.sp_dm";
                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

        public List<yh_jinxiaocun_mingxi> getShouHuoMingXi(string gsname) 
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select shou_h from yh_jinxiaocun_mingxi where shou_h != '' and gs_name = '" + gsname + "' group by shou_h";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_mingxi>(sql);
                return result.ToList();
            }
        }

        public List<MingXiItem> getChMingxi(string shouhuo, string gongsi)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                var @params = new MySqlParameter[]{
                    new MySqlParameter("@shouhuo", shouhuo),
                    new MySqlParameter("@gongxi", gongsi)
                };
                string sql = "select shou_h,sp_dm,cpname,cplb,ifnull(sum(cpsl),0) as ruku_num,ifnull(sum(cpsj),0) as ruku_price from yh_jinxiaocun_mingxi where gs_name=@gongxi group by shou_h,sp_dm,cpname,cplb having shou_h != '' and shou_h = @shouhuo";
                //string sql = "select mx.shijian,mx.shou_h,mx.orderid,mx.sp_dm,mx.cpname,ifnull(ruku.cpsl,0) as ruku_num,ifnull(ruku.cp_price,0) as ruku_price from yh_jinxiaocun_mingxi as mx left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by orderid) as ruku on mx.orderid = ruku.orderid where mx.gs_name = @gongxi GROUP BY mx.orderid having mx.shou_h != '' and mx.shou_h = @shouhuo";
                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

        public List<MingXiItem> getChMingxi_all(string gongsi)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                var @params = new MySqlParameter[]{
                    new MySqlParameter("@gongxi", gongsi)
                };
                string sql = "select shou_h,sp_dm,cpname,cplb,ifnull(sum(cpsl),0) as ruku_num,ifnull(sum(cpsj),0) as ruku_price from yh_jinxiaocun_mingxi where gs_name=@gongxi group by shou_h,sp_dm,cpname,cplb having shou_h != '' order by shou_h";
                //string sql = "select mx.shijian,mx.shou_h,mx.orderid,mx.sp_dm,mx.cpname,ifnull(ruku.cpsl,0) as ruku_num,ifnull(ruku.cp_price,0) as ruku_price from yh_jinxiaocun_mingxi as mx left join (select orderid,sum(cpsl) as cpsl,sum(cpsl*cpsj) as cp_price from yh_jinxiaocun_mingxi where mxtype = '入库' and gs_name = @gongxi group by orderid) as ruku on mx.orderid = ruku.orderid where mx.gs_name = @gongxi GROUP BY mx.orderid having mx.shou_h != '' and mx.shou_h = @shouhuo";
                var result = sen.Database.SqlQuery<MingXiItem>(sql, @params);
                return result.ToList();
            }
        }

        public int del_mingxi(int cpid)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "DELETE FROM yh_jinxiaocun_mingxi WHERE _id = '" + cpid + "'";
                return sen.Database.ExecuteSqlCommand(sql); ;
            }

        }

        public int update(List<yh_jinxiaocun_mingxi> list)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "";
                foreach (yh_jinxiaocun_mingxi item in list)
                {
                    sql += "update yh_jinxiaocun_mingxi set orderid= '" + item.orderid + "',sp_dm= '" + item.sp_dm + "',cpname= '" + item.cpname + "',cplb= '" + item.cplb + "',cpsj= '" + item.cpsj + "',cpsl= '" + item.cpsl + "',mxtype= '" + item.mxtype + "',shou_h= '" + item.shou_h + "' where _id='" + item._id + "' ;";
                }
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}