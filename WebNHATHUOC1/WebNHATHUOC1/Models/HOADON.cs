namespace WebNHATHUOC1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebNHATHUOC1.Models.Metadata;


    [Table("HOADON")]
    [MetadataType(typeof(CHoadon))]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }

        [Key]
        [StringLength(12)]
        public string sohd { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaylap { get; set; }

        [Column(TypeName = "money")]
        public decimal? thanhtien { get; set; }

        [Required]
        [StringLength(12)]
        public string manv { get; set; }

        [Required]
        [StringLength(12)]
        public string makh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
