using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    public partial class qi_chu : System.Web.UI.Page
    {
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
                page.countPage = this.select_row();
                shuaxin();
                this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");
                string act = Request["act"] == null ? "" : Request["act"].ToString();

                if (act.Equals("PostUser"))
                {
                    Response.Write(selectNameAndLebie(Request["id"].ToString()));
                    Response.End();
                }

                try
                {
                    List<JinChuZiLiaoItem> list = Session["jichu"] as List<JinChuZiLiaoItem>;
                    if (list == null)
                    {
                        JinChuModel jin = new JinChuModel();
                        Session["jichu"] = jin.getOutStockDetail(user.gongsi);
                    }
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
                List<yh_jinxiaocun_qichushu> list = this.fen_ye(user.gongsi);
                Session["qi_chu_select"] = list;
                row_count = list.Count;
            }
            catch
            {
                Session["qi_chu_select"] = null;
            }
        }

        public List<yh_jinxiaocun_qichushu> select_chuku()
        {
            try
            {
                QiChuModel qiChuModel = new QiChuModel();
                return qiChuModel.getQiChu(user.gongsi);
            }
            catch
            {
                return null;
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
            }
            else
            {
                page.nowPage = 1;
                this.fen_ye(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == 1)
            {
                Response.Write("<script>alert('已经是第一页');</script>");
            }
            else
            {
                page.nowPage--;
                this.fen_ye(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }
        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            if (page.countPage < (page.nowPage + 1))
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
            }
            else
            {
                page.nowPage++;
                this.fen_ye(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }
        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == page.countPage)
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
            }
            else
            {
                page.nowPage = page.countPage;
                this.fen_ye(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }
        }

        public List<yh_jinxiaocun_qichushu> fen_ye(string gongsi)
        {
            QiChuModel buiness = new QiChuModel();
            return buiness.ming_xi_fenye(page.getLimit1(), page.getLimit2(), user.gongsi);
        }

        public int select_row()
        {
            QiChuModel buiness = new QiChuModel();
            int count = buiness.qi_chu_select_row(user.gongsi).Count;
            return (int)Math.Ceiling(Convert.ToDouble((float)count / (float)page.pageCount));
        }

        protected void qc_tj(object sender, EventArgs e)
        {
            try
            {
                if (Context.Request["tj_pd"].ToString() == "tj_true")
                {
                    QiChuModel buiness = new QiChuModel();

                    List<qi_chu_info> list_qc = new List<qi_chu_info>();
                    int row = Convert.ToInt32(Request.Form["row_i"].ToString());
                    for (int i = 1; i < row; i++)
                    {
                        if (Context.Request["cpid" + i] != null)    
                        {
                            qi_chu_info qci = new qi_chu_info();
                            qci.Cpid = Request.Form["cpid" + i].ToString();
                            qci.Cpname = Request.Form["cpname" + i].ToString();
                            qci.Cplb = Request.Form["cplb" + i].ToString();
                            qci.Cpsj = Request.Form["cpsj" + i].ToString();
                            qci.Cpsl = Request.Form["cpsl" + i].ToString();
                            qci.zh_name = user.name;
                            qci.gs_name = user.gongsi;
                            qci.Shijian = DateTime.Now.ToString("yyyy-MM-dd");
                            list_qc.Add(qci);
                        }
                    }
                    if (list_qc.Count > 0) {
                        buiness.add_qichu(list_qc);
                    }
                    
                    for (int i = 0; i < row_count; i++)
                    {
                        buiness.update_qichu(Context.Request["id" + i].ToString(), Context.Request["cpid_cs" + i].ToString(), Context.Request["cpname_cs" + i].ToString(), Context.Request["cplb_cs" + i].ToString(), Context.Request["cpsj_cs" + i].ToString(), Context.Request["cpsl_cs" + i].ToString());
                    }
                    Response.Write(" <script>alert('提交成功'); location='qi_chu.aspx';</script>");
                }
            }
            catch 
            {
                Response.Write(" <script>alert('网络错误，请稍后再试！');</script>");
            }
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