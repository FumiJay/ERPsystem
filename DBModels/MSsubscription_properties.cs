namespace ERPsystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSsubscription_properties
    {
        [Key]
        [Column(Order = 0)]
        public string publisher { get; set; }

        [StringLength(128)]
        public string publisher_db { get; set; }

        [Key]
        [Column(Order = 1)]
        public string publication { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int publication_type { get; set; }

        [StringLength(128)]
        public string publisher_login { get; set; }

        [StringLength(524)]
        public string publisher_password { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int publisher_security_mode { get; set; }

        [StringLength(128)]
        public string distributor { get; set; }

        [StringLength(128)]
        public string distributor_login { get; set; }

        [StringLength(524)]
        public string distributor_password { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int distributor_security_mode { get; set; }

        [StringLength(128)]
        public string ftp_address { get; set; }

        public int? ftp_port { get; set; }

        [StringLength(128)]
        public string ftp_login { get; set; }

        [StringLength(524)]
        public string ftp_password { get; set; }

        [StringLength(255)]
        public string alt_snapshot_folder { get; set; }

        [StringLength(255)]
        public string working_directory { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool use_ftp { get; set; }

        [StringLength(128)]
        public string dts_package_name { get; set; }

        [StringLength(524)]
        public string dts_package_password { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dts_package_location { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool enabled_for_syncmgr { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool offload_agent { get; set; }

        [StringLength(128)]
        public string offload_server { get; set; }

        [StringLength(255)]
        public string dynamic_snapshot_location { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool use_web_sync { get; set; }

        [StringLength(260)]
        public string internet_url { get; set; }

        [StringLength(128)]
        public string internet_login { get; set; }

        [StringLength(524)]
        public string internet_password { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int internet_security_mode { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int internet_timeout { get; set; }

        [StringLength(128)]
        public string hostname { get; set; }

        [StringLength(128)]
        public string publisherlink { get; set; }

        [StringLength(128)]
        public string publisherlinkuser { get; set; }

        public Guid? job_step_uid { get; set; }

        [StringLength(257)]
        public string job_login { get; set; }

        [StringLength(524)]
        public string job_password { get; set; }
    }
}
