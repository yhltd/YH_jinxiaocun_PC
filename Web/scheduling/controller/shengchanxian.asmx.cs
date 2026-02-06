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
    /// shengchanxian 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class shengchanxian : System.Web.Services.WebService
    {
        private ShengchanxianService ss;

        [WebMethod]
        public string list()
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "生产线");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ss = new ShengchanxianService();
                return ResultUtil.success(ss.listAll(), "查询成功");
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
        public string page(int nowPage, int pageCount, string gongxu, string mingcheng, string xiaolv)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "生产线");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ss = new ShengchanxianService();
                return ResultUtil.success(ss.page(nowPage, pageCount, gongxu, mingcheng, xiaolv), "查询成功");
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
                string quanxian_save1 = us.new_quanxian("sel", "生产线");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ss = new ShengchanxianService();
                return ResultUtil.success(ss.getAll(), "查询成功");
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
        public string save(Web.scheduling.model.shengchanxian shengchanxian)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "生产线");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                    // 有权限，继续执行
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ShengchanxianService ss = new ShengchanxianService();
                if (ss.save(shengchanxian))
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
                // 如果有特定的业务异常，可以这样处理
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
        public string update(Web.scheduling.model.shengchanxian shengchanxian)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("upd", "生产线");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                    // 有权限，继续执行
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ShengchanxianService ss = new ShengchanxianService();
                if (ss.update(shengchanxian))
                {
                    return ResultUtil.success("更新成功");
                }
                else
                {
                    return ResultUtil.error("更新失败");
                }
            }
            catch (Exception ex)  // 修改：使用通用的 Exception
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
                string quanxian_save1 = us.new_quanxian("del", "生产线");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ss = new ShengchanxianService();
                if (ss.delete(id))
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
}