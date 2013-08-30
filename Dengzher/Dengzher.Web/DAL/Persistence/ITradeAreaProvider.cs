using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dengzher.Web.Models;

namespace Dengzher.Web.DAL.Persistence
{
    public interface ITradeAreaProvider:Common.IProvider<TradeAreaModels>
    {
        List<TradeAreaModels> GetTradeAreaByCity(string cityName);
    }
}