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

        public async Task<IEnumerable<Product>> ListProductsByCategoryIdAsync(int id)
        {
            var list = await _context.Products.Where(p => p.CategoryId == id).ToListAsync();
            return list;

        }

        public async Task<IEnumerable<Product>> ListProductsByCategoryNameAsync(string categoryName)
        {
       
            var innerJoinQuery = from category in _context.Categories
                join prod in _context.Products 
                on category.Id equals prod.CategoryId
                where category.Name == categoryName
                select prod; //produces flat sequence



            return innerJoinQuery;

        }

        public async Task AddProduct(Product product)
        {
            var result = await _context.Products.AddAsync(product);
            _context.SaveChanges();


        }

    }
}
