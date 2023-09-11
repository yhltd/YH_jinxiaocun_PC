using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web.Server
{
    public class UserModel
    {

        public List<string> selectCompanys()
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select gongsi from yh_jinxiaocun_user group by gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql);
                List<yh_jinxiaocun_user> userList = result.ToList();
                List<string> companys = new List<string>();
                foreach (var user in userList)
                {
                    companys.Add(user.gongsi);
                }
                return companys;
            }
        }

        public yh_jinxiaocun_user login(string gongsi, string username, string pwd)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                var @params = new MySqlParameter[]
                {
                    new MySqlParameter("@gongsi", gongsi),
                    new MySqlParameter("@username", username),
                    new MySqlParameter("@pwd", pwd)
                };

                string sql = "select * from yh_jinxiaocun_user where gongsi = @gongsi and `name` = @username and `password` = @pwd";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql, @params);
                List<yh_jinxiaocun_user> list = result.ToList();
                return list.Count == 0 ? null : list[0];
            }
        }

        public List<yh_jinxiaocun_user> getList(string gongsi) {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_user where gongsi = '" + gongsi + "'";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql);
                return result.ToList();
            }
        }

        public List<yh_jinxiaocun_user> getUserNum(string gongsi)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select count(_id) as _id from yh_jinxiaocun_user where gongsi = '" + gongsi + "'";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_user>(sql);
                return result.ToList();
            }
        }

        public int delete(string id)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "delete from yh_jinxiaocun_user where _id = '"+id+"'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int add(yh_jinxiaocun_user user) {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "insert into yh_jinxiaocun_user(name,password,_id,gongsi,AdminIS,Btype) values('" + user.name + "','" + user.password + "','" + user._id + "','" + user.gongsi + "','" + user.AdminIS + "','" + user.Btype + "')";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int update(yh_jinxiaocun_user user)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "update yh_jinxiaocun_user set name = '" + user.name + "',password = '" + user.password + "',gongsi = '" + user.gongsi + "',AdminIS = '" + user.AdminIS + "' where _id = '"+user._id+"'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}
