using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SaleOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSaleOrderLine");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "SaleOrderLines");

            migrationBuilder.AddColumn<int>(
                name: "ProductIdProduct",
                table: "SaleOrderLines",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdOrder",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTime(2023, 11, 23, 22, 5, 18, 32, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLines_ProductIdProduct",
                table: "SaleOrderLines",
                column: "ProductIdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrderLines_Products_ProductIdProduct",
                table: "SaleOrderLines",
                column: "ProductIdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrderLines_Products_ProductIdProduct",
                table: "SaleOrderLines");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrderLines_ProductIdProduct",
                table: "SaleOrderLines");

            migrationBuilder.DropColumn(
                name: "ProductIdProduct",
                table: "SaleOrderLines");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "SaleOrderLines",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ProductSaleOrderLine",
                columns: table => new
                {
                    ProductIdProduct = table.Column<int>(type: "INTEGER", nullable: false),
                    SaleOrderLinesIdSaleOrderLine = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSaleOrderLine", x => new { x.ProductIdProduct, x.SaleOrderLinesIdSaleOrderLine });
                    table.ForeignKey(
                        name: "FK_ProductSaleOrderLine_Products_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSaleOrderLine_SaleOrderLines_SaleOrderLinesIdSaleOrderLine",
                        column: x => x.SaleOrderLinesIdSaleOrderLine,
                        principalTable: "SaleOrderLines",
                        principalColumn: "IdSaleOrderLine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdOrder",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTime(2023, 11, 23, 19, 17, 18, 886, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaleOrderLine_SaleOrderLinesIdSaleOrderLine",
                table: "ProductSaleOrderLine",
                column: "SaleOrderLinesIdSaleOrderLine");
        }
    }
}
