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
    /// Summary description for lirun
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class lirun : System.Web.Services.WebService
    {
        private LirunService lirunService;

        [WebMethod]
        public string getList(string benqi_ks,string benqi_js,string bennian_ks,string bennian_js)
        {
            try
            {
                lirunService = new LirunService();
                //全部
                List<lirunList> all = lirunService.getAllLirun();
                //本期
                List<lirunList> benqi = lirunService.getBenqiLirun(benqi_ks, benqi_js);
                //本年
                List<lirunList> bennian = lirunService.getBennianLirun(bennian_ks, bennian_js);
                //上期
                List<lirunList> shangqi = lirunService.getShangqiLirun(benqi_ks);

                List<lirunList> list = new List<lirunList>();

                decimal alljine = 0;
                decimal benqijine = 0;
                decimal bennianjine = 0;
                decimal shangqijine = 0;
                int hang = 0;

                for (int i = 0; i < all.Count; i++) {
                    lirunList lr = new lirunList();
                    if (i == 0)
                    {
                        lirunList newlr = new lirunList();
                        newlr.accounting = all[i].project;
                        list.Add(newlr);

                        lr.project = all[i].project;
                        lr.accounting = all[i].accounting;
                        list.Add(lr);
                    }
                    else 
                    {
                        if (all[i].project.Equals(all[i - 1].project))
                        {
                            lr.project = all[i].project;
                            lr.accounting = all[i].accounting;
                            list.Add(lr);
                        }
                        else 
                        {
                            lirunList newlr = new lirunList();
                            newlr.accounting = all[i].project;
                            list.Add(newlr);

                            lr.project = all[i].project;
                            lr.accounting = all[i].accounting;
                            list.Add(lr);
                        }
                    }
                }

                //本期金额放进list
                for (int i = 0; i < list.Count; i++) 
                {
                    if (list[i].project != null)
                    {
                        for (int j = 0; j < benqi.Count; j++)
                        {
                            if (list[i].project.Equals(benqi[j].project) && list[i].accounting.Equals(benqi[j].accounting))
                            {
                                if (list[i].benqi == null)
                                {
                                    list[i].benqi = benqi[j].benqi;
                                }
                                else
                                {
                                    list[i].benqi = benqi[j].benqi + list[i].benqi;
                                }
                            }
                        }
                    }
                    else 
                    {
                        for (int j = 0; j < benqi.Count; j++)
                        {
                            if (list[i].accounting.Equals(benqi[j].project))
                            {
                                if (list[i].benqi == null)
                                {
                                    list[i].benqi = benqi[j].benqi;
                                }
                                else
                                {
                                    list[i].benqi = benqi[j].benqi + list[i].benqi;
                                }
                            }
                        }
                    }
                }

                //本年金额放进list
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].project != null)
                    {
                        for (int j = 0; j < bennian.Count; j++)
                        {
                            if (list[i].project.Equals(bennian[j].project) && list[i].accounting.Equals(bennian[j].accounting))
                            {
                                if (list[i].bennian == null)
                                {
                                    list[i].bennian = bennian[j].bennian;
                                }
                                else
                                {
                                    list[i].bennian = benqi[j].bennian + list[i].bennian;
                                }
                            }
                        }
                    }
                    else 
                    {
                        for (int j = 0; j < bennian.Count; j++)
                        {
                            if (list[i].accounting.Equals(bennian[j].project))
                            {
                                if (list[i].bennian == null)
                                {
                                    list[i].bennian = bennian[j].bennian;
                                }
                                else
                                {
                                    list[i].bennian = bennian[j].bennian + list[i].bennian;
                                }
                            }
                        }
                    }
                }

                //上期金额放进list
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].project != null)
                    {
                        for (int j = 0; j < shangqi.Count; j++)
                        {
                            if (list[i].project.Equals(shangqi[j].project) && list[i].accounting.Equals(shangqi[j].accounting))
                            {
                                if (list[i].shangqi == null)
                                {
                                    list[i].shangqi = shangqi[j].shangqi;
                                }
                                else
                                {
                                    list[i].shangqi = shangqi[j].shangqi + list[i].shangqi;
                                }
                            }
                        }
                    }
                    else 
                    {
                        for (int j = 0; j < shangqi.Count; j++)
                        {
                            if (list[i].accounting.Equals(shangqi[j].project))
                            {
                                if (list[i].shangqi == null)
                                {
                                    list[i].shangqi = shangqi[j].shangqi;
                                }
                                else
                                {
                                    list[i].shangqi = shangqi[j].shangqi + list[i].shangqi;
                                }
                            }
                        }
                    }
                }

                //合计
                for (int i = 0; i < list.Count; i++) 
                {
                    if (list[i].project != null) 
                    {
                        benqijine = benqijine + Convert.ToDecimal(list[i].benqi);
                        bennianjine = bennianjine + Convert.ToDecimal(list[i].bennian);
                        shangqijine = shangqijine + Convert.ToDecimal(list[i].shangqi);
                    }    
                }

                lirunList lr2 = new lirunList();
                lr2.accounting = "净利润：";
                lr2.benqi = benqijine;
                lr2.bennian = bennianjine;
                lr2.shangqi = shangqijine;
                list.Add(lr2);
                

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
