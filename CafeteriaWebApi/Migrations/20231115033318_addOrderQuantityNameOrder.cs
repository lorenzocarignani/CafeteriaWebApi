using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addOrderQuantityNameOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderIdOrder",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdOrder",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTime(2023, 11, 15, 0, 33, 18, 309, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 1,
                column: "OrderIdOrder",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderIdOrder",
                table: "Products",
                column: "OrderIdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderIdOrder",
                table: "Products",
                column: "OrderIdOrder",
                principalTable: "Orders",
                principalColumn: "IdOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderIdOrder",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderIdOrder",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderIdOrder",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdOrder",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTime(2023, 11, 12, 21, 47, 4, 100, DateTimeKind.Local).AddTicks(8071));
        }
    }
}
