using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dengzher.Web.Models;
using Dengzher.Common;
using Dengzher.Web.DAL.Services;


namespace Dengzher.Web.Controllers
{
    public class HomeController : Controller
    {
        private AdminManager _AdminManager { get; set; }
        public HomeController(AdminManager adminManager)
        {
            this._AdminManager = adminManager;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LogOnModel logon)
        {
            if (ModelState.IsValid)
            {
                _AdminManager.ValidateAdmin(logon.UserName,logon.Password,"12");
            }
            return View();
        }

        public ActionResult About()
        {
            string hello = "hello ,i am just test git";
            return View();
        }


        public ActionResult test()
        {
            var num = 6788;
            return Json(num,JsonRequestBehavior.AllowGet);
        }

      
    }
}
