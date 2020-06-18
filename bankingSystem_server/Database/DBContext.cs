﻿using System;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=banking;User=root;Password=ehddnr1213;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeLog>(entity =>
            {
                entity.HasKey(e => e.TlIndex)
                    .HasName("PRIMARY");

                entity.ToTable("trade_log");

                entity.HasIndex(e => e.ItUserIndex)
                    .HasName("TL_UserIndex_idx");

                entity.Property(e => e.TlIndex).HasColumnName("TL_Index");

                entity.Property(e => e.ItUserIndex).HasColumnName("IT_UserIndex");

                entity.Property(e => e.TlContent)
                    .IsRequired()
                    .HasColumnName("TL_Content")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TlCreatedTime)
                    .HasColumnName("TL_CreatedTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TlReceivedUserIndex).HasColumnName("TL_ReceivedUserIndex");

                entity.Property(e => e.TlType).HasColumnName("TL_Type");

                entity.HasOne(d => d.ItUserIndexNavigation)
                    .WithMany(p => p.TradeLog)
                    .HasForeignKey(d => d.ItUserIndex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TL_UserIndex");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsrIndex)
                    .HasName("PRIMARY");

                entity.ToTable("user");

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