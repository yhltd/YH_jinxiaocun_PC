using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SDZdb;
using System.ComponentModel;
using System.Configuration;
using Order.Common;
using clsBuiness;
using System.Reflection;
using Web.Server;
using Web.ServerEntity;
using System.Web.Script.Serialization;
using Web.jxc_service;

namespace Web
{
    public partial class kucunjiya : System.Web.UI.Page
    {
        // 添加日期控件的声明
        protected HtmlInputControl time_qs;
        protected HtmlInputControl time_jz;

        private int row_count;
        private static ServicePage page = new ServicePage();

        private static yh_jinxiaocun_user user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user.AdminIS.Equals("false"))
            {
                Response.Redirect("~/wqx.aspx");
            }
            if (user != null)
            {
                if (Session["warehouseList"] == null)
                {
                    CangKuModel cangkuModel = new CangKuModel();
                    List<yh_jinxiaocun_cangku> warehouses = cangkuModel.getList(user.gongsi);
                    List<string> warehouseNames = new List<string>();
                    foreach (var warehouse in warehouses)
                    {
                        if (!string.IsNullOrEmpty(warehouse.cangku))
                        {
                            warehouseNames.Add(warehouse.cangku);
                        }
                    }
                    Session["warehouseList"] = warehouseNames;
                }

                page.countPage = this.select_row();
                shuaxin();

                string act = Request["act"] == null ? "" : Request["act"].ToString();

                if (act.Equals("PostUser"))
                {
                    Response.Write(selectNameAndLebie(Request["id"].ToString()));
                    Response.End();
                }

                try
                {
                    Session["jichu"] = null;
                    // 修改这里：使用新的类型
                    List<QiChuQiMoShuItem> list = Session["jichu"] as List<QiChuQiMoShuItem>;
                    if (list == null)
                    {
                        string shijian = Request.Form["shijian"];
                        string shuliang = Request.Form["shuliang"];
                        string cpname = Request.Form["qc_cx"];
                        string cangku = Request.Form["warehouse_select"];

                        JinChuModel jin = new JinChuModel();
                        Session["jichu"] = jin.getOutStockDetailJY(user.gongsi, shijian, shuliang, cpname, cangku);
                    }
                    lblCurrentPage.Text = page.nowPage.ToString();
                }
                catch
                {
                    Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
        }

        protected void bt_select_Click(object sender, EventArgs e)
        {
            shuaxin();
        }

        private void shuaxin()
        {
            try
            {
                // 获取日期参数
                string shijian = Request.Form["shijian"];
                string shuliang = Request.Form["shuliang"];
                string cpname = Request.Form["qc_cx"]; // 也获取商品名称
                string cangku = Request.Form["warehouse_select"];

                JinChuModel jin = new JinChuModel();
                List<QiChuQiMoShuItem> list = jin.getOutStockDetailJY(user.gongsi, shijian, shuliang, cpname, cangku);

                // 如果有商品名称过滤条件，进行筛选
                if (!string.IsNullOrEmpty(cpname))
                {
                    list = list.Where(item =>
                        item.name != null &&
                        item.name.Contains(cpname)).ToList();
                }

                Session["qi_chu_select"] = list;
                row_count = list.Count;
            }
            catch (Exception ex)
            {
                Session["qi_chu_select"] = null;
            }
        }

        protected void bt_chaxun(object sender, EventArgs e)
        {
            chaxun();
        }

        private void chaxun()
        {
            try
            {
                // 获取查询参数
                string cpname = Request.Form["qc_cx"]; // 从表单获取
                string shijian = Request.Form["shijian"];
                string shuliang = Request.Form["shuliang"];
                string cangku = Request.Form["warehouse_select"];

                // 调用新的查询方法
                JinChuModel jin = new JinChuModel();
                List<QiChuQiMoShuItem> list = jin.getOutStockDetailJY(user.gongsi, shijian, shuliang, cpname, cangku);

                // 如果有商品名称过滤条件，进行筛选
                if (!string.IsNullOrEmpty(cpname))
                {
                    list = list.Where(item =>
                        item.name != null &&
                        item.name.Contains(cpname)).ToList();
                }

                Session["qi_chu_select"] = list;
                row_count = list.Count;
            }
            catch (Exception ex)
            {
                // 添加日志以便调试
                Session["qi_chu_select"] = null;
            }
        }


        public string selectNameAndLebie(object id)
        {
            try
            {
                List<JinChuZiLiaoItem> list = Session["jichu"] as List<JinChuZiLiaoItem>;
                foreach (JinChuZiLiaoItem j in list)
                {
                    if (j.sp_dm.Equals(id))
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        return js.Serialize(j);
                    }
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == 1)
            {
                Response.Write("<script>alert('已经是第一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage = 1;
                this.fen_ye(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == 1)
            {
                Response.Write("<script>alert('已经是第一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage--;
                this.fen_ye(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            if (page.countPage < (page.nowPage + 1))
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage++;
                this.fen_ye(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == page.countPage)
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage = page.countPage;
                this.fen_ye(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }

        public List<yh_jinxiaocun_qichushu> fen_ye(string gongsi)
        {
            QiChuModel buiness = new QiChuModel();
            return buiness.ming_xi_fenye(page.getLimit1(), page.getLimit2(), user.gongsi);
        }

        public List<yh_jinxiaocun_qichushu> chaxun(string gongsi, string cpname, string startDate = null, string endDate = null)
        {
            QiChuModel buiness = new QiChuModel();
            return buiness.ming_xi_chaxun(page.getLimit1(), page.getLimit2(), user.gongsi, cpname);
        }

        public int select_row()
        {
            QiChuModel buiness = new QiChuModel();
            int count = buiness.qi_chu_select_row(user.gongsi).Count;
            return (int)Math.Ceiling(Convert.ToDouble((float)count / (float)page.pageCount));
        }


        //后加的删除
        protected void del_qichu(object sender, EventArgs e)
        {
            QiChuModel qichu = new QiChuModel();
            Boolean result = true;
            try
            {
                List<yh_jinxiaocun_qichushu> list = Session["qi_chu_select"] as List<yh_jinxiaocun_qichushu>;
                for (int i = 0; i < list.Count; i++)
                {
                    string name = Request["Checkbox_bd" + i];
                    if (name != null)
                    {
                        if (Convert.ToInt32(name) == i)
                        {
                            result = qichu.del_qichu_ff(list[i]._id) > 0;
                        }
                    }
                }
                if (result)
                {
                    shuaxin();
                    Response.Write("<script>alert('删除成功');</script>");
                }
            }
            catch
            {
                Response.Write(" <script>alert('网络错误，请稍后再试！');</script>");
            }
        }
    }
}