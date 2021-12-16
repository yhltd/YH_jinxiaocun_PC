using System;
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
    /// Summary description for department_new
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class department_new : System.Web.Services.WebService
    {
        private DepartmentService ds;

        private UserInfoService us;

        private user_info user;
        private string quanxian_save;

        //private user_info ui;

        [WebMethod]
        public string departmentList(int nowPage, int pageCount,string department_name,string view_name)
        {

            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "部门");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                ds = new DepartmentService();
                return ResultUtil.success(ds.list(nowPage, pageCount, department_name, view_name), "查询成功");
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

        //private string new_quanxian(string findtype)
        //{
        //    string quanxian_save = "";

        //    user = TokenUtil.getToken();
        //    us = new UserInfoService();
        //    List<department> dlist = us.NewFind_dpnew(user.user_code, user.password, user.company);
        //    String viewname = "部门";
        //    for (int i = 0; i < dlist.Count; i++)
        //    {
        //        if (dlist[i].view_name == viewname)
        //        {
        //            if (findtype == "sel")
        //                quanxian_save = dlist[i].sel;
        //            else if (findtype == "del")
        //                quanxian_save = dlist[i].del;
        //            else if (findtype == "add")
        //                quanxian_save = dlist[i].add;
        //            else if (findtype == "upd")
        //                quanxian_save = dlist[i].upd;
        //        }
        //    }
        //    return quanxian_save;

        //}

        //   public string save(department departmentList)
        [WebMethod]
        public string save(department departmentList)
        {
            try
            {
                us = new UserInfoService();

                string quanxian_save1 = us.new_quanxian("add", "部门");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }


                ds = new DepartmentService();
                if (ds.save(departmentList))
                {
                    return ResultUtil.success("保存成功");
                }
                else
                {
                    return ResultUtil.error("保存失败");
                }
                return "";

            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("查询失败");
            }
            return "";

        }

        [WebMethod]
        public string delete(int id)
        {

            {
                try
                {
                    us = new UserInfoService();
                    string quanxian_save1 = us.new_quanxian("del", "部门");
                    if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                    {
                    }
                    else
                    {

                        return ResultUtil.error("没有权限！");
                    }

                    ds = new DepartmentService();
                    if (ds.delete(id))
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
        public string update(department department)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("upd", "部门");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }


                ds = new DepartmentService();
                if (ds.update(department))
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
