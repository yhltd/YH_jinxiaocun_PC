using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.scheduling.model;
using Web.scheduling.service;
using Web.scheduling.utils;

namespace Web.scheduling.controller
{
    /// <summary>
    /// Summary description for paibanDetail
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class paibanDetail : System.Web.Services.WebService
    {
        private PaiBanDetailService pds;

        private UserInfoService us;

        [WebMethod]
        public string getList(int nowPage, int pageCount,string staff_name,string banci)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "排班明细");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                pds = new PaiBanDetailService();
                return ResultUtil.success(pds.list(nowPage, pageCount,staff_name,banci), "查询成功");
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
        public string delete(int id)
        {
            {
                try
                {
                    us = new UserInfoService();
                    string quanxian_save1 = us.new_quanxian("del", "排班明细");
                    if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                    {
                    }
                    else
                    {

                        return ResultUtil.error("没有权限！");
                    }

                    pds = new PaiBanDetailService();
                    if (pds.delete(id))
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
        }

        public string delete2(string remarks2)
        {
            {
                try
                {
                    pds = new PaiBanDetailService();
                    if (pds.delete2(remarks2))
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
        }

        [WebMethod]
        public string update(paibanbiao_detail updateList)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("upd", "排班明细");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                pds = new PaiBanDetailService();
                if (pds.update(updateList))
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
