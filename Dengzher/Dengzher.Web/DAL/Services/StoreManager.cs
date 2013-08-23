using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dengzher.Web.Models;
using Dengzher.Web.DAL.Persistence;
using Dengzher.Web.DAL.Services;
using Dengzher.Common;

namespace Dengzher.Web.DAL.Services
{
    public class StoreManager : IStoreProvider
    {
        private ActivityManager _ActivityManager = new ActivityManager();

        #region -- 查看所有商铺
        public virtual List<StoreModels> GetAll()
        {
            string sqlStr = "select * from m_store";
            DataTable dt = SqlSeverProvider.ExecuteQuery(sqlStr);
            List<StoreModels> listStores = new List<StoreModels>();
            StoreModels store = null;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    store = new StoreModels
                    {
                        storeID = (int)row["s_storeId"],
                        areaKeyID = (int)row["s_areaKeyId"],
                        storeCName = (string)(row["s_storeCName"] == DBNull.Value ? string.Empty : row["s_storeCName"]),
                        storeEName = (string)(row["s_storeEName"] == DBNull.Value ? string.Empty : row["s_storeEName"]),
                        brandsID = (int)row["s_brandsId"],
                        address = (string)(row["s_address"] == DBNull.Value ? string.Empty : row["s_address"]),
                        phoneNumber = (string)(row["s_phoneNumber"] == DBNull.Value ? string.Empty : row["s_phoneNumber"]),
                        arrivalNum = (int)row["s_arrivalNum"],
                        logo = (string)(row["s_logo"] == DBNull.Value ? string.Empty : row["s_logo"]),
                        categoryID=(int)row["s_categoryId"]
                    };
                    listStores.Add(store);
                }
                return listStores;
            }
            return null;
        } 
        #endregion

        #region -- 根据商铺ID获取商铺信息
        public virtual StoreModels GetById(int id)
        {
            string sqlStr = "select * from m_store where s_storeId='" + id + "'";
            SqlDataReader dr = SqlSeverProvider.ExecuteReader(sqlStr);
            StoreModels store = null;
            if (dr.Read())
            {
                store = new StoreModels
                {
                    storeID = dr.GetInt32(0),
                    areaKeyID = dr.GetInt32(1),
                    storeCName = dr.GetString(2),
                    storeEName = dr.GetString(3),
                    categoryID=dr.GetInt32(4),
                    logo = dr.GetString(5),
                    brandsID = dr.GetInt32(6),
                    address = dr.GetString(7),
                    phoneNumber = dr.GetString(8),
                    arrivalNum = dr.GetInt32(9)
                    
                };
                dr.Close();
                return store;
            }
            return null;
        } 
        #endregion

        public virtual void Add(StoreModels store)
        {
            string sqlStr = string.Format("insert into m_store values({0},'{1}','{2}',{3},'{4}',{5},'{6}','{7}',{8})",
                                            store.areaKeyID, store.storeCName, store.storeEName,store.categoryID,store.logo, store.brandsID,
                                            store.address, store.phoneNumber, store.arrivalNum);
            SqlSeverProvider.ExecuteNonQuery(sqlStr);
        }

        public virtual void Update(int id, StoreModels newStore)
        {
            string sqlStr = string.Format("update m_store set s_areaKeyId=");
            SqlSeverProvider.ExecuteNonQuery(sqlStr);
        }

        public virtual void Remove(int id)
        {
            string sqlStr = "delete from m_store where s_storeId=" + id + "";
            SqlSeverProvider.ExecuteNonQuery(sqlStr);
        }

        public virtual List<StoreModels> GetStoresByAreaId(int id)
        {
            string sqlStr = "select * from m_store where s_areaKeyId=" + id + "";
            DataTable dt = SqlSeverProvider.ExecuteQuery(sqlStr);
            List<StoreModels> listStores = new List<StoreModels>();
            StoreModels store = null;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    store = new StoreModels
                    {
                        storeID = (int)row["s_storeId"],
                        areaKeyID = (int)row["s_areaKeyId"],
                        storeCName = (string)(row["s_storeCName"] == DBNull.Value ? string.Empty : row["s_storeCName"]),
                        storeEName = (string)(row["s_storeEName"] == DBNull.Value ? string.Empty : row["s_storeEName"]),
                        brandsID = (int)row["s_brandsId"],
                        address = (string)(row["s_address"] == DBNull.Value ? string.Empty : row["s_address"]),
                        phoneNumber = (string)(row["s_phoneNumber"] == DBNull.Value ? string.Empty : row["s_phoneNumber"]),
                        arrivalNum = (int)row["s_arrivalNum"]
                    };
                    listStores.Add(store);
                }
                return listStores;
            }
            return null;
        }

        public virtual List<StoreModels> GetStoresByCategory(string category, int tradeAreaId)
        {
            return null;
        }
        #region --3.分类查询商铺
        /// <summary>
        /// 分类查询商铺
        /// </summary>
        /// <param name="cateID"></param>
        /// <param name="tradeAreaId"></param>
        /// <returns></returns>
        public virtual List<StoreModels> GetStoresByCategory(int cateID, int tradeAreaId)
        {
            string sqlStr = "dbo.dz_Store_GetSpecialStore";
            SqlParameter[] parm = { 
                                      new SqlParameter("@TradeAreaId",tradeAreaId),
                                      new SqlParameter("@CategoryId",cateID)
                                  };
            DataTable dt = SqlSeverProvider.ExecuteQuery(sqlStr, CommandType.StoredProcedure, parm);
            List<StoreModels> listStores = new List<StoreModels>();
            StoreModels store = null;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    store = new StoreModels
                    {
                        storeID = (int)row["s_storeId"],
                        areaKeyID = (int)row["s_areaKeyId"],
                        storeCName = (string)(row["s_storeCName"] == DBNull.Value ? string.Empty : row["s_storeCName"]),
                        storeEName = (string)(row["s_storeEName"] == DBNull.Value ? string.Empty : row["s_storeEName"]),
                        brandsID = (int)row["s_brandsId"],
                        address = (string)(row["s_address"] == DBNull.Value ? string.Empty : row["s_address"]),
                        phoneNumber = (string)(row["s_phoneNumber"] == DBNull.Value ? string.Empty : row["s_phoneNumber"]),
                        arrivalNum = (int)row["s_arrivalNum"]
                    };
                    listStores.Add(store);
                }
                return listStores;
            }
            return null;
        } 
        #endregion

        #region --2.搜索店铺
        public virtual List<StoreModels> GetStoresByName(string name)//店铺查询
        {
            string sqlStr = "select * from m_store where s_storeCName like '%" + name + "%' or s_storeEName like '%" + name + "%' ";
            DataTable dt = SqlSeverProvider.ExecuteQuery(sqlStr);
            List<StoreModels> listStores = new List<StoreModels>();
            StoreModels store = null;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    store = new StoreModels
                    {
                        storeID = (int)row["s_storeId"],
                        areaKeyID = (int)row["s_areaKeyId"],
                        storeCName = (string)(row["s_storeCName"] == DBNull.Value ? string.Empty : row["s_storeCName"]),
                        storeEName = (string)(row["s_storeEName"] == DBNull.Value ? string.Empty : row["s_storeEName"]),
                        brandsID = (int)row["s_brandsId"],
                        address = (string)(row["s_address"] == DBNull.Value ? string.Empty : row["s_address"]),
                        phoneNumber = (string)(row["s_phoneNumber"] == DBNull.Value ? string.Empty : row["s_phoneNumber"]),
                        arrivalNum = (int)row["s_arrivalNum"]
                    };
                    listStores.Add(store);
                }
                return listStores;
            }
            return null;
        } 
        #endregion

        #region ---1.根据地区获取商铺信息 及活动
        public virtual storeActivity GetByPosition(int tradeAreaId, int floorNum,float mapX,float mapY, float scaling)
        {
            //存储过程名称
            string sqlStr = "dbo.dz_Area_GetStoreByPosition ";
            storeActivity storeAct= null;
            SqlDataReader dr = SqlSeverProvider.ExecuteReader(sqlStr,CommandType.StoredProcedure);
            if (dr.Read())
            {
                storeAct = new storeActivity
                {
                    storeID=dr.GetInt32(0),
                    storeCName=dr.GetString(1),
                    storeEName=dr.GetString(2)
                };
            }
            // 根据 storeId 获取活动信息  添加到 storeAct 后 在返回
            ActivityModels activity = _ActivityManager.GetByStoreId(storeAct.storeID);
            storeAct.activityID = activity.activityID;
            storeAct.activityTitle = activity.activityTitle;
            storeAct.activityContent = activity.activityContent;

            return storeAct;
        }
        #endregion



    }
}