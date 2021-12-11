using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebNHATHUOC1.Models.Metadata
{
    public class CHoadon
    {
        [Display(Name ="Số hóa đơn")]
        [StringLength(12)]
        public string sohd { get; set; }

        [Display(Name = "Ngày lập")]
        public DateTime ngaylap { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal? thanhtien { get; set; }

        [Display(Name = "Mã nhân viên")]
        [Required]
        [StringLength(12)]
        public string manv { get; set; }

        [Display(Name = "Mã khách hàng")]
        [Required]
        [StringLength(12)]
        public string makh { get; set; }
    }
}