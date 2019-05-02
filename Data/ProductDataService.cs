using Microsoft.EntityFrameworkCore;
using Store.Products.Api.Data.Interfaces;
using Store.Products.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Products.Api.Data
{
    public class ProductDataService : IProductDataService
    {
        private readonly ProductContext _context;

        public ProductDataService(ProductContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Product>> ListProductsAsync()
        {
            var list = await _context.Products.ToListAsync();
            return list;

        }

        public async Task AddProduct(Product product)
        {
            var result = await _context.Products.AddAsync(product);
            _context.SaveChanges();


        }

    }
}
