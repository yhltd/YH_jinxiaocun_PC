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
    public partial class yejiguanli : System.Web.UI.Page
    {
        clsAllnew BusinessHelp;
        List<clt_POS_info> readCards;
        private SortableBindingList<clt_POS_info> sortablePendingOrderList;
        public string alterinfo;
        public string alterinfo1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }



        protected void btgeren(object sender, EventArgs e)
        {

        }

        protected void bttuan(object sender, EventArgs e)
        {





        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtKeyword.Text != "" || (this.txtCompletionTime.Text != "" && this.txtCompletionTime.Text != ""))
            {
                BusinessHelp = new clsAllnew();

                readCards = new List<clt_POS_info>();
                string conditions = "select * from pos_detail where ";//成功

                int DSD = 0;

                if (txtKeyword.Text.Length > 0)
                {
                    DSD++;
                    conditions += " jiansuocankaohao like '%" + txtKeyword.Text + "%'";
                }
                if (txtCompletionTime.Text.Length > 0 && DSD > 0)
                {
                    conditions += " AND  convert(varchar(10),[jiaoyishijian],120) = '" + txtCompletionTime.Text + "'";

                }
                if (txtCompletionTime.Text.Length > 0 && DSD > 0)
                {
                    conditions += " AND  convert(varchar(10),[jiaoyishijian],120) < '" + txtCompletionTime.Text + "'";

                }
                if (txtCompletionTime.Text.Length > 0 && DSD == 0)
                {

                    if (txtCompletionTime.Text.Length > 0)
                    {
                        conditions += "jiaoyishijian>='" + txtCompletionTime.Text + "'" + "and " + "jiaoyishijian<='" + this.TextBox1.Text + "'";

                    }
                }
                conditions += "AND suoshujigou ='" + "河北佐邦电子商务有限公司" + "'";

                //conditions = "select * from pos_detail where jiaoyishijian>='" + "2019/01/16" + "'" + "and " + "jiaoyishijian<='" + "2019/01/17" + "'";

                readCards = BusinessHelp.ReadPOSServer(conditions);


                double nullableQty = (from s in readCards
                                      where Convert.ToDouble(s.jiaoyijine) > 0
                                      select Convert.ToDouble(s.jiaoyijine)).Sum();

                alterinfo = nullableQty.ToString();

                double nullableQty1 = (from s in readCards
                                       where Convert.ToDouble(s.jiaoyishouxufei) > 0
                                       select Convert.ToDouble(s.jiaoyishouxufei)).Sum();

                alterinfo1 = nullableQty1.ToString();
                txtDocumentNumber.Text = alterinfo;
                txtDocumentDescription.Text = alterinfo1;


                //团体

                #region 团体

                List<clt_POS_info> all_readCards = new List<clt_POS_info>();
                conditions = "select * from pos_detail where ";//成功

                DSD = 0;

                if (txtKeyword.Text.Length > 0)
                {
                    DSD++;
                    conditions += " jiansuocankaohao like '%" + txtKeyword.Text + "%'";
                }
                if (txtCompletionTime.Text.Length > 0 && DSD > 0)
                {
                    conditions += " AND  convert(varchar(10),[jiaoyishijian],120) = '" + txtCompletionTime.Text + "'";

                }
                if (txtCompletionTime.Text.Length > 0 && DSD > 0)
                {
                    conditions += " AND  convert(varchar(10),[jiaoyishijian],120) < '" + txtCompletionTime.Text + "'";

                }
                if (txtCompletionTime.Text.Length > 0 && DSD == 0)
                {
                    if (txtCompletionTime.Text.Length > 0)
                    {
                        conditions += "jiaoyishijian>='" + txtCompletionTime.Text + "'" + "and " + "jiaoyishijian<='" + this.TextBox1.Text + "'";

                    }
                }
                string loginname = "a";


                List<clsuserinfo> Finduserlist_Server = new List<clsuserinfo>();
                string strSelect = "select * from _user where name='" + loginname + "'";

                Finduserlist_Server = BusinessHelp.findUser(strSelect.Trim());
                string[] fileText = System.Text.RegularExpressions.Regex.Split(Finduserlist_Server[0].xiajilist, " ");

                {
                    conditions += "AND (suoshujigou ='" + fileText[0] + "'";
                }


                for (int i = 1; i < fileText.Length; i++)
                {
                    if (fileText[i] != "")
                        conditions += "or suoshujigou ='" + fileText[i] + "'";
                }
                conditions += ")";



                readCards = BusinessHelp.ReadPOSServer(conditions);

                double tl1 = (from s in readCards
                                      where Convert.ToDouble(s.jiaoyijine) > 0
                                      select Convert.ToDouble(s.jiaoyijine)).Sum();

                alterinfo = nullableQty.ToString();

                double tl2 = (from s in readCards
                                       where Convert.ToDouble(s.jiaoyishouxufei) > 0
                                       select Convert.ToDouble(s.jiaoyishouxufei)).Sum();


                TextBox2.Text = tl1.ToString();
                TextBox3.Text = tl2.ToString();


                #endregion





                InitialSystemInfo();
            }
        }
        private void InitialSystemInfo()
        {

            if (readCards == null)
                readCards = new List<clt_POS_info>();

            //this.gvList.AutoGenerateColumns = false;
            //sortablePendingOrderList = new SortableBindingList<clt_POS_info>(readCards);

            //this.gvList.DataSource = sortablePendingOrderList;
            //gvList.DataKeyNames = new string[] { "Order_id" };//主键
            //this.gvList.DataBind();
            //alterinfo = "共计 " + sortablePendingOrderList.Count() + " 条";
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

        protected void btnclearClick(object sender, EventArgs e)
        {
            clear_bind();
        }

        public string clear_bind()
        {

            readCards = new List<clt_POS_info>();

            InitialSystemInfo();

            this.txtKeyword.Text = "";
            this.txtCompletionTime.Text = "";
            this.TextBox1.Text = "";
            alterinfo1 = "";
            alterinfo = "";

            return "ok";

        }
        public void NewsList()
        {
            if (readCards != null)
            {
                foreach (clt_POS_info item in readCards)
                {

                    Response.Write("<tr>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.Order_id + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.shangpinbianhao + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.zhucemingcheng + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.jingyingmingcheng + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.suoshujigou + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.jiaoyileixing + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.jiaoyizhuangtai + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.jiaoyijine + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.jiaoyishouxufei + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.jiaoyifujiashouxufei + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.jiaoyishijian + "</td>" + "");
                    Response.Write("<td nowrap  height='24' align='center'>" + item.jiansuocankaohao + "</td>" + "");


                }
            }

        }




    }
}