using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dengzher.Common;
using Dengzher.Web.Models;

namespace Dengzher.Web.DAL.Persistence
{
    public interface IAreaProvider : IProvider<AreaModels>
    {
        List<AreaModels> GetToilets(int TradeAreaID, int FloorNum);
        List<AreaModels> GetLifts(int TradeAreaID, int FloorNum);
    }
}