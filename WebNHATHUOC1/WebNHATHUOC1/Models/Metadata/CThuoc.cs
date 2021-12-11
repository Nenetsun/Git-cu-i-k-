using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebNHATHUOC1.Models.Metadata
{
    public class CThuoc
    {
        [Display(Name = "Mã thuốc")]
        [Required(ErrorMessage = "Hãy nhập mã")]
        [StringLength(12)]
        public string mathuoc { get; set; }

        [Display(Name = "Tên thuốc")]
        [Required(ErrorMessage = "Hãy nhập tên thuốc")]
        [StringLength(30)]
        public string tenthuoc { get; set; }

        [Display(Name = "Mã nhà cung cấp")]
        [Required(ErrorMessage = "Hãy nhập nhà cung cấp")]
        [StringLength(12)]
        public string mancc { get; set; }

        [Display(Name = "Hạn sử dụng")]
        [Required(ErrorMessage = "Hãy nhập hạn sử dụng")]
        public DateTime hansd { get; set; }

        [Display(Name = "Đơn vị tính (Viên, Vỉ, Gói, ...)")]
        [Required(ErrorMessage = "Hãy nhập đơn vị tính")]
        [StringLength(12)]
        public string donvitinh { get; set; }

        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Hãy nhập đơn giá")]
        public decimal dongia { get; set; }

        [Display(Name ="Hết hạn")]
        public bool hethan { get; set; }

        [Display(Name ="Mô tả thuốc")]
        [Required]
        [StringLength(150)]
        public string mota { get; set; }
    }
}