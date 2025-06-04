using MySql.Data.MySqlClient;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Web.jxc_service
{
    public class mingxi
    {
        private static string sqlStr = "";
        private Order.Common.MySqlHelper ms = null;

        public mingxi()
        {
            sqlStr = ConfigurationManager.AppSettings["云合未来进销存系统"].ToString();
        }

        public int checkOrder_id(string order_id, string gongsi)
        {
            ms = new Order.Common.MySqlHelper(sqlStr);
            string sql = "select orderid from yh_jinxiaocun_mingxi where orderid = '" + order_id + "' and gongsi = '" + gongsi + "'";
            int result = ms.ExecuteSql(sql);
            return result;
        }

        public List<string> getGongHuo(string name, string gongsi)
        {
            ms = new Order.Common.MySqlHelper(sqlStr);
            string sql = "select beizhu from yh_jinxiaocun_jinhuofang where finduser = '" + name + "' and gongsi = '" + gongsi + "'";

            MySqlDataReader reader = ms.ExecuteReader(sql);
            List<string> gonghuo = new List<string>();
            while (reader.Read())
            {
                gonghuo.Add(reader["beizhu"].ToString());
            }
            return gonghuo;
        }

        public List<string> getShouHuo(string name, string gongsi)
        {
            ms = new Order.Common.MySqlHelper(sqlStr);
            string sql = "select beizhu from yh_jinxiaocun_chuhuofang where finduser = '" + name + "' and gongsi = '" + gongsi + "'";

            MySqlDataReader reader = ms.ExecuteReader(sql);
            List<string> gonghuo = new List<string>();
            while (reader.Read())
            {
                gonghuo.Add(reader["beizhu"].ToString());
            }
            return gonghuo;
        }


        public int insertMingxi(items item, string company, string name, string mxtype)
        {
            ms = new Order.Common.MySqlHelper(sqlStr);
            string sql = "";

            string date_now = DateTime.Now.ToString();

            for (int i = 0; i < item.itemList.Count; i++)
            {
                sql += "insert into yh_jinxiaocun_mingxi(cplb,cpname,cpsj,cpsl,mxtype,orderid,shijian,sp_dm,shou_h,zh_name,gs_name) select lei_bie as cplb,`name` as cpname," + item.itemList[i].price + " as cpsj," + item.itemList[i].num + " as cpsl,'" + mxtype + "' as mxtype,'" + item.orderid + "' as orderid,'" + date_now + "' as shijian,sp_dm,'" + item.gonghuo + "' as shou_h,'" + company + "' as zh_name,'" + name + "' as gs_name from yh_jinxiaocun_jichuziliao where id = " + item.itemList[i].id + ";";
            }

            int result = ms.ExecuteSql(sql);

            return result;
        }
    }
}