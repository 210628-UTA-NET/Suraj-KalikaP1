using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreModel;
namespace StoreDL
{
    public class StoreDBContext : DbContext
    {
        public DbSet<StoreFront> StoreFronts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public StoreDBContext() : base()
        { }
        public StoreDBContext(DbContextOptions options) : base(options)
        { }
        

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            p_modelBuilder.Entity<StoreFront>()
                .Property(StoreFront => StoreFront.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Order>()
                .Property(Orders => Orders.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Product>()
                .Property(Products => Products.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<LineItem>()
                .Property(LineItems => LineItems.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Customer>()
                .Property(Customer => Customer.Id)
                .ValueGeneratedOnAdd();
        }
        

    }
}
