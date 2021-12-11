using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNHATHUOC1.Models.Metadata
{
    public class CChinhanh
    {
        [StringLength(12)]
        [Display(Name ="Mã chi nhánh")]
        public string macn { get; set; }

        [Required]
        [Display(Name = "Tên quản lý")]
        [StringLength(30)]
        public string tenql { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        [StringLength(150)]
        public string diachi { get; set; }
    }
}