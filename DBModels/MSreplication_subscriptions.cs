namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSreplication_subscriptions
    {
        [Key]
        [Column(Order = 0)]
        public string publisher { get; set; }

        [StringLength(128)]
        public string publisher_db { get; set; }

        [StringLength(128)]
        public string publication { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool independent_agent { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int subscription_type { get; set; }

        [StringLength(128)]
        public string distribution_agent { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "smalldatetime")]
        public DateTime time { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Key]
        [Column(Order = 4)]
        [MaxLength(16)]
        public byte[] transaction_timestamp { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte update_mode { get; set; }

        [MaxLength(16)]
        public byte[] agent_id { get; set; }

        [MaxLength(16)]
        public byte[] subscription_guid { get; set; }

        [MaxLength(16)]
        public byte[] subid { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool immediate_sync { get; set; }
    }
}
