using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Dengzher.Common
{
   public static  class StringExtensions
    {
       /// <summary>
       /// Encrypt the string 
       /// </summary>
       /// <param name="str"></param>
       /// <returns></returns>
       public static string Encrypt(this string str)
       {
           // MD5 Encrypt 1
           //------------------------------------------
           //string strEncrypt = string.Empty;
           //MD5 md5 = MD5.Create();
           //byte[] strByte = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

           //for (int i = 0; i < strByte.Length; i++)
           //{
           //    strEncrypt = strEncrypt + strByte[i].ToString("X");
           //}
           //return strEncrypt;

           // MD5 Encrypt 2
           //------------------------------------------
           MD5 md5 = new MD5CryptoServiceProvider();
           md5.ComputeHash(Encoding.UTF8.GetBytes(str));
           byte[] result = md5.Hash;
           StringBuilder strBuilder = new StringBuilder();
           for (int i = 0; i < result.Length; i++)
           {
               strBuilder.Append(result[i].ToString());
           }
           return strBuilder.ToString();
       }

       /// <summary>
       /// Validate the E-mail
       /// </summary>
       /// <param name="str"></param>
       /// <returns></returns>
       public static bool IsEmail(this string str)
       {
           return Regex.IsMatch(str,@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
       }

       /// <summary>
       /// Validate the string is the price formate.
       /// </summary>
       /// <param name="str"></param>
       /// <returns></returns>
       public static bool IsPrice(this string str)
       {
           Regex regex = new Regex(@"^(0|([1-9]\d*))(\.\d+)?$");
           return regex.IsMatch(str);
       }

       /// <summary>
       /// Validate the string is the Phone formate.
       /// </summary>
       /// <param name="str"></param>
       /// <returns></returns>
       public static bool IsPhone(this string str)
       {
           return Regex.IsMatch(str, @"^(\d{3,4}-)?\d{6,8}$");
           
       }

    }
}
