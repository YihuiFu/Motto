using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dengzher.Web.Models;
using Dengzher.Web.DAL.Persistence;
using Dengzher.Common;

namespace Dengzher.Web.DAL.Services
{
    public class UserManager : IUserProvider
    {

        #region Useless
        public virtual UserModels GetById(int id)
        {
            return null;
        }
        public virtual void Remove(int id)
        {

        }
        public virtual void Update(int id, UserModels newUser)
        {

        }

        #endregion

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public virtual List<UserModels> GetAll()
        {
            string sqlStr = "select * from m_user";
            List<UserModels> users = new List<UserModels>();
            DataTable dt = SqlSeverProvider.ExecuteQuery(sqlStr);
            UserModels user = null;
            foreach (DataRow row in dt.Rows)
            {
                user = new UserModels
                {
                    mobilePhone = (string)row["u_mobilePhone"],
                    password = (string)row["u_password"],
                    nickName = (string)row["u_nickName"],
                    cityName = (string)(row["u_cityName"] == System.DBNull.Value ?string.Empty: row["u_cityName"]),
                    level = (int)(row["u_level"] == System.DBNull.Value ? "0" : row["u_level"]),
                    userPoint = (int)(row["u_userPoint"] == System.DBNull.Value ? "0" : row["u_userPoint"]),
                    email = (string)(row["u_email"] == System.DBNull.Value ? string.Empty : row["u_email"]),
                    avatar = (string)(row["u_avatar"] == System.DBNull.Value ?string.Empty : row["u_avatar"]),
                    position = (int)(row["u_position"] == System.DBNull.Value ? "-1" : row["u_position"]),
                    positionTime = (DateTime)(row["u_positionTime"] == System.DBNull.Value ? "2013-08-12" : row["u_positionTime"]),
                    registerTime = (DateTime)(row["u_registerTime"] == System.DBNull.Value ? "2013-08-12" : row["u_registerTime"])
                };
                users.Add(user);
            }
            return users;
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="user"></param>
        public virtual void Add(UserModels user)
        {
            string sqlStr = "insert into m_user(u_mobilePhone,u_password,u_nickName) values(@mobilePhone,@password,@nickName)";
            SqlParameter[] parm ={
                                     new SqlParameter("@mobilePhone",user.mobilePhone),
                                     new SqlParameter("@password",user.password),
                                     new SqlParameter("@nickName",user.nickName)
                                };
            var result = SqlSeverProvider.ExecuteNonQuery(sqlStr);
            // 是否返回 true or



        }

        /// <summary>
        /// Update user profile according to mobilePhone
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="newUser"></param>
        public virtual void UpdateByPhone(string phone,UserModels newUser)
        {
            string sqlStr = "update m_user set u_mobilePhone=@mobilePhone,u_password=@password,"
            +"u_nickName=@nickName,u_cityName=@cityName,u_email=@email,u_avatar=@avatar where u_mobilePhone="+phone;
            SqlParameter[] parm ={
                                     new SqlParameter("@mobilePhone",newUser.mobilePhone),
                                     new SqlParameter("@password",newUser.password),
                                     new SqlParameter("@nickName",newUser.nickName),
                                     new SqlParameter("@cityName",newUser.cityName),
                                     new SqlParameter("@email",newUser.email),
                                     new SqlParameter("@avatar",newUser.avatar)
                               };
            var result=SqlSeverProvider.ExecuteNonQuery(sqlStr);
        }

        /// <summary>
        /// Get  user by mobilePhone
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public virtual UserModels GetByPhone(string phone)
        {
            string sqlStr = "select * from m_user where u_mobilePhone=@phone";
            SqlParameter[] parm ={
                                     new SqlParameter("@phone",phone)
                               };
            DataTable dt = SqlSeverProvider.ExecuteQuery(sqlStr);
            UserModels user = null;

            foreach (DataRow row in dt.Rows)
            {
                user = new UserModels
                {
                    mobilePhone = (string)row["u_mobilePhone"],
                    password = (string)row["u_password"],
                    nickName = (string)row["u_nickName"],
                    cityName = (string)(row["u_cityName"] == System.DBNull.Value ? string.Empty : row["u_cityName"]),
                    level = (int)(row["u_level"] == System.DBNull.Value ? "0" : row["u_level"]),
                    userPoint = (int)(row["u_userPoint"] == System.DBNull.Value ? "0" : row["u_userPoint"]),
                    email = (string)(row["u_email"] == System.DBNull.Value ? string.Empty : row["u_email"]),
                    avatar = (string)(row["u_avatar"] == System.DBNull.Value ? string.Empty : row["u_avatar"]),
                    position = (int)(row["u_position"] == System.DBNull.Value ? "-1" : row["u_position"]),
                    positionTime = (DateTime)(row["u_positionTime"] == System.DBNull.Value ? "2013-08-12" : row["u_positionTime"]),
                    registerTime = (DateTime)(row["u_registerTime"] == System.DBNull.Value ? "2013-08-12" : row["u_registerTime"])
                };
            }
            return user;
        }

        /// <summary>
        /// delete user by mobilePhone
        /// </summary>
        /// <param name="phone"></param>
        public virtual void DeleteByPhone(string phone)
        {
            string sqlStr = string.Format("delete from m_user where u_mobilePhone={0}",phone);
            SqlSeverProvider.ExecuteNonQuery(sqlStr);
        }

        /// <summary>
        /// change the password
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="newPwd"></param>
        public virtual void ChangePassword(string phone,string newPwd)
        {
            string sqlStr = string.Format("update m_user set u_password={0} where u_mobilePhone={1}",newPwd,phone);
            var result = SqlSeverProvider.ExecuteNonQuery(sqlStr);
        }

        public virtual bool UpdatePosition(string phone,int positionId)
        {
            string sqlStr = string.Format("update m_user set u_position ={0} where u_mobilePhone='{1}'",positionId,phone);
            var result = SqlSeverProvider.ExecuteNonQuery(sqlStr);
            if (result>0)
            {
                return true;
            }
            return false;

        }

    }
}