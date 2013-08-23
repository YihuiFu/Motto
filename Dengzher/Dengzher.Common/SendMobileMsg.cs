using System;
using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Dengzher.Common
{
   public abstract  class SendMobileMsg
    {
       public static bool Send(string phone,string msgContent)
       {
           try
           {
               bool result = false;
               string strPhone = phone;
               var encoding = System.Text.Encoding.GetEncoding("GB2312");
               string postData = string.Format("uid= foyerry123456&pwd=123456&mobile={0};&msg={1}&dtime=", strPhone, msgContent);
               byte[] data = encoding.GetBytes(postData);
               HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.smsadmin.cn/smsmarketing/wwwroot/api/post_send/");
               myRequest.Method = "POST";
               myRequest.ContentType = "application/x-www-form-urlencoded";
               myRequest.ContentLength = data.Length;
               Stream newStream = myRequest.GetRequestStream();
               newStream.Write(data, 0, data.Length);
               newStream.Close();

               HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
               StreamReader reader = new StreamReader(myResponse.GetResponseStream(), encoding);
               string content = reader.ReadToEnd();
               if (content.Substring(0, 1) == "0")
               {
                   result = true;
               }
               else
               {
                   //if (content.Substring(0,1)=="2")
                   //{
                   //    //余额不足
                   //}
                   //else
                   //{

                   //}
                   result = false;
               }
               return result;

           }
           catch
           {
               return false;
           }
       }
    }
}
