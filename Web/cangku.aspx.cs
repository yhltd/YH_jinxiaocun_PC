using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Server;

namespace Web
{
    public partial class cangku : System.Web.UI.Page
    {
        private int row_count;
        private static yh_jinxiaocun_user user;
        int now_lisetcount;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user.AdminIS.Equals("false"))
            {
                Response.Redirect("~/wqx.aspx");
            }
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
                List<yh_jinxiaocun_cangku> list = Session["kehu_select"] as List<yh_jinxiaocun_cangku>;
                now_lisetcount = list.Count();
                Session["now_lisetcount_1"] = now_lisetcount;
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }

        }

        protected void kehu_chaxun(object sender, EventArgs e)
        {
            try
            {
                string cangkuName = Request.Form["kh_cx"];
                Session["kehu_select"] = chaxun(user.gongsi, cangkuName);
                // 保存 查询条数到Session  方便之后保存提交 调用此数据
                List<yh_jinxiaocun_cangku> list = Session["kehu_select"] as List<yh_jinxiaocun_cangku>;
                now_lisetcount = list.Count();
                Session["now_lisetcount_1"] = now_lisetcount;


            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }

        }

        public List<yh_jinxiaocun_cangku> kehu_select(string gs_name)
        {
            CangKuModel cangku = new CangKuModel();
            return cangku.getList(gs_name);
        }

        public List<yh_jinxiaocun_cangku> chaxun(string gs_name, string cangkuName)
        {
            CangKuModel cangku = new CangKuModel();
            return cangku.getList_chaxun(gs_name, cangkuName);
        }

        protected void delete(object sender, EventArgs e)
        {
            List<yh_jinxiaocun_cangku> list = kehu_select(user.gongsi);
            row_count = list.Count;
            CangKuModel cangku = new CangKuModel();
            for (int i = 0; i < row_count; i++)
            {
                string name = Request["Checkbox_bd" + i];
                if (name != null)
                {
                    if (Convert.ToInt32(name) == i)
                    {
                        cangku.delete(list[i].id);
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
                CangKuModel cangku = new CangKuModel();
                row_count = Convert.ToInt32(Session["now_lisetcount_1"].ToString());

                string aa = Context.Request["row_i"].ToString();
                List<yh_jinxiaocun_cangku> list_cangku = new List<yh_jinxiaocun_cangku>();
                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    yh_jinxiaocun_cangku ck = new yh_jinxiaocun_cangku();
                    ck.cangku = Context.Request["cangku" + i].ToString();
                    ck.gongsi = user.gongsi; // 自动添加公司字段

                    list_cangku.Add(ck);
                }
                if (list_cangku.Count > 0)
                {
                    cangku.add(list_cangku);
                }


                for (int i = 0; i < row_count; i++)
                {
                    cangku.update(
                        Context.Request["cangku_cs" + i].ToString(), 
                        Context.Request["id_cs" + i].ToString(),
                        user.gongsi); // 更新时也保持公司字段
                }
                Response.Write(" <script>alert('提交成功');</script>");
                this.kehu_select_load(sender, e);
            }
        }
    }
}