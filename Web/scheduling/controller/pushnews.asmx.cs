using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Web.scheduling.model;
using Web.scheduling.service;
using Web.scheduling.utils;

namespace Web.scheduling.controller
{
    /// <summary>
    /// Summary description for renyuan
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class renyuan : System.Web.Services.WebService
    {
        private UserInfoService us;

        private RenyuanService rs;

        private PaiBanDetailService pbds;

        //private int lunhuanjiangetianshu = 0;


            [WebMethod]
            public string getDepartment()
            {
                try
                {
                    //us = new UserInfoService();
                    //string quanxian_save1 = us.new_quanxian("sel", "人员信息");
                    //if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                    //{
                    //}
                    //else
                    //{
                    //    return ResultUtil.error("没有权限！");
                    //}

                    //rs = new RenyuanService();
                    //return ResultUtil.success(rs.getDepartment(), "查询成功");
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


        


    }
}
