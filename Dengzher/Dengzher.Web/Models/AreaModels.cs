using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dengzher.Web.Models
{
    public class AreaModels
    {
        public int AreaKeyID { get; set; }

        [Required]
        [Display(Name = "商圈编号")]
        public int TradeAreaID { get; set; }

        [Required]
        [Display(Name = "楼层号")]
        public int TradeAreaFloor { get; set; }

        [Required]
        [Display(Name = "区域标号")]
        public int AradID { get; set; }

        [Required]
        [Display(Name = "类别")]
        public int Category { get; set; }

        [Required]
        [Display(Name = "起始X坐标")]
        public float StartX { get; set; }

        [Required]
        [Display(Name = "起始Y坐标")]
        public float StartY { get; set; }

        [Required]
        [Display(Name = "区域宽度")]
        public float Width { get; set; }

        [Required]
        [Display(Name = "区域高度")]
        public float Height { get; set; }

        public bool IsMark { get; set; }
    }
}