using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bankingSystem_server.Database
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TradeLog> TradeLog { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=jinjoosoft.io;Port=43306;Database=banking;User=root;Password=naverscv123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeLog>(entity =>
            {
                entity.HasKey(e => e.TlIndex)
                    .HasName("PRIMARY");

                entity.ToTable("TradeLog");

                entity.HasIndex(e => e.TlReceivedUserIndex)
                    .HasName("TL_ReceivedUserIndex_idx");

                entity.HasIndex(e => e.TlUserIndex)
                    .HasName("TL_UserIndex_idx");

                entity.Property(e => e.TlIndex).HasColumnName("TL_Index");

                entity.Property(e => e.TlContent)
                    .IsRequired()
                    .HasColumnName("TL_Content")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TlCreatedTime)
                    .HasColumnName("TL_CreatedTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TlReceivedUserIndex).HasColumnName("TL_ReceivedUserIndex");

                entity.Property(e => e.TlType).HasColumnName("TL_Type");

                entity.Property(e => e.TlUserIndex).HasColumnName("TL_UserIndex");

                entity.HasOne(d => d.TlReceivedUserIndexNavigation)
                    .WithMany(p => p.TradeLogTlReceivedUserIndexNavigation)
                    .HasForeignKey(d => d.TlReceivedUserIndex)
                    .HasConstraintName("TL_ReceivedUserIndex");

                entity.HasOne(d => d.TlUserIndexNavigation)
                    .WithMany(p => p.TradeLogTlUserIndexNavigation)
                    .HasForeignKey(d => d.TlUserIndex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TL_UserIndex");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsrIndex)
                    .HasName("PRIMARY");

                entity.ToTable("User");

                entity.Property(e => e.UsrIndex).HasColumnName("USR_Index");

                entity.Property(e => e.UsrAccount).HasColumnName("USR_Account");

                entity.Property(e => e.UsrAmount).HasColumnName("USR_Amount");

                entity.Property(e => e.UsrName)
                    .IsRequired()
                    .HasColumnName("USR_Name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.UsrPassword)
                    .IsRequired()
                    .HasColumnName("USR_Password")
                    .HasColumnType("varchar(45)");
            });
        }
    }
}
