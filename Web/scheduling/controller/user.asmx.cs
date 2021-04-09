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
    }
}
