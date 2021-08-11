using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Server;

namespace Web
{
    public partial class gongyingshang : System.Web.UI.Page
    {
        private int row_count;
        private static yh_jinxiaocun_user user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            else
            {
                try
                {
                    this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");

                    if (Convert.ToInt32(Session["gongyingshang"]) == 0)
                    {
                        Session["gongyingshang"] = 0;
                    }

                    this.gys_select_load(sender, e);
                }
                catch
                {
                    Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
                }
            }
        }

        protected void gys_select_load(object sender, EventArgs e)
        {
            try
            {
                Session["gys_select"] = gys_select(user.gongsi);
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }

        }

        public List<yh_jinxiaocun_jinhuofang> gys_select(string gs_name)
        {
            JinHuoFangModel jinhuofang = new JinHuoFangModel();
            return jinhuofang.getList(gs_name);
        }

        protected void delete(object sender, EventArgs e)
        {
            List<yh_jinxiaocun_jinhuofang> list = gys_select(user.gongsi);
            row_count = list.Count;
            JinHuoFangModel gys = new JinHuoFangModel();
            for (int i = 0; i < row_count; i++)
            {
                string name = Request["Checkbox_bd" + i];
                if (name != null)
                {
                    if (Convert.ToInt32(name) == i)
                    {
                        gys.delete(list[i]._id);
                    }
                }
            }
            Response.Write("<script>alert('删除成功');</script>");
            this.gys_select_load(sender, e);
        }

        protected void gys_tj(object sender, EventArgs e)
        {
            if (Context.Request["tj_pd"].ToString() == "tj_true")
            {
                JinHuoFangModel gys = new JinHuoFangModel();
                List<yh_jinxiaocun_jinhuofang> list = gys_select(user.gongsi);
                row_count = list.Count;
                string aa = Context.Request["row_i"].ToString();
                List<yh_jinxiaocun_jinhuofang> list_gys = new List<yh_jinxiaocun_jinhuofang>();
                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    yh_jinxiaocun_jinhuofang chf = new yh_jinxiaocun_jinhuofang();
                    chf.beizhu = Context.Request["beizhu" + i].ToString();
                    chf.lianxidizhi = Context.Request["lianxidizhi" + i].ToString();
                    chf.lianxifangshi = Context.Request["lianxifangshi" + i].ToString();
                    chf.finduser = user.name;
                    chf.gongsi = user.gongsi;

                    list_gys.Add(chf);
                }
                if (list_gys.Count > 0)
                {
                    gys.add(list_gys);
                }


                for (int i = 0; i < row_count; i++)
                {
                    gys.update(Context.Request["beizhu_cs" + i].ToString(), Context.Request["lianxidizhi_cs" + i].ToString(), Context.Request["lianxifangshi_cs" + i].ToString(), Context.Request["id_cs" + i].ToString());
                }
                Response.Write(" <script>alert('提交成功');</script>");
                this.gys_select_load(sender, e);
            }
        }
    }
}