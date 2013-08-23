using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dengzher.Common;
using Dengzher.Web.Models;

namespace Dengzher.Web.DAL.Persistence
{
    public interface  IStoreProvider : IProvider<StoreModels>
    {
        List<StoreModels> GetStoresByAreaId(int id);
        List<StoreModels> GetStoresByName(string name);//店铺查询
        List<StoreModels> GetStoresByCategory(string category,int tradeAreaId);
        storeActivity GetByPosition(int tradeAreaId, int floorNum, float mapX, float mapY, float scaling);
       
       
    }
}