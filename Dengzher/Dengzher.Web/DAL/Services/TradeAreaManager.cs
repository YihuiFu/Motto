using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using Dengzher.Web.Models;
using Dengzher.Common;

namespace Dengzher.Web.DAL.Services
{
    public class TradeAreaManager:Persistence.ITradeAreaProvider
    {
        private static TradeAreaManager _instance = null;
        public static TradeAreaManager Instance
        {
            get
            {
                if (_instance == null) _instance = new TradeAreaManager();
                return _instance;
            }
        }

        public static TradeAreaModels GetTradeAreaByRow(DataRow row)
        {
            TradeAreaModels trade = new TradeAreaModels();
            trade.TradeAreaID = (int)row["t_tradeAreaId"];
            trade.TradeAreaProvince = (int)row["t_tradeAreaProvince"];
            trade.TradeAreaCity = (int)row["t_tradeAreaCity"];
            trade.TradeAreaCityName = row["t_tradeAreaCityName"].ToString();
            trade.TradeAreaAddress = row["t_tradeAreaAddress"].ToString();
            trade.FloorCount = (int)row["t_floorCount"];
            trade.FirstFloor = (int)row["t_firstFloor"];
            trade.TradeAreaLogo = row["t_tradeAreaLogo"].ToString();
            return trade;
        }

        public static TradeAreaModels GetTradeAreaByReader(System.Data.SqlClient.SqlDataReader reader)
        {
            return new TradeAreaModels
            {
                TradeAreaID = (int)reader["t_tradeAreaId"],
                TradeAreaProvince = (int)reader["t_tradeAreaProvince"],
                TradeAreaCity = (int)reader["t_tradeAreaCity"],
                TradeAreaCityName = reader["t_tradeAreaCityName"].ToString(),
                TradeAreaName = reader["t_tradeAreaName"].ToString(),
                TradeAreaAddress = reader["t_tradeAreaAddress"].ToString(),
                FloorCount = (int)reader["t_floorCount"],
                FirstFloor = (int)reader["t_firstFloor"],
                TradeAreaLogo = reader["t_tradeAreaLogo"].ToString()
            };
        }

        //Methods of IProvider
        public List<TradeAreaModels> GetAll()
        {
            string sqlString = "select * from m_tradeArea";
            List<TradeAreaModels> trades = new List<TradeAreaModels>();
            DataTable tbl = SqlSeverProvider.ExecuteQuery(sqlString);
            if (tbl == null) return null;
            foreach (DataRow row in tbl.Rows)
            {
                trades.Add(TradeAreaManager.GetTradeAreaByRow(row));
            }
            return trades;
        }

        public TradeAreaModels GetById(int id)
        {
            string sqlString = "select * from m_tradeArea where t_tradeAreaId = " + id;
            System.Data.SqlClient.SqlDataReader reader = SqlSeverProvider.ExecuteReader(sqlString);
            TradeAreaModels trade = null;
            if (reader.Read())
                trade = TradeAreaManager.GetTradeAreaByReader(reader);
            return trade;
        }

        public void Add(TradeAreaModels trade)
        {
            string sqlString = string.Format("insert into m_tradeArea values({0},{1},{2},{3},{4},{5},{6},{7}",
                trade.TradeAreaProvince,
                trade.TradeAreaCity,
                "'" + trade.TradeAreaCityName + "'",
                "'" + trade.TradeAreaName + "'",
                "'" + trade.TradeAreaAddress + "'",
                trade.FloorCount,
                trade.FirstFloor,
                "'" + trade.TradeAreaLogo + "')");
            SqlSeverProvider.ExecuteNonQuery(sqlString);
        }

        public void Update(int id, TradeAreaModels trade)
        {
            string sqlString = string.Format("update m_tradeArea set t_tradeAreaProvince={0}, t_tradeAreaCity={1}, t_tradeAreaCityName={2}, " +
                "t_tradeAreaName={3}, t_tradeAreaAddress={4}, t_floorCount={5}, t_firstFloor={6}, t_tradeAreaLogo={7} where t_tradeAreaId={8}",
                trade.TradeAreaProvince,
                trade.TradeAreaCity,
                "'" + trade.TradeAreaCityName + "'",
                "'" + trade.TradeAreaName + "'",
                "'" + trade.TradeAreaAddress + "'",
                trade.FloorCount,
                trade.FirstFloor,
                "'" + trade.TradeAreaLogo + "'",
                id);
            SqlSeverProvider.ExecuteNonQuery(sqlString);
        }

        public void Remove(int id)
        {
            string sqlString = "delete from m_tradeArea where t_tradeAreaId=" + id;
            SqlSeverProvider.ExecuteNonQuery(sqlString);
        }

        //Methods of ITradeAreaProvider

        public List<TradeAreaModels> GetTradeAreaByCity(string cityname)
        {
            string sqlString = "dbo.dz_TradeArea_GetByCityName";
            SqlParameter[] parm = {new SqlParameter("@CityName",cityname) };
            List<TradeAreaModels> trades = new List<TradeAreaModels>();
            SqlDataReader reader = SqlSeverProvider.ExecuteReader(sqlString, CommandType.StoredProcedure, parm);
            while (reader.Read())
            {
                trades.Add(GetTradeAreaByReader(reader));
            }
            return trades;
        }
    }
}