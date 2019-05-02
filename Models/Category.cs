using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Products.Api.Models
{
    public class Category
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
