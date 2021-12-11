namespace WebNHATHUOC1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebNHATHUOC1.Models.Metadata;

    [Table("THUOC")]
    [MetadataType(typeof(CThuoc))]
    public partial class THUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUOC()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }

        [Key]
        [StringLength(12)]
        public string mathuoc { get; set; }

        [Required]
        [StringLength(30)]
        public string tenthuoc { get; set; }

        [Required]
        [StringLength(12)]
        public string mancc { get; set; }

        [Column(TypeName = "date")]
        public DateTime hansd { get; set; }

        [Required]
        [StringLength(12)]
        public string donvitinh { get; set; }

        [Column(TypeName = "money")]
        public decimal dongia { get; set; }

        public bool hethan { get; set; }

        [Required]
        [StringLength(150)]
        public string mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
