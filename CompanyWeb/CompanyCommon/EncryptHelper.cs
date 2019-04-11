using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CompanyCommon
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public class EncryptHelper
    {
        #region MD5加密
        /// <summary>     
        /// MD5加密     
        /// </summary>     
        /// <param name="strSource">需要加密的字符串</param>     
        /// <returns>MD5加密后的字符串</returns>     
        public static string Encrypt(string strSource)
        {
            //把字符串放到byte数组中     
            byte[] bytIn = System.Text.Encoding.Default.GetBytes(strSource);
            //建立加密对象的密钥和偏移量             
            byte[] iv = { 102, 16, 93, 156, 78, 4, 218, 32 };//定义偏移量     
            byte[] key = { 55, 103, 246, 79, 36, 99, 167, 3 };//定义密钥     
            //实例DES加密类     
            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.Key = iv;
            mobjCryptoService.IV = key;
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            //实例MemoryStream流加密密文件     
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            return System.Convert.ToBase64String(ms.ToArray());
        }
        #endregion

    }
}