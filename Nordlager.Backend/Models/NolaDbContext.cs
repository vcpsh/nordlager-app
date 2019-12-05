using Microsoft.EntityFrameworkCore;
using Nordlager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nordlager.Backend.Models
{
    public class NolaDbContext: DbContext
    {
        public DbSet<DocumentItem> Documents { get; set; }
        public DbSet<NewsItem> News { get; set; }
        public DbSet<User> Users { get; set; }

        public NolaDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
