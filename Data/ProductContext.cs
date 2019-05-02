using Microsoft.EntityFrameworkCore;
using Store.Products.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Products.Api.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Product>().HasOne(p => p.CategoryId).WithMany(c => c.ProductList).HasForeignKey(p => p.Category);

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
