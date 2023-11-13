using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CafeteriaWebApi.Enums;

namespace CafeteriaWebApi.Data.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdOrder { get; set; }
        public StateOrder State { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryTime { get; set; }

        [ForeignKey("ClientId")]
        public Client? Clients { get; set; }
        public int ClientId { get; set; }

        public ICollection<SaleOrderLine>? SaleOrderLines { get; set; }
    }
}
