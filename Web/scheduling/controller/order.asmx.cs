﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Services;
using Web.scheduling.model;
using Web.scheduling.service;
using Web.scheduling.utils;

namespace Web.scheduling.controller
{
    /// <summary>
    /// order 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class order : System.Web.Services.WebService
    {
        private OrderInfoService ois;

        [WebMethod]
        public string checkOrder(string orderId)
        {
            try
            {
                ois = new OrderInfoService();
                if (ois.checkOrderId(orderId))
                {
                    return ResultUtil.fail(1, "");
                }
                else 
                {
                    return ResultUtil.fail(-1, "");
                }
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
        public string page(int nowPage, int pageCount, string productName, string orderId)
        {
            try
            {
                ois = new OrderInfoService();
                return ResultUtil.success(ois.page(nowPage, pageCount, productName, orderId), "查询成功");
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
        public string list()
        {
            try
            {
                ois = new OrderInfoService();
                return ResultUtil.success(ois.list(), "查询成功");
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
        public string save(order_info orderInfo, List<BomInfoItem> bomList)
        {
            using (TransactionScope tran = new TransactionScope()) 
            {
                try
                {
                    ois = new OrderInfoService();
                    if (bomList.Count == 0 || bomList == null)
                    {
                        return ResultUtil.error("保存失败");
                    }
                    if (ois.save(orderInfo, bomList))
                    {
                        tran.Complete();
                        return ResultUtil.success("保存成功");
                    }
                    else
                    {
                        return ResultUtil.error("保存失败");
                    }
                }
                catch (ErrorUtil err)
                {
                    return ResultUtil.fail(401, err.Message);
                }
                catch
                {
                    return ResultUtil.error("保存失败");
                }
            }
        }

        [WebMethod]
        public string update(order_info orderInfo)
        {
            try
            {
                ois = new OrderInfoService();
                if (ois.update(orderInfo))
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

        [WebMethod]
        public string delete(int id)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    ois = new OrderInfoService();
                    if (ois.delete(id))
                    {
                        tran.Complete();
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
}
