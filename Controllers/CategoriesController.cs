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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryDataService _categoryDataService;

        public CategoriesController(ICategoryDataService categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryDataService.GetCategoriesAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryItem(long id)
        {
            var todoItem = await _categoryDataService.GetCategoryAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Categories
        [HttpPost]
        [EnableCors("_myAllowSpecificOrigins")]
        public async Task<ActionResult> Post([FromBody] Category value)
        {
            await _categoryDataService.AddCategory(value);

            return CreatedAtAction(nameof(GetCategoryItem), new { id = value.Id }, value);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
