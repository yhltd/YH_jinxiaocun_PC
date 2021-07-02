using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class PaiBanDetailService
    {
        private static PaibanDetailDao pbd = new PaibanDetailDao();

        private static PaibanbiaoInfoDao pid = new PaibanbiaoInfoDao();

        private user_info user;


        public PaiBanDetailService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 保存每一条明细
        /// </summary>
        /// <param name="orderInfo">订单信息</param>
        /// <param name="bomList">所用物料信息</param>
        /// <returns></returns>
        public Boolean save(paibanbiao_info paibanbiaoInfo, List<paibanbiao_detail> paibanDetailList,String paibanbiao_id)
        {
            paibanbiaoInfo.riqi = DateTime.Now.ToString("yyyy-MM-dd");
            paibanbiaoInfo.remarks1 = user.company;
            paibanbiaoInfo.remarks2 = paibanbiao_id;
            pid.save<paibanbiao_info>(paibanbiaoInfo);
            foreach (paibanbiao_detail list in paibanDetailList)
            {
                list.company = user.company;
                pbd.save<paibanbiao_detail>(list);
            }
            return true;
        }

        /// <summary>
        /// 查询所有明细
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页显示行数</param>
        /// <returns></returns>
        public PageUtil<paibanbiao_detail> list(int nowPage, int pageCount,string staff_name,string banci)
        {
            PageUtil<paibanbiao_detail> page = new PageUtil<paibanbiao_detail>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = pbd.Count();
            page.pageList = pbd.getList(page.getSkip(), page.getTake(), user.company,staff_name,banci);
            return page;
        }



        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            return pbd.delete<paibanbiao_detail>(id);
        }

        /// <summary>
        /// 修改人员信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public Boolean update(paibanbiao_detail detailList)
        {
            return pbd.update<paibanbiao_detail>(detailList);
        }
    }
}