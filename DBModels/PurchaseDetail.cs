namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseDetail")]
    public partial class PurchaseDetail
    {
        [Key]
        public int Sid { get; set; }

        [Required]
        [StringLength(50)]
        public string Purchase_ID { get; set; }

        [StringLength(50)]
        public string Product_ID { get; set; }

        public int? Product_Quantity { get; set; }

        public int Purchase_Class { get; set; }

        [Column(TypeName = "date")]
        public DateTime ArriveTime { get; set; }

        public bool Isdelete { get; set; }

        public int? DeleteMember { get; set; }

        public DateTime? DeleteTime { get; set; }

        public virtual ProductList ProductList { get; set; }
    }
}
