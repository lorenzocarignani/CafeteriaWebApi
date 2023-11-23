using System;
using CafeteriaWebApi.Enums;

namespace CafeteriaWebApi.Data.Models
{
	public class ClientResponseDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public StateUser UserState { get; set; } = StateUser.Enabled;
        public List<OrderResponseDto> Orders { get; set; }
    }
}

