using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CafeteriaWebApi.Enums;

namespace CafeteriaWebApi.Data.Entities
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? UserType { get; set; }
        public StateUser UserState { get; set; } = StateUser.Enabled;
    }
}
