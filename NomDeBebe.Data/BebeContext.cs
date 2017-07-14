using Microsoft.EntityFrameworkCore;
using NomDeBebe.Data.Entities;
using System;

namespace NomDeBebe.Data
{
    public class BebeContext : DbContext
    {
        public BebeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<BabyName> BabyNames { get; set; }

        public DbSet<YearEntry> YearEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
