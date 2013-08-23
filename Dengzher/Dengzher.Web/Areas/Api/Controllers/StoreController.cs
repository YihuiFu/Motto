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
    public class StoreController : Controller
    {
        private StoreManager _StoreManager { get; set; }
        public StoreController()
        {
            this._StoreManager = new StoreManager();
        }

        #region ---根据位置获取商铺信息 和 商铺活动
        public ActionResult GetStoreByPosition(int tradeAreaId, int floorNum, float mapX, float mapY, float scaling)
        {
            storeActivity storeAct = _StoreManager.GetByPosition(tradeAreaId, floorNum, mapX, mapY, scaling);
            if (storeAct != null)
            {
                return Json(storeAct, JsonRequestBehavior.AllowGet);
            }
            return Json("Failed", JsonRequestBehavior.AllowGet);
        } 
        #endregion
       
        #region --搜索店铺

        /// <summary>
        /// 搜索店铺
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult Search(string name)
        {
            List<StoreModels> stores = _StoreManager.GetStoresByName(name);
            return Json(stores, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        /// <summary>
        /// 分类搜索店铺，如甜品、餐厅
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStoreByCate(string category,int tradeAreaId)
        {
            List<StoreModels> stores = _StoreManager.GetStoresByCategory(category,tradeAreaId);
            return Json(stores,JsonRequestBehavior.AllowGet);
        }


        #region --根据ID获取商铺信息
        public ActionResult GetStoreById(int id)
        {
            StoreModels store = _StoreManager.GetById(id);
            return Json(store, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region --- 测试
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        public ActionResult Test()
        {
           return null;
            #region 测试 Search 搜索查询  ----成功
            //List<StoreModels> stores = _StoreManager.GetStoresByName("维莎");
            //return Json(stores, JsonRequestBehavior.AllowGet); 
            #endregion

            #region 测试  GetStoreById  根据ID 获取商店信息  ----成功
            //StoreModels store = _StoreManager.GetById(1);
            //return Json(store, JsonRequestBehavior.AllowGet); 
            #endregion

        } 
        #endregion

    }
}
