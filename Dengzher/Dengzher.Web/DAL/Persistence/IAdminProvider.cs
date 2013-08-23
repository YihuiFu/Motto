using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dengzher.Common;
using Dengzher.Web.Models;

namespace Dengzher.Web.DAL.Persistence
{
    public interface IAdminProvider : IProvider<LogOnModel>
    {
        bool ValidateAdmin(string userName,string pwd,string code);
    }
}