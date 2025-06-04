using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.model;
using Web.Service;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <author>
    /// dai
    /// </author>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class updateUser : System.Web.Services.WebService
    {
        AccountService asc;

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        [WebMethod]
        public string updatePwd(string oldPwd, string newPwd)
        {
            try
            {
                asc = new AccountService(true);
                int result = asc.updatePwd(oldPwd, newPwd);
                string resultStr = "";
                switch (result)
                {
                    case 1:
                        resultStr = FinanceResultData.getFinanceResultData().success(200, null, "修改成功");
                        break;
                    case -1:
                        resultStr = FinanceResultData.getFinanceResultData().fail(412, null, "旧密码错误");
                        break;
                    default:
                        resultStr = FinanceResultData.getFinanceResultData().fail(500, null, "修改失败");
                        break;
                }
                return resultStr;
            }
            catch (InvalidOperationException ex)
            {
                //身份验证不通过
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                //未知的错误
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        /// <summary>
        /// 修改用户操作密码
        /// </summary>
        /// <param name="oldPwd">旧操作密码</param>
        /// <param name="newPwd">新操作密码</param>
        /// <returns></returns>
        [WebMethod]
        public string updateDo(string oldDo, string newDo)
        {
            try
            {
                asc = new AccountService(true);
                int result = asc.updateDo(oldDo, newDo);
                string resultStr = "";
                switch (result)
                {
                    case 1:
                        resultStr = FinanceResultData.getFinanceResultData().success(200, null, "修改成功");
                        break;
                    case -1:
                        resultStr = FinanceResultData.getFinanceResultData().fail(412, null, "旧操作密码错误");
                        break;
                    default:
                        resultStr = FinanceResultData.getFinanceResultData().fail(500, null, "修改失败");
                        break;
                }
                return resultStr;
            }
            catch (InvalidOperationException ex)
            {
                //身份验证不通过
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                //未知的错误
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user_json">用户的json</param>
        /// <returns></returns>
        [WebMethod]
        public string newUser(string myDo,string user_json)
        {
            string resultStr = "";
            Account account = FinanceJson.getFinanceJson().toObject<Account>(user_json);
            try
            {
                asc = new AccountService(true);
                int result = asc.newUser(myDo, account);
                switch (result)
                {
                    case 1:
                        resultStr = FinanceResultData.getFinanceResultData().success(200, null, "新增成功");
                        break;
                    case -1:
                        resultStr = FinanceResultData.getFinanceResultData().fail(412, null, "您的操作密码不正确");
                        break;
                    case -2:
                        resultStr = FinanceResultData.getFinanceResultData().fail(412, null, "用户名以存在");
                        break;
                    default:
                        resultStr = FinanceResultData.getFinanceResultData().fail(500, null, "新增失败");
                        break;
                }
                return resultStr;
            }
            catch (InvalidOperationException ex)
            {
                //身份验证不通过
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                //未知的错误
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }
    }
}
