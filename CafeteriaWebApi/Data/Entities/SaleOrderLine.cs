using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaWebApi.Data.Entities
{
    public class SaleOrderLine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdSaleOrderLine { get; set; }
        public int QuantitySaleOrderLine { get; set; }
        public string NameSaleOrderLine { get; set; }
        public decimal PriceSaleOrderLine { get; set; }


        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
        public int OrderId { get; set; }
    }
}
