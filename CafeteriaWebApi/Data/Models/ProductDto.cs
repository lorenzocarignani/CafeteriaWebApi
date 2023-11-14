using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebApi.Data.Models
{
    public class ProductDto
    {
        [Required]
        public decimal Price { get; set; }
        [Required] 
        public string? NameProduct { get; set; }
    }
}
