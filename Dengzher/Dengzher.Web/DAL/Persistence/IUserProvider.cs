using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dengzher.Common;
using Dengzher.Web.Models;

namespace Dengzher.Web.DAL.Persistence
{
    public interface IUserProvider:IProvider<UserModels>
    {
        //
        UserModels GetByPhone(string phone);
        void DeleteByPhone(string phone);
        void UpdateByPhone(string phone,UserModels newUser);
        void ChangePassword(string phone,string newPwd);
        bool UpdatePosition(string phone,int positionId);
    }
}