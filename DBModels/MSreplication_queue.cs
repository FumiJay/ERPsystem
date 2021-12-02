namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSreplication_queue
    {
        [Required]
        [StringLength(128)]
        public string publisher { get; set; }

        [Required]
        [StringLength(128)]
        public string publisher_db { get; set; }

        [Required]
        [StringLength(128)]
        public string publication { get; set; }

        [Required]
        [StringLength(128)]
        public string tranid { get; set; }

        [MaxLength(8000)]
        public byte[] data { get; set; }

        public int? datalen { get; set; }

        public int? commandtype { get; set; }

        public DateTime? insertdate { get; set; }

        [Key]
        public long orderkey { get; set; }

        public bool cmdstate { get; set; }
    }
}
