using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Products.Api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double RegularPrice { get; set; }
        public double SalesPrice { get; set; }
        public double PercentDiscount => RegularPrice / SalesPrice > 0 ? RegularPrice / SalesPrice : 0;
        public string ProductImageUrl { get; set; }

        public int CategoryId { get; set; }
    }
}
