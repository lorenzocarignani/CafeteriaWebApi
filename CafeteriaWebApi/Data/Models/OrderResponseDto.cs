using System;
using CafeteriaWebApi.Enums;

namespace CafeteriaWebApi.Data.Models
{
	public class OrderResponseDto
	{
        public int IdOrder { get; set; }
        public StateOrder State { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryTime { get; set; }
        public int Quantity { get; set; }
        public string NameOrder { get; set; }
        public int ClientId { get; set; }
        
    }
}

