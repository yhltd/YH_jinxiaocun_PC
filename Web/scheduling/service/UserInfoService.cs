using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling
{
    public class UserInfoService
    {
        private static UserInfoDao udo = new UserInfoDao();

        private static CommonDao cd = new CommonDao();

        private static DepartmentDao dd = new DepartmentDao();

        private user_info user;

        public UserInfoService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userCode">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="company">公司</param>
        /// <returns>是否登录成功</returns>
        public static Boolean login(string userCode, string pwd, string company)
        {   

            List<user_info> list = udo.list(userCode, pwd, company);
            List<user_info> list1111 = NewFind_dp(userCode, pwd, company);
            if (list.Count > 0)
            {
                TokenUtil.setToken(list[0]);
                return true;
            }
            return false;
        }

        public static List<user_info> NewFind_dp(string userCode, string pwd, string company)
        {
            List<user_info> list = udo.list(userCode, pwd, company);
            List<department> dList = dd.getListByName(list[0].department_name);
            return list;
        }

        #region new tesliew 
        private void finduserinfo()
        {
            UserInfoService item = new UserInfoService();
            List<department> dList = item.NewFind_dpnew("iser", "2q32", "2q3232");
        }

        public List<department> NewFind_dpnew(string userCode, string pwd, string company)
        {
            List<user_info> list = udo.list(userCode, pwd, company);
            List<department> dList = dd.getListByName(list[0].department_name);
            return dList;
        } 

        #endregion
        /// <summary>
        /// 获取所有公司名称
        /// </summary>
        /// <returns>公司名称集合</returns>
        public static List<string> companyList()
        {
            List<string> companys = new List<string>();
            try
            {
                List<user_info> list = udo.list();
                var groups = list.GroupBy(u => u.company);
                foreach (var group in groups)
                {
                    companys.Add(group.Key);
                }
            }
            catch { }
            return companys;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>
        /// null 修改失败
        /// user_info.password == newPwd 修改成功
        /// user_info.password == oldPwd 密码错误
        /// </returns>
        public user_info updatePwd(string oldPwd, string newPwd)
        {
            if (user.password.Equals(oldPwd))
            {
                user.password = newPwd;
                return cd.update<user_info>(user) ? user : null;
            }
            else
            {
                user.password = oldPwd;
                return user;
            }
        }


        public string new_quanxian(string findtype, String viewname)
        {
            string quanxian_save = "";

            user = TokenUtil.getToken();
            UserInfoService us = new UserInfoService();
            List<department> dlist = us.NewFind_dpnew(user.user_code, user.password, user.company);
            for (int i = 0; i < dlist.Count; i++)
            {
                if (dlist[i].view_name == viewname)
                {
                    if (findtype == "sel")
                        quanxian_save = dlist[i].sel;
                    else if (findtype == "del")
                        quanxian_save = dlist[i].del;
                    else if (findtype == "add")
                        quanxian_save = dlist[i].add;
                    else if (findtype == "upd")
                        quanxian_save = dlist[i].upd;
                }
            }
            return quanxian_save;

        }
    }
}