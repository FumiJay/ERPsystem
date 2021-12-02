using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ERPsystem.DBModels
{
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<MSreplication_queue> MSreplication_queue { get; set; }
        public virtual DbSet<ProductList> ProductLists { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<StaffList> StaffLists { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<MSrepl_queuedtraninfo> MSrepl_queuedtraninfo { get; set; }
        public virtual DbSet<MSreplication_objects> MSreplication_objects { get; set; }
        public virtual DbSet<MSreplication_subscriptions> MSreplication_subscriptions { get; set; }
        public virtual DbSet<MSsubscription_agents> MSsubscription_agents { get; set; }
        public virtual DbSet<MSsubscription_articlecolumns> MSsubscription_articlecolumns { get; set; }
        public virtual DbSet<MSsubscription_articles> MSsubscription_articles { get; set; }
        public virtual DbSet<MSsubscription_properties> MSsubscription_properties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductList>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StaffList>()
                .HasMany(e => e.ProductLists)
                .WithRequired(e => e.StaffList)
                .HasForeignKey(e => e.Create_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MSreplication_objects>()
                .Property(e => e.object_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSreplication_subscriptions>()
                .Property(e => e.agent_id)
                .IsFixedLength();

            modelBuilder.Entity<MSreplication_subscriptions>()
                .Property(e => e.subscription_guid)
                .IsFixedLength();

            modelBuilder.Entity<MSreplication_subscriptions>()
                .Property(e => e.subid)
                .IsFixedLength();

            modelBuilder.Entity<MSsubscription_agents>()
                .Property(e => e.attach_version)
                .IsFixedLength();
        }
    }
}
