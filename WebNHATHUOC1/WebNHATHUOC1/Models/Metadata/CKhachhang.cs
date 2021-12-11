using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebNHATHUOC1.Models.Metadata
{
    public class CKhachhang
    {
        [Display(Name ="Số điện thoại")]
        [StringLength(12)]
        public string sodt { get; set; }

        [Display(Name = "Tên khách hàng")]
        [Required]
        [StringLength(30)]
        public string tenkh { get; set; }

    }
}