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
    public class BrandController : Controller
    {

        private BrandManager _BrandManager { get; set; }
        public BrandController()
        {
            this._BrandManager = new BrandManager();
        }
        // GET: /Api/Brand/

        public ActionResult GetAllBrands()
        {
            List<BrandModels> brands = _BrandManager.GetAll();
            return Json(brands,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Test()
        {
            //return null;

            #region 测试 GetAllBrands 获取所有的品牌 ----成功
            List<BrandModels> brands = _BrandManager.GetAll();
            return Json(brands, JsonRequestBehavior.AllowGet); 
            #endregion
        }
    }
}
