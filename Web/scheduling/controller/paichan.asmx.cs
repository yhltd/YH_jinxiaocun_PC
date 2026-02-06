using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.scheduling.model;
using Web.scheduling.service;
using Web.scheduling.utils;
using System.Web.Script.Services;

namespace Web.scheduling.controller
{
    /// <summary>
    /// paichan 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class paichan : System.Web.Services.WebService
    {
        private PaiChanService ps;

        [WebMethod]
        public string page(int nowPage, int pageCount, int orderId = 0)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "排产");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ps = new PaiChanService();
                int? orderIdNullable = orderId > 0 ? (int?)orderId : null;
                return ResultUtil.success(ps.page(nowPage, pageCount, orderIdNullable), "查询成功");
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
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getAll()
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "排产");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ps = new PaiChanService();
                return ResultUtil.success(ps.getAll(), "查询成功");
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
        public string save(Web.scheduling.model.work_detail work_detail)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "排产");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ps = new PaiChanService();
                if (ps.save(work_detail))
                {
                    return ResultUtil.success("保存成功");
                }
                else
                {
                    return ResultUtil.error("保存失败");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("权限") || ex.Message.Contains("验证"))
                {
                    return ResultUtil.error(ex.Message);
                }
                return ResultUtil.fail(401, "操作失败：" + ex.Message);
            }
            catch
            {
                return ResultUtil.error("保存失败");
            }
        }

        [WebMethod]
        public string update(Web.scheduling.model.work_detail work_detail)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("upd", "排产");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ps = new PaiChanService();
                if (ps.update(work_detail))
                {
                    return ResultUtil.success("更新成功");
                }
                else
                {
                    return ResultUtil.error("更新失败");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("权限") || ex.Message.Contains("验证"))
                {
                    return ResultUtil.error(ex.Message);
                }
                return ResultUtil.fail(401, "操作失败：" + ex.Message);
            }
            catch
            {
                return ResultUtil.error("更新失败");
            }
        }

        [WebMethod]
        public string delete(int id)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("del", "排产");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ps = new PaiChanService();
                if (ps.delete(id))
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
        public string deleteBatch(List<int> idList)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("del", "排产");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ps = new PaiChanService();
                if (ps.deleteBatch(idList))
                {
                    return ResultUtil.success("批量删除成功");
                }
                else
                {
                    return ResultUtil.error("批量删除失败");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("批量删除失败");
            }
        }
    }
}