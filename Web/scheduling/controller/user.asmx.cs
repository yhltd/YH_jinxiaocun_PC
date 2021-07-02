using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.controller
{
    /// <summary>
    /// user 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class user : System.Web.Services.WebService
    {
        private user_info userinfo;
        private UserInfoService uis;

        [WebMethod]
        public string updatePwd(string oldPwd, string newPwd)
        {
            try {
                uis = new UserInfoService();
                user_info user = uis.updatePwd(oldPwd, newPwd);
                if (user.password == newPwd)
                {
                    return ResultUtil.success("修改成功");
                }
                else if (user.password == oldPwd)
                {
                    return ResultUtil.fail(-1, "旧密码错误");
                }
                else
                {
                    return ResultUtil.error("修改失败");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("修改失败");
            }
        }

        [WebMethod]
        public string getUsername()
        {
            userinfo = TokenUtil.getToken();
            return ResultUtil.success(userinfo.user_code, "查询成功");
        }

        [WebMethod]
        public string getDepartment()
        {
            userinfo = TokenUtil.getToken();
            return ResultUtil.success(userinfo.department_name, "查询成功");
        }


        [WebMethod]
        public string getList(int nowPage, int pageCount, string user_code)
        {

            try
            {
                uis = new UserInfoService();
                return ResultUtil.success(uis.getList(nowPage, pageCount, user_code), "查询成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (Exception ex)
            {

                return ResultUtil.error("查询失败");
            }
        }


        [WebMethod]
        public string save(user_info user_info)
        {
            try
            {
                uis = new UserInfoService();
                if (uis.save(user_info))
                {

                    return ResultUtil.success("保存成功");
                }
                else
                {
                    return ResultUtil.error("保存失败");
                }

            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("查询失败");
            }
        }

        [WebMethod]
        public string delete(int id)
        {
            try
            {
                uis = new UserInfoService();
                if (uis.delete(id))
                {
                    return ResultUtil.success("删除成功");
                }
                else
                {
                    return ResultUtil.error("删除失败");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("删除失败");
            }
        }

        [WebMethod]
        public string update(user_info user_info)
        {
            try
            {
                uis = new UserInfoService();
                if (uis.update(user_info))
                {
                    return ResultUtil.success("修改成功");
                }
                else
                {
                    return ResultUtil.error("修改失败");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("修改失败");
            }
        }

    }
}
