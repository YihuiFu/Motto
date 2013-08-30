using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dengzher.Web.Models
{
    public class TradeAreaModels
    {
        public int TradeAreaID { get; set; }

        [Display(Name="省份")]
        public int TradeAreaProvince { get; set; }

        [Display(Name="城市")]
        public int TradeAreaCity { get; set; }

        [Display(Name="城市")]
        public string TradeAreaCityName { get; set; }

        [Required]
        [Display(Name="商圈名")]
        public string TradeAreaName { get; set; }

        [Display(Name="商圈地址")]
        public string TradeAreaAddress { get; set; }

        [Required]
        [Display(Name="楼层数")]
        public int FloorCount { get; set; }

        [Required]
        [Display(Name="起始楼层")]
        public int FirstFloor { get; set; }

        [Display(Name="商圈图标")]
        public string TradeAreaLogo { get; set; }
    }
}