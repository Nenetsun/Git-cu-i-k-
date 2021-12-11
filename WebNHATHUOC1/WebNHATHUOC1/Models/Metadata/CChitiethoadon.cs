using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNHATHUOC1.Models.Metadata
{
    public class CChitiethoadon
    {
        [Display(Name = "Số hóa đơn")]
        [Required(ErrorMessage = "Hãy nhập số hóa đơn")]
        [StringLength(12)]
        public string sohd { get; set; }

        [Display(Name = "Mã thuốc")]
        [Required(ErrorMessage = "Hãy nhập mã thuốc")]
        [StringLength(12)]
        public string mathuoc { get; set; }

        [Display(Name = "Đơn vị tính")]
        public string donvitinh { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal dongia { get; set; }

        [Display(Name = "Số lượng")]
        public byte soluong { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal? thanhtien { get; set; }


    }
}