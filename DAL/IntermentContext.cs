using Microsoft.EntityFrameworkCore;
using Centralization.Models;

namespace Centralization.DAL
{
    public partial class IntermentContext : DbContext
    {
        public IntermentContext()
        {
        }

        public IntermentContext(DbContextOptions<IntermentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Interment> Interments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=sql;Initial Catalog=IntranetLookups_Development;User ID=tdahman;Password=Yore@1325;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interment>(entity =>
            {
                entity.HasKey(e => new { e.Idf, e.CemNo });

                entity.HasIndex(e => e.CemNo)
                    .HasName("CemNo");

                entity.HasIndex(e => e.Type)
                    .HasName("Type");

                entity.HasIndex(e => new { e.Idf, e.CemNo })
                    .HasName("IDFCemSearch");

                entity.HasIndex(e => new { e.LastName, e.FirstName })
                    .HasName("NameSearch");

                entity.HasIndex(e => new { e.GraveCrypt, e.LotTier, e.BlockBuilding, e.SectionLocation })
                    .HasName("LocationSearch");

                entity.Property(e => e.BlockBuilding)
                    .HasColumnName("BLOCK_BUILDING")
                    .HasMaxLength(50);

                entity.Property(e => e.CemNo)
                    .HasColumnName("CEMNO")
                    .HasMaxLength(2);

                entity.Property(e => e.EasementNo)
                    .HasColumnName("EASEMENTNO")
                    .HasMaxLength(10);

                entity.Property(e => e.EbTifName)
                    .HasColumnName("EBTif")
                    .HasMaxLength(255);

                entity.Property(e => e.EbTifPath).HasColumnName("EBTifPath");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.GraveCrypt)
                    .HasColumnName("GRAVE_CRYPT")
                    .HasMaxLength(50);

                entity.Property(e => e.IDate).HasColumnName("IDATE");

                entity.Property(e => e.Idf).HasColumnName("IDF");

                entity.Property(e => e.IOTifName).HasColumnName("IOTif");

                entity.Property(e => e.IOTifPath).HasColumnName("IOTifPath");

                entity.Property(e => e.LCTifName).HasColumnName("LCTif");

                entity.Property(e => e.LCTifPath).HasColumnName("LCTifPath");

                entity.Property(e => e.ICTifName).HasColumnName("ICTif");

                entity.Property(e => e.ICTifPath).HasColumnName("TifPath");

                entity.Property(e => e.LastName)
                    .HasColumnName("LNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.LotTier)
                    .HasColumnName("LOT_TIER")
                    .HasMaxLength(50);

                entity.Property(e => e.SectionLocation)
                    .HasColumnName("SECTION_LOCATION")
                    .HasMaxLength(75);

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
