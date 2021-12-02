namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductList")]
    public partial class ProductList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductList()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        [Key]
        [StringLength(50)]
        public string Product_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Class { get; set; }

        public decimal Price { get; set; }

        public int Create_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Create_Time { get; set; }

        public int? Update_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Update_Time { get; set; }

        public bool? Isdelete { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Delete_Time { get; set; }

        public virtual StaffList StaffList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
