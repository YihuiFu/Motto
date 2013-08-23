using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dengzher.Web.Models
{
    public class StoreModels
    {
        public int storeID { get; set; }

        public string storeCName { get; set; }

        public string storeEName { get; set; }

        public string address { get; set; }

        public string phoneNumber { get; set; }

        public string logo { get; set; }

        public int arrivalNum { get; set; }

        public int areaKeyID { get; set; }

        public int brandsID { get; set; }

        public int categoryID { get; set; }


    }

    public class storeActivity
    {
        public int storeID { get; set; }

        public string storeCName { get; set; }

        public string storeEName { get; set; }

        public int activityID { get; set; }

        public string activityTitle { get; set; }

        public string activityContent { get; set; }
    }
}