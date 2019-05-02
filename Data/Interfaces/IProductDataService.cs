using Store.Products.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Products.Api.Data.Interfaces
{
    public interface IProductDataService
    {
        Task<IEnumerable<Product>> ListProductsAsync();

        Task AddProduct(Product product);
    }
}
