using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgriGrader.Core.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace AgriGrader.Infrastructure.Data
{
    public class AgrigraderDbContext : DbContext
    {
        public AgrigraderDbContext(DbContextOptions<AgrigraderDbContext> options) : base(options) { }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<SubCommodity> SubCommodities { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OtpVerification> OtpVerifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // USER SCHEMA
            modelBuilder.Entity<Customer>()
                .ToTable("Customers", "user");

            modelBuilder.Entity<Role>()
                .ToTable("Roles", "user");

            modelBuilder.Entity<Seller>()
                .ToTable("Sellers", "user");

            modelBuilder.Entity<Buyer>()
                .ToTable("Buyers", "user");

            // MASTER SCHEMA
            modelBuilder.Entity<Commodity>()
                .ToTable("Commodities", "master");

            modelBuilder.Entity<SubCommodity>()
                .ToTable("SubCommodities", "master");
           
            modelBuilder.Entity<OtpVerification>()
               .ToTable("OtpVerifications", "master");
        }



    }
}
