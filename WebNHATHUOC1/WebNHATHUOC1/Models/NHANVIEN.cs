namespace WebNHATHUOC1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebNHATHUOC1.Models.Metadata;

    [Table("NHANVIEN")]
    [MetadataType(typeof(CNhanvien))]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(12)]
        public string manv { get; set; }

        [Required]
        [StringLength(30)]
        public string tennv { get; set; }

        [Required]
        [StringLength(12)]
        public string sodt { get; set; }

        [Required]
        [StringLength(12)]
        public string socm { get; set; }

        [StringLength(150)]
        public string diachi { get; set; }

        [Required]
        [StringLength(12)]
        public string macn { get; set; }

        [StringLength(20)]
        public string password { get; set; }

        public virtual CHINHANH CHINHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
