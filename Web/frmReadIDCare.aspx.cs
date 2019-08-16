using China_System.Common;
using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

namespace Web
{
    public partial class frmReadIDCare : System.Web.UI.Page
    {
        public string alterinfo;
        List<clCard_info> readCards;
        public string user;
        public string pass;
        private SortableBindingList<clCard_info> sortablePendingOrderList;
        object ddd;
        public string Show_infomation;
        bool ischeck_zhengjianhaoma = true;
        clsAllnew BusinessHelp;
        private string servename;
        List<clt_Item_info> t_Item_info;

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = Request.Form["idResult"];
            if (Session["servename"] != null)
                servename = Session["servename"].ToString();
            HttpCookie cookie1 = Request.Cookies["MyCook"];

            if (cookie1 != null && cookie1["servename"].ToString() != "")
            {
                string dsdd = cookie1["servename"].ToString();
                //Response.Write("cookie=" + cookie1["servename"].ToString());
            }

            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    if (Cache["servename"] != null)
                    {
                        comboBox1.Text = Cache["servename"].ToString();
                        pass = "123456";
                        // Response.Write(Cache["servename"] + "这里是从缓存中读取的时间");//这里读取的缓存中的时间，刷新页面时，这里的随着时间变化，不会变化。
                    }
                    string dengluleibie = Request.QueryString["dengluleibie"];
                    if (dengluleibie == "nologin")
                    {

                    }
                    BusinessHelp = new clsAllnew();
                    BusinessHelp.rev_servename = servename;
                    if (BusinessHelp.ConStr == null || BusinessHelp.ConStr == null)
                        Response.Redirect("~/Myadmin/login.aspx");

                }
                bind();
            }
            //gvList.HeaderStyle.Wrap = false;//表头不允许换行  
            //gvList.RowStyle.Wrap = false;//表内容不允许换行 
            //  Button1.Attributes.Add("onclick", "chkData()");
            ischeck_zhengjianhaoma = true;
            if (this.hidden1.Value == "1")
            {
                ischeck_zhengjianhaoma = false;
                this.MyGo();
            }
            if (IsPostBack)
                bind();
        }
        public class SortableBindingList<T> : BindingList<T>
        {
            private bool isSortedCore = true;
            private ListSortDirection sortDirectionCore = ListSortDirection.Ascending;
            private PropertyDescriptor sortPropertyCore = null;
            private string defaultSortItem;

            public SortableBindingList() : base() { }

            public SortableBindingList(IList<T> list) : base(list) { }

            protected override bool SupportsSortingCore
            {
                get { return true; }
            }

            protected override bool SupportsSearchingCore
            {
                get { return true; }
            }

            protected override bool IsSortedCore
            {
                get { return isSortedCore; }
            }

            protected override ListSortDirection SortDirectionCore
            {
                get { return sortDirectionCore; }
            }

            protected override PropertyDescriptor SortPropertyCore
            {
                get { return sortPropertyCore; }
            }

            protected override int FindCore(PropertyDescriptor prop, object key)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (Equals(prop.GetValue(this[i]), key)) return i;
                }
                return -1;
            }

            protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
            {
                isSortedCore = true;
                sortPropertyCore = prop;
                sortDirectionCore = direction;
                Sort();
            }

            protected override void RemoveSortCore()
            {
                if (isSortedCore)
                {
                    isSortedCore = false;
                    sortPropertyCore = null;
                    sortDirectionCore = ListSortDirection.Ascending;
                    Sort();
                }
            }

            public string DefaultSortItem
            {
                get { return defaultSortItem; }
                set
                {
                    if (defaultSortItem != value)
                    {
                        defaultSortItem = value;
                        Sort();
                    }
                }
            }

            private void Sort()
            {
                List<T> list = (this.Items as List<T>);
                list.Sort(CompareCore);
                ResetBindings();
            }

            private int CompareCore(T o1, T o2)
            {
                int ret = 0;
                if (SortPropertyCore != null)
                {
                    ret = CompareValue(SortPropertyCore.GetValue(o1), SortPropertyCore.GetValue(o2), SortPropertyCore.PropertyType);
                }
                if (ret == 0 && DefaultSortItem != null)
                {
                    PropertyInfo property = typeof(T).GetProperty(DefaultSortItem, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase, null, null, new Type[0], null);
                    if (property != null)
                    {
                        ret = CompareValue(property.GetValue(o1, null), property.GetValue(o2, null), property.PropertyType);
                    }
                }
                if (SortDirectionCore == ListSortDirection.Descending) ret = -ret;
                return ret;
            }

            private static int CompareValue(object o1, object o2, Type type)
            {
                if (o1 == null) return o2 == null ? 0 : -1;
                else if (o2 == null) return 1;
                else if (type.IsPrimitive || type.IsEnum) return Convert.ToDouble(o1).CompareTo(Convert.ToDouble(o2));
                else if (type == typeof(DateTime)) return Convert.ToDateTime(o1).CompareTo(o2);
                else return String.Compare(o1.ToString().Trim(), o2.ToString().Trim());
            }
        }

        public void bind()
        {

            //gvList.DataSource = readCards;

            //gvList.DataBind();
            btReadcard_server_Click(null, EventArgs.Empty);
            InitialSystemInfo();
        }
        public string clear_bind()
        {

            //gvList.DataSource = readCards;

            //gvList.DataBind();
            readCards = new List<clCard_info>();

            InitialSystemInfo();

            this.txrearchID.Text = "";
            this.txrearchNAME.Text = "";

            return "ok";

        }
        public static string ajaxclear_bind()
        {
            List<clCard_info> readCards = new List<clCard_info>();

            //this.gvList.AutoGenerateColumns = false;
            //sortablePendingOrderList = new SortableBindingList<clCard_info>(readCards);
            ////this.bindingSource1.DataSource = sortablePendingOrderList;
            //this.gvList.DataSource = sortablePendingOrderList;
            //gvList.DataKeyNames = new string[] { "Order_id" };//主键
            // this.gvList.DataBind();
            //Show_infomation = "共计 " + sortablePendingOrderList.Count() + " 条";



            return "ok";


        }

        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_Operation")
            {
                int RowRemark = Convert.ToInt32(e.CommandArgument);
                if (RowRemark >= 0)
                {
                    //string QiHao = gvList.Rows[RowRemark].Cells[1].Text.ToString();
                    BusinessHelp = new clsAllnew();
                    BusinessHelp.rev_servename = servename;
                    gohome();

                    string QiHao = gvList.DataKeys[RowRemark].Value.ToString();
                    string sql2 = "delete from t_Item_3002 where   FItemID='" + QiHao + "'";

                    //BusinessHelp.Readt_PICServer(sql2);
                    BusinessHelp.deleteCard(sql2);

                    //删 t_Item

                    sql2 = "delete from t_Item where   FItemID='" + QiHao + "'";

                    BusinessHelp.deleteCard(sql2);



                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功')</script>");
                    btReadcard_server_Click(null, EventArgs.Empty);

                    InitialSystemInfo();


                }
            }
            else if (e.CommandName == "Btn_View")
            {
                int RowRemark = Convert.ToInt32(e.CommandArgument);
                if (RowRemark >= 0)
                {
                    BusinessHelp = new clsAllnew();
                    BusinessHelp.rev_servename = servename;
                    gohome();
                    string QiHao = gvList.DataKeys[RowRemark].Value.ToString();
                    string sql2 = "select * from t_Accessory where   FItemID='" + QiHao + "'";

                    List<clCard_info> readCards = BusinessHelp.Readt_PICServer(sql2);

                    Response.Redirect("~/ViewImage.aspx?QiHao=" + QiHao);



                }

            }
        }

        private void gohome()
        {
            if (BusinessHelp.ConStr == null || BusinessHelp.ConStr == null)
                Response.Redirect("~/Myadmin/login.aspx");
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvList.EditIndex = e.NewEditIndex;
            //使编辑的行是当前操作的行   editIndex:编辑行的索引  newEditIndex:所编辑的行的索引
            bind();

        }
        //protected void GridView1_RowCancelUpdating(object sender, GridViewEditEventArgs e)
        //{
        //    this.gvList.EditIndex = -1;
        //    //使编辑的行是当前操作的行   editIndex:编辑行的索引  newEditIndex:所编辑的行的索引
        //    bind();

        //}
        //取消
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvList.EditIndex = -1;
            bind();
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Attributes.Add("style", "height:43px Width:43px");
            if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == DataControlRowState.Alternate || e.Row.RowState == DataControlRowState.Edit)
            {
                TextBox curText;
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Controls.Count != 0)
                    {
                        curText = e.Row.Cells[i].Controls[0] as TextBox;
                        if (curText != null)
                        {
                            curText.Width = Unit.Pixel(10);
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //鼠标经过时，行背景色变

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffd800'");

                //鼠标移出时，行背景色变

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

            }
        }
        protected void GridView_Pue_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // if (!IsPostBack)
            {
                BusinessHelp = new clsAllnew();
                BusinessHelp.rev_servename = servename;
                gohome();

                List<clCard_info> AddreadCards = new List<clCard_info>();
                clCard_info item = new clCard_info();


                item.daima_gonghao = ((TextBox)(gvList.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim();
                item.mingcheng = ((TextBox)(gvList.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
                item.xingbie = ((TextBox)(gvList.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();

                if (item.xingbie == "男")
                    item.xingbie = "990113";
                else if (item.xingbie == "女")
                    item.xingbie = "990112";


                item.minzu = ((TextBox)(gvList.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
                item.chushengriqi = ((TextBox)(gvList.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
                item.zhengjianleixing = ((TextBox)(gvList.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();
                item.zhengjianhaoma = ((TextBox)(gvList.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
                item.jiatingzhuzhi = ((TextBox)(gvList.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();
                item.zhengjianyouxiao = ((TextBox)(gvList.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim();
                item.jiguan = ((TextBox)(gvList.Rows[e.RowIndex].Cells[10].Controls[0])).Text.ToString().Trim();

                item.Order_id = gvList.DataKeys[e.RowIndex].Values[0].ToString();
                AddreadCards.Add(item);

                BusinessHelp.changeCardServer(AddreadCards);

                gvList.EditIndex = -1;
                bind();
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            // 演示ToolTip，使用GridView自带的ToolTip
            for (int i = 0; i < gvList.Rows.Count; i++)
            {
                if (gvList.Rows[i].Cells[3].Text == "990112")
                    gvList.Rows[i].Cells[3].Text = "男";
                else if (gvList.Rows[i].Cells[3].Text == "990113")
                    gvList.Rows[i].Cells[3].Text = "女";

                gvList.Rows[i].Cells[8].ToolTip = gvList.Rows[i].Cells[8].Text;
                if (gvList.Rows[i].Cells[8].Text.Length > 4)
                    gvList.Rows[i].Cells[8].Text = gvList.Rows[i].Cells[8].Text.Substring(0, 4) + "...";
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string newaddno;
            int FItemID;
            Confirm_newCardNO(out newaddno, out FItemID);

            //bs


            //cs
            //readCards = BusinessHelp.Read_card();

            //if (results != null && results.Count > 0)
            //    readCards = readCards.Concat(results).ToList();

            WriteInput(newaddno, FItemID);
        }

        private void Confirm_newCardNO(out string newaddno, out int FItemID)
        {
            btReadcard_server_Click(null, EventArgs.Empty);

            BusinessHelp = new clsAllnew();
            BusinessHelp.rev_servename = servename;
            gohome();

            if (readCards == null)
                readCards = new List<clCard_info>();
            readCards.Sort(new China_System.Common.clsCommHelp.Comp());

            #region 新的员工号
            string qi = DateTime.Now.ToString("yyyyMMddss");

            if (readCards == null || readCards.Count == 0)
            {
                qi = DateTime.Now.ToString("yyyyMMddss");
            }
            else
            {
                //ClaimReport_Server.Sort(new Comp());
                qi = System.Text.RegularExpressions.Regex.Replace(readCards[0].daima_gonghao, @"[^0-9]+", "");

            }

            int a = Convert.ToInt32(qi) + 1;
            newaddno = readCards[0].daima_gonghao.Replace(qi, "") + a.ToString();
            readCards.Sort(new China_System.Common.clsCommHelp.Comp1());

            FItemID = Convert.ToInt32(readCards[0].Order_id) + 1;
            #endregion
        }

        private void WriteInput(string newaddno, int FItemID)
        {
            if (readCards != null)
            {
                readCards[0].daima_gonghao = newaddno;
                readCards[0].Order_id = FItemID.ToString();
                if (ischeck_zhengjianhaoma == true)
                {
                    bool isdouble = CHECK_zhengjianhaoma(BusinessHelp);
                    if (isdouble == false)
                    {
                        btwrite_Click(null, EventArgs.Empty);

                        bind();
                    }
                    else
                        return;
                }
                else
                {
                    btwrite_Click(null, EventArgs.Empty);
                    bind();
                }
            }
        }
        private void InitialSystemInfo()
        {
            if (readCards == null)
                readCards = new List<clCard_info>();

            this.gvList.AutoGenerateColumns = false;
            sortablePendingOrderList = new SortableBindingList<clCard_info>(readCards);
            //this.bindingSource1.DataSource = sortablePendingOrderList;
            this.gvList.DataSource = sortablePendingOrderList;
            gvList.DataKeyNames = new string[] { "Order_id" };//主键
            this.gvList.DataBind();
            Show_infomation = "共计 " + sortablePendingOrderList.Count() + " 条";
        }

        protected void btwrite_Click(object sender, EventArgs e)
        {
            BusinessHelp = new clsAllnew();
            BusinessHelp.rev_servename = servename;
            gohome();
            if (readCards != null && readCards.Count > 0)
            {
                string sql2 = "delete from t_Item_3002 where   F_104='" + readCards[0].zhengjianhaoma + "'";

                BusinessHelp.deleteCard(sql2);
            }
            BusinessHelp.createICcard_info_Server(readCards);

            //更新 t_Item
            if (readCards != null && readCards.Count > 0)
            {
                string sql2 = "delete from t_Item where   FItemID='" + readCards[0].FItemID + "'";

                BusinessHelp.deleteCard(sql2);
            }
            t_Item_info = new List<clt_Item_info>();
            #region MyRegion
            clt_Item_info item = new clt_Item_info();
            item.FItemID = readCards[0].FItemID;
            item.FItemClassID = "3002";
            item.FExternID = "-1";
            item.FNumber = readCards[0].daima_gonghao;
            item.FParentID = "0";
            item.FLevel = "1";
            item.FDetail = "1";
            item.FName = readCards[0].mingcheng;
            item.FUnUsed = "0";
            item.FBrNo = "0";
            item.FFullNumber = readCards[0].daima_gonghao;
            item.FDiff = "0";
            item.FDeleted = "0";
            item.FShortNumber = readCards[0].daima_gonghao;
            item.FFullName = readCards[0].mingcheng;
            //item.UUID = readCards[0].FItemID;
            item.FGRCommonID = "-1";
            item.FSystemType = "1";
            item.FUseSign = "0";
            //item.FChkUserID = readCards[0].FItemID;
            item.FAccessory = "0";
            item.FGrControl = "-1";
            item.FModifyTime = DateTime.Now;
            item.FHavePicture = "1";

            #endregion

            t_Item_info.Add(item);


            BusinessHelp.create_t_Item_info_Server(t_Item_info);






            //更新图片
            if (readCards != null && readCards.Count > 0)
            {
                string sql2 = "delete from t_Accessory where   FItemID='" + readCards[0].Order_id + "'";

                BusinessHelp.deleteCard(sql2);
            }
            readCards[0].FTypeID = "3002";

            BusinessHelp.createPIC_info_Server(readCards);


            alterinfo = "添加用户成功！";
        }

        private bool CHECK_zhengjianhaoma(clsAllnew BusinessHelp)
        {
            bool isdouble = false;

            string conditions = "select * from t_Item_3002  where   F_104='" + readCards[0].zhengjianhaoma + "'";//成功

            List<clCard_info> FindreadCards = BusinessHelp.Readt_ItemServer(conditions);
            if (FindreadCards.Count > 0)
            {
                ///   Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('证件号号已存在')</script>");
                //Button1.Attributes.Add("onclick", "chkData()");
                //ShowConfirm("123", "", "");
                // Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>if(confirm('确认添加？'))alert('点击了确定');else alert('点击了取消')</script>");

                //Response.Write("<script>confirm('aaaaaaaaa')</script>");

                string msg = "检测第" + readCards[0].zhengjianhaoma.ToString() + " 数据已存在,是否覆盖?'";
                this.ClientScript.RegisterStartupScript(this.GetType(), msg, "<script>MyConfirm();</script>");
                isdouble = true;
            }
            return isdouble;
        }
        private void MyGo()
        {
            Button1_Click(null, EventArgs.Empty);
            this.hidden1.Value = "2";

        }
        private void CreateITEM_CARD_Server(clsAllnew BusinessHelp)
        {

        }
        public static void ShowConfirm(string strMsg, string strUrl_Yes, string strUrl_No)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) { window.location.href='" + strUrl_Yes +
            "' } else {window.location.href='" + strUrl_No + "' };</script>");
        }
        protected void btReadcard_server_Click(object sender, EventArgs e)
        {
            BusinessHelp = new clsAllnew();
            BusinessHelp.rev_servename = servename;
            gohome();
            readCards = new List<clCard_info>();
            string conditions = "select * from t_Item_3002";//成功

            readCards = BusinessHelp.Readt_ItemServer(conditions);

            InitialSystemInfo();
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            clear_bind();
        }

        void toExcel(GridView gv)
        {
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

            //string fileName = "export.xls";
            string fileName = "System  Info" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string style = @"<style> .text { mso-number-format:\@; } </script> ";
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Write(style);
            Response.Write(sw.ToString());
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        protected void toExcel(object sender, EventArgs e)
        {
            //bind();
            //toExcel(gvList);
            Response.Clear();
            string fileName = "System  Info" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";

            Response.AddHeader("content-disposition",

            "attachment;filename=" + fileName);

            Response.Charset = "";

            // If you want the option to open the Excel file without saving than

            // comment out the line below

            // Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.ContentType = "application/vnd.xlsx";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);

            // turn off paging 
            gvList.AllowPaging = false;
            bind();


            gvList.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());

            Response.End();

            // turn the paging on again 
            gvList.AllowPaging = true;
            bind();

        }
        [System.Web.Services.WebMethod()]
        public static string GetRankedUserDept(string mingcheng, string minzu, string xingbie, string chushengriqi, string jiatingzhuzhi, string zhengjianhaoma, string zhengjianyouxiao, string FData, string FDataF, string idResult)//, , string idResultDesc1
        {
            inputlog("");
            inputlog1("");

            try
            {
                string aainputAll = "名称" + mingcheng + "\r\n民族" + minzu + "\r\n性别" + xingbie + "\r\n出生日期" + chushengriqi + "\r\n家庭住址" + jiatingzhuzhi + "\r\n证件号码" + zhengjianhaoma + "\r\n证件有效" + zhengjianyouxiao + "\r\n image64" + FData + "\r\n image64F" + FDataF + "\r\n result" + idResult;
                if (idResult == "失败" || mingcheng == "" || mingcheng == null || minzu == "" || minzu == null)
                {
                    return "读卡失败,请确认设备连接正常或将身份证拿起重新放入设备！";

                }


                string aainput = "";
                aainputAll += "\r\n";

                inputlog(aainputAll + "s1");

                //确认是否重复
                List<clCard_info> resulits = new List<clCard_info>();
                collect_data(mingcheng, minzu, xingbie, chushengriqi, jiatingzhuzhi, zhengjianhaoma, zhengjianyouxiao, FData, FDataF, resulits);
                inputlog(aainputAll + "s2");

                #region 假数据
                //resulits = new List<clCard_info>();

                //   resulits = jiashuju();

                #endregion

                bool isdou = CHECK_zhengjianhaoma1(resulits);
                if (isdou == true)
                {
                    string msg = "检测第" + resulits[0].zhengjianhaoma.Trim().ToString() + " 数据已存在'";

                    return msg;
                }
                inputlog(aainputAll + "s3");

                string newaddno;
                int FItemID;
                //确认新的号码
                Confirm_newCardNO_(out newaddno, out FItemID);
                inputlog(aainputAll + "s4");

                string strResult = string.Empty;

                //重新整理数据
                //resulits = new List<clCard_info>();
                //collect_data(mingcheng, minzu, xingbie, chushengriqi, jiatingzhuzhi, zhengjianhaoma, zhengjianyouxiao, FData, resulits);

                strResult = "读取成功";
                //写入数据
                if (resulits != null && resulits.Count > 0 && resulits[0].mingcheng != null && resulits[0].mingcheng != "")
                {
                    aainput += aainputAll + "s5";
                    inputlog(aainputAll + "s5");
                    WriteInput1(newaddno, FItemID, resulits, false);
                    inputlog(aainputAll + "s6");
                    aainput += "s6";

                }
                else
                {
                    strResult = "信息缺失无法入库";
                    aainput = aainputAll + strResult;

                }
                aainput += "s7";
                inputlog(aainput);

                strResult = "读取成功";

                return strResult;
            }
            catch (Exception ex)
            {
                inputlog1("001" + ex.Message + "//" + ex + "//" + ex.StackTrace);
                //HttpContext.Current.Response.Write("<script>confirm('001" + ex.ToString() + "')</script>");
                HttpContext.Current.Response.Redirect("~/ErrorPage/ErrorPage.aspx?Error=" + ex.ToString());

                return ex.Message + "//" + ex + "//" + ex.StackTrace;
                throw;
            }
        }

        private static void inputlog(string aainput)
        {
            string A_Path = AppDomain.CurrentDomain.BaseDirectory + "bin\\log.txt";
            if (File.Exists(A_Path))
            {
                StreamWriter sw = new StreamWriter(A_Path);
                sw.WriteLine(aainput);
                sw.Flush();
                sw.Close();
            }
        }
        private static void inputlog1(string aainput)
        {
            string A_Path = AppDomain.CurrentDomain.BaseDirectory + "bin\\log2.txt";
            if (File.Exists(A_Path))
            {
                StreamWriter sw = new StreamWriter(A_Path);
                sw.WriteLine(aainput);
                sw.Flush();
                sw.Close();
            }


        }
        private static List<clCard_info> jiashuju()
        {
            clsAllnew BusinessHelp = new clsAllnew();
            string mdbpath2_Ctirx = AppDomain.CurrentDomain.BaseDirectory + "bin\\cardv.jpg";//记录 Status  click 和选择哪个服务器
            string dirPath = HttpContext.Current.Server.MapPath("bin/cardv.jpg");

            string image64 = "";

            if (Directory.Exists(dirPath))
            {
                inputlog1("002" + dirPath);
                image64 = BusinessHelp.ImgToBase64String(dirPath);
            }

            string A_Path = AppDomain.CurrentDomain.BaseDirectory + "bin\\img.txt";//记录 Status  click 和选择哪个服务器

            string[] fileText = File.ReadAllLines(A_Path);
            for (int i = 0; i < fileText.Length; i++)
            {
                image64 += fileText[i];

            }
            //string m_strPath = Application.StartupPath;

            //Base64ToImage(image64).Save(m_strPath + "\\Hello.jpg");
            //  string mdbpath2_Ctirx = AppDomain.CurrentDomain.BaseDirectory + "\\Hello.jpg";//记录 Status  click 和选择哪个服务器

            //BusinessHelp.Base64ToImage(image64).Save(mdbpath2_Ctirx);


            List<clCard_info> reads1 = new List<clCard_info>();

            clCard_info item = new clCard_info();
            item.daima_gonghao = "d1ll";
            item.zhengjianhaoma = "32012119860802291X";
            item.tupian = item.zhengjianhaoma;
            item.FData = image64;
            item.mingcheng = "刘明川";
            item.minzu = "汉";
            item.xingbie = "1";
            item.xingbie = "990113";//女

            //xingbie = "990112";//男
            item.chushengriqi = "19860802";
            item.jiatingzhuzhi = "南京市江宁区横溪街道西岗社区大吴峰岘29号";

            item.zhengjianyouxiao = "20120503-20220503";

            item.CardType = "1";
            reads1.Add(item);

            return reads1;
        }

        private static void collect_data(string mingcheng, string minzu, string xingbie, string chushengriqi, string jiatingzhuzhi, string zhengjianhaoma, string zhengjianyouxiao, string FData, string FDataF, List<clCard_info> resulits)
        {
            clCard_info item = new clCard_info();
            //姓名
            item.mingcheng = mingcheng.ToString();

            //民族/国家
            item.minzu = minzu.ToString();
            //性别 
            if (xingbie == "1")
                xingbie = "990112";//男
            else
                xingbie = "990113"; //女
            item.xingbie = xingbie.ToString();
            //出生 
            item.chushengriqi = chushengriqi.ToString();

            //地址 
            item.jiatingzhuzhi = jiatingzhuzhi;

            //号码 
            item.zhengjianhaoma = zhengjianhaoma.ToString();

            //有效期 
            item.zhengjianyouxiao = zhengjianyouxiao.ToString();

            //图片

            item.tupian = item.zhengjianhaoma;
            if (FData != null && FData != "")
                item.FData = FData.ToString();

            item.zhengjianleixing = "990119";


            resulits.Add(item);
        }


        private static void Confirm_newCardNO_(out string newaddno, out int FItemID)
        {
            try
            {
                clsAllnew BusinessHelp = new clsAllnew();
                //gohome1();
                List<clCard_info> readCards = new List<clCard_info>();
                string conditions = "select * from t_Item_3002";//成功

                readCards = BusinessHelp.Readt_ItemServer(conditions);

                //InitialSystemInfo();


                //  gohome1();

                if (readCards == null)
                    readCards = new List<clCard_info>();
                readCards.Sort(new China_System.Common.clsCommHelp.Comp());

                #region 新的员工号
                string qi = DateTime.Now.ToString("yyyyMMddss");

                if (readCards == null || readCards.Count == 0)
                {
                    qi = DateTime.Now.ToString("yyyyMMddss");
                }
                else
                {
                    //ClaimReport_Server.Sort(new Comp());
                    qi = System.Text.RegularExpressions.Regex.Replace(readCards[0].daima_gonghao, @"[^0-9]+", "");

                }

                int a = Convert.ToInt32(qi) + 1;
                newaddno = readCards[0].daima_gonghao.Replace(qi, "") + a.ToString();
                readCards.Sort(new China_System.Common.clsCommHelp.Comp1());

                FItemID = Convert.ToInt32(readCards[0].Order_id) + 1;
                #endregion
            }
            catch (Exception ex)
            {
                inputlog1("001" + ex.Message + "//" + ex.ToString() + "//" + ex.StackTrace.ToString());
                HttpContext.Current.Response.Redirect("~/ErrorPage/ErrorPage.aspx?Error=" + ex.ToString());

                //HttpContext.Current.Response.Write("<script>confirm('" + ex.ToString() + "')</script>");
                throw ex;
            }
        }

        private static void gohome1()
        {
            clsAllnew BusinessHelp = new clsAllnew();

            //if (BusinessHelp.ConStr == null || BusinessHelp.ConStr == null)
            //    Response.Redirect("~/Myadmin/login.aspx");
        }
        private static void WriteInput1(string newaddno, int FItemID, List<clCard_info> readCards, bool ischeck_zhengjianhaoma)
        {
            if (readCards != null)
            {
                readCards[0].daima_gonghao = newaddno;
                readCards[0].Order_id = FItemID.ToString();
                if (ischeck_zhengjianhaoma == true)
                {
                    bool isdouble = CHECK_zhengjianhaoma1(readCards);
                    if (isdouble == false)
                    {
                        btwrite_1(readCards);


                        //   bind1();
                    }
                    else
                        return;
                }
                else
                {
                    btwrite_1(readCards);
                    //   bind1();
                }
            }
            else
            {


            }
        }
        private static bool CHECK_zhengjianhaoma1(List<clCard_info> readCards)
        {
            try
            {
                clsAllnew BusinessHelp = new clsAllnew();

                bool isdouble = false;

                string conditions = "select * from t_Item_3002  where   F_104='" + readCards[0].zhengjianhaoma + "'";//成功


                List<clCard_info> FindreadCards = BusinessHelp.Readt_ItemServer(conditions);
                if (FindreadCards.Count > 0)
                {
                    ///   Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('证件号号已存在')</script>");
                    //Button1.Attributes.Add("onclick", "chkData()");
                    //ShowConfirm("123", "", "");
                    // Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>if(confirm('确认添加？'))alert('点击了确定');else alert('点击了取消')</script>");

                    //Response.Write("<script>confirm('aaaaaaaaa')</script>");

                    string msg = "检测第" + readCards[0].zhengjianhaoma.ToString() + " 数据已存在,是否覆盖?'";
                    //  this.ClientScript.RegisterStartupScript(this.GetType(), msg, "<script>MyConfirm();</script>");
                    isdouble = true;
                }
                return isdouble;
            }
            catch (Exception ex)
            {
                inputlog1("003" + ex.Message + "//" + ex.Source + "//" + ex.StackTrace);
                //HttpContext.Current.Response.Write("<script>confirm('003" + ex.ToString() + "')</script>");
                HttpContext.Current.Response.Redirect("~/ErrorPage/ErrorPage.aspx?Error=" + ex.ToString());

                return false;
                throw ex;
            }
        }

        private static void btwrite_1(List<clCard_info> readCards)
        {
            clsAllnew BusinessHelp = new clsAllnew();

            try
            {

                //   gohome();
                if (readCards != null && readCards.Count > 0)
                {
                    string sql2 = "delete from t_Item_3002 where   F_104='" + readCards[0].zhengjianhaoma + "'";

                    BusinessHelp.deleteCard(sql2);
                }
                // readCards[0].chushengriqi = "20120503";

                readCards[0].chushengriqi = clsCommHelp.objToDateTime1(readCards[0].chushengriqi.ToString());
                string[] fileText = System.Text.RegularExpressions.Regex.Split(readCards[0].zhengjianyouxiao, "-");
                if (fileText.Length > 1)
                    readCards[0].zhengjianyouxiao = clsCommHelp.objToDateTime1(fileText[1]);
                else
                    readCards[0].zhengjianyouxiao = clsCommHelp.objToDateTime1(fileText[0]);

                BusinessHelp.createICcard_info_Server(readCards);


                //更新 t_Item
                if (readCards != null && readCards.Count > 0)
                {
                    string sql2 = "delete from t_Item where   FItemID='" + readCards[0].Order_id + "'";

                    BusinessHelp.deleteCard(sql2);
                }
                List<clt_Item_info> t_Item_info = new List<clt_Item_info>();
                #region MyRegion
                clt_Item_info item = new clt_Item_info();
                item.FItemID = readCards[0].Order_id;
                item.FItemClassID = "3002";
                item.FExternID = "-1";
                item.FNumber = readCards[0].daima_gonghao;
                item.FParentID = "0";
                item.FLevel = "1";
                item.FDetail = "1";
                item.FName = readCards[0].mingcheng;
                item.FUnUsed = "0";
                item.FBrNo = "0";
                item.FFullNumber = readCards[0].daima_gonghao;
                item.FDiff = "0";
                item.FDeleted = "0";
                item.FShortNumber = readCards[0].daima_gonghao;
                item.FFullName = readCards[0].mingcheng;
                //item.UUID = readCards[0].FItemID;
                item.FGRCommonID = "-1";
                item.FSystemType = "1";
                item.FUseSign = "0";
                //item.FChkUserID = readCards[0].FItemID;
                item.FAccessory = "0";
                item.FGrControl = "-1";
                //item.FModifyTime = DateTime.Now;
                item.FHavePicture = "1";

                #endregion

                t_Item_info.Add(item);


                BusinessHelp.create_t_Item_info_Server(t_Item_info);

                //更新图片
                if (readCards != null && readCards.Count > 0)
                {
                    string sql2 = "delete from t_Accessory where   FItemID='" + readCards[0].Order_id + "'";

                    BusinessHelp.deleteCard(sql2);
                }
                readCards[0].FTypeID = "3002";

                BusinessHelp.createPIC_info_Server(readCards);


                //alterinfo = "添加用户成功！";

            }
            catch (Exception ex)
            {
                inputlog1("004" + ex.Message + "//" + ex.Source + "//" + ex.StackTrace);
                //HttpContext.Current.Response.Write("<script>confirm('004" + ex.ToString() + "')</script>");
                //HttpContext.Current.Response.Write("Error=" + ex.ToString());
                HttpContext.Current.Response.Redirect("~/ErrorPage/ErrorPage.aspx?Error=" + ex.ToString());

                //return;
                throw ex;
            }
        }

        protected void button2_Click1(object sender, EventArgs e)
        {

        }


        protected void btsearch_Click1(object sender, EventArgs e)
        {
            if (this.txrearchNAME.Text != "" || this.txrearchID.Text != "")
            {
                BusinessHelp = new clsAllnew();
                BusinessHelp.rev_servename = servename;
                gohome();
                readCards = new List<clCard_info>();
                string conditions = "select * from t_Item_3002 where ";//成功

                int DSD = 0;

                if (txrearchNAME.Text.Length > 0)
                {
                    DSD++;
                    conditions += " FName like '%" + txrearchNAME.Text + "%'";
                }
                if (txrearchID.Text.Length > 0 && DSD > 0)
                {
                    conditions += " AND F_104 like '%" + txrearchID.Text + "%'";
                }
                if (txrearchID.Text.Length > 0 && DSD == 0)
                {
                    conditions += "F_104 like '%" + txrearchID.Text + "%'";
                }

                readCards = BusinessHelp.Readt_ItemServer(conditions);

                InitialSystemInfo();
            }
        }


        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //for (int i = 0; i < e.Row.Cells.Count; i++)
            //{
            //    e.Row.Cells[i].Attributes.Add("style", "word-break :keep-all ; word-wrap:keep-all");

            //}

        }


    }
}