using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dengzher.Web.DAL.Persistence;
using Dengzher.Common;

namespace Dengzher.Web.DAL.Services
{
    public class AdminManager
    {
        private IAdminProvider adminProvider{get;set;}
        public AdminManager(IAdminProvider provider)
        {
            this.adminProvider=provider;
        }
        public virtual bool ValidateAdmin(string userName, string Pwd, string code)
        {
            return adminProvider.ValidateAdmin(userName,Pwd,code);
           
            //AdminProvider.get()
        }

       
        
        
    }
}