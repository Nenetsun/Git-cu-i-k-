namespace WebNHATHUOC1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebNHATHUOC1.Models.Metadata;

    [Table("NHACUNGCAP")]
    [MetadataType(typeof(CNhacungcap))]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            THUOCs = new HashSet<THUOC>();
        }

        [Key]
        [StringLength(12)]
        public string mancc { get; set; }

        [Required]
        [StringLength(30)]
        public string tenncc { get; set; }

        [Required]
        [StringLength(12)]
        public string sodt { get; set; }

        [Required]
        [StringLength(150)]
        public string diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUOC> THUOCs { get; set; }
    }
}
