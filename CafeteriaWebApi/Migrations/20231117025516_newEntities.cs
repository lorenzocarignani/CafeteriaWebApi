using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class newEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "NameOrder",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdOrder",
                keyValue: 1,
                columns: new[] { "DeliveryTime", "NameOrder" },
                values: new object[] { new DateTime(2023, 11, 16, 23, 55, 15, 695, DateTimeKind.Local).AddTicks(2950), "Cafe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOrder",
                table: "Orders");

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
                value: new DateTime(2023, 11, 16, 18, 57, 31, 856, DateTimeKind.Local).AddTicks(829));

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
    }
}
