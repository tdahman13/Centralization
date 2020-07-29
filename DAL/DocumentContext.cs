using Microsoft.EntityFrameworkCore;
using Centralization.Models;

namespace Centralization.DAL
{
    public partial class DocumentContext : DbContext
    {
        public DocumentContext()
        {
        }

        public DocumentContext(DbContextOptions<DocumentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocFile> DocFiles { get; set; }
        public virtual DbSet<Easements> Easements { get; set; }
        public virtual DbSet<IntermentOrder> IntermentOrders { get; set; }
        public virtual DbSet<LotCardInventory> LotCardInventory { get; set; }
        public virtual DbSet<LotCard> LotCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=sql;Initial Catalog=BP_Documents_Development;User ID=tdahman;Password=Yore@1325;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocFile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DOCFILES");

                //entity.Property(e => e.Badscan).HasColumnName("BADSCAN");

                entity.Property(e => e.Block)
                    .HasColumnName("BLOCK")
                    .HasMaxLength(255);

                entity.Property(e => e.Cemid)
                    .HasColumnName("CEMID")
                    .HasMaxLength(255);

                //entity.Property(e => e.Checked).HasColumnName("CHECKED");

                //entity.Property(e => e.Comments).HasColumnName("COMMENTS");

                //entity.Property(e => e.Date).HasColumnName("DATE");

                //entity.Property(e => e.Dfindex).HasColumnName("DFINDEX");

                //entity.Property(e => e.Dfnum)
                //    .HasColumnName("DFNUM")
                //    .HasMaxLength(255);

                //entity.Property(e => e.Dfpart)
                //    .HasColumnName("DFPART")
                //    .HasMaxLength(255);

                entity.Property(e => e.Dftif)
                    .HasColumnName("DFTIF")
                    .HasMaxLength(255);

                //entity.Property(e => e.Garbage).HasColumnName("GARBAGE");

                entity.Property(e => e.Gravehigh)
                    .HasColumnName("GRAVEHIGH")
                    .HasMaxLength(255);

                entity.Property(e => e.Gravelow)
                    .HasColumnName("GRAVELOW")
                    .HasMaxLength(255);

                //entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lot)
                    .HasColumnName("LOT")
                    .HasMaxLength(255);

                //entity.Property(e => e.Missing).HasColumnName("MISSING");

                //entity.Property(e => e.ParentCemNum).HasMaxLength(255);

                //entity.Property(e => e.Scandate)
                //    .HasColumnName("SCANDATE")
                //    .HasColumnType("datetime");

                entity.Property(e => e.Section)
                    .HasColumnName("SECTION")
                    .HasMaxLength(255);

                //entity.Property(e => e.Series)
                //    .HasColumnName("SERIES")
                //    .HasMaxLength(255);

                entity.Property(e => e.Tifpath)
                    .HasColumnName("TIFPATH")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Easements>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EASEMENTS");

                //entity.HasIndex(e => e.ParentCemNum)
                //    .HasName("ParentCemNum");

                entity.HasIndex(e => new { e.Cemid, e.Easementno })
                    .HasName("CemAndEasement");

                entity.HasIndex(e => new { e.Cemid, e.Date, e.Easementno })
                    .HasName("CemIDAndEasementNoAndDate");

                //entity.Property(e => e.Badscan).HasColumnName("BADSCAN");

                entity.Property(e => e.Block)
                    .HasColumnName("BLOCK")
                    .HasMaxLength(255);

                entity.Property(e => e.Cemid)
                    .HasColumnName("CEMID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                //entity.Property(e => e.Checked).HasColumnName("CHECKED");

                //entity.Property(e => e.Comments)
                //    .HasColumnName("COMMENTS")
                //    .HasMaxLength(255);

                entity.Property(e => e.Date).HasColumnName("DATE");

                entity.Property(e => e.Easementno)
                    .HasColumnName("EASEMENTNO")
                    .HasMaxLength(255);

                entity.Property(e => e.Ebtif)
                    .HasColumnName("EBTIF")
                    .HasMaxLength(255);

                //entity.Property(e => e.Garbage).HasColumnName("GARBAGE");

                entity.Property(e => e.Gravehigh)
                    .HasColumnName("GRAVEHIGH")
                    .HasMaxLength(255);

                entity.Property(e => e.Gravelow)
                    .HasColumnName("GRAVELOW")
                    .HasMaxLength(255);

                //entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lot)
                    .HasColumnName("LOT")
                    .HasMaxLength(255);

                //entity.Property(e => e.Missing).HasColumnName("MISSING");

                //entity.Property(e => e.ParentCemNum).HasMaxLength(255);

                //entity.Property(e => e.Scandate)
                //    .HasColumnName("SCANDATE")
                //    .HasColumnType("datetime");

                entity.Property(e => e.Section)
                    .HasColumnName("SECTION")
                    .HasMaxLength(255);

                //entity.Property(e => e.Series)
                //    .HasColumnName("SERIES")
                //    .HasMaxLength(255);

                //entity.Property(e => e.Svtpage).HasColumnName("SVTPAGE");

                entity.Property(e => e.Tifpath)
                    .HasColumnName("TIFPATH")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<IntermentOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("INTERMENTORDERS");

                //entity.Property(e => e.Badscan).HasColumnName("BADSCAN");

                entity.Property(e => e.Block)
                    .HasColumnName("BLOCK")
                    .HasMaxLength(255);

                entity.Property(e => e.Cemid)
                    .HasColumnName("CEMID")
                    .HasMaxLength(255);

                //entity.Property(e => e.Checked).HasColumnName("CHECKED");

                //entity.Property(e => e.Date).HasColumnName("DATE");

                //entity.Property(e => e.Garbage).HasColumnName("GARBAGE");

                entity.Property(e => e.Grave)
                    .HasColumnName("GRAVE")
                    .HasMaxLength(255);

                //entity.Property(e => e.Id).HasColumnName("ID");

                //entity.Property(e => e.Intno)
                //    .HasColumnName("INTNO")
                //    .HasMaxLength(255);

                entity.Property(e => e.Iotif)
                    .HasColumnName("IOTIF")
                    .HasMaxLength(255);

                entity.Property(e => e.Lot)
                    .HasColumnName("LOT")
                    .HasMaxLength(255);

                //entity.Property(e => e.Missing).HasColumnName("MISSING");

                //entity.Property(e => e.ParentCemNum).HasMaxLength(255);

                //entity.Property(e => e.Scandate)
                //    .HasColumnName("SCANDATE")
                //    .HasColumnType("datetime");

                entity.Property(e => e.Section)
                    .HasColumnName("SECTION")
                    .HasMaxLength(255);

                //entity.Property(e => e.Signaturecopynum)
                //    .HasColumnName("SIGNATURECOPYNUM")
                //    .HasMaxLength(255);

                //entity.Property(e => e.Signaturecopypage).HasColumnName("SIGNATURECOPYPAGE");

                entity.Property(e => e.Tifpath)
                    .HasColumnName("TIFPATH")
                    .HasMaxLength(255);

                //entity.Property(e => e.Unmatched).HasColumnName("UNMATCHED");

                //entity.Property(e => e.Year)
                //    .HasColumnName("YEAR")
                //    .HasMaxLength(255);
            });

            modelBuilder.Entity<LotCardInventory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Block).HasMaxLength(50);

                entity.Property(e => e.CemNum).HasMaxLength(2);

                //entity.Property(e => e.DateModified)
                //    .HasColumnName("Date_Modified")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.EasementNumber).HasMaxLength(50);

                //entity.Property(e => e.EasementNumberAuto).HasMaxLength(50);

                entity.Property(e => e.Grave).HasMaxLength(50);

               // entity.Property(e => e.GraveType).HasMaxLength(50);

                entity.Property(e => e.Lot).HasMaxLength(50);

                entity.Property(e => e.LotCardId).HasColumnName("LotCardID");

                //entity.Property(e => e.OrderId).HasColumnName("OrderID");

                //entity.Property(e => e.ParentCemNum).HasMaxLength(2);

                //entity.Property(e => e.PriceClass).HasMaxLength(50);

                entity.Property(e => e.Section).HasMaxLength(50);

                //entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<LotCard>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LOTCARDS");

                //entity.Property(e => e.Badscan).HasColumnName("BADSCAN");

                //entity.Property(e => e.Block)
                //    .HasColumnName("BLOCK")
                //    .HasMaxLength(255);

                //entity.Property(e => e.Cemid)
                //    .HasColumnName("CEMID")
                //    .HasMaxLength(255);

                //entity.Property(e => e.Checked).HasColumnName("CHECKED");

                //entity.Property(e => e.Checkinventorycount)
                //    .HasColumnName("CHECKINVENTORYCOUNT")
                //    .HasMaxLength(255);

                //entity.Property(e => e.Duplicate).HasColumnName("DUPLICATE");

                //entity.Property(e => e.Garbage).HasColumnName("GARBAGE");

                //entity.Property(e => e.Grave)
                //    .HasColumnName("GRAVE")
                //    .HasMaxLength(255);

                entity.Property(e => e.Id).HasColumnName("ID");

                //entity.Property(e => e.Itsbatch).HasColumnName("ITSBATCH");

                //entity.Property(e => e.Lcid).HasColumnName("LCID");

                entity.Property(e => e.Lctif)
                    .HasColumnName("LCTIF")
                    .HasMaxLength(255);

                //entity.Property(e => e.Lot)
                //    .HasColumnName("LOT")
                //    .HasMaxLength(255);

                //entity.Property(e => e.Missing).HasColumnName("MISSING");

                //entity.Property(e => e.ParentCemNum).HasMaxLength(255);

                //entity.Property(e => e.Scandate)
                //    .HasColumnName("SCANDATE")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.Section)
                //    .HasColumnName("SECTION")
                //    .HasMaxLength(255);

                //entity.Property(e => e.Sequence).HasColumnName("SEQUENCE");

                entity.Property(e => e.Tifpath)
                    .HasColumnName("TIFPATH")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
