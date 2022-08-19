using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.util;

namespace Web.finance.model
{
    /// <author>
    /// dai
    /// </author>
    public class SpaceModel
    {
        //数据库模型
        private bds28428944_dbEntities bde;

        //实例化
        public SpaceModel() {
            bde = new bds28428944_dbEntities();
        }

        /// <summary>
        /// 获取时间配置表中的某个公司对象
        /// </summary>
        /// <param name="company">公司名</param>
        /// <returns>control_soft_time</returns>
        public control_soft_time getUserSpaceInfo(string company)
        {
            var result = from u in bde.control_soft_time where u.name == company && u.soft_name == "财务" select u;
            control_soft_time cst = null;
            try
            {
                cst = result.FirstOrDefault();
            }
            catch(Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return cst;
        }

        /// <summary>
        /// 获取时间配置表中的某个公司对象
        /// </summary>
        /// <param name="company">公司名</param>
        /// <returns>control_soft_time</returns>
        public control_soft_time getUserSpaceInfo_all(string company,string xitong)
        {
            var result = from u in bde.control_soft_time where u.name == company && u.soft_name == xitong select u;
            control_soft_time cst = null;
            try
            {
                cst = result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return cst;
        }
    }
}