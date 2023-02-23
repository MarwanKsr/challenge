using Enoca.Core.Domain.Companies;
using Enoca.Core.Domain.Orders;
using Enoca.Core.Domain.Products;
using Enoca.Data.Data.EntitesConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Add the following
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This important for scaffolding, and can't inject any service
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase("ScaffoldingDB");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            builder.ApplyConfiguration(new OrderEntityTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
