using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.entiy;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{

    public class User_ManagementService
    {
        //model层
        private User_ManagementModel user_managementmodel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public User_ManagementService()
        {
            try
            {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                user_managementmodel = new User_ManagementModel();
            }
            catch
            {
                throw new InvalidOperationException("身份验证不通过");
            }
        }


        public FinancePage<User_ManagementItem> getListService(FinancePage<User_ManagementItem> financePage)
        {
            //获取pageList
            financePage = user_managementmodel.getList(financePage, account.company);
            //获取总页数
            financePage.total = user_managementmodel.getPageCount(account.company);
            return financePage;
        }

        public quanxian selectQuanXianService(Account user)
        {
            string bianhao = user.bianhao;
            quanxian quanxian = user_managementmodel.getQuanXian(bianhao);

            return quanxian;
        }




        public Boolean delUserService(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                if (user_managementmodel.delUser(ids[i]) <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        public User_ManagementItem updUserService(User_ManagementItem user)
        {
            user.company = account.company;
            int result = user_managementmodel.updUser(user.getAccount());
            return result > 0 ? user : null;
        }


        public Boolean newUserService(Account user)
        {
            //设置新部门的所属公司
            user.company = account.company;
            string bianhao = DateTime.Now.ToString("yyyymmddhhmmss");
            user.bianhao = bianhao;
            quanxian quan = new quanxian();
            quan.bianhao = bianhao;
            quan.kmzz_add = "是";
            quan.kmzz_delete = "是";
            quan.kmzz_update = "是";
            quan.kmzz_select = "是";
            quan.kzxm_add = "是";
            quan.kzxm_delete = "是";
            quan.kzxm_update = "是";
            quan.kzxm_select = "是";
            quan.bmsz_add = "是";
            quan.bmsz_delete = "是";
            quan.bmsz_update = "是";
            quan.bmsz_select = "是";
            quan.pzhz_add = "是";
            quan.pzhz_delete = "是";
            quan.pzhz_update = "是";
            quan.pzhz_select = "是";
            quan.znkb_select = "是";
            quan.xjll_select = "是";
            quan.zcfz_select = "是";
            quan.lysy_select = "是";
            quan.jjtz_add = "是";
            quan.jjtz_delete = "是";
            quan.jjtz_update = "是";
            quan.jjtz_select = "是";
            quan.jjzz_add = "是";
            quan.jjzz_delete = "是";
            quan.jjzz_update = "是";
            quan.jjzz_select = "是";
            quan.zhgl_add = "是";
            quan.zhgl_delete = "是";
            quan.zhgl_update = "是";
            quan.zhgl_select = "是";

            Boolean result = false;

            if ((user_managementmodel.newUser(user) > 0) && (user_managementmodel.newQuanXian(quan) > 0))
            {
                result = true;
            }
            //影响行数大于0则添加成功
            return result;
        }

        public quanxianItem updQuanXianService(quanxianItem quanxian)
        {   
            int result = user_managementmodel.updQuanXian(quanxian);
            return result > 0 ? quanxian : null;
        }

        public quanxian quanxianGetService(string bianhao)
        {
            quanxian result = user_managementmodel.getQuanXian(bianhao);
            return result;
        }



    }
    
}


