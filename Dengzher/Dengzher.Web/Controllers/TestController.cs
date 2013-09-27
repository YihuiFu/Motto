using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dengzher.Web.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult test()
        {
            var second = "这是第二次修改的";
            var result = second;
            return View();
        }

    }
}
