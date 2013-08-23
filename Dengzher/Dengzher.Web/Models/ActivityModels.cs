using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dengzher.Web.Models
{
    public class ActivityModels
    {
        public int activityID { get; set; }

        public string activityTitle { get; set; }

        public string activityContent { get; set; }

        public string activityImage { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }
    }
}