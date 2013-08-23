using System;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dengzher.Web.Models
{
    public class BrandModels
    {
        [Key]
        public int brandsID { get; set; }

        [Required]
        [Display(Name="中文名称")]
        public string chineseName { get; set; }

        [Required]
        [Display(Name="英文名称")]
        public string englishName { get; set; }

        [Display(Name="品牌图片")]
        public string logo { get; set; }
    }
}