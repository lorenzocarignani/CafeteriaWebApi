using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebApi.Data.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdProduct { get; set; }
        public string? NameProduct { get; set; }
        public decimal Price { get; set; }

        public ICollection<SaleOrderLine>? SaleOrderLines { get; set; }
    }
}
