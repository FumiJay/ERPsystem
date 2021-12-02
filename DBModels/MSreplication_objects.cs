namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSreplication_objects
    {
        [StringLength(128)]
        public string publisher { get; set; }

        [StringLength(128)]
        public string publisher_db { get; set; }

        [StringLength(128)]
        public string publication { get; set; }

        [Key]
        [Column(Order = 0)]
        public string object_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string object_type { get; set; }

        [StringLength(128)]
        public string article { get; set; }
    }
}
