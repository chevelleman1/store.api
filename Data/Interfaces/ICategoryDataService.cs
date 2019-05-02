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

        Task AddCategory(Category category);
        Task<Category> GetCategoryAsync(long Id);
    }
}
