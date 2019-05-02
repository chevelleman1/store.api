using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Products.Api.Data;
using Store.Products.Api.Data.Interfaces;
using Store.Products.Api.Models;

namespace Store.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public async Task AddProduct(Product product)
        {
            await _productDataService.AddProduct(product);
        }

    }
}