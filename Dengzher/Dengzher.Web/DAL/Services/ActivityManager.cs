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
    public class ActivityManager :IActivityProvider
    {
       
        public virtual void Add(ActivityModels activity)
        { 

        }

        public virtual List<ActivityModels> GetAll()
        {
            return null;
        }

        public virtual ActivityModels GetById(int id)
        {
            return null;
        }

        public virtual void Remove(int id)
        { 

        }

        public virtual void Update(int id,ActivityModels newActivity)
        { 

        }

        public virtual ActivityModels GetByStoreId(int id)
        {
            return null;
        }

    }
}