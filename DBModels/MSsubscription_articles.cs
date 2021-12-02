namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSsubscription_articles
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int agent_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int artid { get; set; }

        [Key]
        [Column(Order = 2)]
        public string article { get; set; }

        [Key]
        [Column(Order = 3)]
        public string dest_table { get; set; }

        [Key]
        [Column(Order = 4)]
        public string owner { get; set; }

        [StringLength(128)]
        public string cft_table { get; set; }
    }
}
