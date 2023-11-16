using System;
using System.ComponentModel.DataAnnotations;
using CafeteriaWebApi.Data.Entities;

namespace CafeteriaWebApi.Data.Models
{
	public class OrderDto
	{
        [Required]
        public ICollection<Product> NameOrder { get; set; }
        public int Quantity { get; set; }
    }
}

