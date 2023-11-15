using System;
using System.ComponentModel.DataAnnotations;
using CafeteriaWebApi.Data.Entities;

namespace CafeteriaWebApi.Data.Models
{
	public class OrderDto
	{
        [Required]
        public ICollection<Product> NameOrder { get; set; }
       // [Required]
        //public decimal Quantity { get; set; }
    }
}

