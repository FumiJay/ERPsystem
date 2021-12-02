namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSsubscription_agents
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string publisher { get; set; }

        [Key]
        [Column(Order = 2)]
        public string publisher_db { get; set; }

        [Key]
        [Column(Order = 3)]
        public string publication { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int subscription_type { get; set; }

        [StringLength(128)]
        public string queue_id { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte update_mode { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool failover_mode { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int spid { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime login_time { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool allow_subscription_copy { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int attach_state { get; set; }

        [Key]
        [Column(Order = 11)]
        [MaxLength(16)]
        public byte[] attach_version { get; set; }

        public int? last_sync_status { get; set; }

        [StringLength(128)]
        public string last_sync_summary { get; set; }

        public DateTime? last_sync_time { get; set; }

        [StringLength(128)]
        public string queue_server { get; set; }
    }
}
