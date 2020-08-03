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

        public DbSet<MemorialApplication> MemorialApplication { get; set; }
        public DbSet<LinkedInterment> LinkedInterments { get; set; }
    }
}
