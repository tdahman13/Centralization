using Microsoft.EntityFrameworkCore;
using Centralization.Models;

namespace Centralization.DAL
{
    public class MemorialContext : DbContext
    {
        public MemorialContext(DbContextOptions<MemorialContext> options)
            : base(options)
        {
        }

        public DbSet<MemorialApplication> MemorialApplications { get; set; }
        public DbSet<LinkedInterment> LinkedInterments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemorialApplication>().ToTable("MemorialApplications");
            modelBuilder.Entity<LinkedInterment>().ToTable("LinkedInterments");
        }
    }
}
