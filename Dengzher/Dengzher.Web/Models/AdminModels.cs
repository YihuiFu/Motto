using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dengzher.Web.Models
{
    public class AdminModel
    {
        public AdminModel()
        {
            this.ID = Guid.NewGuid();
        }
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Display(Name="用户名")]
        [MinLength(6,ErrorMessage="用户名的长度不能少于6个字符！")]
        public string UserName { get; set; }

        [Required]
        [Display(Name="密码")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage="密码长度不能少于6个字符！")]
        public string Password { get; set; }

        [Display(Name="邮箱")]
        [DataType(DataType.EmailAddress,ErrorMessage="邮箱格式不正确！")]
        public string Email { get; set; }

        [Display(Name="手机号码")]
        [DataType(DataType.PhoneNumber,ErrorMessage="手机号码格式不正确！")]
        [StringLength(11,MinimumLength=11,ErrorMessage="手机号码长度不正确！")]
        public string MobilePhone { get; set; }
    }

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住密码?")]
        public bool RememberMe { get; set; }
    }

   
}