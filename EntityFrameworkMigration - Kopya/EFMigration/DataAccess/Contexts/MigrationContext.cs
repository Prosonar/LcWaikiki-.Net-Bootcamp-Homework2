using EntityFrameworkMigration.DataAccess.Mapping;
using EntityFrameworkMigration.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.DataAccess.Contexts
{
    public class MigrationContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolType> SchoolTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;initial catalog=EFMigration;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new SchoolMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new SchoolTypeMapping());
        }

    }
}
