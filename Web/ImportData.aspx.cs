using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class ImportData : System.Web.UI.Page
    {

        List<clt_POS_info> KEYResult;
        public string alterinfo;

        private SortableBindingList<clt_POS_info> sortablePendingOrderList;

        clsAllnew BusinessHelp = new clsAllnew();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                FileUpload1.Style.Add("display", "none");

                gvList.Attributes.Add("style", "table-layout:fixed");
                bind();

            }


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


        protected void UploadButton_Click(object sender, EventArgs e)
        {

            string fileName1 = txrearchID.Text;
            //  // 设置文件保存目录
            //string appPath = Request.PhysicalApplicationPath + @"Uploads\";
            //if (!System.IO.Directory.Exists(appPath)) System.IO.Directory.CreateDirectory(appPath);

            if (fileName1.Length > 0)
            {
                String fileName = FileUpload1.FileName;
                //string savePath = appPath + Server.HtmlEncode(FileUpload1.FileName);    // 生成保存路径
                //   FileUpload1.SaveAs(savePath);  // 保存文件

                KEYResult = BusinessHelp.HandingChargeKEY(fileName1);
                BusinessHelp.createPOS_Server(KEYResult);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上传成功！')</script>");
                alterinfo = "共计成功上传：" + KEYResult.Count;



            }
            else
            {
                txrearchID.Text = "";
            }

        }

        protected void vcButton_Click(object sender, EventArgs e)
        {

        }

        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_Operation")
            {
                int RowRemark = Convert.ToInt32(e.CommandArgument);
                if (RowRemark >= 0)
                {
                    ////string QiHao = gvList.Rows[RowRemark].Cells[1].Text.ToString();
                    //BusinessHelp = new clsAllnew();
                    //BusinessHelp.rev_servename = servename;
                    //gohome();

                    //string QiHao = gvList.DataKeys[RowRemark].Value.ToString();
                    //string sql2 = "delete from t_Item_3002 where   FItemID='" + QiHao + "'";

                    ////BusinessHelp.Readt_PICServer(sql2);
                    //BusinessHelp.deleteCard(sql2);

                    ////删 t_Item

                    //sql2 = "delete from t_Item where   FItemID='" + QiHao + "'";

                    //BusinessHelp.deleteCard(sql2);



                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功')</script>");
                    //btReadcard_server_Click(null, EventArgs.Empty);

                    //InitialSystemInfo();


                }
            }
            else if (e.CommandName == "Btn_View")
            {
                int RowRemark = Convert.ToInt32(e.CommandArgument);
                if (RowRemark >= 0)
                {
                    //BusinessHelp = new clsAllnew();
                    //BusinessHelp.rev_servename = servename;
                    //gohome();
                    //string QiHao = gvList.DataKeys[RowRemark].Value.ToString();
                    //string sql2 = "select * from t_Accessory where   FItemID='" + QiHao + "'";

                    //List<clCard_info> readCards = BusinessHelp.Readt_PICServer(sql2);

                    //Response.Redirect("~/ViewImage.aspx?QiHao=" + QiHao);



                }

            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvList.EditIndex = e.NewEditIndex;
            //使编辑的行是当前操作的行   editIndex:编辑行的索引  newEditIndex:所编辑的行的索引
            bind();

        }
        public void bind()
        {

            //gvList.DataSource = readCards;

            //gvList.DataBind();
            btReadcard_server_Click(null, EventArgs.Empty);
            InitialSystemInfo();
        }
        private void InitialSystemInfo()
        {
            if (KEYResult == null)
                KEYResult = new List<clt_POS_info>();

            this.gvList.AutoGenerateColumns = false;
            sortablePendingOrderList = new SortableBindingList<clt_POS_info>(KEYResult);

            this.gvList.DataSource = sortablePendingOrderList;
            gvList.DataKeyNames = new string[] { "Order_id" };//主键
            this.gvList.DataBind();
            alterinfo = "共计 " + sortablePendingOrderList.Count() + " 条";
        }
        protected void btReadcard_server_Click(object sender, EventArgs e)
        {
            BusinessHelp = new clsAllnew();

            KEYResult = new List<clt_POS_info>();
            string conditions = "select * from pos_detail";//成功
            KEYResult = BusinessHelp.ReadPOSServer(conditions);


            InitialSystemInfo();
        }

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
                //BusinessHelp.rev_servename = servename;
                //gohome();

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

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //for (int i = 0; i < e.Row.Cells.Count; i++)
            //{
            //    e.Row.Cells[i].Attributes.Add("style", "word-break :keep-all ; word-wrap:keep-all");

            //}

        }

    }
}