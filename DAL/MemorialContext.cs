using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Centralization.Models.MemorialApplication> MemorialApplication { get; set; }
    }
}
