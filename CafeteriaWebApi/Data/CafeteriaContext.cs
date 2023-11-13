using CafeteriaWebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaWebApi.Data
{
    public class CafeteriaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SaleOrderLine> SaleOrderLines { get; set; }
        public DbSet<Product> Products { get; set; }

        public CafeteriaContext(DbContextOptions<CafeteriaContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Name = "admin",
                    Password = "admin",
                    Email = "admin@gmail.com"

                });


            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 2,
                    Name= "client",
                    Password = "client",
                    Email = "client@gmail.com"
                });

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    IdOrder = 1,
                    State = Enums.StateOrder.Waiting,
                    TotalPrice = 1050,
                    DeliveryTime = DateTime.Now,
                    ClientId = 2
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    IdProduct = 1,
                    NameProduct = "Cafe",
                    Price = 1
                });



            modelBuilder.Entity<Client>()
                .HasMany(p => p.Orders)
                .WithOne(c => c.Clients)
                .HasForeignKey(k => k.ClientId);

            modelBuilder.Entity<Order>()
                .HasMany(sol => sol.SaleOrderLines)
                .WithOne(p => p.Orders)
                .HasForeignKey(i => i.OrderId);

            modelBuilder.Entity<SaleOrderLine>()
                .HasOne(l => l.Products)
                .WithMany()
                .HasForeignKey(i => i.ProductId);
        }
    }
}
