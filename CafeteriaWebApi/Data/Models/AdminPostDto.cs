﻿using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebApi.Data.Models
{
    public class AdminPostDto
    {
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }

    }
}
