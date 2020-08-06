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

        async Task<Category> ICategoryDataService.GetCategoryAsync(int id)
        {
            var category = await _productContext.Categories.FindAsync(id);
            return category;
        }

        public async Task AddCategory(Category category)
        {
            var result = await _productContext.Categories.AddAsync(category);
            _productContext.SaveChanges();   
        }

    

        public async Task DeleteCategory(int id)
        {
            var categoryToDelete = await _productContext.Categories.FindAsync(id);
            _productContext.Categories.Remove(categoryToDelete);
            _productContext.SaveChanges();
        }
        public async Task UpdateCategory(int id, Category category)
        {
            //var categoryToDelete = await _productContext.Categories.FindAsync(id);
            //_productContext.Categories.AsNoTracking().Where(t => t.Id == id).FirstOrDefault();
            _productContext.Categories.Update(category);
             _productContext.SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetFilteredCategories(string searchTerm)
        {
            return await _productContext.Categories.Where(c => c.Name.Contains(searchTerm)).ToListAsync();
        }
    }
}
