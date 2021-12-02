namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StaffList")]
    public partial class StaffList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffList()
        {
            ProductLists = new HashSet<ProductList>();
        }

        [Key]
        public int Staff_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Staff_Name { get; set; }

        public int Staff_Level { get; set; }

        public int Create_Staff_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public int? Update_Staff_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateTime { get; set; }

        public bool? Isdelete { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductList> ProductLists { get; set; }
    }
}
