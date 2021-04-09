using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.scheduling.utils
{
    public class RsaUtil
    {
        private const string MY_TOKEN = "yhocn/scheduling";


        /// <summary> 
        /// 加密
        /// </summary> 
        public static string RSAEncryption(string express)
        {

            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
            param.KeyContainerName = MY_TOKEN;
            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
            {
                byte[] plaindata = System.Text.Encoding.Default.GetBytes(express);
                byte[] encryptdata = rsa.Encrypt(plaindata, false);
                return Convert.ToBase64String(encryptdata);
            }
        }

        /// <summary> 
        /// 解密
        /// </summary> 
        public static string RSADecrypt(string ciphertext)
        {
            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
            param.KeyContainerName = MY_TOKEN;
            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(ciphertext);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return System.Text.Encoding.Default.GetString(decryptdata);
            }
        }
    }
}