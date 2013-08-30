using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dengzher.Web.Models;
using Dengzher.Web.DAL.Persistence;
using Dengzher.Web.DAL.Services;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Dengzher.Web.Areas.Api.Controllers
{
    public class UserController : Controller
    {
        private UserManager _UserManager { get; set; }
        public UserController()
        {
            this._UserManager = new UserManager();
        }

        public ActionResult Register(UserModels user)
        {
            _UserManager.Add(user);
            return Json("success！",JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login(string phone)
        {
            UserModels user = _UserManager.GetByPhone(phone);
            return Json(user,JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult ChangePassword(string phone,string newPwd)
        {
            _UserManager.ChangePassword(phone,newPwd);
            return Json("success",JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateProfile(string phone,UserModels newUser)
        {
            _UserManager.UpdateByPhone(phone,newUser);
            return Json("success",JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsersNearby()
        {
            int tradeAreaId = 0;
            if (string.IsNullOrEmpty(ControllerContext.HttpContext.Request.QueryString["TradeAreaId"]))
                return null;
            tradeAreaId = int.Parse(ControllerContext.HttpContext.Request.QueryString["TradeAreaId"]);
            List<UserModels> users = _UserManager.GetUserNearby(tradeAreaId);
            var jsonObject = new JArray();
            var jsonEle = new JObject() as dynamic;
            foreach(UserModels user in users)
            {
                jsonEle.mobilePhone = user.mobilePhone;
                jsonEle.nickName = user.nickName;
                jsonEle.avatar = user.avatar;
                jsonEle.positionTime = user.positionTime;
                jsonEle.floorNum = int.Parse(user.password);
                jsonObject.Add(jsonEle);
            }
            return new NetJsonResult(jsonObject);
        }

        //------------------------------------------------------------------
        //
        //修改头像
        //---------------------------------------

    }
}
