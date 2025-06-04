using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.model;
using Web.finance.service;
using Web.finance.util;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <author>
    /// dai
    /// </author>
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class voucherWord : System.Web.Services.WebService
    {
        private VoucherWordService voucherWordService;


        [WebMethod]
        public string getVoucherWordList(string financePageJson)
        {
            //分页对象
            FinancePage<VoucherWord> financePage = null;
            try
            {
                //创建service层实例
                voucherWordService = new VoucherWordService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<VoucherWord>>(financePageJson);
                //获取处理过的分页对象
                financePage = voucherWordService.getVoucherWordList(financePage);

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
        public string getWordList()
        {
            List<VoucherWord> financePage = null;
            try
            {
                //创建service层实例
                voucherWordService = new VoucherWordService();
                //获取处理过的分页对象
                financePage = voucherWordService.getVoucherWordList();

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
        public string addVoucherWord(string wordJson)
        {
            try
            {
                //创建service层实例
                voucherWordService = new VoucherWordService();
                //处理json
                VoucherWord voucherWord = FinanceJson.getFinanceJson().toObject<VoucherWord>(wordJson);

                if (voucherWordService.addVoucherWord(voucherWord))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "新增成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "新增失败");
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idsJson">id数组json</param>
        /// <returns></returns>
        [WebMethod]
        public string delVoucherWord(string idsJson)
        {
            try
            {
                //创建service层实例
                voucherWordService = new VoucherWordService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (voucherWordService.deleteVoucherWord(ids))
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

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="newVoucherWord"></param>
        /// <returns></returns>
        [WebMethod]
        public string updVoucherWord(string newVoucherWord)
        {
            try
            {
                //创建service层实例
                voucherWordService = new VoucherWordService();
                //处理json
                VoucherWord voucherWord = FinanceJson.getFinanceJson().toObject<VoucherWord>(newVoucherWord);
                //修改操作
                if (voucherWordService.updateVoucherWord(voucherWord))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "修改成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "修改失败");
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
