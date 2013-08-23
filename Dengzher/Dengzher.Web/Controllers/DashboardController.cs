using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dengzher.Web.Models;
using Dengzher.Common;
using Dengzher.Web.DAL.Services;
using Dengzher.Web.DAL.Persistence;

namespace Dengzher.Web.Controllers
{
    public class DashboardController : Controller
    {
        public  BrandManager _BrandManager { get;private  set; }
        public DashboardController()
        {
            this._BrandManager = new BrandManager();
        }
       
        public ActionResult Index()
        {

            var brands = _BrandManager.GetAll();
           
            return View(brands);
            
        }

        public ActionResult Edit()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("id", 100);
            dic.Add("name", "hello");
            return Json(dic, JsonRequestBehavior.AllowGet); 
        }

    }
}
