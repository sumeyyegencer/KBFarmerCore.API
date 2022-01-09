using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KBHayvancılıkTakipSistemi.Models
{
    public partial class FarmDBContext : DbContext
    {
        public FarmDBContext()
        {
        }

        public FarmDBContext(DbContextOptions<FarmDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Sheep> Sheep { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SUMEYYEGENCER;Initial Catalog=FarmDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sheep>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.BarcodeNo).HasColumnName("barcode_no");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.RaceId).HasColumnName("race_id");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Sheep)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Sheep_Group");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Sheep)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Sheep_Race");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
