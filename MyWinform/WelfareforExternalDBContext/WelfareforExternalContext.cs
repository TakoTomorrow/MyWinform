using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MyWinform.WelfareforExternalDBContext
{
    public partial class WelfareforExternalContext : DbContext
    {
        public WelfareforExternalContext()
        {
            
        }

        public WelfareforExternalContext(DbContextOptions<WelfareforExternalContext> options)
            : base(options)
        {           
        }

        public virtual DbSet<Wfactsetup> Wfactsetup { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=TWTPEWEAPDB10T\\HISTORICAL;Database=WelfareforExternal;Trusted_Connection=True;user id=WelfareInterface;password=PWelfareInterface;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wfactsetup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WFACTSETUP");

                entity.Property(e => e.AcerDealCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ActCode)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.ActEndDate).HasColumnType("datetime");

                entity.Property(e => e.ActStartDate).HasColumnType("datetime");

                entity.Property(e => e.ActYear)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo).HasColumnName("SerialNO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
