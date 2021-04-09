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

        private user_info user;

        public UserInfoService() {
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
            try
            {
                List<user_info> list = udo.list(userCode, pwd, company);
                if (list.Count > 0)
                {
                    TokenUtil.setToken(list[0]);
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

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
            catch{}
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
    }
}