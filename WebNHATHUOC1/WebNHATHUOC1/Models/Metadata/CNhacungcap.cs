using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebNHATHUOC1.Models.Metadata
{
    public class CNhacungcap
    {
        [Display(Name ="Mã nhà cung cấp")]
        [StringLength(12)]
        public string mancc { get; set; }

        [Display(Name = "Tên nhà cung cấp")]
        [Required]
        [StringLength(30)]
        public string tenncc { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required]
        [StringLength(12)]
        public string sodt { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required]
        [StringLength(150)]
        public string diachi { get; set; }
    }
}