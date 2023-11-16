using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeteriaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTableQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdminId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Users_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameProduct = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    AdminId = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderIdOrder = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder");
                    table.ForeignKey(
                        name: "FK_Products_Users_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderLines",
                columns: table => new
                {
                    IdSaleOrderLine = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuantityOfProduct = table.Column<int>(type: "INTEGER", nullable: false),
                    Discount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderLines", x => x.IdSaleOrderLine);
                    table.ForeignKey(
                        name: "FK_SaleOrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrderLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "AdminId", "NameProduct", "OrderIdOrder", "Price" },
                values: new object[] { 1, null, "Cafe", null, 1m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "State", "UserType" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "admin", "admin", true, "Admin" },
                    { 2, "client@gmail.com", "client", "client", true, "Client" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "IdOrder", "AdminId", "ClientId", "DeliveryTime", "Quantity", "State", "TotalPrice" },
                values: new object[] { 1, null, 2, new DateTime(2023, 11, 16, 18, 55, 33, 844, DateTimeKind.Local).AddTicks(3814), 0m, 1, 1050m });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdminId",
                table: "Orders",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AdminId",
                table: "Products",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderIdOrder",
                table: "Products",
                column: "OrderIdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLines_OrderId",
                table: "SaleOrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLines_ProductId",
                table: "SaleOrderLines",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleOrderLines");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
