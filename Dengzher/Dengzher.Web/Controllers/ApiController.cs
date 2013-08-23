using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dengzher.Web.Models;
using Dengzher.Common;
using Dengzher.Web.DAL.Services;
using Dengzher.Web.DAL.Persistence;


namespace Dengzher.Web.Controllers
{
    public class ApiController : Controller
    {
        //
        // GET: /Api/
        private BrandManager brandManager = new BrandManager();
        public ActionResult GetAllBrands()
        {
            var result = brandManager.GetAll();
           // List<BrandModels> brands = new List<BrandModels> {
           //    new BrandModels{brandsID=1,chineseName="匹克",englishName="Peak",logo="peak.jpg"},
           //    new BrandModels{brandsID=2,chineseName="耐克",englishName="Nike",logo="Nike.jpg"}
           //};
            
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public ActionResult SendMsg()
        {
            //生成随机验证码
            SendMobileMsg.Send("12","12");
            return null;
            
           // string phone = "18959260874";
           //var result= SendMobileMsg(phone);
           // return Json(result,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Test()
        {
            var result = false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[NonAction]
        //public bool SendMobileMsg(string phone)
        //{
            
        //    try
        //    {
        //        string msgContent = " 你好！测试数据！";
        //        bool result = false;
        //        string strPhone = phone;
        //        var encoding = System.Text.Encoding.GetEncoding("GB2312");
        //        string postData = string.Format("uid= foyerry123456&pwd=123456&mobile={0};&msg={1}&dtime=", strPhone, msgContent);
        //        byte[] data = encoding.GetBytes(postData);
        //        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.smsadmin.cn/smsmarketing/wwwroot/api/post_send/");
        //        myRequest.Method = "POST";
        //        myRequest.ContentType = "application/x-www-form-urlencoded";
        //        myRequest.ContentLength = data.Length;
        //        Stream newStream = myRequest.GetRequestStream();
        //        newStream.Write(data,0,data.Length);
        //        newStream.Close();

        //        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
        //        StreamReader reader = new StreamReader(myResponse.GetResponseStream(), encoding);
        //        string content = reader.ReadToEnd();
        //        if (content.Substring(0,1)=="0")
        //        {
        //            result = true;
        //        }
        //        else
        //        {
        //            //if (content.Substring(0,1)=="2")
        //            //{
        //            //    //余额不足
        //            //}
        //            //else
        //            //{

        //            //}
        //            result = false;
        //        }
        //        return result;
                
        //    }
        //    catch 
        //    {
        //        return false;
        //    }
        //}


        //
        //Login
        //


        /// <summary>
        /// 发送手机注册验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult SendValidateCode()
        {
            var phone = HttpContext.Request["phone"].ToString();
            var code=ValidateCode.GenerateMsgCode();
            string msgContent = "您好！欢迎使用motto！您的注册验证码为："+code;
            var result = SendMobileMsg.Send(phone,msgContent);
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            //插入数据库，保存验证码并向用户发短信，返回验证码
            return null;
        }

        public ActionResult Login()
        {
            //获取用户名 密码 判断是否  返回 yes or not

            return null;
        }

        public ActionResult UpdateProfile()
        {
            return null;
        }

        public ActionResult ChangePassword()
        {
            return null;
        }

        
        [HttpPost]
        public ActionResult GetStoreByPosition()
        {

            return null;
        }


    }
}
