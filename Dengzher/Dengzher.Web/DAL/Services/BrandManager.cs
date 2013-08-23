using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Dengzher.Web.Models;
using Dengzher.Web.DAL.Persistence;
using Dengzher.Common;

namespace Dengzher.Web.DAL.Services
{
    public class BrandManager :IBrandProvider
    {
       //------------------------------------------------------
        //数据库字段 englisgName 改为englishName
        //
        //---------------------------------------------------------
        
        #region Add
        public virtual void Add(BrandModels brand)
        {
            string sqlStr = "insert into m_brands values (@chineseName,@englishName,@logo)";
            SqlParameter[] parm ={
                                     new SqlParameter("@chineseName",brand.chineseName),
                                     new SqlParameter("@englishName",brand.englishName),
                                     new SqlParameter("@logo",brand.logo)
                              };
            var result = SqlSeverProvider.ExecuteNonQuery(sqlStr);
        }
        #endregion

        #region GetById
        public virtual BrandModels GetById(int id)
        {
            string sqlStr = string.Format("select * from m_brands where b_brandsId={0}", id);
            BrandModels brand = null;
            DataTable dt = SqlSeverProvider.ExecuteQuery(sqlStr);
            foreach (DataRow  row in dt.Rows)
            {
                brand = new BrandModels
                {
                    brandsID = (int)row["b_brandsId"],
                    chineseName = (string)(row["b_chineseName"] == System.DBNull.Value ?string.Empty : row["b_chineseName"]),
                    englishName = (string)(row["b_englisgName"] == System.DBNull.Value ? string.Empty : row["b_englisgName"]),
                    logo = (string)(row["b_logo"] == System.DBNull.Value ? string.Empty : row["b_logo"])

                };
            }
            return brand;
        }
        #endregion

        #region GetAll
       public virtual List<BrandModels> GetAll()
        {
            string sqlStr = "select * from m_brands";
            List<BrandModels> brands=new List<BrandModels>();
            DataTable dt = SqlSeverProvider.ExecuteQuery(sqlStr);
            BrandModels brand = null;
            foreach (DataRow row in dt.Rows)
            {
                brand = new BrandModels
                {
                    brandsID = (int)row["b_brandsId"],
                    chineseName = (string)(row["b_chineseName"] == System.DBNull.Value ? string.Empty : row["b_chineseName"]),
                    englishName = (string)(row["b_englisgName"] == System.DBNull.Value ? string.Empty : row["b_englisgName"]),
                    logo = (string)row["b_logo"]
                };
                brands.Add(brand);
            }
            return brands;
           
        }
        #endregion

        #region Remove
        public virtual void Remove(int id)
        {
            string sqlStr = string.Format("delete from m_brands where b_brandsId={0}",id);
            var result = SqlSeverProvider.ExecuteNonQuery(sqlStr);
        }
        #endregion

        #region Update
        public virtual void Update(int id,BrandModels newBrand)
        {
            string sqlStr = string.Format("update m_brands set b_chineseName={0},b_englisgName={1},b_logo={3}",newBrand.chineseName,newBrand.englishName,newBrand.logo);
            var result = SqlSeverProvider.ExecuteNonQuery(sqlStr);
        }
        #endregion

       
        
    }
}