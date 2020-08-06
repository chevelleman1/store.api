using Store.Products.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Products.Api.Data.Interfaces
{
    public interface ICategoryDataService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Category>> GetFilteredCategories(string searchTerm);

        

        Task AddCategory(Category category);
        Task DeleteCategory(int Id);
        Task UpdateCategory(int Id, Category category);
        Task<Category> GetCategoryAsync(int Id);
    }
}
