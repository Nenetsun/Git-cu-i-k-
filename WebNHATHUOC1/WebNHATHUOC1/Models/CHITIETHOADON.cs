namespace WebNHATHUOC1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebNHATHUOC1.Models.Metadata;

    [Table("CHITIETHOADON")]
    [MetadataType(typeof(CChitiethoadon))]
    public partial class CHITIETHOADON
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string sohd { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string mathuoc { get; set; }

        [Required]
        [StringLength(12)]
        public string donvitinh { get; set; }

        [Column(TypeName = "money")]
        public decimal dongia { get; set; }

        public byte soluong { get; set; }

        [Column(TypeName = "money")]
        public decimal? thanhtien { get; set; }

        public virtual THUOC THUOC { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
