using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Products.Api.Data;
using Store.Products.Api.Data.Interfaces;
using Store.Products.Api.Models;

namespace Store.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDataService _productDataService;

        public ProductsController(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productDataService.ListProductsAsync();

            return products.ToList();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategoryId(int id)
        {
            var products = await _productDataService.ListProductsByCategoryIdAsync(id);

            return products.ToList();
        }

        [HttpGet("[action]/{categoryName}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategoryName(string categoryName)
        {
            var products = await _productDataService.ListProductsByCategoryNameAsync(categoryName);

            return products.ToList();
        }

        [HttpPost]
        public async Task AddProduct(Product product)
        {
            await _productDataService.AddProduct(product);
        }

    }
}