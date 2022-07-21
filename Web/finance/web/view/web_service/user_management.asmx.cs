using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.entiy;
using Web.finance.model;
using Web.finance.service;
using Web.finance.util;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <summary>
    /// user_management 的摘要说明
    /// </summary>
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class user_management : System.Web.Services.WebService
    {

        private User_ManagementService user_managementservice;



        [WebMethod]
        public string getList(string financePageJson)
        {
            //分页对象
            FinancePage<User_ManagementItem> financePage = null;
            try
            {
                //创建service层实例
                user_managementservice = new User_ManagementService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<User_ManagementItem>>(financePageJson);
                //获取处理过的分页对象
                financePage = user_managementservice.getListService(financePage);

                return FinanceResultData.getFinanceResultData().success(200, financePage, "成功");
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

        [WebMethod]
        public string queryList(string financePageJson,string username)
        {
            //分页对象
            FinancePage<User_ManagementItem> financePage = null;
            try
            {
                //创建service层实例
                user_managementservice = new User_ManagementService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<User_ManagementItem>>(financePageJson);
                //获取处理过的分页对象
                financePage = user_managementservice.queryListService(financePage,username);

                return FinanceResultData.getFinanceResultData().success(200, financePage, "成功");
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

        [WebMethod]
        public string delete(string idsJson)
        {
            try
            {
                //创建service层实例
                user_managementservice = new User_ManagementService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (user_managementservice.delUserService(ids))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "删除成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "删除失败");
                }
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


        [WebMethod]
        public string update(string newUserJson)
        {
            try
            {
                //创建service层实例
                user_managementservice = new User_ManagementService();
                //处理json
                User_ManagementItem user_managementitem = FinanceJson.getFinanceJson().toObject<User_ManagementItem>(newUserJson);
                //修改操作
                user_managementitem = user_managementservice.updUserService(user_managementitem);
                if (user_managementitem != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, user_managementitem, "成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "删除失败");
                }
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


        [WebMethod]
        public string add(string userJson)
        {
            try
            {
                //创建service层实例
                user_managementservice = new User_ManagementService();
                //处理json
                Account user = FinanceJson.getFinanceJson().toObject<Account>(userJson);

                if (user_managementservice.newUserService(user))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "添加成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "添加失败");
                }
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



        [WebMethod]
        public string getquanxian(string quanxianJson)
        {
            try
            {
                //创建service层实例
                user_managementservice = new User_ManagementService();
                //处理json
                Account user = FinanceJson.getFinanceJson().toObject<Account>(quanxianJson);
                quanxian quanxian = user_managementservice.selectQuanXianService(user);
                if (quanxian != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, quanxian, "获取权限成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "获取权限失败");
                }
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



        [WebMethod]
        public string updateQX(string quanxian,string bianhao)
        {
            try
            {
                //创建service层实例
                user_managementservice = new User_ManagementService();
                //处理json
                quanxianItem quanxianitem = FinanceJson.getFinanceJson().toObject<quanxianItem>(quanxian);
                //修改操作
                quanxianitem.bianhao = bianhao;
                quanxianitem = user_managementservice.updQuanXianService(quanxianitem);
                if (quanxianitem != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, quanxianitem, "成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "删除失败");
                }
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


        [WebMethod]
        public string quanxianGet()
        {
            try
            {
                Account account = new Account();

                //创建service层实例
                user_managementservice = new User_ManagementService();
                //处理json
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                string bianhao = account.bianhao;

                quanxian quanxianitem = user_managementservice.quanxianGetService(bianhao);

                if (quanxianitem != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, quanxianitem, "成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "删除失败");
                }
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
