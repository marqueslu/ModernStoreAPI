using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.ValueObjects;
using ModernStoreAPI.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Infra.Contexts
{
    public class ModernStoreAPIDataContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost,1433;Database=ModerStore;User ID=SA;Password=123Aa321");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.Entity<Customer>().OwnsOne(typeof(Document), "Document");
            modelBuilder.Entity<Customer>().OwnsOne(typeof(Email), "Email");
            modelBuilder.Entity<Customer>().OwnsOne(typeof(Name), "Name");

            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderITemMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }

    }
}
