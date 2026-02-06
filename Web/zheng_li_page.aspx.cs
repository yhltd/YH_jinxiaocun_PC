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

namespace Web
{
    public partial class zheng_li_page : System.Web.UI.Page
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
            else {
                try
                {
                    this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");

                    if (Convert.ToInt32(Session["dq_ye_zl"]) == 0)
                    {
                        Session["dq_ye_zl"] = 0;
                    }
                    if (!Page.IsPostBack)
                        this.zl_select_load(sender, e);
                }
                catch
                {
                    Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
                }
            }
        }

        protected void zl_select_load(object sender, EventArgs e)
        {
            try
            {
                Session["zl_and_jc_select"] = zl_select(user.gongsi);
                List<yh_jinxiaocun_zhengli> list = Session["zl_and_jc_select"] as List<yh_jinxiaocun_zhengli>;
                now_lisetcount = list.Count();
                Session["now_lisetcount_1"] = now_lisetcount;
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }

        protected void chaxun(object sender, EventArgs e)
        {
            try
            {
                string name = Request.Form["zl_cx"];
                Session["zl_and_jc_select"] = zl_chaxun(user.gongsi, name);
                // 保存 查询条数到Session  方便之后保存提交 调用此数据
                List<yh_jinxiaocun_zhengli> list = Session["zl_and_jc_select"] as List<yh_jinxiaocun_zhengli>;
                now_lisetcount = list.Count();
                Session["now_lisetcount_1"] = now_lisetcount;
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }

        }

        public List<yh_jinxiaocun_zhengli> zl_chaxun(string gs_name, string name)
        {
            ZhengLiModel zhengli = new ZhengLiModel();
            return zhengli.getList_chaxun(gs_name,name);
        }

        public List<yh_jinxiaocun_zhengli> zl_select(string gs_name)
        {
            ZhengLiModel zhengli = new ZhengLiModel();
            return zhengli.getList(gs_name);
        }

        protected void del_qichu(object sender, EventArgs e)
        {
            List<yh_jinxiaocun_zhengli> list = zl_select(user.gongsi);
            row_count = list.Count;
            ZhengLiModel zhengli = new ZhengLiModel();
            for (int i = 0; i < row_count; i++)
            {
                string name = Request["Checkbox_bd" + i];
                if (name != null)
                {
                    if (Convert.ToInt32(name) == i)
                    {
                        zhengli.delete(list[i].id);
                    }
                }
            }
            Response.Write("<script>alert('删除成功');</script>");
            this.zl_select_load(sender, e);
        }


        protected void zl_tj(object sender, EventArgs e)
        {
            if (Context.Request["tj_pd"].ToString() == "tj_true")
            {
                ZhengLiModel zhengli = new ZhengLiModel();
                // 获取数据库中现有的所有商品
                List<yh_jinxiaocun_zhengli> existingProducts = zl_select(user.gongsi);

                row_count = Convert.ToInt32(Session["now_lisetcount_1"].ToString());
                List<yh_jinxiaocun_zhengli> list_zl = new List<yh_jinxiaocun_zhengli>();
                List<string> duplicateProducts = new List<string>(); // 存储重复的商品信息

                // 检查新增的商品是否重复
                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    yh_jinxiaocun_zhengli zaji = new yh_jinxiaocun_zhengli();
                    zaji.sp_dm = Context.Request["sp_dm" + i].ToString();
                    zaji.name = Context.Request["name" + i].ToString();
                    zaji.lei_bie = Context.Request["lei_bie" + i].ToString();
                    zaji.dan_wei = Context.Request["dan_wei" + i].ToString();
                    zaji.beizhu = Context.Request["bei_zhu" + i].ToString();

                    zaji.zh_name = user.name;
                    zaji.gs_name = user.gongsi;

                    // 检查是否与现有商品完全重复（所有字段都相同）
                    bool isDuplicate = existingProducts.Any(p =>
                        p.sp_dm == zaji.sp_dm &&
                        p.name == zaji.name &&
                        p.lei_bie == zaji.lei_bie &&
                        p.dan_wei == zaji.dan_wei &&
                        p.beizhu == zaji.beizhu &&
                        p.gs_name == zaji.gs_name); // 同一公司内检查

                    if (isDuplicate)
                    {
                        // 记录重复的商品信息
                        string duplicateInfo = string.Format("商品代码: {0}, 商品名称: {1}", zaji.sp_dm, zaji.name);
                        duplicateProducts.Add(duplicateInfo);
                    }
                    else
                    {
                        list_zl.Add(zaji);

                        // 同时将新添加的商品添加到现有列表中，用于检查后续的新增商品是否重复
                        yh_jinxiaocun_zhengli tempProduct = new yh_jinxiaocun_zhengli();
                        tempProduct.sp_dm = zaji.sp_dm;
                        tempProduct.name = zaji.name;
                        tempProduct.lei_bie = zaji.lei_bie;
                        tempProduct.dan_wei = zaji.dan_wei;
                        tempProduct.beizhu = zaji.beizhu;
                        tempProduct.gs_name = zaji.gs_name;
                        existingProducts.Add(tempProduct);
                    }
                }

                // 如果有重复的商品，提示用户
                if (duplicateProducts.Count > 0)
                {
                    string duplicateMessage = "以下商品与已有商品完全相同，不允许重复添加：\n\n" +
                                             string.Join("\n", duplicateProducts) +
                                             "\n\n请修改重复的商品信息后再提交！";
                    Response.Write("<script>alert('" + duplicateMessage.Replace("'", "\\'").Replace("\n", "\\n") + "');</script>");
                    return; // 停止提交
                }

                // 检查新增商品之间是否有重复
                var duplicateInNewList = list_zl
                    .GroupBy(p => new { p.sp_dm, p.name, p.lei_bie, p.dan_wei, p.beizhu })
                    .Where(g => g.Count() > 1)
                    .Select(g => string.Format("商品代码: {0}, 商品名称: {1}", g.Key.sp_dm, g.Key.name))
                    .ToList();

                if (duplicateInNewList.Count > 0)
                {
                    string duplicateMessage = "新增的商品中存在重复项：\n\n" +
                                             string.Join("\n", duplicateInNewList) +
                                             "\n\n请修改重复的商品信息后再提交！";
                    Response.Write("<script>alert('" + duplicateMessage.Replace("'", "\\'").Replace("\n", "\\n") + "');</script>");
                    return; // 停止提交
                }

                // 如果没有重复，则执行添加操作
                if (list_zl.Count > 0)
                {
                    zhengli.add(list_zl);
                }

                // 更新现有商品
                for (int i = 0; i < row_count; i++)
                {
                    zhengli.update(
                        Context.Request["sp_dm_cs" + i].ToString(),
                        Context.Request["name_cs" + i].ToString(),
                        Context.Request["lei_bie_cs" + i].ToString(),
                        Context.Request["dan_wei_cs" + i].ToString(),
                        Context.Request["beizhu_cs" + i].ToString(),
                        Context.Request["id_cs" + i].ToString()
                    );
                }

                Response.Write("<script>alert('提交成功');</script>");
                this.zl_select_load(sender, e);
            }
        }
    }
}