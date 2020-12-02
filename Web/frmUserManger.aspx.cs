using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class frmUserManger : System.Web.UI.Page
    {
        SqlConnection sqlcon;
        SqlCommand sqlcom;
        string strCon = "Data Source=bds28428944.my3w.com;Database=bds28428944_db;Uid=bds28428944;Pwd=Lyh079101";
        List<clsuserinfo> userlist_Server;
        public string alterinfo;
        int RowRemark = 0;
        int cloumn = 0;
        List<clsuserinfo> Result_Server;
        private SortableBindingList<clsuserinfo> sortablePendingOrderList;

        protected void Page_Load(object sender, EventArgs e)
        {
            //bind();
            InitialSystemInfo();
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

        //绑定
        public void bind()
        {
            string sqlstr = "select * from emw_user";
            sqlcon = new SqlConnection(strCon);
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlcon);
            DataSet myds = new DataSet();
            sqlcon.Open();
            myda.Fill(myds, "emw_user");
            gvList.DataSource = myds;
            //gvList.DataKeyNames = new string[] { "id" };//主键
            gvList.DataBind();
            sqlcon.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            alterinfo = "124";

            userlist_Server = new List<clsuserinfo>();
            clsuserinfo item = new clsuserinfo();

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                alterinfo = "请填写完整信息然后创建！";
                return;
            }
            if (textBox2.Text.Trim() != textBox3.Text.Trim())
            {
                alterinfo = "两次输入的用户密码不一致，请重新输入！";

                return;
            }
            item.name = textBox1.Text.Trim();
            item.password = textBox2.Text.Trim();
            if (this.radioButton1.Checked == true)
                item.Btype = "Normal";
            else if (this.radioButton2.Checked == true)
                item.Btype = "lock";
            if (checkBox1.Checked == true)
                item.AdminIS = "true";
            else
                item.AdminIS = "false";

            item.jigoudaima = this.comboBox1.Text.Trim();
            item.mibao = this.textBox4.Text.Trim();

            item.Createdate = DateTime.Now.ToString("yyyy/MM/dd/HH");

            userlist_Server.Add(item);
            clsAllnew BusinessHelp = new clsAllnew();
            string findup_name = "";

            findup_name = item.jigoudaima;


            while (true)
            {
                List<clsuserinfo> Finduserlist_Server = new List<clsuserinfo>();
                string strSelect = "select * from _user where name='" + findup_name + "'";

                Finduserlist_Server = BusinessHelp.findUser(strSelect.Trim());

                //绑定上级
                if (Finduserlist_Server.Count > 0)
                {
                    Finduserlist_Server[0].xiajilist = Finduserlist_Server[0].xiajilist + " " + item.name;

                    //更新上级信息
                    string conditions = "update _user set  " + " xiajilist ='" + Finduserlist_Server[0].xiajilist + "'" + " where _id = " + Finduserlist_Server[0].Order_id + " ";

                    BusinessHelp.Update_User_Server(conditions);

                    findup_name = Finduserlist_Server[0].jigoudaima;
                }
                else
                    break;


            }


            BusinessHelp.createUser_Server(userlist_Server);
            alterinfo = "创建用户成功！";

            InitialSystemInfo();

        }
        private void InitialSystemInfo()
        {
            clsAllnew BusinessHelp = new clsAllnew();
            clsuserinfo user = (clsuserinfo)Session["user"];
            Result_Server = new List<clsuserinfo>();

            Result_Server = BusinessHelp.ReadUserlistfromServer(user.gongsi);
            this.gvList.AutoGenerateColumns = false;
            sortablePendingOrderList = new SortableBindingList<clsuserinfo>(Result_Server);
            this.gvList.DataSource = sortablePendingOrderList;
            this.gvList.DataBind();
        }
        protected void button2_Click(object sender, EventArgs e)
        {

        }
        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_Operation")
            {
                int RowRemark = Convert.ToInt32(e.CommandArgument);

                string QiHao = gvList.Rows[RowRemark].Cells[1].Text.ToString();
                clsAllnew BusinessHelp = new clsAllnew();

                BusinessHelp.deleteUSER(QiHao);
                InitialSystemInfo();
            }
        }



    }
}