﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DocumentItem>().Property(d => d.CreatedAt).HasDefaultValueSql("now()");
            builder.Entity<NewsItem>().Property(n => n.CreatedAt).HasDefaultValueSql("now()");
        }
    }
}
