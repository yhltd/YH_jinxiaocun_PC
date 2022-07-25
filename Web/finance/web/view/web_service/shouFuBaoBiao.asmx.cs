using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.service;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <summary>
    /// Summary description for shouFuBaoBiao
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class shouFuBaoBiao : System.Web.Services.WebService
    {
        private ShouFuBaoBiaoService shouFuBaoBiaoService;

        [WebMethod]
        public string getYS(string kehu,string ks,string js)
        {
            try
            {
                shouFuBaoBiaoService = new ShouFuBaoBiaoService();
                List<shoufubaobiao> getYingShou = shouFuBaoBiaoService.getYingShou(kehu,ks,js);
                List<shoufubaobiao> getXiaoXiang = shouFuBaoBiaoService.getXiaoXiang(kehu, ks, js);
                int count = 0;
                if (getYingShou.Count > getXiaoXiang.Count)
                {
                    count = getYingShou.Count;
                }
                else
                {
                    count = getXiaoXiang.Count;
                }

                List<shoufubaobiao> list = new List<shoufubaobiao>();

                for (int i = 0; i < count; i++)
                {
                    shoufubaobiao sfbb = new shoufubaobiao();
                    if (i < getYingShou.Count)
                    {
                        sfbb.kehu = getYingShou[i].kehu;
                        sfbb.project = getYingShou[i].project;
                        sfbb.zhaiyao = getYingShou[i].zhaiyao;
                        sfbb.jine1 = Convert.ToDecimal(getYingShou[i].jine1);
                    }
                    if (i < getXiaoXiang.Count)
                    {
                        sfbb.unit = getXiaoXiang[i].unit;
                        sfbb.invoice_type = getXiaoXiang[i].invoice_type;
                        sfbb.invoice_no = getXiaoXiang[i].invoice_no;
                        sfbb.jine2 = Convert.ToString(getXiaoXiang[i].jine2);
                    }
                    list.Add(sfbb);
                }

                return FinanceResultData.getFinanceResultData().success(200, list, "成功");
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
        public string getYF(string kehu,string ks,string js)
        {
            try
            {
                shouFuBaoBiaoService = new ShouFuBaoBiaoService();
                List<shoufubaobiao> getYingFu = shouFuBaoBiaoService.getYingFu(kehu, ks, js);
                List<shoufubaobiao> getJinXiang = shouFuBaoBiaoService.getJinXiang(kehu, ks, js);
                int count = 0;
                if (getYingFu.Count > getJinXiang.Count)
                {
                    count = getYingFu.Count;
                }
                else
                {
                    count = getJinXiang.Count;
                }

                List<shoufubaobiao> list = new List<shoufubaobiao>();

                for (int i = 0; i < count; i++)
                {
                    shoufubaobiao sfbb = new shoufubaobiao();
                    if (i < getYingFu.Count)
                    {
                        sfbb.kehu = getYingFu[i].kehu;
                        sfbb.project = getYingFu[i].project;
                        sfbb.zhaiyao = getYingFu[i].zhaiyao;
                        sfbb.jine1 = getYingFu[i].jine1;
                    }
                    if (i < getJinXiang.Count)
                    {
                        sfbb.unit = getJinXiang[i].unit;
                        sfbb.invoice_type = getJinXiang[i].invoice_type;
                        sfbb.invoice_no = getJinXiang[i].invoice_no;
                        sfbb.jine2 = getJinXiang[i].jine2;
                    }
                    list.Add(sfbb);
                }

                return FinanceResultData.getFinanceResultData().success(200, list, "成功");
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
