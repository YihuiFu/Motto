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
        public ActionResult GetToilets()
        {
            if (string.IsNullOrEmpty(ControllerContext.HttpContext.Request.QueryString["TradeAreaID"]))
                return null;
            if (string.IsNullOrEmpty(ControllerContext.HttpContext.Request.QueryString["FloorNum"]))
                return null;
            int tradeAreaID, floorNum;
            if (!int.TryParse(ControllerContext.HttpContext.Request.QueryString["TradeAreaID"], out tradeAreaID))
                return null;
            if (!int.TryParse(ControllerContext.HttpContext.Request.QueryString["FloorNum"], out floorNum))
                return null;
            List<AreaModels> area = AreaManager.Instance.GetToilets(tradeAreaID, floorNum);
            return new NetJsonResult(area);
        }

        public ActionResult GetLifts()
        {
            if (string.IsNullOrEmpty(ControllerContext.HttpContext.Request.QueryString["TradeAreaID"]))
                return null;
            if (string.IsNullOrEmpty(ControllerContext.HttpContext.Request.QueryString["FloorNum"]))
                return null;
            int tradeAreaID, floorNum;
            if (!int.TryParse(ControllerContext.HttpContext.Request.QueryString["TradeAreaID"], out tradeAreaID))
                return null;
            if (!int.TryParse(ControllerContext.HttpContext.Request.QueryString["FloorNum"], out floorNum))
                return null;
            dynamic lifts = AreaManager.Instance.GetLifts(tradeAreaID, floorNum);
            return new NetJsonResult(lifts);
        }

    }
}
