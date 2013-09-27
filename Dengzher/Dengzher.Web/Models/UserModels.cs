using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dengzher.Web.Models
{
    public class UserModels
    {
        [Key]
        public string mobilePhone { get; set; }

        public string password { get; set; }

        public string nickName { get; set; }

        public string cityName { get; set; }//  foreigner key

        public int level { get; set; }

        public int userPoint { get; set; }

        public string email { get; set; }

        public string avatar { get; set; }

        public int position { get; set; } // foreigner key

        public DateTime positionTime { get; set; }

        public DateTime registerTime { get; set; }

        public int testh { get; set; }

        public string hello { get; set; }
    }
    
}