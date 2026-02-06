using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class ShengchanxianService
    {
        private static ShengchanxianDao sd = new ShengchanxianDao();
        private static CommonDao cd = new CommonDao();
        private user_info user;

        public ShengchanxianService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 查询全部生产线
        /// </summary>
        /// <returns></returns>
        public List<shengchanxian> listAll()
        {
            return sd.listAll(user.company);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页行数</param>
        /// <param name="gongxu">工序</param>
        /// <param name="mingcheng">名称</param>
        /// <returns></returns>
        public PageUtil<shengchanxian> page(int nowPage, int pageCount, string gongxu, string mingcheng, string xiaolv)
        {
            PageUtil<shengchanxian> page = new PageUtil<shengchanxian>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = sd.count(user.company, gongxu ?? "", mingcheng ?? "", xiaolv ?? "");
            page.pageList = sd.list(user.company, page.getSkip(), page.getTake(), gongxu ?? "", mingcheng ?? "", xiaolv ?? "");
            return page;
        }

        /// <summary>
        /// 获取所有生产线（不分页，返回所有数据）
        /// </summary>
        /// <returns></returns>
        public List<shengchanxian> getAll()
        {
            try
            {
                // 验证用户权限
                user = TokenUtil.getToken();
                if (user == null)
                {
                    throw new ErrorUtil("无权限");
                }

                // 调用Dao层的getAll方法
                return sd.getAll(user.company);
            }
            catch (Exception ex)
            {
                // 这里可以根据需要记录日志
                throw new ErrorUtil("获取生产线列表失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 新增生产线
        /// </summary>
        /// <param name="shengchanxian"></param>
        /// <returns></returns>
        public Boolean save(shengchanxian sx)
        {
            try
            {

                sx.gongsi = user.company;
                return sd.save_shengchanxian(sx) != null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改生产线信息
        /// </summary>
        /// <param name="shengchanxian"></param>
        /// <returns></returns>
        public Boolean update(shengchanxian sx)
        {
            try
            {
                if (sx.id <= 0)
                {
                    throw new Exception("生产线ID无效");
                }

                sx.gongsi = user.company;
                return sd.update_shengchanxian(sx);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除生产线
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            return cd.delete<shengchanxian>(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public Boolean deleteBatch(List<int> idList)
        {
            foreach (int id in idList)
            {
                if (!cd.delete<shengchanxian>(id))
                {
                    return false;
                }
            }
            return true;
        }
    }
}