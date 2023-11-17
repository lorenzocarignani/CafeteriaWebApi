using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebApi.Data.Entities
{
    public class SaleOrderLine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdSaleOrderLine { get; set; }
        public int QuantityOfProduct { get; set; }
        public decimal Discount { get; set; }

        [ForeignKey("ProductId")]
        public Product? Products { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("OrderId")]
        public Order? Orders { get; set; }
        public int OrderId { get; set; }

        public ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
