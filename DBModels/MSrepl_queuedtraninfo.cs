namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSrepl_queuedtraninfo
    {
        [Key]
        [Column(Order = 0)]
        public string publisher { get; set; }

        [Key]
        [Column(Order = 1)]
        public string publisher_db { get; set; }

        [Key]
        [Column(Order = 2)]
        public string publication { get; set; }

        [Key]
        [Column(Order = 3)]
        public string tranid { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long maxorderkey { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long commandcount { get; set; }
    }
}
