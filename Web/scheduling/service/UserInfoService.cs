using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;
using Web.Util;

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

            List<paichan_user> newList = new List<paichan_user>();
            paichan_user ui = new paichan_user();
            for (int i = 0; i < list.Count; i++)
            {
                ui.id = list[i].id;
                ui.user_code = list[i].user_code;
                ui.password = list[i].password;
                ui.department_name = list[i].department_name;
                ui.company = list[i].company;
                newList.Add(ui);
            }
            if (list.Count > 0)
            {
                if (list[0].state.Equals("禁用")) 
                {
                    return false;
                }
                else
                {
                    TokenUtil.setToken(newList[0]);

                    //string a=FinanceRSA.RSAEncryption(FinanceJson.getFinanceJson().toJson(ui));

                    return true;
                }
            }
            return false;
        }

        public static List<user_info> NewFind_dp(string userCode, string pwd, string company)
        {
            List<user_info> list = udo.list(userCode, pwd, company);
            List<department> dList = dd.getListByName(list[0].department_name,company);
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
            List<department> dList = dd.getListByName(list[0].department_name,company);
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
            List<string> company = new List<string>();
            try
            {
                List<user_info> list = udo.list();
                var groups = list.GroupBy(u => u.company);
                foreach (var group in groups)
                {
                    companys.Add(group.Key);
                }
                for (int i = companys.Count; i > 0; i--) {
                    company.Add(companys[i-1]);
                }
            }
            catch { }
            return company;
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

        /// <summary>
        /// 查询user_info
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页显示行数</param>
        /// <returns></returns>
        public PageUtil<user_info> getList(int nowPage, int pageCount,string user_code)
        {
            user = TokenUtil.getToken();
            string company = user.company;
            PageUtil<user_info> page = new PageUtil<user_info>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = udo.Count();
            page.pageList = udo.getlist(page.getSkip(), page.getTake(), company, user_code);
            return page;
        }

        /// <summary>
        /// 新增账号
        /// </summary>
        /// <returns></returns>
        public Boolean save(user_info user_info)
        {
            user = TokenUtil.getToken();
            user_info.company = user.company;
            return udo.add<user_info>(user_info) != null;
        }

        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            return udo.delete<user_info>(id);
        }

        /// <summary>
        /// 修改账号
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public Boolean update(user_info user_info)
        {
            return udo.update<user_info>(user_info);
        }

    }
}