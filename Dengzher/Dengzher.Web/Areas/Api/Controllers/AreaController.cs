using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dengzher.Web.Models;
using Dengzher.Common;
using Dengzher.Web.DAL.Services;
using Dengzher.Web.DAL.Persistence;

namespace Dengzher.Web.Areas.Api.Controllers
{
    public class AreaController : Controller
    {
      

        public ActionResult Index()
        {
            return View();
        }

    }
}
