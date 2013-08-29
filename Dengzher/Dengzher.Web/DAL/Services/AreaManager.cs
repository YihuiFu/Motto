using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Dengzher.Web.Models;
using Dengzher.Common;

namespace Dengzher.Web.DAL.Services
{
    public class AreaManager : Persistence.IAreaProvider
    {
        private static AreaManager _instance;
        public static AreaManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AreaManager();
                return _instance;
            }
        }

        //Method of IProvider
        public virtual List<AreaModels> GetAll()
        {
            string sqlString = "select * from m_area";
            List<AreaModels> areas = new List<AreaModels>();
            AreaModels area = null;
            DataTable tab = SqlSeverProvider.ExecuteQuery(sqlString);
            foreach (DataRow row in tab.Rows)
            {
                area = new AreaModels
                {
                    AreaKeyID = (int)row["a_allAreaKeyId"],
                    TradeAreaID = (int)row["a_tradeAreaId"],
                    TradeAreaFloor = (int)row["a_tradeAreaFloor"],
                    AradID = (int)row["a_areaId"],
                    Category = (int)row["a_areaCategory"],
                    StartX = (float)row["a_startX"],
                    StartY = (float)row["a_startY"],
                    Width = (float)row["a_width"],
                    Height = (float)row["a_height"],
                    IsMark = (bool)row["a_isMark"]
                };
                areas.Add(area);
            }
            return areas;
        }

        public virtual AreaModels GetById(int ID)
        {
            string sqlString = "select * from m_area where a_allAreaKeyId = " + ID;
            SqlDataReader reader = SqlSeverProvider.ExecuteReader(sqlString);
            AreaModels area = null;
            if (reader.Read())
            {
                area = new AreaModels
                {
                    AreaKeyID = (int)reader["a_allAreaKeyId"],
                    TradeAreaID = (int)reader["a_tradeAreaId"],
                    TradeAreaFloor = (int)reader["a_tradeAreaFloor"],
                    Category = (int)reader["a_areaCategory"],
                    AradID = (int)reader["a_areaId"],
                    StartX = (float)reader["a_startX"],
                    StartY = (float)reader["a_startY"],
                    Width = (float)reader["a_width"],
                    Height = (float)reader["a_height"],
                    IsMark = (bool)reader["a_isMark"]
                };
            }
            return area;
        }

        public virtual void Add(AreaModels area)
        {
            int ismark = 0;
            if (area.IsMark == true) ismark = 1;
            string sqlString = string.Format("insert into m_area values({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                area.TradeAreaID, area.TradeAreaFloor, area.AradID, area.Category, area.StartX, area.StartY,
                area.Width, area.Height, ismark);
            SqlSeverProvider.ExecuteNonQuery(sqlString);
        }

        public virtual void Update(int ID, AreaModels area)
        {
            int ismark = 0;
            if (area.IsMark == true) ismark = 1;
            string sqlString = string.Format("update m_area set a_tradeAreaId={0},a_tradeAreaFloor={1},a_areaId={2}," +
                "a_areaCategory={3},a_startX={4},a_startY={5},a_width={6},a_height={7},a_isMark={8}" +
                " where a_allAreaKeyId={9}",
                area.TradeAreaID,
                area.TradeAreaFloor,
                area.AradID,
                area.Category,
                area.StartX,
                area.StartY,
                area.Width,
                area.Height,
                ismark,
                ID);
            SqlSeverProvider.ExecuteNonQuery(sqlString);
        }

        public virtual void Remove(int ID)
        {
            string sqlString = "delete from m_area where a_allAreaKeyId=" + ID;
            SqlSeverProvider.ExecuteNonQuery(sqlString);
        }

        //Method of IAreaProvider

        //根据商圈楼层获取洗手间
        public virtual List<AreaModels> GetToilets(int TradeAreaID, int FloorNum)
        {
            string sqlString = "dbo.dz_Area_GetToilets";
            SqlParameter[] parm = { new SqlParameter("@TradeAreaId",TradeAreaID),
                                  new SqlParameter("@FloorNum",FloorNum)};
            List<AreaModels> toilets = new List<AreaModels>();
            SqlDataReader reader = SqlSeverProvider.ExecuteReader(sqlString, CommandType.StoredProcedure, parm);
            while (reader.Read())
            {
                float a = float.Parse(reader["a_startX"].ToString());
                toilets.Add(new AreaModels
                {
                    AreaKeyID = (int)reader["a_allAreaKeyId"],
                    TradeAreaID = (int)reader["a_tradeAreaId"],
                    TradeAreaFloor = (int)reader["a_tradeAreaFloor"],
                    Category = (int)reader["a_areaCategory"],
                    AradID = (int)reader["a_areaId"],
                    StartX = float.Parse(reader["a_startX"].ToString()),
                    StartY = float.Parse(reader["a_startY"].ToString()),
                    Width = float.Parse(reader["a_width"].ToString()),
                    Height = float.Parse(reader["a_height"].ToString()),
                    IsMark = (bool)reader["a_isMark"]
                });
            }
            reader.Close();
            return toilets;
        }

        //根据商圈楼层获取电梯扶梯
        public virtual List<AreaModels> GetLifts(int TradeAreaID, int FloorNum)
        {
            string sqlString = "dbo.dz_Area_GetLift";
            SqlParameter[] parm = { new SqlParameter("@TradeAreaId",TradeAreaID),
                                  new SqlParameter("@FloorNum",FloorNum)};
            List<AreaModels> lifts = new List<AreaModels>();
            SqlDataReader reader = SqlSeverProvider.ExecuteReader(sqlString, CommandType.StoredProcedure, parm);
            while (reader.Read())
            {
                lifts.Add(new AreaModels
                {
                    AreaKeyID = (int)reader["a_allAreaKeyId"],
                    TradeAreaID = (int)reader["a_tradeAreaId"],
                    TradeAreaFloor = (int)reader["a_tradeAreaFloor"],
                    Category = (int)reader["a_areaCategory"],
                    AradID = (int)reader["a_areaId"],
                    StartX = float.Parse(reader["a_startX"].ToString()),
                    StartY = float.Parse(reader["a_startY"].ToString()),
                    Width = float.Parse(reader["a_width"].ToString()),
                    Height = float.Parse(reader["a_height"].ToString()),
                    IsMark = (bool)reader["a_isMark"]
                });
            }
            reader.Close();
            return lifts;
        }
    }
}