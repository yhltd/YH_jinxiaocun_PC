using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Server;

namespace Web
{
    public partial class kehu : System.Web.UI.Page
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

                    if (Convert.ToInt32(Session["kehu"]) == 0)
                    {
                        Session["kehu"] = 0;
                    }

                    this.kehu_select_load(sender, e);
                }
                catch
                {
                    Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
                }
            }
        }

        protected void kehu_select_load(object sender, EventArgs e)
        {
            try
            {
                Session["kehu_select"] = kehu_select(user.gongsi);
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }

        }

        public List<yh_jinxiaocun_chuhuofang> kehu_select(string gs_name)
        {
            ChuHuoFangModel chuhuofang = new ChuHuoFangModel();
            return chuhuofang.getList(gs_name);
        }

        protected void delete(object sender, EventArgs e)
        {
            List<yh_jinxiaocun_chuhuofang> list = kehu_select(user.gongsi);
            row_count = list.Count;
            ChuHuoFangModel kehu = new ChuHuoFangModel();
            for (int i = 0; i < row_count; i++)
            {
                string name = Request["Checkbox_bd" + i];
                if (name != null)
                {
                    if (Convert.ToInt32(name) == i)
                    {
                        kehu.delete(list[i]._id);
                    }
                }
            }
            Response.Write("<script>alert('删除成功');</script>");
            this.kehu_select_load(sender, e);
        }

        protected void kehu_tj(object sender, EventArgs e)
        {
            if (Context.Request["tj_pd"].ToString() == "tj_true")
            {
                ChuHuoFangModel kehu = new ChuHuoFangModel();
                List<yh_jinxiaocun_chuhuofang> list = kehu_select(user.gongsi);
                row_count = list.Count;
                string aa = Context.Request["row_i"].ToString();
                List<yh_jinxiaocun_chuhuofang> list_kehu = new List<yh_jinxiaocun_chuhuofang>();
                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    yh_jinxiaocun_chuhuofang chf = new yh_jinxiaocun_chuhuofang();
                    chf.beizhu = Context.Request["beizhu" + i].ToString();
                    chf.lianxidizhi = Context.Request["lianxidizhi" + i].ToString();
                    chf.lianxifangshi = Context.Request["lianxifangshi" + i].ToString();
                    chf.finduser = user.name;
                    chf.gongsi = user.gongsi;

                    list_kehu.Add(chf);
                }
                if (list_kehu.Count > 0)
                {
                    kehu.add(list_kehu);
                }


                for (int i = 0; i < row_count; i++)
                {
                    kehu.update(Context.Request["beizhu_cs" + i].ToString(), Context.Request["lianxidizhi_cs" + i].ToString(), Context.Request["lianxifangshi_cs" + i].ToString(), Context.Request["id_cs" + i].ToString());
                }
                Response.Write(" <script>alert('提交成功');</script>");
                this.kehu_select_load(sender, e);
            }
        }

    }
}