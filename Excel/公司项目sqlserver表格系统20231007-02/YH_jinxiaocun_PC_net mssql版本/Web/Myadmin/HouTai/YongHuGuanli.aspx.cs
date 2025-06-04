using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using clsBuiness;
using SDZdb;
using Web.Server;
using System.Text;
using System.Security.Cryptography;
namespace Web.Myadmin.HouTai
{
    public partial class YongHuGuanli : System.Web.UI.Page
    {
        protected List<yh_jinxiaocun_user> YongHutable;
        private static yh_jinxiaocun_user user;
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
            
            if (!IsPostBack)
            {
                string act = Request["act"] == null ? "" : Request["act"].ToString();
                if (act.Equals("PostUser"))
                {
                    string id = Request["id"] == null ? "0" : Request["id"].ToString();
                    Response.Write(delete(id));
                    Response.End();
                }
                this.SelectUser();
            }
        }
        //protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        //{
            //string[] a = new string[10];
            //for (int i = 2; i <= 41; i++)
            //{
                //a[i - 2] = GridView1.Rows[GridView1.SelectedIndex].Cells[i + 1].Text;
            //}
            //a[1] = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString();

            //Session["b"] = a[39];
            //Session["year"] = a[0];
            //Session["moth"] = a[1];
            //Session["name"] = a[2];
            //Server.Transfer("../Personnel/kaoqinUpd.aspx");
        //}
        public int delete(string id)
        {
            string msg = string.Empty;
            UserModel s = new UserModel();
            int result = 0;
            try
            {
                result = s.delete(id);
            }
            catch
            {
                result = -1;
            }
            return result;
        }


        /// <summary>
        /// Aes加解密钥必须32位
        /// </summary>
        public static string AesKey
        {
            get
            {
                return "20230916IsMaimes"; // 此处可自定义，32个字符长度
            }
        }
 
        /// <summary>
        /// 获取Aes32位密钥
        /// </summary>
        /// <param name="key">Aes密钥字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>Aes32位密钥</returns>
        static byte[] GetAesKey(string key, Encoding encoding)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", "Aes密钥不能为空");
            }
            if (key.Length < 32)
            {
                // 不足32补全
                key = key.PadRight(32, '0');
            }
            if (key.Length > 32)
            {
                key = key.Substring(0, 32);
            }
            return encoding.GetBytes(key);
        }
 
        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>加密后的字符串</returns>
        [System.Web.Services.WebMethod]
        public static string EncryptAes(string source)
        {
            return EncryptAes(source, AesKey);
        }
 
        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="key">aes密钥，长度必须32位</param>
        /// <param name="model">运算模式</param>
        /// <param name="padding">填充模式</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>加密后的字符串</returns>
        public static string EncryptAes(string source, string key, CipherMode model = CipherMode.ECB, 
        PaddingMode padding = PaddingMode.PKCS7, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
 
            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
            {
                aesProvider.Key = GetAesKey(key, encoding);
                aesProvider.Mode = model;
                aesProvider.Padding = padding;
                using (ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor())
                {
                    byte[] inputBuffers = encoding.GetBytes(source),
                        results = cryptoTransform.TransformFinalBlock(inputBuffers, 0, inputBuffers.Length);
                    aesProvider.Clear();
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
 
        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>解密后的字符串</returns>
        [System.Web.Services.WebMethod]
        public static string DecryptAes(string source)
        {
            return DecryptAes(source, AesKey);
        }
 
        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="key">aes密钥，长度必须32位</param>
        /// <param name="model">运算模式</param>
        /// <param name="padding">填充模式</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>解密后的字符串</returns>
        public static string DecryptAes(string source, string key, CipherMode model = CipherMode.ECB, 
        PaddingMode padding = PaddingMode.PKCS7, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
 
            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
            {
                aesProvider.Key = GetAesKey(key, encoding);
                aesProvider.Mode = model;
                aesProvider.Padding = padding;
                using (ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor())
                {
                    source = source.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
                    if (source.Length % 4 > 0)
                    {
                        source = source.PadRight(source.Length + 4 - source.Length % 4, '=');
                    }
                    byte[] inputBuffers = Convert.FromBase64String(source);
                    byte[] results = cryptoTransform.TransformFinalBlock(inputBuffers, 0, inputBuffers.Length);
                    aesProvider.Clear();
                    return encoding.GetString(results);
                }
            }
        }

        /// <summary>
        /// 将一个byte数组转换成一个格式化的16进制字符串
        /// </summary>
        /// <param name="data">byte数组</param>
        /// <returns>格式化的16进制字符串</returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            }
            return sb.ToString().ToUpper();
        }


        private void SelectUser()
        {
            UserModel s = new UserModel();
            UserFor.DataSource = s.getList(user.gongsi);
            UserFor.DataBind();
        }
        protected void BTN_UP_Click(object sender, EventArgs e)
        {
            Server.Transfer("../InsertUser.aspx");
        }
        protected void BTN_ShuaXing_Click(object sender, EventArgs e)
        {
            try
            {
                SelectUser();
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }
    }
}