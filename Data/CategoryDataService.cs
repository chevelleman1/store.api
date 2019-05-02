using Microsoft.EntityFrameworkCore;
using Store.Products.Api.Data.Interfaces;
using Store.Products.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Products.Api.Data
{
    public class CategoryDataService: ICategoryDataService
    {
        private readonly ProductContext _productContext;
        public CategoryDataService(ProductContext productContext)
        {
            _productContext = productContext;
        }

        async Task<IEnumerable<Category>> ICategoryDataService.GetCategoriesAsync()
        {
            var categories = await _productContext.Categories.ToListAsync();
            return categories;
        }

        async Task<Category> ICategoryDataService.GetCategoryAsync(long id)
        {
            var category = await _productContext.Categories.FindAsync(id);
            return category;
        }

        public async Task AddCategory(Category category)
        {
            var result = await _productContext.Categories.AddAsync(category);
            _productContext.SaveChanges();   
        }
    }
}
