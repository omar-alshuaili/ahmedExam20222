
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductModel
{
    public class ProductDBContext : DbContext
    {
         public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public ProductDBContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Week7ProductCoreDB";
            optionsBuilder.UseSqlServer(myconnectionstring)
              .LogTo(Console.WriteLine,
                     new[] { DbLoggerCategory.Database.Command.Name },
                     LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Alternative to [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            //modelBuilder.Entity<Product>().Property("ID").UseIdentityColumn(seed: 1, increment: 1);

            //Product[] products = DBHelper.Get<Product>(@"C:\Users\ppowell\source\repos\EFCoreProductsSample\ProductModel\Products.csv").ToArray();
            //modelBuilder.Entity<Product>().HasData(products);

            //modelBuilder.Entity<Product>().HasData(
            // new Product
            // {
            //     ID = 46,
            //     Description = "test",
            //     ReorderLevel = 4,
            //     ReorderQuantity = 2,
            //     StockOnHand = 30,
            //     UnitPrice = 10
            // });

            base.OnModelCreating(modelBuilder);
        }


    }
}


