using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.finance.entiy;
using Web.finance.util;


namespace Web.finance.model
{
    public class User_ManagementModel
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public User_ManagementModel() 
        {
            fin = new FinanceEntities();
        }


        public FinancePage<User_ManagementItem> getList(FinancePage<User_ManagementItem> financePage, string company)
        {
            //公司
            var companyParam = new SqlParameter("@company", company);
            //查询最小行号
            var minPageParam = new SqlParameter("@minPageParam", financePage.getMin());
            //查询最大行号
            var maxPageParam = new SqlParameter("@maxPageParam", financePage.getMax());

            string sql = "select a.id,a.rownum,a.name,a.pwd,a.do,a.bianhao from (select *,row_number() over(order by id) as rownum from Account where company = @company) as a where a.rownum > @minPageParam and a.rownum < @maxPageParam";
            var result = fin.Database.SqlQuery<User_ManagementItem>(sql, companyParam, minPageParam, maxPageParam);
            try
            {
                financePage.pageList = result.ToList();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return financePage;
        }





        public int getPageCount(string company)
        {
            //公司
            var companyParam = new SqlParameter("@company", company);

            string sql = "select count(*) as total from Account where company = @company";

            var result = fin.Database.SqlQuery<FinancePage<User_ManagementItem>>(sql, companyParam);
            int total = 0;
            try
            {
                total = result.FirstOrDefault().total;
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return total;
        }


        public int delUser(int id)
        {
            List<Account> list = fin.Account.Where(u => u.id == id).ToList();
            string bianhao = list[0].bianhao;

            List<quanxian> list2 = fin.quanxian.Where(u => u.bianhao == bianhao).ToList();
            int quanxianid = list2[0].id;
            quanxian quan = fin.quanxian.Find(quanxianid);
            fin.quanxian.Remove(quan);

            fin.Account.Remove(this.findUser(id));
            int result = 0;
            try
            {
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }


        public Account findUser(int id)
        {
            Account deopartment = null;
            try
            {
                deopartment = fin.Account.Find(id);
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return deopartment;
        }


        public int updUser(Account account)
        {
            //新的实体类添加到上下文
            fin.Account.Attach(account);
            //手动修改状态
            fin.Entry<Account>(account).State = EntityState.Modified;
            int result = 0;
            try
            {
                //保存修改
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }


        public int newUser(Account account)
        {

            fin.Account.Add(account);
            int result = 0;
            try
            {
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }

        public int newQuanXian(quanxian quan)
        {

            fin.quanxian.Add(quan);
            int result = 0;
            try
            {
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }


        public quanxian getQuanXian(string bianhao)
        {
            quanxian quanxian = null;
            try
            {
                List<quanxian> list = fin.quanxian.Where(u => u.bianhao == bianhao).ToList();
                int quanxianid = list[0].id;
                quanxian = fin.quanxian.Find(quanxianid);
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return quanxian;
        }

        public int updQuanXian(quanxian quanxian)
        {
            //新的实体类添加到上下文
            quanxian updquanxian = null;
            List<quanxian> list = fin.quanxian.Where(u => u.bianhao == quanxian.bianhao).ToList();
            int quanxianid = list[0].id;
            updquanxian = fin.quanxian.Find(quanxianid);
            updquanxian.kmzz_add = quanxian.kmzz_add;
            updquanxian.kmzz_delete = quanxian.kmzz_delete;
            updquanxian.kmzz_update = quanxian.kmzz_update;
            updquanxian.kmzz_select = quanxian.kmzz_select;
            updquanxian.kzxm_add = quanxian.kzxm_add;
            updquanxian.kzxm_delete = quanxian.kzxm_delete;
            updquanxian.kzxm_update = quanxian.kzxm_update;
            updquanxian.kzxm_select = quanxian.kzxm_select;
            updquanxian.bmsz_add = quanxian.bmsz_add;
            updquanxian.bmsz_delete = quanxian.bmsz_delete;
            updquanxian.bmsz_update = quanxian.bmsz_update;
            updquanxian.bmsz_select = quanxian.bmsz_select;
            updquanxian.zhgl_add = quanxian.zhgl_add;
            updquanxian.zhgl_delete = quanxian.zhgl_delete;
            updquanxian.zhgl_update = quanxian.zhgl_update;
            updquanxian.zhgl_select = quanxian.zhgl_select;
            updquanxian.pzhz_add = quanxian.pzhz_add;
            updquanxian.pzhz_delete = quanxian.pzhz_delete;
            updquanxian.pzhz_update = quanxian.pzhz_update;
            updquanxian.pzhz_select = quanxian.pzhz_select;
            updquanxian.znkb_select = quanxian.znkb_select;
            updquanxian.xjll_select = quanxian.xjll_select;
            updquanxian.zcfz_select = quanxian.zcfz_select;
            updquanxian.lysy_select = quanxian.lysy_select;
            updquanxian.jjtz_add = quanxian.jjtz_add;
            updquanxian.jjtz_delete = quanxian.jjtz_delete;
            updquanxian.jjtz_update = quanxian.jjtz_update;
            updquanxian.jjtz_select = quanxian.jjtz_select;
            updquanxian.jjzz_add = quanxian.jjzz_add;
            updquanxian.jjzz_delete = quanxian.jjzz_delete;
            updquanxian.jjzz_update = quanxian.jjzz_update;
            updquanxian.jjzz_select = quanxian.jjzz_select;

            fin.quanxian.Attach(updquanxian);
            //手动修改状态
            fin.Entry<quanxian>(updquanxian).State = EntityState.Modified;
            int result = 0;
            try
            {
                //保存修改
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }

        




    }
}
