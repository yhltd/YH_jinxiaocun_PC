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
using System.IO;
using Web.jxc_service;
using Web.Server;

namespace Web
{
    public partial class tuihuomingxi : System.Web.UI.Page
    {
        private static ServicePage page = new ServicePage();
        private static yh_jinxiaocun_user user;
        private Boolean xiayiye = false;

        private String kstime88;
        private String jstime88;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
                return;
            }

            if (user.AdminIS.Equals("false"))
            {
                Response.Redirect("~/wqx.aspx");
                return;
            }

            try
            {
                if (!IsPostBack)
                {
                    // 从Session恢复查询条件
                    if (Session["ks_riqi"] != null)
                    {
                        kstime88 = Session["ks_riqi"].ToString();
                        jstime88 = Session["js_riqi"].ToString();
                    }

                    // 初始化分页
                    Session["ming_xi_select_dd"] = null;
                    page.countPage = this.getCountPage();

                    List<yh_jinxiaocun_tuihuomingxi> list = Session["ming_xi_select_dd"] as List<yh_jinxiaocun_tuihuomingxi>;
                    if (list == null)
                    {
                        this.ming_xi_select(user.gongsi);
                    }

                    if (Convert.ToInt32(Session["dq_ye_mx_dd"]) == 0)
                    {
                        Session["dq_ye_mx_dd"] = 0;
                    }

                    lblCurrentPage.Text = page.nowPage.ToString();
                }
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }

        //protected void toExcel(object sender, EventArgs e)
        //{

        //    List<yh_jinxiaocun_tuihuomingxi> list = ri_qi_select(Context.Request["time_qs"].ToString(), Context.Request["time_jz"].ToString(), Context.Request["order_number"].ToString(), user.gongsi);
        //    if (list != null)
        //    {
        //        StringWriter sw = new StringWriter();

        //        sw.WriteLine("订单号\t商品代码\t商品名称\t商品类别\t价格\t数量\t明细类型\t时间\t公司名\t收货方");

        //        foreach (yh_jinxiaocun_tuihuomingxi mingxi in list)
        //        {

        //            sw.WriteLine(mingxi.orderid + "\t" + mingxi.sp_dm + "\t" + mingxi.cpname + "\t" + mingxi.cplb + "\t" + mingxi.cpsj + "\t" + mingxi.cpsl + "\t" + mingxi.mxtype + "\t'" + mingxi.shijian + "\t" + mingxi.gs_name + "\t" + mingxi.shou_h);

        //        }

        //        sw.Close();

        //        Response.AddHeader("Content-Disposition", "attachment; filename=明细.xls");

        //        Response.ContentType = "application/ms-excel";

        //        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

        //        Response.Write(sw);

        //        Response.End();
        //    }
        //    else
        //    {
        //        Response.Write(" <script>alert('保存失败'); location='ming_xi.aspx';</script>");
        //    }

        //}
        protected void bt_select_Click(object sender, EventArgs e)
        {

            try
            {
                page.nowPage = 1;
                ming_xi_select(user.gongsi);
            }
            catch
            {
                Session["ming_xi_select_dd"] = null;
            }
        }

        protected void shuaxin()
        {

            try
            {
                page.nowPage = 1;
                ming_xi_select(user.gongsi);
            }
            catch
            {
                Session["ming_xi_select_dd"] = null;
            }
        }

        public int getCountPage()
        {
            TuiHuomxModel mingxi = new TuiHuomxModel();
            // 传递日期参数
            int allCount = mingxi.getPageCount(user.gongsi, kstime88, jstime88);
            return (int)Math.Ceiling(Convert.ToDouble((float)allCount / (float)page.pageCount));
        }

        public void ming_xi_select(string gs_name)
        {
            Session["ming_xi_select_dd"] = null;
            TuiHuomxModel buiness = new TuiHuomxModel();

            // 获取查询条件（从Session）
            string time_qs = kstime88;
            string time_jz = jstime88;
            string order_number = Session["order_number"] as string ?? "";
            string cangku = Session["cangku"] as string ?? "";
            string shou_h = Session["shou_h"] as string ?? "";

            // 直接调用 TuiHuomxModel 的方法
            Session["ming_xi_select_dd"] = buiness.ri_qi_select(
                time_qs ?? "1999-01-01",
                time_jz ?? "2999-12-31",
                order_number,
                cangku,
                shou_h,
                gs_name
            );
        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {
            kstime88 = Context.Request["time_qs"].ToString();
            jstime88 = Context.Request["time_jz"].ToString();
            if (page.nowPage == 1)
            {
                Response.Write("<script>alert('已经是第一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage = 1;
                this.ming_xi_select(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            kstime88 = Context.Request["time_qs"].ToString();
            jstime88 = Context.Request["time_jz"].ToString();
            if (page.nowPage == 1)
            {
                Response.Write("<script>alert('已经是第一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage--;
                this.ming_xi_select(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            kstime88 = Context.Request["time_qs"].ToString();
            jstime88 = Context.Request["time_jz"].ToString();
            if (page.countPage < (page.nowPage + 1))
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage++;
                this.ming_xi_select(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }

        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            kstime88 = Context.Request["time_qs"].ToString();
            jstime88 = Context.Request["time_jz"].ToString();
            if (page.nowPage == page.countPage)
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage = page.countPage;
                this.ming_xi_select(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }

        protected void rq_select(object sender, EventArgs e)
        {
            try
            {
                Session["ming_xi_select_dd"] = null;

                // 获取所有查询条件
                string time_qs = Context.Request["time_qs"];
                string time_jz = Context.Request["time_jz"];
                string order_number = Context.Request["order_number"];
                string cangku = Context.Request["product_name"]; // 注意：页面中仓库的id是product_name
                string shou_h = Context.Request["return_party"]; // 注意：页面中退货方的id是return_party

                // 保存到Session
                Session["ks_riqi"] = time_qs;
                Session["js_riqi"] = time_jz;
                Session["order_number"] = order_number;
                Session["cangku"] = cangku;
                Session["shou_h"] = shou_h;

                kstime88 = time_qs;
                jstime88 = time_jz;

                // 调用查询方法，传递6个参数
                Session["ming_xi_select_dd"] = ri_qi_select(
                    time_qs, 
                    time_jz, 
                    order_number ?? "", 
                    cangku ?? "", 
                    shou_h ?? "", 
                    user.gongsi
                );
            }
            catch (Exception ex)
            {
                return;
            }
        }

        // 修改这个方法，增加参数
        public List<yh_jinxiaocun_tuihuomingxi> ri_qi_select(string time_qs, string time_jz, string order_number, string cangku, string shou_h, string gs_name)
        {
            // 处理空值
            if (string.IsNullOrEmpty(time_qs))
            {
                time_qs = "1999-01-01";
            }
            if (string.IsNullOrEmpty(time_jz))
            {
                time_jz = "2999-12-31";
            }

            TuiHuomxModel mingxi = new TuiHuomxModel();
            // 调用修改后的方法，传递6个参数
            return mingxi.ri_qi_select(time_qs, time_jz, order_number, cangku, shou_h, gs_name);
        }

        protected void del_mingxi(object sender, EventArgs e)
        {
            TuiHuomxModel mingxi = new TuiHuomxModel();
            Boolean result = true;
            bool hasDeleted = false; // 记录是否执行了删除操作
    
            try
            {
                List<yh_jinxiaocun_tuihuomingxi> list = Session["ming_xi_select_dd"] as List<yh_jinxiaocun_tuihuomingxi>;
        
                // 添加安全检查
                if (list == null || list.Count == 0)
                {
                    Response.Write("<script>alert('没有可删除的数据！');</script>");
                    return;
                }

                // 创建一个列表来存储要删除的ID
                List<int> idsToDelete = new List<int>();
        
                // 先收集所有选中的ID
                for (int i = 0; i < list.Count; i++)
                {
                    string checkboxValue = Request["Checkbox_bd" + i];
                    if (!string.IsNullOrEmpty(checkboxValue) && checkboxValue.Trim() != "")
                    {
                        int index;
                        if (int.TryParse(checkboxValue.Trim(), out index) && index == i)
                        {
                            idsToDelete.Add(list[i].id);
                        }
                    }
                }

                // 检查是否有选中的记录
                if (idsToDelete.Count == 0)
                {
                    Response.Write("<script>alert('请先选择要删除的记录！');</script>");
                    return;
                }

                // 批量删除选中的记录
                foreach (int id in idsToDelete)
                {
                    if (mingxi.del_mingxi(id) > 0)
                    {
                        hasDeleted = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }

                if (result && hasDeleted)
                {
                    shuaxin(); // 刷新数据
                    Response.Write("<script>alert('删除成功！');</script>");
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void mx_save(object sender, EventArgs e)
        {
            try
            {
                // 获取当前用户
                yh_jinxiaocun_user user = (yh_jinxiaocun_user)Session["user"];

                if (user == null)
                {
                    Response.Write("<script>alert('请先登录！');</script>");
                    return;
                }

                TuiHuomxModel mingxi = new TuiHuomxModel();

                // 安全地获取shuliang参数
                string aaStr = Context.Request["shuliang"];
                if (string.IsNullOrEmpty(aaStr))
                {
                    Response.Write("<script>alert('参数错误：shuliang为空！');</script>");
                    return;
                }

                int totalRows = 0;
                if (!int.TryParse(aaStr, out totalRows))
                {
                    Response.Write("<script>alert('参数错误：shuliang不是有效数字！');</script>");
                    return;
                }

                List<yh_jinxiaocun_tuihuomingxi> list_gys = new List<yh_jinxiaocun_tuihuomingxi>();

                // 检查是否要标记为已入库
                string isRuKu = Context.Request["isRuKu"] ?? "no";

                // 获取选中的行索引
                string[] selectedRows = Context.Request.Form.GetValues("selected_rows");
                if (selectedRows == null || selectedRows.Length == 0)
                {
                    Response.Write("<script>alert('请先选择要保存的行！');</script>");
                    return;
                }

                // 调试信息
                System.Text.StringBuilder debugInfo = new System.Text.StringBuilder();
                debugInfo.AppendLine("开始保存数据");
                debugInfo.AppendLine("总行数：" + totalRows);
                debugInfo.AppendLine("选中行数：" + selectedRows.Length);
                debugInfo.AppendLine("isRuKu参数值：" + isRuKu);
                debugInfo.AppendLine("选中的行索引：" + string.Join(",", selectedRows));

                // 只处理选中的行
                foreach (string rowIndexStr in selectedRows)
                {
                    int rowIndex;
                    if (!int.TryParse(rowIndexStr, out rowIndex))
                        continue;

                    // 确保行索引在有效范围内
                    if (rowIndex < 0 || rowIndex >= totalRows)
                        continue;

                    yh_jinxiaocun_tuihuomingxi mx = new yh_jinxiaocun_tuihuomingxi();

                    debugInfo.AppendLine("=== 处理选中的第 " + rowIndex + " 行 ===");

                    // 获取id
                    string idStr = Context.Request["id" + rowIndex];
                    debugInfo.AppendLine("id" + rowIndex + " = " + (idStr ?? "null"));
                    if (!string.IsNullOrEmpty(idStr))
                    {
                        int id;
                        if (int.TryParse(idStr, out id))
                        {
                            mx.id = id;
                        }
                    }

                    // 获取其他字段 - 使用正确的字段名
                    mx.orderid = Context.Request["orderid" + rowIndex] ?? "";
                    debugInfo.AppendLine("orderid" + rowIndex + " = " + mx.orderid);

                    mx.sp_dm = Context.Request["sp_dm" + rowIndex] ?? "";
                    debugInfo.AppendLine("sp_dm" + rowIndex + " = " + mx.sp_dm);

                    mx.cpname = Context.Request["cpname" + rowIndex] ?? "";
                    debugInfo.AppendLine("cpname" + rowIndex + " = " + mx.cpname);

                    mx.cplb = Context.Request["cplb" + rowIndex] ?? "";
                    debugInfo.AppendLine("cplb" + rowIndex + " = " + mx.cplb);

                    mx.cpsj = Context.Request["cpsj" + rowIndex] ?? "";
                    debugInfo.AppendLine("cpsj" + rowIndex + " = " + mx.cpsj);

                    mx.cpsl = Context.Request["cpsl" + rowIndex] ?? "";
                    debugInfo.AppendLine("cpsl" + rowIndex + " = " + mx.cpsl);

                    // 注意：这里需要检查HTML中是否有mxtype字段
                    mx.mxtype = Context.Request["mxtype" + rowIndex] ?? "";
                    if (string.IsNullOrEmpty(mx.mxtype))
                    {
                        // 如果获取不到，尝试从Session中获取
                        var ming_xi_select_dd = Session["ming_xi_select_dd"] as List<Web.Server.yh_jinxiaocun_tuihuomingxi>;
                        if (ming_xi_select_dd != null && rowIndex < ming_xi_select_dd.Count)
                        {
                            mx.mxtype = ming_xi_select_dd[rowIndex].mxtype;
                        }
                    }
                    debugInfo.AppendLine("mxtype" + rowIndex + " = " + mx.mxtype);

                    // 获取shou_h字段
                    mx.shou_h = Context.Request["shou_h" + rowIndex] ?? "";
                    debugInfo.AppendLine("shou_h" + rowIndex + " = " + mx.shou_h);

                    // 获取cangku字段
                    mx.cangku = Context.Request["cangku" + rowIndex] ?? "";
                    debugInfo.AppendLine("cangku" + rowIndex + " = " + mx.cangku);

                    // 添加公司名称
                    mx.gs_name = user.gongsi;

                    // 根据用户选择设置ruku字段
                    if (isRuKu == "yes")
                    {
                        mx.ruku = "已入库";
                    }
                    else
                    {
                        mx.ruku = ""; // 空字符串
                    }
                    debugInfo.AppendLine("ruku = " + mx.ruku);

                    // 添加到列表
                    list_gys.Add(mx);
                }

                // 输出调试信息到控制台
                Response.Write("<script>console.log('" + debugInfo.ToString().Replace("'", "\\'").Replace("\r\n", "\\n") + "');</script>");

                // 检查是否有数据
                if (list_gys.Count == 0)
                {
                    Response.Write("<script>alert('没有要保存的数据！');</script>");
                    return;
                }

                // 保存到数据库
                int result = mingxi.update(list_gys);


                // 2. 如果是入库操作，同时添加到采购明细表
                if (isRuKu == "yes")
                {
                    // 转换为 List<yh_jinxiaocun_mingxi>
                    List<yh_jinxiaocun_mingxi> mingxiList = new List<yh_jinxiaocun_mingxi>();

                    foreach (var tuihuoItem in list_gys)
                    {
                        yh_jinxiaocun_mingxi mingxiItem = new yh_jinxiaocun_mingxi()
                        {
                            orderid = tuihuoItem.orderid,
                            sp_dm = tuihuoItem.sp_dm,
                            cpname = tuihuoItem.cpname,
                            cplb = tuihuoItem.cplb,
                            cpsj = tuihuoItem.cpsj,
                            cpsl = tuihuoItem.cpsl,
                            mxtype = "入库", // 固定为"退货入库"
                            shou_h = tuihuoItem.shou_h,
                            cangku = tuihuoItem.cangku,
                            gs_name = user.gongsi,
                            zh_name = user.name ?? "", // 用户名
                            shijian = DateTime.Now,
                        };

                        mingxiList.Add(mingxiItem);
                    }

                    // 调用 addCG 方法
                    MingxiModel mingXiModel = new MingxiModel();
                    int result1 = mingXiModel.addCG(mingxiList);

                    Response.Write("<script>console.log('添加到采购明细表结果: " + result1 + " 条');</script>");
                }



                // 显示相应的提示信息
                if (isRuKu == "yes")
                {
                    Response.Write("<script>alert('保存成功！已标记" + list_gys.Count + "条记录为已入库。');</script>");
                }
                else
                {
                    Response.Write("<script>alert('保存成功！更新了" + list_gys.Count + "条记录。');</script>");
                }

                // 刷新数据
                ming_xi_select(user.gongsi);
            }
            catch (Exception ex)
            {
                // 输出详细的错误信息
                Response.Write("<script>alert('保存失败：" + ex.Message.Replace("'", "\\'") + "');</script>");
                Response.Write("<script>console.error('保存错误：" + ex.Message.Replace("'", "\\'") + "');</script>");
                Response.Write("<script>console.error('堆栈跟踪：" + ex.StackTrace.Replace("'", "\\'").Replace("\r\n", "\\n") + "');</script>");
            }

            // 刷新页面数据
            try
            {
                this.Page_Load(sender, e);
            }
            catch { }
        }



    }
}