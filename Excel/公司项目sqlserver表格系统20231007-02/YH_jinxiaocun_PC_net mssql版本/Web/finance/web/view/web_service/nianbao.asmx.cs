using SDZdb;
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
    /// <summary>
    /// Summary description for nianbao
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class nianbao : System.Web.Services.WebService
    {
        private NianBaoService nianBaoService;
        private SimpleDataModel simpleDataModel;

        [WebMethod]
        public string getList(string financePageJson, string ks, string js)
        {
            //分页对象
            //FinancePage<SimpleData> financePage = null;
            
            //simpleDataModel=new SimpleDataModel();
            try
            {
                //创建service层实例
                //nianBaoService = new NianBaoService();
                //处理json
                //financePage = FinanceJson.getFinanceJson().toObject<FinancePage<SimpleData>>(financePageJson);
                //获取处理过的分页对象
                //financePage = nianBaoService.getNianBaoByNian_shouru(financePage, ks, js);
                nianBaoService = new NianBaoService();
                List<SimpleData> getlist_shouru = nianBaoService.getNianBaoByNian_shouru(ks, js);
                List<SimpleData> getlist_zhichu = nianBaoService.getNianBaoByNian_zhichu(ks, js);
                int count = 0;
                if (getlist_shouru.Count > getlist_zhichu.Count)
                {
                    count = getlist_shouru.Count;
                }
                else 
                {
                    count = getlist_zhichu.Count;
                }

                List<nianbaoList> list = new List<nianbaoList>();

                for (int i = 0; i < count; i++) 
                {
                    nianbaoList nb = new nianbaoList();
                    if (i < getlist_shouru.Count)
                    {
                        nb.zhaiyao1 = getlist_shouru[i].zhaiyao;
                        nb.kehu1 = getlist_shouru[i].kehu;
                        nb.receivable = getlist_shouru[i].receivable;
                    }
                    if (i < getlist_zhichu.Count)
                    {
                        nb.zhaiyao2 = getlist_zhichu[i].zhaiyao;
                        nb.kehu2 = getlist_zhichu[i].kehu;
                        nb.cope = getlist_zhichu[i].cope;
                    }
                    list.Add(nb);
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
