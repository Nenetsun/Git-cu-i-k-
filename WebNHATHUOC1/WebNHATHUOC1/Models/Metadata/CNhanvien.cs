using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNHATHUOC1.Models
{
    public class CNhanvien
    {
        [Required(ErrorMessage = "Hãy nhập mã")]
        [StringLength(12)]
        [Display(Name = "Mã nhân viên")]
        public string manv { get; set; }

        [Required(ErrorMessage = "Hãy nhập họ tên")]
        [StringLength(30)]
        [Display(Name = "Tên nhân viên")]
        public string tennv { get; set; }

        [Required(ErrorMessage = "Hãy nhập số ĐT")]
        [StringLength(12)]
        [Display(Name = "Số điện thoại (10 số)")]
        public string sodt { get; set; }

        [Required(ErrorMessage = "Hãy nhập số CM")]
        [StringLength(12)]
        [Display(Name = "Số CMND (12 số)")]
        public string socm { get; set; }

        [StringLength(150)]
        [Display(Name = "Địa chỉ")]
        public string diachi { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Mã chi nhánh")]
        public string macn { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [StringLength(20)]
        [Display(Name = "Mật khẩu")]
        public string password { get; set; }
    }
}