using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dengzher.Web.Models;
using Dengzher.Web.DAL.Persistence;
using Dengzher.Web.DAL.Services;

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

        //------------------------------------------------------------------
        //
        //修改头像
        //---------------------------------------

    }
}
