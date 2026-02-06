using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class PaiChanService
    {
        private static PaiChanDao pd = new PaiChanDao();
        private static CommonDao cd = new CommonDao();
        private user_info user;

        public PaiChanService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页行数</param>
        /// <param name="order_id">订单ID</param>
        /// <param name="work_num">排产数量</param>
        /// <param name="start_date">开始日期</param>
        /// <param name="end_date">结束日期</param>
        /// <returns></returns>
        public PageUtil<work_detail> page(int nowPage, int pageCount, int? orderId = null)
        {
            PageUtil<work_detail> page = new PageUtil<work_detail>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;

            // 获取总记录数
            page.total = pd.count(user.company, orderId);

            // 获取分页数据
            page.pageList = pd.list(user.company, nowPage, pageCount, orderId);

            return page;
        }

        /// <summary>
        /// 获取所有排产明细（不分页）
        /// </summary>
        /// <returns></returns>
        public List<WorkDetailDTO> getAll()
        {
            try
            {
                user = TokenUtil.getToken();
                if (user == null)
                {
                    throw new ErrorUtil("无权限");
                }

                // 调用新的联查方法，返回DTO
                return pd.GetAll(user.company);
            }
            catch (Exception ex)
            {
                throw new ErrorUtil("获取排产明细列表失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 新增排产明细
        /// </summary>
        /// <param name="work_detail"></param>
        /// <returns></returns>
        public Boolean save(work_detail wd)
        {
            try
            {
                // 设置公司信息
                wd.company = user.company;

                // 验证必填字段
                if (wd.order_id <= 0)
                {
                    throw new Exception("订单ID必须大于0");
                }

                if (wd.work_num <= 0)
                {
                    throw new Exception("排产数量必须大于0");
                }

                if (wd.work_start_date == null || wd.work_start_date == DateTime.MinValue)
                {
                    throw new Exception("开始日期不能为空");
                }

                // 如果行号为空，自动生成
                if (wd.row_num == null || wd.row_num <= 0)
                {
                    wd.row_num = getNextRowNum();
                }

                // 如果类型为空，设置默认值
                if (string.IsNullOrEmpty(wd.type))
                {
                    wd.type = "normal";
                }

                // 如果是否插入为空，设置默认值
                if (wd.is_insert == null)
                {
                    wd.is_insert = 0;
                }

                return pd.save_work_detail(wd) != null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取下一个行号
        /// </summary>
        /// <returns></returns>
        private int getNextRowNum()
        {
            try
            {
                var maxRowNum = pd.getMaxRowNum(user.company);
                return maxRowNum + 1;
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// 修改排产明细
        /// </summary>
        /// <param name="work_detail"></param>
        /// <returns></returns>
        public Boolean update(work_detail wd)
        {
            try
            {
                if (wd.id <= 0)
                {
                    throw new Exception("排产明细ID无效");
                }

                // 验证必填字段
                if (wd.order_id <= 0)
                {
                    throw new Exception("订单ID必须大于0");
                }

                if (wd.work_num <= 0)
                {
                    throw new Exception("排产数量必须大于0");
                }

                if (wd.work_start_date == null || wd.work_start_date == DateTime.MinValue)
                {
                    throw new Exception("开始日期不能为空");
                }

                wd.company = user.company;
                return pd.update_work_detail(wd);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除排产明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            return cd.delete<work_detail>(id);
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
                if (!cd.delete<work_detail>(id))
                {
                    return false;
                }
            }
            return true;
        }
    }
}